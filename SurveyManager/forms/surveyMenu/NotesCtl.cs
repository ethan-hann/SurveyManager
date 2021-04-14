using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            notes[(DateTime)lbNoteKeys.Items[lbNoteKeys.SelectedIndex]] = txtNoteContents.Text;

            lblCharCount.Text = "Character Count: " + txtNoteContents.Text.Count() + " / 4,000";
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            RuntimeVars.Instance.OpenJob.Notes = notes;

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
