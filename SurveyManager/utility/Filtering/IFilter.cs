using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.utility.Filtering
{
    /// <summary>
    /// Interace for any class that is a Filter.
    /// </summary>
    public interface IFilter
    {
        /// <summary>
        /// All implementing classes must implement this property to get their filter string.
        /// </summary>
        string FilterString
        {
            get;
        }
    }
}
