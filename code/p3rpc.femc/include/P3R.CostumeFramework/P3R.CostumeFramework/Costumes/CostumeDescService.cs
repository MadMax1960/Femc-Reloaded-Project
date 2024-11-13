using System.Reflection;
using System.Text;
using Unreal.AtlusScript.Interfaces;

namespace P3R.CostumeFramework.Costumes;

internal class CostumeDescService
{
	private readonly IAtlusAssets atlusAssets;

	private readonly List<string> descEntries = new();

	public CostumeDescService(IAtlusAssets atlusAssets)
	{
		this.atlusAssets = atlusAssets;

		this.LoadDescEntries();
    }

	/// <summary>
	/// Call after costumes have had their item ID assigned.
	/// TODO: Populate item ID when GameCostumes is created, it being
	/// dynamically assigned causes so many annoyances.
	/// </summary>
	public void Init()
	{
		var sb = new StringBuilder();
        for (int i = 0; i < this.descEntries.Count; i++)
        {
            sb.AppendLine($"[msg Item_{i:D3}]");
            sb.AppendLine($"[uf 0 5 65278][uf 2 1]{this.descEntries[i]}[n][e]");
        }

        this.atlusAssets.AddAsset("BMD_ItemCostumeHelp", sb.ToString(), AssetType.BMD, AssetMode.Both);
    }

    public void SetCostumeDesc(int costumeItemId, string costumeDesc)
        => this.descEntries[costumeItemId] = costumeDesc;

    private void LoadDescEntries()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = "P3R.CostumeFramework.Resources.descriptions.msg";
        using var stream = assembly.GetManifestResourceStream(resourceName)!;
        using var reader = new StreamReader(stream);

		while (!reader.EndOfStream)
		{
			var line = reader.ReadLine();
			if (line?.StartsWith("[uf") == true)
			{
				if (!line.EndsWith("[n][e]"))
				{
					line = $"{line}[n][e]";
				}

				this.descEntries.Add(line);
			}
		}

		// Add placeholder entries.
		for (int i = 0; i < 100; i++)
		{
			this.descEntries.Add("[uf 0 5 65278][uf 2 1]未使用[n][e]");
		}
    }
}
