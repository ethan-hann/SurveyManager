using System;
using System.ComponentModel;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers
{
    /// <summary>
    /// This class represents a county object. A county is simple and has only an id and name. A County is associated with a <see cref="SurveyJob.Survey"/>.
    /// <para>This class implements the <see cref="IDatabaseWrapper"/> interface to facilitate easier database operations.</para>
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class County : ExpandableObjectConverter, IDatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; }

        /// <summary>
        /// The name for this county.
        /// </summary>
        [Category("County Information")]
        [Description("The full name of the county.")]
        [Browsable(true)]
        [DisplayName("Name")]
        public string CountyName { get; set; } = "N/A";

        /// <summary>
        /// Get a value indicating if this county is valid. A valid county is one whose name is not "N/A".
        /// </summary>
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
