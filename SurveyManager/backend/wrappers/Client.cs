using System;
using System.ComponentModel;
using System.Threading;

namespace SurveyManager.backend.wrappers
{
    /// <summary>
    /// Defines a survey client.
    /// </summary>
    public class Client
    {
        [Browsable(false)]
        public int ID { get; set; } = 0;

        [Category("Client Information")]
        [Description("The full name of the client.")]
        [Browsable(true)]
        [DisplayName("Client Name")]
        public string Name { get; set; } = "N/A";

        [Category("Client Information")]
        [Description("The phone number for the client.")]
        [Browsable(true)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } = "N/A";

        [Category("Client Information")]
        [Description("The email address of the client.")]
        [Browsable(true)]
        [DisplayName("Email Address")]
        public string Email { get; set; } = "N/A";

        [Category("Client Information")]
        [Description("The fax number, if any, of the client.")]
        [Browsable(true)]
        [DisplayName("Fax Number")]
        public string FaxNumber { get; set; } = "N/A";

        [Browsable(false)]
        public int AddressID { get; set; }

        [Category("Client Address")]
        [Description("The address of the client.")]
        [Browsable(true)]
        [DisplayName("Address")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Address ClientAddress { get; set; } = new Address();

        /// <summary>
        /// Checks the name and phone number to ensure they are not the default values.
        /// </summary>
        [Browsable(false)]
        public bool IsValid
        {
            get
            {
                return !Name.Equals("N/A") && !PhoneNumber.Equals("N/A");
            }
        }

        public Client() { }

        public Client(int id, int addressID, string name, string phoneNumber, string email, string faxNumber = "")
        {
            ID = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            FaxNumber = faxNumber;
            AddressID = addressID;
        }

        public Client(int id, string name, string phoneNumber, string email, string faxNumber = "")
        {
            ID = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            FaxNumber = faxNumber;
        }

        public Client(string name, string phoneNumber, string email, string faxNumber = "")
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            FaxNumber = faxNumber;
        }

        public Client(string name, string phoneNumber, string email, Address address, string faxNumber = "")
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            ClientAddress = address;
            FaxNumber = faxNumber;
        }

        public Client(int id, string name, string phoneNumber, string email, Address address, string faxNumber = "")
        {
            ID = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            ClientAddress = address;
            FaxNumber = faxNumber;
            AddressID = address.ID;
        }

        public void SetAddress()
        {
            if (AddressID != 0)
            {
                Thread dbThread = new Thread(() =>
                {
                    ClientAddress = Database.GetAddress(AddressID);
                })
                {
                    Name = "GetClientAddressThread",
                    IsBackground = true
                };
                dbThread.Start();
            }
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
