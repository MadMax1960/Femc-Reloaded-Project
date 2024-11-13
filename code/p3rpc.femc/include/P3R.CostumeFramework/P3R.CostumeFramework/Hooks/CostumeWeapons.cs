using P3R.CostumeFramework.Costumes;
using System.Runtime.InteropServices;
using Unreal.ObjectsEmitter.Interfaces;
using Unreal.ObjectsEmitter.Interfaces.Types;

namespace P3R.CostumeFramework.Hooks;

internal unsafe class CostumeWeapons
{
    private readonly IUnreal unreal;
    public CostumeWeapons(IDataTables dt, IUnreal unreal, IUObjects uobjs)
    {
        this.unreal = unreal;

        dt.FindDataTable("DT_Costume", table =>
        {
            //foreach (var row in table.Rows)
            //{
            //    var costumeRow = (FAppCharTableRow*)row.Self;
            //    for (int i = 0; i < costumeRow->Costumes.mapNum; i++)
            //    {
            //        //Log.Information($"{row.Name}: {i}");
            //        var costumeAssetPath = &costumeRow->Costumes.elements[i].Value.Costume.Mesh.baseObj.baseObj.ObjectId;
            //        costumeAssetPath->AssetPathName = *unreal.FName(AssetUtils.GetUnrealAssetPath(Character.Yukari, 51, CostumeAssetType.CostumeMesh)!);
            //    }

            //    //for (int i = 0; i < costumeRow->WeaponType.mapNum; i++)
            //    //{
            //    //    var bp = unreal.GetName(&costumeRow->WeaponType.elements[i].Value.BluePrints.AllocatorInstance[0].baseObj.baseObj.ObjectId.AssetPathName);
            //    //    Log.Information($"{row.Name}: {bp}");
            //    //}
            //}
        });

        //uobjs.FindObject("BP_Wp0001_01_C", obj =>
        //{
        //    var charWeapon = (AAppCharWeaponBase*)obj.Self;
        //    Log.Information(unreal.GetName(&charWeapon->WeaponTbl.Anim.baseObj.baseObj.ObjectId.AssetPathName));
        //});
    }
}
