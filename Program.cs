using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace textEncryption;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("== Bitwise Text Encryption Playground");
        Console.ResetColor();

        //* Create service instances
        var validator = new InputValidator();
        var encryptionService = new EncryptionService();
        var formatter = new DisplayFormatter();
        var fileService = new FileService();

        //* Get validated inputs
        string input = validator.GetValidTextInput();
        byte[] key = validator.GetValidMultiByteKeyInput(encryptionService);

        //* Encrypt and Decrypt
        string encrypted = encryptionService.Encrypt(input, key);
        string decrypted = encryptionService.Decrypt(encrypted, key);

        //* Display results
        formatter.DisplayEncryptionResults(input, key, encrypted, decrypted);

        //* Ask if user wants to save
        Console.Write("\nSave encrypted text to file? (y/n): ");
        var saveChoice = Console.ReadLine()?.ToLower();
        if (saveChoice == "y" || saveChoice == "yes")
        {
            Console.WriteLine("Enter file path (e.g., 'encrypted.txt')");
            var filePath = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                try
                {
                    fileService.SaveEncryptedText(encrypted, filePath);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Encrypted text saved to: {filePath}");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error saving file: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }

        //* Ask if user wants to save key
        Console.Write("Save key to file? (y/n): ");
        var saveKeyChoice = Console.ReadLine()?.ToLower();
        if (saveKeyChoice == "y" || saveKeyChoice == "yes")
        {
            Console.Write("Enter key file path (e.g., 'key.txt'): ");
            var keyFilePath = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(keyFilePath))
            {
                try
                {
                    fileService.SaveKey(key, keyFilePath);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Key saved to: {keyFilePath}");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error saving key: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }
    }
}