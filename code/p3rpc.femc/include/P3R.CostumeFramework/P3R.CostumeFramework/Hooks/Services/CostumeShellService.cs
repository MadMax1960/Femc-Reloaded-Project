using P3R.CostumeFramework.Costumes;
using P3R.CostumeFramework.Costumes.Models;
using P3R.CostumeFramework.Hooks.Costumes;
using P3R.CostumeFramework.Hooks.Costumes.Models;
using Unreal.ObjectsEmitter.Interfaces;

namespace P3R.CostumeFramework.Hooks.Services;

internal unsafe class CostumeShellService
{
    private const int SHELL_COSTUME_ID = 51;
    private readonly Dictionary<Character, int> prevCostumeIds = [];
    private readonly DefaultCostumes defaultCostumes = new();

    private readonly CostumeTableService costumeTable;
    private readonly CostumeRegistry costumes;

    public CostumeShellService(IDataTables dt, CostumeRegistry costumes, CostumeTableService costumeTable)
    {
        this.costumes = costumes;
        this.costumeTable = costumeTable;

        // Reset data on DT_Costume load.
        dt.FindDataTable("DT_Costume", _ =>
        {
            foreach (var character in Characters.PC)
            {
                this.prevCostumeIds[character] = -1;
            }
        });
    }

    public int UpdateCostume(Character character, int costumeId)
    {
        if (costumeId == SHELL_COSTUME_ID)
        {
            this.prevCostumeIds[character] = costumeId;
            this.costumeTable.SetCostumeData(character, SHELL_COSTUME_ID, defaultCostumes[character]);
            Log.Debug($"{character}: Reset shell costume data.");
        }

        if (costumeId < GameCostumes.BASE_MOD_COSTUME_ID)
        {
            return costumeId;
        }

        var shouldUpdateData = this.prevCostumeIds[character] != costumeId;
        if (shouldUpdateData && this.costumes.TryGetCostume(character, costumeId, out var costume))
        {
            this.costumeTable.SetCostumeData(character, SHELL_COSTUME_ID, costume);
            this.prevCostumeIds[character] = costumeId;
        }

        return SHELL_COSTUME_ID;
    }
}
