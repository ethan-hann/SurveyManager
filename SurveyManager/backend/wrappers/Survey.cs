using SurveyManager.forms.surveyMenu;
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
        [TypeConverter(typeof(ExpandableObjectConverter))]
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

        [Browsable(false)]
        public string FileIds { get; set; } = "N/A";

        [Category("Files")]
        [Description("A list of files that should be associated with this survey job.")]
        [Browsable(true)]
        [DisplayName("Files")]
        [Editor(typeof(UploadFileEditor), typeof(UITypeEditor))]
        public List<CFile> Files { get; private set; } = new List<CFile>();

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
        /// Remove a file, if it exists, from the associated file list.
        /// </summary>
        /// <param name="file">The file to remove.</param>
        public void RemoveFile(CFile file)
        {
            if (Files.Contains(file))
                Files.Remove(file);
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
        }

        private int[] ParseFileIds()
        {
            string trimmed = FileIds.Trim();
            string[] tokens = trimmed.Split(',');

            int[] ids = new int[tokens.Length];
            for (int i = 0; i < tokens.Length; i++)
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
            if (!IsValidSurvey)
                return DatabaseError.SurveyIncomplete;

            foreach (CFile file in Files)
            {
                DatabaseError fileError = Database.InsertFile(file) ? DatabaseError.NoError : DatabaseError.FileInsert;
                int id = Database.GetLastRowIDInserted("File");
                if (fileError == DatabaseError.FileInsert)
                    return fileError;
                AddFileId(id);
            }
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

            foreach (CFile file in Files)
            {
                DatabaseError fileError;
                //We need to insert a new file
                if (file.ID == 0)
                {
                    fileError = Database.InsertFile(file) ? DatabaseError.NoError : DatabaseError.FileInsert;
                    int id = Database.GetLastRowIDInserted("File");
                    if (fileError == DatabaseError.FileInsert)
                        return fileError;
                    AddFileId(id);
                }
                else //we are updating a file
                {
                    fileError = Database.UpdateFile(file) ? DatabaseError.NoError : DatabaseError.FileUpdate;
                    if (fileError == DatabaseError.FileUpdate)
                        return fileError;
                }
            }

            return Database.UpdateSurvey(this) ? DatabaseError.NoError : DatabaseError.SurveyInsert;
        }
    }
}
