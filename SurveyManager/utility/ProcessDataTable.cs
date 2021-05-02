using SurveyManager.backend.wrappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SurveyManager.utility.Enums;

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
                CompanyName = (string)row["company_name"],
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

        public static Survey GetSurvey(DataRow row)
        {
            Survey s = new Survey
            {
                ID = (int)row["survey_id"],
                JobNumber = (string)row["job_number"],
                ClientID = (int)row["client_id"],
                Description = (string)row["description"],
                AbstractNumber = (string)row["abstract_number"],
                Subdivision = (string)row["subdivision"],
                LotNumber = (string)row["lot"],
                BlockNumber = (string)row["block"],
                SectionNumber = (string)row["section"],
                CountyID = (int)row["county_id"],
                Acres = (double)row["acres"],
                FileIds = (string)row["file_ids"],
                RealtorID = row.IsNull("realtor_id") ? 0 : (int)row["realtor_id"],
                TitleCompanyID = row.IsNull("title_company_id") ? 0 : (int)row["title_company_id"],
                LocationID = (int)row["address_id"],
                NotesString = (string)row["notes"],
                SurveyName = (string)row["survey_name"]
            };

            s.BillingObject.BillingIds = (string)row["billing_ids"];
            s.BillingObject.LineItemIds = (string)row["line_item_ids"];

            s.SetObjects();
            return s;
        }

        public static Rate GetRate(DataRow row)
        {
            Rate r = new Rate
            {
                ID = (int)row["rate_id"],
                Description = (string)row["description"],
                Amount = (decimal)row["amount"],
                TimeUnit = (TimeUnit)Enum.Parse(typeof(TimeUnit), (string)row["time_unit"]),
                CountyID = (int)row["county_id"],
                TaxIncluded = (bool)row["include_tax"]
            };

            r.SetObjects();
            return r;
        }
    }
}
