namespace LocumApp.Domain.Enums
{
    /// <summary>
    ///     Defines the author of a note associated with a job application.
    /// </summary>
    public enum NoteAuthorType
    {
        /// <summary>
        ///     The note was created by the candidate (applicant) themselves.
        /// </summary>
        Candidate = 0,

        /// <summary>
        ///     The note was created by the job poster or recruiter/facility.
        /// </summary>
        Poster = 1,

        /// <summary>
        ///     The note was created by the credentialing team or compliance staff.
        /// </summary>
        CredentialingTeam = 2
    }
}