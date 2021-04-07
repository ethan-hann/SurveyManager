using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.backend.wrappers
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class County : ExpandableObjectConverter, DatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; }

        [Category("County Information")]
        [Description("The full name of the county.")]
        [Browsable(true)]
        [DisplayName("Name")]
        public string CountyName { get; set; }

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

        public Enums.DatabaseError Delete()
        {
            return Database.DeleteCounty(this) ? Enums.DatabaseError.NoError : Enums.DatabaseError.CountyDelete;
        }

        public Enums.DatabaseError Insert()
        {
            return Database.InsertCounty(this) ? Enums.DatabaseError.NoError : Enums.DatabaseError.CountyInsert;
        }

        public Enums.DatabaseError Update()
        {
            return Database.UpdateCounty(this) ? Enums.DatabaseError.NoError : Enums.DatabaseError.CountyUpdate;
        }

        public override string ToString()
        {
            return CountyName;
        }
    }
}
