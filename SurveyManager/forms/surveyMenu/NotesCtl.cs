using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static SurveyManager.utility.CEventArgs;

namespace SurveyManager.forms.surveyMenu
{
    public partial class NotesCtl : UserControl
    {
        private Dictionary<DateTime, string> notes;

        public EventHandler StatusUpdate;

        public NotesCtl(Dictionary<DateTime, string> notes)
        {
            InitializeComponent();

            this.notes = notes;
        }

        private void NotesCtl_Load(object sender, EventArgs e)
        {
            foreach (DateTime key in notes.Keys)
            {
                lbNoteKeys.Items.Add(key);
            }

            if (lbNoteKeys.Items.Count > 0)
                lbNoteKeys.SelectedIndex = 0;
            else
                txtNoteContents.Enabled = false;

            lblTotalNoteCount.Text = "Total # of Notes: " + lbNoteKeys.Items.Count;

            txtNoteContents.ReadOnly = JobHandler.Instance.ReadOnly;
        }

        private void lbNoteKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbNoteKeys.SelectedIndex >= 0)
            {
                txtNoteContents.Text = notes[(DateTime)lbNoteKeys.Items[lbNoteKeys.SelectedIndex]];
            }
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            if (JobHandler.Instance.ReadOnly)
                return;

            DateTime now = DateTime.Now;
            notes.Add(now, "");
            lbNoteKeys.Items.Add(now);
            lbNoteKeys.SelectedItem = now;

            if (lbNoteKeys.Items.Count > 0)
                txtNoteContents.Enabled = true;
            else
                txtNoteContents.Enabled = false;

            lblTotalNoteCount.Text = "Total # of Notes: " + lbNoteKeys.Items.Count;
        }

        private void btnRemoveNote_Click(object sender, EventArgs e)
        {
            if (JobHandler.Instance.ReadOnly)
                return;

            DateTime selected = (DateTime)lbNoteKeys.SelectedItem;
            notes.Remove(selected);
            lbNoteKeys.Items.Remove(selected);
            lbNoteKeys.SelectedIndex = lbNoteKeys.Items.Count - 1;

            if (lbNoteKeys.Items.Count > 0)
                txtNoteContents.Enabled = true;
            else
                txtNoteContents.Enabled = false;

            lblTotalNoteCount.Text = "Total # of Notes: " + lbNoteKeys.Items.Count;
        }

        private void txtNoteContents_TextChanged(object sender, EventArgs e)
        {
            if (lbNoteKeys.Items.Count <= 0)
                return;

            //Use regular expressions to protect against the user inserting the delimeter for seperating time and note entries in the database.
            MatchCollection mc = Regex.Matches(txtNoteContents.Text, "(\\/\\*--\\*\\/)+", RegexOptions.Multiline);
            foreach (Match m in mc)
            {
                txtNoteContents.Text = txtNoteContents.Text.Remove(m.Index, m.Length);
            }

            //Update the dictionary with the new text value.
            notes[(DateTime)lbNoteKeys.Items[lbNoteKeys.SelectedIndex]] = txtNoteContents.Text;

            //Update the character count
            lblCharCount.Text = "Character Count: " + txtNoteContents.Text.Count() + " / 4,000";
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (!JobHandler.Instance.ReadOnly)
                //When this user control is disposed (closed), update the currently open job with the new notes.
                SaveNotes();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void txtNoteContents_KeyPress(object sender, KeyPressEventArgs e)
        {
            //If the text has been changed, notify about a pending save.
            JobHandler.Instance.UpdateSavePending(true);
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (!JobHandler.Instance.ReadOnly)
                SaveNotes();
        }

        private void SaveNotes()
        {
            if (JobHandler.Instance.IsJobOpen)
            {
                JobHandler.Instance.CurrentJob.Notes = notes;
                StatusUpdate?.Invoke(this, new StatusArgs("Notes for Job# " + JobHandler.Instance.CurrentJob.JobNumber + " updated internally."));
            }
            else
            {
                StatusUpdate?.Invoke(this, new StatusArgs("Invalid operation: <Save Notes> => Job is not opened!"));
            }
        }
    }
}
