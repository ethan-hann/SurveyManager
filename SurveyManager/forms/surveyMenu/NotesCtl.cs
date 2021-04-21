using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveyManager.forms.surveyMenu
{
    public partial class NotesCtl : UserControl
    {
        private Dictionary<DateTime, string> notes;

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

            lblTotalNoteCount.Text = "Total # of Notes: " + lbNoteKeys.Items.Count;
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
            DateTime now = DateTime.Now;
            notes.Add(now, "");
            lbNoteKeys.Items.Add(now);
            lbNoteKeys.SelectedItem = now;

            lblTotalNoteCount.Text = "Total # of Notes: " + lbNoteKeys.Items.Count;
        }

        private void btnRemoveNote_Click(object sender, EventArgs e)
        {
            DateTime selected = (DateTime)lbNoteKeys.SelectedItem;
            notes.Remove(selected);
            lbNoteKeys.Items.Remove(selected);
            lbNoteKeys.SelectedIndex = lbNoteKeys.Items.Count - 1;

            lblTotalNoteCount.Text = "Total # of Notes: " + lbNoteKeys.Items.Count;
        }

        private void txtNoteContents_TextChanged(object sender, EventArgs e)
        {
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
            //When this user control is disposed (closed), update the currently open job with the new notes.
            if (RuntimeVars.Instance.IsJobOpen)
                RuntimeVars.Instance.OpenJob.Notes = notes;

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void txtNoteContents_KeyPress(object sender, KeyPressEventArgs e)
        {
            //If the text has been changed, notify about a pending save.
            RuntimeVars.Instance.OpenJob.SavePending = true;
        }
    }
}
