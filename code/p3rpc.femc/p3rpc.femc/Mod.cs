using P3R.CostumeFramework.Interfaces;
using p3rpc.classconstructor.Interfaces;
using p3rpc.commonmodutils;
using p3rpc.femc.Audio;
using p3rpc.femc.Components;
using p3rpc.femc.Configuration;
using p3rpc.femc.Template;
using p3rpc.femc.UeToolkit;
using Reloaded.Hooks.Definitions;
using Reloaded.Memory;
using Reloaded.Memory.Sigscan.Definitions;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using Ryo.Interfaces;
using SharedScans.Interfaces;
using System.Diagnostics;
using UE.Toolkit.Interfaces;
using Unreal.AtlusScript.Interfaces;
using UnrealEssentials.Interfaces;
using static p3rpc.femc.Configuration.Config;
using IUnrealMemory = UE.Toolkit.Interfaces.IUnrealMemory;



/// ok maybe p3rpc.femc.music.interfaces is required, but it's not in repo and randomization doesn't work leading me to believe they're connected, or randomization never worked idk

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
		private readonly MusicManager _musicManager;
		private AssetRedirector _assetRedirector;
		private readonly ICostumeApi _costumeApi;
		private ArmorData _armorData;




        private string modName { get; set; }

		public Mod(ModContext context)
		{
            _modLoader = context.ModLoader;
			_hooks = context.Hooks;
			_logger = context.Logger;
			_owner = context.Owner;
			_configuration = context.Configuration;
			_modConfig = context.ModConfig;

			var process = Process.GetCurrentProcess();
			if (process.MainModule == null) throw new Exception($"[{_modConfig.ModName}] Could not get main module (this should never happen)");
			var baseAddress = process.MainModule.BaseAddress;
            var scannerFactory = GetDependency<IScannerFactory>("Scanner Factory");
            var startupScanner = GetDependency<IStartupScanner>("Reloaded Startup Scanner");
			if (_hooks == null) throw new Exception($"[{_modConfig.ModName}] Could not get controller for Reloaded hooks");
			var sharedScans = GetDependency<ISharedScans>("Shared Scans");
			Utils utils = new(startupScanner, _logger, _hooks, baseAddress, "Femc Project", System.Drawing.Color.Thistle, _configuration.DebugLogLevel);
			var unrealEssentials = GetDependency<IUnrealEssentials>("Unreal Essentials");
			var classMethods = GetDependency<IClassMethods>("Class Constructor (Class Methods)");
            var objectMethods = GetDependency<IObjectMethods>("Class Constructor (Object Methods)");
			var uObjects = GetDependency<IUnrealObjects>("UE Toolkit (IUObjects)");
            var toolKit = GetDependency<IToolkit>("UE Toolkit (IToolkit");
            var unrealMemory = GetDependency<IUnrealMemory>("UE Toolkit (IUnrealMemory)");
            var unrealNames = GetDependency<IUnrealNames>("UE Toolkit (IUnrealNames)");
			var atlusScript = GetDependency<IAtlusAssets>("Unreal Atlus Script (IAtlusAssets)");
            _costumeApi = GetDependency<ICostumeApi>("Costume Framework");

			var ryo = GetDependency<IRyoApi>("Ryo Framework");
            var memory = new Memory();

            // Check what game version this is
            var scanner = scannerFactory.CreateScanner(process, process.MainModule);
            var res = scanner.FindPattern("48 8B C4 48 89 48 ?? 55 41 54 48 8D 68 ?? 48 81 EC 48 01 00 00");
			bool bIsAigis = false;
			if (!res.Found)
			{
				_logger.WriteLine("Error! Couldn't find the pattern for UAppCharacterComp::Update! We'll assume that this is Episode Aigis.", System.Drawing.Color.Red);
				bIsAigis = true;
            }
			unsafe
			{
                if (*(byte*)(baseAddress + res.Offset + 0x254) == 0x75)
                {
                    _logger.WriteLine("Set hooks to use Episode Aigis.");
                    bIsAigis = true;
                }
            }

            _context = new(baseAddress, _configuration, _logger, startupScanner, _hooks, _modLoader.GetDirectoryForModId(_modConfig.ModId), utils, memory, sharedScans, classMethods, objectMethods, bIsAigis);
			_modRuntime = new(_context);
			_musicManager = new MusicManager(_modLoader, _modConfig, _configuration, ryo, _logger, _context);
            _armorData = new(_modLoader, _modConfig, _configuration, uObjects, toolKit, _context);

            modName = _modConfig.ModName;
			// Load Modules/assets
			LoadEnabledAddons(unrealEssentials, ryo, atlusScript);
			InitializeModules();
			_assetRedirector = new AssetRedirector(unrealNames, modName);
			_assetRedirector.RedirectPlayerAssets();
			_musicManager.GenerateMusicScript();
		}

		private IControllerType GetDependency<IControllerType>(string modName) where IControllerType : class
		{
			var controller = _modLoader.GetController<IControllerType>();
			if (controller == null || !controller.TryGetTarget(out var target))
				throw new Exception($"[{_modConfig.ModName}] Could not get controller for \"{modName}\". This depedency is likely missing.");
			return target;

		}

        private void LoadEnabledAddons(IUnrealEssentials unrealEssentials, IRyoApi ryo, IAtlusAssets atlusScript)
		{
			try
			{
                FunStuffLoader.LoadFunStuffAssets(unrealEssentials, _configuration, _context._modLocation); // loads fun stuff :true:
                Voice.LoadVoiceAssets(_modLoader, _modConfig, _configuration, ryo); // loads voice options
                HairLoader.LoadHairAssets(unrealEssentials, _configuration, _context._modLocation); // loads 3d hair
                AnimLoader.LoadAnimAssets(unrealEssentials, _configuration, _context._modLocation); // loads 3d anim
                NaginataLoader.LoadNaginataAssets(unrealEssentials, _configuration, _context._modLocation); // loads 3d weapons
                AoaLoader.LoadAoaAssets(unrealEssentials, _configuration, _context._modLocation); // loads 2d aoa
                AoaTextLoader.LoadAoaTextAssets(unrealEssentials, _configuration, _context._modLocation); // loads the 2d aoa text thing on the side
                BustupLoader.LoadBustups(unrealEssentials, _configuration, _context._modLocation); // loads 2d bustups
                ShardLoader.LoadShardAssets(unrealEssentials, _configuration, _context._modLocation); // loads the 2d shard, which is technially 3d
                LevelUpLoader.LoadLevelUpAssets(unrealEssentials, _configuration, _context._modLocation); // loads the 2d level up portraits
                PartyPanelLoader.LoadPartyPanelAssets(unrealEssentials, _configuration, _context._modLocation); // loads the 2d party panel
                CutinLoader.LoadCutinAssets(unrealEssentials, _configuration, _context._modLocation); // loads the 2d cutin usms
                GroupEventLoader.LoadGroupEventAssets(unrealEssentials, _configuration, _context._modLocation); // loads the group event thing, its 2d art 
                KyotoEventLoader.LoadKyotoEventAssets(unrealEssentials, _configuration, _context._modLocation); // loads the kyoto event, it is also 2d art
                Theo.LoadTheoAssets(unrealEssentials, _modLoader, _modConfig, ryo, _configuration, _context._modLocation); // loads Theo
                Saori.LoadSaoriAssets(unrealEssentials, _modLoader, _modConfig, ryo, _configuration, _context._modLocation); // loads Saori
                Rio.LoadRioAssets(unrealEssentials, _modLoader, _modConfig, ryo, _configuration, _context._modLocation); // loads Rio
                HotspringsLoader.LoadHotspringsAssets(unrealEssentials, _modLoader, _modConfig, ryo, atlusScript, _configuration, _context._modLocation); // loads Hot Spring Event
                Testing.LoadTesticles(unrealEssentials, _modLoader, _modConfig, ryo, _configuration, _context._modLocation); // loads Theo
				HexEditing.CampCommon.Apply(_configuration, _context._modLocation);
                HexEditing.SaveLoad.Apply(_configuration, _context._modLocation);
                HexEditing.Mail.Apply(_configuration, _context._modLocation);
                HexEditing.Battle.Apply(_configuration, _context._modLocation);
				HexEditing.PersonaStatus.Apply(_configuration, _context._modLocation);
                HexEditing.Cmmu.Apply(_configuration, _context._modLocation);
                HexEditing.Handwriting.Apply(_configuration, _context._modLocation);
                HexEditing.Field.Apply(_configuration, _context._modLocation);
            }
			catch (Exception ex)
			{
				_context._utils.Log($"An error occured trying to read addons: \"{ex.Message}\"", System.Drawing.Color.Red);
			}

            unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Redirector")); // this is femcs asset folder, all her assets go in here. If they are not in here, she will not load
            _costumeApi.AddCostumesFolder(_modConfig.ModId, Path.Combine(_context._modLocation, "Outfit Loader")); // Folder with all the costume ymls
        }

        private void InitializeModules() // Rirurin's stuff, don't touch on penalty of death (Ivan is exempt from this) 
		{
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
                _modRuntime.AddModule<CampQuest>();
                _modRuntime.AddModule<CampCalendar>();
				_modRuntime.AddModule<CampSystem>();
				_modRuntime.AddModule<SocialStats>();
				_modRuntime.AddModule<Tutorial>();
				_modRuntime.AddModule<MissingPerson>();
                _modRuntime.AddModule<Requests>();
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
            if (_configuration.EnableBattle) _modRuntime.AddModule<Battle>();
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
			if (_configuration.EnableItemList) _modRuntime.AddModule<ItemList>();
			if (_configuration.EnableCommunity) _modRuntime.AddModule<Cmmu>();
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
