namespace Library.NET.Cryptography;

public interface ICrypto
{
    void ChangePurpose(string purpose);
    string Decrypt(string input);
    string Encrypt(string input);
}