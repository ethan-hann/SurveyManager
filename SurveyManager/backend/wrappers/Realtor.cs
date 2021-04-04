﻿using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.backend.wrappers
{
    public class Realtor : DatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; }

        [Category("Realtor Information")]
        [Description("The full name of the realtor.")]
        [Browsable(true)]
        [DisplayName("Realtor Name")]
        public string Name { get; set; } = "N/A";

        [Category("Realtor Information")]
        [Description("The email address of the realtor.")]
        [Browsable(true)]
        [DisplayName("Email Address")]
        public string Email { get; set; } = "N/A";

        [Category("Realtor Information")]
        [Description("The phone number for the realtor.")]
        [Browsable(true)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } = "N/A";

        [Category("Realtor Information")]
        [Description("The fax number, if any, of the realtor.")]
        [Browsable(true)]
        [DisplayName("Fax Number")]
        public string FaxNumber { get; set; } = "N/A";

        /// <summary>
        /// Get a value representing whether this Realtor is valid or not.
        /// <para>A valid Realtor is one whose name and email is not equal to N/A and also not an empty string.</para>
        /// </summary>
        [Browsable(false)]
        public bool IsValid
        {
            get
            {
                return (!Name.Equals("N/A") && Name.Length > 0) && (!Email.Equals("N/A") && Email.Length > 0);
            }
        }

        public Realtor() { }

        public Realtor(int iD, string name, string email, string phoneNumber, string faxNumber)
        {
            ID = iD;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            FaxNumber = faxNumber;
        }

        public Realtor(string name, string email, string phoneNumber, string faxNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            FaxNumber = faxNumber;
        }

        public Enums.DatabaseError Delete()
        {
            return Database.DeleteRealtor(this) ? Enums.DatabaseError.NoError : Enums.DatabaseError.RealtorDelete;
        }

        public Enums.DatabaseError Insert()
        {
            if (IsValid)
                return Database.InsertRealtor(this) ? Enums.DatabaseError.NoError : Enums.DatabaseError.RealtorInsert;
            else
                return Enums.DatabaseError.RealtorIncomplete;
        }

        public Enums.DatabaseError Update()
        {
            if (IsValid)
                return Database.UpdateRealtor(this) ? Enums.DatabaseError.NoError : Enums.DatabaseError.RealtorUpdate;
            else
                return Enums.DatabaseError.RealtorIncomplete;
        }
    }
}
