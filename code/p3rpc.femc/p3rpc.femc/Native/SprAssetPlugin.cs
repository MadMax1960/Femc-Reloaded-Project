using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Native
{
    // GENERATED FROM UE4SS CXX HEADER DUMP
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public struct FSprData
    {
        [FieldOffset(0x0000)] float Width;
        [FieldOffset(0x0004)] float Height;
        [FieldOffset(0x0008)] float U0;
        [FieldOffset(0x000C)] float V0;
        [FieldOffset(0x0010)] float U1;
        [FieldOffset(0x0014)] float v1;
        [FieldOffset(0x0018)] nint Texture;
        [FieldOffset(0x0020)] uint RGBA;
        [FieldOffset(0x0030)] short StretchLen;
        [FieldOffset(0x0038)] uint ScalingSize;

    }; // Size: 0x40

    public struct FSprDataArray
    {
        TArray<FSprData> SprDatas;
    }; // Size: 0x10

    [StructLayout(LayoutKind.Explicit, Size = 0x90)]
    public unsafe struct USprAsset //: public UObject
    {
        [FieldOffset(0x0028)] public TArray<nint> mTexArray; // UTexture*
        [FieldOffset(0x0038)] TMap SprDatas;
    };
}
