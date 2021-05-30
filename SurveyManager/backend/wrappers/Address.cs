using System;
using System.ComponentModel;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers
{
    /// <summary>
    /// This class represents an address. An address in the case of Survey Manager does not have a state associated with it.
    /// <para>All addresses are assumed to be in the state of Texas.</para>
    /// <para>This class implements the <see cref="IDatabaseWrapper"/> interface to facilitate easier database operations.</para>
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class Address : ExpandableObjectConverter, IDatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; }

        /// <summary>
        /// The street component of the address.
        /// </summary>
        [Category("Address")]
        [Description("The street component of the address.")]
        [Browsable(true)]
        [DisplayName("Street")]
        public string Street { get; set; } = string.Empty;

        /// <summary>
        /// The city component of the address.
        /// </summary>
        [Category("Address")]
        [Description("The city component of the address.")]
        [Browsable(true)]
        [DisplayName("City")]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// The zip-code component of the address.
        /// </summary>
        [Category("Address")]
        [Description("The zip code for the address; must be 5 characters long.")]
        [Browsable(true)]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; } = string.Empty;

        /// <summary>
        /// Get a value indicating if this address is considered to be empty.
        /// <para>Returns true if the street, city, or zip-code are empty strings.</para>
        /// </summary>
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
            DatabaseError e;
            if (!IsEmpty)
            {
                if (ID == 0)
                {
                    ID = Database.InsertAddress(this);
                    e = ID != 0 ? DatabaseError.NoError : DatabaseError.AddressInsert;
                }
                else
                {
                    e = Database.UpdateAddress(this) ? DatabaseError.NoError : DatabaseError.AddressUpdate;
                }
                return e;
            }
            else
                return DatabaseError.AddressIncomplete;
        }

        public DatabaseError Update()
        {
            return Insert();
        }

        public DatabaseError Delete()
        {
            return Database.DeleteAddress(this) ? DatabaseError.NoError : DatabaseError.AddressDelete;
        }
    }
}
