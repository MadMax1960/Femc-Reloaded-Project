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
using Unreal.ObjectsEmitter.Interfaces;
using static p3rpc.femc.Configuration.Config;
using p3rpc.classconstructor.Interfaces;
using Ryo.Interfaces;



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
		private readonly IUnreal unreal;
		private readonly MusicManager _musicManager;
		private AssetRedirector _assetRedirector;


		private string modName { get; set; }

		public Mod(ModContext context)
		{
            _modLoader = context.ModLoader;
			_hooks = context.Hooks;
			_logger = context.Logger;
			_owner = context.Owner;
			_configuration = context.Configuration;
			_modConfig = context.ModConfig;
            // Get dependencies and initialize context
            var mainModule = Process.GetCurrentProcess().MainModule;
			if (mainModule == null) throw new Exception($"[{_modConfig.ModName}] Could not get main module (this should never happen)");
			var baseAddress = mainModule.BaseAddress;
            unreal = GetDependency<IUnreal>("Unreal Objects Emitter");
			var startupScanner = GetDependency<IStartupScanner>("Reloaded Startup Scanner");
			if (_hooks == null) throw new Exception($"[{_modConfig.ModName}] Could not get controller for Reloaded hooks");
			var sharedScans = GetDependency<ISharedScans>("Shared Scans");
			Utils utils = new(startupScanner, _logger, _hooks, baseAddress, "Femc Project", System.Drawing.Color.Thistle, _configuration.DebugLogLevel);
			var unrealEssentials = GetDependency<IUnrealEssentials>("Unreal Essentials");
			var classMethods = GetDependency<IClassMethods>("Class Constructor (Class Methods)");
            var objectMethods = GetDependency<IObjectMethods>("Class Constructor (Object Methods)");
            var ryo = GetDependency<IRyoApi>("Ryo");
            var memory = new Memory();
            _context = new(baseAddress, _configuration, _logger, startupScanner, _hooks, _modLoader.GetDirectoryForModId(_modConfig.ModId), utils, memory, sharedScans, classMethods, objectMethods);
			_modRuntime = new(_context);
			_musicManager = new MusicManager(_modLoader, _modConfig, _configuration, ryo, _logger, _context);

			modName = _modConfig.ModName;
			// Load Modules/assets
			LoadEnabledAddons(unrealEssentials, ryo);
			InitializeModules();
			_assetRedirector = new AssetRedirector(unreal, modName);
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
					LoadMiscAssets(unrealEssentials, ryo);
				}
				catch (Exception ex)
				{
					_context._utils.Log($"An error occured trying to read addons: \"{ex.Message}\"", System.Drawing.Color.Red);
				}
			}

			private void Load3dAssets(IUnrealEssentials unrealEssentials)
			{
			if (_configuration.HairTrue == HairType.MudkipsHair)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "hair", "MudkipHair"));
			else if (_configuration.HairTrue == HairType.KotoneBeanHair)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "hair", "NaobeanHair"));

			if (_configuration.AnimTrue == AnimType.OriginalAnims)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "Anims", "Original Dummy"));
			else if (_configuration.AnimTrue == AnimType.CustomAnims)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "Anims", "Custom Anims"));
			else if (_configuration.AnimTrue == AnimType.VeryFunnyAnims)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "Anims", "Very Funny Anims"));

			if (_configuration.SkirtEtcFix)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "TestSkeleton"));

			if (_configuration.NagiWeap)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "Nagitana"));
			}

			private void Load2dAssets(IUnrealEssentials unrealEssentials)
			{
			if (_configuration.AOATrue == AOAType.Ely)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "Ely"));
			else if (_configuration.AOATrue == AOAType.Chrysanthie)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "Chrysanthie"));
			else if (_configuration.AOATrue == AOAType.Fernando)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "Fernando"));
			else if (_configuration.AOATrue == AOAType.Monica)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "Monica"));
			else if (_configuration.AOATrue == AOAType.RonaldReagan)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "RonaldReagan"));
			else if (_configuration.AOATrue == AOAType.esaadrien)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "esaadrien"));
			else if (_configuration.AOATrue == AOAType.mekki)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "mekki"));
			else if (_configuration.AOATrue == AOAType.shiosakana)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "shiosakana"));
			else if (_configuration.AOATrue == AOAType.shiosakanaAlt)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "shiosakanaAlt"));
			// Other AOA conditions...

			if (_configuration.AOAText == AOATextType.DontLookBack)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOAText", "DontLookBack"));
			else if (_configuration.AOAText == AOATextType.SorryBoutThat)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOAText", "SorryBoutThat"));
			else if (_configuration.AOAText == AOATextType.PerfectlyAccomplished)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOAText", "PerfectlyAccomplished"));
			// Other AOAText conditions...

			if (_configuration.BustupTrue == BustupType.Neptune)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Neptune"));
			else if (_configuration.BustupTrue == BustupType.Ely)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Ely"));
			else if (_configuration.BustupTrue == BustupType.Esa)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Esa"));
			else if (_configuration.BustupTrue == BustupType.Betina)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Betina"));
			else if (_configuration.BustupTrue == BustupType.Anniversary)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "25thAnniversary"));
			else if (_configuration.BustupTrue == BustupType.JustBlue)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "JustBlue"));
			else if (_configuration.BustupTrue == BustupType.Sav)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Sav"));
			else if (_configuration.BustupTrue == BustupType.Doodled)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Doodled"));
			else if (_configuration.BustupTrue == BustupType.RonaldReagan)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "RonaldReagan"));
			else if (_configuration.BustupTrue == BustupType.ElyAlt)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "ElyAlt"));
			else if (_configuration.BustupTrue == BustupType.Yuunagi)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Yuunagi"));
			else if (_configuration.BustupTrue == BustupType.cielbell)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "cielbell"));
			else if (_configuration.BustupTrue == BustupType.axolotl)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "axolotl"));
			else if (_configuration.BustupTrue == BustupType.ghostedtoast)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "ghostedtoast"));
			else if (_configuration.BustupTrue == BustupType.Strelko)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Strelko"));
			else if (_configuration.BustupTrue == BustupType.gackt)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "gackt"));
			else if (_configuration.BustupTrue == BustupType.Jackie)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Jackie"));
			else if (_configuration.BustupTrue == BustupType.Lisa)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Lisa9388"));
			else if (_configuration.BustupTrue == BustupType.BetaFemcByMae)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "BetaFemcByMae"));
			else if (_configuration.BustupTrue == BustupType.crezzstar)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "crezzstar"));
			// Other Bustup conditions...

			if (_configuration.ShardTrue == ShardType.Esa)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Shard", "Esa"));
			else if (_configuration.ShardTrue == ShardType.Ely)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Shard", "Ely"));
			else if (_configuration.ShardTrue == ShardType.ElyAlt)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Shard", "ElyAlt"));
			else if (_configuration.ShardTrue == ShardType.Shiosakana)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Shard", "Shiosakana"));
			// Other Shard conditions...

			if (_configuration.LevelUpTrue == LevelUpType.Esa)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "LevelUp", "Esa"));
			else if (_configuration.LevelUpTrue == LevelUpType.Ely)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "LevelUp", "Ely"));
			// Other Level Up conditions...

			if (_configuration.PartyPanelTrue == PartyPanelType.Kris)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "PartyPanel", "Kris"));
			else if (_configuration.PartyPanelTrue == PartyPanelType.Esa)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "PartyPanel", "Esa"));
			// Other Party Panel conditions...

			if (_configuration.CutinTrue == CutinType.berrycha)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Cutin", "berrycha"));
			else if (_configuration.CutinTrue == CutinType.ElyandPatmandx)
				unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Cutin", "ElyandPatmandx"));
			// Other Cutin conditions...
			}

		private void LoadTheoAssets(IUnrealEssentials unrealEssentials, IRyoApi ryo)
			{
				if (_configuration.TheodorefromAlvinandTheChipmunks)
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
				if (_configuration.KotoneRoom)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Fun Stuff", "Kotone Room"));

				if (_configuration.GregoryHouseRatPoisonDeliverySystem)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Fun Stuff", "GregoryHouseRatPoisonDeliverySystem"));
				if (!_configuration.GregoryHouseRatPoisonDeliverySystem)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Fun Stuff", "GregoryHouseRatPoisonDeliverySystemog"));
			}

			private void LoadMiscAssets(IUnrealEssentials unrealEssentials, IRyoApi ryo)
			{
				if (_configuration.bluehairandpronounce)
					ryo.AddAudioFolder(_modLoader.GetDirectoryForModId(_modConfig.ModId) + "/Voice");
			}


		private void InitializeModules()
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