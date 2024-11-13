using System.Reflection;
using System.Text.Json;

namespace P3R.CostumeFramework.Hooks.Animations.Models;

public class GameBones
{
    private readonly Dictionary<int, string> reversed;

    public GameBones()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "P3R.CostumeFramework.Resources.bones.json";
        using var stream = assembly.GetManifestResourceStream(resourceName)!;
        using var reader = new StreamReader(stream);
        var json = reader.ReadToEnd();
        var bones = JsonSerializer.Deserialize<BonesSerialized>(json) ?? throw new Exception("Failed to load bones.");
        reversed = bones.FinalNameToIndexMap.ToDictionary(x => x.Value, x => x.Key);
    }

    public string this[int index] => reversed[index];

    private class BonesSerialized
    {
        public Dictionary<string, int> FinalNameToIndexMap { get; set; } = [];
    }
}