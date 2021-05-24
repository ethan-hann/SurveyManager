using ComponentFactory.Krypton.Toolkit;
using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MimeKit;
using SurveyManager.forms.userControls;
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
        private List<IEmailMessageControl> messages = new List<IEmailMessageControl>();

        private delegate void AddNode(TreeNode n);

        public ViewEmail()
        {
            InitializeComponent();
        }

        public ViewEmail(List<IEmailMessageControl> messages)
        {
            InitializeComponent();

            this.messages = messages;
        }

        private void ViewEmail_Load(object sender, EventArgs e)
        {
            client.Connect(Settings.Default.IncomingMailServer, Settings.Default.IncomingMailPort, Settings.Default.IncomingMailRequiresSSL);
            client.Authenticate(Settings.Default.MailServerUser, Settings.Default.MailServerPassword);
            
            tvMailbox.Nodes.Add("inboxNode", "Inbox");

            if (messages.Count <= 0)
                fetchMailWorker.RunWorkerAsync();
            else
                PopulateMessages();
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

        private void PopulateMessages()
        {
            TreeNode[] messageNodes = new TreeNode[messages.Count];
            for (int i = 0; i < messages.Count; i++)
            {
                MimeMessage message = messages[i].MessageDetails;
                messageNodes[i] = new TreeNode($"{message.From}: {message.Subject}");
                messageNodes[i].Tag = message;
                currentNode = messageNodes[i];

                tvMailbox.Nodes["inboxNode"].Nodes.Add(currentNode);
                lblStatus.Text = $"Retrieving message {i} of {messages.Count}...";
            }
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

                if (e.Node.Tag.GetType() == typeof(MimeMessage))
                {
                    splitContainer.Panel2.Controls.Clear();
                    bool contains = messages.Where(m => m.UniqueHash == e.Node.GetHashCode()).Any();
                    if (contains)
                    {
                        ViewMessageCtl ctl = messages.Find(m => m.UniqueHash == e.Node.GetHashCode()) as ViewMessageCtl;
                        if (ctl != null)
                        {
                            ctl.Dock = DockStyle.Fill;
                            splitContainer.Panel2.Controls.Add(ctl);
                        }
                    }
                    else
                    {
                        ViewMessageCtl ctl = new ViewMessageCtl(e.Node.Tag as MimeMessage, e.Node.GetHashCode());
                        messages.Add(ctl);
                        ctl.Dock = DockStyle.Fill;
                        splitContainer.Panel2.Controls.Add(ctl);
                    }
                }
            }
        }
    }
}
