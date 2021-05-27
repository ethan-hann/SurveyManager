using System;
using System.ComponentModel;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class County : ExpandableObjectConverter, IDatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; }

        [Category("County Information")]
        [Description("The full name of the county.")]
        [Browsable(true)]
        [DisplayName("Name")]
        public string CountyName { get; set; } = "N/A";

        public bool IsValidCounty
        {
            get
            {
                return !CountyName.Equals("N/A");
            }
        }

        public County() { }

        public County(int id, string name)
        {
            ID = id;
            CountyName = name;
        }

        public County(string name)
        {
            CountyName = name;
        }

        public override string ToString()
        {
            return CountyName;
        }

        public DatabaseError Insert()
        {
            DatabaseError e;
            if (IsValidCounty)
            {
                if (ID == 0)
                {
                    ID = Database.InsertCounty(this);
                    e = ID != 0 ? DatabaseError.NoError : DatabaseError.CountyInsert;
                }
                else
                {
                    e = Database.UpdateCounty(this) ? DatabaseError.NoError : DatabaseError.CountyUpdate;
                }
                return e;
            }
            else
            {
                return DatabaseError.CountyIncomplete;
            }
        }

        public DatabaseError Update()
        {
            return Insert();
        }

        public DatabaseError Delete()
        {
            return Database.DeleteCounty(this) ? DatabaseError.NoError : DatabaseError.CountyDelete;
        }
    }
}
