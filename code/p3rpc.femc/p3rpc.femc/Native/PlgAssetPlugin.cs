using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Native
{
    // GENERATED FROM UE4SS CXX HEADER DUMP
    public struct FPlgData
    {
        TArray<FPlgPrimitiveData> PlgDatas;                                               // 0x0000 (size: 0x10)

    }; // Size: 0x10

    public unsafe struct FPlgPrimitiveData
    {
        TArray<FVector> Vertices;                                                         // 0x0000 (size: 0x10)
        TArray<ushort> Indices;                                                           // 0x0010 (size: 0x10)
        TArray<uint> Colors;                                                              // 0x0020 (size: 0x10)
        FName Name;                                                                       // 0x0030 (size: 0x8)
        float MinX;                                                                       // 0x0038 (size: 0x4)
        float MinY;                                                                       // 0x003C (size: 0x4)
        float MaxX;                                                                       // 0x0040 (size: 0x4)
        float MaxY;                                                                       // 0x0044 (size: 0x4)

    }; // Size: 0x48

    public unsafe struct UPlgAsset //: public UObject
    {
        FPlgData PlgData;                                                                 // 0x0028 (size: 0x10)
    }; // Size: 0x38

    public unsafe struct UPlgPrimitiveComponent //: public UMeshComponent
    {
        UPlgAsset* PlgAsset;                                                        // 0x0478 (size: 0x8)
        int PlgPrimitiveNo;                                                             // 0x0480 (size: 0x4)
    }; // Size: 0x490
}
