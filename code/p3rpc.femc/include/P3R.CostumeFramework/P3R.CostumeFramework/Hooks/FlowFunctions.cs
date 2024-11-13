using Reloaded.Hooks.Definitions.X64;

namespace P3R.CostumeFramework.Hooks;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
internal class FlowFunctions
{
    [Function(CallingConventions.Microsoft)]
    public delegate int GET_PARTY(int index);

    public FlowFunctions()
    {
        ScanHooks.Add(
            nameof(GET_PARTY),
            "40 53 48 83 EC 20 8B D9 E8 ?? ?? ?? ?? 48 85 C0 75 ?? 48 83 C4 20 5B C3 8B D3 48 8B C8 E8",
            (hooks, result) => this.GetParty = hooks.CreateWrapper<GET_PARTY>(result, out _));
    }

    public GET_PARTY GetParty { get; private set; }
}
