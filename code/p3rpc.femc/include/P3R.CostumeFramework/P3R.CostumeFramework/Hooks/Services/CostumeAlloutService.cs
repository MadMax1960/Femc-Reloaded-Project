using P3R.CostumeFramework.Costumes.Models;
using P3R.CostumeFramework.Hooks.Models;
using P3R.CostumeFramework.Utils;
using System.Runtime.InteropServices;
using Unreal.ObjectsEmitter.Interfaces;
using Unreal.ObjectsEmitter.Interfaces.Types;

namespace P3R.CostumeFramework.Hooks.Services;

internal unsafe class CostumeAlloutService
{
    private readonly IUnreal unreal;
    private readonly CostumeManager manager;

    public CostumeAlloutService(IDataTables dt, IUnreal unreal, CostumeManager manager)
    {
        this.unreal = unreal;
        this.manager = manager;

        dt.FindDataTable<FBtlAlloutFinishTexture>("DT_BtlAlloutFinishTexture", this.BtlAlloutFinishTextureLoaded);
    }

    private void BtlAlloutFinishTextureLoaded(DataTable<FBtlAlloutFinishTexture> table)
    {
        foreach (var costume in this.manager.GetCurrentCostumes())
        {
            var alloutRowName = $"PC{(int)costume.Character}";
            var alloutRow = table.Rows.First(x => x.Name == alloutRowName).Self;

            ModUtils.IfNotNull(costume.Config.Allout.NormalPath, path => this.SetAssetPath(alloutRow, CostumeAssetType.AlloutNormal, path!));
            ModUtils.IfNotNull(costume.Config.Allout.NormalMaskPath, path => this.SetAssetPath(alloutRow, CostumeAssetType.AlloutNormalMask, path!));
            ModUtils.IfNotNull(costume.Config.Allout.SpecialPath, path => this.SetAssetPath(alloutRow, CostumeAssetType.AlloutSpecial, path!));
            ModUtils.IfNotNull(costume.Config.Allout.SpecialMaskPath, path => this.SetAssetPath(alloutRow, CostumeAssetType.AlloutSpecialMask, path!));
            ModUtils.IfNotNull(costume.Config.Allout.PlgPath, path => this.SetAssetPath(alloutRow, CostumeAssetType.AlloutPlg, path!));
            ModUtils.IfNotNull(costume.Config.Allout.TextPath, path => this.SetAssetPath(alloutRow, CostumeAssetType.AlloutText, path!));
        }
    }

    private void SetAssetPath(FBtlAlloutFinishTexture* allout, CostumeAssetType type, string path)
    {
        var assetFName = *this.unreal.FName(AssetUtils.GetUnrealAssetPath(path)!);
        switch (type)
        {
            case CostumeAssetType.AlloutNormal:
                allout->TextureNormal.baseObj.baseObj.ObjectId.AssetPathName = assetFName;
                break;
            case CostumeAssetType.AlloutNormalMask:
                allout->TextureNormalMask.baseObj.baseObj.ObjectId.AssetPathName = assetFName;
                break;
            case CostumeAssetType.AlloutSpecial:
                allout->TextureSpecialOutfit.baseObj.baseObj.ObjectId.AssetPathName = assetFName;
                break;
            case CostumeAssetType.AlloutSpecialMask:
                allout->TextureSpecialMask.baseObj.baseObj.ObjectId.AssetPathName = assetFName;
                break;
            case CostumeAssetType.AlloutPlg:
                allout->TexturePlg.baseObj.baseObj.ObjectId.AssetPathName = assetFName;
                break;
            case CostumeAssetType.AlloutText:
                allout->TextureText.baseObj.baseObj.ObjectId.AssetPathName = assetFName;
                break;
            default:
                break;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    private unsafe struct FBtlAlloutFinishTexture
    {
        public SoftObjectProperty TextureNormal;
        public SoftObjectProperty TextureNormalMask;
        public SoftObjectProperty TextureSpecialOutfit;
        public SoftObjectProperty TextureSpecialMask;
        public SoftObjectProperty TextureText;
        public SoftObjectProperty TexturePlg;
    }
}
