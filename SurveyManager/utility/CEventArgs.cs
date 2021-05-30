using SurveyManager.backend.wrappers;
using SurveyManager.backend.wrappers.SurveyJob;
using SurveyManager.utility.Licensing;
using System;
using System.Collections.Generic;
using System.Data;
using static SurveyManager.utility.Enums;

namespace SurveyManager.utility
{
    /// <summary>
    /// This class represents custom event args classes.
    /// </summary>
    public class CEventArgs
    {
        /// <summary>
        /// Event args representing when a filter is done searching.
        /// </summary>
        public class FilterDoneEventArgs : EventArgs
        {
            public DataTable Results { get; internal set; }
            public string Query { get; internal set; }

            public FilterDoneEventArgs(DataTable results, string query)
            {
                Results = results;
                Query = query;
            }
        }

        /// <summary>
        /// Event args representing when a database connection is done connecting.
        /// </summary>
        public class DBArgs : EventArgs
        {
            public int ExceptionCode { get; internal set; }

            public DBArgs(int exCode)
            {
                ExceptionCode = exCode;
            }
        }

        /// <summary>
        /// Event args representing when a search in the database has been finished.
        /// </summary>
        public class DBObjectArgs : EventArgs
        {
            public IDatabaseWrapper Object { get; internal set; }
            public EntityTypes Type { get; internal set; }

            public DBObjectArgs(IDatabaseWrapper obj, EntityTypes type)
            {
                Object = obj;
                Type = type;
            }
        }

        /// <summary>
        /// Event args representing when the status label is updated.
        /// </summary>
        public class StatusArgs : EventArgs
        {
            public string StatusString { get; internal set; }

            public StatusArgs(string status)
            {
                StatusString = status;
            }
        }

        /// <summary>
        /// Event args representing when a survey is opened.
        /// </summary>
        public class SurveyOpenedEventArgs : EventArgs
        {
            public Survey Survey { get; internal set; }

            public SurveyOpenedEventArgs(Survey survey)
            {
                Survey = survey;
            }
        }

        /// <summary>
        /// Event args representing when a query is ran against the database.
        /// </summary>
        public class QueryRanArgs : EventArgs
        {
            public string TableName { get; internal set; }

            public QueryRanArgs(string tableName)
            {
                TableName = tableName;
            }
        }

        /// <summary>
        /// Event args representing when a file upload is done.
        /// </summary>
        public class FileUploadDoneArgs : EventArgs
        {
            public List<CFile> Files { get; internal set; }

            public FileUploadDoneArgs(List<CFile> files)
            {
                Files = files;
            }
        }

        /// <summary>
        /// Event args representing when the license engine is finished licensing.
        /// </summary>
        public class LicensingEventArgs : EventArgs
        {
            public CloseReasons CloseReason { get; internal set; }
            public LicenseInfo License { get; internal set; }

            public LicensingEventArgs(LicenseInfo info, CloseReasons closeReason)
            {
                License = info;
                CloseReason = closeReason;
            }
        }

        /// <summary>
        /// Event args representing when an object is created.
        /// </summary>
        public class ObjectCreatedEventArgs : EventArgs
        {
            public object DataValue { get; internal set; }
            public object Tag { get; internal set; }

            public ObjectCreatedEventArgs(object dataValue, object tag)
            {
                DataValue = dataValue;
                Tag = tag;
            }
        }
    }
}
