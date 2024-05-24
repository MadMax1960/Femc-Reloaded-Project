using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using Unreal.ObjectsEmitter.Interfaces;
using Unreal.ObjectsEmitter.Interfaces.Types;
using Unreal.ObjectsEmitter.Reloaded.Unreal;

namespace Unreal.ObjectsEmitter.Reloaded.Objects;

internal unsafe class UObjectsService : IUObjects
{
    private record ObjectListener(string ObjectName, Action<UnrealObject> Found, Func<UnrealObject, bool>? IsReady);

    [Function(CallingConventions.Microsoft)]
    private delegate UObject* UObject_Constructor(UObject* self);
    private IHook<UObject_Constructor>? objConstructor;

    private readonly UnrealService unreal;
    private readonly List<ObjectListener> listeners = new();
    private bool logObjects;

    public UObjectsService(UnrealService unreal)
    {
        this.unreal = unreal;

        ScanHooks.Add(
            "UObject Function_14197ffb0 (Called after initalized and ready)",
            //"48 89 5C 24 ?? 57 48 83 EC 40 48 8D 05 ?? ?? ?? ?? 48 8B F9 48 89 01 E8 ?? ?? ?? ?? 48 8D 44 24",
            //"48 83 EC 38 48 8B 41 ?? 8B 90",
            "40 53 48 83 EC 20 48 8B 41 ?? 48 8B D9 8B 90 ?? ?? ?? ?? C1 EA 17",
            (hooks, result) => this.objConstructor = hooks.CreateHook<UObject_Constructor>(this.UObject, result).Activate());

        this.ObjectCreated += (UnrealObject obj) =>
        {
            var objListeners = this.listeners.Where(x => x.ObjectName == obj.Name).ToArray();
            if (objListeners.Length < 1)
            {
                return;
            }

            foreach (var listener in objListeners)
            {
                listener.Found(obj);
            }
        };
    }

    public Action<UnrealObject>? ObjectCreated { get; set; }

    public void FindObject(string objectName, Action<UnrealObject> found, Func<UnrealObject, bool>? isReady = null)
        => this.listeners.Add(new(objectName, found, isReady));

    public void SetLogObjects(bool logObjects) => this.logObjects = logObjects;

    private UObject* UObject(UObject* self)
    {
        var result = this.objConstructor!.OriginalFunction(self);

        var name = this.unreal.GetName(&self->NamePrivate);
        if (this.logObjects)
        {
            Log.Information($"UObject: {name} || {(nint)self:X}");
        }

        this.ObjectCreated?.Invoke(new(name, self));
        return result;
    }
}
