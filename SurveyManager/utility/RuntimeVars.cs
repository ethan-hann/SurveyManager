using System;
using System.Collections.Generic;
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
        
        public int NumberOfDBConnectionFormsOpen { get; set; } = 0;
    }
}
