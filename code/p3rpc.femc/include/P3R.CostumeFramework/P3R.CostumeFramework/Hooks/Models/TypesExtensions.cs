namespace P3R.CostumeFramework.Hooks.Models;

public static class TypesExtensions
{
    public unsafe static TPersistentObjectPtr<FSoftObjectPath>* GetObjectPtr<T>(this TSoftObjectPtr<T> obj)
         where T : unmanaged => &obj.baseObj.baseObj;

    public unsafe static TPersistentObjectPtr<FSoftObjectPath>* GetClassPtr<T>(this TSoftClassPtr<T> obj)
         where T : unmanaged => &obj.baseObj.baseObj;
}