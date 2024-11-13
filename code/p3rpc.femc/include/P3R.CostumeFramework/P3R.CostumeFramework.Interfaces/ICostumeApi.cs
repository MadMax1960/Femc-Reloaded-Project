namespace P3R.CostumeFramework.Interfaces;

public interface ICostumeApi
{
    /// <summary>
    /// Add a costume overrides YAML file.
    /// </summary>
    /// <param name="file">File path.</param>
    void AddOverridesFile(string file);

    /// <summary>
    /// Add a folder to load costumes from.
    /// </summary>
    /// <param name="modId">Mod ID.</param>
    /// <param name="folder">Folder path.</param>
    void AddCostumesFolder(string modId, string folder);
}
