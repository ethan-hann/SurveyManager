
namespace SurveyManager.forms.userControls
{
    partial class ViewMessageCtl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.msgHeaderGroup = new ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup();
            this.btnForward = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnReply = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.btnDownloadAttachments = new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.lvAttachments = new System.Windows.Forms.ListView();
            this.lblTo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblSenderName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.chromeContainer = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.msgHeaderGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.msgHeaderGroup.Panel)).BeginInit();
            this.msgHeaderGroup.Panel.SuspendLayout();
            this.msgHeaderGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chromeContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // msgHeaderGroup
            // 
            this.msgHeaderGroup.ButtonSpecs.AddRange(new ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup[] {
            this.btnForward,
            this.btnReply,
            this.btnDownloadAttachments});
            this.msgHeaderGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgHeaderGroup.Location = new System.Drawing.Point(0, 0);
            this.msgHeaderGroup.Name = "msgHeaderGroup";
            // 
            // msgHeaderGroup.Panel
            // 
            this.msgHeaderGroup.Panel.Controls.Add(this.chromeContainer);
            this.msgHeaderGroup.Panel.Controls.Add(this.kryptonPanel1);
            this.msgHeaderGroup.Size = new System.Drawing.Size(1032, 769);
            this.msgHeaderGroup.TabIndex = 4;
            this.msgHeaderGroup.ValuesPrimary.Description = "<Sent Date>";
            this.msgHeaderGroup.ValuesPrimary.Heading = "<Subject>";
            this.msgHeaderGroup.ValuesPrimary.Image = null;
            this.msgHeaderGroup.ValuesSecondary.Heading = "";
            // 
            // btnForward
            // 
            this.btnForward.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.btnForward.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnForward.Image = global::SurveyManager.Properties.Resources.forward_16x16;
            this.btnForward.Text = "Forward";
            this.btnForward.UniqueName = "7EDCFF16E17B466E3197D96ABC6C2DB9";
            // 
            // btnReply
            // 
            this.btnReply.Edge = ComponentFactory.Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            this.btnReply.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnReply.Image = global::SurveyManager.Properties.Resources.reply_16x16;
            this.btnReply.Text = "Reply";
            this.btnReply.UniqueName = "47CDC34563224D847DB02AA92AD7EB4A";
            // 
            // btnDownloadAttachments
            // 
            this.btnDownloadAttachments.HeaderLocation = ComponentFactory.Krypton.Toolkit.HeaderLocation.SecondaryHeader;
            this.btnDownloadAttachments.Image = global::SurveyManager.Properties.Resources.download_16x16;
            this.btnDownloadAttachments.Text = "Download Attachments";
            this.btnDownloadAttachments.UniqueName = "82B2CC24A0AC40A25086391636F8FF24";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.lvAttachments);
            this.kryptonPanel1.Controls.Add(this.lblTo);
            this.kryptonPanel1.Controls.Add(this.lblSenderName);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(1030, 63);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // lvAttachments
            // 
            this.lvAttachments.Dock = System.Windows.Forms.DockStyle.Right;
            this.lvAttachments.HideSelection = false;
            this.lvAttachments.Location = new System.Drawing.Point(701, 0);
            this.lvAttachments.Name = "lvAttachments";
            this.lvAttachments.Size = new System.Drawing.Size(329, 63);
            this.lvAttachments.TabIndex = 1;
            this.lvAttachments.UseCompatibleStateImageBehavior = false;
            this.lvAttachments.View = System.Windows.Forms.View.SmallIcon;
            this.lvAttachments.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvAttachments_MouseDoubleClick);
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(3, 33);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(166, 21);
            this.lblTo.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblTo.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.TabIndex = 1;
            this.lblTo.Values.ExtraText = "hannethan@gmail.com";
            this.lblTo.Values.Text = "to";
            // 
            // lblSenderName
            // 
            this.lblSenderName.Location = new System.Drawing.Point(3, 3);
            this.lblSenderName.Name = "lblSenderName";
            this.lblSenderName.Size = new System.Drawing.Size(235, 24);
            this.lblSenderName.StateCommon.LongText.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderName.StateCommon.ShortText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenderName.TabIndex = 0;
            this.lblSenderName.Values.ExtraText = "<noreply@youtube.com>";
            this.lblSenderName.Values.Text = "YouTube";
            // 
            // chromeContainer
            // 
            this.chromeContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chromeContainer.Location = new System.Drawing.Point(0, 63);
            this.chromeContainer.Name = "chromeContainer";
            this.chromeContainer.Size = new System.Drawing.Size(1030, 647);
            this.chromeContainer.TabIndex = 1;
            // 
            // ViewMessageCtl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.msgHeaderGroup);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ViewMessageCtl";
            this.Size = new System.Drawing.Size(1032, 769);
            this.Load += new System.EventHandler(this.ViewMessageCtl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.msgHeaderGroup.Panel)).EndInit();
            this.msgHeaderGroup.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.msgHeaderGroup)).EndInit();
            this.msgHeaderGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chromeContainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonHeaderGroup msgHeaderGroup;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnForward;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnReply;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTo;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblSenderName;
        private System.Windows.Forms.ListView lvAttachments;
        private ComponentFactory.Krypton.Toolkit.ButtonSpecHeaderGroup btnDownloadAttachments;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel chromeContainer;
    }
}
