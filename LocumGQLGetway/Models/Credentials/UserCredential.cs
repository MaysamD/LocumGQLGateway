using LocumGQLGateway.Enums;

namespace LocumGQLGateway.Models.Credentials;

/// <summary>
///     Represents a user-provided credential, answer, or document used for verification or onboarding.
/// </summary>
public class UserCredential : BaseEntity
{
    /// <summary>
    ///     The related question this credential answers.
    /// </summary>
    public int QuestionId { get; set; }

    /// <summary>
    ///     Navigation property for the related question.
    /// </summary>
    public Question Question { get; set; } = null!;

    /// <summary>
    ///     The answer text provided by the user (if applicable).
    /// </summary>
    public string? AnswerText { get; set; }

    /// <summary>
    ///     The ID of the selected option (if the question was multiple-choice).
    /// </summary>
    public int? SelectedOptionId { get; set; }

    /// <summary>
    ///     Navigation property for the selected question option.
    /// </summary>
    public QuestionOption? SelectedOption { get; set; }

    /// <summary>
    ///     Indicates whether the credential has been validated.
    /// </summary>
    public bool? IsValidated { get; set; }

    /// <summary>
    ///     The method used to validate the credential.
    ///     Defaults to <see cref="Enums.ValidationMethod.NotValidated" />.
    /// </summary>
    public ValidationMethod ValidationMethod { get; set; } = ValidationMethod.NotValidated;

    /// <summary>
    ///     The date and time (UTC) when the credential was validated.
    ///     Null if not yet validated.
    /// </summary>
    public DateTime? ValidatedAtUtc { get; set; }

    /// <summary>
    ///     The ID of the user who validated the credential.
    /// </summary>
    public int? ValidatedById { get; set; }

    /// <summary>
    ///     Navigation property for the user who validated this credential.
    /// </summary>
    public User? ValidatedBy { get; set; }

    /// <summary>
    ///     Optional notes or comments from the validator (e.g., reason for rejection or additional info).
    /// </summary>
    public string? ValidationNotes { get; set; }

    /// <summary>
    ///     When this credential expires (e.g., license, certification).
    ///     Null if it never expires.
    /// </summary>
    public DateTime? ExpirationDateUtc { get; set; }

    /// <summary>
    ///     File path or URL to a supporting document, if applicable.
    /// </summary>
    public string? DocumentUrl { get; set; }
}