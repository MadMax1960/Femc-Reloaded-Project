using System.Runtime.InteropServices;
using System.Text;

namespace P3R.CostumeFramework.Costumes;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct DataTableString
{
    public const int MAX_LENGTH = 1023;

    public DataTableString(string newString)
    {
        this.Flags = (1023 << 6) | 32;
        this.SetString(newString);
    }

    public ushort Flags;

    public void SetString(string newString)
    {
        if (newString.Length > MAX_LENGTH)
        {
            Log.Warning($"New data table string longer than max length: {MAX_LENGTH}\nString: {newString}");
            return;
        }

        var flagsMask = 0b111111;
        var flagsValue = this.Flags & flagsMask;
        var newLength = newString.Length;
        var newDtFlags = (ushort)((newLength << 6) | flagsValue);
        this.Flags = newDtFlags;

        var bytes = Encoding.ASCII.GetBytes(newString);
        fixed (DataTableString* self = &this)
        {
            var strStart = (nint)self + 2;
            Marshal.Copy(bytes, 0, strStart, bytes.Length);
        }
    }

    public string? GetString()
    {
        fixed (DataTableString* self = &this)
        {
            var strStart = (byte*)self + 2;
            var length = this.GetLength();
            var buffer = new byte[length];
            Marshal.Copy((nint)strStart, buffer, 0, length);
            return Encoding.ASCII.GetString(buffer);
        }
    }

    public readonly int GetLength() => this.Flags >> 6;

    public static DataTableString* Create()
    {
        var instance = new DataTableString();
        var pointer = (DataTableString*)Marshal.AllocHGlobal(MAX_LENGTH + 2);
        *pointer = instance;
        return pointer;
    }
}
