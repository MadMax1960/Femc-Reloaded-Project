using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Native
{
    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public unsafe struct UBfAsset //: public UObject
    {
        [FieldOffset(0x28)] TArray<byte> mBuf;
    };
}
