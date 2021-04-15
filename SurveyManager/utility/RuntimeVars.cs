using ComponentFactory.Krypton.Toolkit;
using SurveyManager.backend.wrappers;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.utility
{
    public class RuntimeVars
    {
        private static RuntimeVars instance = null;
        private static readonly object padlock = new object();

        private RuntimeVars() { }

        public static RuntimeVars Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new RuntimeVars();
                    return instance;
                }
            }
        }
        
        /// <summary>
        /// Get a value indicating the number of database connection forms currently open.
        /// </summary>
        public int NumberOfDBConnectionFormsOpen { get; set; } = 0;

        /// <summary>
        /// Get a value indicating if the database is currently connected.
        /// </summary>
        public bool DatabaseConnected { get; set; } = false;

        /// <summary>
        /// Get the list of supported counties.
        /// </summary>
        public List<County> Counties { get; set; }

        public string SelectedPageUniqueName { get; set; } = "";

        /// <summary>
        /// Get the currently open survey job.
        /// </summary>
        public Survey OpenJob { get; set; }

        /// <summary>
        /// Get a value indicating if a survey job is already open.
        /// </summary>
        public bool IsJobOpen
        {
            get
            {
                return OpenJob != null;
            }
        }

        public TempFileCollection TempFiles = new TempFileCollection(Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()));

        /// <summary>
        /// Get a reference to the main form of the application.
        /// </summary>
        public MainForm MainForm { get; set; }
    }
}
