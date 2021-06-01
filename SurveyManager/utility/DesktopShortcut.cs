using IWshRuntimeLibrary;
using System;
using System.IO;
using System.Reflection;

namespace SurveyManager.utility
{
    public class DesktopShortcut
    {
        /// <summary>
        /// Attempts to create a shortcut to this application on the user's desktop.
        /// </summary>
        /// <param name="shortcutName">The name of the shortcut file.</param>
        /// <returns>True if the shortcut was created successfully; false otherwise.</returns>
        public static bool Create(string shortcutName)
        {
            try
            {
                WshShell shell = new WshShell();
                string desktopDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                IWshShortcut shortcut = shell.CreateShortcut(Path.Combine(desktopDirectory, shortcutName, ".lnk"));
                shortcut.TargetPath = Assembly.GetExecutingAssembly().Location;
                shortcut.WindowStyle = 1;
                shortcut.Description = "Survey Manager Shortcut";
                shortcut.WorkingDirectory = desktopDirectory;
                shortcut.IconLocation = Assembly.GetExecutingAssembly().Location;
                shortcut.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get a value indicating if the specified shortcut name exists on the user's desktop.
        /// </summary>
        /// <param name="shortcutName">The name of the shortcut file.</param>
        /// <returns>True if the shortcut exists; false otherwise.</returns>
        public static bool Exists(string shortcutName)
        {
            string desktopDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            return System.IO.File.Exists(Path.Combine(desktopDirectory, shortcutName, ".lnk"));
        }
    }
}
