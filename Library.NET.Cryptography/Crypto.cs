using Microsoft.AspNetCore.DataProtection;

namespace Library.NET.Cryptography;
public class Crypto(IDataProtectionProvider provider) : ICrypto
{
    private IDataProtector _protector = provider.CreateProtector("Test");

    public void ChangePurpose(string purpose) => _protector = _protector.CreateProtector(purpose);

    public string Encrypt(string input) => _protector.Protect(input);

    public string Decrypt(string input) => _protector.Unprotect(input);
}