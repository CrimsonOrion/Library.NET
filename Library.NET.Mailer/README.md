# Library.NET.Mailer
---
##### Disclaimer
---
***This is my personal wrapper for [FluentEmail.Mailkit](https://github.com/lukencode/FluentEmail). It is designed to make my life easier interacting with my other programs.***
## Implementing `IEmailer`

##### Create a new instance:
---
``` cs
IEmailer emailer = new FluentEmailerMailKit();
```

##### Set `EmailOptions`
---
``` cs
emailer.EmailOptions = new()
{
    FromAddress = new("sender@test.com", "Tester"),
    ToAddresses = new List<AddressModel>() { new("recipient@test.com"), new("recipient2@test.com") },
    CcAddresses = new List<AddressModel>() { new("recipient3@test.com"), new("recipient4@test.com") },
    BccAddresses = new List<AddressModel>() { new("recipient5@test.com"), new("recipient6@test.com") },
    ReplyToAddress = new(),
    Subject = "Test from Sender",
    Body = "This is a test from the Tester program",
    Attachments = new List<FileInfo>() { new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "New Text Document.txt")) },
    Template = String.Empty,
    IsBodyHTML = true
}
```

##### Set `SmtpOptions`
---
``` cs
emailer.SmtpOptions = new()
{
    Server = "mailserver.test.com",
    Port = 25,
    User = String.Empty,
    Password = String.Empty,
    UseSsl = false,
    RequiresAuthentication = false,
    PreferredEncoding = String.Empty,
    UsePickupDirectory = false,
    MailPickupDirectory = String.Empty,
    SocketOptions = SecureSocketOptions.Auto
}
```

##### Send the email
---
``` cs
SendResponse result = await emailer.SetOptions().SendEmailAsync();

if (result.Successful)
{
    Console.WriteLine("Success!");
}
else
{
    StringBuilder stringBuilder = new();
    foreach (var err in result.ErrorMessages)
    {
        stringBuilder.AppendLine(err);
    }
    Console.WriteLine(stringBuilder.ToString());
}
```

##### Alternatively, you can set `EmailOptions` and `SmtpOptions` in `.SetOptions()`
---
``` cs
emailer.SetOptions(
    new AddressModel("sender@test.com", "Tester"),
    new List<AddressModel>() { new("recipient@test.com"), new("recipient2@test.com") },
    new List<AddressModel>() { new("recipient3@test.com"), new("recipient4@test.com") },
    new List<AddressModel>() { new("recipient5@test.com"), new("recipient6@test.com") },
    new AddressModel(),
    "Test from Sender",
    "This is a test from the Tester program",
    new List<FileInfo>() { new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "New Text Document.txt")) },
    "",
    true,
    "mailserver.test.com",
    25,
    "",
    "",
    false,
    false,
    "",
    false,
    "",
    SecureSocketOptions.Auto
    )
    .SendEmail();
```
---
## Methods

### Options:
#### `EmailOptions`
* `fromAddress`: Sender information
* `replyToAddress`*(optional)*: Address info for replies. Defaults to `fromAddress`.
* `toAddresses`, `ccAddresses`*(optional)*, `bccAddresses`*(optional)*: Recipient lists
* `subject`*(optional)*: Subject line. Defaults to `string.Empty`.
* `body`*(optional)*: The body of the email. Defaults to `string.Empty`.
* `template`*(optional)*: Template for the email body. Defaults to `string.Empty`. *(see example below)*
* `isBodyHtml`*(optional)*: Should the `body` be rendered as HTML?

#### `SmtpOptions`
* `server`: SMTP server name or IP address
* `port`*(optional)*: TCP port the emailer uses to send the mail. Defaults to `25`.
* `user`, `password` *(both optional if `requiresAuthentication` is `false`)*: Credentials passed to the SMTP server for sending mail. Defaults to `string.Empty`.
* `useSSL`*(optional)*: Does the server use SSL? Defaults to `false`.
* `requiresAuthentication`*(optional)*: Does the server require authentication to send mail? Defaults to `false`.
* `preferredEncoding`*(optional)*: Preferred encoding for the email. Defaults to `string.Empty`.
* `usePickupDirectory`*(optional)*: Does the email use a pickup directory for delivery? Defaults to `false`.
* `mailPickupDirectory`*(optional)*: Pickup directory for mail delivery. Defaults to `string.Empty`.
* `socketOptions`*(optional)*: Provides a way of specifying the SSL and/or TLS encryption that should be used for a connection. Defaults to `Auto`, that is, If the server does not support SSL or TLS, then the connection will continue without any encryption.

### *SendEmail* & *SendEmailAsync* 
``` cs
SendResponse result = await emailer.SetOptions().SendEmailAsync();

SendResponse result = emailer.SetOptions(
    new AddressModel("sender@test.com", "Tester"),
    new List<AddressModel>() { new("recipient@test.com"), new("recipient2@test.com") },
    new List<AddressModel>() { new("recipient3@test.com"), new("recipient4@test.com") },
    new List<AddressModel>() { new("recipient5@test.com"), new("recipient6@test.com") },
    new AddressModel(),
    "Test from Sender",
    "This is a test from the Tester program",
    new List<FileInfo>() { new(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "New Text Document.txt")) },
    "",
    true,
    "mailserver.test.com",
    25,
    "",
    "",
    false,
    false,
    "",
    false,
    "",
    SecureSocketOptions.Auto
    )
    .SendEmail();
```

### *SendEmailWithTemplate<T>(T templateModel)* & *SendEmailWithTemplateAsync<T>(T templateModel)*
``` cs
var template = new StringBuilder();
template.AppendLine("Dear @Model.FirstName,");
template.AppendLine("<p>Thanks for purchasing @Model.ProductName. We hope you enjoy it! </p>");
template.AppendLine("- COS Team");

emailer.EmailOptions.Template = template.ToString();

SendResponse result = emailer.SetOptions().SendEmailWithTemplate(new {FirstName = "John", ProductName = "Epic Razors"});
```
#### *NOTE: to make this work, you have to add the following to your .csproj file: per this  [MS doc](https://docs.microsoft.com/en-us/dotnet/core/compatibility/aspnet-core/6.0/preservecompilationcontext-not-set-by-default)* 
``` xml
<PropertyGroup>
...
    <PreserveCompilationContext>true</PreserveCompilationContext>
...
</PropertyGroup>
```
---

### Planned implementations

* Using a different renderer than `RazorRenderer()`. That is why you have to put the `<PreserveCompilationContext>true</PreserveCompilationContext>` in the .csproj file.

### Outside Dependencies

* [FluentEmail.MailKit](https://www.nuget.org/packages/FluentEmail.MailKit/)
* [FluentEmail.Razor](https://www.nuget.org/packages/FluentEmail.Razor/)