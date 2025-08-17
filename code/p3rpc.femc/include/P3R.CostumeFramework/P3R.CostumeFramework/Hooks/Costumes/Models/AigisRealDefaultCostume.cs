using P3R.CostumeFramework.Costumes;
using P3R.CostumeFramework.Costumes.Models;
using P3R.CostumeFramework.Hooks.Services;

namespace P3R.CostumeFramework.Hooks.Costumes.Models;

internal class AigisRealDefaultCostume : DefaultCostume
{
    public AigisRealDefaultCostume() : base(Character.Aigis)
    {
        this.Config.Hair.MeshPath = AssetUtils.GetAssetFile(Character.AigisReal, 0, CostumeAssetType.HairMesh);
        this.Config.Costume.MeshPath = AssetUtils.GetAssetFile(Character.AigisReal, 54, CostumeAssetType.CostumeMesh);
        
        this.Config.Allout.NormalPath = AssetUtils.GetAssetFile(Character.AigisReal, 0, CostumeAssetType.AlloutNormal);
        this.Config.Allout.NormalMaskPath = AssetUtils.GetAssetFile(Character.AigisReal, 0, CostumeAssetType.AlloutNormalMask);
        this.Config.Allout.SpecialPath = AssetUtils.GetAssetFile(Character.AigisReal, 0, CostumeAssetType.AlloutSpecial);
        this.Config.Allout.SpecialMaskPath = AssetUtils.GetAssetFile(Character.AigisReal, 0, CostumeAssetType.AlloutSpecialMask);
        this.Config.Allout.TextPath = AssetUtils.GetAssetFile(Character.AigisReal, 0, CostumeAssetType.AlloutText);
        this.Config.Allout.PlgPath = AssetUtils.GetAssetFile(Character.AigisReal, 0, CostumeAssetType.AlloutPlg);
    }
}