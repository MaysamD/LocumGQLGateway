using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocumApp.Domain.Models.Jobs;

public class MessageHistory : BaseEntity
{
    /// <summary>
    /// Gets or sets the ID of the original <see cref="Message"/> this history entry belongs to.
    /// </summary>
    [Required]
    [Column("message_id")]
    public int MessageId { get; set; }
    
    /// <summary>
    /// Navigation property to the original <see cref="Message"/>.
    /// </summary>
    public virtual Message Message { get; set; } = null!;

    /// <summary>
    /// Gets or sets the content of the message at the time this history entry was created.
    /// </summary>
    [Required]
    [Column("content", TypeName = "nvarchar(max)")]
    public string Content { get; set; } = string.Empty;
    
    /// <summary>
    /// Optional: Gets or sets the ID of the user who made the edit.
    /// Helps track who modified the message.
    /// </summary>
    [Column("edited_by_user_id")]
    public int? EditedByUserId { get; set; }

    /// <summary>
    /// Optional: Navigation property for the user who edited the message.
    /// </summary>
    public virtual User? EditedBy { get; set; }
}