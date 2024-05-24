using Unreal.ObjectsEmitter.Interfaces.Types;

namespace Unreal.ObjectsEmitter.Interfaces;

public interface IUObjects
{
    /// <summary>
    /// Event fired when UObject constructor is called.
    /// </summary>
    Action<UnrealObject>? ObjectCreated { get; set; }

    /// <summary>
    /// Finds and send the given object whenever one is created.
    /// </summary>
    /// <param name="objectName">Name of object.</param>
    /// <param name="found">Callback to pass object to.</param>
    /// <param name="isReady">Optional condition to statisfy before sending.</param>
    void FindObject(string objectName, Action<UnrealObject> found, Func<UnrealObject, bool>? isReady = null);
}