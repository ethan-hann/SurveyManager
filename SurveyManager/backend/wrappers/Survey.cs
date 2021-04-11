﻿using SurveyManager.forms.surveyMenu;
using SurveyManager.utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SurveyManager.utility.Enums;

namespace SurveyManager.backend.wrappers
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [Serializable]
    public class Survey : ExpandableObjectConverter, DatabaseWrapper
    {
        [Browsable(false)]
        public int ID { get; set; }

        [Category("Survey Information")]
        [Description("The job number assigned to this survey.")]
        [Browsable(true)]
        [DisplayName("Job Number")]
        public string JobNumber { get; set; } = "N/A";

        [Browsable(false)]
        public int ClientID { get; set; }

        [Category("Survey Information")]
        [Description("A description for this survey job.")]
        [Browsable(true)]
        [DisplayName("Description")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Description { get; set; } = "N/A";

        [Category("Survey Information")]
        [Description("The abstract number where this survey job is located.")]
        [Browsable(true)]
        [DisplayName("Survey Abstract")]
        public string AbstractNumber { get; set; } = "N/A";

        [Category("Subdivision")]
        [Description("The subdivision, if any, this survey job is located. If a subdivision is specified, the lot number, block number, and section number should also be specified.")]
        [Browsable(true)]
        [DisplayName("Subdivision")]
        public string Subdivision { get; set; } = "N/A";

        [Category("Subdivision")]
        [Description("The lot number in the subdivision for this survey job.")]
        [Browsable(true)]
        [DisplayName("Lot Number")]
        public string LotNumber { get; set; } = "N/A";

        [Category("Subdivision")]
        [Description("The block number in the subdivision for this survey job.")]
        [Browsable(true)]
        [DisplayName("Block Number")]
        public string BlockNumber { get; set; } = "N/A";

        [Category("Subdivision")]
        [Description("The section in the subdivision for this survey job.")]
        [Browsable(true)]
        [DisplayName("Section Number")]
        public string SectionNumber { get; set; } = "N/A";

        [Browsable(false)]
        public int CountyID { get; set; }

        [Category("Survey Information")]
        [Description("The number of acres this survey is for.")]
        [Browsable(true)]
        [DisplayName("Acres")]
        public double Acres { get; set; }

        [Browsable(false)]
        public int RealtorID { get; set; }

        [Browsable(false)]
        public int TitleCompanyID { get; set; }

        [Category("Associated Objects")]
        [Description("The client who ordered the survey.")]
        [Browsable(true)]
        [DisplayName("Client")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Client Client { get; set; } = new Client();

        [Category("Associated Objects")]
        [Description("The county this survey is located in.")]
        [Browsable(true)]
        [DisplayName("County")]
        [TypeConverter(typeof(CountyTypeConverter))]
        public County County { get; set; } = new County();

        [Category("Associated Objects")]
        [Description("The realtor, if any, for this survey.")]
        [Browsable(true)]
        [DisplayName("Realtor")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Realtor Realtor { get; set; } = new Realtor();

        [Category("Associated Objects")]
        [Description("The title company, if any, for this survey.")]
        [Browsable(true)]
        [DisplayName("Title Company")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TitleCompany TitleCompany { get; set; } = new TitleCompany();

        [Category("Survey Information")]
        [Description("The location for this survey job, if different from the Client's address.")]
        [Browsable(true)]
        [DisplayName("Location")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Address Location { get; set; } = new Address();

        [Browsable(false)]
        public int LocationID { get; set; }

        [Browsable(false)]
        public string FileIds { get; set; } = "N/A";

        [Category("Files")]
        [Description("The total number of files associated with this survey job.")]
        [Browsable(true)]
        [DisplayName("Files")]
        public int NumOfFiles
        {
            get
            {
                return Files.Count;
            }
        }

        [Category("Files")]
        [Description("A list of files that should be associated with this survey job.")]
        [Browsable(false)]
        [DisplayName("Files")]
        //[Editor(typeof(UploadFileEditor), typeof(UITypeEditor))]
        public List<CFile> Files { get; private set; } = new List<CFile>();
        //TODO: see https://stackoverflow.com/questions/7456738/how-do-i-pass-an-argument-to-a-class-that-inherits-uitypeeditor

        [Browsable(false)]
        public bool HasFiles
        {
            get
            {
                return Files.Count != 0;
            }
        }

        /// <summary>
        /// Get a value that indicates if this is a valid Survey object.
        /// <para>A valid survey has a client, county, job number, and description at the very least.</para>
        /// </summary>
        [Browsable(false)]
        public bool IsValidSurvey
        {
            get
            {
                return Client != null && County != null && !JobNumber.Equals("N/A") && !Description.Equals("N/A") && !AbstractNumber.Equals("N/A");
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
            if (LocationID == Client.ClientAddress.ID)
            {
                Location = Client.ClientAddress;
            }
            else if (LocationID != 0)
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
                    int[] ids = ParseFileIds();
                    Files = Database.GetFiles(ids);
                })
                {
                    IsBackground = true
                };
                dbThread.Start();
            }
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
        /// Adds the files to the associated file list.
        /// </summary>
        /// <param name="files">The files to add.</param>
        public void AddFiles(ICollection<CFile> files)
        {
            Files.AddRange(files);
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

        private int[] ParseFileIds()
        {
            string trimmed = FileIds.Trim();
            string[] tokens = trimmed.Split(',');

            int[] ids = new int[tokens.Length - 1];
            for (int i = 0; i < tokens.Length - 1; i++)
            {
                ids[i] = int.Parse(tokens[i]);
            }
            return ids;
        }

        /// <summary>
        /// Delete this survey from the database, along with the associated files.
        /// </summary>
        /// <returns>A <see cref="DatabaseError"/> with the result of the Delete operation.</returns>
        public DatabaseError Delete()
        {
            foreach (CFile file in Files)
            {
                DatabaseError fileError = Database.DeleteFile(file) ? DatabaseError.NoError : DatabaseError.FileDelete;
                if (fileError == DatabaseError.FileDelete)
                    return fileError;
            }

            return Database.DeleteSurvey(this) ? DatabaseError.NoError : DatabaseError.SurveyDelete;
        }

        /// <summary>
        /// Handles insertion of this survey and any files associated with it.
        /// </summary>
        /// <returns>A <see cref="DatabaseError"/> with the result of the Insert operation.</returns>
        public DatabaseError Insert()
        {
            #region Client Insert/Update
            if (Client.ID == 0)
            {
                DatabaseError clientError = Client.Insert();
                if (clientError != DatabaseError.NoError)
                    return clientError;
                Client.ID = Database.GetLastRowIDInserted("Client");
            }
            else
            {
                DatabaseError clientError = Client.Update();
                if (clientError != DatabaseError.NoError)
                    return clientError;
            }
            #endregion
            #region Realtor Insert/Update
            if (Realtor.IsValidRealtor)
            {
                if (Realtor.ID == 0)
                {
                    DatabaseError realtorError = Realtor.Insert();
                    if (realtorError != DatabaseError.NoError)
                        return realtorError;
                    Realtor.ID = Database.GetLastRowIDInserted("Realtor");
                }
                else
                {
                    DatabaseError realtorError = Realtor.Update();
                    if (realtorError != DatabaseError.NoError)
                        return realtorError;
                }
            }
            #endregion
            #region Title Company Insert/Update
            if (TitleCompany.IsValidCompany)
            {
                if (TitleCompany.ID == 0)
                {
                    DatabaseError tcError = TitleCompany.Insert();
                    if (tcError != DatabaseError.NoError)
                        return tcError;
                    TitleCompany.ID = Database.GetLastRowIDInserted("TitleCompany");
                }
                else
                {
                    DatabaseError tcError = TitleCompany.Update();
                    if (tcError != DatabaseError.NoError)
                        return tcError;
                }
            }
            #endregion
            #region Location Insert/Update
            {
                if (Location.ID == 0)
                {
                    DatabaseError locationError = Location.Insert();
                    if (locationError != DatabaseError.NoError)
                        return locationError;
                    Location.ID = Database.GetLastRowIDInserted("Address");
                }
                else
                {
                    DatabaseError locError = Location.Update();
                    if (locError != DatabaseError.NoError)
                        return locError;
                }
            }
            #endregion
            #region Files Insert
            foreach (CFile file in Files)
            {
                DatabaseError fileError = file.Update();
                if (fileError == DatabaseError.FileInsert)
                    return fileError;
                if (file.ID == 0)
                    AddFileId(Database.GetLastRowIDInserted("File"));
                else
                    AddFileId(file.ID);
            }
            #endregion
            #region County Insert
            if (County.ID == 0)
                return DatabaseError.CountyInsert;
            #endregion

            return Database.InsertSurvey(this) ? DatabaseError.NoError : DatabaseError.SurveyInsert;
        }

        /// <summary>
        /// Handles updating this survey and any files associated with it as well. 
        /// If there is a file with an ID of 0 (meaning it hasn't been inserted yet), inserts it.
        /// </summary>
        /// <returns>A <see cref="DatabaseError"/> with the result of the Update operation.</returns>
        public DatabaseError Update()
        {
            if (!IsValidSurvey)
                return DatabaseError.SurveyIncomplete;
            
            #region Client Update
            if (Client.ID != 0)
            {
                DatabaseError clientError = Client.Update();
                if (clientError != DatabaseError.NoError)
                    return clientError;
            }
            #endregion
            #region Realtor Update
            if (Realtor.IsValidRealtor)
            {
                if (Realtor.ID == 0)
                {
                    DatabaseError realtorError = Realtor.Update();
                    if (realtorError != DatabaseError.NoError)
                        return realtorError;
                }
            }
            #endregion
            #region Title Company Update
            if (TitleCompany.IsValidCompany)
            {
                if (TitleCompany.ID != 0)
                {
                    DatabaseError tcError = TitleCompany.Update();
                    if (tcError != DatabaseError.NoError)
                        return tcError;
                }
                
            }
            #endregion
            #region Location Update
            {
                if (Location.ID != 0)
                {
                    DatabaseError locationError = Location.Update();
                    if (locationError != DatabaseError.NoError)
                        return locationError;
                }
            }
            #endregion
            #region Files Update
            foreach (CFile file in Files)
            {
                DatabaseError fileError = file.Update();
                if (fileError == DatabaseError.FileInsert)
                    return fileError;
                if (file.ID == 0)
                    AddFileId(Database.GetLastRowIDInserted("File"));
                else
                    AddFileId(file.ID);
            }
            #endregion

            return Database.UpdateSurvey(this) ? DatabaseError.NoError : DatabaseError.SurveyInsert;
        }

        public override string ToString()
        {
            return JobNumber;
        }
    }
}
