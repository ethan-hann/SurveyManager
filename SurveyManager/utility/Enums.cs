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
            RealtorIncomplete,
            /// <summary>
            /// Error when inseting title company data.
            /// </summary>
            TitleCompanyInsert,
            /// <summary>
            /// Error when updating title company data.
            /// </summary>
            TitleCompanyUpdate,
            /// <summary>
            /// Error when deleting title company data.
            /// </summary>
            TitleCompanyDelete,
            /// <summary>
            /// Error when a title company is missing important information.
            /// </summary>
            TitleCompanyIncomplete,
            /// <summary>
            /// Error when inserting file data.
            /// </summary>
            FileInsert,
            /// <summary>
            /// Error when updating file data.
            /// </summary>
            FileUpdate,
            /// <summary>
            /// Error when deleting file data.
            /// </summary>
            FileDelete,
            /// <summary>
            /// Error when a file is missing important information.
            /// </summary>
            FileIncomplete
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

        public enum FileExtension
        {
            /// <summary>
            /// An AutoCAD drawing file.
            /// </summary>
            DWG,
            /// <summary>
            /// A plain text file.
            /// </summary>
            TXT,
            /// <summary>
            /// A legacy word document.
            /// </summary>
            DOC,
            /// <summary>
            /// A word document.
            /// </summary>
            DOCX,
            /// <summary>
            /// A PDF document.
            /// </summary>
            PDF,
            /// <summary>
            /// A portable graphics picture.
            /// </summary>
            PNG,
            /// <summary>
            /// A picture file.
            /// </summary>
            JPG,
            /// <summary>
            /// An alternate form of a JPG file.
            /// </summary>
            JPEG,
            /// <summary>
            /// Represents no file extension.
            /// </summary>
            NONE
        }
    }
}
