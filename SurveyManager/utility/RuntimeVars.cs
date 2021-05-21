using ComponentFactory.Krypton.Toolkit;
using Standard.Licensing;
using SurveyManager.backend.wrappers;
using SurveyManager.utility.Licensing;
using SurveyManager.utility.Logging;
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
        /// Get or set the applications log file.
        /// </summary>
        public LogFile LogFile { get; set; }

        /// <summary>
        /// Is the product licensed or not?
        /// </summary>
        public bool IsLicensed 
        {
            get
            {
                return (License.Type == Licensing.LicenseType.FullLicense) || (License.Type == Licensing.LicenseType.Trial);
            }
        }

        /// <summary>
        /// The information assocatied with the license.
        /// </summary>
        public LicenseInfo License { get; set; } = LicenseInfo.CreateUnlicensedInfo();

        /// <summary>
        /// Get the name or company of the user for whom the license is valid for.
        /// </summary>
        public string LicenseHolder { get; set; } = "N/A";


        public TempFileCollection TempFiles = new TempFileCollection(Path.Combine(Path.GetTempPath(), Path.GetRandomFileName()));

        /// <summary>
        /// Get a reference to the main form of the application.
        /// </summary>
        public MainForm MainForm { get; set; }
    }
}
