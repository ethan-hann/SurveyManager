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
            Client c = new Client();
            c.ID = (int)row["client_id"];
            c.Name = (string)row["name"];
            c.PhoneNumber = (string)row["phone_number"];
            c.Email = (string)row["email_address"];
            c.FaxNumber = (string)row["fax_number"];
            c.AddressID = (int)row["address_id"];

            if (c.AddressID != 0)
                c.SetAddress();

            return c;
        }
    }
}
