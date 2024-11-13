using P3R.CostumeFramework.Costumes.Models;
using P3R.CostumeFramework.Costumes;
using P3R.CostumeFramework.Hooks.Animations.Models;
using P3R.CostumeFramework.Hooks.Models;
using P3R.CostumeFramework.Hooks.Services;
using Unreal.ObjectsEmitter.Interfaces;
using P3R.CostumeFramework.Hooks.Costumes;
using p3rpc.classconstructor.Interfaces;

namespace P3R.CostumeFramework.Hooks.Animations;

internal unsafe class CostumeAnimsService
{
    private readonly IUnreal unreal;
    private readonly CostumeTableService costumeTable;

    public CostumeAnimsService(IUObjects uobjs, IUnreal unreal, IObjectMethods objMethods, CostumeTableService costumeTable)
    {
        this.unreal = unreal;
        this.costumeTable = costumeTable;
        //uobjs.FindObject("SKEL_Human", obj =>
        //{
        //    var bones = new GameBones();
        //    string[] keywords =
        //    [
        //        "head",
        //        "eye",
        //        "brow",
        //        "cheek",
        //        "nose",
        //        "mouth",
        //        "jaw",
        //        "tongue",
        //        "lips",
        //        "hair",
        //        "face",
        //        "mask",
        //        "iris",
        //        "pupil",
        //        "laugh",
        //        "tooth"
        //    ];

        //    var skel = (USkeleton*)obj.Self;
        //    for (int i = 0; i < skel->BoneTree.Num; i++)
        //    {
        //        var bone = &skel->BoneTree.AllocatorInstance[i];
        //        var name = bones[i];

        //        if (keywords.Any(x => name.Contains(x, StringComparison.OrdinalIgnoreCase)))
        //        {
        //            Log.Debug($"SKEL_Human ({name}): Retarget bone animation to {EBoneTranslationRetargetingMode.OrientAndScale}.");
        //            bone->TranslationRetargetingMode = EBoneTranslationRetargetingMode.OrientAndScale;
        //        }
        //    }
        //});
    }

    public void UpdateCostumeAnims(Costume costume)
    {
        var charRow = this.costumeTable.GetCharacterRow(costume.Character);
        var anims = charRow->Anims;

        var commonAnim = anims.GetByIndex(0);
        var dungeonAnim = anims.GetByIndex(1);
        var combineAnim = anims.GetByIndex(2);
        var eventAnim = anims.GetByIndex(3);

        if (Enum.TryParse<Character>(costume.Config.Anims.Common, true, out var commonChar))
        {
            this.SetAnim(commonAnim, CostumeAssetType.CommonAnim, commonChar);
        }
        else
        {
            this.SetAnim(commonAnim, CostumeAssetType.CommonAnim, costume.Character);
        }

        if (Enum.TryParse<Character>(costume.Config.Anims.Dungeon, true, out var dungeonChar))
        {
            this.SetAnim(dungeonAnim, CostumeAssetType.DungeonAnim, dungeonChar);
        }
        else
        {
            this.SetAnim(dungeonAnim, CostumeAssetType.DungeonAnim, costume.Character);
        }

        if (Enum.TryParse<Character>(costume.Config.Anims.Combine, true, out var combineChar))
        {
            this.SetAnim(combineAnim, CostumeAssetType.CombineAnim, dungeonChar);
        }
        else
        {
            this.SetAnim(combineAnim, CostumeAssetType.DungeonAnim, costume.Character);
        }

        if (Enum.TryParse<Character>(costume.Config.Anims.Event, true, out var eventChar))
        {
            this.SetAnim(eventAnim, CostumeAssetType.EventAnim, eventChar);
        }
        else
        {
            this.SetAnim(eventAnim, CostumeAssetType.EventAnim, costume.Character);
        }

        //ModUtils.IfNotNull(costume.Config.Face.AnimPath, path =>
        //{
        //    charRow->FaceAnim.GetObjectPtr()->ObjectId.AssetPathName = *this.unreal.FName(AssetUtils.GetUnrealAssetPath(path));
        //});
    }

    private void SetAnim(TSoftObjectPtr<UAppCharAnimDataAsset>* charAnim, CostumeAssetType animType, Character newCharAnim)
    {
        var currentAnim = this.unreal.GetName(charAnim->GetObjectPtr()->ObjectId.AssetPathName);
        var newAnim = AssetUtils.GetUnrealAssetPath(newCharAnim, 0, animType)!;
        if (currentAnim != newAnim)
        {
            charAnim->baseObj.baseObj.ObjectId.AssetPathName = *this.unreal.FName(newAnim);
            charAnim->baseObj.baseObj.WeakPtr = new();
        }
    }
}
