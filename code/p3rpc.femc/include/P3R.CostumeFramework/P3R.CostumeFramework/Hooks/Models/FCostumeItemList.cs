using System.Runtime.InteropServices;
using Unreal.ObjectsEmitter.Interfaces.Types;

namespace P3R.CostumeFramework.Hooks.Models;

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe struct FCostumeItemList
{
    [FieldOffset(0x0000)] public FString ItemDef;
    [FieldOffset(0x0010)] public ushort SortNum;
    [FieldOffset(0x0014)] public uint ItemType;
    [FieldOffset(0x0018)] public EquipFlag EquipID;
    [FieldOffset(0x001C)] public uint Price;
    [FieldOffset(0x0020)] public uint SellPrice;
    [FieldOffset(0x0024)] public ushort GetFLG;
    [FieldOffset(0x0028)] public uint ReflectType;
    [FieldOffset(0x002C)] public ushort CostumeID;
}
