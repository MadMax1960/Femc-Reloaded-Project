using System.Runtime.InteropServices;

namespace Project.Utils;

public static class StringsCache
{
    private static readonly Dictionary<string, nint> cachedStrPtrs = new();

    public static nint GetStringPtr(string str)
    {
        if (cachedStrPtrs.TryGetValue(str, out var ptr))
        {
            return ptr;
        }

        var newPtr = Marshal.StringToHGlobalAnsi(str);
        cachedStrPtrs[str] = newPtr;
        return newPtr;
    }
}
