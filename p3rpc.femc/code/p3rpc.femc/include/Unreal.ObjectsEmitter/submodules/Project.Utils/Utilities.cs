using System.Diagnostics;

namespace Project.Utils;

public static class Utilities
{
    public readonly static string PushCallerRegisters = "push rcx\npush rdx\npush r8\npush r9";
    public readonly static string PopCallerRegisters = "pop r9\npop r8\npop rdx\npop rcx";
    public readonly static nint BaseAddress = Process.GetCurrentProcess().MainModule?.BaseAddress ?? 0;

    public static ushort ToBigEndian(this ushort value)
    {
        var bigEndianValue = BitConverter.ToUInt16(BitConverter.GetBytes(value).Reverse().ToArray());
        return bigEndianValue;
    }

    public static uint ToBigEndian(this uint value)
    {
        var bigEndianValue = BitConverter.ToUInt32(BitConverter.GetBytes(value).Reverse().ToArray());
        return bigEndianValue;
    }

    public static short ToBigEndian(this short value)
    {
        var bigEndianValue = BitConverter.ToInt16(BitConverter.GetBytes(value).Reverse().ToArray());
        return bigEndianValue;
    }
}
