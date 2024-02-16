using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Native
{
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    struct FUIColor //: public FTableRowBase
    {
        [FieldOffset(0x0008)] public float R;                                                                          //  (size: 0x4)
        [FieldOffset(0x000C)] public float G;                                                                          //  (size: 0x4)
        [FieldOffset(0x0010)] public float B;                                                                          //  (size: 0x4)
        [FieldOffset(0x0014)] public float A;                                                                          //  (size: 0x4)

    }; // Size: 0x18

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    struct FUILayout //: public FTableRowBase
    {
        [FieldOffset(0x0008)] public float X;                                                                          //  (size: 0x4)
        [FieldOffset(0x000C)] public float Y;                                                                          //  (size: 0x4)
        [FieldOffset(0x0010)] public float Angle;                                                                      //  (size: 0x4)
        [FieldOffset(0x0014)] public float Scale;                                                                      //  (size: 0x4)

    }; // Size: 0x18

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    struct FUITriangularCursor //: public FTableRowBase
    {
        [FieldOffset(0x0008)] public float X0;                                                                         //  (size: 0x4)
        [FieldOffset(0x000C)] public float Y0;                                                                         //  (size: 0x4)
        [FieldOffset(0x0010)] public float X1;                                                                         //  (size: 0x4)
        [FieldOffset(0x0014)] public float Y1;                                                                         //  (size: 0x4)
        [FieldOffset(0x0018)] public float X2;                                                                         //  (size: 0x4)
        [FieldOffset(0x001C)] public float Y2;                                                                         //  (size: 0x4)

    }; // Size: 0x20
}
