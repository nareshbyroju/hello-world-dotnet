using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

class HelloWorld
{
    // VULNERABILITY: Hardcoded credentials
    private const string DbPassword = "admin@123password";
    private const string ApiKey = "sk-abcdef123456";
    private const string AwsAccessKey = "AKIAIOSFODNN7EXAMPLE";

    static void Main()
    {
        Console.WriteLine("Hello, World! (.NET)");
        Console.WriteLine($"Connected with: {DbPassword}");
    }

    // VULNERABILITY: Weak MD5 hashing
    public static string HashPassword(string password)
    {
        using (MD5 md5 = MD5.Create())  // Insecure hash algorithm
        {
            byte[] hashedBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToHexString(hashedBytes);
        }
    }

    // VULNERABILITY: Deserialization of untrusted data
    public static void DeserializeJson(string jsonData)
    {
        var settings = new JsonSerializerSettings 
        { 
            TypeNameHandling = TypeNameHandling.Auto  // Unsafe deserialization
        };
        var obj = JsonConvert.DeserializeObject(jsonData, settings);
        Console.WriteLine(obj);
    }

    // VULNERABILITY: Command injection
    public static string ExecuteCommand(string userInput)
    {
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c {userInput}",  // Command injection
            UseShellExecute = false,
            RedirectStandardOutput = true
        };
        
        using (Process process = Process.Start(psi))
        {
            return process.StandardOutput.ReadToEnd();
        }
    }

    // VULNERABILITY: SQL injection (simulated)
    public static string BuildUserQuery(string userId)
    {
        string query = $"SELECT * FROM Users WHERE Id = {userId}";  // SQL injection
        return query;
    }
}
