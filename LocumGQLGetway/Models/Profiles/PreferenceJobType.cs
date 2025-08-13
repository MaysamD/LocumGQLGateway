namespace LocumGQLGateway.Models.Profiles
{
    /// <summary>
    ///     Represents the association between a user's preference and a job type.
    ///     Serves as a join entity in a many-to-many relationship between
    ///     <see cref="Preference"/> and <see cref="JobType"/>.
    /// </summary>
    public class PreferenceJobType
    {
        /// <summary>
        ///     Gets or sets the identifier of the associated preference.
        /// </summary>
        public int PreferenceId { get; set; }

        /// <summary>
        ///     Gets or sets the identifier of the associated job type.
        /// </summary>
        public int JobTypeId { get; set; }
    }
}