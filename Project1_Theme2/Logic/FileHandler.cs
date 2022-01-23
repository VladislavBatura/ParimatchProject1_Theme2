using System.Text.Json;
using System.Text.Json.Serialization;
using Project1_Theme2.Models;

namespace Project1_Theme2.Logic;

public static class FileHandler
{
    private static readonly JsonSerializerOptions _options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonHandler() },
        WriteIndented = true
    };

    private const string FileName = "save.json";

    public static bool IsFileExist()
    {
        return File.Exists(FileName);
    }

    public static void Save()
    {
        var figures = Menu.GetFigures();

        if (figures.Values.Count == 0)
        {
            return;
        }

        var listOrderedFigures = new List<Figure>();
        foreach (var f in figures)
        {
            listOrderedFigures = listOrderedFigures.Union(f.Value).ToList();
        }

        var json = JsonSerializer.Serialize(listOrderedFigures, _options);
        File.WriteAllText(FileName, json);
    }

    public static List<Figure> Load()
    {
        var json = File.ReadAllText(FileName);
        var obj = JsonSerializer.Deserialize<List<Figure>>(json, _options);
        return obj;
    }
}
