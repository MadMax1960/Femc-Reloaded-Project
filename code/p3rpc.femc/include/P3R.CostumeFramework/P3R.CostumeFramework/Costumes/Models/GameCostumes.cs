using P3R.CostumeFramework.Types;
using System.Collections;
using System.Reflection;
using System.Text.Json;

namespace P3R.CostumeFramework.Costumes.Models;

internal class GameCostumes : IReadOnlyList<Costume>
{
    public const int BASE_MOD_COSTUME_ID = 1000;
    public const int RANDOMIZED_COSTUME_ID = 10001;
    private const int NUM_MOD_COSTUMES = 10000;

    private readonly List<int> disabledCostumes = [154, 501, 502, 503, 504];

    private readonly CostumeFilter filterSetting;
    private readonly Dictionary<CostumeFilter, int[]> filters = new()
    {
        [CostumeFilter.Non_Fanservice] = [102, 104, 106]
    };

    private readonly List<Costume> costumes = [];

    public GameCostumes(CostumeFilter filter, bool useExtendedOutfits)
    {
        this.filterSetting = filter;

        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "P3R.CostumeFramework.Resources.costumes.json";
        using var stream = assembly.GetManifestResourceStream(resourceName)!;
        using var reader = new StreamReader(stream);
        var json = reader.ReadToEnd();

        var gameCostumes = JsonSerializer.Deserialize<Dictionary<Character, Costume[]>>(json)!;
        foreach (var charCostumes in gameCostumes)
        {
            this.costumes.AddRange(charCostumes.Value);
        }

        if (useExtendedOutfits)
        {
            this.UseExtendedOutfits();
        }

        // Enable all existing costumes.
        foreach (var costume in this.costumes)
        {
            costume.IsEnabled = IsCostumeEnabled(costume);
        }

        // Add randomized costumes.
        for (int i = 1; i < 12; i++)
        {
            var character = (Character)i;
            this.costumes.Add(new(character, RANDOMIZED_COSTUME_ID)
            {
                Name = "Randomized Costumes",
                Description = "[uf 0 5 65278][uf 2 1]Mystical clothes that randomly take the form of other outfits.[n][e]",
                IsEnabled = true,
            });
        }

        // Add mod costume slots.
        for (int i = 0; i < NUM_MOD_COSTUMES; i++)
        {
            var costumeId = BASE_MOD_COSTUME_ID + i;
            var costume = new Costume(costumeId);
            this.costumes.Add(costume);
        }
    }

    private void UseExtendedOutfits()
    {
        Log.Information("Mod Integration Enabled: Extended Outfits");
        int[] eoCostumeIds = [1, 2, 5, 6, 51, 52, 101, 102, 103, 104, 106, 151, 154, 155, 158, 159, 160, 161, 162, 201];
        this.disabledCostumes.AddRange(eoCostumeIds);

        this.costumes.Add(new(Character.Player, 303, "Hotel Yukata") { IsEnabled = false });
        this.costumes.Add(new(Character.Player, 305, "Ball Stage Outfit") { IsEnabled = true });
        this.costumes.Add(new(Character.Player, 306, "Black Shirt") { IsEnabled = true });
        this.costumes.Add(new(Character.Player, 307, "Pumpkin Clown Outfit (placeholder)") { IsEnabled = false });
        this.costumes.Add(new(Character.Player, 308, "Santa Costume (placeholder)") { IsEnabled = false });
        this.costumes.Add(new(Character.Player, 309, "WEGO T-Shirt (placeholder)") { IsEnabled = false });
        this.costumes.Add(new(Character.Player, 310, "Martial Arts Master Gi") { IsEnabled = false });
        this.costumes.Add(new(Character.Player, 311, "Girly Maid Uniform (placeholder)") { IsEnabled = false });
        this.costumes.Add(new(Character.Player, 312, "PS2 models") { IsEnabled = false });

        this.costumes.Add(new(Character.Yukari, 300, "Dorm Kitchen Apron") { IsEnabled = false });
        this.costumes.Add(new(Character.Yukari, 302, "Summer Festival Yukata") { IsEnabled = false });
        this.costumes.Add(new(Character.Yukari, 301, "Hotel Yukata") { IsEnabled = false });

        this.costumes.Add(new(Character.Stupei, 300, "Hotel Yukata") { IsEnabled = false });

        this.costumes.Add(new(Character.Akihiko, 300, "Hotel Yukata") { IsEnabled = false });

        this.costumes.Add(new(Character.Mitsuru, 300, "Uniform & Armband (Ponytail)") { IsEnabled = true });
        this.costumes.Add(new(Character.Mitsuru, 301, "SEES Uniform (Ponytail)") { IsEnabled = true });
        this.costumes.Add(new(Character.Mitsuru, 302, "Winter Uniform (Ponytail)") { IsEnabled = true });
        this.costumes.Add(new(Character.Mitsuru, 303, "Summer Garb (Ponytail)") { IsEnabled = true });
        this.costumes.Add(new(Character.Mitsuru, 304, "Winter Garb (Ponytail)") { IsEnabled = true });
        this.costumes.Add(new(Character.Mitsuru, 305, "Maid Outfit (Untied)") { IsEnabled = true });
        this.costumes.Add(new(Character.Mitsuru, 306, "Elegant Bikini (Ponytail)") { IsEnabled = true });
        this.costumes.Add(new(Character.Mitsuru, 307, "Sexy Armor (Untied)") { IsEnabled = true });
        //this.costumes.Add(new(Character.Mitsuru, 308, "Yasogami Uniform (Ponytail)") { IsEnabled = true });
        //this.costumes.Add(new(Character.Mitsuru, 309, "Shujin Uniform (Ponytail)") { IsEnabled = true });
        //this.costumes.Add(new(Character.Mitsuru, 310, "Metal Rider (Untied)") { IsEnabled = true });
        this.costumes.Add(new(Character.Mitsuru, 311, "Dorm Kitchen Apron") { IsEnabled = true });
        this.costumes.Add(new(Character.Mitsuru, 312, "Dorm Kitchen Apron (Untied)") { IsEnabled = true });
        this.costumes.Add(new(Character.Mitsuru, 313, "Summer Festival Yukata") { IsEnabled = false });
        this.costumes.Add(new(Character.Mitsuru, 314, "New Years Kimono") { IsEnabled = false });
        this.costumes.Add(new(Character.Mitsuru, 315, "Hotel Yukata") { IsEnabled = false });

        this.costumes.Add(new(Character.Shinjiro, 300, "SEES Uniform (Ponytail)") { IsEnabled = true });
        this.costumes.Add(new(Character.Shinjiro, 301, "Dorm Kitchen Apron") { IsEnabled = false });
        this.costumes.Add(new(Character.Shinjiro, 302, "Dorm Kitchen Apron (Ponytail)") { IsEnabled = true });
        this.costumes.Add(new(Character.Shinjiro, 303, "Duds & Armband (Ponytail)") { IsEnabled = true });
        this.costumes.Add(new(Character.Shinjiro, 304, "SEES Uniform (Ponytail)") { IsEnabled = true });
        this.costumes.Add(new(Character.Shinjiro, 305, "Winter Garb (Ponytail)") { IsEnabled = true });
        this.costumes.Add(new(Character.Shinjiro, 306, "Tuxedo (Beanie)") { IsEnabled = true });
        this.costumes.Add(new(Character.Shinjiro, 307, "Bicolor Shorts (Beanie)") { IsEnabled = true });
        //this.costumes.Add(new(Character.Shinjiro, 308, "Yasogami Uniform (Beanie)") { IsEnabled = true });
        //this.costumes.Add(new(Character.Shinjiro, 309, "Shujin Uniform (Beanie)") { IsEnabled = true });
    }

    public Costume this[int index] => costumes[index];

    public int Count => costumes.Count;

    public IEnumerator<Costume> GetEnumerator() => costumes.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => costumes.GetEnumerator();

    private bool IsCostumeEnabled(Costume costume)
    {
        if (this.disabledCostumes.Contains(costume.CostumeId))
        {
            return false;
        }

        if (this.filters.TryGetValue(this.filterSetting, out var filter))
        {
            if (filter.Contains(costume.CostumeId))
            {
                return false;
            }
        }

        return true;
    }
}
