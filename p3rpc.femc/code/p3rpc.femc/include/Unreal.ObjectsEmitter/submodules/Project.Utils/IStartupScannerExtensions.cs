using Reloaded.Hooks.Definitions;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;

namespace Project.Utils;

public static class IStartupScannerExtensions
{
    public static void Scan<T>(
        this IStartupScanner scanner,
        IReloadedHooks hooks,
        string name,
        string pattern,
        out IFunction<T>? function)
    {
        IFunction<T>? innerFunction = default;
        scanner.AddMainModuleScan(pattern, result =>
        {
            if (!result.Found)
            {
                Log.Error($"Failed to find pattern for {name}. Pattern: {pattern}");
                return;
            }

            var address = Utilities.BaseAddress + result.Offset;
            innerFunction = hooks.CreateFunction<T>(address);
        });

        function = innerFunction;
    }

    public static void Scan(
        this IStartupScanner scanner,
        string name,
        string pattern,
        Action<nint> callback)
    {
        scanner.AddMainModuleScan(pattern, result =>
        {
            if (!result.Found)
            {
                Log.Error($"Failed to find pattern for {name}. Pattern: {pattern}");
                return;
            }

            var address = Utilities.BaseAddress + result.Offset;
            Log.Information($"{name} found at: {address:X}");
            callback(address);
        });
    }

    public static void FunctionScan<T>(
        this IStartupScanner scanner,
        IReloadedHooks hooks,
        string name,
        string pattern,
        Action<IFunction<T>> callback)
    {
        scanner.AddMainModuleScan(pattern, result =>
        {
            if (!result.Found)
            {
                Log.Error($"Failed to find pattern for {name}. Pattern: {pattern}");
                return;
            }

            var address = Utilities.BaseAddress + result.Offset;
            var function = hooks.CreateFunction<T>(address);

            Log.Information($"{name} found at: {address:X}");
            callback(function);
        });
    }
}
