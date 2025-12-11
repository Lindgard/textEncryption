using System;
namespace textEncryption;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("== Bitwise Text Encryption Playground ==");
        Console.ResetColor();
        string input;
        do{
            Console.WriteLine("Enter text to encrypt: ");
            input = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                break;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Text cannot be empty. Please try again.");
            Console.ResetColor();
        } while (true); //* repeat until valid input
        
        const int MAX_LENGTH = 50;
        if (input.Length > MAX_LENGTH)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Warning: Input is very long ({input.Length} characters). This may impact performance.");
            Console.WriteLine($"Only the first {MAX_LENGTH} characters will be encrypted.");
            Console.ResetColor();
            input = input.Substring(0, MAX_LENGTH);
        }
        
        byte key;
        while (true)
        {
            Console.Write("Enter key (0-255, defaults to 73): ");
            var keyText = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(keyText))
            {
                key = 73;
                Console.WriteLine($"Using default key: {key}");
                break;
            }

            var parsedKey = TryParseKey(keyText);
            if (parsedKey.HasValue)
            {
                key = parsedKey.Value;
                break;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Invalid key. Please enter a valid number between 0 and 255.");
            Console.ResetColor();
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nYou entered: '{input}'");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Key: {key}");
        Console.ResetColor();

        var encrypted = Encrypt(input, key);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Encrypted length: {encrypted.Length}");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Encrypted bytes: {string.Join(",", encrypted.Select(c => (int)c))}");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Encrypted: '{encrypted}'");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Encrypted (hex): {ToHexString(encrypted)}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Decrypted: '{Decrypt(encrypted, key)}'");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Decrypted (hex): {ToHexString(Decrypt(encrypted, key))}");
        Console.ResetColor();
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
