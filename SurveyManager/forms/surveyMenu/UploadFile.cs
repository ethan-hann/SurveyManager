using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend;
using SurveyManager.backend.wrappers;
using SurveyManager.forms.dialogs;
using SurveyManager.Properties;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.surveyMenu
{
    public partial class UploadFile : KryptonForm
    {
        private StringBuilder bldr = new StringBuilder();
        private List<CFile> filesToAdd = new List<CFile>();
        private string currentFileName = "";
        private bool saved = false;

        private Thread backgroundThread;

        public EventHandler StatusUpdate;

        /// <summary>
        /// Occurs whenever the file upload is done and the user clicks the Save button. Simply passes the list of files along to the subscriber of this event.
        /// </summary>
        public EventHandler FileUploadDone;

        public UploadFile(List<CFile> files = null)
        {
            InitializeComponent();

            if (files != null)
                filesToAdd = files;
        }

        private void UploadFile_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.attachment.GetHicon());

            btnSave.Click += SaveFiles;

            if (filesToAdd.Count > 0)
            {
                lbFileNames.Items.AddRange(filesToAdd.ToArray());
            }

            lblFileSize.Text = "Total File Size For This Job: " + Utility.FormatSize(lbFileNames.Items.Cast<CFile>().Sum(e => e.Contents.Length));
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                progressBar.Value = 0;
                tblProgress.Visible = true;
                progressBar.Maximum = fileDialog.FileNames.Length;
                bgWorker.RunWorkerAsync();
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                backgroundThread = Thread.CurrentThread;

                filesToAdd = new List<CFile>();
                bldr = new StringBuilder();

                int counter = 0;
                foreach (string fileName in fileDialog.FileNames)
                {
                    bgWorker.ReportProgress(counter);

                    FileInfo fInfo = new FileInfo(fileName);
                    if (fInfo.Length > Database.MAX_ALLOWED_PACKET_SIZE)
                    {
                        bldr.Append(fInfo.FullName + "\n");
                        continue;
                    }

                    CFile f = new CFile
                    {
                        FileName = Path.GetFileNameWithoutExtension(fInfo.FullName),
                        Extension = (FileExtension)Enum.Parse(typeof(FileExtension), fInfo.Extension.ToUpper().Replace(".", "")),
                    };

                    if (f.ReadAllBytes(fInfo.FullName))
                    {
                        currentFileName = fInfo.FullName;
                        filesToAdd.Add(f);
                    }
                    else
                        bldr.Append(fInfo.FullName + "\n");

                    counter++;
                }
            }
            catch (ThreadAbortException)
            {

            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            StatusUpdate?.Invoke(this, new StatusArgs($"Processing: {currentFileName}"));
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lbFileNames.Items.AddRange(filesToAdd.ToArray());
            lblFileSize.Text = "Total File Size For This Job: " + Utility.FormatSize(lbFileNames.Items.Cast<CFile>().Sum(e => e.Contents.Length));

            if (bldr.Length != 0)
                CRichMsgBox.Show("The following files were either too big to be added to the database or an error occured while reading them:", "File Error",
                    bldr.ToString(), MessageBoxButtons.OK, Resources.error_64x64);

            StatusUpdate?.Invoke(this, new StatusArgs($"{filesToAdd.Count} files pending upload."));

            progressBar.Value = 0;
            tblProgress.Visible = false;

            JobHandler.Instance.UpdateSavePending(true);
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            int count = lbFileNames.SelectedIndices.Count;
            if (count > 0)
            {
                for (int i = count - 1; i >= 0; i--)
                {
                    int idx = lbFileNames.SelectedIndices[i];
                    lbFileNames.Items.RemoveAt(idx);
                }

                lblFileSize.Text = "Total File Size For This Job: " + Utility.FormatSize(lbFileNames.Items.Cast<CFile>().Sum(e => e.Contents.Length));
                StatusUpdate?.Invoke(this, new StatusArgs($"Removed {count} files from pending upload."));
                Application.DoEvents();

                if (lbFileNames.Items.Count > 0)
                    propGrid.SelectedObject = lbFileNames.Items[0];
                else
                    propGrid.SelectedObject = null;

                StatusUpdate?.Invoke(this, new StatusArgs($"{lbFileNames.Items.Count} files pending upload."));
            }

            JobHandler.Instance.UpdateSavePending(true);
        }

        private void SaveFiles(object sender, EventArgs e)
        {
            if (lbFileNames.Items.Count > 0)
            {
                FileUploadDone?.Invoke(this, new FileUploadDoneArgs(lbFileNames.Items.Cast<CFile>().ToList()));
                DialogResult = DialogResult.OK;

            }
            else
            {
                FileUploadDone?.Invoke(this, new FileUploadDoneArgs(new List<CFile>()));
                DialogResult = DialogResult.Cancel;
            }

            saved = true;
            JobHandler.Instance.UpdateSavePending(true);
            Close();
        }

        private void lbFileNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbFileNames.SelectedIndex >= 0)
            {
                propGrid.SelectedObject = (CFile)lbFileNames.Items[lbFileNames.SelectedIndex];
                picBox.Image = ((CFile)propGrid.SelectedObject).DisplayIcon;
                picPanel.Visible = true;
            }
            else
            {
                picPanel.Visible = false;
            }
        }

        private void UploadFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bgWorker.IsBusy)
            {
                backgroundThread.Abort();
                StatusUpdate?.Invoke(this, new StatusArgs($"File upload canceled."));
            }

            if (!saved)
                StatusUpdate?.Invoke(this, new StatusArgs($"File upload canceled."));

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void btnCancelLoading_Click(object sender, EventArgs e)
        {
            if (bgWorker.IsBusy)
            {
                backgroundThread.Abort();
                StatusUpdate?.Invoke(this, new StatusArgs($"File upload cancelled."));

                GC.Collect();
                GC.WaitForPendingFinalizers();

                progressBar.Value = 0;
                tblProgress.Visible = false;
            }
        }
    }
}
