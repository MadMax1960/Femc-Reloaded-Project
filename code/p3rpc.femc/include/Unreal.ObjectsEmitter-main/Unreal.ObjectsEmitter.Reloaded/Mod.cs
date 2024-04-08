using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using System.Drawing;
using Unreal.ObjectsEmitter.Interfaces;
using Unreal.ObjectsEmitter.Reloaded.Configuration;
using Unreal.ObjectsEmitter.Reloaded.DataTables;
using Unreal.ObjectsEmitter.Reloaded.Objects;
using Unreal.ObjectsEmitter.Reloaded.Template;
using Unreal.ObjectsEmitter.Reloaded.Unreal;

namespace Unreal.ObjectsEmitter.Reloaded;

public class Mod : ModBase, IExports
{
    private readonly IModLoader modLoader;
    private readonly IReloadedHooks? hooks;
    private readonly ILogger log;
    private readonly IMod owner;

    private Config config;
    private readonly IModConfig modConfig;

    private readonly UnrealService unreal;
    private readonly DataTablesService dataTables;
    private readonly UObjectsService uobjects;

    public Mod(ModContext context)
    {
        this.modLoader = context.ModLoader;
        this.hooks = context.Hooks!;
        this.log = context.Logger;
        this.owner = context.Owner;
        this.config = context.Configuration;
        this.modConfig = context.ModConfig;

        Log.Initialize("UE.Obj.Emitter", this.log, Color.Aquamarine);
        Log.LogLevel = this.config.LogLevel;

        this.unreal = new();
        this.dataTables = new(this.unreal);
        this.uobjects = new(this.unreal);

        this.modLoader.AddOrReplaceController<IUnreal>(this.owner, this.unreal);
        this.modLoader.AddOrReplaceController<IDataTables>(this.owner, this.dataTables);
        this.modLoader.AddOrReplaceController<IUObjects>(this.owner, this.uobjects);

        this.ApplyConfig();
        this.modLoader.GetController<IStartupScanner>().TryGetTarget(out var scanner);
        ScanHooks.Initialize(scanner!, this.hooks);
    }

    private void ApplyConfig()
    {
        Log.LogLevel = this.config.LogLevel;
        this.dataTables.SetLogTables(this.config.LogTables);
        this.uobjects.SetLogObjects(this.config.LogObjects);
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

    public Type[] GetTypes() => new Type[] { typeof(IUnreal), typeof(IDataTables), typeof(IUObjects) };
    #endregion

    #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Mod() { }
#pragma warning restore CS8618
    #endregion
}