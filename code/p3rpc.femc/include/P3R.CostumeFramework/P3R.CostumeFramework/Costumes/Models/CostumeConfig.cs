using P3R.CostumeFramework.Hooks.Services;

namespace P3R.CostumeFramework.Costumes.Models;

internal class CostumeConfig
{
    /// <summary>
    /// Overrides costume name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Custom Ryo group ID for sharing Ryo
    /// files between costumes.
    /// </summary>
    public string? RyoGroupId { get; set; }

    public CostumePartsData Base { get; set; } = new();

    public CostumePartsData Costume { get; set; } = new();

    public CostumePartsData Hair { get; set; } = new();

    public CostumePartsData Face { get; set; } = new();

    public CostumeAllout Allout { get; set; } = new();

    public CostumeAnims Anims { get; set; } = new();

    public string? GetAssetFile(CostumeAssetType assetType)
        => assetType switch
        {
            CostumeAssetType.BaseMesh => GetOrParseAssetPath(this.Base.MeshPath),
            CostumeAssetType.BaseAnim => GetOrParseAssetPath(this.Base.AnimPath),
            CostumeAssetType.CostumeMesh => GetOrParseAssetPath(this.Costume.MeshPath),
            CostumeAssetType.CostumeAnim => GetOrParseAssetPath(this.Costume.AnimPath),
            CostumeAssetType.FaceMesh => GetOrParseAssetPath(this.Face.MeshPath),
            CostumeAssetType.FaceAnim => GetOrParseAssetPath(this.Face.AnimPath),
            CostumeAssetType.HairMesh => GetOrParseAssetPath(this.Hair.MeshPath),
            CostumeAssetType.HairAnim => GetOrParseAssetPath(this.Hair.AnimPath),
            CostumeAssetType.AlloutNormal => GetOrParseAssetPath(this.Allout.NormalPath),
            CostumeAssetType.AlloutNormalMask => GetOrParseAssetPath(this.Allout.NormalMaskPath),
            CostumeAssetType.AlloutSpecial => GetOrParseAssetPath(this.Allout.SpecialPath),
            CostumeAssetType.AlloutSpecialMask => GetOrParseAssetPath(this.Allout.SpecialMaskPath),
            CostumeAssetType.AlloutText => GetOrParseAssetPath(this.Allout.TextPath),
            CostumeAssetType.AlloutPlg => GetOrParseAssetPath(this.Allout.PlgPath),
            _ => throw new NotImplementedException(),
        };

    private static string? GetOrParseAssetPath(string? assetPath)
    {
        if (assetPath == null)
        {
            return null;
        }

        if (assetPath.StartsWith("asset:"))
        {
            var parts = assetPath["asset:".Length..].Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (parts.Length < 2)
            {
                return null;
            }

            var character = Enum.Parse<Character>(parts[0], true);
            var type = Enum.Parse<CostumeAssetType>(parts[1], true);
            var costumeId = 0;
            if (parts.Length == 3)
            {
                _ = int.TryParse(parts[2], out costumeId);
            }

            return AssetUtils.GetAssetFile(character, costumeId, type);
        }

        return assetPath;
    }
}

internal class CostumeAnims
{
    public string? Common { get; set; }

    public string? Dungeon { get; set; }

    public string? Combine { get; set; }

    public string? Event { get; set; }
}

internal class CostumePartsData
{
    public string? MeshPath { get; set; }

    public string? AnimPath { get; set; }
}

internal class CostumeAllout
{
    private string? _specialPath;
    private string? _specialMaskPath;

    public string? NormalPath { get; set; }

    public string? NormalMaskPath { get; set; }

    public string? SpecialPath
    {
        get
        {
            if (_specialPath == null)
            {
                return this.NormalPath;
            }

            return _specialPath;
        }

        set => _specialPath = value;
    }

    public string? SpecialMaskPath
    {
        get
        {
            if (_specialMaskPath == null)
            {
                return this.NormalMaskPath;
            }

            return _specialMaskPath;
        }

        set => _specialMaskPath = value;
    }

    public string? TextPath { get; set; }

    public string? PlgPath { get; set; }
}