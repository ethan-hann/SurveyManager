using SurveyManager.backend.wrappers;
using SurveyManager.utility.Licensing;
using System;
using System.Collections.Generic;
using System.Data;
using static SurveyManager.utility.Enums;

namespace SurveyManager.utility
{
    public class CEventArgs
    {
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

        public class DBArgs : EventArgs
        {
            public int ExceptionCode { get; internal set; }

            public DBArgs(int exCode)
            {
                ExceptionCode = exCode;
            }
        }

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

        public class StatusArgs : EventArgs
        {
            public string StatusString { get; internal set; }

            public StatusArgs(string status)
            {
                StatusString = status;
            }
        }

        public class SurveyOpenedEventArgs : EventArgs
        {
            public Survey Survey { get; internal set; }

            public SurveyOpenedEventArgs(Survey survey)
            {
                Survey = survey;
            }
        }

        public class QueryRanArgs : EventArgs
        {
            public string TableName { get; internal set; }

            public QueryRanArgs(string tableName)
            {
                TableName = tableName;
            }
        }

        public class FileUploadDoneArgs : EventArgs
        {
            public List<CFile> Files { get; internal set; }

            public FileUploadDoneArgs(List<CFile> files)
            {
                Files = files;
            }
        }

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
