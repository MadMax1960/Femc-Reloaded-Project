using p3rpc.classconstructor.Interfaces;
using p3rpc.commonmodutils;
using p3rpc.femc.Configuration;
using Reloaded.Hooks.Definitions;
using Reloaded.Memory;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using SharedScans.Interfaces;
using UE.Toolkit.Interfaces;

namespace p3rpc.femc
{
    public class FemcContext : UnrealContext
    {
        public new Config _config { get; set; } // hide original config
        public readonly ConfigColor ColorBlack = new ConfigColor(0x0, 0x0, 0x0, 0xff);
        public readonly ConfigColor ColorWhite = new ConfigColor(0xff, 0xff, 0xff, 0xff);
        public bool bIsAigis { get; init; }
        public bool bIsSteam { get; set; }
       
        public IUnrealMemory _toolkitMemory { get; private set; }
        public IUnrealClasses _toolkitClasses { get; private set; }
        public IUnrealObjects _toolkitObjects { get; private set; }

        public FemcContext(long baseAddress, IConfigurable config, ILogger logger, IStartupScanner startupScanner, 
            IReloadedHooks hooks, string modLocation, Utils utils, Memory memory, ISharedScans sharedScans, 
            IClassMethods classMethods, IObjectMethods objectMethods, bool _bIsAigis,
            IUnrealMemory toolkitMemory, IUnrealClasses toolkitClasses, IUnrealObjects toolkitObjects)
            : base (baseAddress, config, logger, startupScanner, hooks, modLocation, utils, memory, sharedScans, classMethods, objectMethods) 
        {
            _config = (Config)config;
            bIsAigis = _bIsAigis;
            bIsSteam = true;
            _toolkitMemory = toolkitMemory;
            _toolkitClasses = toolkitClasses;
            _toolkitObjects = toolkitObjects;
        }

        public override void OnConfigUpdated(IConfigurable newConfig) => _config = (Config)newConfig;
    }
}
