using SurveyManager.backend.wrappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.utility
{
    public class ProcessDataTable
    {
        public static Address GetAddress(DataRow row)
        {
            return new Address
            {
                ID = (int)row["address_id"],
                Street = (string)row["street"],
                City = (string)row["city"],
                ZipCode = (string)row["zip_code"]
            }; ;
        }

        public static Client GetClient(DataRow row)
        {
            Client c = new Client
            {
                ID = (int)row["client_id"],
                Name = (string)row["name"],
                PhoneNumber = (string)row["phone_number"],
                Email = (string)row["email_address"],
                FaxNumber = (string)row["fax_number"],
                AddressID = (int)row["address_id"]
            };

            if (c.AddressID != 0)
                c.SetAddress();

            return c;
        }

        public static Realtor GetRealtor(DataRow row)
        {
            return new Realtor
            {
                ID = (int)row["realtor_id"],
                Name = (string)row["name"],
                Email = (string)row["email"],
                PhoneNumber = (string)row["phone_number"],
                FaxNumber = (string)row["fax_number"]
            }; ;
        }

        public static County GetCounty(DataRow row)
        {
            return new County
            {
                ID = (int)row["county_id"],
                CountyName = (string)row["county_name"]
            };
        }

        public static TitleCompany GetTitleCompany(DataRow row)
        {
            return new TitleCompany
            {
                ID = (int)row["company_id"],
                Name = (string)row["name"],
                AssociateName = (string)row["associate_name"],
                AssociateEmail = (string)row["associate_email"],
                OfficeNumber = (string)row["office_number"]
            };
        }

        //public static Survey GetSurvey(DataRow row)
        //{
            
        //}
    }
}
