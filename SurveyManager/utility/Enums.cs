using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyManager.utility
{
    public class Enums
    {
        /// <summary>
        /// Enum reprenting the two boolean operations available for filtering.
        /// </summary>
        public enum BooleanOps
        {
            /// <summary>
            /// Represents the boolean operation AND
            /// </summary>
            AND,
            /// <summary>
            /// Represents the boolean operation OR
            /// </summary>
            OR
        }

        /// <summary>
        /// Enum representing the different SQL Query types that can be built
        /// </summary>
        public enum QType
        {
            /// <summary>
            /// Represents an Insert SQL Query
            /// </summary>
            INSERT,
            /// <summary>
            /// Represents a Select SQL Query
            /// </summary>
            SELECT,
            /// <summary>
            /// Represents an Update SQL Query
            /// </summary>
            UPDATE,
            /// <summary>
            /// Represents a Delete SQL Query
            /// </summary>
            DELETE
        }

        /// <summary>
        /// Enum representing the different errors that can happen when interacting with the database.
        /// </summary>
        public enum DatabaseError
        {
            /// <summary>
            /// No error has occured.
            /// </summary>
            NoError,
            /// <summary>
            /// Error when a client's data is missing important information.
            /// </summary>
            ClientIncomplete,
            /// <summary>
            /// Error when inserting client data.
            /// </summary>
            ClientInsert,
            /// <summary>
            /// Error when updating client data.
            /// </summary>
            ClientUpdate,
            /// <summary>
            /// Error when deleting client data.
            /// </summary>
            ClientDelete,
            /// <summary>
            /// Error when inserting address data.
            /// </summary>
            AddressInsert,
            /// <summary>
            /// Error when updating address data.
            /// </summary>
            AddressUpdate,
            /// <summary>
            /// Error when deleting address data.
            /// </summary>
            AddressDelete,
            /// <summary>
            /// Error when an address is missing important information
            /// </summary>
            AddressIncomplete,
            /// <summary>
            /// Error when inserting county data.
            /// </summary>
            CountyInsert,
            /// <summary>
            /// Error when updating county data.
            /// </summary>
            CountyUpdate,
            /// <summary>
            /// Error when deleting county data.
            /// </summary>
            CountyDelete,
            /// <summary>
            /// Error when inserting realtor data.
            /// </summary>
            RealtorInsert,
            /// <summary>
            /// Error when updating realtor data.
            /// </summary>
            RealtorUpdate,
            /// <summary>
            /// Error when deleting realtor data.
            /// </summary>
            RealtorDelete,
            /// <summary>
            /// Error when a realtor is missing important information
            /// </summary>
            RealtorIncomplete
        }

        /// <summary>
        /// Enum representing the different entities for the program.
        /// </summary>
        public enum EntityTypes
        {
            /// <summary>
            /// Represents a client entity.
            /// </summary>
            Client,
            /// <summary>
            /// Represents a survey entity.
            /// </summary>
            Survey,
            /// <summary>
            /// Represents a title company entity.
            /// </summary>
            TitleCompany,
            /// <summary>
            /// Represents a realtor entity.
            /// </summary>
            Realtor
        }
    }
}
