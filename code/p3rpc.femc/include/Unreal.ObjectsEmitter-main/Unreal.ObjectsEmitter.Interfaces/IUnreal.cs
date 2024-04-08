using System.Diagnostics.CodeAnalysis;
using Unreal.ObjectsEmitter.Interfaces.Types;

namespace Unreal.ObjectsEmitter.Interfaces;

public unsafe interface IUnreal
{
    /// <summary>
    /// FName constructor/getter.
    /// </summary>
    /// <param name="str">String of FName.</param>
    /// <param name="findType">Find type, defaults to find or add.</param>
    /// <returns>FName instance.</returns>
    FName* FName(string str, EFindName findType = EFindName.FName_Add);

    /// <summary>
    /// Get the string of the given <see cref="FName"/>.
    /// </summary>
    /// <param name="name">FName instance.</param>
    /// <returns><see cref="FName"/> string value.</returns>
    string GetName(FName* name);

    /// <summary>
    /// Get the string of the name at the given location in name pool.
    /// </summary>
    /// <param name="poolLoc">Location in name pool.</param>
    /// <returns><see cref="Types.FName"/> string value.</returns>
    string GetName(uint poolLoc);

    /// <summary>
    /// Assign a new string to an FName with the given string value.
    /// Essentially acts as overwriting an FName at runtime.
    /// </summary>
    /// <param name="modName">Mod name.</param>
    /// <param name="fnameString">String value of FName to set.</param>
    /// <param name="newString">New string value.</param>
    void AssignFName(string modName, string fnameString, string newString);

    nint FMalloc(long size, int alignment);

    FNamePool* GetPool();
}