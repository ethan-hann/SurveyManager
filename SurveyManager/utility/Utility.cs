using SurveyManager.backend.wrappers;
using SurveyManager.backend.wrappers.SurveyJob;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using static SurveyManager.utility.Enums;

namespace SurveyManager.utility
{
    /// <summary>
    /// This class holds utility methods that are used throughout Survey Manager.
    /// </summary>
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
        /// Converts a timespan object into a human readable string in the form of: 
        /// x days, x hours, x minutes, x seconds
        /// </summary>
        /// <param name="span">The timespan to convert.</param>
        /// <returns>A string representing the timespan as words.</returns>
        public static string ToFullString(TimeSpan span)
        {
            List<Tuple<int, string>> components = new List<Tuple<int, string>> {
                Tuple.Create((int)span.TotalDays, "day"),
                Tuple.Create(span.Hours, "hour"),
                Tuple.Create(span.Minutes, "minute"),
                Tuple.Create(span.Seconds, "second"),
            };

            while (components.Any() && components[0].Item1 == 0)
                components.RemoveAt(0);

            return string.Join(", ",
                components.Select(t => t.Item1 + " " + t.Item2 + (t.Item1 != 1 ? "s" : string.Empty)));
        }

        /// <summary>
        /// Converts a list of billing items into a dictionary with the key being the date of the billing item and the value being a list
        /// of billing items for that date.
        /// </summary>
        public static Dictionary<string, List<BillingItem>> CreateDictionary(List<BillingItem> items)
        {
            Dictionary<string, List<BillingItem>> dict = new Dictionary<string, List<BillingItem>>();
            List<BillingItem> itemsToAdd;
            bool[] addedItems = new bool[items.Count];

            for (int i = 0; i < items.Count; i++)
            {
                itemsToAdd = new List<BillingItem>();
                BillingItem item = items[i];
                DateTime date = item.AssociatedDate;

                for (int j = 1; j < items.Count; j++)
                {
                    BillingItem nextItem = items[j];

                    if (nextItem.AssociatedDate.Equals(date) & addedItems[j] == false)
                    {
                        addedItems[j] = true;
                        itemsToAdd.Add(nextItem);
                    }
                }
                if (addedItems[i] == false)
                {
                    itemsToAdd.Add(item);
                    addedItems[i] = true;
                }

                if (!dict.ContainsKey(date.Date.ToShortDateString()))
                    dict.Add(date.Date.ToShortDateString(), itemsToAdd);
            }
            return dict;
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

        /// <summary>
        /// Convert a list of items into a data table.
        /// </summary>
        /// <typeparam name="T">The type this table is created for.</typeparam>
        /// <param name="items">The list of items in the table.</param>
        /// <param name="type">The <see cref="ItemType"/> this table represents.</param>
        /// <param name="dictItems">A dictionary of items, for use when creating a table of billing items.</param>
        /// <returns></returns>
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
        /// Converts a <see cref="DateTime"/> object into a <see cref="TimeSpan"/> object.
        /// </summary>
        /// <param name="date">The date to convert.</param>
        /// <returns>A <see cref="TimeSpan"/> representing the date.</returns>
        public static TimeSpan ToTimeSpan(DateTime date)
        {
            int hours = date.Hour;
            int minutes = date.Minute;
            int seconds = date.Second;
            TimeSpan days = date.TimeOfDay;
            return days;
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
