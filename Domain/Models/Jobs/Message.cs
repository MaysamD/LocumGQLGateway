using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocumApp.Domain.Models.Jobs;

/// <summary>
/// Represents a message exchanged between a candidate and a job poster.
/// </summary>
[Table("messages")]
public class Message : BaseEntity
{
    /// <summary>
    /// Gets or sets the job this message is related to.
    /// Required for both pre- and post-application conversations.
    /// </summary>
    [Required]
    [Column("job_id")]
    public int JobId { get; set; }

    public virtual Job Job { get; set; } = null!;

    /// <summary>
    /// Gets or sets the optional job application this message is tied to.
    /// Null if the user has not applied yet.
    /// </summary>
    [Column("job_application_id")]
    public int? JobApplicationId { get; set; }

    public virtual JobApplication? JobApplication { get; set; }

    /// <summary>
    /// Gets or sets the ID of the sender (candidate or poster).
    /// </summary>
    [Required]
    [Column("sender_user_id")]
    public int SenderUserId { get; set; }

    public virtual User Sender { get; set; } = null!;

    /// <summary>
    /// Gets or sets the ID of the recipient.
    /// </summary>
    [Required]
    [Column("recipient_user_id")]
    public int RecipientUserId { get; set; }

    public virtual User Recipient { get; set; } = null!;

    /// <summary>
    /// Reference to the message this is replying to.
    /// </summary>
    [Column("reply_to_message_id")]
    public int? ReplyToMessageId { get; set; }
    public virtual Message? ReplyTo { get; set; }
    
    /// <summary>
    /// Gets or sets the content of the message.
    /// </summary>
    [Required]
    [Column("content", TypeName = "nvarchar(max)")]
    public string Content { get; set; } = string.Empty;

     /// <summary>
    /// Gets or sets whether the recipient has read the message.
    /// </summary>
    [Column("is_read")]
    public bool IsRead { get; set; } = false;
     
    /// <summary>
    /// Gets or sets the collection of historical versions of this message.
    /// Each entry represents the content of the message before it was edited,
    /// allowing auditing and tracking of changes over time.
    /// </summary>
    public virtual ICollection<MessageHistory> History { get; set; } = new List<MessageHistory>();

}