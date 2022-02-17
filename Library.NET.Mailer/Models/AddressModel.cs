namespace Library.NET.Mailer.Models;
public class AddressModel
{
    public string DisplayName { get; set; }
    public string EmailAddress { get; set; }

    public AddressModel() { }

    public AddressModel(string emailAddress)
    {
        EmailAddress = emailAddress;
        DisplayName = emailAddress;
    }

    public AddressModel(string emailAddress, string displayName)
    {
        EmailAddress = emailAddress;
        DisplayName = displayName;
    }
}