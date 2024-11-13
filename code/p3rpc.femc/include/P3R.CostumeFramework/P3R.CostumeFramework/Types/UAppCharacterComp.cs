using System.Runtime.InteropServices;

namespace P3R.CostumeFramework.Types;

[StructLayout(LayoutKind.Explicit, Size = 0x370)]
public unsafe struct UAppCharacterComp
{
    [FieldOffset(0x0000)] public UAppCharBaseComp baseObj;
    [FieldOffset(0x02F8)] public float mBagMotionBlendTime_StandToRun_;
    [FieldOffset(0x02FC)] public float mBagMotionBlendTime_RunToStand_;
    [FieldOffset(0x0300)] public bool bIsBagSetting_;
    [FieldOffset(0x0301)] public bool bIsBagRun_;
    [FieldOffset(0x0304)] public int mBagKeyID_;
    [FieldOffset(0x0308)] public int mOverwirteBagKeyID_;
    [FieldOffset(0x030C)] public bool bIsBagInvalidIK_;
    [FieldOffset(0x0310)] public ACharacterBaseCore* Character;
    [FieldOffset(0x0318)] public bool bNeedInitialize;
    //[FieldOffset(0x0320)] public UAppCharLoader* Loader;
    //[FieldOffset(0x0328)] public TArray<IntPtr> EffectWeapons;
    //[FieldOffset(0x0338)] public TArray<int> HideMaterialIDs;
    [FieldOffset(0x0358)] public int mSetCostumeID;
    [FieldOffset(0x035C)] public int mSetWeaponType;
    [FieldOffset(0x0360)] public int mSetWeaponModelID;
}
