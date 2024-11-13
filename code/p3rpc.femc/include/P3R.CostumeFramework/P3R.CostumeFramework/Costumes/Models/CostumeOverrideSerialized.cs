namespace P3R.CostumeFramework.Costumes.Models;

internal class CostumeOverrideSerialized
{
    /// <summary>
    /// Name of character the override is for.
    /// </summary>
    public string Character { get; set; } = string.Empty;

    /// <summary>
    /// Costume ID that is being overwritten (or name).
    /// </summary>
    public string OriginalCostumeId { get; set; } = string.Empty;

    /// <summary>
    /// The name of the overriding costume.
    /// Costume Framework costumes don't have set costume IDs 
    /// so only reliable way to reference them (combined with Character).
    /// </summary>
    public string NewCostumeName { get; set; } = string.Empty;
}
