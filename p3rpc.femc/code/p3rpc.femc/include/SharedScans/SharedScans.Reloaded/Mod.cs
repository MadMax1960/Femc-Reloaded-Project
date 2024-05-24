using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using SharedScans.Interfaces;
using SharedScans.Reloaded.Configuration;
using SharedScans.Reloaded.Scans;
using SharedScans.Reloaded.Template;
using System.Diagnostics;
using System.Drawing;

namespace SharedScans.Reloaded;

public class Mod : ModBase, IExports
{
    private readonly IModLoader modLoader;
    private readonly IReloadedHooks hooks;
    private readonly ILogger log;
    private readonly IMod owner;

    private Config config;
    private readonly IModConfig modConfig;

    private readonly SharedScansService scans;

    public Mod(ModContext context)
    {
        this.modLoader = context.ModLoader;
        this.hooks = context.Hooks!;
        this.log = context.Logger;
        this.owner = context.Owner;
        this.config = context.Configuration;
        this.modConfig = context.ModConfig;

        Log.Initialize("SharedScans", this.log, Color.White);
        Log.LogLevel = this.config.LogLevel;

#if DEBUG
        Debugger.Launch();
#endif

        this.modLoader.GetController<IStartupScanner>().TryGetTarget(out var scanner);
        this.scans = new(new(scanner!, this.hooks));
        this.modLoader.AddOrReplaceController<ISharedScans>(this.owner, this.scans);

        this.ApplyConfig();
    }

    private void ApplyConfig()
    {
        Log.LogLevel = this.config.LogLevel;
    }

    #region Standard Overrides
    public override void ConfigurationUpdated(Config configuration)
    {
        // Apply settings from configuration.
        // ... your code here.
        config = configuration;
        log.WriteLine($"[{modConfig.ModId}] Config Updated: Applying");
        this.ApplyConfig();
    }

    public Type[] GetTypes() => new Type[] { typeof(ISharedScans) };
    #endregion

    #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Mod() { }
#pragma warning restore CS8618
    #endregion
}