using SurveyManager.backend.wrappers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SurveyManager.forms.dialogs
{
    /// <summary>
    /// A class to create custom message boxes; functions similar to the <see cref="CMessageBox"/> class, except more text can be displayed.
    /// </summary>
    public static class CRichMsgBox
    {
        /// <summary>
        /// Creates a custom MessageBox popup where the main body of the popup is a rich-text box.
        /// </summary>
        /// <param name="text">The body text of the popup</param>
        /// <param name="caption">The caption (title) of the popup</param>
        /// <param name="richText">The rich text to populate the rich text box with</param>
        /// <param name="buttons">The <see cref="MessageBoxButtons"/> this popup should contain </param>
        /// <param name="image">An image to display left of the body text; Valid sizes for the image are from 0 to 64</param>
        /// <param name="textIsRTF">Is the text specified by the <paramref name="richText"/> parameter formatted as Rich Text.</param>
        /// <returns>A <see cref="DialogResult"/> indicating the result of showing the dialog.</returns>
        public static DialogResult Show(string text, string caption, string richText, MessageBoxButtons buttons, Image image, bool textIsRTF = false)
        {
            RichMessageForm message = new RichMessageForm
            {
                Text = caption,
                ForeColor = Color.Black
            };

            if (image.Height < 0 || image.Height > 64)
                throw new Exception("Invalid image height. Valid height ranges from 0 to 64.");
            else if (image.Width < 0 || image.Width > 64)
                throw new Exception("Invalid image width. Valid width ranges from 0 to 64.");
            else
            {
                message.picImage.Image = image;
                message.lblText.Text = text;

                if (textIsRTF)
                    message.rtbMessage.Rtf = richText;
                else
                    message.rtbMessage.Text = richText;

                switch (buttons)
                {
                    case MessageBoxButtons.OK:
                    message.btnYes.Visible = false;
                    message.btnNo.Visible = false;
                    message.btnCancel.Visible = false;
                    message.btnOK.Location = message.btnCancel.Location;
                    message.btnOK.Text = "OK";
                    break;
                    case MessageBoxButtons.OKCancel:
                    message.btnYes.Visible = false;
                    message.btnNo.Visible = false;
                    message.btnOK.Text = "OK";
                    message.btnCancel.Text = "Cancel";
                    break;
                    case MessageBoxButtons.YesNo:
                    message.btnOK.Visible = false;
                    message.btnCancel.Visible = false;
                    message.btnYes.Location = message.btnOK.Location;
                    message.btnNo.Location = message.btnCancel.Location;
                    message.btnYes.Text = "Yes";
                    message.btnNo.Text = "No";
                    break;
                    case MessageBoxButtons.YesNoCancel:
                    message.btnOK.Visible = false;
                    message.btnYes.Text = "Yes";
                    message.btnNo.Text = "No";
                    message.btnCancel.Text = "Cancel";
                    break;
                    case MessageBoxButtons.RetryCancel:
                    message.btnYes.Visible = false;
                    message.btnNo.Visible = false;
                    message.btnOK.Text = "Cancel";
                    message.btnCancel.Text = "Retry";
                    break;
                }

                if (message.lblText.Height > 64)
                    message.Height = (message.lblText.Top + message.lblText.Height) + 78;

                return (message.ShowDialog());
            }
        }

        /// <summary>
        /// Creates a custom MessageBox popup where the main body of the popup is a splitter panel, The left side is a rich-text box while the
        /// right side is a list view that can display a list of objects marked for deletion.
        /// </summary>
        /// <param name="text">The body text of the popup</param>
        /// <param name="caption">The caption (title) of the popup</param>
        /// <param name="richText">The rich text to populate the rich text box with</param>
        /// <param name="textIsRTF">Is the text specified by the <paramref name="richText"/> parameter formatted as Rich Text.</param>
        /// <param name="buttons">The <see cref="MessageBoxButtons"/> this popup should contain </param>
        /// <param name="image">An image to display left of the body text; Valid sizes for the image are from 0 to 64</param>
        /// <param name="objects">A list of <see cref="IDatabaseWrapper"/> objects that are the objects to be deleted. Displayed in the ListView.</param>
        /// <returns>A <see cref="DialogResult"/> indicating the result of showing the dialog.</returns>
        public static DialogResult ShowDeleteDialog(string text, string caption, string richText, bool textIsRTF, MessageBoxButtons buttons, Image image, List<IDatabaseWrapper> objects)
        {
            DeleteMessageForm message = new DeleteMessageForm
            {
                Text = caption,
                ForeColor = Color.Black
            };

            if (image.Height < 0 || image.Height > 64)
                throw new Exception("Invalid image height. Valid height ranges from 0 to 64.");
            else if (image.Width < 0 || image.Width > 64)
                throw new Exception("Invalid image width. Valid width ranges from 0 to 64.");
            else
            {
                message.picImage.Image = image;
                message.lblText.Text = text;

                if (textIsRTF)
                    message.rtbMessage.Rtf = richText;
                else
                    message.rtbMessage.Text = richText;

                switch (buttons)
                {
                    case MessageBoxButtons.OK:
                    message.btnYes.Visible = false;
                    message.btnNo.Visible = false;
                    message.btnCancel.Visible = false;
                    message.btnOK.Location = message.btnCancel.Location;
                    message.btnOK.Text = "OK";
                    break;
                    case MessageBoxButtons.OKCancel:
                    message.btnYes.Visible = false;
                    message.btnNo.Visible = false;
                    message.btnOK.Text = "OK";
                    message.btnCancel.Text = "Cancel";
                    break;
                    case MessageBoxButtons.YesNo:
                    message.btnOK.Visible = false;
                    message.btnCancel.Visible = false;
                    message.btnYes.Location = message.btnOK.Location;
                    message.btnNo.Location = message.btnCancel.Location;
                    message.btnYes.Text = "Yes";
                    message.btnNo.Text = "No";
                    break;
                    case MessageBoxButtons.YesNoCancel:
                    message.btnOK.Visible = false;
                    message.btnYes.Text = "Yes";
                    message.btnNo.Text = "No";
                    message.btnCancel.Text = "Cancel";
                    break;
                    case MessageBoxButtons.RetryCancel:
                    message.btnYes.Visible = false;
                    message.btnNo.Visible = false;
                    message.btnOK.Text = "Cancel";
                    message.btnCancel.Text = "Retry";
                    break;
                }

                if (message.lblText.Height > 64)
                    message.Height = (message.lblText.Top + message.lblText.Height) + 78;

                foreach (IDatabaseWrapper wrapper in objects)
                {
                    message.lvObjects.Items.Add($"{wrapper.ID}  -  {wrapper}");
                }
                message.lvObjects.Sort(); //sort in ascending order, based on Sorting property set in Design View.

                message.lblListViewCaption.Text = $"Objects to be deleted: {message.lvObjects.Items.Count}";

                return (message.ShowDialog());
            }
        }
    }
}
