using FluentEmail.Core;
using FluentEmail.Core.Models;
using FluentEmail.MailKitSmtp;
using FluentEmail.Razor;

using Library.NET.Helpers;
using Library.NET.Mailer.Models;

using MailKit.Security;

namespace Library.NET.Mailer;
public class FluentEmailerMailKit : IEmailer
{
    public EmailOptionsModel EmailOptions { get; set; } = new();
    public SmtpOptionsModel SmtpOptions { get; set; } = new();

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

        SmtpOptions = new SmtpOptionsModel()
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
            SecureSocketOptions = secureSocketOptions
        };

        return this;
    }

    public ResponseModel SendEmail()
    {
        return CreateAndSendEmail("");
    }

    public async Task<ResponseModel> SendEmailAsync()
    {
        return await CreateAndSendEmailAsync("");
    }

    public ResponseModel SendEmailWithTemplate<T>(T templateModel)
    {
        return CreateAndSendEmail(templateModel);
    }

    public async Task<ResponseModel> SendEmailWithTemplateAsync<T>(T templateModel)
    {
        return await CreateAndSendEmailAsync(templateModel);
    }

    private ResponseModel CreateAndSendEmail<T>(T templateModel)
    {
        IFluentEmail email = string.IsNullOrEmpty(EmailOptions.Template) ? GenerateEmail() : GenerateEmailWithTemplate(templateModel);

        SendResponse result = email.Send();

        return new ResponseModel() { ErrorMessages = result.ErrorMessages, MessageId = result.MessageId, SetSuccessful = result.Successful };
    }

    private async Task<ResponseModel> CreateAndSendEmailAsync<T>(T templateModel)
    {
        IFluentEmail email = string.IsNullOrEmpty(EmailOptions.Template) ? GenerateEmail() : GenerateEmailWithTemplate(templateModel);
        SendResponse result = new();
        try
        {
            result = await email.SendAsync();
            return new ResponseModel() { ErrorMessages = result.ErrorMessages, MessageId = result.MessageId, SetSuccessful = result.Successful };
        }
        catch (Exception ex)
        {
            List<string> messages = new() { ex.Message };
            messages.AddRange(result.ErrorMessages);
            return new ResponseModel() { ErrorMessages = messages, MessageId = result.MessageId, SetSuccessful = result.Successful };
        }
    }

    private IFluentEmail GenerateEmail()
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
            SocketOptions = SmtpOptions.SecureSocketOptions switch
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

        IFluentEmail email = new Email()
            .SetFrom(EmailOptions.FromAddress.EmailAddress, EmailOptions.FromAddress.DisplayName)
            .ReplyTo(EmailOptions.ReplyToAddress.EmailAddress, EmailOptions.ReplyToAddress.DisplayName)
            .Subject(EmailOptions.Subject)
            ;

        foreach (AddressModel to in EmailOptions.ToAddresses)
        {
            email.To(to.EmailAddress, to.DisplayName);
        }

        if (EmailOptions.CcAddresses != null && EmailOptions.CcAddresses.Any())
        {
            foreach (AddressModel cc in EmailOptions.CcAddresses)
            {
                email.CC(cc.EmailAddress, cc.DisplayName);
            }
        }

        if (EmailOptions.BccAddresses != null && EmailOptions.BccAddresses.Any())
        {
            foreach (AddressModel bcc in EmailOptions.BccAddresses)
            {
                email.BCC(bcc.EmailAddress, bcc.DisplayName);
            }
        }

        if (!string.IsNullOrEmpty(EmailOptions.Body))
        {
            email.Body(EmailOptions.Body);
        }

        if (EmailOptions.IsBodyHTML)
        {
            email.Data.IsHtml = true;
            Email.DefaultRenderer = new RazorRenderer();
        }

        foreach (FileInfo attach in EmailOptions.Attachments)
        {
            email.AttachFromFilename(attach.FullName, attach.GetContentType(), attach.Name);
        }

        return email;
    }

    //var template = new StringBuilder();
    //template.AppendLine("Dear @Model.FirstName,");
    //template.AppendLine("<p>Thanks for purchasing @Model.ProductName. We hope you enjoy it! </p>");
    //template.AppendLine("- COS Team");
    private IFluentEmail GenerateEmailWithTemplate<T>(T templateModel)
    {
        IFluentEmail email = GenerateEmail();

        if (!string.IsNullOrEmpty(EmailOptions.Template))
        {
            email.UsingTemplate(EmailOptions.Template, templateModel);
        }

        return email;
    }
}