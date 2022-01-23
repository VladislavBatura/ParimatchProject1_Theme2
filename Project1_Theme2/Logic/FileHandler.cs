using System.Text.Json;
using System.Text.Json.Serialization;
using Project1_Theme2.Models;

namespace Project1_Theme2.Logic;

public static class FileHandler
{
    private static readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    private const string FileName = "save.json";

    public static bool IsFileExist()
    {
        return File.Exists(FileName);
    }

    public static void Save()
    {
        var json = JsonSerializer.Serialize(Menu.GetFigures(), _options);
        File.WriteAllText(FileName, json);
    }

    public static Dictionary<int, List<Figure>> Load()
    {
        var json = File.ReadAllText(FileName);
        var obj = JsonSerializer.Deserialize<Dictionary<int, List<Figure>>>(json, _options);
        return obj;
    }
}
