using ComponentFactory.Krypton.Toolkit;
using Ionic.Zip;
using SurveyManager.backend.wrappers;
using SurveyManager.forms.dialogs;
using SurveyManager.Properties;
using SurveyManager.utility;
using SurveyManager.utility.Icons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;

namespace SurveyManager.forms.fileMenu
{
    public partial class FileBrowser : KryptonForm
    {
        private List<CFile> files;
        private ImageList _smallImageList = new ImageList();
        private ImageList _largeImageList = new ImageList();
        private IconListManager _iconListManager;

        public EventHandler StatusUpdate;

        public FileBrowser(List<CFile> filesToView)
        {
            InitializeComponent();

            _smallImageList.ColorDepth = ColorDepth.Depth32Bit;
            _largeImageList.ColorDepth = ColorDepth.Depth32Bit;

            _smallImageList.ImageSize = new Size(16, 16);
            _largeImageList.ImageSize = new Size(32, 32);

            filesList.SmallImageList = _smallImageList;
            filesList.LargeImageList = _largeImageList;

            _iconListManager = new IconListManager(_smallImageList, _largeImageList);

            files = filesToView;

            foreach (CFile file in files)
            {
                string filePath = file.GetTempFile();
                ListViewItem item = new ListViewItem(file.FullFileName, _iconListManager.AddFileIcon(filePath));
                item.Tag = file;
                filesList.Items.Add(item);
            }

            btnDownloadFiles.Click += DownloadFiles;
        }

        private void DownloadFiles(object sender, EventArgs e)
        {
            if (filesList.SelectedItems.Count > 0)
            {
                if (filesList.SelectedItems.Count == 1)
                {
                    SaveOneFile(filesList.SelectedItems[0].Tag as CFile);
                }
                else
                {
                    SaveMultipleFiles();
                }
            }
            else
            {
                StatusUpdate?.Invoke(this, new StatusArgs("No files were selected. Nothing to download!"));
            }
        }

        private void SaveOneFile(CFile file)
        {
            saveDialog.Filter = $"(*.{file.Extension.ToString().ToLower()})|*.{file.Extension.ToString().ToLower()}";
            saveDialog.Title = "Download File";
            saveDialog.FileName = file.FileName;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    File.WriteAllBytes(saveDialog.FileName, file.Contents);
                    StatusUpdate?.Invoke(this, new StatusArgs(file.FullFileName + " downloaded from Job# " + JobHandler.Instance.CurrentJob.JobNumber + ". Saved to " + saveDialog.FileName));
                }
                catch (Exception)
                {
                    CMessageBox.Show("There was an error saving the file: " + saveDialog.FileName + "\nPlease try again.", "Error", MessageBoxButtons.OK, Resources.error_64x64);
                    StatusUpdate?.Invoke(this, new StatusArgs("File " + file.FullFileName + " could not be saved."));
                }
            }
        }

        private void SaveMultipleFiles()
        {
            saveDialog.Filter = "Compressed Zip Archive (*.zip)|*.zip";
            saveDialog.Title = "Download Multiple Files";
            saveDialog.FileName = JobHandler.Instance.CurrentJob.JobNumber;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                List<CFile> filesToSave = new List<CFile>();
                foreach (ListViewItem item in filesList.SelectedItems)
                {
                    filesToSave.Add(item.Tag as CFile);
                }

                using (ZipFile zip = new ZipFile())
                {
                    foreach (CFile file in filesToSave)
                    {
                        zip.AddEntry(file.FullFileName, file.Contents);
                    }

                    zip.Save(saveDialog.FileName);
                }
                StatusUpdate?.Invoke(this, new StatusArgs(RuntimeVars.Instance.TempFiles.Count + " files downloaded from Job# " + JobHandler.Instance.CurrentJob.JobNumber + ". Zip archive saved to: " + saveDialog.FileName));
            }
        }

        private void FileBrowser_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.folder_64x64.GetHicon());
        }

        private void filesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView senderList = sender as ListView;
            if (senderList != null)
            {
                ListViewItem clickedItem = senderList.HitTest(e.Location).Item;
                if (clickedItem != null)
                    Process.Start((clickedItem.Tag as CFile).TempPath);
            }
        }

        private void filesList_MouseClick(object sender, MouseEventArgs e)
        {
            ListView senderList = sender as ListView;
            if (senderList != null)
            {
                ListViewItem clickedItem = senderList.HitTest(e.Location).Item;
                if (clickedItem != null)
                {
                    splitPanels.Panel2Collapsed = false;
                    splitPanels.Panel2.Show();
                    propGrid.SelectedObject = (clickedItem.Tag as CFile);
                }
            }
        }

        private void FileBrowser_FormClosed(object sender, FormClosedEventArgs e)
        {
            RuntimeVars.Instance.TempFiles.Delete();
        }
    }
}
