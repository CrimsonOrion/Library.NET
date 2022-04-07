namespace Library.NET.Mailer.Models;

/// <summary>
/// Sets the email options like To:, From:, etc.
/// </summary>
public class EmailOptionsModel
{
    /// <summary>
    /// Sender information
    /// </summary>
    public AddressModel FromAddress { get; set; }

    /// <summary>
    /// Reply to address information
    /// </summary>
    public AddressModel ReplyToAddress { get; set; }

    /// <summary>
    /// Recipient list
    /// </summary>
    public IList<AddressModel> ToAddresses { get; set; } = new List<AddressModel>();

    /// <summary>
    /// Carbon copy recipent list
    /// </summary>
    public IList<AddressModel> CcAddresses { get; set; } = new List<AddressModel>();

    /// <summary>
    /// Blind carbon copy recipent list
    /// </summary>
    public IList<AddressModel> BccAddresses { get; set; } = new List<AddressModel>();

    /// <summary>
    /// List of <see cref="FileInfo"/> for attachments
    /// </summary>
    public IList<FileInfo> Attachments { get; set; } = new List<FileInfo>();

    /// <summary>
    /// Subject line
    /// </summary>
    public string Subject { get; set; }

    /// <summary>
    /// The body of the email.
    /// </summary>
    /// <remarks>Can be HTML if <see cref="IsBodyHTML"/> is set to <value>true</value></remarks>
    public string Body { get; set; }

    /// <summary>
    /// Template for the email
    /// </summary>
    /// <example>
    /// Here's an example:
    /// <code>
    /// var template = new StringBuilder();
    /// template.AppendLine("Dear @Model.FirstName,");
    /// template.AppendLine("<p>Thanks for purchasing @Model.ProductName. We hope you enjoy it! </p>");
    /// template.AppendLine("- COS Team");
    /// </code>
    /// </example>
    /// <remarks>
    /// See property description for an example.
    /// </remarks>
    public string Template { get; set; }

    /// <summary>
    /// Should the <see cref="Body"/> be rendered as HTML?
    /// </summary>
    public bool IsBodyHTML { get; set; } = false;
}