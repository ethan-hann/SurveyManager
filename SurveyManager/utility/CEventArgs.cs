using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.utility
{
    public class CEventArgs
    {
        public class FilterDoneEventArgs : EventArgs
        {
            public DataTable Results { get; internal set; }

            public FilterDoneEventArgs(DataTable results)
            {
                Results = results;
            }
        }

        public class DBArgs : EventArgs
        {
            public int ExceptionCode { get; set; }

            public DBArgs(int exCode)
            {
                ExceptionCode = exCode;
            }
        }
    }
}
