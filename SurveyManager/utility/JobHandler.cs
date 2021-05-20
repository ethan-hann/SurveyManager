using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.utility
{
    /// <summary>
    /// This class handles all tasks relating to survey jobs. It is responsible for opening, closing, keeping track
    /// of the current job, saving, and updating the recent docs for surveys.
    /// 
    /// <para>This class cannot be instantiated. Instead, it must be referenced through its single <see cref="Instance"/> property.</para>
    /// </summary>
    public class JobHandler
    {
        private static JobHandler instance = null;
        private static readonly object padlock = new object();

        private JobHandler() { }

        public static JobHandler Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new JobHandler();
                    return instance;
                }
            }
        }
    }
}
