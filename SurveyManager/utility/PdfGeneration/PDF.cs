using Spire.Pdf;
using Spire.Pdf.AutomaticFields;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;
using SurveyManager.backend.wrappers;
using SurveyManager.backend.wrappers.SurveyJob;
using SurveyManager.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

namespace SurveyManager.utility.PdfGeneration
{
    public class PDF
    {
        private static PdfDocument document; //the top level document of this PDF object
        private static PdfPageBase currentPage; //the current page being worked on
        private static PdfLayoutResult currentTableLayout; //the current table layout object
        private static PdfMargins margins; //the margins for the document
        private static PdfTrueTypeFont pageFont; //the font that text should be drawn with
        private static PdfTrueTypeFont pageFontBold; //the bold font that text should be drawn with
        private static PdfTrueTypeFont headerFont; //the font that large, header text should be drawn with
        private static PdfTrueTypeFont headerFontBold; //the font that large, header text should be drawn with

        private static string savePath;

        private static bool isStream; //should this document be saved to disk (false) or saved as a Stream object and kept in memory (true)

        private static float currentY; //the current y-position on the page

        /// <summary>
        /// Create a new PDF Document with the specified information.
        /// <para>This should be called before any Generation methods in this class as it sets up variables relevant to the next Generate method call.</para>
        /// </summary>
        /// <param name="filename">The file name of the new PDF document.</param>
        /// <param name="title">The title (for metadata) of the new PDF document.</param>
        /// <param name="author">The author (for metadata) of the new PDF document.</param>
        /// <param name="subject">The subject (for metadata) of the new PDF document.</param>
        /// <param name="headerString">The text for the header.</param>
        /// <param name="documentFont">The font family to use for this new PDF document. See <see cref="Fonts"/> for valid options.</param>
        /// <param name="fontSize">The normal font size for the text in this new PDF document. Default is 11. The header font size will be this font size plus 4.</param>
        /// <param name="stream">Should the new document be created as a MemoryStream instead of a file? Default is false.</param>
        public static void CreateDocument(string filename, string title, string author, string subject, string headerString, Fonts documentFont, bool includeHeader = true, bool includeFooter = true, bool landscape = false, int fontSize = 11, bool stream = false)
        {
            //Set document properties
            document = new PdfDocument();
            document.DocumentInformation.Author = author;
            document.DocumentInformation.Title = title;
            document.DocumentInformation.Producer = $"SSP {Utility.GetAppVersion()}";
            document.DocumentInformation.Keywords = "SSP Report, Computer generated, Sample shipping program";
            document.DocumentInformation.Subject = subject;

            //Set page size and margins
            //document.PageSettings.Size = PdfPageSize.Letter;

            if (landscape)
            {
                document.PageSettings.Orientation = PdfPageOrientation.Landscape;
                margins = new PdfMargins(20, 20, 20, 20);
                document.PageSettings.SetMargins(20, 20, 20, 20);
                document.PageSettings.Size = new SizeF((float)Utility.ToPixels(11), (float)Utility.ToPixels(8.5));
            }
            else
            {
                document.PageSettings.Orientation = PdfPageOrientation.Portrait;
                margins = new PdfMargins(30, 30, 30, 30);
                document.PageSettings.SetMargins(30, 30, 30, 30);
                document.PageSettings.Size = new SizeF((float)Utility.ToPixels(8.5), (float)Utility.ToPixels(11.0));
            }

            //Set fonts
            switch (documentFont)
            {
                case Fonts.Courier:
                {
                    pageFontBold = new PdfTrueTypeFont(new Font("Courier New", fontSize, FontStyle.Bold), true);
                    pageFont = new PdfTrueTypeFont(new Font("Courier New", fontSize, FontStyle.Regular), true);
                    headerFont = new PdfTrueTypeFont(new Font("Courier New", fontSize + 4, FontStyle.Regular), true);
                    headerFontBold = new PdfTrueTypeFont(new Font("Courier New", fontSize + 4, FontStyle.Bold), true);
                    break;
                }
                case Fonts.TimesNewRoman:
                {
                    pageFontBold = new PdfTrueTypeFont(new Font("Times New Roman", fontSize, FontStyle.Bold), true);
                    pageFont = new PdfTrueTypeFont(new Font("Times New Roman", fontSize, FontStyle.Regular), true);
                    headerFont = new PdfTrueTypeFont(new Font("Times New Roman", fontSize + 4, FontStyle.Regular), true);
                    headerFontBold = new PdfTrueTypeFont(new Font("Times New Roman", fontSize + 4, FontStyle.Bold), true);
                    break;
                }
            }

            //Add an initial page to the document and set as current
            currentPage = document.Pages.Add();

            //Add header and footer
            if (includeHeader)
                document.Template.Top = CreateHeaderTemplate(document, margins, headerString);
            if (includeFooter)
                document.Template.Bottom = CreateFooterTemplate(document, margins);

            currentY = GetTopPage();

            //Set up variables for saving
            isStream = stream;
            savePath = Path.Combine(Settings.Default.DefaultSavePath, $"{filename}.pdf");
        }

        public static MemoryStream GenerateBillingReport(Survey s)
        {
            if (document == null)
            {
                RuntimeVars.Instance.LogFile.AddEntry("Could not generate Billing Report for Job# " + s.JobNumber + ". There doesn't seem to be a valid document created.");
                return null;
            }

            DrawStringLarge("Time to Bill", GetLeftPage());
            DrawStringLine(new Pair<string, string>("Office Time: ", s.OfficeTime.ToString()), true, new Pair<string, string>("Office SubTotal: ", s.GetOfficeBill().ToString("C2")), true, true);
            DrawStringLine(new Pair<string, string>("Field Time: ", s.FieldTime.ToString()), true, new Pair<string, string>("Field SubTotal: ", s.GetFieldBill().ToString("C2")), true, true);
            DrawStringBold($"SubTotal: {(s.GetFieldBill() + s.GetOfficeBill()).ToString("C2")}", GetRightPage());

            DrawStringLarge("Line Items", GetLeftPage());

            foreach (LineItem item in s.BillingLineItems)
            {
                DrawStringLine(new Pair<string, string>(item.Description, ""), false, new Pair<string, string>("", item.SubTotal.ToString("C2")), false, true);
            }

            DrawStringBold($"SubTotal: {s.GetBillingLineItemsBill():C2}", GetRightPage());

            DrawLineSeperator();

            DrawStringLargeBold($"Total Bill: {s.GetTotalBill():C2}", GetLeftPage());

            if (isStream)
            {
                MemoryStream ms = new MemoryStream();
                document.SaveToStream(ms);
                document.Close();
                return ms;
            }
            else
            {
                document.SaveToFile(savePath);
                document.Close();
                return null;
            }
        }

        public static MemoryStream GenerateFullReport(Survey s)
        {
            if (document == null)
            {
                RuntimeVars.Instance.LogFile.AddEntry("Could not generate full report for Job# " + s.JobNumber + ". There doesn't seem to be a valid document created.");
                return null;
            }

            //TODO: Create full survey report

            if (isStream)
            {
                MemoryStream ms = new MemoryStream();
                document.SaveToStream(ms);
                document.Close();
                return ms;
            }
            else
            {
                document.SaveToFile(savePath);
                document.Close();
                return null;
            }
        }

        #region Header and Footer
        private static PdfPageTemplateElement CreateHeaderTemplate(PdfDocument doc, PdfMargins margins, string headerString)
        {
            SizeF pageSize = doc.PageSettings.Size;

            PdfPageTemplateElement headerSpace = new PdfPageTemplateElement(pageSize.Width, margins.Top + margins.Bottom)
            {
                Foreground = false
            };

            float x = margins.Left;
            float y = 0;

            //Figure out what logo to use; either the application's logo or the owning company's logo
            Bitmap logo = null; //Resources.logo.ToBitmap();
            

            //Draw image in header if we have one
            if (logo != null)
            {
                PdfImage headerImage = PdfImage.FromImage(Utility.ResizeImage(logo, 96, 96));
                float width = headerImage.Width / 3;
                float height = headerImage.Height / 3;
                headerSpace.Graphics.DrawImage(headerImage, x, margins.Top - height - 2, width, height);
            }

            DrawLine(headerSpace.Graphics, x, y + margins.Top - 2, pageSize.Width - x, y + margins.Top - 2);

            //Draw string in header
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);
            SizeF size = headerFontBold.MeasureString(headerString, format);
            headerSpace.Graphics.DrawString(headerString, headerFontBold, PdfBrushes.Black, (headerSpace.Width / 2) - (size.Width / 2), margins.Top - (size.Height + 5), format);

            return headerSpace;
        }

        private static PdfPageTemplateElement CreateFooterTemplate(PdfDocument doc, PdfMargins margins)
        {
            SizeF pageSize = doc.PageSettings.Size;

            PdfPageTemplateElement footerSpace = new PdfPageTemplateElement(pageSize.Width, margins.Bottom + margins.Top);
            footerSpace.Foreground = false;

            float x = margins.Left;
            float y = 0;

            DrawLine(footerSpace.Graphics, x, y, GetRightPage(), y);

            y += 5;
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);
            string footerText = "This document was generated using computer software\nand is deemed to be as accurate as possible.";
            footerSpace.Graphics.DrawString(footerText, pageFont, PdfBrushes.Gray, x, y, format);

            PdfPageNumberField number = new PdfPageNumberField();
            PdfPageCountField count = new PdfPageCountField();
            PdfCompositeField compositeField = new PdfCompositeField(pageFont, PdfBrushes.Gray, "Page {0} of {1}", number, count);
            compositeField.StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Top);
            SizeF size = pageFont.MeasureString(compositeField.Text);
            compositeField.Bounds = new RectangleF(GetRightPage() - margins.Right - size.Width, y, size.Width, size.Height);
            compositeField.Draw(footerSpace.Graphics);

            return footerSpace;
        }
        #endregion

        private static void DrawLine(PdfCanvas graphics, float x, float y, float x2, float y2)
        {
            PdfPen pen = new PdfPen(PdfBrushes.Black, 1)
            {
                DashStyle = PdfDashStyle.Custom
            };
            pen.DashPattern = new float[] { 5 };
            graphics.DrawLine(pen, x, y, x2, y2);
        }

        private static void DrawLineSeperator(bool updateCurrentY = true)
        {
            DrawLine(currentPage.Canvas, GetLeftPage(), currentY, GetRightPage(), currentY);
            if (updateCurrentY)
                UpdateCurrentY("W", true, false);
        }

        /// <summary>
        /// Draw a string to the page at the specified x-position.
        /// </summary>
        /// <param name="text">The text to draw.</param>
        /// <param name="x">The x-position to start drawing the string at.</param>
        /// <param name="updateCurrentY">Should this method update the current y-position variable after drawing?</param>
        private static void DrawString(string text, float x, bool updateCurrentY = true)
        {
            SizeF stringSize = pageFont.MeasureString(text);
            float newX = x;
            if (x + stringSize.Width >= GetRightPage())
                newX = GetRightPage() - stringSize.Width;

            PdfStringFormat layout = new PdfStringFormat
            {
                LineLimit = false,
                WordWrap = PdfWordWrapType.Word
            };

            currentPage.Canvas.DrawString(text, pageFont, PdfBrushes.Black, newX, currentY, layout);
            if (updateCurrentY)
                UpdateCurrentY(text, false);
        }

        /// <summary>
        /// Draw a bold string to the page at the specified x-position.
        /// </summary>
        /// <param name="text">The text to draw.</param>
        /// <param name="x">The x-position to start drawing the string at.</param>
        /// <param name="updateCurrentY">Should this method update the current y-position variable after drawing?</param>
        private static void DrawStringBold(string text, float x, bool updateCurrentY = true)
        {
            SizeF stringSize = pageFontBold.MeasureString(text);
            float newX = x;
            if (x + stringSize.Width >= GetRightPage())
                newX = GetRightPage() - stringSize.Width;

            PdfStringFormat layout = new PdfStringFormat
            {
                LineLimit = false,
                WordWrap = PdfWordWrapType.Word,

            };

            currentPage.Canvas.DrawString(text, pageFontBold, PdfBrushes.Black, newX, currentY, layout);
            if (updateCurrentY)
                UpdateCurrentY(text, true);
        }

        /// <summary>
        /// Draw a large string to the page at the specified x-position.
        /// </summary>
        /// <param name="text">The text to draw.</param>
        /// <param name="x">The x-position to start drawing the string at.</param>
        /// <param name="updateCurrentY">Should this method update the current y-position variable after drawing?</param>
        private static void DrawStringLarge(string text, float x, bool updateCurrentY = true)
        {
            SizeF stringSize = headerFont.MeasureString(text);
            float newX = x;
            if (x + stringSize.Width >= GetRightPage())
                newX = GetRightPage() - stringSize.Width;

            PdfStringFormat layout = new PdfStringFormat
            {
                LineLimit = false,
                WordWrap = PdfWordWrapType.Word
            };

            currentPage.Canvas.DrawString(text, headerFont, PdfBrushes.Black, newX, currentY, layout);
            if (updateCurrentY)
                UpdateCurrentY(text, false, true);
        }

        /// <summary>
        /// Draw a bold, large string to the page at the specified x-position.
        /// </summary>
        /// <param name="text">The text to draw.</param>
        /// <param name="x">The x-position to start drawing the string at.</param>
        /// <param name="updateCurrentY">Should this method update the current y-position variable after drawing?</param>
        private static void DrawStringLargeBold(string text, float x, bool updateCurrentY = true)
        {
            SizeF stringSize = headerFontBold.MeasureString(text);
            float newX = x;
            if (x + stringSize.Width >= GetRightPage())
                newX = GetRightPage() - stringSize.Width;

            PdfStringFormat layout = new PdfStringFormat
            {
                LineLimit = false,
                WordWrap = PdfWordWrapType.Word
            };

            currentPage.Canvas.DrawString(text, headerFontBold, PdfBrushes.Black, newX, currentY, layout);
            if (updateCurrentY)
                UpdateCurrentY(text, false, true);
        }

        /// <summary>
        /// Draw a string pair with a bolded title and normal description on the same line.
        /// </summary>
        /// <param name="title">The title text to draw.</param>
        /// <param name="description">The description text to draw.</param>
        /// <param name="x">The starting x position to draw the two strings at.</param>
        /// <param name="updateCurrentY">Should this method update the current y-position variable after drawing?</param>
        /// <returns>The <see cref="SizeF"/> of the new string pair.</returns>
        private static SizeF DrawStringPair(string title, string description, float x, bool updateCurrentY = true)
        {
            SizeF totalSize = new SizeF();
            totalSize += pageFontBold.MeasureString(title);
            totalSize += pageFont.MeasureString(description);
            float newX;

            if (x + totalSize.Width >= GetRightPage())
            {
                newX = GetRightPage() - totalSize.Width;
            }
            else
            {
                newX = x;
            }

            DrawStringBold(title, newX, false);
            DrawString(description, pageFontBold.MeasureString(title).Width + newX + 2, false);
            if (updateCurrentY)
                UpdateCurrentY(title, true, false);
            return totalSize;
        }

        /// <summary>
        /// Draw two text pairs, one left aligned and one right aligned. The strings to draw are specified by the <see cref="Pair{K, V}"/> parameters.
        /// <para>A pair can be any two strings; i.e. "Customer ID:" and "Test Customer". To draw the text, this method needs to know if the left and right text
        /// should be considered as pairs. This means that the Key of the <see cref="Pair{K, V}"/> will be drawn bolded while the Value will be drawn using the regular text font.</para>
        /// <para>You should also specify whether the current y-position should be updated after execution of this method.</para>
        /// </summary>
        /// <param name="left">The text to draw left aligned.</param>
        /// <param name="leftIsPair">Is the left text considered a pair?</param>
        /// <param name="right">The text to draw right aligned.</param>
        /// <param name="rightIsPair">Is the right text considered a pair?</param>
        /// <param name="updateCurrentY">Should this method update the value of the current y-position?</param>
        private static void DrawStringLine(Pair<string, string> left, bool leftIsPair, Pair<string, string> right, bool rightIsPair, bool updateCurrentY)
        {
            if (leftIsPair && rightIsPair)
            {
                DrawStringPair(left.Key + "\t", left.Value, GetLeftPage(), false);
                DrawStringPair(right.Key + "\t", right.Value, GetRightPage(), false);
                if (updateCurrentY)
                    UpdateCurrentY(left.Key, true, false);
            }
            else if (leftIsPair && !rightIsPair)
            {
                DrawStringPair(left.Key + "\t", left.Value, GetLeftPage(), false);
                DrawString($"{right.Key + "\t"} {right.Value}", GetRightPage(), false);
                if (updateCurrentY)
                    UpdateCurrentY(left.Key + "\t", true, false);
            }
            else if (!leftIsPair && rightIsPair)
            {
                DrawString($"{left.Key + "\t"} {left.Value}", GetLeftPage(), false);
                DrawStringPair(right.Key + "\t", right.Value, GetRightPage(), false);
                if (updateCurrentY)
                    UpdateCurrentY(right.Key, true, false);
            }
            else if (!leftIsPair && !rightIsPair)
            {
                DrawString($"{left.Key + "\t"} {left.Value}", GetLeftPage(), false);
                DrawString($"{right.Key + "\t"} {right.Value}", GetRightPage(), false);
                if (updateCurrentY)
                    UpdateCurrentY(left.Key + "\t", false, false);
            }
        }

        #region Location Help Methods
        private static float GetLeftPage()
        {
            return margins.Left;
        }

        private static float GetRightPage()
        {
            return currentPage.Size.Width - margins.Left - margins.Right;
        }

        private static float GetTopPage()
        {
            if (document.Template.Top != null)
                return margins.Top + (document.Template.Top.Height / 2.0f);
            else
                return margins.Top;
        }

        private static float GetBottomPage()
        {
            if (document.Pages.Count > 1)
            {
                currentPage = document.Pages[document.Pages.Count - 1];
            }

            if (document.Template.Bottom != null)
                return currentPage.Size.Height - document.Template.Bottom.Height - margins.Top - margins.Bottom - (margins.Bottom * 1.5f);
            else
                return currentPage.Size.Height - margins.Top - margins.Bottom;
        }

        private static float GetCenterPageX()
        {
            return (currentPage.Size.Width - (margins.Left + margins.Right)) / 2.0f;
        }

        private static float GetCenterPageY()
        {
            return (currentPage.Size.Height - (margins.Top + margins.Bottom)) / 2.0f;
        }

        private static PointF GetCenterPage()
        {
            return new PointF(GetCenterPageX(), GetCenterPageY());
        }

        /// <summary>
        /// Updates the y-position using the last line of text and the specified parameters.
        /// </summary>
        /// <param name="lastLineText">The last line of text drawn.</param>
        /// <param name="wasBolded">Was the text drawn with the bold font?</param>
        /// <param name="usingHeaderFont">Was the text draw with the header font?</param>
        /// <returns>The new <see cref="currentY"/> position.</returns>
        private static float UpdateCurrentY(string lastLineText, bool wasBolded, bool usingHeaderFont = false)
        {
            if (wasBolded)
                if (usingHeaderFont)
                    currentY += headerFontBold.MeasureString(lastLineText).Height + 5;
                else
                    currentY += pageFontBold.MeasureString(lastLineText).Height + 5;
            else
                if (usingHeaderFont)
                currentY += headerFont.MeasureString(lastLineText).Height + 5;
            else
                currentY += pageFont.MeasureString(lastLineText).Height + 5;
            return currentY;
        }

        private static float BacktrackCurrentY(string lastLineText, bool wasBolded, bool usingHeaderFont = false)
        {
            if (wasBolded)
                if (usingHeaderFont)
                    currentY -= headerFontBold.MeasureString(lastLineText).Height + 5;
                else
                    currentY -= pageFontBold.MeasureString(lastLineText).Height + 5;
            else
                if (usingHeaderFont)
                currentY -= headerFont.MeasureString(lastLineText).Height + 5;
            else
                currentY -= pageFont.MeasureString(lastLineText).Height + 5;
            return currentY;
        }
        #endregion

    }
}
