using p3rpc.femc.Components;
using p3rpc.femc.Configuration;
using p3rpc.femc.Template;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using System;
using System.Diagnostics;
using System.Reflection;

namespace p3rpc.femc
{
    /// <summary>
    /// Your mod logic goes here.
    /// </summary>
    public class Mod : ModBase // <= Do not Remove.
    {
        /// <summary>
        /// Provides access to the mod loader API.
        /// </summary>
        private readonly IModLoader _modLoader;

        /// <summary>
        /// Provides access to the Reloaded.Hooks API.
        /// </summary>
        /// <remarks>This is null if you remove dependency on Reloaded.SharedLib.Hooks in your mod.</remarks>
        private readonly IReloadedHooks? _hooks;

        /// <summary>
        /// Provides access to the Reloaded logger.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Entry point into the mod, instance that created this class.
        /// </summary>
        private readonly IMod _owner;

        /// <summary>
        /// Provides access to this mod's configuration.
        /// </summary>
        private Config _configuration;

        /// <summary>
        /// The configuration of the currently executing mod.
        /// </summary>
        private readonly IModConfig _modConfig;

        private Context _context;
        private Dictionary<string, ModuleBase> _modules;

        public Mod(ModContext context)
        {
            _modLoader = context.ModLoader;
            _hooks = context.Hooks;
            _logger = context.Logger;
            _owner = context.Owner;
            _configuration = context.Configuration;
            _modConfig = context.ModConfig;

            var baseAddress = Process.GetCurrentProcess().MainModule.BaseAddress;
            _modLoader.GetController<IStartupScanner>().TryGetTarget(out var startupScanner);
            if (startupScanner == null || _hooks == null) throw new Exception("Missing dependencies : startup scanner, hooks");
            Utils utils = new(startupScanner, _logger, _hooks, baseAddress);
            _context = new(baseAddress, _configuration, _logger, startupScanner, _hooks, _modLoader.GetDirectoryForModId(_modConfig.ModId), utils);
            _modules = new();
            AddModule<UICommon>();
            if (_configuration.EnableMailIcon) AddModule<MailIcon>();
            if (_configuration.EnableCampMenu) AddModule<Camp>();
            if (_configuration.EnableCampMenu) AddModule<DateTimePanel>();
            if (_configuration.EnableTextbox)
            {
                AddModule<MsgWindowSimple>();
                AddModule<MsgWindowSelectSimple>();
            }
            if (_configuration.EnableMindMessageBox)
            {
                AddModule<MsgWindowMind>();
                AddModule<MsgWindowSelectMind>();
            }
            if (_configuration.EnableInteractPrompt) AddModule<MiscCheckDraw>();
            if (_configuration.EnableMinimap)
            {
                AddModule<Minimap>();
                //AddModule<LocationSelect>();
            }

            foreach (var mod in _modules.Values) mod.Register();
        }

        private void AddModule<T>() where T : ModuleBase
        {
            Type typeInfo = typeof(T);
            ConstructorInfo construct = typeInfo.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public, null, CallingConventions.HasThis,
                new Type[] { typeof(Context), typeof(Dictionary<string, ModuleBase>)}, null
            );
            if (construct != null)
            {
                T newModule = (T)construct.Invoke(new object[] { _context, _modules });
                _modules.Add(typeInfo.Name, newModule);
                _context._utils.Log($"Added module {typeInfo.Name}");
            }
            else
            {
                throw new Exception($"Could not find appropriate constructor for type {typeInfo.Name}");
            }
        }

        #region Standard Overrides
        public override void ConfigurationUpdated(Config configuration)
        {
            // Apply settings from configuration.
            // ... your code here.
            _configuration = configuration;
            _logger.WriteLine($"[{_modConfig.ModId}] Config Updated: Applying");
            foreach (var mod in _modules.Values) mod.OnConfigUpdated(configuration);
        }
        #endregion

        #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Mod() { }
#pragma warning restore CS8618
        #endregion
    }
}