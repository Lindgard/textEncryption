using System;
namespace textEncryption;

public class InputValidator
{
    private const int MAX_LENGTH = 50;

    public string GetValidTextInput()
    {
        string input;
        do
        {
            Console.WriteLine("Enter text to encrypt: ");
            input = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrEmpty(input))
            {
                break;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Text cannot be empty. Please try again.");
            Console.ResetColor();
        } while (true);

        return ValidateLength(input);
    }

    public byte GetValidKeyInput(EncryptionService encryptionService)
    {
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

            var parsedKey = encryptionService.TryParseKey(keyText);
            if (parsedKey.HasValue)
            {
                key = parsedKey.Value;
                break;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Invalid key. Please enter a valid number between 0 and 255.");
            Console.ResetColor();
        }

        return key;
    }

    private string ValidateLength(string input)
    {
        if (input.Length > MAX_LENGTH)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Warning: Input is very long ({input.Length} characters). This may impact performance.");
            Console.WriteLine($"Only the first {MAX_LENGTH} characters will be encrypted.");
            Console.ResetColor();
            return input.Substring(0, MAX_LENGTH);
        }
        return input;
    }
}