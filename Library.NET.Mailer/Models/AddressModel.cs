namespace Library.NET.Mailer.Models;

/// <summary>
/// Allows for email address and display name for emails
/// </summary>
public class AddressModel
{
    /// <summary>
    /// What is displayed to a recipent
    /// </summary>
    public string DisplayName { get; set; }

    /// <summary>
    /// Email address of the sender/receipent
    /// </summary>
    public string EmailAddress { get; set; }

    public AddressModel() { }

    /// <summary>
    /// AddressModel where <see cref="DisplayName"/> is the email address
    /// </summary>
    /// <param name="emailAddress">Email address of the sender/receipent</param>
    public AddressModel(string emailAddress)
    {
        EmailAddress = emailAddress;
        DisplayName = emailAddress;
    }

    /// <summary>
    /// AddressModel where both <see cref="EmailAddress"/> and <see cref="DisplayName"/> are supplied
    /// </summary>
    /// <param name="emailAddress">Email address of the sender/receipent</param>
    /// <param name="displayName"></param>
    public AddressModel(string emailAddress, string displayName)
    {
        EmailAddress = emailAddress;
        DisplayName = displayName;
    }
}