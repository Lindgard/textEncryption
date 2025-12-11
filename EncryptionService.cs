using System;
namespace textEncryption;

public class EncryptionService
{
    public static string Encrypt(string text, byte key)
    {
        var chars = text.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] ^ key);
        }
        return new string(chars);
    }

    public static string Decrypt(string text, byte key)
    {
        return Encrypt(text, key);
    }

    public static byte? TryParseKey(string? keyText)
    {
        if (byte.TryParse(keyText, out byte key))
            return key;
        return null;
    }
}