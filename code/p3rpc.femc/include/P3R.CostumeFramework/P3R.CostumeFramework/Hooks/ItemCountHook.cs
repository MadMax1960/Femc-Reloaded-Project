using P3R.CostumeFramework.Costumes;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;

namespace P3R.CostumeFramework.Hooks;

internal class ItemCountHook
{
    [Function(CallingConventions.Microsoft)]
    private delegate int FUN_14c15cad0(int itemId);
    private IHook<FUN_14c15cad0>? hook;

    private delegate byte IsAstrea();
    private IsAstrea? isAstrea;

    private readonly CostumeRegistry registry;

    public ItemCountHook(CostumeRegistry registry)
    {
        this.registry = registry;
        ScanHooks.Add(
            "GET_ITEM_NUM",
            "49 89 E3 48 81 EC 88 00 00 00 48 8B 05 ?? ?? ?? ?? 48 31 E0",
            (hooks, result) => this.hook = hooks.CreateHook<FUN_14c15cad0>(this.Hook, result).Activate());
        
        ScanHooks.Add(nameof(IsAstrea),
            "48 83 EC 28 E8 ?? ?? ?? ?? 48 85 C0 74 ?? E8 ?? ?? ?? ?? 48 8B C8 E8 ?? ?? ?? ?? 3C 01 0F 94 C0 48 83 C4 28 C3 48 83 C4 28 C3",
            (hooks, result) => isAstrea = hooks.CreateWrapper<IsAstrea>(result, out _));
    }

    private int Hook(int itemId)
    {
        if (this.registry.TryGetCostumeByItemId(itemId, out var costume))
        {
            if (costume.Character == Character.AigisReal && isAstrea!() == 0)
            {
                return 0;
            }
            
            return 1;
        }

        return this.hook!.OriginalFunction(itemId);
    }
}
