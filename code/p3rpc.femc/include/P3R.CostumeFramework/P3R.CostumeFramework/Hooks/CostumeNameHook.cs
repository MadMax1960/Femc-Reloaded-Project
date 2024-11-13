using P3R.CostumeFramework.Costumes;
using System.Runtime.InteropServices;
using Unreal.ObjectsEmitter.Interfaces;
using Unreal.ObjectsEmitter.Interfaces.Types;

namespace P3R.CostumeFramework.Hooks;

internal unsafe class CostumeNameHook
{
	public CostumeNameHook(IUObjects uobjects, IUnreal unreal, CostumeRegistry registry)
	{
		uobjects.FindObject("DatItemCostumeNameDataAsset", obj =>
		{
			var nameTable = (UItemNameListTable*)obj.Self;

			for (int i = 0; i < nameTable->Data.Num; i++)
			{
				var costume = registry.Costumes.FirstOrDefault(x => x.CostumeItemId == i);

				if (costume?.Name != null)
                {
                    nameTable->Data.AllocatorInstance[i] = unreal.FString(costume.Name);
                    Log.Debug($"Set name for Costume Item ID: {i} || Name: {costume.Name}");
                }
			}
		});
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct UItemNameListTable
{
    //[FieldOffset(0x0000)] public UAppDataAsset baseObj;
    [FieldOffset(0x0030)] public TArray<FString> Data;
}
