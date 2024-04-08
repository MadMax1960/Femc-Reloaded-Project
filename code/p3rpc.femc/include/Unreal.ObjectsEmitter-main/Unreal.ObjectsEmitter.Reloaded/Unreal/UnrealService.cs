using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using System.Runtime.InteropServices;
using Unreal.ObjectsEmitter.Interfaces;
using Unreal.ObjectsEmitter.Interfaces.Types;

namespace Unreal.ObjectsEmitter.Reloaded.Unreal;

internal unsafe class UnrealService : IUnreal
{
    [Function(CallingConventions.Microsoft)]
    private delegate FName* FName_ctor(FName* name, nint str, EFindName findTyp);
    private IHook<FName_ctor>? fname;

    [Function(CallingConventions.Microsoft)]
    private delegate nint FMemory_Malloc(long size, int alignment);
    private FMemory_Malloc? fmalloc;

    private readonly Dictionary<string, string> fnameAssigns = new();
    private FNamePool* g_namePool;

    public UnrealService()
    {
        ScanHooks.Add(
            "FGlobalNamePool",
            "4C 8D 05 ?? ?? ?? ?? EB ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 4C 8B C0 C6 05 " +
            "?? ?? ?? ?? 01 48 8B 44 24 ?? 48 8B D3 48 C1 E8 20 8D 0C ?? 49 03 4C ?? ?? E8 " +
            "?? ?? ?? ?? 48 8B C3",
            (hooks, result) =>
            {
                var namePoolPtr = GetGlobalAddress(result + 3);
                g_namePool = (FNamePool*)namePoolPtr;
            });

        ScanHooks.Add(
            "FName Constructor",
            "48 89 5C 24 ?? 57 48 83 EC 30 48 8B D9 48 89 54 24 ?? 33 C9 41 8B F8 4C 8B DA",
            (hooks, result) =>
            {
                this.fname = hooks.CreateHook<FName_ctor>(this.FName, result).Activate();
            });

        ScanHooks.Add(
            nameof(FMemory_Malloc),
            "48 89 5C 24 ?? 57 48 83 EC 20 48 8B F9 8B DA 48 8B 0D ?? ?? ?? ?? 48 85 C9",
            (hooks, result) => this.fmalloc = hooks.CreateWrapper<FMemory_Malloc>(result, out _));
    }

    public void AssignFName(string modName, string fnameString, string newString)
    {
        if (fnameString == newString)
        {
            Log.Error($"Attempted to redirect FName to itself. This is considered an error and should be fixed. Mod: {modName} || String: {newString}");
            return;
        }

        this.fnameAssigns[fnameString] = newString;
        Log.Debug($"Assigned FName: {fnameString}\nMod: {modName} || New: {newString}");
    }

    public FName* FName(string str, EFindName findType = EFindName.FName_Add)
    {
        //var fname = (FName*)Marshal.AllocHGlobal(8);
        var fname = (FName*)this.fmalloc!(8, 16);
        var strPtr = StringsCache.GetStringPtrUni(str);
        return this.FName(fname, strPtr, findType);
    }

    public nint FMalloc(long size, int alignment) => this.fmalloc!(size, alignment);

    public FName* FName(FName* name, nint str, EFindName findType)
    {
        var nameString = Marshal.PtrToStringUni(str) ?? string.Empty;

        if (!string.IsNullOrEmpty(nameString) && this.fnameAssigns.TryGetValue(nameString, out var newString))
        {
            *name = *this.FName(newString);
        }
        else
        {
            this.fname!.OriginalFunction(name, str, findType);
        }

        return name;
    }

    public string GetName(FName* name)
        => g_namePool->GetString(name->pool_location);

    public string GetName(FName name)
        => g_namePool->GetString(name.pool_location);

    public string GetName(uint poolLocation)
        => g_namePool->GetString(poolLocation);

    public FNamePool* GetPool() => g_namePool;

    private static nuint GetGlobalAddress(nint ptrAddress)
    {
        return (nuint)(*(int*)ptrAddress + ptrAddress + 4);
    }
}
