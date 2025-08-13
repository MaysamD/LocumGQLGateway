using System.ComponentModel.DataAnnotations;

namespace LocumGQLGateway.Models.Profiles
{
    /// <summary>
    /// Represents a type of job or role, such as Nurse, Physician, or Technician.
    /// </summary>
    public class JobType : BaseEntity
    {
        /// <summary>
        /// The name of the job type.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        
        /// <summary>
        /// Optional description providing more details about the Job type.
        /// </summary>
        [MaxLength(250)]
        public string? Description { get; set; }
    }
}