using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocumApp.Domain.Models.Credentials;

public class CategoryQuestion
{
    [Column("id")] public int Id { get; set; }

    [Column("form_id")] [Required] public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    [Column("question_id")] [Required] public int QuestionId { get; set; }

    public Question Question { get; set; } = null!;

    [Column("sort_order")] public int? SortOrder { get; set; } = 0;
}