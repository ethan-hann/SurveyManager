using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.utility.Logging
{
    /// <summary>
    /// Helper class for creating log file entries. The log file location is specified by the <see cref="LOG_FILE_PATH"/>
    /// assigned in the constructor and cannot be changed while the program is running.
    /// </summary>
    public class LogFile
    {
        private readonly string LOG_FILE_PATH;

        /// <summary>
        /// The list of Log entries for this session.
        /// </summary>
        public Dictionary<DateTime, string> Entries = new Dictionary<DateTime, string>();

        public LogFile(string logFilePath)
        {
            LOG_FILE_PATH = logFilePath;
        }

        /// <summary>
        /// Add a new entry to the log file. The date and time is added automatically.
        /// </summary>
        /// <param name="logtext">The text to add.</param>
        public void AddEntry(string logtext)
        {
            try
            {
                Entries.Add(DateTime.Now, logtext);
            } catch (ArgumentException)
            {
                //If we get an argument exception, it is because multiple events were triggered at one time resulting in the same DateTime object as the key.
                //The solution is to just add 1 second to the DateTime object for each occurance. This should minimize collisions.
                Entries.Add(DateTime.Now + TimeSpan.FromSeconds(1), logtext);
            }
        }

        /// <summary>
        /// Write the contents of the <see cref="Entries"/> dictionary to the files specified by <see cref="LOG_FILE_PATH"/>.
        /// </summary>
        public void WriteToFile()
        {
            StringBuilder logEntries = new StringBuilder();
            for (int i = 0; i < Entries.Count; i++)
            {
                logEntries.Append($"{Entries.Keys.ElementAt(i)}: {Entries[Entries.Keys.ElementAt(i)]}\n");
            }

            try
            {
                File.WriteAllText(Path.Combine(LOG_FILE_PATH, "sm.log"), logEntries.ToString());
            } catch (Exception)
            {
                Console.WriteLine("[CRITICAL]: Could not write to log file!!!");
                return;
            }
        }
    }
}
