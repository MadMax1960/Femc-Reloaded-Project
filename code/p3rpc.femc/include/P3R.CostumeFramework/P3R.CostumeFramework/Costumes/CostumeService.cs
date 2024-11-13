using P3R.CostumeFramework.Configuration;
using P3R.CostumeFramework.Hooks;
using P3R.CostumeFramework.Hooks.Animations;
using P3R.CostumeFramework.Hooks.Costumes;
using P3R.CostumeFramework.Hooks.Services;
using p3rpc.classconstructor.Interfaces;
using Unreal.ObjectsEmitter.Interfaces;

namespace P3R.CostumeFramework.Costumes;

internal unsafe class CostumeService
{
    private readonly CostumeHooks costumeHooks;
    private readonly CostumeManager costumeManager;
    private readonly ItemCountHook itemCountHook;
    private readonly CostumeNameHook costumeNameHook;
    private readonly ItemEquip itemEquip;
    private readonly CostumeAlloutService alloutService;
    private readonly CostumeTableService costumeTable;
    private readonly CostumeShellService costumeShells;
    private readonly CostumeAnimsService costumeAnims;

    public CostumeService(
        IUObjects uobjs,
        IUnreal unreal,
        IDataTables dt,
        CostumeRegistry registry,
        CostumeOverridesRegistry overrides,
        CostumeDescService costumeDesc,
        CostumeMusicService costumeMusic,
        CostumeRyoService costumeAudio,
        IObjectMethods objMethods,
        bool useFemcPlayer)
    {
        this.itemEquip = new(registry);
        this.costumeTable = new(dt, unreal, registry, useFemcPlayer);
        this.costumeShells = new(dt, registry, this.costumeTable);
        this.costumeAnims = new(uobjs, unreal, objMethods, this.costumeTable);
        this.costumeHooks = new(uobjs, unreal, registry, overrides, costumeDesc, costumeMusic, costumeAudio, this.costumeShells, this.itemEquip);
        this.costumeManager = new(this.costumeHooks);
        this.alloutService = new(dt, unreal, this.costumeManager);
        this.itemCountHook = new(registry);
        this.costumeNameHook = new(uobjs, unreal, registry);

        this.costumeHooks.OnCostumeChanged += costume =>
        {
            costumeMusic.Refresh(costume);
            costumeAudio.Refresh(costume);
            //costumeAnims.UpdateCostumeAnims(costume);
        };
    }

    public void SetConfig(Config config)
    {
        this.costumeHooks.SetRandomizeCostumes(config.RandomizeCostumes);
        this.costumeHooks.SetOverworldCostumes(config.OverworldCostumes);
    }
}