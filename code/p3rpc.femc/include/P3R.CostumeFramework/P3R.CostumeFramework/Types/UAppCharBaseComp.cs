using System.Runtime.InteropServices;
using P3R.CostumeFramework.Costumes;

namespace P3R.CostumeFramework.Types;

[StructLayout(LayoutKind.Explicit, Size = 0x300)]
public unsafe struct UAppCharBaseComp
{
    //[FieldOffset(0x0000)] public UActorComponent baseObj;
    //[FieldOffset(0x00E0)] public AActor* mMotionAttached_;
    //[FieldOffset(0x00E8)] public FName mMotionAttachedSocketName_;
    //[FieldOffset(0x00F0)] public FTransform mMotionAttachedTransform;
    [FieldOffset(0x0120)] public bool mMotionDetachPrepared_;
    [FieldOffset(0x0121)] public bool bMotionDetachPreparedTransKeep_;
    [FieldOffset(0x0122)] public bool bMotionDetachPreparedRelativeTrans_;
    //[FieldOffset(0x0124)] public FRotator mMotionDetachPreparedRelativeRotator_;
    //[FieldOffset(0x0130)] public FVector mMotionDetachPreparedRelativeLocation_;
    [FieldOffset(0x0150)] public int mFadeType_;
    [FieldOffset(0x0154)] public int mFadeFrame_;
    [FieldOffset(0x0158)] public int mFadePattern_;
    [FieldOffset(0x0190)] public bool mDelayPauseAnimReq_;
    [FieldOffset(0x0191)] public bool mDelayPauseAnimFlag_;
    [FieldOffset(0x0194)] public float mDelayPauseAnimSpeedRate_;
    //[FieldOffset(0x0198)] public TSoftClassPtr<AAppPropsCore> mBagClassPtr_;
    //[FieldOffset(0x01C0)] public FName mBagAttachSocketName;
    //[FieldOffset(0x01C8)] public FName mBagAnimSlotName_;
    //[FieldOffset(0x01D0)] public TMap<EAppCharBagAnimType, IntPtr> mBagAnims_;
    //[FieldOffset(0x0220)] public AAppPropsCore* mBagActor_;
    [FieldOffset(0x0228)] public bool bIsLockedLookAt_;
    [FieldOffset(0x0229)] public byte mLockedLookAtType_;
    [FieldOffset(0x022C)] public float mLockedLookAtSpeed_;
    //[FieldOffset(0x0230)] public USkeletalMeshComponent* CostumeMesh;
    //[FieldOffset(0x0238)] public USkeletalMeshComponent* HairMesh;
    //[FieldOffset(0x0240)] public USkeletalMeshComponent* FaceMesh;
    //[FieldOffset(0x0248)] public UAppCharFootstepsAtom* FootstepsAtom;
    //[FieldOffset(0x0250)] public UAnimMontage* AnimMontage_DefaultSlot;
    //[FieldOffset(0x0258)] public UAnimMontage* AnimMontage_FacialSlot;
    //[FieldOffset(0x0260)] public UAnimMontage* AnimMontage_NeckSlot;
    //[FieldOffset(0x0268)] public UAnimMontage* AnimMontage_TurnSlot;
    //[FieldOffset(0x0278)] public UAnimMontage* AnimMontage_HavBagSlot;
    //[FieldOffset(0x0280)] public EAppCharCategoryType CategoryID;
    //[FieldOffset(0x0284)] public int IndexID;
    [FieldOffset(0x0284)] public Character Character;
    [FieldOffset(0x0288)] public int CostumeID;
    //[FieldOffset(0x028C)] public EAnimPackID AnimPackID;
    //[FieldOffset(0x0290)] public UAppCharAnimDataAsset* AnimPack;
    //[FieldOffset(0x0298)] public UAppCharFaceAnimDataAsset* FaceAnimPack;
    //[FieldOffset(0x02A0)] public EAppCharWeaponType WeaponType;
    [FieldOffset(0x02A4)] public int WeaponId;
    //[FieldOffset(0x02A8)] public TArray<IntPtr> Weapons;
    [FieldOffset(0x02B8)] public bool bBagEnable;
    [FieldOffset(0x02BC)] public int ShoesID;
    //[FieldOffset(0x02C0)] public EAppCharState State;
    //[FieldOffset(0x02C4)] public FVector MoveLocation;
    [FieldOffset(0x02D0)] public float MoveSpeed;
    [FieldOffset(0x02D4)] public bool bTransparencyEnable;
    //[FieldOffset(0x02D8)] public FAppCharTransparency Transparency;
}
