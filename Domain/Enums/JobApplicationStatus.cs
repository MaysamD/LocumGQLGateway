namespace LocumApp.Domain.Enums;

/// <summary>
///     Represents the lifecycle status of a job application within the system.
/// </summary>
public enum JobApplicationStatus
{
    /// <summary>
    ///     The application has been submitted by the candidate and is awaiting review.
    /// </summary>
    Submitted = 0,

    /// <summary>
    ///     The application is currently under review by the job poster or credentialing team.
    /// </summary>
    UnderReview = 1,

    /// <summary>
    ///     The candidate has been shortlisted for further steps.
    /// </summary>
    Shortlisted = 2,

    /// <summary>
    ///     The candidate has been interviewed (in person, virtual, or phone).
    /// </summary>
    Interviewed = 3,

    /// <summary>
    ///     The candidate has been offered the job.
    /// </summary>
    Offered = 4,

    /// <summary>
    ///     The candidate has accepted the job offer.
    /// </summary>
    Accepted = 5,

    /// <summary>
    ///     The candidate has declined the job offer.
    /// </summary>
    Declined = 6,

    /// <summary>
    ///     The application has been rejected by the job poster or credentialing team.
    /// </summary>
    Rejected = 7,

    /// <summary>
    ///     The application has been withdrawn by the candidate.
    /// </summary>
    Withdrawn = 8,

    /// <summary>
    ///     The candidate is currently onboarding or credentialing is in progress.
    /// </summary>
    CredentialingInProgress = 9,

    /// <summary>
    ///     The candidate has successfully completed onboarding and credentialing.
    /// </summary>
    Hired = 10
}