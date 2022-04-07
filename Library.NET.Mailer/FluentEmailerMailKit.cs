using FluentEmail.Core;
using FluentEmail.Core.Models;
using FluentEmail.MailKitSmtp;
using FluentEmail.Razor;

using Library.NET.Helpers;
using Library.NET.Mailer.Models;

using MailKit.Security;

namespace Library.NET.Mailer;

/// <summary>
/// Mailkit used to send emails
/// </summary>
/// <remarks>
/// Outside References: <see cref="MailKit.Security"/>, <see cref="FluentEmail.Core"/>, <see cref="FluentEmail.MailKitSmtp"/>, and <see cref="FluentEmail.Razor"/>
/// </remarks>
public class FluentEmailerMailKit : IEmailer
{
    public EmailOptionsModel EmailOptions { get; set; } = new();
    public SmtpClientOptions SmtpOptions { get; set; } = new();

    public FluentEmailerMailKit()
    {
    }

    public IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, IList<AddressModel> ccAddresses, IList<AddressModel> bccAddresses, AddressModel replyToAddress, string subject, string body, IList<FileInfo> attachments, string template, bool isBodyHTML, string server, int port, string user, string password, bool useSSL, bool requiresAuthentication, string preferredEncoding, bool usePickupDirectory, string mailPickupDirectory, SecureSocketOptions secureSocketOptions)
    {
        EmailOptions = new EmailOptionsModel()
        {
            FromAddress = fromAddress,
            ReplyToAddress = replyToAddress,
            ToAddresses = toAddresses,
            CcAddresses = ccAddresses,
            BccAddresses = bccAddresses,
            Attachments = attachments,
            Subject = subject,
            Body = body,
            Template = template,
            IsBodyHTML = isBodyHTML
        };

        SmtpOptions = new SmtpClientOptions()
        {
            Server = server,
            Port = port,
            User = user,
            Password = password,
            UseSsl = useSSL,
            RequiresAuthentication = requiresAuthentication,
            PreferredEncoding = preferredEncoding,
            UsePickupDirectory = usePickupDirectory,
            MailPickupDirectory = mailPickupDirectory,
            SocketOptions = secureSocketOptions
        };

        return this;
    }

    public SendResponse SendEmail() => CreateAndSendEmail("");

    public async Task<SendResponse> SendEmailAsync() => await CreateAndSendEmailAsync("");

    public SendResponse SendEmailWithTemplate<T>(T templateModel) => CreateAndSendEmail(templateModel);

    public async Task<SendResponse> SendEmailWithTemplateAsync<T>(T templateModel) => await CreateAndSendEmailAsync(templateModel);

    private SendResponse CreateAndSendEmail<T>(T templateModel)
    {
        IFluentEmail email = string.IsNullOrEmpty(EmailOptions.Template) ? GenerateEmail<object>(null) : GenerateEmail(templateModel);

        SendResponse result = email.Send();

        return result;
    }

    private async Task<SendResponse> CreateAndSendEmailAsync<T>(T templateModel)
    {
        IFluentEmail email = string.IsNullOrEmpty(EmailOptions.Template) ? GenerateEmail<object>(null) : GenerateEmail(templateModel);
        SendResponse result = new();
        try
        {
            result = await email.SendAsync();
        }
        catch (Exception ex)
        {
            List<string> messages = new() { ex.Message };
            messages.AddRange(result.ErrorMessages);
        }

        return result;
    }

    private IFluentEmail GenerateEmail<T>(T templateModel)
    {
        MailKitSender sender = new(new SmtpClientOptions
        {
            Server = SmtpOptions.Server,
            Port = SmtpOptions.Port,
            User = SmtpOptions.User,
            Password = SmtpOptions.Password,
            UseSsl = SmtpOptions.UseSsl,
            RequiresAuthentication = SmtpOptions.RequiresAuthentication,
            PreferredEncoding = SmtpOptions.PreferredEncoding,
            UsePickupDirectory = SmtpOptions.UsePickupDirectory,
            MailPickupDirectory = SmtpOptions.MailPickupDirectory,
            SocketOptions = SmtpOptions.SocketOptions switch
            {
                SecureSocketOptions.None => MailKit.Security.SecureSocketOptions.None,
                SecureSocketOptions.Auto => MailKit.Security.SecureSocketOptions.Auto,
                SecureSocketOptions.SslOnConnect => MailKit.Security.SecureSocketOptions.SslOnConnect,
                SecureSocketOptions.StartTls => MailKit.Security.SecureSocketOptions.StartTls,
                SecureSocketOptions.StartTlsWhenAvailable => MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable,
                _ => MailKit.Security.SecureSocketOptions.Auto
            }
        });

        Email.DefaultSender = sender;
        Email.DefaultRenderer = EmailOptions.IsBodyHTML ? new RazorRenderer() : new FluentEmail.Core.Defaults.ReplaceRenderer();

        IFluentEmail email = new Email()
            .SetFrom(EmailOptions.FromAddress.EmailAddress, EmailOptions.FromAddress.DisplayName)
            .ReplyTo(EmailOptions.ReplyToAddress.EmailAddress ?? EmailOptions.FromAddress.EmailAddress, EmailOptions.ReplyToAddress.DisplayName ?? EmailOptions.ReplyToAddress.DisplayName)
            .Subject(EmailOptions.Subject)
            .Body(EmailOptions.Body, EmailOptions.IsBodyHTML)
            ;

        foreach (AddressModel to in EmailOptions.ToAddresses)
        {
            email.To(to.EmailAddress, to.DisplayName);
        }

        if (EmailOptions.CcAddresses.Any())
        {
            foreach (AddressModel cc in EmailOptions.CcAddresses)
            {
                email.CC(cc.EmailAddress, cc.DisplayName);
            }
        }

        if (EmailOptions.BccAddresses.Any())
        {
            foreach (AddressModel bcc in EmailOptions.BccAddresses)
            {
                email.BCC(bcc.EmailAddress, bcc.DisplayName);
            }
        }

        if (!string.IsNullOrEmpty(EmailOptions.Template))
        {
            email.UsingTemplate(EmailOptions.Template, templateModel);
        }

        foreach (FileInfo attach in EmailOptions.Attachments)
        {
            email.AttachFromFilename(attach.FullName, attach.GetContentType(), attach.Name);
        }

        return email;
    }
}