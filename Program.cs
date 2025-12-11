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
    }

    static byte? TryParseKey(string? keyText)
    {
        if (byte.TryParse(keyText, out var key))
            return key;
        return null;
    }
}
