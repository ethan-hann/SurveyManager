using System;

namespace SurveyManager.utility.Filtering
{
    /// <summary>
    /// Class representing a Filter statement using various <see cref="SqlOperators"/>.
    /// </summary>
    [Serializable()]
    public class Filter : IFilter
    {
        private readonly string m_strFilterName;
        private readonly SqlOperators m_sqlOperator;
        private string m_strFilterValue;

        /// <summary>
        /// Create a new Filter statement with the specified name (column), <see cref="SqlOperators"/> operator, and value (search text).
        /// </summary>
        /// <param name="strFilterName">The name of the column this statement is for.</param>
        /// <param name="sqlOperator">The <see cref="SqlOperators"/> that this statement applies.</param>
        /// <param name="strFilterValue">The search text to apply to the column using the specified <see cref="SqlOperators"/>.</param>
        public Filter(string strFilterName, SqlOperators sqlOperator, string strFilterValue)
        {
            m_strFilterName = strFilterName;
            m_sqlOperator = sqlOperator;
            m_strFilterValue = strFilterValue;
        }

        /// <summary>
        /// Getter for the actual filter string of this statement.
        /// </summary>
        public string FilterString
        {
            get
            {
                string strFilter = "";
                m_strFilterValue = m_strFilterValue.Replace("'", "''");
                switch (m_sqlOperator)
                {
                    case SqlOperators.Greater:
                    strFilter = m_strFilterName + " > '" + m_strFilterValue + "'";
                    break;
                    case SqlOperators.Less:
                    strFilter = m_strFilterName + " < '" + m_strFilterValue + "'";
                    break;
                    case SqlOperators.Equals:
                    strFilter = m_strFilterName + " = '" + m_strFilterValue + "'";
                    break;
                    case SqlOperators.LessOrEqual:
                    strFilter = m_strFilterName + " <= '" + m_strFilterValue + "'";
                    break;
                    case SqlOperators.GreaterOrEqual:
                    strFilter = m_strFilterName + " >= '" + m_strFilterValue + "'";
                    break;
                    case SqlOperators.NotEqual:
                    strFilter = m_strFilterName + " <> '" + m_strFilterValue + "'";
                    break;
                    case SqlOperators.StartsLike:
                    strFilter = m_strFilterName + " LIKE '" + m_strFilterValue + "%'";
                    break;
                    case SqlOperators.EndsLike:
                    strFilter = m_strFilterName + " LIKE '%" + m_strFilterValue + "'";
                    break;
                    case SqlOperators.Like:
                    strFilter = m_strFilterName + " LIKE '%" + m_strFilterValue + "%'";
                    break;
                    case SqlOperators.NotLike:
                    strFilter = m_strFilterName + " NOT LIKE '" + m_strFilterValue + "'";
                    break;
                    default:
                    throw new Exception("This operator type is not supported");
                }
                return strFilter;
            }
        }
    }

    /// <summary>
    /// Enum representing the various operations that can be applied on search text and column names.
    /// </summary>
    public enum SqlOperators
    {
        /// <summary>
        /// &gt; - The column value is greater than the search value.
        /// </summary>
        Greater,
        /// <summary>
        /// &lt; - The column value is less than the search value.
        /// </summary>
        Less,
        /// <summary>
        /// = - The column value equals the search value.
        /// </summary>
        Equals,
        /// <summary>
        /// %value.* - The column value begins with the search value.
        /// </summary>
        StartsLike,
        /// <summary>
        /// .*value% - The column value ends with the search value.
        /// </summary>
        EndsLike,
        /// <summary>
        /// %value% - The column value contains the search value.
        /// </summary>
        Like,
        /// <summary>
        /// NOT %value% - The column value does not contain the search value.
        /// </summary>
        NotLike,
        /// <summary>
        /// &lt;= - The column value is less than or equal to the search value.
        /// </summary>
        LessOrEqual,
        /// <summary>
        /// &gt;= - The column value is greater than or equal to the search value.
        /// </summary>
        GreaterOrEqual,
        /// <summary>
        /// &lt;&gt; - The column value is not equal to the search value.
        /// </summary>
        NotEqual
    }
}
