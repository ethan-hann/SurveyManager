using SurveyManager.backend.wrappers.SurveyJob;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Survey : ExpandableObjectConverter, DatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; }

        [Category("Survey Information")]
        [Description("The job number assigned to this survey.")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Job Number")]
        public string JobNumber { get; set; } = "N/A";

        [Category("Survey Information")]
        [Description("A description for this survey job.")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Description")]
        public string Description { get; set; } = "N/A";

        [Category("Survey Information")]
        [Description("The abstract number where this survey job is located.")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Abstract")]
        public string AbstractNumber { get; set; } = "N/A";

        [Category("Survey Information")]
        [Description("The survey this job is located in.")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Survey")]
        public string SurveyName { get; set; } = "N/A";

        [Category("Subdivision")]
        [Description("The subdivision, if any, this survey job is located. If a subdivision is specified, the lot number, block number, and section number should also be specified.")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Subdivision")]
        public string Subdivision { get; set; } = "N/A";

        [Category("Subdivision")]
        [Description("The lot number in the subdivision for this survey job.")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Lot Number")]
        public string LotNumber { get; set; } = "N/A";

        [Category("Subdivision")]
        [Description("The block number in the subdivision for this survey job.")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Block Number")]
        public string BlockNumber { get; set; } = "N/A";

        [Category("Subdivision")]
        [Description("The section in the subdivision for this survey job.")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Section Number")]
        public string SectionNumber { get; set; } = "N/A";

        [Category("Survey Information")]
        [Description("The number of acres this survey is for.")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Acres")]
        public double Acres { get; set; }

        [Category("Associated Objects")]
        [Description("The client who ordered the survey.")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Client")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Client Client { get; set; } = new Client();

        [Browsable(false)]
        public int ClientID { get; set; }

        [Category("Associated Objects")]
        [Description("The county this survey is located in.")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("County")]
        [TypeConverter(typeof(CountyTypeConverter))]
        public County County { get; set; }

        [Browsable(false)]
        public int CountyID { get; set; }

        [Category("Associated Objects")]
        [Description("The realtor, if any, for this survey.")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Realtor")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Realtor Realtor { get; set; } = new Realtor();

        [Browsable(false)]
        public int RealtorID { get; set; }

        [Category("Associated Objects")]
        [Description("The title company, if any, for this survey.")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Title Company")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TitleCompany TitleCompany { get; set; } = new TitleCompany();

        [Browsable(false)]
        public int TitleCompanyID { get; set; }

        [Category("Survey Information")]
        [Description("The location for this survey job.")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Location")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Address Location { get; set; } = new Address();

        [Browsable(false)]
        public int LocationID { get; set; }

        [Browsable(false)]
        public string FileIds { get; set; } = "N/A";

        [Browsable(false)]
        public List<CFile> Files { get; private set; } = new List<CFile>();

        [Category("Files")]
        [Description("The total number of files associated with this survey job.")]
        [Browsable(true)]
        [ReadOnly(true)]
        [DisplayName("Files")]
        public int NumOfFiles
        {
            get
            {
                return Files.Count;
            }
        }

        [Browsable(false)]
        public bool HasFiles
        {
            get
            {
                return Files.Count != 0;
            }
        }

        [Browsable(false)]
        public Billing BillingObject { get; set; } = new Billing();

        [Category("Billing")]
        [Description("The total amount of field time spent on this job.")]
        [Browsable(true)]
        [DisplayName("Field Time")]
        public string TotalFieldTime
        {
            get
            {
                return Utility.ToFullString(BillingObject.GetTotalFieldTime());
            }
        }

        [Category("Billing")]
        [Description("The total dollar amount to bill for the field time, including any applicable tax.")]
        [Browsable(true)]
        [DisplayName("Field Bill")]
        public string FieldAmount
        {
            get
            {
                return BillingObject.GetTotalFieldBill().ToString("C2");
            }
        }

        [Category("Billing")]
        [Description("The total amount of office time spent on this job.")]
        [Browsable(true)]
        [DisplayName("Office Time")]
        public string TotalOfficeTime
        {
            get
            {
                return Utility.ToFullString(BillingObject.GetTotalOfficeTime());
            }
        }

        [Category("Billing")]
        [Description("The total dollar amount to bill for the office time, including any applicable tax.")]
        [Browsable(true)]
        [DisplayName("Office Bill")]
        public string OfficeAmount
        {
            get
            {
                return BillingObject.GetTotalOfficeBill().ToString("C2");
            }
        }

        [Category("Billing")]
        [Description("The total billing amount including office time, field time, and all additional line items for this survey.")]
        [Browsable(true)]
        [DisplayName("Billing Total")]
        public string BillingTotal
        {
            get
            {
                return string.Format("{0:C}", BillingObject.GetTotalBill());
            }
        }

        [Browsable(false)]
        public Dictionary<DateTime, string> Notes { get; internal set; } = new Dictionary<DateTime, string>();

        [Browsable(false)]
        public string NotesString { get; set; } = "N/A";

        /// <summary>
        /// Get a value that indicates if this is a valid Survey object.
        /// <para>A valid survey has a client, county, job number, and description at the very least.</para>
        /// </summary>
        [Browsable(false)]
        public bool IsValidSurvey
        {
            get
            {
                return (Client != null && Client.IsValidClient) && County != null && !JobNumber.Equals("N/A") && !Description.Equals("N/A") && !AbstractNumber.Equals("N/A");
            }
        }

        /// <summary>
        /// Populates the objects for this survey with values from the database.
        /// <para>Gets the survey's Client, County, Realtor, TitleCompany, and any files associated with it.</para>
        /// </summary>
        public void SetObjects()
        {
            if (ClientID != 0)
            {
                Thread dbThread = new Thread(() =>
                {
                    Client = Database.GetClient(ClientID);
                })
                {
                    IsBackground = true
                };
                dbThread.Start();
            }
            if (CountyID != 0)
            {
                Thread dbThread = new Thread(() =>
                {
                    County = Database.GetCounty(CountyID);
                })
                {
                    IsBackground = true
                };
                dbThread.Start();
            }
            if (RealtorID != 0)
            {
                Thread dbThread = new Thread(() =>
                {
                    Realtor = Database.GetRealtor(RealtorID);
                })
                {
                    IsBackground = true
                };
                dbThread.Start();
            }
            if (TitleCompanyID != 0)
            {
                Thread dbThread = new Thread(() =>
                {
                    TitleCompany = Database.GetTitleCompany(TitleCompanyID);
                })
                {
                    IsBackground = true
                };
                dbThread.Start();
            }
            if (LocationID != 0)
            {
                Thread dbThread = new Thread(() =>
                {
                    Location = Database.GetAddress(LocationID);
                })
                {
                    IsBackground = true
                };
                dbThread.Start();
            }
            if (!FileIds.Equals("N/A"))
            {
                Thread dbThread = new Thread(() =>
                {
                    int[] ids = ParseIds(FileIds);
                    Files = Database.GetFiles(ids);
                })
                {
                    IsBackground = true
                };
                dbThread.Start();
            }
            if (!NotesString.Equals("N/A"))
            {
                ParseNotes(NotesString);
            }

            BillingObject.SetObjects();
        }

        /// <summary>
        /// Add a new file to the associated file list.
        /// </summary>
        /// <param name="file">The file to add.</param>
        public void AddFile(CFile file)
        {
            Files.Add(file);
        }

        /// <summary>
        /// Adds the files to the associated file list if they are not already present.
        /// </summary>
        /// <param name="files">The files to add.</param>
        public void AddFiles(ICollection<CFile> files)
        {
            foreach (CFile file in files)
            {
                if (!Files.Contains(file))
                    Files.Add(file);
            }
        }

        /// <summary>
        /// Overwrites the files list to be the specified files instead.
        /// </summary>
        /// <param name="files">The files to set as the new <see cref="Files"/> list.</param>
        public void SetFiles(ICollection<CFile> files)
        {
            Files = files.ToList();
            FileIds = "";
        }

        /// <summary>
        /// Remove a file, if it exists, from the associated file list.
        /// </summary>
        /// <param name="file">The file to remove.</param>
        public void RemoveFile(CFile file)
        {
            if (Files.Contains(file))
                Files.Remove(file);
        }

        /// <summary>
        /// Remove all files in <paramref name="files"/> from <see cref="Files"/>.
        /// </summary>
        /// <param name="files">The collection of files to remove.</param>
        public void RemoveFiles(ICollection<CFile> files)
        {
            Files = (List<CFile>)Files.Except(files).Cast<CFile>();
        }

        /// <summary>
        /// Clear this survey's associated files and file ids.
        /// </summary>
        public void ClearFiles()
        {
            Files = new List<CFile>();
            FileIds = "N/A";
        }

        /// <summary>
        /// Add a new file id to the id list.
        /// </summary>
        /// <param name="id">The id to add.</param>
        public void AddFileId(int id)
        {
            if (FileIds.Equals("N/A"))
                FileIds = "";

            if (FileIds.Contains($"{id}"))
                return;

            StringBuilder str = new StringBuilder(FileIds);
            str.Append($"{id}, ");
            FileIds = str.ToString().Trim();
        }

        /// <summary>
        /// Remove a file id from the id list.
        /// </summary>
        /// <param name="id">The id to remove.</param>
        public void RemoveFileId(int id)
        {
            StringBuilder str = new StringBuilder(FileIds);
            str.Replace($"{id},", string.Empty);
            FileIds = str.ToString().Trim();
            if (FileIds.Equals(""))
                FileIds = "N/A";
        }

        public void AddNote(DateTime time, string newNote)
        {
            if (!Notes.ContainsKey(time))
                Notes.Add(time, newNote);
        }

        public void AddNote(string newNote)
        {
            Notes.Add(DateTime.Now, newNote);
        }

        public void RemoveNote(DateTime time)
        {
            if (Notes.ContainsKey(time))
                Notes.Remove(time);
        }

        /// <summary>
        /// Parses a string containing notes and times into the appropiate dictionary in this class.
        /// <para>A note is specified by a dateTime in ticks (i.e., 637539336310000000) followed by a string; these two components are seperated by <c>/*--*/</c></para>
        /// </summary>
        /// <param name="notesString">The string containing the notes and time information.</param>
        public bool ParseNotes(string notesString)
        {
            //Notes format -> 637539336310000000/*--*/NotesGoHere/*--*/637539384080000000/*--*/More Notes here.../*--*/
            string noteDelimter = "/*--*/";
            string[] notes = notesString.Split(noteDelimter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            //If we dont have an even number of items (meaning we don't have pairs of times and notes,
            //return false and don't attempt parse
            if (notes.Length % 2 != 0)
                return false;

            //the notes array has a time in ticks followed by the note content:
            //i.e. (0) 18:00:31, (1) NotesGoHere, (2) 19:20:08, (3) More Notes here...
            //need to only iterate every other item containing the time entry, hence i+=2
            for (int i = 0; i < notes.Length - 1; i += 2)
            {
                AddNote(new DateTime(long.Parse(notes[i])), notes[i + 1]);
            }

            return true;
        }

        private int[] ParseIds(string strids)
        {
            string trimmed = strids.Trim();
            string delimeter = ",";
            string[] tokens = trimmed.Split(delimeter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int[] ids = new int[tokens.Length];
            for (int i = 0; i < tokens.Length; i++)
            {
                ids[i] = int.Parse(tokens[i]);
            }
            return ids;
        }

        public string GetNotesString()
        {
            StringBuilder bldr = new StringBuilder();
            foreach (DateTime key in Notes.Keys)
            {
                bldr.Append($"{key.Ticks}/*--*/{Notes[key]}/*--*/");
            }
            return bldr.ToString();
        }

        private DatabaseError UpdateObjects()
        {
            DatabaseError e;

            e = Client.Insert();
            if (e != DatabaseError.NoError)
                return e;

            e = Location.Insert();
            if (e != DatabaseError.NoError)
                return e;
            LocationID = Location.ID;

            e = County.Insert();
            if (e != DatabaseError.NoError)
                return e;
            CountyID = County.ID;

            if (Realtor.IsValidRealtor)
            {
                e = Realtor.Insert();
                if (e != DatabaseError.NoError)
                    return e;
                RealtorID = Realtor.ID;
            }

            if (TitleCompany.IsValidCompany)
            {
                e = TitleCompany.Insert();
                if (e != DatabaseError.NoError)
                    return e;
                TitleCompanyID = TitleCompany.ID;
            }

            e = BillingObject.Insert();
            if (e != DatabaseError.NoError)
                return e;

            #region Files Insert
            foreach (CFile file in Files)
            {
                DatabaseError fileError = file.Insert();
                if (fileError != DatabaseError.NoError)
                    return fileError;
                AddFileId(file.ID);
            }
            #endregion

            return DatabaseError.NoError;
        }

        public override string ToString()
        {
            return JobNumber;
        }

        /// <summary>
        /// Handles insertion of this survey and any files associated with it.
        /// </summary>
        /// <returns>A <see cref="DatabaseError"/> with the result of the Insert operation.</returns>
        public DatabaseError Insert()
        {
            if (IsValidSurvey)
            {
                DatabaseError e = UpdateObjects();
                if (e != DatabaseError.NoError)
                    return e;
                if (ID == 0)
                {
                    ID = Database.InsertSurvey(this);
                    e = ID != 0 ? DatabaseError.NoError : DatabaseError.SurveyInsert;
                }
                else
                {
                    e = Database.UpdateSurvey(this) ? DatabaseError.NoError : DatabaseError.SurveyUpdate;
                }
                return e;
            }
            return DatabaseError.SurveyIncomplete;
        }

        /// <summary>
        /// Handles updating this survey and any files associated with it as well. 
        /// If there is a file with an ID of 0 (meaning it hasn't been inserted yet), inserts it.
        /// </summary>
        /// <returns>A <see cref="DatabaseError"/> with the result of the Update operation.</returns>
        public DatabaseError Update()
        {
            return Insert();
        }

        private DatabaseError DeleteObjects()
        {
            DatabaseError e;
            e = Database.DeleteAddress(Location) ? DatabaseError.NoError : DatabaseError.AddressDelete;
            if (e != DatabaseError.NoError)
                return e;

            e = BillingObject.Delete();
            if (e != DatabaseError.NoError)
                return e;

            foreach (CFile file in Files)
            {
                e = Database.DeleteFile(file) ? DatabaseError.NoError : DatabaseError.FileDelete;
                if (e != DatabaseError.NoError)
                    return e;
            }

            return DatabaseError.NoError;
        }

        /// <summary>
        /// Delete this survey from the database, along with the associated files and billing line items.
        /// </summary>
        /// <returns>A <see cref="DatabaseError"/> with the result of the Delete operation.</returns>
        public DatabaseError Delete()
        {
            DatabaseError e = DeleteObjects();
            if (e != DatabaseError.NoError)
                return e;

            return Database.DeleteSurvey(this) ? DatabaseError.NoError : DatabaseError.SurveyDelete;
        }
    }
}
