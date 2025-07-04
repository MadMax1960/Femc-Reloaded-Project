using p3rpc.commonmodutils;
using p3rpc.femc.Components;
using p3rpc.femc.Configuration;
using p3rpc.femc.Template;
using Reloaded.Hooks.Definitions;
using Reloaded.Memory;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using SharedScans.Interfaces;
using System.Diagnostics;
using UnrealEssentials.Interfaces;
using static p3rpc.femc.Configuration.Config;
using p3rpc.classconstructor.Interfaces;
using Ryo.Interfaces;
using Reloaded.Memory.Sigscan.Definitions;
using P3R.CostumeFramework.Interfaces;
using UE.Toolkit.Interfaces;
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
            _armorData = new(_modLoader, _modConfig, uObjects, toolKit, _context);

            modName = _modConfig.ModName;
			// Load Modules/assets
			LoadEnabledAddons(unrealEssentials, ryo);
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

        private void LoadEnabledAddons(IUnrealEssentials unrealEssentials, IRyoApi ryo)
		{
			try
			{
				Load3dAssets(unrealEssentials);
				Load2dAssets(unrealEssentials);
				LoadTheoAssets(unrealEssentials, ryo);
				LoadFunStuff(unrealEssentials);
				LoadMiscAssets(ryo);
			}
			catch (Exception ex)
			{
				_context._utils.Log($"An error occured trying to read addons: \"{ex.Message}\"", System.Drawing.Color.Red);
			}
		}

		private void Load3dAssets(IUnrealEssentials unrealEssentials)
		{
		if (_configuration.HairTrue == HairType.MudkipsHair) // hair option, this shit broken, i should fix it
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "hair", "MudkipHair"));
		else if (_configuration.HairTrue == HairType.KotoneBeanHair)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "hair", "NaobeanHair"));
		
		if (_configuration.AnimTrue == AnimType.OriginalAnims) // animation option
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "Anims", "Original Dummy"));
		else if (_configuration.AnimTrue == AnimType.CustomAnims)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "Anims", "Custom Anims"));
		else if (_configuration.AnimTrue == AnimType.VeryFunnyAnims)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "Anims", "Very Funny Anims"));

		if (_configuration.NagiWeap) // loads naginata
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "Nagitana"));
			
		unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Redirector")); // just loads actual assets, if this doesnt load femc doesn't load lmfao
		_costumeApi.AddCostumesFolder(_modConfig.ModId, Path.Combine(_context._modLocation, "Oscar Fortnite")); // Fuck it 

		}

		private void Load2dAssets(IUnrealEssentials unrealEssentials)
		{
			AoaLoader.LoadAoaAssets(unrealEssentials, _configuration, _context._modLocation);
			AoaTextLoader.LoadAoaTextAssets(unrealEssentials, _configuration, _context._modLocation);
			BustupLoader.LoadBustups(unrealEssentials, _configuration, _context._modLocation);
			ShardLoader.LoadShardAssets(unrealEssentials, _configuration, _context._modLocation);
			LevelUpLoader.LoadLevelUpAssets(unrealEssentials, _configuration, _context._modLocation);
			PartyPanelLoader.LoadPartyPanelAssets(unrealEssentials, _configuration, _context._modLocation);
			CutinLoader.LoadCutinAssets(unrealEssentials, _configuration, _context._modLocation);
			GroupEventLoader.LoadGroupEventAssets(unrealEssentials, _configuration, _context._modLocation);
			KyotoEventLoader.LoadKyotoEventAssets(unrealEssentials, _configuration, _context._modLocation);
		}

		private void LoadTheoAssets(IUnrealEssentials unrealEssentials, IRyoApi ryo)
			{
				if (_configuration.TheodorefromAlvinandTheChipmunks) // loads all the theo assets, needs to be seperated for configs...
				{
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Theo", "TheodorefromAlvinandTheChipmunks"));
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Theo", "cutin", "mekkipatman"));
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Theo", "message"));
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Theo", "Bustup"));
					ryo.AddAudioFolder(_modLoader.GetDirectoryForModId(_modConfig.ModId) + "/Theo/voice/Landon");
				}
			}

		private void LoadFunStuff(IUnrealEssentials unrealEssentials)
		{
			if (_configuration.KotoneRoom)  // kotones room with the paintings and stuff 
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Fun Stuff", "Kotone Room"));
			
			if (_configuration.GregoryHouseRatPoisonDeliverySystem) // house apron
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Fun Stuff", "GregoryHouseRatPoisonDeliverySystem"));
			if (!_configuration.GregoryHouseRatPoisonDeliverySystem)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Fun Stuff", "GregoryHouseRatPoisonDeliverySystemog"));

            if (_configuration.OtomeArcade)  // kotones room with the paintings and stuff 
                unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Fun Stuff", "Otome Arcade"));
        }

		private void LoadMiscAssets(IRyoApi ryo)
		{
			if (_configuration.bluehairandpronounce)
				ryo.AddAudioFolder(_modLoader.GetDirectoryForModId(_modConfig.ModId) + "/Voice"); // gendered audio
			
			if (_configuration.VoiceTrue == VoiceType.Mellodi) // voice stuff, mellodi, silly, etc
				ryo.AddAudioFolder(_modLoader.GetDirectoryForModId(_modConfig.ModId) + "/mellodi/normal battle");
			else if (_configuration.VoiceTrue == VoiceType.MellodiSilly)
				ryo.AddAudioFolder(_modLoader.GetDirectoryForModId(_modConfig.ModId) + "/mellodi/april fools");
			else if (_configuration.VoiceTrue == VoiceType.Japanese)
				ryo.AddAudioFolder(_modLoader.GetDirectoryForModId(_modConfig.ModId) + "/mellodi/nothing lmao");

		}

		private void InitializeModules() // Rirurin's stuff, don't touch on penalty of death
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
