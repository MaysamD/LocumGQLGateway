namespace LocumGQLGateway.Enums
{
    /// <summary>
    /// Enumerates the possible data types for questions in the system.
    /// </summary>
    public enum QuestionDataType
    {
        /// <summary>
        /// A free-text string response.
        /// </summary>
        Text,

        /// <summary>
        /// A numeric response.
        /// </summary>
        Number,

        /// <summary>
        /// A date response.
        /// </summary>
        Date,

        /// <summary>
        /// A boolean (true/false) response.
        /// </summary>
        Boolean,

        /// <summary>
        /// A multiple-choice selection.
        /// </summary>
        MultipleChoice

        // Add more data types as needed.
    }
}