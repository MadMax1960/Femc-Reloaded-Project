using Reloaded.Hooks.Definitions;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;

namespace SharedScans.Reloaded.Scans;

internal class ScansManager
{
    private readonly IStartupScanner scanner;
    private readonly IReloadedHooks hooks;

    public ScansManager(IStartupScanner scanner, IReloadedHooks hooks)
    {
        this.scanner = scanner;
        this.hooks = hooks;
    }

    /// <summary>
    /// Add a new scan hook.
    /// </summary>
    /// <param name="name">Name of scan.</param>
    /// <param name="pattern">Pattern to scan for.</param>
    /// <param name="success">Success action with hooks and result.</param>
    public void Add(string name, string pattern, Action<IReloadedHooks, nint> success)
    {
        this.scanner.Scan(name, pattern, result => success.Invoke(this.hooks, result));
    }
}
