using P3R.CostumeFramework.Costumes;
using P3R.CostumeFramework.Costumes.Models;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace P3R.CostumeFramework.Hooks.Costumes.Models;

internal class DefaultCostumes : IReadOnlyDictionary<Character, Costume>
{
    private readonly Dictionary<Character, Costume> costumes = [];

    public DefaultCostumes(bool useFemcPlayer = false)
    {
        foreach (var character in Characters.PC)
        {
            if (character == Character.Player)
            {
                if (useFemcPlayer)
                {
                    costumes[character] = new FemcCostume();
                    Log.Information("Mod Integration Enabled: FEMC Mod");
                }
                else
                {
                    costumes[character] = new DefaultCostume(Character.Player);
                }
            }
            else if (character == Character.AigisReal)
            {
                costumes[character] = new AigisRealDefaultCostume();
            }
            else if (character == Character.Metis)
            {
                costumes[character] = new MetisDefaultCostume();
            }
            else
            {
                costumes[character] = new DefaultCostume(character);
            }
        }
    }

    public Costume this[Character key] => this.costumes[key];

    public IEnumerable<Character> Keys => this.costumes.Keys;

    public IEnumerable<Costume> Values => this.costumes.Values;

    public int Count => this.costumes.Count;

    public bool ContainsKey(Character key) => this.costumes.ContainsKey(key);

    public IEnumerator<KeyValuePair<Character, Costume>> GetEnumerator() => this.costumes.GetEnumerator();

    public bool TryGetValue(Character key, [MaybeNullWhen(false)] out Costume value) => this.costumes.TryGetValue(key, out value);

    IEnumerator IEnumerable.GetEnumerator() => this.costumes.GetEnumerator();
}
