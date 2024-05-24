using Reloaded.Hooks.Definitions;
using SharedScans.Interfaces;

namespace SharedScans.Reloaded.Scans;

public class HookListener<TFunction> : IScanListener
{
    public HookListener(string owner, string id, TFunction hookFunction)
    {
        this.Hook = new()
        {
            Owner = owner,
            Id = id,
            HookFunction = hookFunction,
        };
    }

    public string Id => this.Hook.Id;

    public HookContainer<TFunction> Hook { get; }

    public void SetScanFound(IReloadedHooks hooks, nint result)
    {
        var reloadedHook = hooks.CreateHook(this.Hook.HookFunction, result).Activate();
        this.Hook.Hook = reloadedHook;

        Log.Debug($"Hook created for: {this.Hook.Owner} || ID: {this.Hook.Id}");
    }
}
