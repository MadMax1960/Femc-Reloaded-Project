namespace BGME.BattleThemes.Interfaces;

public interface IBattleThemesApi
{
    /// <summary>
    /// Add a path to load themes from. Can be a <c>file</c> or <c>folder</c>.
    /// </summary>
    /// <param name="path">Path to theme file or folder containing themes.</param>
    void AddPath(string modId, string path);

    /// <summary>
    /// Remove a previously added theme path.
    /// </summary>
    /// <param name="path">Theme path.</param>
    void RemovePath(string path);
}
