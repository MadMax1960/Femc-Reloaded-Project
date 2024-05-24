using Reloaded.Hooks.Definitions;

namespace SharedScans.Reloaded.Scans;

public interface IScanListener
{
    string Id { get; }

    void SetScanFound(IReloadedHooks hooks, nint result);
}
