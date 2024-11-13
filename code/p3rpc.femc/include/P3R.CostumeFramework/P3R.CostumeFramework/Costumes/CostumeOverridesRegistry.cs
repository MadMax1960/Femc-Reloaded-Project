using P3R.CostumeFramework.Costumes.Models;
using P3R.CostumeFramework.Utils;
using System.Diagnostics.CodeAnalysis;

namespace P3R.CostumeFramework.Costumes;

internal class CostumeOverridesRegistry(CostumeRegistry costumes)
{
    private readonly CostumeRegistry costumes = costumes;
    private readonly List<CostumeOverride> costumeOverrides = [];

    public bool TryGetCostumeOverride(Character character, int originalCostumeId, [NotNullWhen(true)]out Costume? newCostume)
    {
        // Get override.
        var costumeOverride = this.costumeOverrides.FirstOrDefault(x => x.Character == character && x.OriginalCostumeId == originalCostumeId);
        if (costumeOverride == null)
        {
            newCostume = null;
            return false;
        }

        // Get new costume.
        // Search all costumes instead of only enabled because:
        // - Extended Outfits add some base game costumes that CF disables to prevent duplicates.
        // - Filters can disable costumes but the game can still use them, not allowing for overrides.
        newCostume = this.costumes.Costumes.FirstOrDefault(x => x.Character == costumeOverride.Character
            && x.Name?.Equals(costumeOverride.NewCostumeName, StringComparison.OrdinalIgnoreCase) == true);
        if (newCostume == null)
        {
            Log.Warning($"Failed to find new costume from override: {character} || Costume: {costumeOverride.NewCostumeName}");
        }

        return newCostume != null;
    }

    public void AddOverridesFile(string file)
    {
        try
        {
            var overrides = YamlSerializer.DeserializeFile<CostumeOverrideSerialized[]>(file);
            foreach (var costumeOverride in overrides)
            {
                var character = Enum.Parse<Character>(costumeOverride.Character, true);

                // Parse costume ID as int.
                if (int.TryParse(costumeOverride.OriginalCostumeId, out var costumeId) == false)
                {
                    // Or find costume ID by name.
                    var existingCostume = this.costumes.GetActiveCostumes().FirstOrDefault(x => x.Name?.Equals(costumeOverride.OriginalCostumeId, StringComparison.OrdinalIgnoreCase) == true)
                        ?? throw new Exception($"Failed to find original costume by name. Costume: {costumeOverride.OriginalCostumeId}");

                    costumeId = existingCostume.CostumeId;
                }

                this.costumeOverrides.Add(new()
                {
                    Character = character,
                    OriginalCostumeId = costumeId,
                    NewCostumeName = costumeOverride.NewCostumeName,
                });

                Log.Information($"Costume override: {character} || Costume ID: {costumeOverride.OriginalCostumeId} || New: {costumeOverride.NewCostumeName}");
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Failed to load overrides file.\nFile: {file}");
        }
    }
}
