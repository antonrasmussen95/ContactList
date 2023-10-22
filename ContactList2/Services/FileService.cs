namespace ContactList2.Services;

// Min FileService som är till för att spara och läsa JSON till en specifik fil //
public class FileService
{   
    
    private static readonly string filePath = @"C:\Users\anton\Desktop\contacts.json";

    public static void SaveToFile(string contentAsJson)
    {
        try
        {
            using var sw = new StreamWriter(filePath);
            sw.Write(contentAsJson);
        }
        catch { }
    }

    public static string ReadFromFile()
    {
        try
        {
            if (File.Exists(filePath))
            {
                using var sr = new StreamReader(filePath);
                return sr.ReadToEnd();
            }
            else return null!; 
        }
        catch { return null!; } 
    }
}
