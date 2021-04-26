using SurveyManager.backend.wrappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SurveyManager.utility.Enums;

namespace SurveyManager.utility
{
    public class Utility
    {
        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        /// <summary>
        /// Formats a number in bytes to the next closest size representation and appends its suffix to the end.
        /// <para>This is a quick alternative to using the <see cref="DGV.FileSizeFormatProvider"/> class.</para>
        /// </summary>
        /// <param name="bytes">The bytes to format</param>
        /// <returns>The number formatted with its suffix.</returns>
        public static string FormatSize(long bytes)
        {
            string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };
            int counter = 0;
            decimal number = bytes;

            while (Math.Round(number / 1024) >= 1)
            {
                number /= 1024;
                counter++;
            }
            return string.Format("{0:n2} {1}", number, suffixes[counter]);
        }

        /// <summary>
        /// Get the center <see cref="Point"/> of the specified <paramref name="clientSize"/>.
        /// </summary>
        /// <param name="clientSize"></param>
        /// <returns></returns>
        public static Point GetCenterPoint(Size clientSize)
        {
            return new Point(clientSize.Width / 2, clientSize.Height / 2);
        }

        /// <summary>
        /// Get a string that represents this applications current version.
        /// </summary>
        /// <returns>A string representing the current version; or "NONE" if the version could not be determined.</returns>
        public static string GetAppVersion()
        {
            string versionDeploy = Application.ProductVersion;
            if (System.Diagnostics.Debugger.IsAttached)
            {
                return string.Format("Version {0} DEBUG", versionDeploy);
            }
            else
            {
                if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                {
                    Version deploy = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                    versionDeploy = string.Format("{0}.{1}.{2}.{3}", deploy.Major, deploy.Minor, deploy.Build, deploy.Revision);
                    return string.Format("Version {0} PRODUCTION", versionDeploy);
                }
            }
            return "NONE";
        }

        public static DataTable ToTable<T>(List<T> items, ItemType type, Dictionary<DateTime, string> dictItems = null)
        {
            string[] data;
            if (items != null)
                data = new string[items.Count];
            else if (dictItems != null)
                data = new string[dictItems.Count];
            else
                data = new string[0];
            int counter = 0;
            DataTable dt = new DataTable();

            switch (type)
            {
                case ItemType.Files:
                {
                    
                    List<CFile> files = items.Cast<CFile>().ToList();
                    foreach (CFile file in files)
                    {
                        data[counter] = $"{file.FullFileName};{file.Description};{file.FileSize}";
                        counter++;
                    }

                    dt.Columns.Add("Name", typeof(string));
                    dt.Columns.Add("Description", typeof(string));
                    dt.Columns.Add("File Size", typeof(string));
                    break;
                }
                case ItemType.Notes:
                {
                    foreach (DateTime key in dictItems.Keys)
                    {
                        data[counter] = $"{key};{dictItems[key]}";
                        counter++;
                    }

                    dt.Columns.Add("Date", typeof(string));
                    dt.Columns.Add("Contents", typeof(string));
                    break;
                }
            }

            for (int i = 0; i < data.Length; i++)
            {
                dt.Rows.Add(data[i].Split(';'));
            }
            return dt;
        }

        /// <summary>
        /// Convert the specified number of pixels to its inches equivalent.
        /// <para>Assumes the DPI to be 96.</para>
        /// </summary>
        /// <param name="pixels">The number of pixels to convert from.</param>
        /// <param name="dpi">The pixel density to use in the conversion.</param>
        /// <returns>A double representing the number of inches equal to the number of pixels.</returns>
        public static double ToInches(double pixels, double dpi = 96)
        {
            return pixels / dpi;
        }

        /// <summary>
        /// Convert the specified number of inches to its pixel equivalent.
        /// <para>Assumes the DPI to be 96.</para>
        /// </summary>
        /// <param name="inches">The number of inches to convert from.</param>
        /// <param name="dpi">The pixel density to use in the conversion.</param>
        /// <returns>A double representing the number of pixels equal to the number of inches.</returns>
        public static double ToPixels(double inches, double dpi = 96)
        {
            return inches * dpi;
        }

        /// <summary>
        /// Trims the string to be the length specified before a new-line character is inserted.
        /// <para>If the new-line character would be inserted at the position of a period (.), the
        /// new line is inserted at the index of the period + 1.</para>
        /// <para>If the line being checked contains a new-line character already, nothing is done for that line.</para>
        /// </summary>
        /// <param name="text">The string to trim.</param>
        /// <param name="lineLength">The number of characters in the line. Default is 80.</param>
        /// <returns>A new <see cref="TrimVars"/> structure containing the trimmed string and the number of new lines.</returns>
        public static TrimVars TrimString(string text, int lineLength = 80)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (i % lineLength == 0 && i != 0)
                {
                    if (text[i].Equals('.'))
                    {
                        if (i + 1 <= text.Length)
                        {
                            text = text.Insert(i + 1, "\n");
                        }
                        if (i + 2 <= text.Length)
                        {
                            text = text.Remove(i + 2, 1);
                        }
                    }
                    else if (text[i].Equals('\n'))
                    {
                        continue;
                    }
                    else
                    {
                        text = text.Insert(i, "\n");
                    }
                }
            }
            return new TrimVars(text);
        }

        /// <summary>
        /// Represents a structure to hold a trimmed string (from <see cref="Utility.TrimString(string, int)"/>) and the number of new-lines in that string.
        /// </summary>
        public struct TrimVars
        {
            /// <summary>
            /// The trimmed string containing new-line characters
            /// </summary>
            public string trimmedString { get; private set; }
            /// <summary>
            /// The number of new-line characters in the string
            /// </summary>
            public int numberOfLines { get; private set; }

            /// <summary>
            /// Get an instance of this structure with the specified string.
            /// </summary>
            /// <param name="trimmedString"></param>
            public TrimVars(string trimmedString)
            {
                this.trimmedString = trimmedString;
                numberOfLines = trimmedString.Count(c => c.Equals('\n'));
            }
        }
    }
}
