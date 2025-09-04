using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace PersonToJson.Models;

public class PersonalInfo
{
    public required Person Person { get; init; }
    public required Contacts Contacts { get; init; }
    

    public static void UnLoad(PersonalInfo personalInfo, string path = "personal_info.json")
    {
        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(personalInfo, options);
        File.WriteAllText(path, json);
    }

    public static PersonalInfo? Load(string path = "personal_info.json")
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<PersonalInfo>(json);
    }
}