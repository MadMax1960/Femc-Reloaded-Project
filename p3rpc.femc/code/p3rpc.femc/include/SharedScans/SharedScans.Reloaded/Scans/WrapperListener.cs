using Reloaded.Hooks.Definitions;
using SharedScans.Interfaces;

namespace SharedScans.Reloaded.Scans;

internal class WrapperListener<TFunction> : IScanListener
{
    public WrapperListener(string owner, string id)
    {
        this.Wrapper = new()
        {
            Owner = owner,
            Id = id,
        };
    }

    public string Id => this.Wrapper.Id;

    public WrapperContainer<TFunction> Wrapper { get; }

    public void SetScanFound(IReloadedHooks hooks, nint result)
    {
        this.Wrapper.Wrapper = hooks.CreateWrapper<TFunction>(result, out _);
        Log.Debug($"Wrapper created for: {this.Wrapper.Owner} || ID: {this.Wrapper.Id}");
    }
}
