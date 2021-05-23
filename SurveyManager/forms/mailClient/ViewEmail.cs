using ComponentFactory.Krypton.Toolkit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MimeKit;
using SurveyManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyManager.forms.mailClient
{
    public partial class ViewEmail : KryptonForm
    {
        private ImapClient client = new ImapClient();

        private delegate void AddNode(TreeNode n);

        public ViewEmail()
        {
            InitializeComponent();
        }

        private void ViewEmail_Load(object sender, EventArgs e)
        {
            btnReply.Click += BtnReply_Click;

            client.Connect(Settings.Default.IncomingMailServer, Settings.Default.IncomingMailPort, Settings.Default.IncomingMailRequiresSSL);
            client.Authenticate(Settings.Default.MailServerUser, Settings.Default.MailServerPassword);
            
            tvMailbox.Nodes.Add("inboxNode", "Inbox");
            fetchMailWorker.RunWorkerAsync();
        }

        private void BtnReply_Click(object sender, EventArgs e)
        {
            SendEmail sendForm = new SendEmail();
            sendForm.Show();
        }

        TreeNode currentNode;

        private void fetchMailWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!client.IsAuthenticated)
            {
                client.Authenticate(Settings.Default.MailServerUser, Settings.Default.MailServerPassword);
            }

            if (!client.IsAuthenticated)
                fetchMailWorker.CancelAsync();

            var inbox = client.Inbox;
            inbox.Open(MailKit.FolderAccess.ReadOnly);

            TreeNode[] messageNodes = new TreeNode[inbox.Count];

            for (int i = 0; i < inbox.Count; i++)
            {
                if (!fetchMailWorker.CancellationPending)
                {
                    MimeMessage message = inbox.GetMessage(i);
                    messageNodes[i] = new TreeNode($"{message.From}: {message.Subject}");
                    messageNodes[i].Tag = message;
                    currentNode = messageNodes[i];
                    fetchMailWorker.ReportProgress(i, new TreeNodeHelper(currentNode, i, inbox.Count));
                }
                else
                {
                    break;
                }
            }
            
            client.Disconnect(true);
        }

        private void fetchMailWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            TreeNodeHelper nodeData = (TreeNodeHelper)e.UserState;
            if (!fetchMailWorker.CancellationPending)
            {
                tvMailbox.Invoke((MethodInvoker)(() => tvMailbox.Nodes["inboxNode"].Nodes.Add(nodeData.currentNode)));
                Invoke((MethodInvoker)(() => lblStatus.Text = $"Retrieving message {e.ProgressPercentage} of {nodeData.totalInboxCount}..."));
            }
        }

        private void fetchMailWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "Mailbox up-to-date!";
        }

        internal struct TreeNodeHelper
        {
            internal TreeNode currentNode;
            internal int nodeIndex;
            internal int totalInboxCount;

            public TreeNodeHelper(TreeNode node, int index, int totalInboxCount)
            {
                currentNode = node;
                nodeIndex = index;
                this.totalInboxCount = totalInboxCount;
            }
        }

        private void ViewEmail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (fetchMailWorker.IsBusy)
                fetchMailWorker.CancelAsync();
        }

        private void tvMailbox_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                if (e.Node.Tag == null)
                    return;

                string text = "Message could not be displayed.";
                messageView.Navigate("about:blank");
                if (messageView.Document != null)
                {
                    if (e.Node.Tag.GetType() == typeof(MimeMessage))
                    {
                        MimeMessage msg = e.Node.Tag as MimeMessage;
                        if (msg.HtmlBody != null)
                            text = msg.HtmlBody;
                        else if (msg.TextBody != null)
                            text = msg.TextBody;

                        lblFrom.Values.ExtraText = msg.From.ToString();
                        lblTo.Values.ExtraText = msg.To.ToString();
                        lblSubject.Values.ExtraText = msg.Subject;
                        lblAttachments.Values.ExtraText = msg.Attachments.Count().ToString();
                    }

                    messageView.DocumentText = text;
                }
            }
        }

        private void messageView_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!e.Url.ToString().Equals("about:blank"))
            {
                Process.Start(e.Url.ToString());
                e.Cancel = true;
            }
        }
    }
}
