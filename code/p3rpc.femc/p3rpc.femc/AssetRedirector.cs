using UE.Toolkit.Interfaces;

namespace p3rpc.femc
{
	internal class AssetRedirector
	{
		private readonly IUnrealNames _unrealNames;
		private readonly string _modName;

		public AssetRedirector(IUnrealNames unreal, string modName)
		{
			_unrealNames = unreal;
			_modName = modName;
		}

		public void RedirectPlayerAssets()
		{
			this.RedirectAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_FaceAnim", "/Game/Xrd777/Characters/Data/DataAsset/Player/PC0002/DA_PC0002_FaceAnim"); // read the filename to my left
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C051", "/Game/Xrd777/Characters/Player/FemC/Femc_Winter_School_Battle.uasset"); // joker persona 5 reference
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C502", "/Game/Xrd777/Characters/Player/PC0005/Models/SK_PC0005_C502"); // mitsuru shujin redirect
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_BaseSkelton", "/Game/Xrd777/Characters/Player/FemC/Femc_Skeleton.uasset"); // trent crimm the indepedent
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C504", "/Game/Xrd777/Characters/Player/PC0006/Models/SK_PC0006_C504");
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H504", "/Game/Xrd777/Characters/Player/FemC/Femc_Hair"); // forgor velvet hair
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_Title_00", "/Game/Xrd777/Characters/Player/FemC/malcomlni_n_thine_midel"); // title model
		}

		private void RedirectAsset(string ogAssetPath, string newAssetPath)
		{
			var ogFnames = new AssetFNames(ogAssetPath);
			var newFnames = new AssetFNames(newAssetPath);

			_unrealNames.RedirectFName(_modName, ogFnames.AssetName, newFnames.AssetName);
			_unrealNames.RedirectFName(_modName, ogFnames.AssetPath, newFnames.AssetPath);
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
