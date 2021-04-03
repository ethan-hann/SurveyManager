using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.utility.Filtering
{
    /// <summary>
    /// Represents an OR boolean filter statement.
    /// </summary>
    [Serializable()]
    public class ORFilter : IFilter
    {
        private readonly FilterExpressionList m_filterExpressionList = new FilterExpressionList();

        /// <summary>
        /// Create a new OR filter statement. The left and right hand sides of the supplied statements are conjoined with an OR between them.
        /// </summary>
        /// <param name="filterExpressionLeft">The left hand side of the statement.</param>
        /// <param name="filterExpressionRight">The right hand side of the statement.</param>
        public ORFilter(IFilter filterExpressionLeft, IFilter filterExpressionRight)
        {
            m_filterExpressionList.Add(filterExpressionLeft);
            m_filterExpressionList.Add(filterExpressionRight);
        }

        /// <summary>
        /// Get the filter string for this statement.
        /// </summary>
        public string FilterString
        {
            get
            {
                string strFilter = "";
                if (m_filterExpressionList.Count > 0)
                {
                    for (int i = 0; i < m_filterExpressionList.Count - 1; i++)
                    {
                        strFilter += m_filterExpressionList[i].FilterString + " OR ";
                    }
                    strFilter += m_filterExpressionList[m_filterExpressionList.Count - 1].FilterString;
                    strFilter = "(" + strFilter + ")";
                }
                return strFilter;
            }
        }
    }
}
