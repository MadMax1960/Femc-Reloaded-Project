using System.Runtime.InteropServices;

namespace P3R.CostumeFramework.Types;

[StructLayout(LayoutKind.Explicit, Size = 0x5A0)]
public unsafe struct ACharacterBaseCore
{
    //[FieldOffset(0x0000)] public ACharacter baseObj;
    //[FieldOffset(0x04B8)] public UCBL_LoaderBase* _SkeletalMeshLoader;
    //[FieldOffset(0x04C0)] public UCBL_LoaderBase* _AnimBpLoader;
    //[FieldOffset(0x04C8)] public TArray<IntPtr> _SkeletalMeshCompArray;
    [FieldOffset(0x04D8)] public bool _RecalcBounds;
    [FieldOffset(0x04D9)] public bool _AutoLoading;
    //[FieldOffset(0x04E0)] public UCB_HumanMeshPackAsset* _MeshPackAsset;
    [FieldOffset(0x0528)] public int _PreviewMeshNo;
    [FieldOffset(0x052C)] public int _PreviewCostumeNo;
    [FieldOffset(0x0530)] public int _PreviewHairNo;
    [FieldOffset(0x0534)] public int _PreviewFaceNo;
    //[FieldOffset(0x0548)] public UCB_HumanAnimPackAsset* _AnimPackAsset;
    [FieldOffset(0x0580)] public int _PreviewMeshAnimNo;
    [FieldOffset(0x0584)] public int _PreviewCostumeAnimNo;
    [FieldOffset(0x0588)] public int _PreviewHairAnimNo;
}