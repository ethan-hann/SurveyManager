using ComponentFactory.Krypton.Toolkit;
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
using static SurveyManager.utility.Enums;

namespace SurveyManager.forms.surveyMenu
{
    public partial class TimeEntry : KryptonForm
    {
        private readonly TimeType type;

        public TimeEntry(TimeType type)
        {
            InitializeComponent();

            this.type = type;
        }

        private void TimeEntry_Load(object sender, EventArgs e)
        {
            btnAddTime.Click += AddTime;
            btnRemoveTime.Click += RemoveTime;

            SetTotalTimeLabel();
        }

        private void AddTime(object sender, EventArgs e)
        {
            int hours = int.Parse(txtHours.Text);
            int minutes = int.Parse(txtMinutes.Text);
            int seconds = int.Parse(txtSeconds.Text);
            TimeSpan timeToAdd = new TimeSpan(hours, minutes, seconds);

            switch (type)
            {
                case TimeType.Field:
                {
                    //RuntimeVars.Instance.OpenJob.AddFieldTime(timeToAdd);
                    break;
                }
                case TimeType.Office:
                {
                    //RuntimeVars.Instance.OpenJob.AddOfficeTime(timeToAdd);
                    break;
                }
            }

            SetTotalTimeLabel();
            RuntimeVars.Instance.OpenJob.SavePending = true;
        }

        private void RemoveTime(object sender, EventArgs e)
        {
            //Add time based on labels text too!! TODO!!!
            int hours = int.Parse(txtHours.Text);
            int minutes = int.Parse(txtMinutes.Text);
            int seconds = int.Parse(txtSeconds.Text);
            TimeSpan timeToRemove = new TimeSpan(hours, minutes, seconds);

            switch (type)
            {
                case TimeType.Field:
                {
                    //RuntimeVars.Instance.OpenJob.RemoveFieldTime(timeToRemove);
                    break;
                }
                case TimeType.Office:
                {
                    //RuntimeVars.Instance.OpenJob.RemoveOfficeTime(timeToRemove);
                    break;
                }
            }

            SetTotalTimeLabel();
            RuntimeVars.Instance.OpenJob.SavePending = true;
        }

        private void SetTotalTimeLabel()
        {
            TimeSpan totalTime = RuntimeVars.Instance.OpenJob.BillingObject.GetTotalTime();
            lblTotalTime.Text = "Total Time = " + $"{totalTime.Hours} hour(s), {totalTime.Minutes} minute(s), {totalTime.Seconds} second(s)";
        }

        private void lblHours_MouseClick(object sender, MouseEventArgs e)
        {
            txtHours.Text = lblHours.Text;
            txtHours.Visible = true;
        }

        private void lblMinutes_MouseClick(object sender, MouseEventArgs e)
        {
            txtMinutes.Text = lblMinutes.Text;
            txtMinutes.Visible = true;
        }

        private void lblSeconds_MouseClick(object sender, MouseEventArgs e)
        {
            txtSeconds.Text = lblSeconds.Text;
            txtSeconds.Visible = true;
        }

        private void hoursUp_MouseClick(object sender, MouseEventArgs e)
        {
            int hours = int.Parse(lblHours.Text);
            hours += 1;
            lblHours.Text = hours.ToString();
            txtHours.Text = lblHours.Text;
        }

        private void hoursDown_MouseClick(object sender, MouseEventArgs e)
        {
            int hours = int.Parse(lblHours.Text);
            hours -= 1;
            if (hours <= 0)
                hours = 0;

            lblHours.Text = hours.ToString();
            txtHours.Text = lblHours.Text;
        }

        private void minutesUp_MouseClick(object sender, MouseEventArgs e)
        {
            int minutes = int.Parse(lblMinutes.Text);
            minutes += 1;
            lblMinutes.Text = minutes.ToString();
            txtMinutes.Text = lblMinutes.Text;
        }

        private void minutesDown_MouseClick(object sender, MouseEventArgs e)
        {
            int minutes = int.Parse(lblMinutes.Text);
            minutes -= 1;
            if (minutes <= 0)
                minutes = 0;

            lblMinutes.Text = minutes.ToString();
            txtMinutes.Text = lblMinutes.Text;
        }

        private void secondsUp_MouseClick(object sender, MouseEventArgs e)
        {
            int seconds = int.Parse(lblSeconds.Text);
            seconds += 1;
            lblSeconds.Text = seconds.ToString();
            txtSeconds.Text = lblSeconds.Text;
        }

        private void secondsDown_MouseClick(object sender, MouseEventArgs e)
        {
            int seconds = int.Parse(lblSeconds.Text);
            seconds -= 1;
            if (seconds <= 0)
                seconds = 0;

            lblSeconds.Text = seconds.ToString();
            txtSeconds.Text = lblSeconds.Text;
        }

        private void txtHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (int.TryParse(txtHours.Text, out int hours))
                {
                    if (hours >= 0)
                    {
                        lblHours.Text = txtHours.Text;
                        txtHours.Visible = false;
                    }
                    else
                        txtHours.Visible = false;
                }
            }
        }

        private void txtMinutes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (int.TryParse(txtMinutes.Text, out int minutes))
                {
                    if (minutes >= 0)
                    {
                        lblMinutes.Text = txtMinutes.Text;
                        e.Handled = true;

                        txtMinutes.Visible = false;
                        lblMinutes.Text = txtMinutes.Text;
                    }
                    else
                        e.Handled = false;
                }
                else
                    e.Handled = false;
            }
        }

        private void txtSeconds_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (int.TryParse(txtSeconds.Text, out int seconds))
                {
                    if (seconds >= 0)
                    {
                        lblSeconds.Text = txtSeconds.Text;
                        txtSeconds.Visible = false;
                    }
                    else
                        txtSeconds.Visible = false;
                }
            }
        }
    }
}
