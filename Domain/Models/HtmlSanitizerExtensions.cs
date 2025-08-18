using Ganss.Xss;

namespace LocumApp.Domain.Models;

public static class HtmlSanitizerExtensions
{
    /// <summary>
    /// Creates a configured instance of HtmlSanitizer with allowed tags and attributes.
    /// </summary>
    public static HtmlSanitizer CreateConfiguredSanitizer()
    {
        var sanitizer = new HtmlSanitizer();

        // Allowed tags
        sanitizer.AllowedTags.Add("p");
        sanitizer.AllowedTags.Add("b");
        sanitizer.AllowedTags.Add("i");
        sanitizer.AllowedTags.Add("u");
        sanitizer.AllowedTags.Add("a");
        sanitizer.AllowedTags.Add("ul");
        sanitizer.AllowedTags.Add("ol");
        sanitizer.AllowedTags.Add("li");
        sanitizer.AllowedTags.Add("br");

        // Allowed attributes
        sanitizer.AllowedAttributes.Add("href");
        sanitizer.AllowedAttributes.Add("style");

        return sanitizer;
    }

    /// <summary>
    /// Sanitizes the input HTML string using the configured sanitizer.
    /// </summary>
    public static string SanitizeHtml(this string html)
    {
        var sanitizer = CreateConfiguredSanitizer();
        return sanitizer.Sanitize(html ?? string.Empty);
    }
}