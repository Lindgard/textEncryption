using System;

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

        //* Get validated inputs
        string input = validator.GetValidTextInput();
        byte[] key = validator.GetValidMultiByteKeyInput(encryptionService);

        //* Encrypt and Decrypt
        string encrypted = encryptionService.Encrypt(input, key);
        string decrypted = encryptionService.Decrypt(encrypted, key);

        //* Display results
        formatter.DisplayEncryptionResults(input, key, encrypted, decrypted);
    }
}