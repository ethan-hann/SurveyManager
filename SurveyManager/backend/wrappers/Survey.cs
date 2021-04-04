using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.backend.wrappers
{
    public class Survey : DatabaseWrapper
    {
        public int ID { get; set; }
        public string JobNumber { get; set; }
        public int ClientID { get; set; }
        public string Description { get; set; }
        public string Subdivision { get; set; }
        public string LotNumber { get; set; }
        public string BlockNumber { get; set; }
        public string SectionNumber { get; set; }
        public int CountyID { get; set; }
        public double Acres { get; set; }
        public int RealtorID { get; set; }
        public int TitleCompanyID { get; set; }

        public Client Client { get; set; }
        public County County { get; set; }
        public Realtor Realtor { get; set; }

        

        public Enums.DatabaseError Delete()
        {
            throw new NotImplementedException();
        }

        public Enums.DatabaseError Insert()
        {
            throw new NotImplementedException();
        }

        public Enums.DatabaseError Update()
        {
            throw new NotImplementedException();
        }
    }
}
