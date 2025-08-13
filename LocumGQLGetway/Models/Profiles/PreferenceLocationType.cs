namespace LocumGQLGateway.Models.Profiles
{
    /// <summary>
    ///     Represents the relationship between a user's preference and a location type.
    ///     This serves as a join entity in a many-to-many relationship between
    ///     <see cref="Preference"/> and <see cref="LocationType"/>.
    /// </summary>
    public class PreferenceLocationType
    {
        /// <summary>
        ///     Gets or sets the identifier of the associated location type.
        /// </summary>
        public int LocationTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the identifier of the associated preference.
        /// </summary>
        public int PreferenceId { get; set; }
    }
}