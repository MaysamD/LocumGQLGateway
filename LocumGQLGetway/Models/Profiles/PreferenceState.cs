namespace LocumGQLGateway.Models.Profiles
{
    /// <summary>
    ///     Represents the relationship between a user's preference and a State.
    ///     This serves as a join entity in a many-to-many relationship between
    ///     <see cref="Preference"/> and <see cref="State"/>.
    /// </summary>
    public class PreferenceState
    {
        /// <summary>
        ///     Gets or sets the identifier of the associated State.
        /// </summary>
        public int StateId { get; set; }

        /// <summary>
        ///     Gets or sets the identifier of the associated preference.
        /// </summary>
        public int PreferenceId { get; set; }
    }
}