using SurveyManager.backend.wrappers;
using SurveyManager.Properties;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace SurveyManager.utility
{
    /// <summary>
    /// Static class that facilitates sending email. Mail can be sent using the various Send methods.
    /// <para>A valid <see cref="MailInfo"/> structure is required before attempting to send email. Thus, it is recommended to call <see cref="Initialize"/> before any other methods.</para>
    /// </summary>
    public class Mail
    {
        /// <summary>
        /// The support email address to send feedback and bug reports to.
        /// </summary>
        private const string SUPPORT_ADDRESS = "thomasthunderous@protonmail.com";

        /// <summary>
        /// Send email to the support email address (supportbayareatx@teamlogicit.com). Allows attaching of optional <see cref="Stream"/> objects to the email.
        /// </summary>
        /// <param name="subject">The subject for the email.</param>
        /// <param name="body">The text to include in the body of the email.</param>
        /// <param name="attachments">The attachments to send with this email, as <see cref="Stream"/> objects.</param>
        /// <param name="ccRecipients">Optional CC recipients seperated by semi-colons.</param>
        public static void SendHTML(string subject, string body, ArrayList attachments = null, string ccRecipients = null)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(Settings.Default.MailFromAddress, "Survey Manager Feedback");
                mail.To.Add(SUPPORT_ADDRESS);
                mail.Subject = subject;

                if (ccRecipients != null)
                {
                    mail.CC.Add(ccRecipients);
                }

                ContentType ct = new ContentType(MediaTypeNames.Text.RichText);
                AlternateView altBody = AlternateView.CreateAlternateViewFromString(body, ct);
                mail.AlternateViews.Add(altBody);
                mail.IsBodyHtml = true;

                if (attachments != null)
                {
                    int counter = 1;

                    foreach (MemoryStream s in attachments)
                    {
                        Attachment a = new Attachment(s, ct);
                        a.ContentDisposition.FileName = $"attachment{counter}.rtf";
                        a.ContentDisposition.Size = s.Length;
                        mail.Attachments.Add(a);
                        counter++;
                    }
                }

                using (SmtpClient smtp = new SmtpClient(Settings.Default.MailServerHost, Settings.Default.MailServerPort))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(Settings.Default.MailServerUser, Settings.Default.MailServerPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        /// <summary>
        /// Send an email in which the body of the email is considered to be HTML. Allows attaching of an optional <see cref="Stream"/> object to the email.
        /// </summary>
        /// <param name="subject">The subject for the email.</param>
        /// <param name="body">The text to include in the body of the email.</param>
        /// <param name="toAddress">The address to send the email to.</param>
        /// <param name="attachment">The attachment to send with this email, as a <see cref="Stream"/>.</param>
        /// <param name="ccRecipients">Optional CC recipients seperated by semi-colons.</param>
        public static void SendHTML(string subject, string body, string toAddress, Stream attachment = null, string ccRecipients = null)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(Settings.Default.MailFromAddress, "Survey Manager Feedback");
                mail.To.Add(toAddress);
                mail.Subject = subject;

                if (ccRecipients != null)
                {
                    mail.CC.Add(ccRecipients);
                }

                ContentType ct = new ContentType(MediaTypeNames.Text.RichText);
                AlternateView altBody = AlternateView.CreateAlternateViewFromString(body, ct);
                mail.AlternateViews.Add(altBody);
                mail.IsBodyHtml = true;

                if (attachment != null)
                {
                    Attachment a = new Attachment(attachment, ct);
                    a.ContentDisposition.FileName = $"Password.rtf";
                    a.ContentDisposition.Size = attachment.Length;
                    mail.Attachments.Add(a);
                }

                using (SmtpClient smtp = new SmtpClient(Settings.Default.MailServerHost, Settings.Default.MailServerPort))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(Settings.Default.MailServerUser, Settings.Default.MailServerPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        /// <summary>
        /// Send an email in which the body of the email is considered to be HTML. Allows attaching of a <see cref="CFile"/> object to the email.
        /// </summary>
        /// <param name="subject">The subject for the email.</param>
        /// <param name="body">The text to include in the body of the email.</param>
        /// <param name="toAddress">The address to send the email to.</param>
        /// <param name="attachment">The attachment to send with this email.</param>
        /// <param name="ccRecipients">Optional CC recipients seperated by semi-colons.</param>
        public static void SendHTML(string subject, string body, string toAddress, CFile attachment, string ccRecipients = null)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(Settings.Default.MailFromAddress);
                mail.To.Add(toAddress);
                mail.Subject = subject;

                if (ccRecipients != null)
                    mail.CC.Add(ccRecipients);
                mail.CC.Add(SUPPORT_ADDRESS);

                ContentType ct = new ContentType();
                if (attachment.Extension == Enums.FileExtension.TXT)
                    ct = new ContentType(MediaTypeNames.Text.RichText);
                else if (attachment.Extension == Enums.FileExtension.JPEG)
                    ct = new ContentType(MediaTypeNames.Image.Jpeg);
                Attachment a = new Attachment(new MemoryStream(attachment.Contents), ct);
                a.ContentDisposition.FileName = $"{attachment.FileName}.{attachment.Extension.ToString().ToLower()}";
                a.ContentDisposition.Size = attachment.Contents.Length;

                AlternateView altBody = AlternateView.CreateAlternateViewFromString(body, ct);
                mail.AlternateViews.Add(altBody);
                mail.IsBodyHtml = true;
                mail.Attachments.Add(a);
                mail.Body = body;

                using (SmtpClient smtp = new SmtpClient(Settings.Default.MailServerHost, Settings.Default.MailServerPort))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(Settings.Default.MailServerUser, Settings.Default.MailServerPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }

        /// <summary>
        /// Send regular email to the specified address and optional CC recipients.
        /// </summary>
        /// <param name="subject">The subject for the email.</param>
        /// <param name="body">The text to include in the body of the email.</param>
        /// <param name="to_address">The address to send the email to.</param>
        /// <param name="ccRecipients">Optional CC recipients seperated by semi-colons.</param>
        public static void SendMail(string subject, string body, string to_address, string ccRecipients = null)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(Settings.Default.MailFromAddress);
                mail.To.Add(to_address);
                mail.Subject = subject;

                if (ccRecipients != null)
                {
                    mail.CC.Add(ccRecipients);
                }

                mail.Body = body;
                mail.IsBodyHtml = false;

                using (SmtpClient smtp = new SmtpClient(Settings.Default.MailServerHost, Settings.Default.MailServerPort))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(Settings.Default.MailServerUser, Settings.Default.MailServerPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
