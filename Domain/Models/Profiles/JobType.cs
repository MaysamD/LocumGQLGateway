using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocumApp.Domain.Models.Profiles;

/// <summary>
///     Represents a type of job or role, such as Nurse, Physician, or Technician.
/// </summary>
[Table("job_types")]
public class JobType : BaseEntity
{
    /// <summary>
    ///     The name of the job type.
    /// </summary>
    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    ///     Optional description providing more details about the Job type.
    /// </summary>
    [MaxLength(250)]
    [Column("description")]
    public string? Description { get; set; }
}