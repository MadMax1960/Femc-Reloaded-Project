using Reloaded.Hooks.Definitions;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;

namespace Project.Utils;

public interface IGameHook
{
    void Initialize(IStartupScanner scanner, IReloadedHooks hooks);
}
