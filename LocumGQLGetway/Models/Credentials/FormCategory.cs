using System.ComponentModel.DataAnnotations;

namespace LocumGQLGateway.Models.Credentials;

public class FormCategory
{
    public int Id { get; set; }

    [Required] public int FormId { get; set; }

    public Form Form { get; set; } = null!;

    [Required] public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;

    public bool IncludeAllQuestions { get; set; } = true;
    public int SortOrder { get; set; }
}