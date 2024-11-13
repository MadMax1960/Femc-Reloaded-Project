namespace P3R.CostumeFramework.Costumes.Models;

public record CostumeMod(string ModId, string ModDir)
{
    public string ContentDir { get; } = Path.Join(ModDir, "UnrealEssentials", "P3R", "Content");

    public string CostumesDir { get; } = Path.Join(ModDir, "UnrealEssentials", "P3R", "Content", "Costumes");
};
