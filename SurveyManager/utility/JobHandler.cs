using SurveyManager.backend;
using SurveyManager.backend.wrappers;
using SurveyManager.forms.dialogs;
using SurveyManager.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static SurveyManager.utility.CEventArgs;
using static SurveyManager.utility.Enums;

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

        private bool _savePending = false;

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

        public bool UpdateSavePending(bool isSavePending)
        {
            _savePending = IsJobOpen ? isSavePending : false;
            return SavePending;
        }

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

            _jobState = Open(s);
            switch (_jobState)
            {
                case JobState.SavePending:
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
                            OpenJob(s);
                            break;
                        }
                        case ExitChoice.ExitNoSave:
                        {
                            isClosing = true;
                            Close();
                            OpenJob(s);
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
                    break;
                }
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

        public bool OpenJob(string jobNumber)
        {
            if (IsJobOpen && jobNumber.Equals(CurrentJob.JobNumber))
            {
                StatusUpdate?.Invoke(this, new StatusArgs($"Job# {CurrentJob.JobNumber} is already opened. Ignoring re-open command."));
                _jobState = JobState.DuplicateJobNumber;
                return false;
            }

            if (IsJobOpen && SavePending)
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
                        OpenJob(jobNumber);
                        break;
                    }
                    case ExitChoice.ExitNoSave:
                    {
                        isClosing = true;
                        Close();
                        OpenJob(jobNumber);
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

            JobOpened?.Invoke(this, new StatusArgs($"Job# {jobNumber} opened successfully."));
            return JobState.Opened;
        }

        private JobState Open(Survey s)
        {
            if (IsJobOpen && SavePending)
                return JobState.SavePending;

            JobOpening?.Invoke(this, new StatusArgs($"Opening Job# {s.JobNumber}. Please wait..."));
            if (s == null)
                return JobState.InvalidJob;
            CurrentJob = s;

            JobOpened?.Invoke(this, new StatusArgs($"Job# {s.JobNumber} opened successfully."));
            return JobState.Opened;
        }

        public bool CreateJob(string jobNumber)
        {
            _jobState = Create(jobNumber);
            switch (_jobState)
            {
                case JobState.SavePending:
                {
                    ExitChoice choice = CMessageBox.ShowExitDialog("There are unsaved changes to the currently opened job. What would you like to do?",
                    "Confirm", System.Windows.Forms.MessageBoxButtons.OKCancel, Resources.warning_64x64, true);
                    switch (choice)
                    {
                        case ExitChoice.SaveAndExit:
                        {
                            isClosing = true;
                            Save();
                            CreateJob(jobNumber);
                            break;
                        }
                        case ExitChoice.ExitNoSave:
                        {
                            isClosing = true;
                            Close();
                            CreateJob(jobNumber);
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
                    break;
                }
                case JobState.DuplicateJobNumber:
                {
                    StatusUpdate?.Invoke(this, new StatusArgs($"Job# {jobNumber} already exists. Try opening it instead."));
                    _jobState = JobState.DuplicateJobNumber;
                    return false; 
                }
            }

            if (CurrentJob != null)
                _jobState = JobState.Opened;

            return true;
        }

        private JobState Create(string jobNumber)
        {
            if (IsJobOpen && SavePending)
                return JobState.SavePending;

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

        public bool SaveJob(bool addToRecents = true)
        {
            if (!IsJobOpen)
            {
                StatusUpdate?.Invoke(this, new StatusArgs("There is no job currently opened, therefore there is nothing to save."));
                _jobState = JobState.NoJobOpened;
                return false;
            }

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

            if (addToRecents)
            {
                AddSurveyToRecentJobs();
            }

            return true;
        }

        DatabaseError saveError = DatabaseError.NoError;
        private JobState Save()
        {
            _jobState = JobState.Saving;
            JobSaving?.Invoke(this, new StatusArgs($"Saving Job# {CurrentJob.JobNumber} to the database. Please wait..."));
            lastJobNumber = CurrentJob.JobNumber;

            if (CurrentJob != null && !CurrentJob.IsValidSurvey)
                return JobState.InvalidJob;

            //start saving the job on a background thread
            saveBackgroundWorker.RunWorkerAsync();

            return _jobState;
        }

        private void SaveBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
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
            if (_jobState != JobState.SaveError && isClosing)
            {
                JobSaved?.Invoke(this, new StatusArgs($"Job# {lastJobNumber} saved to the database successfully."));
                Close();
            }
            else
            {
                JobSaved?.Invoke(this, new StatusArgs($"Job# {lastJobNumber} saved to the database successfully."));
            }
        }

        public bool CloseJob(bool isOpeningOtherJob = false)
        {
            if (IsJobOpen && SavePending)
            {
                ExitChoice choice = CMessageBox.ShowExitDialog("There are unsaved changes to the currently opened job. What would you like to do?",
                    "Confirm", System.Windows.Forms.MessageBoxButtons.OKCancel, Resources.warning_64x64, true, isOpeningOtherJob);
                switch (choice)
                {
                    case ExitChoice.SaveAndExit:
                    {
                        isClosing = true;
                        Save();
                        break;
                    }
                    case ExitChoice.ExitNoSave:
                    {
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

        public void AddSurveyToRecentJobs()
        {
            if (!Settings.Default.RecentJobs.Contains(CurrentJob.JobNumber))
            {
                Settings.Default.RecentJobs.Add(CurrentJob.JobNumber);
                Settings.Default.Save();

                RuntimeVars.Instance.MainForm.UpdateRecentDocs();
            }
        }
    }
}
