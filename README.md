# XWorm 5.2 | XClient Decrypt

This project is used to decrypt the encrypted settings of `XClient.exe`. It allows decryption of data encrypted with AES encryption using encrypted settings.

## Usage

It is used to decipher encrypted settings. It works by decrypting encrypted data and printing it to the screen.

## Settings

Encrypted settings are stored as static string variables within the `Settings` class. These settings are kept encrypted and can be decrypted using the `AlgorithmAES.Decrypt` method.

```csharp
public class Settings
{
    public static string Hosts = "WM9gIQ5UxNWMG2/B7vnS1A==";
    public static string Port = "MhnPw7FFFhzELqlXNj/5qA==";
    public static string KEY = "/XUnWZUhuk2qHbeGFGE+Hg==";
    public static string SPL = "otR4GvdeDl1AhTYM5SuH+Q==";
    public static string Groub = "FZmY5LpdeIdpI7DzmC66GA==";
    public static string USBNM = "Cou/N6h9a6BOy7TJfYCJPQ==";
    //...
}
```

## Encryption

Data is encrypted and decrypted using the Rijndael AES encryption algorithm within the `AlgorithmAES` class.

```csharp
public class AlgorithmAES
{
    public static object Decrypt(string input)
    {
        // ...
    }
}
```

## Notes

- This code is provided for learning and experimentation purposes only.

## License

This project is licensed under the MIT License. You can check the [LICENSE file](LICENSE) for more information.