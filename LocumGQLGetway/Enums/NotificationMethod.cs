namespace LocumGQLGateway.Enums
{
    /// <summary>
    /// Defines the available methods for delivering notifications to users.
    /// </summary>
    public enum NotificationMethod
    {
        /// <summary>
        /// Notification delivered via Email.
        /// </summary>
        Email = 1,

        /// <summary>
        /// Notification delivered via SMS (text message).
        /// </summary>
        SMS = 2,

        /// <summary>
        /// Notification delivered via In-App messaging.
        /// </summary>
        InApp = 3
    }
}