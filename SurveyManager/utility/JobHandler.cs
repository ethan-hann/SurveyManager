using SurveyManager.backend;
using SurveyManager.backend.wrappers.SurveyJob;
using SurveyManager.forms.dialogs;
using SurveyManager.Properties;
using System;
using System.ComponentModel;
using System.Collections;
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;
using System.Collections.Generic;

namespace SurveyManager.utility
{
    /// <summary>
    /// This class handles all tasks relating to survey jobs. It is responsible for opening, closing, keeping track
    /// of the current job, saving, and updating the recent docs for surveys.
    /// 
    /// <para>This class cannot be instantiated. Instead, it must be referenced through its single <see cref="Instance"/> property.</para>
    /// </summary>
    public class JobHandler
    {
        private static JobHandler instance = null;
        private static readonly object padlock = new object();
        private BackgroundWorker saveBackgroundWorker = new BackgroundWorker();
        private bool isClosing = false;
        private string lastJobNumber = "";

        public static JobHandler Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                        instance = new JobHandler();
                    return instance;
                }
            }
        }

        private JobHandler()
        {
            saveBackgroundWorker.DoWork += SaveBackgroundWorker_DoWork;
            saveBackgroundWorker.RunWorkerCompleted += SaveBackgroundWorker_RunWorkerCompleted;
        }

        /// <summary>
        /// Occurs when a survey job is being opened.
        /// </summary>
        public EventHandler JobOpening;
        /// <summary>
        /// Occurs when a survey job is being closed.
        /// </summary>
        public EventHandler JobClosing;
        /// <summary>
        /// Occurs after a survey job has been successfully opened.
        /// </summary>
        public EventHandler JobOpened;
        /// <summary>
        /// Occurs after a survey job has been successfully closed.
        /// </summary>
        public EventHandler JobClosed;
        /// <summary>
        /// Occurs when a survey job is being saved.
        /// </summary>
        public EventHandler JobSaving;
        /// <summary>
        /// Occurs after a survey job has been successfully saved.
        /// </summary>
        public EventHandler JobSaved;
        /// <summary>
        /// Occurs when a new survey job is being created.
        /// </summary>
        public EventHandler JobCreating;
        /// <summary>
        /// Occurs after a new survey job has been created successfully.
        /// </summary>
        public EventHandler JobCreated;

        /// <summary>
        /// Occurs when the status of the main form needs to be updated.
        /// </summary>
        public EventHandler StatusUpdate;

        /// <summary>
        /// Get the currently opened survey job. If no job is open, returns null. It is recommended to use <see cref="IsJobOpen"/> to
        /// make sure there is actually a job opened.
        /// </summary>
        public Survey CurrentJob { get; private set; } = null;

        /// <summary>
        /// Get the missing information for the current survey job as a list of strings.
        /// <para>If there is no job opened, the list contains a single item: <c>NO JOB OPENED</c>.</para>
        /// <para>If the current job is valid, the returned list will be empty (i.e. Count == 0).</para>
        /// </summary>
        public List<string> MissingInformation
        {
            get
            {
                List<string> info = new List<string>();
                if (!IsJobOpen)
                {
                    info.Add("NO JOB OPENED");
                    return info;
                }

                if (CurrentJob.Client == null || !CurrentJob.Client.IsValidClient)
                    info.Add("Client");

                if (CurrentJob.County == null || !CurrentJob.County.IsValidCounty)
                    info.Add("County");

                if (CurrentJob.JobNumber == null || CurrentJob.JobNumber.ToLower().Equals("n/a"))
                    info.Add("Job Number");

                if (CurrentJob.Description == null || CurrentJob.Description.ToLower().Equals("n/a"))
                    info.Add("Description");

                if (CurrentJob.AbstractNumber == null || CurrentJob.AbstractNumber.ToLower().Equals("n/a"))
                    info.Add("Abstract Number");

                if (CurrentJob.Location == null || CurrentJob.Location.IsEmpty)
                    info.Add("Location");

                return info;
            }
        }

        private bool _savePending = false;

        /// <summary>
        /// Get a value indicating if the current job needs saving because of modification.
        /// </summary>
        public bool SavePending
        {
            get
            {
                return IsJobOpen ? _savePending : false;
            }
        }

        /// <summary>
        /// Get a value indicating if a job is currently opened.
        /// </summary>
        public bool IsJobOpen
        {
            get
            {
                return CurrentJob != null;
            }
        }

        /// <summary>
        /// Get or set whether this job should be considered read-only and therefore non-editable.
        /// </summary>
        public bool ReadOnly { get; set; } = false;

        private JobState _jobState = JobState.None;

        /// <summary>
        /// Get a <see cref="JobState"/> enum value representing the current state of the job handler.
        /// </summary>
        public JobState CurrentJobState
        {
            get
            {
                return _jobState;
            }
        }

        /// <summary>
        /// Update whether there is a save pending on the current job.
        /// <para>Has no effect if the job is opened as Read-Only.</para>
        /// </summary>
        /// <param name="isSavePending">True if a save is pending; False otherwise.</param>
        /// <returns>The new value for <see cref="SavePending"/></returns>
        public bool UpdateSavePending(bool isSavePending)
        {
            _savePending = IsJobOpen && !ReadOnly ? isSavePending : false;
            return SavePending;
        }

        /// <summary>
        /// Open an existing survey job for editing.
        /// <para>This method affects the <see cref="CurrentJobState"/> property and Invokes the <see cref="StatusUpdate"/> event.</para>
        /// </summary>
        /// <param name="s">The <see cref="Survey"/> to open.</param>
        /// <returns>True if the job was opened successfully; False otherwise.</returns>
        public bool OpenJob(Survey s)
        {
            if (IsJobOpen)
            {
                if (s.JobNumber.Equals(CurrentJob.JobNumber))
                {
                    StatusUpdate?.Invoke(this, new StatusArgs($"Job# {CurrentJob.JobNumber} is already opened. Ignoring re-open command."));
                    _jobState = JobState.DuplicateJobNumber;
                    return false;
                }
            }

            if (IsJobOpen && SavePending && !ReadOnly)
            {
                ExitChoice choice = CMessageBox.ShowExitDialog("There are unsaved changes to the currently opened job. What would you like to do?",
                    "Confirm", System.Windows.Forms.MessageBoxButtons.OKCancel, Resources.warning_64x64, true);
                switch (choice)
                {
                    case ExitChoice.SaveAndExit:
                    {
                        isClosing = true;
                        Save();
                        Close();
                        break;
                    }
                    case ExitChoice.ExitNoSave:
                    {
                        isClosing = true;
                        Close();
                        break;
                    }
                    case ExitChoice.SaveOnly:
                    {
                        Save();
                        return false;
                    }
                    case ExitChoice.Cancel:
                    {
                        StatusUpdate?.Invoke(this, new StatusArgs("Opening of Job# " + s.JobNumber + " canceled."));
                        return false;
                    }
                }
            }

            _jobState = Open(s);
            switch (_jobState)
            {
                case JobState.OpenError:
                {
                    StatusUpdate?.Invoke(this, new StatusArgs("An error occured while trying to open Job#: " + s.JobNumber + ". Perhaps it doesn't actually exist."));
                    _jobState = JobState.OpenError;
                    return false;
                }
            }

            if (CurrentJob != null)
                _jobState = JobState.Opened;

            return CurrentJob != null;
        }

        /// <summary>
        /// Open an existing survey job for editing.
        /// <para>This method affects the <see cref="CurrentJobState"/> property and Invokes the <see cref="StatusUpdate"/> event.</para>
        /// </summary>
        /// <param name="jobNumber">The Job# of the survey job to open.</param>
        /// <returns>True if the job was opened successfully; False otherwise.</returns>
        public bool OpenJob(string jobNumber)
        {
            if (IsJobOpen && jobNumber.Equals(CurrentJob.JobNumber))
            {
                StatusUpdate?.Invoke(this, new StatusArgs($"Job# {CurrentJob.JobNumber} is already opened. Ignoring re-open command."));
                _jobState = JobState.DuplicateJobNumber;
                return false;
            }

            if (IsJobOpen && SavePending && !ReadOnly)
            {
                ExitChoice choice = CMessageBox.ShowExitDialog("There are unsaved changes to the currently opened job. What would you like to do?",
                    "Confirm", System.Windows.Forms.MessageBoxButtons.OKCancel, Resources.warning_64x64, true);
                switch (choice)
                {
                    case ExitChoice.SaveAndExit:
                    {
                        isClosing = true;
                        Save();
                        Close();
                        break;
                    }
                    case ExitChoice.ExitNoSave:
                    {
                        isClosing = true;
                        Close();
                        break;
                    }
                    case ExitChoice.SaveOnly:
                    {
                        Save();
                        return false;
                    }
                    case ExitChoice.Cancel:
                    {
                        StatusUpdate?.Invoke(this, new StatusArgs("Opening of Job# " + jobNumber + " canceled."));
                        return false;
                    }
                }
            }

            _jobState = Open(jobNumber);
            if (_jobState == JobState.OpenError)
            {
                StatusUpdate?.Invoke(this, new StatusArgs("An error occured while trying to open Job#: " + jobNumber + ". Perhaps it doesn't actually exist."));
                return false;
            }

            if (CurrentJob != null)
                _jobState = JobState.Opened;

            return CurrentJob != null;
        }

        private JobState Open(string jobNumber)
        {
            if (IsJobOpen)
            {
                _jobState = Close();
                if (_jobState != JobState.Closed)
                    return _jobState;
            }

            JobOpening?.Invoke(this, new StatusArgs($"Opening Job# {jobNumber}. Please wait..."));
            Survey s = Database.GetSurvey(jobNumber);

            if (s == null)
                return JobState.OpenError;
            CurrentJob = s;

            _jobState = JobState.Opened;

            JobOpened?.Invoke(this, new StatusArgs($"Job# {jobNumber} opened successfully."));
            return _jobState;
        }

        private JobState Open(Survey s)
        {
            if (IsJobOpen)
            {
                _jobState = Close();
                if (_jobState != JobState.Closed)
                    return _jobState;
            }

            JobOpening?.Invoke(this, new StatusArgs($"Opening Job# {s.JobNumber}. Please wait..."));
            if (s == null)
                return JobState.InvalidJob;
            CurrentJob = s;

            _jobState = JobState.Opened;

            JobOpened?.Invoke(this, new StatusArgs($"Job# {s.JobNumber} opened successfully."));
            return _jobState;
        }

        /// <summary>
        /// Create a new job and open it for editing.
        /// <para>This method affects the <see cref="CurrentJobState"/> property and Invokes the <see cref="StatusUpdate"/> event.</para>
        /// </summary>
        /// <param name="jobNumber">The Job# of the survey job to create.</param>
        /// <returns>True if the job was created successfully; False otherwise.</returns>
        public bool CreateJob(string jobNumber)
        {
            if (IsJobOpen && SavePending && !ReadOnly)
            {
                ExitChoice choice = CMessageBox.ShowExitDialog("There are unsaved changes to the currently opened job. What would you like to do?",
                    "Confirm", System.Windows.Forms.MessageBoxButtons.OKCancel, Resources.warning_64x64, true);
                switch (choice)
                {
                    case ExitChoice.SaveAndExit:
                    {
                        isClosing = false;
                        Save();
                        break;
                    }
                    case ExitChoice.ExitNoSave:
                    {
                        isClosing = true;
                        Close();
                        break;
                    }
                    case ExitChoice.SaveOnly:
                    {
                        Save();
                        return false;
                    }
                    case ExitChoice.Cancel:
                    {
                        StatusUpdate?.Invoke(this, new StatusArgs("Creation of Job# " + jobNumber + " canceled."));
                        _jobState = JobState.CreateCancelled;
                        return false;
                    }
                }
            }

            _jobState = Create(jobNumber);
            if (_jobState == JobState.DuplicateJobNumber)
            {
                StatusUpdate?.Invoke(this, new StatusArgs($"Job# {jobNumber} already exists. Try opening it instead."));
                _jobState = JobState.DuplicateJobNumber;
                return false;
            }

            if (CurrentJob != null)
                _jobState = JobState.Opened;

            return true;
        }

        private JobState Create(string jobNumber)
        {
            JobCreating?.Invoke(this, new StatusArgs($"Creating Job# {jobNumber}. Please wait..."));

            if (!Database.DoesSurveyExist(jobNumber))
            {
                CurrentJob = new Survey()
                {
                    JobNumber = jobNumber
                };

                JobOpened?.Invoke(this, new StatusArgs($"Job # {jobNumber} created and opened successfully."));
                UpdateSavePending(true);
                return JobState.Opened;
            }
            else
            {
                return JobState.DuplicateJobNumber;
            }
        }

        /// <summary>
        /// Save the job to the database on a seperate thread if it is open and not in a Read-Only state.
        /// <para>This method affects the <see cref="CurrentJobState"/> property and Invokes the <see cref="StatusUpdate"/> event.</para>
        /// </summary>
        /// <returns>True if the job was saved successfully; False otherwise.</returns>
        public bool SaveJob()
        {
            if (ReadOnly && IsJobOpen)
            {
                StatusUpdate?.Invoke(this, new StatusArgs($"Job# {CurrentJob.JobNumber} opened in READ-ONLY mode. Cannot save to database."));
                _jobState = JobState.ReadOnly;
                return false;
            }

            if (!IsJobOpen)
            {
                StatusUpdate?.Invoke(this, new StatusArgs("There is no job currently opened, therefore there is nothing to save."));
                _jobState = JobState.NoJobOpened;
                return false;
            }

            if (_jobState == JobState.Saving)
                return false;

            _jobState = Save();
            switch (_jobState)
            {
                case JobState.InvalidJob:
                {
                    StatusUpdate?.Invoke(this, new StatusArgs($"Job# {CurrentJob.JobNumber} is missing required information. Please add more information to the job and try saving it again."));
                    _jobState = JobState.InvalidJob;
                    return false;
                }
                case JobState.Saved:
                {
                    StatusUpdate?.Invoke(this, new StatusArgs($"Job# {CurrentJob.JobNumber} saved successfully!"));
                    _jobState = JobState.Saved;
                    break;
                }
                case JobState.SaveError:
                {
                    StatusUpdate?.Invoke(this, new StatusArgs(saveError.ToDescriptionString()));
                    _jobState = JobState.SaveError;
                    return false;
                }
            }

            return true;
        }

        DatabaseError saveError = DatabaseError.NoError;
        private JobState Save()
        {
            if (CurrentJob == null || !CurrentJob.IsValidSurvey)
                return JobState.InvalidJob;

            _jobState = JobState.Saving;
            JobSaving?.Invoke(this, new StatusArgs($"Saving Job# {CurrentJob.JobNumber} to the database. Please wait..."));
            lastJobNumber = CurrentJob.JobNumber;

            //start saving the job on a background thread
            saveBackgroundWorker.RunWorkerAsync();

            return _jobState;
        }

        private void SaveBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            CurrentJob.LastUpdated = DateTime.Now;
            if (CurrentJob.ID == 0)
                saveError = CurrentJob.Insert();
            else
                saveError = CurrentJob.Update();

            if (saveError == DatabaseError.NoError)
            {
                _jobState = JobState.Saved;
            }
            else
            {
                _jobState = JobState.SaveError;
            }
        }

        private void SaveBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_jobState == JobState.SaveError)
            {
                JobSaved?.Invoke(this, new StatusArgs($"Job# {lastJobNumber} could not be saved to the database."));
                _savePending = true;
                return;
            }

            if (isClosing)
            {
                JobSaved?.Invoke(this, new StatusArgs($"Job# {lastJobNumber} saved to the database successfully."));
                _savePending = false;
                AddSurveyToRecentJobs();
                Close();
            }
            else
            {
                AddSurveyToRecentJobs();
                _savePending = false;
                JobSaved?.Invoke(this, new StatusArgs($"Job# {lastJobNumber} saved to the database successfully."));
                return;
            }
        }

        /// <summary>
        /// Close the currently open job.
        /// <para>This method affects the <see cref="CurrentJobState"/> property and Invokes the <see cref="StatusUpdate"/> event.</para>
        /// </summary>
        /// <param name="isClosingApplication">Whether the main application is exiting.</param>
        /// <param name="isOpeningOtherJob">Whether another survey job is pending opening.</param>
        /// <returns>True if the job was closed successfully; False otherwise.</returns>
        public bool CloseJob(bool isClosingApplication = false, bool isOpeningOtherJob = false, bool showDialog = true)
        {
            if (IsJobOpen && SavePending && !ReadOnly)
            {
                if (isClosingApplication)
                {
                    _jobState = Close();
                }
                else
                {
                    if (showDialog)
                    {
                        ExitChoice choice = CMessageBox.ShowExitDialog("There are unsaved changes to the currently opened job. What would you like to do?",
                    "Confirm", System.Windows.Forms.MessageBoxButtons.OKCancel, Resources.warning_64x64, true, isOpeningOtherJob);
                        switch (choice)
                        {
                            case ExitChoice.SaveAndExit:
                            {
                                if (CurrentJob.IsValidSurvey)
                                {
                                    isClosing = true;
                                    Save();
                                    break;
                                }
                                else
                                {
                                    isClosing = true;
                                    StatusUpdate?.Invoke(this, new StatusArgs("Job is missing information. Can not save to database; Closing instead..."));
                                    Close();
                                    break;
                                }
                            }
                            case ExitChoice.ExitNoSave:
                            {
                                Close();
                                break;
                            }
                            case ExitChoice.SaveOnly:
                            {
                                if (CurrentJob.IsValidSurvey)
                                    Save();
                                else
                                    StatusUpdate?.Invoke(this, new StatusArgs("Job is missing information. Can not save to database."));
                                return false;
                            }
                            case ExitChoice.Cancel:
                            {
                                StatusUpdate?.Invoke(this, new StatusArgs("Closing of Job# " + CurrentJob.JobNumber + " canceled."));
                                _jobState = JobState.CloseCancelled;
                                return false;
                            }
                            default:
                                return false;
                        }
                    }
                    else
                    {
                        _jobState = Close();
                    }
                }
            }
            else
            {
                _jobState = Close();
            }

            return _jobState != JobState.CloseError;
        }

        private JobState Close()
        {
            if (!IsJobOpen)
                return JobState.NoJobOpened;

            string jobNumber = CurrentJob.JobNumber;
            JobClosing?.Invoke(this, new StatusArgs($"Closing Job# {jobNumber}. Please wait..."));
            CurrentJob = null;
            JobClosed?.Invoke(this, new StatusArgs($"Job# {jobNumber} closed successfully."));
            isClosing = false;

            return JobState.Closed;
        }

        /// <summary>
        /// Add the current survey job to <see cref="Settings.RecentJobs"/>.
        /// If the job is already present in the list of recent jobs, its <see cref="Survey.LastUpdated"/> is updated instead.
        /// </summary>
        public void AddSurveyToRecentJobs()
        {
            int index = -1;
            foreach (string str in Settings.Default.RecentJobs)
            {
                string[] parts = str.Split('\t');
                if (parts.Length != 2)
                    return;
                string jobNumber = parts[0];
                if (jobNumber.Equals(CurrentJob.JobNumber))
                {
                    index = Settings.Default.RecentJobs.IndexOf(str);
                    break;
                }
            }

            if (index != -1)
            {
                Settings.Default.RecentJobs[index] = $"{CurrentJob.JobNumber}\t{CurrentJob.LastUpdated}";
                Settings.Default.Save();
            }
            else
            {
                Settings.Default.RecentJobs.Add($"{CurrentJob.JobNumber}\t{CurrentJob.LastUpdated}");
                Settings.Default.Save();
            }

            RuntimeVars.Instance.MainForm.UpdateRecentDocs();
        }
    }
}
