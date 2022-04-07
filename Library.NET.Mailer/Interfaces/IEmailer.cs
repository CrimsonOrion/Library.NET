using FluentEmail.Core.Models;
using FluentEmail.MailKitSmtp;

using Library.NET.Mailer.Models;

using MailKit.Security;

namespace Library.NET.Mailer;

/// <summary>
/// Interface for setting up a custom emailer
/// </summary>
public interface IEmailer
{
    /// <summary>
    /// <see cref="EmailOptionsModel"/>: Sets the email options like To:, From:, etc.
    /// </summary>
    EmailOptionsModel EmailOptions { get; set; }

    /// <summary>
    /// Sets SMTP settings (server, port, etc.)
    /// </summary>
    SmtpClientOptions SmtpOptions { get; set; }

    /// <summary>
    /// Sends an email synchronously.
    /// </summary>
    /// <returns><see cref="SendResponse"/> with email result information</returns>
    SendResponse SendEmail();

    /// <summary>
    /// Sends an email asynchronously.
    /// </summary>
    /// <returns><see cref="SendResponse"/> with email result information</returns>
    Task<SendResponse> SendEmailAsync();

    /// <summary>
    /// Sends an email synchronously using a template.
    /// </summary>
    /// <returns><see cref="SendResponse"/> with email result information</returns>
    SendResponse SendEmailWithTemplate<T>(T templateModel);

    /// <summary>
    /// Sends an email asynchronously using a template.
    /// </summary>
    /// <returns><see cref="SendResponse"/> with email result information</returns>
    Task<SendResponse> SendEmailWithTemplateAsync<T>(T templateModel);

    /// <summary>
    /// Sets the options manaully for the emailer
    /// </summary>
    /// <param name="fromAddress">Sender information</param>
    /// <param name="toAddresses">Recipient list</param>
    /// <param name="ccAddresses">Carbon copy recipent list</param>
    /// <param name="bccAddresses">Blind carbon copy recipent list</param>
    /// <param name="replyToAddress">Reply to address information</param>
    /// <param name="subject">Subject line</param>
    /// <param name="body">The body of the email. Can be HTML.</param>
    /// <param name="attachments">List of <see cref="FileInfo"/> for attachments</param>
    /// <param name="template">Template for the email. See <see cref="EmailOptionsModel.Template"/> for more infomation.</param>
    /// <param name="isBodyHTML">Should the <paramref name="body"/> be rendered as HTML?</param>
    /// <param name="server">Server url or address</param>
    /// <param name="port">Port to send the message on</param>
    /// <param name="user">Username if authentication is required</param>
    /// <param name="password">Password if authentication is required</param>
    /// <param name="useSSL">Does the server require SSL?</param>
    /// <param name="requiresAuthentication">Does the server require authentication?</param>
    /// <param name="preferredEncoding">Encoding for the email</param>
    /// <param name="usePickupDirectory">Does this use a pickup directory for files?</param>
    /// <param name="mailPickupDirectory">Pickup directory for files</param>
    /// <param name="SocketOptions">Socket security options, select one of <see cref="SecureSocketOptions"/></param>
    /// <returns><see cref="IEmailer"/> instance to send mail with</returns>
    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, IList<AddressModel> ccAddresses, IList<AddressModel> bccAddresses, AddressModel replyToAddress, string subject, string body, IList<FileInfo> attachments, string template, bool isBodyHTML, string server, int port, string user, string password, bool useSSL, bool requiresAuthentication, string preferredEncoding, bool usePickupDirectory, string mailPickupDirectory, SecureSocketOptions SocketOptions);

    /// <summary>
    /// Sets the options for the emailer. Uses <see cref="EmailOptions"/> for template options and <see cref="SmtpOptions"/> for all but Smtp server name/ip
    /// </summary>
    /// <param name="fromAddress">Sender information</param>
    /// <param name="toAddresses">Recipient list</param>
    /// <param name="ccAddresses">Carbon copy recipent list</param>
    /// <param name="bccAddresses">Blind carbon copy recipent list</param>
    /// <param name="replyToAddress">Reply to address information</param>
    /// <param name="subject">Subject line</param>
    /// <param name="body">The body of the email. Can be HTML.</param>
    /// <param name="attachments">List of <see cref="FileInfo"/> for attachments</param>
    /// <param name="server">Server url or address</param>
    /// <returns><see cref="IEmailer"/> instance to send mail with</returns>
    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, IList<AddressModel> ccAddresses, IList<AddressModel> bccAddresses, AddressModel replyToAddress, string subject, string body, IList<FileInfo> attachments, string server) => SetOptions(fromAddress, toAddresses, ccAddresses, bccAddresses, replyToAddress, subject, body, attachments, EmailOptions.Template, EmailOptions.IsBodyHTML, server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SocketOptions.Value);

    /// <summary>
    /// Sets the options for the emailer. Uses <see cref="EmailOptions"/> for template options and reply-to address and <see cref="SmtpOptions"/> for all but Smtp server name/ip
    /// </summary>
    /// <param name="fromAddress">Sender information</param>
    /// <param name="toAddresses">Recipient list</param>
    /// <param name="ccAddresses">Carbon copy recipent list</param>
    /// <param name="bccAddresses">Blind carbon copy recipent list</param>
    /// <param name="subject">Subject line</param>
    /// <param name="body">The body of the email. Can be HTML.</param>
    /// <param name="attachments">List of <see cref="FileInfo"/> for attachments</param>
    /// <param name="server">Server url or address</param>
    /// <returns><see cref="IEmailer"/> instance to send mail with</returns>
    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, IList<AddressModel> ccAddresses, IList<AddressModel> bccAddresses, string subject, string body, IList<FileInfo> attachments, string server) => SetOptions(fromAddress, toAddresses, ccAddresses, bccAddresses, fromAddress, subject, body, attachments, EmailOptions.Template, EmailOptions.IsBodyHTML, server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SocketOptions.Value);

    /// <summary>
    /// Sets the options for the emailer. Uses <see cref="EmailOptions"/> for template and attachment options and <see cref="SmtpOptions"/> for all but Smtp server name/ip
    /// </summary>
    /// <param name="fromAddress">Sender information</param>
    /// <param name="toAddresses">Recipient list</param>
    /// <param name="ccAddresses">Carbon copy recipent list</param>
    /// <param name="bccAddresses">Blind carbon copy recipent list</param>
    /// <param name="replyToAddress">Reply to address information</param>
    /// <param name="subject">Subject line</param>
    /// <param name="body">The body of the email. Can be HTML.</param>
    /// <param name="server">Server url or address</param>
    /// <returns><see cref="IEmailer"/> instance to send mail with</returns>
    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, IList<AddressModel> ccAddresses, IList<AddressModel> bccAddresses, AddressModel replyToAddress, string subject, string body, string server) => SetOptions(fromAddress, toAddresses, ccAddresses, bccAddresses, replyToAddress, subject, body, new List<FileInfo>(), EmailOptions.Template, EmailOptions.IsBodyHTML, server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SocketOptions.Value);

    /// <summary>
    /// Sets the options for the emailer. Uses <see cref="EmailOptions"/> for template and attachment options as well as reply-to address and <see cref="SmtpOptions"/> for all but Smtp server name/ip
    /// </summary>
    /// <param name="fromAddress">Sender information</param>
    /// <param name="toAddresses">Recipient list</param>
    /// <param name="ccAddresses">Carbon copy recipent list</param>
    /// <param name="bccAddresses">Blind carbon copy recipent list</param>
    /// <param name="subject">Subject line</param>
    /// <param name="body">The body of the email. Can be HTML.</param>
    /// <param name="server">Server url or address</param>
    /// <returns><see cref="IEmailer"/> instance to send mail with</returns>
    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, IList<AddressModel> ccAddresses, IList<AddressModel> bccAddresses, string subject, string body, string server) => SetOptions(fromAddress, toAddresses, ccAddresses, bccAddresses, fromAddress, subject, body, new List<FileInfo>(), EmailOptions.Template, EmailOptions.IsBodyHTML, server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SocketOptions.Value);

    /// <summary>
    /// Sets the options for the emailer. Uses <see cref="EmailOptions"/> for template, cc, bcc and attachment options and <see cref="SmtpOptions"/> for all but Smtp server name/ip
    /// </summary>
    /// <param name="fromAddress">Sender information</param>
    /// <param name="toAddresses">Recipient list</param>
    /// <param name="replyToAddress">Reply to address information</param>
    /// <param name="subject">Subject line</param>
    /// <param name="body">The body of the email. Can be HTML.</param>
    /// <param name="server">Server url or address</param>
    /// <returns><see cref="IEmailer"/> instance to send mail with</returns>
    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, AddressModel replyToAddress, string subject, string body, string server) => SetOptions(fromAddress, toAddresses, null, null, replyToAddress, subject, body, new List<FileInfo>(), EmailOptions.Template, EmailOptions.IsBodyHTML, server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SocketOptions.Value);

    /// <summary>
    /// Sets the options for the emailer. Uses <see cref="EmailOptions"/> for template, cc, bcc and attachment options as well as reply-to address and <see cref="SmtpOptions"/> for all but Smtp server name/ip
    /// </summary>
    /// <param name="fromAddress">Sender information</param>
    /// <param name="toAddresses">Recipient list</param>
    /// <param name="subject">Subject line</param>
    /// <param name="body">The body of the email. Can be HTML.</param>
    /// <param name="server">Server url or address</param>
    /// <returns><see cref="IEmailer"/> instance to send mail with</returns>
    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, string subject, string body, string server) => SetOptions(fromAddress, toAddresses, null, null, fromAddress, subject, body, new List<FileInfo>(), EmailOptions.Template, EmailOptions.IsBodyHTML, server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SocketOptions.Value);

    /// <summary>
    /// Sets the options for the emailer. Uses <see cref="EmailOptions"/> for template, cc and bcc address and <see cref="SmtpOptions"/> for all but Smtp server name/ip
    /// </summary>
    /// <param name="fromAddress">Sender information</param>
    /// <param name="toAddresses">Recipient list</param>
    /// <param name="replyToAddress">Reply to address information</param>
    /// <param name="subject">Subject line</param>
    /// <param name="body">The body of the email. Can be HTML.</param>
    /// <param name="attachments">List of <see cref="FileInfo"/> for attachments</param>
    /// <param name="server">Server url or address</param>
    /// <returns><see cref="IEmailer"/> instance to send mail with</returns>
    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, AddressModel replyToAddress, string subject, string body, IList<FileInfo> attachments, string server) => SetOptions(fromAddress, toAddresses, null, null, replyToAddress, subject, body, attachments, EmailOptions.Template, EmailOptions.IsBodyHTML, server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SocketOptions.Value);

    /// <summary>
    /// Sets the options for the emailer. Uses <see cref="EmailOptions"/> for template, cc, bcc and reply-to address and <see cref="SmtpOptions"/> for all but Smtp server name/ip
    /// </summary>
    /// <param name="fromAddress">Sender information</param>
    /// <param name="toAddresses">Recipient list</param>
    /// <param name="subject">Subject line</param>
    /// <param name="body">The body of the email. Can be HTML.</param>
    /// <param name="attachments">List of <see cref="FileInfo"/> for attachments</param>
    /// <param name="server">Server url or address</param>
    /// <returns><see cref="IEmailer"/> instance to send mail with</returns>
    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, string subject, string body, IList<FileInfo> attachments, string server) => SetOptions(fromAddress, toAddresses, null, null, fromAddress, subject, body, attachments, EmailOptions.Template, EmailOptions.IsBodyHTML, server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SocketOptions.Value);

    /// <summary>
    /// Sets the options for the emailer. Uses <see cref="EmailOptions"/> for template, cc, bcc and reply-to address and <see cref="SmtpOptions"/> for all else, including server
    /// </summary>
    /// <param name="fromAddress">Sender information</param>
    /// <param name="toAddresses">Recipient list</param>
    /// <param name="subject">Subject line</param>
    /// <param name="body">The body of the email. Can be HTML.</param>
    /// <param name="attachments">List of <see cref="FileInfo"/> for attachments</param>
    /// <returns><see cref="IEmailer"/> instance to send mail with</returns>
    IEmailer SetOptions(AddressModel fromAddress, IList<AddressModel> toAddresses, string subject, string body, IList<FileInfo> attachments) => SetOptions(fromAddress, toAddresses, null, null, fromAddress, subject, body, attachments, EmailOptions.Template, EmailOptions.IsBodyHTML, SmtpOptions.Server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SocketOptions.Value);

    /// <summary>
    /// Sets the options automatically for the emailer from values in <see cref="EmailOptions"/> and <see cref="SmtpOptions"/>
    /// </summary>
    /// <returns><see cref="IEmailer"/> instance to send mail with</returns>
    IEmailer SetOptions() => SetOptions(EmailOptions.FromAddress, EmailOptions.ToAddresses, EmailOptions.CcAddresses, EmailOptions.BccAddresses, EmailOptions.ReplyToAddress, EmailOptions.Subject, EmailOptions.Body, EmailOptions.Attachments, EmailOptions.Template, EmailOptions.IsBodyHTML, SmtpOptions.Server, SmtpOptions.Port, SmtpOptions.User, SmtpOptions.Password, SmtpOptions.UseSsl, SmtpOptions.RequiresAuthentication, SmtpOptions.PreferredEncoding, SmtpOptions.UsePickupDirectory, SmtpOptions.MailPickupDirectory, SmtpOptions.SocketOptions.Value);
}