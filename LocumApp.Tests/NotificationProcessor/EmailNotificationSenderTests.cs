using System.Text.Json;
using LocumApp.Domain.Models.Notifications;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NotificationProcessor.Models;
using NotificationProcessor.Services.Implementations;

namespace LocumApp.Tests.NotificationProcessor;

public class EmailNotificationSenderTests
{
    private readonly Mock<ILogger<EmailNotificationSender>> _loggerMock;
    private readonly EmailSettings _emailSettings;

    public EmailNotificationSenderTests()
    {
        _loggerMock = new Mock<ILogger<EmailNotificationSender>>();
        _emailSettings = new EmailSettings
        {
            SmtpHost = "smtp.test.com",
            SmtpPort = 587,
            SenderEmail = "test@test.com",
            Password = "password",
            SenderName = "Test Sender"
        };
    }

    private EmailNotificationSender CreateService()
    {
        return new EmailNotificationSender(
            _loggerMock.Object,
            Options.Create(_emailSettings)
        );
    }

    [Fact]
    public async Task SendAsync_ShouldThrow_WhenRecipientMissing()
    {
        var sender = CreateService();
        var notification = new Notification
        {
            Title = "Hello",
            Message = "World"
        };

        await Assert.ThrowsAsync<ArgumentNullException>(() => sender.SendAsync(notification));
    }

    [Fact]
    public async Task SendAsync_ShouldThrow_WhenInvalidEmail()
    {
        var sender = CreateService();
        var notification = new Notification
        {
            EmailRecipient = "invalid-email",
            Title = "Test",
            Message = "Message"
        };

        await Assert.ThrowsAsync<ArgumentException>(() => sender.SendAsync(notification));
    }

    [Fact]
    public void ReplaceTemplateVariables_ShouldReplaceValues()
    {
        var sender = CreateService();
        var template = "Hello {{Name}}, welcome to {{Company}}!";
        var metadata = JsonSerializer.Serialize(new { Name = "Maysam", Company = "Locum" });

        var result = sender.ReplaceTemplateVariables(template, metadata);

        Assert.Contains("Maysam", result);
        Assert.Contains("Locum", result);
    }

    [Fact]
    public void ReplaceTemplateVariables_ShouldReturnOriginal_WhenNoMetadata()
    {
        var sender = CreateService();
        var template = "Hello {{Name}}";

        var result = sender.ReplaceTemplateVariables(template, "{}");

        Assert.Equal("Hello {{Name}}", result);
    }

    [Fact]
    public void BuildEmailBody_ShouldReturnHtml_WhenHtmlBodyProvided()
    {
        var sender = CreateService();
        var notification = new Notification
        {
            EmailRecipient = "user@test.com",
            Title = "Test",
            HtmlBody = "<h1>HTML Content</h1>"
        };

        var body = sender
            .GetType()
            .GetMethod("BuildEmailBody", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
            .Invoke(sender, new object[] { notification, false }) as string;

        Assert.Equal("<h1>HTML Content</h1>", body);
    }

    [Fact]
    public void BuildEmailBody_ShouldReturnPlainMessage_WhenMessageProvided()
    {
        var sender = CreateService();
        var notification = new Notification
        {
            EmailRecipient = "user@test.com",
            Title = "Test",
            Message = "Plain text message"
        };

        var body = sender
            .GetType()
            .GetMethod("BuildEmailBody", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
            .Invoke(sender, new object[] { notification, false }) as string;

        Assert.Equal("Plain text message", body);
    }
}