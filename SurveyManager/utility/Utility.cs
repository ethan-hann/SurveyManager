using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
