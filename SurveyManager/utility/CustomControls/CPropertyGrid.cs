using SurveyManager.Properties;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SurveyManager.utility.CustomControls
{
    public partial class CPropertyGrid : PropertyGrid
    {
        ToolStripButton acceptButton = new ToolStripButton("Save");
        ToolStripButton clearButton = new ToolStripButton("Clear");
        ToolStripButton uploadFiles = new ToolStripButton("Upload Files");
        ToolStripButton downloadFiles = new ToolStripButton("Download Files");
        ToolStripButton openJob = new ToolStripButton("Open Selected Job");

        public CPropertyGrid()
        {
            InitializeComponent();

            acceptButton.Image = Resources.success_16x16;
            clearButton.Image = Resources.error_16x16;
            uploadFiles.Image = Resources.file_16x16;
            downloadFiles.Image = Resources.download_16x16;
            openJob.Image = Resources.open_16x16;
            acceptButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            clearButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            uploadFiles.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            downloadFiles.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            openJob.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

            AddButtons();
        }

        public CPropertyGrid(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            acceptButton.Image = Resources.success_16x16;
            clearButton.Image = Resources.error_16x16;
            uploadFiles.Image = Resources.file_16x16;
            downloadFiles.Image = Resources.download_16x16;
            openJob.Image = Resources.open_16x16;
            acceptButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            clearButton.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            uploadFiles.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            downloadFiles.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            openJob.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;

            AddButtons();
        }

        private void AddButtons()
        {
            ToolStrip toolStrip = null;
            foreach (Control c in Controls)
            {
                toolStrip = c as ToolStrip;
                if (toolStrip != null)
                    break;
            }

            if (toolStrip != null)
            {
                //Hide the property pages button
                toolStrip.Items[4].Visible = false;

                //Add our custom buttons
                toolStrip.Items.Add(acceptButton);
                toolStrip.Items.Add(clearButton);
                toolStrip.Items.Add(uploadFiles);
                toolStrip.Items.Add(downloadFiles);
                toolStrip.Items.Add(openJob);
                uploadFiles.Visible = false;
                downloadFiles.Visible = false;
                openJob.Visible = false;
            }
        }

        public ToolStripButton GetAcceptButton()
        {
            return acceptButton;
        }

        public ToolStripButton GetClearButton()
        {
            return clearButton;
        }

        public ToolStripButton GetUploadFilesButton()
        {
            return uploadFiles;
        }

        public ToolStripButton GetDownloadFilesButton()
        {
            return downloadFiles;
        }

        public ToolStripButton GetOpenJobButton()
        {
            return openJob;
        }

        protected override bool ProcessTabKey(bool forward)
        {
            var grid = this.Controls[2];
            var field = grid.GetType().GetField("allGridEntries",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);
            var entries = (field.GetValue(grid) as IEnumerable).Cast<GridItem>().ToList();
            var index = entries.IndexOf(this.SelectedGridItem);

            if (forward && index < entries.Count - 1)
            {
                var next = entries[index + 1];
                next.Select();
                return true;
            }
            return base.ProcessTabKey(forward);
        }
    }
}
