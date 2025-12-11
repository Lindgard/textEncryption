using System;
namespace textEncryption;

public class EncryptionService
{
    //* Single byte Encryption and Decryption
    public string Encrypt(string text, byte key)
    {
        var chars = text.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] ^ key);
        }
        return new string(chars);
    }

    public string Decrypt(string text, byte key)
    {
        return Encrypt(text, key);
    }


    //* Multi-byte Encryption and Decryption
    public string Encrypt(string text, byte[] key)
    {
        var chars = text.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            byte keyByte = key[i % key.Length];
            chars[i] = (char)(chars[i] ^ keyByte);
        }
        return new string(chars);
    }

    public string Decrypt(string text, byte[] key)
    {
        return Encrypt(text, key);
    }

    public byte? TryParseKey(string? keyText)
    {
        if (byte.TryParse(keyText, out byte key))
            return key;
        return null;
    }
}