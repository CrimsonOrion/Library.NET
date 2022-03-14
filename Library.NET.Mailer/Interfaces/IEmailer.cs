using Library.NET.Mailer.Models;

using MailKit.Security;

namespace Library.NET.Mailer;

public interface IEmailer
{
    EmailOptionsModel EmailOptions { get; set; }
    SmtpOptionsModel SmtpOptions { get; set; }

    ResponseModel SendEmail();
    Task<ResponseModel> SendEmailAsync();
    ResponseModel SendEmailWithTemplate<T>(T templateModel);
    Task<ResponseModel> SendEmailWithTemplateAsync<T>(T templateModel);
    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, IList<AddressModel> ccAddresses, IList<AddressModel> bccAddresses, AddressModel replyToAddress, string subject, string body, IList<FileInfo> attachments, string template, bool isBodyHTML, string server, int port, string user, string password, bool useSSL, bool requiresAuthentication, string preferredEncoding, bool usePickupDirectory, string mailPickupDirectory, SecureSocketOptions secureSocketOptions);
    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, IList<AddressModel> ccAddresses, IList<AddressModel> bccAddresses, AddressModel replyToAddress, string subject, string body, IList<FileInfo> attachments, string server)
    {
        return SetOptions(fromAddress, toAddresses, ccAddresses, bccAddresses, replyToAddress, subject, body, attachments, EmailOptions.Template, EmailOptions.IsBodyHTML, server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SecureSocketOptions);
    }

    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, IList<AddressModel> ccAddresses, IList<AddressModel> bccAddresses, string subject, string body, IList<FileInfo> attachments, string server)
    {
        return SetOptions(fromAddress, toAddresses, ccAddresses, bccAddresses, fromAddress, subject, body, attachments, EmailOptions.Template, EmailOptions.IsBodyHTML, server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SecureSocketOptions);
    }

    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, IList<AddressModel> ccAddresses, IList<AddressModel> bccAddresses, AddressModel replyToAddress, string subject, string body, string server)
    {
        return SetOptions(fromAddress, toAddresses, ccAddresses, bccAddresses, replyToAddress, subject, body, new List<FileInfo>(), EmailOptions.Template, EmailOptions.IsBodyHTML, server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SecureSocketOptions);
    }

    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, IList<AddressModel> ccAddresses, IList<AddressModel> bccAddresses, string subject, string body, string server)
    {
        return SetOptions(fromAddress, toAddresses, ccAddresses, bccAddresses, fromAddress, subject, body, new List<FileInfo>(), EmailOptions.Template, EmailOptions.IsBodyHTML, server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SecureSocketOptions);
    }

    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, AddressModel replyToAddress, string subject, string body, string server)
    {
        return SetOptions(fromAddress, toAddresses, null, null, replyToAddress, subject, body, new List<FileInfo>(), EmailOptions.Template, EmailOptions.IsBodyHTML, server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SecureSocketOptions);
    }

    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, string subject, string body, string server)
    {
        return SetOptions(fromAddress, toAddresses, null, null, fromAddress, subject, body, new List<FileInfo>(), EmailOptions.Template, EmailOptions.IsBodyHTML, server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SecureSocketOptions);
    }

    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, AddressModel replyToAddress, string subject, string body, IList<FileInfo> attachments, string server)
    {
        return SetOptions(fromAddress, toAddresses, null, null, replyToAddress, subject, body, attachments, EmailOptions.Template, EmailOptions.IsBodyHTML, server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SecureSocketOptions);
    }

    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, string subject, string body, IList<FileInfo> attachments, string server)
    {
        return SetOptions(fromAddress, toAddresses, null, null, fromAddress, subject, body, attachments, EmailOptions.Template, EmailOptions.IsBodyHTML, server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SecureSocketOptions);
    }

    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, string subject, string body, IList<FileInfo> attachments)
    {
        return !string.IsNullOrEmpty(SmtpOptions.Server) ? SetOptions(fromAddress, toAddresses, null, null, fromAddress, subject, body, attachments, EmailOptions.Template, EmailOptions.IsBodyHTML, SmtpOptions.Server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SecureSocketOptions) : throw new System.Exception("Smtp Server cannot be null");
    }
}