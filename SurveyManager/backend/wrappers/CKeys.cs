using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.backend.wrappers
{
    /// <summary>
    /// Simple class to hold key references for the Survey Table. This is used when deleting a Survey job.
    /// </summary>
    public class CKeys
    {
        public int ClientID { get; private set; }
        public int CountyID { get; private set; }
        public int RealtorID { get; private set; }
        public int TitleCompanyID { get; private set; }
        public int AddressID { get; private set; }

        private int[] keys = new int[5];

        /// <summary>
        /// Get all keys this class as an array of integers.
        /// <para>Returns in this order: <c>ClientID, CountyID, RealtorID, TitleCompanyID, AddressID</c></para>
        /// </summary>
        /// <returns></returns>
        public int[] KeyIDs
        {
            get { return keys; }
            set
            {
                keys = value;
                ClientID = keys[0];
                CountyID = keys[1];
                RealtorID = keys[2];
                TitleCompanyID = keys[3];
                AddressID = keys[4];
            }
        }

        public CKeys(int clientID, int countyID, int realtorID, int titleCompanyID, int addressID)
        {
            ClientID = clientID;
            CountyID = countyID;
            RealtorID = realtorID;
            TitleCompanyID = titleCompanyID;
            AddressID = addressID;

            keys = new int[] { ClientID, CountyID, RealtorID, TitleCompanyID, AddressID };
        }

        /// <summary>
        /// Remove all keys that are zero.
        /// </summary>
        public void RemoveZeroKeys()
        {
            List<int> temp = keys.ToList();
            temp.RemoveAll(k => k == 0);
            keys = temp.ToArray();
        }
    }
}
