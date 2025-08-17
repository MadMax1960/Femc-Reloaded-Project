using P3R.CostumeFramework.Costumes;
using P3R.CostumeFramework.Costumes.Models;
using P3R.CostumeFramework.Hooks.Services;

namespace P3R.CostumeFramework.Hooks.Costumes.Models;

internal class FemcCostume : Costume
{
    public FemcCostume()
    {
        Character = Character.Player;
        Config.Base.MeshPath = AssetUtils.GetAssetFile(Character.Yukari, 0, CostumeAssetType.BaseMesh);
        Config.Base.AnimPath = AssetUtils.GetAssetFile(Character.Player, 51, CostumeAssetType.BaseAnim);
        Config.Costume.MeshPath = "/Game/Xrd777/Characters/Player/FemC/Femc_Winter_School";
        Config.Hair.MeshPath = "/Game/Xrd777/Characters/Player/FemC/Femc_Hair";
        Config.Face.MeshPath = "/Game/Xrd777/Characters/Player/FemC/Femc_Face";
        Config.Costume.AnimPath = "None";
        Config.Hair.AnimPath = "None";
        Config.Face.AnimPath = "None";

        Config.Allout.NormalPath = AssetUtils.GetAssetFile(Character.Player, 0, CostumeAssetType.AlloutNormal);
        Config.Allout.NormalMaskPath = AssetUtils.GetAssetFile(Character.Player, 0, CostumeAssetType.AlloutNormalMask);
        Config.Allout.SpecialPath = AssetUtils.GetAssetFile(Character.Player, 0, CostumeAssetType.AlloutSpecial);
        Config.Allout.SpecialMaskPath = AssetUtils.GetAssetFile(Character.Player, 0, CostumeAssetType.AlloutSpecialMask);
        Config.Allout.TextPath = AssetUtils.GetAssetFile(Character.Player, 0, CostumeAssetType.AlloutText);
        Config.Allout.PlgPath = AssetUtils.GetAssetFile(Character.Player, 0, CostumeAssetType.AlloutPlg);
    }
}
