namespace P3R.CostumeFramework.Costumes.Models;

internal class CostumeOverride
{
    /// <summary>
    /// Character the override is for.
    /// </summary>
    public Character Character { get; set; }

    /// <summary>
    /// Costume ID that is being overwritten.
    /// </summary>
    public int OriginalCostumeId { get; set; }

    /// <summary>
    /// The name of the overriding costume.
    /// Costume Framework costumes don't have set costume IDs 
    /// so only reliable way to reference them (combined with Character).
    /// </summary>
    public string NewCostumeName { get; set; } = string.Empty;
}
