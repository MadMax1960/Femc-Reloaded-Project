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
using Unreal.ObjectsEmitter.Interfaces;
using System;
using System.Collections.Generic;
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
		private readonly IUnreal unreal;

		public static string NAME { get; private set; }

		public Mod(ModContext context)
		{
			_modLoader = context.ModLoader;
			_hooks = context.Hooks;
			_logger = context.Logger;
			_owner = context.Owner;
			_configuration = context.Configuration;
			_modConfig = context.ModConfig;

			_modLoader.GetController<IUnreal>().TryGetTarget(out this.unreal);
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
				else if (_configuration.BustupTrue == BustupType.Anniversary)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "25thAnniversary"));


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
			}
			catch (Exception ex)
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
			this.RedirectPlayerAssets();

		}

		// ADD ASSET REDIRECTS HERE.
		private void RedirectPlayerAssets()
		{
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_F000", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_F999"); // face
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H000", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_H999"); // hair
			this.RedirectAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_CombineAnim", "/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_CombineAnim"); // idk what this is, its something
			this.RedirectAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_CommonAnim", "/Game/Xrd777/Characters/Data/DataAsset/Player/PC0002/DA_PC0002_CommonAnim"); // common anim stuff, walking, sitting, griddying, etc
			// this.RedirectAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_EventAnim", "/Game/Xrd777/Characters/Data/DataAsset/Player/PC0002/DA_PC0002_EventAnim"); // Event anims, so specific events, probably why velvet room dies tbqh
			this.RedirectAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_FaceAnim", "/Game/Xrd777/Characters/Data/DataAsset/Player/PC0002/DA_PC0002_FaceAnim"); // read the filename to my left
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/ABP_PC0001", "/Game/Xrd777/Characters/Player/PC0002/ABP_PC0002"); // might omega die
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/AnmCommon/A_PC0001_CMA0055_ADDP_BagLNoPocket", "/Game/Xrd777/Characters/Player/PC0002/AnmCommon/A_PC0002_CMA0056_ADDP_BagL"); // might die 
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/AnmCommon/A_PC0001_CMA0056_ADDP_BagL", "/Game/Xrd777/Characters/Player/PC0002/AnmCommon/A_PC0002_CMA0056_ADDP_BagL"); // might die 2
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/AnmCommon/A_PC0001_CMA0063_ADDP_TravelBagL", "/Game/Xrd777/Characters/Player/PC0002/AnmCommon/A_PC0002_CMA0056_ADDP_BagL"); // might die 3
			this.RedirectAsset("/Game/Xrd777/Blueprints/Characters/Player/Bag/BP_AppCharBag_0001_000", "/Game/Xrd777/Blueprints/Characters/Player/Bag/BP_AppCharBag_0002_000"); // idk what these 2 do
			this.RedirectAsset("/Game/Xrd777/Blueprints/Characters/Player/Bag/BP_AppCharBag_0001_099", "/Game/Xrd777/Blueprints/Characters/Player/Bag/BP_AppCharBag_0002_001"); // this is the 2nd 
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_BaseSkelton", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_BaseSkelton"); // trent crimm the indepedent
		}

		private void RedirectAsset(string ogAssetPath, string newAssetPath)
		{
			var ogFnames = new AssetFNames(ogAssetPath);
			var newFnames = new AssetFNames(newAssetPath);

			this.unreal.AssignFName(Mod.NAME, ogFnames.AssetName, newFnames.AssetName);
			this.unreal.AssignFName(Mod.NAME, ogFnames.AssetPath, newFnames.AssetPath);
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

internal static class AssetUtils
{
	/// <summary>
	/// Gets the expected asset file for the given character's costume ID and asset type.
	/// </summary>
	/// <param name="character">Character.</param>
	/// <param name="costumeId">Costume ID.</param>
	/// <param name="type">Asset type.</param>
	/// <returns></returns>
	public static string GetAssetPath(Character character, AssetType type, int costumeId = 0)
		=> type switch
		{
			AssetType.BaseMesh => FormatAssetPath($"/Game/Xrd777/Characters/Player/PC{FormatCharId(character)}/Models/SK_PC{FormatCharId(character)}_BaseSkelton", character),
			AssetType.CostumeMesh => FormatAssetPath($"/Game/Xrd777/Characters/Player/PC{FormatCharId(character)}/Models/SK_PC{FormatCharId(character)}_C{costumeId:000}", character),
			AssetType.HairMesh => FormatAssetPath($"/Game/Xrd777/Characters/Player/PC{FormatCharId(character)}/Models/SK_PC{FormatCharId(character)}_H{costumeId:000}", character),
			AssetType.FaceMesh => FormatAssetPath($"/Game/Xrd777/Characters/Player/PC{FormatCharId(character)}/Models/SK_PC{FormatCharId(character)}_F{costumeId:000}", character),
			AssetType.CommonAnim => FormatAssetPath($"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{FormatCharId(character)}/DA_PC{FormatCharId(character)}_CommonAnim", character),
			AssetType.CombineAnim => FormatAssetPath($"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{FormatCharId(character)}/DA_PC{FormatCharId(character)}_CombineAnim", character),
			AssetType.EventAnim => FormatAssetPath($"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{FormatCharId(character)}/DA_PC{FormatCharId(character)}_EventAnim", character),
			AssetType.FaceAnim => FormatAssetPath($"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{FormatCharId(character)}/DA_PC{FormatCharId(character)}_FaceAnim", character),
			_ => throw new Exception(),
		};

	public static string GetAssetFile(Character character, AssetType type, Outfit outfit)
		=> GetAssetPath(character, type, (int)outfit);

	/// <summary>
	/// Gets the expected asset path from asset file path.
	/// Simply removes the .uasset extension and/or adds the game content path.
	/// </summary>
	/// <param name="assetFile">Asset .uasset file path.</param>
	/// <returns>Asset path.</returns>
	public static string GetAssetPath(string assetFile)
	{
		var adjustedPath = assetFile.Replace('\\', '/').Replace(".uasset", string.Empty);

		if (adjustedPath.IndexOf("Content") is int contentIndex && contentIndex > -1)
		{
			adjustedPath = adjustedPath.Substring(contentIndex + 8);
		}

		if (!adjustedPath.StartsWith("/Game/"))
		{
			adjustedPath = $"/Game/{adjustedPath}";
		}

		return adjustedPath;
	}

	public static string FormatCharId(Character character)
		=> ((int)character).ToString("0000");

	private static string FormatAssetPath(string path, Character character)
	{
		if (character >= Character.Player && character <= Character.Shinjiro)
		{
			return path;
		}
		else
		{
			return path.Replace("PC", "SC").Replace("Player", "Sub");
		}
	}
}

public enum AssetType
{
	BaseMesh,
	CostumeMesh,
	HairMesh,
	FaceMesh,

	CommonAnim,
	CombineAnim,
	EventAnim,
	FaceAnim,
}

public enum Character
{
	NONE,
	Player,
	Yukari,
	Stupei,
	Akihiko,
	Mitsuru,
	Fuuka,
	Aigis,
	Ken,
	Koromaru,
	Shinjiro = 10,

	// Side-characters.
	////Kenji = 101,
	////Hidetoshi,
	////Bunkichi,
	////Mitsuko,
	////Kazushi,
	////Yuko,
	////Keisuke = 108,
	////Chihiro,
	//Maiko,
	//Pharos = 110,
	//Andre_Laurent_Jean_Geraux,
	//Tanaka,
	//Mutatsu,
	//Mamoru,
	//Akinari,

	//Igor = 201,
	//Elizabeth,

	//Takaya = 211,
	//Jin,
	//Chidori,

	//Ryoji = 221,
	//Ikutsuki,
	//Natsuki,
	//Takeharu,

	FEMC = 999,
}

public class CharacterConfig
{
	public CharacterBase Base { get; set; } = new();

	public CharacterAnims Animations { get; set; } = new();

	public Dictionary<Outfit, string?> Outfits { get; set; } = new();
}

public class CharacterBase
{
	public Character Character { get; set; } = Character.Player;

	public string? BaseSkeleton { get; set; }

	public string? Hair { get; set; }

	public string? Face { get; set; }
}

public class CharacterAnims
{
	public string? Common { get; set; }

	public string? Combine { get; set; }

	public string? Event { get; set; }

	public string? Face { get; set; }
}

public enum Outfit
{
	Missing = 0,
	Summer_Uniform = 1,
	Winter_Uniform = 2,
	Summer_Casual = 5,
	Winter_Casual = 6,
	Uniform_Armband = 51,
	SEES_Uniform = 52,
	Gekkoukan_Jersey = 101,
	Swimsuit = 102,
	Nightwear = 103,
	Battle_Armor = 104,
	Butler_Suit = 106,
	Track_Team_Shirt = 151,
	Hot_Springs_Towel = 154,
	Hotel_Yukata = 155,
	Shrine_Festival_Yukata = 156,
	New_Years_Kimono = 157,
	Wilduck_Burger_Uniform = 158,
	Dorm_Apron = 159,
	Cafe_Uniform = 160,
	Be_Blue_V_Uniform = 161,
	Screen_Shot_Uniform = 162,
	SEES_Outfit = 201,
	SEES_Uniform_2 = 202,
	Damaged_Ribbon = 203,
	Ocean_Sundress = 204,
	Ocean_Sundress_2 = 205,
	Firearms = 206,
	Phantom_Suit = 501,
	Shujin_Uniform = 502,
	Yasogami_Uniform = 503,
}

internal record AssetFNames(string AssetFile)
{
	public string AssetName { get; } = Path.GetFileNameWithoutExtension(AssetFile);

	public string AssetPath { get; } = AssetUtils.GetAssetPath(AssetFile);
};

