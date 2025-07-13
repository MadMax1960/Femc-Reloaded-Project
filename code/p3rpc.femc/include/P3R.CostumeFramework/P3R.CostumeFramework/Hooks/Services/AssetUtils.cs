using P3R.CostumeFramework.Costumes;
using P3R.CostumeFramework.Costumes.Models;
using P3R.CostumeFramework.Hooks.Animations.Models;
using P3R.CostumeFramework.Hooks.Models;

namespace P3R.CostumeFramework.Hooks.Services;

internal static class AssetUtils
{
    /// <summary>
    /// Gets the expected asset file for the given character's costume ID and asset type.
    /// </summary>
    /// <param name="character">Character.</param>
    /// <param name="costumeId">Costume ID.</param>
    /// <param name="type">Asset type.</param>
    /// <returns></returns>
    public static string? GetAssetFile(Character character, int costumeId, CostumeAssetType type)
    {
        var astreaDepContentDir = character is Character.Metis or Character.AigisReal ? "Xrd777" : "Astrea";
        
        string? assetFile = type switch
        {
            CostumeAssetType.BaseMesh => $"/Game/Xrd777/Characters/Player/PC{GetCharIdString(character)}/Models/SK_PC{GetCharIdString(character)}_BaseSkelton.uasset",
            CostumeAssetType.CostumeMesh => $"/Game/Xrd777/Characters/Player/PC{GetCharIdString(character)}/Models/SK_PC{GetCharIdString(character)}_C{costumeId:000}.uasset",
            CostumeAssetType.HairMesh => $"/Game/Xrd777/Characters/Player/PC{GetCharIdString(character)}/Models/SK_PC{GetCharIdString(character)}_H{costumeId:000}.uasset",
            CostumeAssetType.FaceMesh => $"/Game/Xrd777/Characters/Player/PC{GetCharIdString(character)}/Models/SK_PC{GetCharIdString(character)}_F{costumeId:000}.uasset",

            CostumeAssetType.BaseAnim => $"/Game/Xrd777/Characters/Player/PC{GetCharIdString(character)}/ABP_PC{GetCharIdString(character)}.uasset",
            CostumeAssetType.CostumeAnim => "/CharacterBase/Human/Blueprints/Animation/ABP_CH_CostumeBase.uasset",
            CostumeAssetType.HairAnim => "/CharacterBase/Human/Blueprints/Animation/ABP_CH_HairBase.uasset",
            CostumeAssetType.FaceAnim => $"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{GetCharIdString(character)}/DA_PC{GetCharIdString(character)}_FaceAnim.uasset",

            CostumeAssetType.AlloutNormal => $"/Game/{astreaDepContentDir}/Battle/Allout/Materials/Finish2D/T_Btl_AlloutFinish_Pc{GetCharIdStringShort(character)}_A1{(costumeId >= 1000 ? $"_{costumeId}" : string.Empty)}",
            CostumeAssetType.AlloutNormalMask => $"/Game/{astreaDepContentDir}/Battle/Allout/Materials/Finish2D/T_Btl_AlloutFinish_Pc{GetCharIdStringShort(character)}_A2{(costumeId >= 1000 ? $"_{costumeId}" : string.Empty)}",
            CostumeAssetType.AlloutSpecial => $"/Game/{astreaDepContentDir}/Battle/Allout/Materials/Finish2D/T_Btl_AlloutFinish_Pc{GetCharIdStringShort(character)}_B1{(costumeId >= 1000 ? $"_{costumeId}" : string.Empty)}",
            CostumeAssetType.AlloutSpecialMask => $"/Game/{astreaDepContentDir}/Battle/Allout/Materials/Finish2D/T_Btl_AlloutFinish_Pc{GetCharIdStringShort(character)}_B2{(costumeId >= 1000 ? $"_{costumeId}" : string.Empty)}",
            CostumeAssetType.AlloutText => $"/Game/{astreaDepContentDir}/Battle/Allout/Materials/Finish2D/T_Btl_AlloutFinishText_Pc{GetCharIdStringShort(character)}{(costumeId >= 1000 ? $"_{costumeId}" : string.Empty)}",
            CostumeAssetType.AlloutPlg => $"{GetCharacterPlg(character)}{(costumeId >= 1000 ? $"_{costumeId}" : string.Empty)}",

            CostumeAssetType.CommonAnim => $"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{GetCharIdString(character)}/DA_PC{GetCharIdString(character)}_CommonAnim.uasset",
            CostumeAssetType.DungeonAnim => $"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{GetCharIdString(character)}/DA_PC{GetCharIdString(character)}_DungeonAnim.uasset",
            CostumeAssetType.CombineAnim => $"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{GetCharIdString(character)}/DA_PC{GetCharIdString(character)}_CombineAnim.uasset",
            CostumeAssetType.EventAnim => $"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{GetCharIdString(character)}/DA_PC{GetCharIdString(character)}_EventAnim.uasset",
            _ => throw new Exception(),
        };

        return assetFile;
    }

    /// <summary>
    /// Gets the expected asset path from asset file path.
    /// Simply removes the .uasset extension and/or adds the game content path.
    /// </summary>
    /// <param name="assetFile">Asset .uasset file path.</param>
    /// <returns>Asset path.</returns>
    public static string GetAssetPath(string assetFile)
    {
        var adjustedPath = assetFile.Replace('\\', '/').Replace(".uasset", string.Empty);
        if (!adjustedPath.StartsWith("/Game/"))
        {
            adjustedPath = $"/Game/{adjustedPath}";
        }

        return adjustedPath;
    }

    public static string? GetAssetPath(Character character, int costumeId, CostumeAssetType type)
    {
        var assetFile = GetAssetFile(character, costumeId, type);
        return assetFile != null ? GetAssetPath(assetFile) : null;
    }

    /// <summary>
    /// Gets the expected asset path per Unreal's format of having
    /// the file name repeat after a period.
    /// </summary>
    public static string? GetUnrealAssetPath(Character character, int costumeId, CostumeAssetType type)
    {
        var assetPath = GetAssetPath(character, costumeId, type);
        return assetPath != null ? $"{assetPath}.{Path.GetFileName(assetPath)}" : null;
    }

    /// <summary>
    /// Gets the expected asset path per Unreal's format of having
    /// the file name repeat after a period.
    /// </summary>
    public static string GetUnrealAssetPath(string assetFile)
    {
        var assetPath = GetAssetPath(assetFile);
        return $"{assetPath}.{Path.GetFileName(assetPath)}";
    }

    public static Character GetCharFromEquip(EquipFlag flag)
        => Enum.Parse<Character>(flag.ToString());

    public static EquipFlag GetEquipFromChar(Character character)
        => character == Character.AigisReal ? EquipFlag.Aigis : Enum.Parse<EquipFlag>(character.ToString());

    public static string GetCharIdString(Character character)
        => ((int)character).ToString("0000");

    public static string GetCharIdStringShort(Character character)
        => ((int)character).ToString("00");

    private static string GetCharacterPlg(Character character)
    {
        return character switch
        {
            Character.Player => "/Game/Xrd777/Battle/Allout/Materials/Finish2D/PLG_UI_Battle_Allout_Last_Hero",
            Character.Yukari => "/Game/Xrd777/Battle/Allout/Materials/Finish2D/PLG_UI_Battle_Allout_Last_Yukari",
            Character.Stupei => "/Game/Xrd777/Battle/Allout/Materials/Finish2D/PLG_UI_Battle_Allout_Last_Junpei",
            Character.Akihiko => "/Game/Xrd777/Battle/Allout/Materials/Finish2D/PLG_UI_Battle_Allout_Last_Sanada",
            Character.Mitsuru => "/Game/Xrd777/Battle/Allout/Materials/Finish2D/PLG_UI_Battle_Allout_Last_Mituru",
            Character.Fuuka => "/Game/Xrd777/Battle/Allout/Materials/Finish2D/PLG_UI_Battle_Allout",
            Character.Aigis => "/Game/Xrd777/Battle/Allout/Materials/Finish2D/PLG_UI_Battle_Allout_Last_Aegis",
            Character.Ken => "/Game/Xrd777/Battle/Allout/Materials/Finish2D/PLG_UI_Battle_Allout_Last_Amada",
            Character.Koromaru => "/Game/Xrd777/Battle/Allout/Materials/Finish2D/PLG_UI_Battle_Allout_Last_Koromaru",
            Character.Shinjiro => "/Game/Xrd777/Battle/Allout/Materials/Finish2D/PLG_UI_Battle_Allout_Last_Aragaki",
            Character.Metis => "/Game/Astrea/Battle/Allout/Materials/Finish2D/PLG_UI_Battle_Allout_Last_Metis",
            Character.AigisReal => "/Game/Astrea/Battle/Allout/Materials/Finish2D/PLG_UI_Battle_Allout_Last_HeroAegis",
            _ => throw new NotImplementedException(),
        };
    }

    public static string GetAnimPath(Character character, CharAnim anim)
    {
        var name = GetAnimName(character, anim);
        if (anim <= CharAnim.BSDngAlsNWalkRun)
        {
            return $"/Game/Xrd777/Characters/Player/PC{GetCharIdString(character)}/AnmDungeon/{name}.{name}";
        }
        else
        {
            return $"/Game/Xrd777/Characters/Player/PC{GetCharIdString(character)}/AnmBattle/{name}.{name}";
        }
    }

    public static string? GetAnimName(Character character, CharAnim anim)
        => anim switch
        {
            CharAnim.DngAlsNPose => $"A_PC{GetCharIdString(character)}_DNG_ALS_N_POSE",
            CharAnim.DngAlsNRunF => $"A_PC{GetCharIdString(character)}_DNG_ALS_N_Run_F",
            CharAnim.DngAlsNWalkF => $"A_PC{GetCharIdString(character)}_DNG_ALS_N_Walk_F",
            CharAnim.DngAlsPoseRunStrideZero => $"A_PC{GetCharIdString(character)}_DNG_ALS_POSE_RunStrideZero",
            CharAnim.DngAlsStopPose => $"A_PC{GetCharIdString(character)}_DNG_ALS_STOP_POSE",
            CharAnim.DngPoseNeutral => $"A_PC{GetCharIdString(character)}_DNG0001_POSE_Neutral",
            CharAnim.DngBaseSuddenStop => $"A_PC{GetCharIdString(character)}_DNG0002_BASE_SuddenStop",
            CharAnim.DngBaseBreath => $"A_PC{GetCharIdString(character)}_DNG0003_BASE_Breath",
            CharAnim.DngBaseRun => $"A_PC{GetCharIdString(character)}_DNG0006_BASE_Run",
            CharAnim.DngBaseWalk => $"A_PC{GetCharIdString(character)}_DNG0008_BASE_Walk",
            CharAnim.DngBasePActionA => $"A_PC{GetCharIdString(character)}_DNG0031_BASE_PActionA",
            CharAnim.DngBasePActionB => $"A_PC{GetCharIdString(character)}_DNG0032_BASE_PActionB",
            CharAnim.DngBaseDashRun => $"A_PC{GetCharIdString(character)}_DNG0101_BASE_DashRun",
            CharAnim.DngBaseLocoStopL => $"A_PC{GetCharIdString(character)}_DNG0103_BASE_LocomotionStopL",
            CharAnim.DngBaseTalk => $"A_PC{GetCharIdString(character)}_DNG0113_BASE_Talk",
            CharAnim.BSDngAlsNWalkRun => $"BS_PC{GetCharIdString(character)}_DNG_ALS_N_WalkRun",

            CharAnim.IdleN => $"A_PC{GetCharIdString(character)}_BTL0001_BASE_IdleN",
            CharAnim.IdleCStart => $"A_PC{GetCharIdString(character)}_BTL{GetCharIdString(character)}_BASE_IdleCStart",
            CharAnim.IdleC => $"A_PC{GetCharIdString(character)}_BTL0003_BASE_IdleC",
            CharAnim.IdleCEnd => $"A_PC{GetCharIdString(character)}_BTL0004_BASE_IdleCEnd",
            CharAnim.PA => $"A_PC{GetCharIdString(character)}_BTL0005_BASE_PA",
            CharAnim.Dying => $"A_PC{GetCharIdString(character)}_BTL0006_BASE_Dying",
            CharAnim.Damage => $"A_PC{GetCharIdString(character)}_BTL0007_BASE_Damage",
            CharAnim.Dead => $"A_PC{GetCharIdString(character)}_BTL0008_BASE_Dead",
            CharAnim.DeadLoop => $"A_PC{GetCharIdString(character)}_BTL0009_BASE_DeadLoop",
            CharAnim.Resurrection => $"A_PC{GetCharIdString(character)}_BTL0010_BASE_Resurrection",
            CharAnim.RunStart => $"A_PC{GetCharIdString(character)}_BTL0011_BASE_RunStart",
            CharAnim.Run => $"A_PC{GetCharIdString(character)}_BTL0012_BASE_Run",
            CharAnim.Escape => $"A_PC{GetCharIdString(character)}_BTL0014_BASE_Escape",
            CharAnim.GuardStart => $"A_PC{GetCharIdString(character)}_BTL0015_BASE_GuardStart",
            CharAnim.GuardLoop => $"A_PC{GetCharIdString(character)}_BTL0016_BASE_GuardLoop",
            CharAnim.GuardEnd => $"A_PC{GetCharIdString(character)}_BTL0017_BASE_GuardEnd",
            CharAnim.Avoid => $"A_PC{GetCharIdString(character)}_BTL0018_BASE_Avoid",
            CharAnim.AttackMissAIdle => $"A_PC{GetCharIdString(character)}_BTL0020_BASE_AttackMissAIdle",
            CharAnim.AttackA => $"A_PC{GetCharIdString(character)}_BTL0021_BASE_AttackA",
            //CharAnim.AttackB => $"A_PC{GetCharIdString(character)}_BTL0022_BASE_AttackB",
            //CharAnim.AttackC => $"A_PC{GetCharIdString(character)}_BTL0023_BASE_AttackC",
            CharAnim.AttackMissA => $"A_PC{GetCharIdString(character)}_BTL0024_BASE_AttackMissA",
            CharAnim.AttackAIdle => $"A_PC{GetCharIdString(character)}_BTL0025_BASE_AttackAIdle",
            CharAnim.AttackBIdle => $"A_PC{GetCharIdString(character)}_BTL0026_BASE_AttackBIdle",
            CharAnim.AttackCIdle => $"A_PC{GetCharIdString(character)}_BTL0027_BASE_AttackCIdle",
            CharAnim.SummonStart => $"A_PC{GetCharIdString(character)}_BTL0031_BASE_SummonStart",
            CharAnim.SummonLoop => $"A_PC{GetCharIdString(character)}_BTL0032_BASE_SummonLoop",
            CharAnim.SummonCancel => $"A_PC{GetCharIdString(character)}_BTL0033_BASE_SummonCancel",
            CharAnim.SummonActStart => $"A_PC{GetCharIdString(character)}_BTL0034_BASE_SummonActStart",
            CharAnim.SummonActLoop => $"A_PC{GetCharIdString(character)}_BTL0035_BASE_SummonActLoop",
            CharAnim.SummonActEnd => $"A_PC{GetCharIdString(character)}_BTL0036_BASE_SummonActEnd",
            CharAnim.ItemStart => $"A_PC{GetCharIdString(character)}_BTL0051_BASE_ItemStart",
            CharAnim.ItemLoop => $"A_PC{GetCharIdString(character)}_BTL0052_BASE_ItemLoop",
            CharAnim.ItemCancel => $"A_PC{GetCharIdString(character)}_BTL0053_BASE_ItemCancel",
            CharAnim.ItemUse => $"A_PC{GetCharIdString(character)}_BTL0054_BASE_ItemUse",
            CharAnim.KnockDown => $"A_PC{GetCharIdString(character)}_BTL0056_BASE_KnockDown",
            CharAnim.DownLoop => $"A_PC{GetCharIdString(character)}_BTL0057_BASE_DownLoop",
            CharAnim.Return => $"A_PC{GetCharIdString(character)}_BTL0058_BASE_Return",
            CharAnim.BatonTouchA => $"A_PC{GetCharIdString(character)}_BTL0061_BASE_BatonTouchA",
            CharAnim.BatonTouchB => $"A_PC{GetCharIdString(character)}_BTL0062_BASE_BatonTouchB",
            CharAnim.BatonTouchSide => $"A_PC{GetCharIdString(character)}_BTL0062_BASE_BatonTouchSide_02",
            CharAnim.VictoryMainStart => $"A_PC{GetCharIdString(character)}_BTL0071_BASE_VictoryMainStart",
            CharAnim.VictorySubAStart => $"A_PC{GetCharIdString(character)}_BTL0073_BASE_VictorySubAStart",
            CharAnim.AllOutAttackStartMain => $"A_PC{GetCharIdString(character)}_BTL0081_BASE_AllOutAttackStartMain",
            CharAnim.AllOutAttackStartSubA => $"A_PC{GetCharIdString(character)}_BTL0082_BASE_AllOutAttackStartSubA",
            CharAnim.AllOutAttackStartSubB => $"A_PC{GetCharIdString(character)}_BTL0083_BASE_AllOutAttackStartSubB",
            CharAnim.AllOutAttackStartSubC => $"A_PC{GetCharIdString(character)}_BTL0084_BASE_AllOutAttackStartSubC",
            CharAnim.AllOutAttackEndMain => $"A_PC{GetCharIdString(character)}_BTL0085_BASE_AllOutAttackEndMain",
            CharAnim.AllOutAttackLastShot => $"A_PC{GetCharIdString(character)}_BTL0089_BASE_AllOutAttackLastShot",
            CharAnim.ShuffleTimeStart => $"A_PC{GetCharIdString(character)}_BTL0091_BASE_ShuffleTimeStart",
            CharAnim.ShuffleTimeLoop => $"A_PC{GetCharIdString(character)}_BTL0092_BASE_ShuffleTimeLoop",
            CharAnim.ShuffleTimeEnd => $"A_PC{GetCharIdString(character)}_BTL0093_BASE_ShuffleTimeEnd",
            CharAnim.CutTheurgia => $"A_PC{GetCharIdString(character)}_BTL0100_BASE_CutTheurgia",
            CharAnim.CutAngry => $"A_PC{GetCharIdString(character)}_BTL0101_BASE_CutAngry",
            CharAnim.CutTheurgiaFaceDown => $"A_PC{GetCharIdString(character)}_BTL0121_BASE_CutTheurgiaFaceDown",
            CharAnim.CutTheurgiaFaceUp => $"A_PC{GetCharIdString(character)}_BTL0122_BASE_CutTheurgiaFaceUp",
            CharAnim.MayaIdle => $"A_PC{GetCharIdString(character)}_BTL0123_BASE_MayaIdle",
            CharAnim.TheurgiaACut01 => $"A_PC{GetCharIdString(character)}_BTL0131_BASE_TheurgiaACut01",
            CharAnim.TheurgiaACut02 => $"A_PC{GetCharIdString(character)}_BTL0132_BASE_TheurgiaACut02",
            CharAnim.TheurgiaACut03 => $"A_PC{GetCharIdString(character)}_BTL0133_BASE_TheurgiaACut03",
            CharAnim.TheurgiaACut04 => $"A_PC{GetCharIdString(character)}_BTL0134_BASE_TheurgiaACut04",
            CharAnim.TheurgiaACut05 => $"A_PC{GetCharIdString(character)}_BTL0135_BASE_TheurgiaACut05",
            CharAnim.TheurgiaACut06 => $"A_PC{GetCharIdString(character)}_BTL0136_BASE_TheurgiaACut06",
            CharAnim.TheurgiaBCut01 => $"A_PC{GetCharIdString(character)}_BTL0141_BASE_TheurgiaBCut01",
            CharAnim.Attack => $"A_PC{GetCharIdString(character)}_BTL5005_BASE_Attack",
            _ => null,
        };
}
