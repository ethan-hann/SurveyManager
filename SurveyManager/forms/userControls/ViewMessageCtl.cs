using CefSharp;
using CefSharp.WinForms;
using MimeKit;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;

namespace SurveyManager.forms.userControls
{
    public partial class ViewMessageCtl : UserControl, IEmailMessageControl
    {
        private MimeMessage currentMessage;
        private ChromiumWebBrowser chromeBrowser;
        private int uniqueTag;

        ChromiumWebBrowser IEmailMessageControl.Browser { get => chromeBrowser; set => chromeBrowser = value; }
        MimeMessage IEmailMessageControl.MessageDetails { get => currentMessage; set => currentMessage = value; }

        int IEmailMessageControl.UniqueHash { get => uniqueTag; set => uniqueTag = value; }

        public ViewMessageCtl(MimeMessage messageToDisplay, int uniqueTag)
        {
            InitializeComponent();

            InitializeChromium();
            currentMessage = messageToDisplay;
            this.uniqueTag = uniqueTag;
        }

        private void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            if (!Cef.IsInitialized)
                Cef.Initialize(settings);

            chromeBrowser = new ChromiumWebBrowser("http://rendering/");
            chromeBrowser.Dock = DockStyle.Fill;

            chromeContainer.Controls.Add(chromeBrowser);
        }

        private void ViewMessageCtl_Load(object sender, EventArgs e)
        {
            if (currentMessage != null)
            {
                msgHeaderGroup.ValuesPrimary.Heading = currentMessage.Subject;
                msgHeaderGroup.ValuesPrimary.Description = currentMessage.Date.DateTime.ToLongDateString();

                FormatFromAddress();
                lblTo.Values.ExtraText = currentMessage.To.ToString();

                LoadMessage();

                if (currentMessage.Attachments.Count() > 0)
                    PopulateAttachments();
                else
                {
                    lvAttachments.Visible = false;
                    btnDownloadAttachments.Visible = false;
                }
                    
            }
        }

        private void FormatFromAddress()
        {
            if (currentMessage == null)
                return;

            List<MailboxAddress> mailboxes = currentMessage.From.Mailboxes.ToList();
            lblSenderName.Values.Text = mailboxes.First().Name;
            lblSenderName.Values.ExtraText = $"<{mailboxes.First().Address}>";

            for (int i = 1; i < mailboxes.Count - 1; i++)
            {
                lblSenderName.Values.ExtraText += $"{mailboxes[i].Name} <{mailboxes[i].Address}>, ";
            }

            if (mailboxes.First() != mailboxes.Last())
                lblSenderName.Values.ExtraText += $"{mailboxes.Last().Name} <{mailboxes.Last().Address}>";
        }

        private void LoadMessage()
        {
            if (currentMessage != null)
            {
                string text = "Message could not be displayed.";
                if (currentMessage.HtmlBody != null)
                    text = currentMessage.HtmlBody;
                else if (currentMessage.TextBody != null)
                    text = currentMessage.TextBody;

                if (chromeBrowser.LoadHtml(text, "http://rendering/"))
                {
                    chromeBrowser.Invalidate();
                    chromeBrowser.Update();
                }
                else
                {
                    RuntimeVars.Instance.MainForm.ChangeStatusText(this, new StatusArgs($"Could not load html webpage: {currentMessage.Subject}"));
                }
            }
        }

        private void PopulateAttachments()
        {
            if (currentMessage == null)
                return;

            lvAttachments.Visible = true;
            btnDownloadAttachments.Visible = true;

            foreach (MimeEntity attachment in currentMessage.Attachments)
            {
                try
                {
                    ListViewItem attachItem = new ListViewItem(attachment.ContentBase.LocalPath);
                    attachItem.Tag = attachment;
                    lvAttachments.Items.Add(attachItem);
                } catch (Exception)
                {
                    RuntimeVars.Instance.LogFile.AddEntry($"Error while processing attachments for email message: {currentMessage.Subject}");
                }
            }
        }

        private void lvAttachments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView senderList = sender as ListView;
            if (senderList != null)
            {
                ListViewItem clickedItem = senderList.HitTest(e.Location).Item;
                if (clickedItem == null)
                    return;
                Console.WriteLine("Attachment double clicked!");
                //Process.Start((clickedItem.Tag as CFile).TempPath);
            }
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            Cef.Shutdown();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
