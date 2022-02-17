using Library.NET.Mailer.Models;

namespace Library.NET.Mailer;

public interface IEmailer
{
    EmailOptionsModel EmailOptions { get; set; }
    SmtpOptionsModel SmtpOptions { get; set; }

    ResponseModel SendEmail();
    Task<ResponseModel> SendEmailAsync();
    ResponseModel SendEmailWithTemplate<T>(T templateModel);
    Task<ResponseModel> SendEmailWithTemplateAsync<T>(T templateModel);
    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, IList<AddressModel> ccAddresses, IList<AddressModel> bccAddresses, AddressModel replyToAddress, string subject, string body, IList<FileInfo> attachments, string template, bool isBodyHTML, string server, int port, string user, string password, bool useSSL, bool requiresAuthentication, string preferredEncoding, bool usePickupDirectory, string mailPickupDirectory);
    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, IList<AddressModel> ccAddresses, IList<AddressModel> bccAddresses, AddressModel replyToAddress, string subject, string body, IList<FileInfo> attachments)
    {
        return SetOptions(fromAddress, toAddresses, ccAddresses, bccAddresses, replyToAddress, subject, body, attachments, EmailOptions.Template, EmailOptions.IsBodyHTML, SmtpOptions.Server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory);
    }

    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, IList<AddressModel> ccAddresses, IList<AddressModel> bccAddresses, string subject, string body, IList<FileInfo> attachments)
    {
        return SetOptions(fromAddress, toAddresses, ccAddresses, bccAddresses, fromAddress, subject, body, attachments, EmailOptions.Template, EmailOptions.IsBodyHTML, SmtpOptions.Server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory);
    }

    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, IList<AddressModel> ccAddresses, IList<AddressModel> bccAddresses, AddressModel replyToAddress, string subject, string body)
    {
        return SetOptions(fromAddress, toAddresses, ccAddresses, bccAddresses, replyToAddress, subject, body, new List<FileInfo>(), EmailOptions.Template, EmailOptions.IsBodyHTML, SmtpOptions.Server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory);
    }

    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, IList<AddressModel> ccAddresses, IList<AddressModel> bccAddresses, string subject, string body)
    {
        return SetOptions(fromAddress, toAddresses, ccAddresses, bccAddresses, fromAddress, subject, body, new List<FileInfo>(), EmailOptions.Template, EmailOptions.IsBodyHTML, SmtpOptions.Server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory);
    }

    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, AddressModel replyToAddress, string subject, string body)
    {
        return SetOptions(fromAddress, toAddresses, null, null, replyToAddress, subject, body, new List<FileInfo>(), EmailOptions.Template, EmailOptions.IsBodyHTML, SmtpOptions.Server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory);
    }

    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, string subject, string body)
    {
        return SetOptions(fromAddress, toAddresses, null, null, fromAddress, subject, body, new List<FileInfo>(), EmailOptions.Template, EmailOptions.IsBodyHTML, SmtpOptions.Server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory);
    }

    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, AddressModel replyToAddress, string subject, string body, IList<FileInfo> attachments)
    {
        return SetOptions(fromAddress, toAddresses, null, null, replyToAddress, subject, body, attachments, EmailOptions.Template, EmailOptions.IsBodyHTML, SmtpOptions.Server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory);
    }

    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, string subject, string body, IList<FileInfo> attachments)
    {
        return SetOptions(fromAddress, toAddresses, null, null, fromAddress, subject, body, attachments, EmailOptions.Template, EmailOptions.IsBodyHTML, SmtpOptions.Server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory);
    }
}