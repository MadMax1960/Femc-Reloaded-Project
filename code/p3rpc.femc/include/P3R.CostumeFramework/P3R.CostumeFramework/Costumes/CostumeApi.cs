using P3R.CostumeFramework.Interfaces;

namespace P3R.CostumeFramework.Costumes;

internal class CostumeApi(CostumeRegistry costumes, CostumeOverridesRegistry overrides) : ICostumeApi
{
    public void AddCostumesFolder(string modId, string folder) => costumes.RegisterMod(modId, folder);

    public void AddOverridesFile(string file) => overrides.AddOverridesFile(file);
}
