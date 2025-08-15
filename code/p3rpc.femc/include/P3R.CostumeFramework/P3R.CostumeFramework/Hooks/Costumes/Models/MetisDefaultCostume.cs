using P3R.CostumeFramework.Costumes;
using P3R.CostumeFramework.Costumes.Models;
using P3R.CostumeFramework.Hooks.Services;

namespace P3R.CostumeFramework.Hooks.Costumes.Models;

internal class MetisDefaultCostume : DefaultCostume
{
    public MetisDefaultCostume() : base(Character.Metis)
    {
        this.Config.Costume.MeshPath = AssetUtils.GetAssetFile(Character.Metis, 201, CostumeAssetType.CostumeMesh);
    }
}