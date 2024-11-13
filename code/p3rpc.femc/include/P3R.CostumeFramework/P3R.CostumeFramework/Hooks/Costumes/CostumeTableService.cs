using P3R.CostumeFramework.Costumes;
using P3R.CostumeFramework.Costumes.Models;
using P3R.CostumeFramework.Hooks.Costumes.Models;
using P3R.CostumeFramework.Hooks.Models;
using P3R.CostumeFramework.Hooks.Services;
using P3R.CostumeFramework.Utils;
using Reloaded.Hooks.Definitions;
using System.Text.Json;
using Unreal.ObjectsEmitter.Interfaces;
using Unreal.ObjectsEmitter.Interfaces.Types;

namespace P3R.CostumeFramework.Hooks.Costumes;

internal unsafe class CostumeTableService
{
    private readonly IUnreal unreal;
    private readonly CostumeRegistry costumes;
    private DefaultCostumes defaultCostumes;
    private DataTable<FAppCharTableRow>? table;
    private IAsmHook? fullDtHook;

    public CostumeTableService(IDataTables dt, IUnreal unreal, CostumeRegistry costumes, bool useFemcPlayer)
    {
        this.unreal = unreal;
        this.costumes = costumes;
        this.defaultCostumes = new(useFemcPlayer);

        ScanHooks.Add(
            "Use Full DT_Costume",
            "33 DB 48 8D 4D ?? 48 89 5D ?? 48 89 5D ?? 8D 53 ?? 84 C0 74 ?? E8 ?? ?? ?? ?? 8B 55 ?? 8D 7A",
            (hooks, result) => this.fullDtHook = hooks.CreateAsmHook("use64\nmov rax, 1", result).Activate());

        dt.FindDataTable<FAppCharTableRow>("DT_Costume", table =>
        {
            this.table = table;

            this.UpdateCostumeTable();
            //this.DumpCostumeTable();
        });
    }

    private record CostumeSerialized(Character Character, int CostumeId, string BaseMesh, string CostumeMesh, string FaceMesh, string HairMesh);

    private void DumpCostumeTable()
    {
        if (this.table == null) return;

        var costumesSerialized = new List<CostumeSerialized>();
        foreach (var character in Enum.GetValues<Character>())
        {
            var rowName = character <= Character.AigisReal ? $"PC{(int)character}" : $"SC{(int)character}";
            if (this.table.TryGetValue(rowName, out var row))
            {
                foreach (var item in row.Costumes)
                {
                    var costumeId = item.Key;
                    var costumeData = item.Value;

                    var baseMesh = this.unreal.GetName(costumeData.Base.Mesh.GetObjectPtr()->ObjectId.AssetPathName);
                    var costumeMesh = this.unreal.GetName(costumeData.Costume.Mesh.GetObjectPtr()->ObjectId.AssetPathName);
                    var faceMesh = this.unreal.GetName(costumeData.Face.Mesh.GetObjectPtr()->ObjectId.AssetPathName);
                    var hairMesh = this.unreal.GetName(costumeData.Hair.Mesh.GetObjectPtr()->ObjectId.AssetPathName);

                    costumesSerialized.Add(new(character, costumeId, baseMesh, costumeMesh, faceMesh, hairMesh));
                }
            }
        }

        File.WriteAllText("costumes.json", JsonSerializer.Serialize(costumesSerialized, new JsonSerializerOptions() { WriteIndented = true }));
    }

    private void UpdateCostumeTable()
    {
        if (this.table == null) return;

        foreach (var costume in this.costumes.Costumes)
        {
            if (costume.CostumeId < GameCostumes.BASE_MOD_COSTUME_ID)
            {
                this.UpdateCostume(costume);
            }
        }
    }

    /// <summary>
    /// Set costume data from costume to alternative costume ID than the one set in costume.
    /// </summary>
    public void SetCostumeData(Character character, int costumeId, Costume costume)
    {
        var charRow = this.GetCharacterRow(character);
        if (charRow->Costumes.TryGet(costumeId, out var costumeData))
        {
            this.SetCostumeData(costumeData, costume);
        }
        else
        {
            Log.Error($"Failed to find costume: {costume.Character} || Costume ID: {costumeId}");
        }
    }

    private void UpdateCostume(Costume costume)
    {
        var charRow = this.GetCharacterRow(costume.Character);
        if (charRow->Costumes.TryGet(costume.CostumeId, out var costumeData))
        {
            this.SetCostumeData(costumeData, costume);
        }
        else
        {
            Log.Warning($"Failed to update costume: {costume.Character} || ID: {costume.CostumeId} || {costume.Name}");
        }
    }

    private void SetCostumeData(FAppCharCostumeData* costumeData, Costume costume)
    {
        if (costume.CostumeId >= GameCostumes.BASE_MOD_COSTUME_ID)
        {
            this.SetCostumeAsset(costumeData, costume.Character, CostumeAssetType.BaseMesh, costume.Config.GetAssetFile(CostumeAssetType.BaseMesh));
            this.SetCostumeAsset(costumeData, costume.Character, CostumeAssetType.BaseAnim, costume.Config.GetAssetFile(CostumeAssetType.BaseAnim));
            this.SetCostumeAsset(costumeData, costume.Character, CostumeAssetType.CostumeMesh, costume.Config.GetAssetFile(CostumeAssetType.CostumeMesh));
            this.SetCostumeAsset(costumeData, costume.Character, CostumeAssetType.CostumeAnim, costume.Config.GetAssetFile(CostumeAssetType.CostumeAnim));
            this.SetCostumeAsset(costumeData, costume.Character, CostumeAssetType.FaceMesh, costume.Config.GetAssetFile(CostumeAssetType.FaceMesh));
            this.SetCostumeAsset(costumeData, costume.Character, CostumeAssetType.FaceAnim, costume.Config.GetAssetFile(CostumeAssetType.FaceAnim));
            this.SetCostumeAsset(costumeData, costume.Character, CostumeAssetType.HairMesh, costume.Config.GetAssetFile(CostumeAssetType.HairMesh));
            this.SetCostumeAsset(costumeData, costume.Character, CostumeAssetType.HairAnim, costume.Config.GetAssetFile(CostumeAssetType.HairAnim));
        }
        else
        {
            ModUtils.IfNotNull(costume.Config.GetAssetFile(CostumeAssetType.BaseMesh), path => this.SetCostumeAsset(costumeData, costume.Character, CostumeAssetType.BaseMesh, path!));
            ModUtils.IfNotNull(costume.Config.GetAssetFile(CostumeAssetType.BaseAnim), path => this.SetCostumeAsset(costumeData, costume.Character, CostumeAssetType.BaseAnim, path!));
            ModUtils.IfNotNull(costume.Config.GetAssetFile(CostumeAssetType.CostumeMesh), path => this.SetCostumeAsset(costumeData, costume.Character, CostumeAssetType.CostumeMesh, path!));
            ModUtils.IfNotNull(costume.Config.GetAssetFile(CostumeAssetType.CostumeAnim), path => this.SetCostumeAsset(costumeData, costume.Character, CostumeAssetType.CostumeAnim, path!));
            ModUtils.IfNotNull(costume.Config.GetAssetFile(CostumeAssetType.FaceMesh), path => this.SetCostumeAsset(costumeData, costume.Character, CostumeAssetType.FaceMesh, path!));
            ModUtils.IfNotNull(costume.Config.GetAssetFile(CostumeAssetType.FaceAnim), path => this.SetCostumeAsset(costumeData, costume.Character, CostumeAssetType.FaceAnim, path!));
            ModUtils.IfNotNull(costume.Config.GetAssetFile(CostumeAssetType.HairMesh), path => this.SetCostumeAsset(costumeData, costume.Character, CostumeAssetType.HairMesh, path!));
            ModUtils.IfNotNull(costume.Config.GetAssetFile(CostumeAssetType.HairAnim), path => this.SetCostumeAsset(costumeData, costume.Character, CostumeAssetType.HairAnim, path!));
        }
    }

    private void SetCostumeAsset(FAppCharCostumeData* costumeData, Character character, CostumeAssetType assetType, string? newAssetFile)
    {
        var assetFile = newAssetFile ?? this.GetDefaultAsset(character, assetType);
        if (assetFile == null)
        {
            Log.Error($"Costume asset path is null: {character} || {assetType}");
            return;
        }

        var assetPath = AssetUtils.GetUnrealAssetPath(assetFile);
        if (assetType == CostumeAssetType.BaseAnim
            || assetType == CostumeAssetType.CostumeAnim
            || assetType == CostumeAssetType.FaceAnim
            || assetType == CostumeAssetType.HairAnim)
        {
            assetPath += "_C";
        }

        var assetFName = assetFile != "None" ? *this.unreal.FName(assetPath) : *this.unreal.FName("None");

        switch (assetType)
        {
            case CostumeAssetType.BaseMesh:
                costumeData->Base.Mesh.baseObj.baseObj.ObjectId.AssetPathName = assetFName;
                costumeData->Base.Mesh.baseObj.baseObj.WeakPtr = new();
                break;
            case CostumeAssetType.CostumeMesh:
                costumeData->Costume.Mesh.baseObj.baseObj.ObjectId.AssetPathName = assetFName;
                costumeData->Costume.Mesh.baseObj.baseObj.WeakPtr = new();
                break;
            case CostumeAssetType.HairMesh:
                costumeData->Hair.Mesh.baseObj.baseObj.ObjectId.AssetPathName = assetFName;
                costumeData->Hair.Mesh.baseObj.baseObj.WeakPtr = new();
                break;
            case CostumeAssetType.FaceMesh:
                costumeData->Face.Mesh.baseObj.baseObj.ObjectId.AssetPathName = assetFName;
                costumeData->Face.Mesh.baseObj.baseObj.WeakPtr = new();
                break;
            case CostumeAssetType.BaseAnim:
                costumeData->Base.Anim.baseObj.baseObj.ObjectId.AssetPathName = assetFName;
                costumeData->Base.Anim.baseObj.baseObj.WeakPtr = new();
                break;
            case CostumeAssetType.CostumeAnim:
                costumeData->Costume.Anim.baseObj.baseObj.ObjectId.AssetPathName = assetFName;
                costumeData->Costume.Anim.baseObj.baseObj.WeakPtr = new();
                break;
            case CostumeAssetType.HairAnim:
                costumeData->Hair.Anim.baseObj.baseObj.ObjectId.AssetPathName = assetFName;
                costumeData->Hair.Anim.baseObj.baseObj.WeakPtr = new();
                break;
            case CostumeAssetType.FaceAnim:
                costumeData->Face.Anim.baseObj.baseObj.ObjectId.AssetPathName = assetFName;
                costumeData->Face.Anim.baseObj.baseObj.WeakPtr = new();
                break;
            default:
                break;
        }
    }

    public FAppCharTableRow* GetCharacterRow(Character character) => table!.Rows.First(x => x.Name == $"PC{(int)character}").Self;

    private string? GetDefaultAsset(Character character, CostumeAssetType assetType) => this.defaultCostumes[character].Config.GetAssetFile(assetType);
}
