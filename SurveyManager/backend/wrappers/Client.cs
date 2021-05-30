using System;
using System.ComponentModel;
using System.Threading;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers
{
    /// <summary>
    /// This class represents a Client object. A client is associated with a <see cref="SurveyJob.Survey"/>.
    /// <para>This class implements the <see cref="IDatabaseWrapper"/> interface to facilitate easier database operations.</para>
    /// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class Client : ExpandableObjectConverter, IDatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; } = 0;

        /// <summary>
        /// The full name of the client.
        /// </summary>
        [Category("Client Information")]
        [Description("The full name of the client.")]
        [Browsable(true)]
        [DisplayName("Client Name")]
        public string Name { get; set; } = "N/A";

        /// <summary>
        /// The phone number of the client.
        /// </summary>
        [Category("Client Information")]
        [Description("The phone number of the client.")]
        [Browsable(true)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } = "N/A";

        /// <summary>
        /// The email address of the client.
        /// </summary>
        [Category("Client Information")]
        [Description("The email address of the client.")]
        [Browsable(true)]
        [DisplayName("Email Address")]
        public string Email { get; set; } = "N/A";

        /// <summary>
        /// The fax number, if any, of the client.
        /// </summary>
        [Category("Client Information")]
        [Description("The fax number, if any, of the client.")]
        [Browsable(true)]
        [DisplayName("Fax Number")]
        public string FaxNumber { get; set; } = "N/A";

        /// <summary>
        /// The id for this client's address in the database.
        /// </summary>
        [Browsable(false)]
        public int AddressID { get; set; }

        /// <summary>
        /// The <see cref="Address"/> for this client object.
        /// </summary>
        [Category("Client Address")]
        [Description("The address of the client.")]
        [Browsable(true)]
        [DisplayName("Address")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Address ClientAddress { get; set; } = new Address();

        /// <summary>
        /// Get a value indicating if the client is valid. A valid client is one whose name and phone number is not "N/A" and whose address is 
        /// not empty.
        /// </summary>
        [Browsable(false)]
        public bool IsValidClient
        {
            get
            {
                return !Name.Equals("N/A") && !PhoneNumber.Equals("N/A") && !ClientAddress.IsEmpty;
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

        /// <summary>
        /// Set the <see cref="ClientAddress"/> object from the database based on the id in <see cref="AddressID"/>. Runs on a seperate thread.
        /// </summary>
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

        public DatabaseError Insert()
        {
            DatabaseError e;
            if (IsValidClient)
            {
                if (ClientAddress.ID == 0)
                {
                    ClientAddress.ID = Database.InsertAddress(ClientAddress);
                    AddressID = ClientAddress.ID;
                    e = ClientAddress.ID != 0 ? DatabaseError.NoError : DatabaseError.AddressInsert;
                    if (e != DatabaseError.NoError)
                        return e;
                }
                else
                {
                    e = Database.UpdateAddress(ClientAddress) ? DatabaseError.NoError : DatabaseError.AddressUpdate;
                    if (e != DatabaseError.NoError)
                        return e;
                }

                if (ID == 0)
                {
                    ID = Database.InsertClient(this);
                    e = ID != 0 ? DatabaseError.NoError : DatabaseError.ClientInsert;
                }
                else
                {
                    e = Database.UpdateClient(this) ? DatabaseError.NoError : DatabaseError.ClientUpdate;
                }
                return e;
            }
            return DatabaseError.ClientIncomplete;
        }

        public DatabaseError Update()
        {
            return Insert();
        }

        public DatabaseError Delete()
        {
            return Database.DeleteClient(this) ? DatabaseError.NoError : DatabaseError.ClientDelete;
        }
    }
}
