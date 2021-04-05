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
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.surveyMenu
{
    public partial class UploadFile : KryptonForm
    {
        public EventHandler StatusUpdate;

        public UploadFile()
        {
            InitializeComponent();
        }

        private void UploadFile_Load(object sender, EventArgs e)
        {
            Icon = Icon.FromHandle(Resources.file_16x16.GetHicon());

            btnSave.Click += SaveFiles;
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            StringBuilder bldr = new StringBuilder();
            List<CFile> filesToAdd = new List<CFile>();

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in fileDialog.FileNames)
                {
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
                    f.ReadAllBytes(fInfo.FullName);
                    filesToAdd.Add(f);
                }

                lbFileNames.Items.AddRange(filesToAdd.ToArray());
                Text = $"Upload Files - Total Size to Upload = {Utility.FormatSize(lbFileNames.Items.Cast<CFile>().Sum(e => e.Contents.Length))}";

                if (bldr.Length != 0)
                    CRichMsgBox.Show("The following files were to big to be added to the database:", "Files to big",
                        bldr.ToString(), MessageBoxButtons.OK, Resources.error_64x64);

                StatusUpdate?.Invoke(this, new StatusArgs($"{filesToAdd.Count} files pending upload."));
            }
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            int count = lbFileNames.SelectedIndices.Count;
            if (count > 0)
            {
                for (int i = count - 1; i >= 0; i--)
                {
                    lbFileNames.Items.RemoveAt(i);
                }

                Text = $"Upload Files - Total Size to Upload = {Utility.FormatSize(lbFileNames.Items.Cast<CFile>().Sum(e => e.Contents.Length))}";
                StatusUpdate?.Invoke(this, new StatusArgs($"Removed {count} files from pending upload."));
            }
        }

        private void SaveFiles(object sender, EventArgs e)
        {
            
        }

        private void lbFileNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbFileNames.SelectedIndex >= 0)
                propGrid.SelectedObject = (CFile)lbFileNames.Items[lbFileNames.SelectedIndex];
        }
    }
}
