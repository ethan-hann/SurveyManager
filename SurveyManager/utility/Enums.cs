using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SurveyManager.utility.Enums;

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
            [Description("No database error has occured.")]
            NoError,
            /// <summary>
            /// Error when a client's data is missing important information.
            /// </summary>
            [Description("The client's information is missing or incomplete.")]
            ClientIncomplete,
            /// <summary>
            /// Error when inserting client data.
            /// </summary>
            [Description("There was an error inserting the client's information into the database.")]
            ClientInsert,
            /// <summary>
            /// Error when updating client data.
            /// </summary>
            [Description("There was an error updating the existing client's information in the database.")]
            ClientUpdate,
            /// <summary>
            /// Error when deleting client data.
            /// </summary>
            [Description("There was an error deleting the existing client from the database.")]
            ClientDelete,
            /// <summary>
            /// Error when inserting address data.
            /// </summary>
            [Description("There was an error inserting an address into the database.")]
            AddressInsert,
            /// <summary>
            /// Error when updating address data.
            /// </summary>
            [Description("There was an error updating an existing address in the database.")]
            AddressUpdate,
            /// <summary>
            /// Error when deleting address data.
            /// </summary>
            [Description("There was an error deleting an existing address from the database.")]
            AddressDelete,
            /// <summary>
            /// Error when an address is missing important information
            /// </summary>
            [Description("The address's information was missing or incomplete.")]
            AddressIncomplete,
            /// <summary>
            /// Error when inserting county data.
            /// </summary>
            [Description("There was an error inserting the county's information into the database.")]
            CountyInsert,
            /// <summary>
            /// Error when updating county data.
            /// </summary>
            [Description("There was an error updating the existing county's information in the database.")]
            CountyUpdate,
            /// <summary>
            /// Error when deleting county data.
            /// </summary>
            [Description("There was an error deleting an existing county from the database.")]
            CountyDelete,
            /// <summary>
            /// Error when a county is missing important information.
            /// </summary>
            [Description("The county's information was missing or incomplete.")]
            CountyIncomplete,
            /// <summary>
            /// Error when inserting realtor data.
            /// </summary>
            [Description("There was an error inserting the realtor's information into the database.")]
            RealtorInsert,
            /// <summary>
            /// Error when updating realtor data.
            /// </summary>
            [Description("There was an error updating the existing realtor's information in the database.")]
            RealtorUpdate,
            /// <summary>
            /// Error when deleting realtor data.
            /// </summary>
            [Description("There was an error deleting an existing realtor from the database.")]
            RealtorDelete,
            /// <summary>
            /// Error when a realtor is missing important information
            /// </summary>
            [Description("The realtor's information was missing or incomplete.")]
            RealtorIncomplete,
            /// <summary>
            /// Error when inseting title company data.
            /// </summary>
            [Description("There was an error inserting the title company's information into the database.")]
            TitleCompanyInsert,
            /// <summary>
            /// Error when updating title company data.
            /// </summary>
            [Description("There was an error updating the existing title company's information in the database.")]
            TitleCompanyUpdate,
            /// <summary>
            /// Error when deleting title company data.
            /// </summary>
            [Description("There was an error deleting an existing title company from the database.")]
            TitleCompanyDelete,
            /// <summary>
            /// Error when a title company is missing important information.
            /// </summary>
            [Description("The title company's information was missing or incomplete.")]
            TitleCompanyIncomplete,
            /// <summary>
            /// Error when inserting file data.
            /// </summary>
            [Description("There was an error inserting the file's information into the database.")]
            FileInsert,
            /// <summary>
            /// Error when updating file data.
            /// </summary>
            [Description("There was an error updating an existing file's information in the database.")]
            FileUpdate,
            /// <summary>
            /// Error when deleting file data.
            /// </summary>
            [Description("There was an error deleting an existing file from the database.")]
            FileDelete,
            /// <summary>
            /// Error when a file is missing important information.
            /// </summary>
            [Description("The file's information was missing or incomplete.")]
            FileIncomplete,
            /// <summary>
            /// Error when inserting survey data.
            /// </summary>
            [Description("There was an error inserting the survey's information into the database.")]
            SurveyInsert,
            /// <summary>
            /// Error when updating survey data.
            /// </summary>
            [Description("There was an error updating the existing survey's information in the database.")]
            SurveyUpdate,
            /// <summary>
            /// Error when deleting survey data.
            /// </summary>
            [Description("There was an error deleting an existing survey from the database.")]
            SurveyDelete,
            /// <summary>
            /// Error when a survey is missing important information.
            /// </summary>
            [Description("The survey's information was missing or incomplete.")]
            SurveyIncomplete,
            /// <summary>
            /// Error when inserting a billing line item.
            /// </summary>
            [Description("There was an error inserting the line item's information into the database.")]
            LineItemInsert,
            /// <summary>
            /// Error when updating a billing line item.
            /// </summary>
            [Description("There was an error updating an existing line item's information in the database.")]
            LineItemUpdate,
            /// <summary>
            /// Error when deleting a billing line item.
            /// </summary>
            [Description("There was an error deleting an existing line item from the database.")]
            LineItemDelete,
            /// <summary>
            /// Error when a billing line item is missing important information.
            /// </summary>
            [Description("The line item's information was missing or incomplete.")]
            LineItemIncomplete,
            /// <summary>
            /// Error when inserting a rate item.
            /// </summary>
            [Description("There was an error inserting the rate's information into the database.")]
            RateInsert,
            /// <summary>
            /// Error when updating a rate item.
            /// </summary>
            [Description("There was an error updating an existing rate's information in the database.")]
            RateUpdate,
            /// <summary>
            /// Error when deleting a rate item.
            /// </summary>
            [Description("There was an error deleting an existing rate from the database.")]
            RateDelete,
            /// <summary>
            /// Error when a rate item is missing important information.
            /// </summary>
            [Description("The rate's information was missing or incomplete.")]
            RateIncomplete,
            /// <summary>
            /// Error when inserting a billing item.
            /// </summary>
            [Description("There was an error inserting the billing item's information into the database.")]
            BillingItemInsert,
            /// <summary>
            /// Error when updating a billing item.
            /// </summary>
            [Description("There was an error updating an existing billing item's information in the database.")]
            BillingItemUpdate,
            /// <summary>
            /// Error when deleting a billing item.
            /// </summary>
            [Description("There was an error deleting an existing billing item from the database.")]
            BillingItemDelete,
            /// <summary>
            /// Error when a billing item is missing important information.
            /// </summary>
            [Description("The billing item's information was missing or incomplete.")]
            BillingItemIncomplete
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
            Realtor,
            /// <summary>
            /// Represents a rate entity.
            /// </summary>
            Rate
        }

        /// <summary>
        /// Enum representing the various item types that a Survey contains.
        /// </summary>
        public enum ItemType
        {
            /// <summary>
            /// Represents that Survey notes should be considered.
            /// </summary>
            Notes,
            /// <summary>
            /// Represents that Survey files should be considered.
            /// </summary>
            Files
        }

        /// <summary>
        /// Enum representing the various close reasons a License Activation dialog can have.
        /// </summary>
        public enum CloseReasons
        {
            /// <summary>
            /// The dialog was closed and the current license is valid.
            /// </summary>
            Licensed,
            /// <summary>
            /// The dialog was closed and the current license is invalid.
            /// </summary>
            Unlicensed,
            /// <summary>
            /// The dialog was closed and the current license was updated.
            /// </summary>
            Updating
        }

        public enum FileExtension
        {
            /// <summary>
            /// An AutoCAD file.
            /// </summary>
            DWG,
            /// <summary>
            /// An AutoCAD file.
            /// </summary>
            DXF,
            /// <summary>
            /// An AutoCAD file.
            /// </summary>
            DWT,
            /// <summary>
            /// An AutoCAD file.
            /// </summary>
            DXB,
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
            /// A picture file.
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

        public enum StatusText
        {
            [Description("No job is currently opened. There is nothing to add a Client to.")]
            NoJob_AddClient,
            [Description("No job is currently opened. There is nothing to add a Realtor to.")]
            NoJob_AddRealtor,
            [Description("No job is currently opened. There is nothing to add a Title Company to.")]
            NoJob_AddTitleCompany,
            [Description("No job is currently opened. There is nothing to change.")]
            NoJob_BasicInfo,
            [Description("No job is currently opened. There is nothing to view.")]
            NoJob_View,
            [Description("No job is currently opened. There is nothing to save.")]
            NoJob_Save,
            [Description("No job is currently opened. There is nothing to close.")]
            NoJob_Close,
            [Description("No job is currently opened. There is nothing to attach files to.")]
            NoJob_AttachFile,
            [Description("No job is currently opened. There is nothing to view the files of.")]
            NoJob_ViewFiles,
            [Description("No job is currently opened. There is nothing to edit rates for.")]
            NoJob_EditRates,
            [Description("No job is currently opened. There is nothing to add time to.")]
            NoJob_AddTime,
            [Description("No job is currently opened. There is nothing to add billing items to.")]
            NoJob_AddBillingItems,
            [Description("No job is currently opened. There is no current bill to open.")]
            NoJob_OpenBill,
            [Description("No job is currently opened. There is nothing to add notes to.")]
            NoJob_AddNotes,
            [Description("No job is currently opened. There is no billing portal to open.")]
            NoJob_BillingPortal,
            [Description("No server connection defined. Can't access database. Please open a connection using the Database Connection button on the Database tab.")]
            NoDatabaseConnection,
            [Description("Survey Manager - Database: {0}\t\t{1}\t\t{2}")]
            TitleText,
            [Description("No job is currently opened. There is nothing to generate a report for.")]
            NoJob_FullReport,
            [Description("No job is currently opened. There is nothing to generate a full file report for.")]
            NoJob_FileReport,
            [Description("There are no files associated with this job; nothing to generate a full file report for.")]
            FileReport_NoFiles
        }

        /// <summary>
        /// Enum representing the various time units to use for billing.
        /// </summary>
        public enum TimeUnit
        {
            Minute,
            Hour,
            Day
        }

        public enum ExitChoice
        {
            SaveAndExit,
            SaveOnly,
            ExitNoSave,
            Cancel
        }

        public enum SurveyPage
        {
            IsSurveyPage
        }

        public enum TimeType
        {
            Office,
            Field
        }

        public enum Fonts
        {
            Courier,
            TimesNewRoman
        }
    }

    public static class EnumExtensions
    {
        public static string ToDescriptionString(this StatusText val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static string ToDescriptionString(this DatabaseError val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}
