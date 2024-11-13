using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using System.Runtime.InteropServices;
using Unreal.ObjectsEmitter.Interfaces;

namespace P3R.CostumeFramework.Hooks.Animations;

public unsafe class ObjSpawn
{
    private delegate UObject* StaticConstructObject_Internal(FStaticConstructObjectParameters* parameters);
    private StaticConstructObject_Internal? staticConstructObject;

    private delegate UObject* StaticLoadObject(UClass* uclass, UObject* outer, nint name, void* fileName, ELoadFlags loadFlags, void* uPackageMap, bool bAllowObjectReconciliation, void* instancingContext);
    private IHook<StaticLoadObject>? loadObjHook;

    public ObjSpawn()
    {
        ScanHooks.Add(
            nameof(StaticConstructObject_Internal),
            "48 89 5C 24 ?? 48 89 74 24 ?? 55 57 41 54 41 56 41 57 48 8D AC 24 ?? ?? ?? ?? 48 81 EC B0 01 00 00 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 85 ?? ?? ?? ?? 48 8B 39",
            (hooks, result) => this.staticConstructObject = hooks.CreateWrapper<StaticConstructObject_Internal>(result, out _));

        ScanHooks.Add(
            nameof(StaticLoadObject),
            "40 55 53 56 57 41 54 41 55 41 56 41 57 48 8D AC 24 ?? ?? ?? ?? 48 81 EC D8 06 00 00",
            (hooks, result) => this.loadObjHook = hooks.CreateHook<StaticLoadObject>(this.StaticLoadObjectImpl, result).Activate());
    }

    public UObject* StaticLoadObjectImpl(UClass* uclass, UObject* outer, string name)
        => this.StaticLoadObjectImpl(uclass, outer, Marshal.StringToHGlobalUni(name));

    public UObject* StaticLoadObjectImpl(UClass* uclass, UObject* outer, nint name, void* fileName = null, ELoadFlags loadFlags = ELoadFlags.LOAD_None, void* uPackageMap = null, bool bAllowObjectReconciliation = true, void* instancingContext = null)
    {
        var result = this.loadObjHook!.OriginalFunction(uclass, outer, name, fileName, loadFlags, uPackageMap, bAllowObjectReconciliation, instancingContext);
        Log.Information($"{Marshal.PtrToStringUni(name)}");
        return result;
    }

    public UObject* SpawnObject(FStaticConstructObjectParameters parameters)
    {
        var objParams = Marshal.AllocHGlobal(sizeof(FStaticConstructObjectParameters));
        Marshal.StructureToPtr(parameters, objParams, false);
        return this.staticConstructObject!((FStaticConstructObjectParameters*)objParams);
    }
}


[StructLayout(LayoutKind.Explicit, Size = 64)]
public struct FStaticConstructObjectParameters
{
    [FieldOffset(0)]
    public unsafe UClass* Class;

    [FieldOffset(8)]
    public unsafe UObject* Outer;

    [FieldOffset(16)]
    public FName Name;

    [FieldOffset(24)]
    public EObjectFlags SetFlags;

    [FieldOffset(28)]
    public EInternalObjectFlags InternalSetFlags;

    [FieldOffset(32)]
    public byte bCopyTransientsFromClassDefaults;

    [FieldOffset(33)]
    public byte bAssumeTemplateIsArchetype;

    [FieldOffset(40)]
    public unsafe UObject* Template;

    [FieldOffset(48)]
    public nint InstanceGraph;

    [FieldOffset(56)]
    public nint ExternalPackage;
}