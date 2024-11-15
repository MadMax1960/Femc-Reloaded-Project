using p3rpc.femc.Components;
using UnrealEssentials.Interfaces;
using System;
using System.IO;
using Unreal.ObjectsEmitter.Interfaces;

namespace p3rpc.femc
{
	internal class AssetRedirector
	{
		private readonly IUnreal _unreal;
		private readonly string _modName;

		public AssetRedirector(IUnreal unreal, string modName)
		{
			_unreal = unreal;
			_modName = modName;
		}

		public void RedirectPlayerAssets()
		{
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_F000", "/Game/Xrd777/Characters/Player/FemC/Femc_Face"); // face
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H000", "/Game/Xrd777/Characters/Player/FemC/Femc_Hair"); // hair
		    //this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H000", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_H998"); // aigis hair
			this.RedirectAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_CombineAnim", "/Game/Xrd777/Characters/Data/DataAsset/Player/PC0002/DA_PC0002_CombineAnim"); // idk what this is, its something
			this.RedirectAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_CommonAnim", "/Game/Xrd777/Characters/Data/DataAsset/Player/PC0002/DA_PC0002_CommonAnim"); // common anim stuff, walking, sitting, griddying, etc
			//this.RedirectAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_EventAnim", "/Game/Xrd777/Characters/Data/DataAsset/Player/PC0002/DA_PC0002_EventAnim"); // Event anims, so specific events, probably why velvet room dies tbqh
			this.RedirectAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_FaceAnim", "/Game/Xrd777/Characters/Data/DataAsset/Player/PC0002/DA_PC0002_FaceAnim"); // read the filename to my left
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/ABP_PC0001", "/Game/Xrd777/Characters/Player/PC0002/ABP_PC0002"); // might omega die
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/AnmCommon/A_PC0001_CMA0055_ADDP_BagLNoPocket", "/Game/Xrd777/Characters/Player/PC0002/AnmCommon/A_PC0002_CMA0056_ADDP_BagL"); // might die 
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/AnmCommon/A_PC0001_CMA0056_ADDP_BagL", "/Game/Xrd777/Characters/Player/PC0002/AnmCommon/A_PC0002_CMA0056_ADDP_BagL"); // might die 2
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/AnmCommon/A_PC0001_CMA0063_ADDP_TravelBagL", "/Game/Xrd777/Characters/Player/PC0002/AnmCommon/A_PC0002_CMA0056_ADDP_BagL"); // might die 3
			//this.RedirectAsset("/Game/Xrd777/Blueprints/Characters/Player/Bag/BP_AppCharBag_0001_000", "/Game/Xrd777/Blueprints/Characters/Player/Bag/BP_AppCharBag_0002_000"); // idk what these 2 do
			//this.RedirectAsset("/Game/Xrd777/Blueprints/Characters/Player/Bag/BP_AppCharBag_0001_099", "/Game/Xrd777/Blueprints/Characters/Player/Bag/BP_AppCharBag_0002_001"); // this is the 2nd 
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_BaseSkelton", "/Game/Xrd777/Characters/Player/FemC/Femc_Skeleton.uasset"); // trent crimm the indepedent
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C001", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C991"); // summer school I think?
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C002", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C992"); // winter school
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C005", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C993"); // summer casual
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C006", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C994"); // winter casual
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C051", "/Game/Xrd777/Characters/Player/FemC/Femc_Winter_School_Battle.uasset"); // joker persona 5 reference
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C052", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C999"); // STRETCHING SKIRT MAKE LOOK BAD :((((((((
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C101", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C985"); // idk what this is, its something though
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C102", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C986"); // idk what this is, its something though
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C103", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C982"); // bikini I think?
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C106", "/Game/Xrd777/Characters/Player/PC0005/Models/SK_PC0005_C106"); // this is something too
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C151", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C985"); // :idk:
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C154", "/Game/Xrd777/Characters/Player/PC0005/Models/SK_PC0005_C154"); // never gonna give you up, never gonna let you down
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C155", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C155"); // yukata i believe
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C158", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C983"); // idk
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C159", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C970"); // dorm apron
		//	this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C160", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C984"); // idk
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C161", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C980"); // work outfit for something
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C162", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C981"); // something
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C501", "/Game/Xrd777/Characters/Player/FemC/FemC_PhantomThief"); //not  rise
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C502", "/Game/Xrd777/Characters/Player/PC0005/Models/SK_PC0005_C502"); // mitsuru shujin redirect
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C503", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C997"); // not best outfit, its naoto, look at her go, i need to use new yuha textures for coat (and maybe make textures for pants and hat while I wait, but either way its naoto, look at that woah, wow, naoto, noot, shirogane, tiny person, little short tiny not tall detective 
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H158", "/Game/Xrd777/Characters/Player/FemC/Femc_Hair"); // hair
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H501", "/Game/Xrd777/Characters/Player/FemC/Femc_Hair"); // hair 2 (3 technically)
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H159", "/Game/Xrd777/Characters/Player/FemC/Femc_Hair"); // yuha hair 3 (4 technically)
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C504", "/Game/Xrd777/Characters/Player/PC0006/Models/SK_PC0006_C504");
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H504", "/Game/Xrd777/Characters/Player/FemC/Femc_Hair"); // forgor velvet hair
		}

		private void RedirectAsset(string ogAssetPath, string newAssetPath)
		{
			var ogFnames = new AssetFNames(ogAssetPath);
			var newFnames = new AssetFNames(newAssetPath);

			_unreal.AssignFName(_modName, ogFnames.AssetName, newFnames.AssetName);
			_unreal.AssignFName(_modName, ogFnames.AssetPath, newFnames.AssetPath);
		}
	}

	internal static class AssetUtils
	{
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
}
