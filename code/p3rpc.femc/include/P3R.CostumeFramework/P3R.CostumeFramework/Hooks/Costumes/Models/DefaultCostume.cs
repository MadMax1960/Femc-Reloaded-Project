using P3R.CostumeFramework.Costumes;
using P3R.CostumeFramework.Costumes.Models;
using P3R.CostumeFramework.Hooks.Services;

namespace P3R.CostumeFramework.Hooks.Costumes.Models;

internal class DefaultCostume : Costume
{
    public DefaultCostume(Character character)
    {
        Character = character;
        Config.Base.MeshPath = AssetUtils.GetAssetFile(character, 51, CostumeAssetType.BaseMesh);
        Config.Base.AnimPath = AssetUtils.GetAssetFile(character, 51, CostumeAssetType.BaseAnim);
        Config.Costume.MeshPath = AssetUtils.GetAssetFile(character, 51, CostumeAssetType.CostumeMesh);
        Config.Hair.MeshPath = AssetUtils.GetAssetFile(character, 0, CostumeAssetType.HairMesh);
        Config.Face.MeshPath = AssetUtils.GetAssetFile(character, 0, CostumeAssetType.FaceMesh);
        Config.Costume.AnimPath = "None";
        Config.Hair.AnimPath = "None";
        Config.Face.AnimPath = "None";

        Config.Allout.NormalPath = AssetUtils.GetAssetFile(character, 0, CostumeAssetType.AlloutNormal);
        Config.Allout.NormalMaskPath = AssetUtils.GetAssetFile(character, 0, CostumeAssetType.AlloutNormalMask);
        Config.Allout.SpecialPath = AssetUtils.GetAssetFile(character, 0, CostumeAssetType.AlloutSpecial);
        Config.Allout.SpecialMaskPath = AssetUtils.GetAssetFile(character, 0, CostumeAssetType.AlloutSpecialMask);
        Config.Allout.TextPath = AssetUtils.GetAssetFile(character, 0, CostumeAssetType.AlloutText);
        Config.Allout.PlgPath = AssetUtils.GetAssetFile(character, 0, CostumeAssetType.AlloutPlg);
    }
}
