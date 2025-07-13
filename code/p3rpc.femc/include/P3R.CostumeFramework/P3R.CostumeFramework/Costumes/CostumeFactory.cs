using P3R.CostumeFramework.Costumes.Models;
using P3R.CostumeFramework.Utils;
using Ryo.Interfaces;

namespace P3R.CostumeFramework.Costumes;

internal class CostumeFactory
{
    private readonly IRyoApi ryo;
    private readonly GameCostumes costumes;

    public CostumeFactory(IRyoApi ryo, GameCostumes costumes)
    {
        this.ryo = ryo;
        this.costumes = costumes;
    }

    public Costume? Create(CostumeMod mod, string costumeDir, Character character)
    {
        var config = GetCostumeConfig(costumeDir);
        var costume = this.CreateOrFindCostume(mod.ModId, character, config.Name ?? Path.GetFileName(costumeDir));
        if (costume == null)
        {
            return null;
        }

        ApplyCostumeConfig(costume, config);
        LoadCostumeFiles(mod, costume, costumeDir);
        LoadCostumeRyo(costume, costumeDir);
        Log.Information($"Costume created: {costume.Character} || Costume ID: {costume.CostumeId}\nFolder: {costumeDir}");
        return costume;
    }

    private static void ApplyCostumeConfig(Costume costume, CostumeConfig config)
    {
        if (config.Name != null) costume.Name = config.Name;
        if (config.DisplayName != null) costume.Config.DisplayName = config.DisplayName;
        if (config.RyoGroupId != null) costume.Config.RyoGroupId = config.RyoGroupId;
        if (config.Base.MeshPath != null) costume.Config.Base.MeshPath = config.Base.MeshPath;
        if (config.Costume.MeshPath != null) costume.Config.Costume.MeshPath = config.Costume.MeshPath;
        if (config.Face.MeshPath != null) costume.Config.Face.MeshPath = config.Face.MeshPath;
        if (config.Hair.MeshPath != null) costume.Config.Hair.MeshPath = config.Hair.MeshPath;
        if (config.Base.AnimPath != null) costume.Config.Base.AnimPath = config.Base.AnimPath;
        if (config.Costume.AnimPath != null) costume.Config.Costume.AnimPath = config.Costume.AnimPath;
        if (config.Face.AnimPath != null) costume.Config.Face.AnimPath = config.Face.AnimPath;
        if (config.Hair.AnimPath != null) costume.Config.Hair.AnimPath = config.Hair.AnimPath;
        
        if (config.Allout.NormalPath != null) costume.Config.Allout.NormalPath = config.Allout.NormalPath;
        if (config.Allout.NormalMaskPath != null) costume.Config.Allout.NormalMaskPath = config.Allout.NormalMaskPath;
        if (config.Allout.SpecialPath != null) costume.Config.Allout.SpecialPath = config.Allout.SpecialPath;
        if (config.Allout.SpecialMaskPath != null) costume.Config.Allout.SpecialMaskPath = config.Allout.SpecialMaskPath;
        if (config.Allout.PlgPath != null) costume.Config.Allout.PlgPath = config.Allout.PlgPath;
        if (config.Allout.TextPath != null) costume.Config.Allout.TextPath = config.Allout.TextPath;
        
        if (config.Anims.Common != null) costume.Config.Anims.Common = config.Anims.Common;
        if (config.Anims.Dungeon != null) costume.Config.Anims.Dungeon = config.Anims.Dungeon;
        if (config.Anims.Event != null) costume.Config.Anims.Event = config.Anims.Event;
        if (config.Anims.Combine != null) costume.Config.Anims.Combine = config.Anims.Combine;
    }

    public Costume? CreateFromExisting(Character character, string name, int costumeId)
    {
        var costume = this.CreateOrFindCostume(Mod.NAME, character, name);
        if (costume == null)
        {
            return null;
        }

        costume.Config.Costume.MeshPath = $"/Game/Xrd777/Characters/Player/PC{character:0000}/Models/SK_PC{character:0000}_C{costumeId:000}.uasset";
        return costume;
    }

    public Costume? CreateFromExisting(Character character, string name, string existingMesh)
    {
        var costume = this.CreateOrFindCostume(Mod.NAME, character, name);
        if (costume == null)
        {
            return null;
        }

        costume.Config.Costume.MeshPath = existingMesh;
        return costume;
    }

    private static void LoadCostumeFiles(CostumeMod mod, Costume costume, string costumeDir)
    {
        SetCostumeFile(mod, Path.Join(costumeDir, "base-mesh.uasset"), path => costume.Config.Base.MeshPath = path);
        SetCostumeFile(mod, Path.Join(costumeDir, "base-anim.uasset"), path => costume.Config.Base.AnimPath = path);

        SetCostumeFile(mod, Path.Join(costumeDir, "costume-mesh.uasset"), path => costume.Config.Costume.MeshPath = path);
        SetCostumeFile(mod, Path.Join(costumeDir, "costume-anim.uasset"), path => costume.Config.Costume.AnimPath = path);

        SetCostumeFile(mod, Path.Join(costumeDir, "hair-mesh.uasset"), path => costume.Config.Hair.MeshPath = path);
        SetCostumeFile(mod, Path.Join(costumeDir, "hair-anim.uasset"), path => costume.Config.Hair.AnimPath = path);

        SetCostumeFile(mod, Path.Join(costumeDir, "face-mesh.uasset"), path => costume.Config.Face.MeshPath = path);
        SetCostumeFile(mod, Path.Join(costumeDir, "face-anim.uasset"), path => costume.Config.Face.AnimPath = path);

        SetCostumeFile(mod, Path.Join(costumeDir, "allout-normal.uasset"), path => costume.Config.Allout.NormalPath = path);
        SetCostumeFile(mod, Path.Join(costumeDir, "allout-normal-mask.uasset"), path => costume.Config.Allout.NormalMaskPath = path);
        SetCostumeFile(mod, Path.Join(costumeDir, "allout-special.uasset"), path => costume.Config.Allout.SpecialPath = path);
        SetCostumeFile(mod, Path.Join(costumeDir, "allout-special-mask.uasset"), path => costume.Config.Allout.SpecialMaskPath = path);
        SetCostumeFile(mod, Path.Join(costumeDir, "allout-text.uasset"), path => costume.Config.Allout.TextPath = path);
        SetCostumeFile(mod, Path.Join(costumeDir, "allout-plg.uasset"), path => costume.Config.Allout.PlgPath = path);

        SetCostumeFile(mod, Path.Join(costumeDir, "music.pme"), path => costume.MusicScriptFile = path, SetType.Full);
        SetCostumeFile(mod, Path.Join(costumeDir, "battle.theme.pme"), path => costume.BattleThemeFile = path, SetType.Full);

        SetCostumeFile(mod, Path.Join(costumeDir, "description.msg"), path => costume.Description = File.ReadAllText(path), SetType.Full);
    }

    private void LoadCostumeRyo(Costume costume, string costumeDir)
    {
        var ryoDir = Path.Join(costumeDir, "ryo");
        if (Directory.Exists(ryoDir))
        {
            this.ryo.AddAudioPath(ryoDir, new() { IsEnabled = false, GroupId = costume.RyoGroupId });
            this.ryo.AddMoviePath(ryoDir, new() { IsEnabled = false, GroupId = costume.RyoGroupId });
        }
    }

    private static CostumeConfig GetCostumeConfig(string costumeDir)
    {
        var configFile = Path.Join(costumeDir, "config.yaml");
        if (File.Exists(configFile))
        {
            return YamlSerializer.DeserializeFile<CostumeConfig>(configFile);
        }

        return new();
    }

    private static void SetCostumeFile(CostumeMod mod, string modFile, Action<string> setFile, SetType type = SetType.Relative)
    {
        if (File.Exists(modFile))
        {
            if (type == SetType.Relative)
            {
                setFile(Path.GetRelativePath(mod.ContentDir, modFile));
            }
            else
            {
                setFile(modFile);
            }
        }
    }

    /// <summary>
    /// Creates a new costume for <paramref name="character"/> or gets an existing costume by <paramref name="name"/>.
    /// </summary>
    private Costume? CreateOrFindCostume(string ownerId, Character character, string name)
    {
        var existingCostume = this.costumes.FirstOrDefault(x => x.Character == character && x.Name == name);
        if (existingCostume != null)
        {
            return existingCostume;
        }

        var newCostume = this.costumes.FirstOrDefault(x => x.Character == Character.NONE);
        if (newCostume != null)
        {
            newCostume.Name = name;
            newCostume.Character = character;
            newCostume.IsEnabled = true;
            newCostume.OwnerModId = ownerId;
        }
        else
        {
            Log.Warning("No new costume slots available.");
        }

        return newCostume;
    }

    private enum SetType
    {
        Relative,
        Full,
    }
}
