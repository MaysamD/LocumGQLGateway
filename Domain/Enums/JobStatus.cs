namespace LocumApp.Domain.Enums;

    /// <summary>
    /// Represents the current status of a job posting.
    /// </summary>
    public enum JobStatus
    {
        /// <summary>
        /// The job is open and accepting applications.
        /// </summary>
        Open = 0,

        /// <summary>
        /// The job is pending approval or pending scheduling.
        /// </summary>
        Pending = 1,

        /// <summary>
        /// The job has been filled and is no longer accepting applications.
        /// </summary>
        Filled = 2,

        /// <summary>
        /// The job posting has been closed by the poster or administrator.
        /// </summary>
        Closed = 3,

        /// <summary>
        /// The job posting has been cancelled before being filled.
        /// </summary>
        Cancelled = 4,

        /// <summary>
        /// The job is temporarily on hold, e.g., due to facility or staffing issues.
        /// </summary>
        OnHold = 5,

        /// <summary>
        /// The job posting has expired and is no longer active.
        /// </summary>
        Expired = 6
    }
