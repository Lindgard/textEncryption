namespace textEncryption;

public class DisplayFormatter
{
    public string ToHexString(string text)
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

    public void DisplayEncryptionResults(string input, byte key, string encrypted, string decrypted)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nYou entered: '{input}'");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Key: {key}");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Encrypted length: {encrypted.Length}");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Encrypted: {encrypted}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Encrypted (hex): {ToHexString(encrypted)}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Decrypted: '{decrypted}'");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Decrypted (hex): {ToHexString(decrypted)}");
        Console.ResetColor();
    }

    //* Multi-byte version
    public void DisplayEncryptionResults(string input, byte[] key, string encrypted, string decrypted)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nYou entered: '{input}'");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Key: [{string.Join(", ", key)}]");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Encrypted length: {encrypted.Length}");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Encrypted: {encrypted}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Encrypted (hex): {ToHexString(encrypted)}");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Decrypted: '{decrypted}'");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Decrypted (hex): {ToHexString(decrypted)}");
        Console.ResetColor();
    }
}