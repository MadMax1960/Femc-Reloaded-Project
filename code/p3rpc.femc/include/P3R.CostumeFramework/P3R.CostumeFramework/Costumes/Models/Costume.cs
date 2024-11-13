namespace P3R.CostumeFramework.Costumes.Models;

internal class Costume
{
    private const string DEF_DESC = "[uf 0 5 65278][uf 2 1]Costume added with Costume Framework.[n][e]";

    public Costume(Character character, int costumeId, string name)
    {
        this.Character = character;
        this.CostumeId = costumeId;
        this.Name = name;
    }

    public Costume(Character character, int costumeId)
    {
        this.Character = character;
        this.CostumeId = costumeId;
    }

    public Costume(int costumeId)
    {
        this.CostumeId = costumeId;
    }

    public Costume()
    {
    }

    public int CostumeItemId { get; private set; }

    public int CostumeId { get; set; }

    public bool IsEnabled { get; set; }

    public Character Character { get; set; } = Character.NONE;

    public string? Name
    {
        get => this.Config.Name;
        set => this.Config.Name = value;
    }

    public string Description { get; set; } = DEF_DESC;

    public CostumeConfig Config { get; set; } = new();

    public string? OwnerModId { get; set; }

    public string? MusicScriptFile { get; set; }

    public string? BattleThemeFile { get; set; }

    public string RyoGroupId => this.Config.RyoGroupId ?? $"{this.Character}.{this.CostumeId}";

    public void SetCostumeItemId(int costumeItemId)
    {
        this.CostumeItemId = costumeItemId;
        Log.Debug($"Set Costume Item ID: {this.Character} || {this.Name} || {this.CostumeItemId}");
    }

    public static bool IsItemIdCostume(int itemId) => itemId >= 0x8000 && itemId < 0x9000;

    public static int GetCostumeItemId(int itemId) => itemId - 0x8000;

    public static bool IsActive(Costume costume) => costume.IsEnabled && costume.Character != Character.NONE;
}
