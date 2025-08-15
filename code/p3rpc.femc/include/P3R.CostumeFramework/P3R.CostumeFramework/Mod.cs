using BGME.BattleThemes.Interfaces;
using BGME.Framework.Interfaces;
using P3R.CostumeFramework.Configuration;
using P3R.CostumeFramework.Costumes;
using P3R.CostumeFramework.Interfaces;
using P3R.CostumeFramework.Template;
using p3rpc.classconstructor.Interfaces;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using Ryo.Interfaces;
using System.Diagnostics;
using System.Drawing;
using Unreal.AtlusScript.Interfaces;
using Unreal.ObjectsEmitter.Interfaces;

namespace P3R.CostumeFramework;

public class Mod : ModBase, IExports
{
    public const string NAME = "P3R.CostumeFramework";

    private readonly IModLoader modLoader;
    private readonly IReloadedHooks? hooks;
    private readonly ILogger log;
    private readonly IMod owner;

    private Config config;
    private readonly IModConfig modConfig;

    private readonly CostumeService costumes;
    private readonly CostumeApi costumeApi;
    private readonly CostumeRegistry costumeRegistry;
    private readonly CostumeDescService costumeDesc;
    private readonly CostumeMusicService costumeMusic;
    private readonly CostumeRyoService costumeRyo;
    private readonly CostumeOverridesRegistry costumeOverrides;

    public Mod(ModContext context)
    {
        this.modLoader = context.ModLoader;
        this.hooks = context.Hooks!;
        this.log = context.Logger;
        this.owner = context.Owner;
        this.config = context.Configuration;
        this.modConfig = context.ModConfig;

#if DEBUG
        Debugger.Launch();
#endif

        Project.Init(this.modConfig, this.modLoader, this.log);
        Log.LogLevel = this.config.LogLevel;

        this.modLoader.GetController<IStartupScanner>().TryGetTarget(out var scanner);
        this.modLoader.GetController<IUObjects>().TryGetTarget(out var uobjects);
        this.modLoader.GetController<IUnreal>().TryGetTarget(out var unreal);
        this.modLoader.GetController<IDataTables>().TryGetTarget(out var dataTables);
        this.modLoader.GetController<IAtlusAssets>().TryGetTarget(out var atlusAssets);
        this.modLoader.GetController<IBgmeApi>().TryGetTarget(out var bgme);
        this.modLoader.GetController<IBattleThemesApi>().TryGetTarget(out var battleThemes);
        this.modLoader.GetController<IRyoApi>().TryGetTarget(out var ryo);
        this.modLoader.GetController<IObjectMethods>().TryGetTarget(out var objMethods);

        var enabledMods = this.modLoader.GetAppConfig().EnabledMods;
        var eoEnabled = enabledMods.Contains("p3r.skins.extendedoutfits");
        var femcEnabled = enabledMods.Contains("p3rpc.femc");

        this.costumeRegistry = new(ryo!, this.config.CostumeFilter, eoEnabled);
        this.costumeOverrides = new(this.costumeRegistry);
        this.costumeDesc = new(atlusAssets!);
        this.costumeMusic = new(bgme!, battleThemes!, this.costumeRegistry);
        this.costumeRyo = new(ryo!);
        this.costumes = new(uobjects!, unreal!, dataTables!, this.costumeRegistry, this.costumeOverrides, this.costumeDesc, this.costumeMusic, this.costumeRyo, objMethods!, femcEnabled);

        this.costumeApi = new CostumeApi(costumeRegistry, costumeOverrides);
        this.modLoader.AddOrReplaceController<ICostumeApi>(this.owner, this.costumeApi);
        this.ApplyConfig();

        this.modLoader.ModLoaded += this.OnModLoaded;
        Project.Start();
    }

    private void OnModLoaded(IModV1 mod, IModConfigV1 config)
    {
        if (!config.ModDependencies.Contains(this.modConfig.ModId))
        {
            return;
        }

        var modDir = this.modLoader.GetDirectoryForModId(config.ModId);
        this.costumeRegistry.RegisterMod(config.ModId, modDir);

        var overridesFile = Path.Join(modDir, "costumes", "overrides.yaml");
        if (File.Exists(overridesFile))
        {
            this.costumeOverrides.AddOverridesFile(overridesFile);
        }
    }

    private void ApplyConfig()
    {
        Log.LogLevel = this.config.LogLevel;
        this.costumes.SetConfig(this.config);
        this.costumeMusic.SetConfig(this.config);
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

    public Type[] GetTypes() => [ typeof(ICostumeApi) ];
    #endregion

    #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public Mod() { }
#pragma warning restore CS8618
    #endregion
}