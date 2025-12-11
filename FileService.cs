using System;
using System.IO;

namespace textEncryption;

public class FileService
{
    public void SaveEncryptedText(string encryptedText, string filePath)
    {
        File.WriteAllText(filePath, encryptedText);
    }

    public string LoadEncryptedText(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }
        return File.ReadAllText(filePath);
    }

    public void SaveKey(byte[] key, string filePath)
    {
        string keyString = string.Join(", ", key);
        File.WriteAllText(filePath, keyString);
    }

    public byte[] LoadKey(string filePath, EncryptionService encryptionService)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"File not found: {filePath}");
        }

        string keyString = File.ReadAllText(filePath);
        var parts = keyString.Split(", ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var keyList = new List<byte>();

        foreach (var part in parts)
        {
            var parsedKey = encryptionService.TryParseKey(part);
            if (parsedKey.HasValue)
            {
                keyList.Add(parsedKey.Value);
            }
            else
            {
                throw new FormatException($"Invalid format in file: {part}");
            }
        }
        return keyList.ToArray();
    }
}