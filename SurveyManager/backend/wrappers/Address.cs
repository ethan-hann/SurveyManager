using SurveyManager.utility;
using System;
using System.ComponentModel;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers
{
    /// <summary>
    /// Defines a basic address used for surveys and clients.
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Address : ExpandableObjectConverter, DatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; }

        [Category("Address")]
        [Description("The street component of the address.")]
        [Browsable(true)]
        [DisplayName("Street")]
        public string Street { get; set; } = string.Empty;

        [Category("Address")]
        [Description("The city component of the address.")]
        [Browsable(true)]
        [DisplayName("City")]
        public string City { get; set; } = string.Empty;

        [Category("Address")]
        [Description("The zip code for the address; must be 5 characters long.")]
        [Browsable(true)]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; } = string.Empty;

        [Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return Street.Equals(string.Empty) || City.Equals(string.Empty) || ZipCode.Equals(string.Empty);
            }
        }

        public Address() { }

        public Address(int iD, string street, string city, string zipCode)
        {
            ID = iD;
            Street = street;
            City = city;
            ZipCode = zipCode;
        }

        public Address(string street, string city, string zipCode)
        {
            Street = street;
            City = city;
            ZipCode = zipCode;
        }

        public override string ToString()
        {
            if (!IsEmpty)
                return $"{Street} {City}, {ZipCode}";
            return "(...)";
        }

        public DatabaseError Insert()
        {
            if (!IsEmpty)
                return Database.InsertAddress(this) ? DatabaseError.NoError : DatabaseError.AddressInsert;
            else
                return DatabaseError.AddressIncomplete;
        }

        public DatabaseError Update()
        {
            if (!IsEmpty)
                return Database.UpdateAddress(this) ? DatabaseError.NoError : DatabaseError.AddressUpdate;
            else
                return DatabaseError.AddressIncomplete;
        }

        public DatabaseError Delete()
        {
            return Database.DeleteAddress(this) ? DatabaseError.NoError : DatabaseError.AddressDelete;
        }
    }
}
