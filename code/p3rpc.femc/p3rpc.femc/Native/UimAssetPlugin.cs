using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Native
{
    // GENERATED FROM UE4SS CXX HEADER DUMP
    struct FUim2DVertCol
    {
        float X;                                                                          // 0x0000 (size: 0x4)
        float Y;                                                                          // 0x0004 (size: 0x4)
        uint Color;                                                                       // 0x0008 (size: 0x4)

    }; // Size: 0xC

    struct FUim2DVertColUV
    {
        float X;                                                                          // 0x0000 (size: 0x4)
        float Y;                                                                          // 0x0004 (size: 0x4)
        uint Color;                                                                     // 0x0008 (size: 0x4)
        float U0;                                                                         // 0x000C (size: 0x4)
        float V0;                                                                         // 0x0010 (size: 0x4)

    }; // Size: 0x14

    struct FUim2DVertUV
    {
        float X;                                                                          // 0x0000 (size: 0x4)
        float Y;                                                                          // 0x0004 (size: 0x4)
        float U0;                                                                         // 0x0008 (size: 0x4)
        float V0;                                                                         // 0x000C (size: 0x4)

    }; // Size: 0x10

    struct FUim2DVertex
    {
        float X;                                                                          // 0x0000 (size: 0x4)
        float Y;                                                                          // 0x0004 (size: 0x4)

    }; // Size: 0x8

    struct FUim3DVertCol
    {
        float X;                                                                          // 0x0000 (size: 0x4)
        float Y;                                                                          // 0x0004 (size: 0x4)
        float Z;                                                                          // 0x0008 (size: 0x4)
        uint Color;                                                                       // 0x000C (size: 0x4)

    }; // Size: 0x10

    struct FUim3DVertColUV
    {
        float X;                                                                          // 0x0000 (size: 0x4)
        float Y;                                                                          // 0x0004 (size: 0x4)
        float Z;                                                                          // 0x0008 (size: 0x4)
        uint Color;                                                                       // 0x000C (size: 0x4)
        float U0;                                                                         // 0x0010 (size: 0x4)
        float V0;                                                                         // 0x0014 (size: 0x4)

    }; // Size: 0x18

    struct FUim3DVertUV
    {
        float X;                                                                          // 0x0000 (size: 0x4)
        float Y;                                                                          // 0x0004 (size: 0x4)
        float Z;                                                                          // 0x0008 (size: 0x4)
        float U0;                                                                         // 0x000C (size: 0x4)
        float V0;                                                                         // 0x0010 (size: 0x4)

    }; // Size: 0x14

    struct FUim3DVertex
    {
        float X;                                                                          // 0x0000 (size: 0x4)
        float Y;                                                                          // 0x0004 (size: 0x4)
        float Z;                                                                          // 0x0008 (size: 0x4)

    }; // Size: 0xC

    [StructLayout(LayoutKind.Explicit, Size = 0x130)]
    struct FUimData
    {
        [FieldOffset(0x0000)] public uint frameSkip;
        [FieldOffset(0x0004)] public int frameNum;
        [FieldOffset(0x0008)] public int vertexNum;
        [FieldOffset(0x000C)] public int polygonNum;
        [FieldOffset(0x0010)] public int indexNum;
        [FieldOffset(0x0014)] public int coordinate;
        [FieldOffset(0x0018)] public int geomFormat;
        [FieldOffset(0x001C)] public int animFormat;
        [FieldOffset(0x0020)] public TArray<FUim2DVertex> p2DGeomVertex;
        [FieldOffset(0x0030)] public TArray<FUim2DVertCol> p2DGeomVertCol;
        [FieldOffset(0x0040)] public TArray<FUim2DVertColUV> p2DGeomVertColUV;
        [FieldOffset(0x0050)] public TArray<FUim2DVertUV> p2DGeomVertUV;
        [FieldOffset(0x0060)] public TArray<FUim2DVertex> p2DAnimVertex;
        [FieldOffset(0x0070)] public TArray<FUim2DVertCol> p2DAnimVertCol;
        [FieldOffset(0x0080)] public TArray<FUim2DVertColUV> p2DAnimVertColUV;
        [FieldOffset(0x0090)] public TArray<FUim2DVertUV> p2DAnimVertUV;
        [FieldOffset(0x00A0)] public TArray<FUim3DVertex> p3DGeomVertex;
        [FieldOffset(0x00B0)] public TArray<FUim3DVertCol> p3DGeomVertCol;
        [FieldOffset(0x00C0)] public TArray<FUim3DVertColUV> p3DGeomVertColUV;
        [FieldOffset(0x00D0)] public TArray<FUim3DVertUV> p3DGeomVertUV;
        [FieldOffset(0x00E0)] public TArray<FUim3DVertex> p3DAnimVertex;
        [FieldOffset(0x00F0)] public TArray<FUim3DVertCol> p3DAnimVertCol;
        [FieldOffset(0x0100)] public TArray<FUim3DVertColUV> p3DAnimVertColUV;
        [FieldOffset(0x0110)] public TArray<FUim3DVertUV> p3DAnimVertUV;
        [FieldOffset(0x0120)] public TArray<ushort> Indices;

    };

    [StructLayout(LayoutKind.Explicit, Size = 0x158)]
    public unsafe struct UUimAsset //: public UObject
    {
        [FieldOffset(0x0028)] FUimData UimData;
    };
}
