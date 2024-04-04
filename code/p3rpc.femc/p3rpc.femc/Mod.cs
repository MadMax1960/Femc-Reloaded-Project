using p3rpc.commonmodutils;
using p3rpc.femc.Components;
using p3rpc.femc.Configuration;
using p3rpc.femc.Template;
using Reloaded.Hooks.Definitions;
using Reloaded.Memory;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using SharedScans.Interfaces;
using System;
using System.Diagnostics;
using System.Reflection;
using UnrealEssentials.Interfaces;
using static p3rpc.femc.Configuration.Config;

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

        private FemcContext _context;
        private ModuleRuntime<FemcContext> _modRuntime;

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
            if (startupScanner == null) throw new Exception("[Femc Project] Could not get controller for Reloaded startup scanner");
            if (_hooks == null) throw new Exception("[Femc Project] Could not get controller for Reloaded hooks");
            _modLoader.GetController<ISharedScans>().TryGetTarget(out var sharedScans);
            if (sharedScans == null) throw new Exception("[Femc Project] Could not get controller for Shared Scans");
            Utils utils = new(startupScanner, _logger, _hooks, baseAddress, "Femc Project", System.Drawing.Color.Thistle);
            var unrealEssentialsController = _modLoader.GetController<IUnrealEssentials>();
            if (unrealEssentialsController == null || !unrealEssentialsController.TryGetTarget(out var unrealEssentials))
            {
                utils.Log($"Unable to get controller for Unreal Essentials, stuff won't work :(", System.Drawing.Color.Red);
                return;
            }
            var memory = new Memory();
            _context = new(baseAddress, _configuration, _logger, startupScanner, _hooks, _modLoader.GetDirectoryForModId(_modConfig.ModId), utils, memory, sharedScans);
            _modRuntime = new(_context);

            try
            {
                if (_configuration.HairTrue == HairType.MudkipsHair)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "hair", "MudkipHair"));
                else if (_configuration.HairTrue == HairType.KotoneBeanHair)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "hair", "NaobeanHair"));

                if (_configuration.AOATrue == AOAType.Ainz)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "Ainz"));
                else if (_configuration.AOATrue == AOAType.Ely)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "Ely"));
                else if (_configuration.AOATrue == AOAType.Chrysanthie)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "Chrysanthie"));

                if (_configuration.AOAText == AOATextType.DontLookBack)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOAText", "DontLookBack"));
                else if (_configuration.AOAText == AOATextType.SorryBoutThat)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOAText", "SorryBoutThat"));

                if (_configuration.BustupTrue == BustupType.Neptune)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Neptune"));
                else if (_configuration.BustupTrue == BustupType.Ely)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Ely"));
                else if (_configuration.BustupTrue == BustupType.ElyOld)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "ElyOld"));
                else if (_configuration.BustupTrue == BustupType.Esa)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Esa"));
                else if (_configuration.BustupTrue == BustupType.Betina)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Betina"));
				

                if (_configuration.ShardTrue == ShardType.Esa)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Shard", "Esa"));
                else if (_configuration.ShardTrue == ShardType.Ely)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Shard", "Ely"));

                if (_configuration.LevelUpTrue == LevelUpType.Esa)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "LevelUp", "Esa"));
                else if (_configuration.LevelUpTrue == LevelUpType.Ely)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "LevelUp", "Ely"));

                if (_configuration.CutinTrue == CutinType.berrycha)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Cutin", "berrycha"));
                else if (_configuration.CutinTrue == CutinType.ElyandPatmandx)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Cutin", "ElyandPatmandx"));

                if (_configuration.KotoneRoom == true)
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Fun Stuff", "Kotone Room"));
            } catch (Exception ex)
            {
                _context._utils.Log($"An error occured trying to read addons: \"{ex.Message}\"", System.Drawing.Color.Red);
            }

            _modRuntime.AddModule<UICommon>();
            if (_configuration.EnableMailIcon) _modRuntime.AddModule<MailIcon>();
			if (_configuration.EnableCampMenu)
            {
                _modRuntime.AddModule<CampCommon>();
                _modRuntime.AddModule<CampRoot>();
                _modRuntime.AddModule<CampSkill>();
                _modRuntime.AddModule<CampItem>();
                _modRuntime.AddModule<CampEquip>();
                _modRuntime.AddModule<CampPersona>();
                _modRuntime.AddModule<CampStats>();
                _modRuntime.AddModule<CampSocialLink>();
                _modRuntime.AddModule<CampCalendar>();
                _modRuntime.AddModule<CampSystem>();
                _modRuntime.AddModule<SocialStats>();
                _modRuntime.AddModule<Tutorial>();
            }
            if (_configuration.EnableDateTimePanel) _modRuntime.AddModule<DateTimePanel>();
            if (_configuration.EnableTextbox)
            {
                _modRuntime.AddModule<MsgWindowSimpleCommon>();
                _modRuntime.AddModule<MsgWindowSimple>();
                _modRuntime.AddModule<MsgWindowSelectSimple>();
                _modRuntime.AddModule<MsgWindowAssist>();
                _modRuntime.AddModule<MsgWindowSystem>();
                _modRuntime.AddModule<GenericSelect>();
            }
            if (_configuration.EnableMindMessageBox)
            {
                _modRuntime.AddModule<MsgWindowMind>();
                _modRuntime.AddModule<MsgWindowSelectMind>();
            }
            if (_configuration.EnableInteractPrompt) _modRuntime.AddModule<MiscCheckDraw>();
            if (_configuration.EnableMinimap)
            {
                _modRuntime.AddModule<Minimap>();
                _modRuntime.AddModule<LocationSelect>();
            }
            if (_configuration.EnableBustup)
            {
                _modRuntime.AddModule<Bustup>();
            }
            if (_configuration.EnableMessageScript)
            {
                _modRuntime.AddModule<MessageScript>();
            }
            if (_configuration.EnableTownMap) _modRuntime.AddModule<TownMap>();
            if (_configuration.EnablePartyPanel) _modRuntime.AddModule<PartyPanel>();
            if (_configuration.EnableBacklog) _modRuntime.AddModule<Backlog>();
            if (_configuration.EnableButtonPrompts) _modRuntime.AddModule<KeyHelp>();
            if (_configuration.EnableGetItem) _modRuntime.AddModule<MiscGetItemDraw>();
            if (_configuration.EnableTimeSkip)
            {
                _modRuntime.AddModule<DayChange>();
                _modRuntime.AddModule<TimeChange>();
            }
            if (_configuration.EnablePersonaStatus) _modRuntime.AddModule<PersonaStatus>();
            if (_configuration.EnableNetworkFeatures)
            {
                _modRuntime.AddModule<VoiceAction>();
                _modRuntime.AddModule<VoiceAnswer>();
            }
            if (_configuration.EnableShop)
            {
                _modRuntime.AddModule<SimpleShop>();
                _modRuntime.AddModule<MiscMoneyDraw>();
            }
            if (_configuration.EnableCutin) _modRuntime.AddModule<Cutin>();
            if (_configuration.EnableTitleMenu)
            {
                _modRuntime.AddModule<TitleMenu>();
                _modRuntime.AddModule<DifficultySelection>();
            }
            if (_configuration.EnableStaffRoll)
            {
                _modRuntime.AddModule<LocalizationStaffRoll>();
                //_modRuntime.AddModule<StaffRoll>();
            }
            if (_configuration.EnableWipe) _modRuntime.AddModule<Wipe>();
            _modRuntime.RegisterModules();
        }
        #region Standard Overrides
        public override void ConfigurationUpdated(Config configuration)
        {
            // Apply settings from configuration.
            // ... your code here.
            _configuration = configuration;
            _logger.WriteLine($"[{_modConfig.ModId}] Config Updated: Applying");
            _modRuntime.UpdateConfiguration(configuration);
        }
        #endregion

        #region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Mod() { }
#pragma warning restore CS8618
        #endregion
    }
}