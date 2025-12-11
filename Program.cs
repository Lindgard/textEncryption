using System;
namespace textEncryption;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("== Bitwise Text Encryption Playground ==");
        Console.WriteLine("Enter text to encrypt: ");
        var input = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter key (0-255, defaults to 73): ");
        var keyText = Console.ReadLine();
        byte key = TryParseKey(keyText) ?? 73;

        Console.WriteLine($"\nYou entered: '{input}'");
        Console.WriteLine($"Key: {key}");

        var encrypted = Encrypt(input, key);
        Console.WriteLine($"Encrypted length: {encrypted.Length}");
        Console.WriteLine($"Encrypted bytes: {string.Join(",", encrypted.Select(c => (int)c))}");
        Console.WriteLine($"Encrypted: '{encrypted}'");
        Console.WriteLine($"Encrypted (hex): {ToHexString(encrypted)}");
        Console.WriteLine($"Decrypted: '{Decrypt(encrypted, key)}'");
    }

    static byte? TryParseKey(string? keyText)
    {
        if (byte.TryParse(keyText, out var key))
            return key;
        return null;
    }

    static string Encrypt(string text, byte key)
    {
        var chars = text.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            chars[i] = (char)(chars[i] ^ key);
        }
        return new string(chars);
    }

    static string Decrypt(string text, byte key)
    {
        return Encrypt(text, key);
    }

    static string ToHexString(string text)
    {
        var hexParts = new List<string>();
        foreach (char c in text)
        {
            int value = (int)c;
            string hex = value.ToString("X2");
            hexParts.Add(hex);
        }
        return string.Join(" ", hexParts);
    }
}
