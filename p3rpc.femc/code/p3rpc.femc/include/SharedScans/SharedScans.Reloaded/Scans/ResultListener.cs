using Reloaded.Hooks.Definitions;

namespace SharedScans.Reloaded.Scans;

public class ResultListener : IScanListener
{
    private readonly Action<nint> success;

    public ResultListener(string id, Action<nint> success)
    {
        this.Id = id;
        this.success = success;
    }

    public string Id { get; }

    public void SetScanFound(IReloadedHooks hooks, nint result)
        => this.success.Invoke(result);
}
