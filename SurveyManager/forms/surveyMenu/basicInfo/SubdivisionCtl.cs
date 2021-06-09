﻿using ComponentFactory.Krypton.Toolkit;
using SurveyManager.utility;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SurveyManager.forms.surveyMenu.basicInfo
{
    public partial class SubdivisionCtl : UserControl, IInfoControl
    {
        public bool IsEdited { get; set; } = false;

        public SubdivisionCtl()
        {
            InitializeComponent();
        }

        private void SubdivisionCtl_Load(object sender, EventArgs e)
        {
            txtName.Text = JobHandler.Instance.CurrentJob.Subdivision;
            txtSection.Text = JobHandler.Instance.CurrentJob.SectionNumber;
            txtBlock.Text = JobHandler.Instance.CurrentJob.BlockNumber;
            txtLot.Text = JobHandler.Instance.CurrentJob.LotNumber;

            txtName.ReadOnly = JobHandler.Instance.ReadOnly;
            txtSection.ReadOnly = JobHandler.Instance.ReadOnly;
            txtBlock.ReadOnly = JobHandler.Instance.ReadOnly;
            txtLot.ReadOnly = JobHandler.Instance.ReadOnly;

            IsEdited = true;
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            KryptonTextBox txtBox = sender as KryptonTextBox;
            if (txtBox != null)
                txtBox.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 128);
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            KryptonTextBox txtBox = sender as KryptonTextBox;
            if (txtBox != null)
                txtBox.StateCommon.Back.Color1 = Color.White;
        }

        public bool SaveInfo()
        {
            JobHandler.Instance.CurrentJob.Subdivision = txtName.Text.Length == 0 ? "N/A" : txtName.Text;
            JobHandler.Instance.CurrentJob.SectionNumber = txtSection.Text.Length == 0 ? "N/A" : txtSection.Text;
            JobHandler.Instance.CurrentJob.BlockNumber = txtBlock.Text.Length == 0 ? "N/A" : txtBlock.Text;
            JobHandler.Instance.CurrentJob.LotNumber = txtLot.Text.Length == 0 ? "N/A" : txtLot.Text;

            return true;
        }

        private void JobModified(object sender, KeyPressEventArgs e)
        {
            JobHandler.Instance.UpdateSavePending(true);
        }
    }
}