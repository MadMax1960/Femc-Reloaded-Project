using P3R.CostumeFramework.Costumes;
using P3R.CostumeFramework.Costumes.Models;
using System.Diagnostics.CodeAnalysis;

namespace P3R.CostumeFramework.Hooks;

internal unsafe class ItemEquip
{
    private delegate nint GetGlobalWork();
    private GetGlobalWork? getGlobalWork;

    private readonly CostumeRegistry costumes;

    public ItemEquip(CostumeRegistry costumes)
    {
        this.costumes = costumes;

        ScanHooks.Add(
            nameof(GetGlobalWork),
            "48 89 5C 24 ?? 57 48 83 EC 20 48 8B 0D ?? ?? ?? ?? 33 DB",
            (hooks, result) => this.getGlobalWork = hooks.CreateWrapper<GetGlobalWork>(result, out _));
    }

    public nint GetCharWork(Character character)
        => this.getGlobalWork!() + 0x1b0 + ((nint)character * 0x2b4);

    public int GetEquip(Character character, Equip equip)
        => *(ushort*)(this.GetCharWork(character) + 0x28c + ((nint)equip * 2));

    public bool TryGetEquipCostume(Character character, [NotNullWhen(true)]out Costume? costume)
    {
        var equipItemId = this.GetEquip(character, Equip.Outfit);
        return this.costumes.TryGetCostumeByItemId(equipItemId, out costume);
    }
}

public enum Equip
    : ushort
{
    Weapon,
    Armor,
    Footwear,
    Accessory,
    Outfit,
}
