using SharedScans.Interfaces;

namespace SharedScans.Reloaded.Scans;

internal class SharedScansService : ISharedScans
{
    private readonly ScansManager scansManager;
    private readonly List<IScanListener> listeners = new();

    public SharedScansService(ScansManager scansManager)
    {
        this.scansManager = scansManager;
    }

    public void AddScan(string id, string? pattern)
    {
        if (string.IsNullOrEmpty(pattern))
        {
            Log.Verbose($"{id}: No pattern given.");
            return;
        }

        this.scansManager.Add(id, pattern, (hooks, result) =>
        {
            var scanListeners = this.listeners.Where(x => x.Id == id).ToArray();
            foreach (var listener in scanListeners)
            {
                listener.SetScanFound(hooks, result);
            }

            if (scanListeners.Length > 0)
            {
                Log.Information($"Scan for \"{id}\" given to {scanListeners.Length} listener(s).");
            }
        });
    }

    public void AddScan<TFunction>(string? pattern)
        => this.AddScan(typeof(TFunction).Name, pattern);

    public void CreateListener(string id, Action<nint> success)
    {
        var listener = new ResultListener(id, success);
        this.listeners.Add(listener);
    }

    public void CreateListener<TFunction>(Action<nint> success)
        => this.CreateListener(typeof(TFunction).Name, success);

    public HookContainer<TFunction> CreateHook<TFunction>(TFunction hookFunction, string owner)
    {
        var id = typeof(TFunction).Name;
        var listener = new HookListener<TFunction>(owner, id, hookFunction);
        this.listeners.Add(listener);
        return listener.Hook;
    }

    public WrapperContainer<TFunction> CreateWrapper<TFunction>(string owner)
    {
        var id = typeof(TFunction).Name;
        var listener = new WrapperListener<TFunction>(owner, id);
        this.listeners.Add(listener);
        return listener.Wrapper;
    }
}
