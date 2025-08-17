using P3R.CostumeFramework.Costumes.Models;
using P3R.CostumeFramework.Types;
using Ryo.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace P3R.CostumeFramework.Costumes;

internal class CostumeRegistry
{
    private readonly CostumeFactory costumeFactory;

    public CostumeRegistry(IRyoApi ryo, CostumeFilter filter, bool useExtendedOutfits)
    {
        this.Costumes = new(filter, useExtendedOutfits);
        this.costumeFactory = new(ryo, this.Costumes);
    }

    public GameCostumes Costumes { get; }

    public Costume[] GetActiveCostumes()
        => this.Costumes.Where(IsActiveCostume).ToArray();

    public Costume? GetRandomCostume(Character character)
    {
        var costumes = this.GetActiveCostumes().Where(x => x.Character == character).ToArray();
        if (costumes.Length < 1)
        {
            return null;
        }

        return costumes[Random.Shared.Next(0, costumes.Length)];
    }

    public bool TryGetCostume(Character character, int costumeId, [NotNullWhen(true)] out Costume? costume)
    {
        costume = this.Costumes.FirstOrDefault(x => IsRequestedCostume(x, character, costumeId));
        
        // For Aigis, also check for any costumes under her Astrea ID.
        if (costume == null && character == Character.Aigis)
        {
            costume = this.Costumes.FirstOrDefault(x => IsRequestedCostume(x, Character.AigisReal, costumeId));
        }
        
        if (costume != null)
        {
            return true;
        }

        return false;
    }

    public bool TryGetCostumeByItemId(int itemId, [NotNullWhen(true)] out Costume? costume)
    {
        var costumeItemId = Costume.GetCostumeItemId(itemId);
        costume = this.Costumes.FirstOrDefault(x => x.CostumeItemId == costumeItemId && IsActiveCostume(x));
        return costume != null;
    }

    public void RegisterMod(string modId, string modDir)
    {
        var mod = new CostumeMod(modId, modDir);
        if (!Directory.Exists(mod.CostumesDir))
        {
            return;
        }

        foreach (var character in Enum.GetValues<Character>())
        {
            var characterDir = Path.Join(mod.CostumesDir, character.ToString());
            if (!Directory.Exists(characterDir))
            {
                continue;
            }

            // Build costumes from folders.
            foreach (var costumeDir in Directory.EnumerateDirectories(characterDir))
            {
                try
                {
                    this.costumeFactory.Create(mod, costumeDir, character);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, $"Failed to create costume from folder.\nFolder: {costumeDir}");
                }
            }
        }
    }

    private static bool IsRequestedCostume(Costume costume, Character character, int costumeId)
    {
        if (costume.Character == character
            && costume.CostumeId == costumeId
            && IsActiveCostume(costume))
        {
            return true;
        }

        return false;
    }

    private static bool IsActiveCostume(Costume costume)
        => costume.IsEnabled
        && costume.Character != Character.NONE;
}
