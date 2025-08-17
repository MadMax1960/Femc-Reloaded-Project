using P3R.CostumeFramework.Costumes.Models;
using Ryo.Interfaces;
using Ryo.Interfaces.Classes;

namespace P3R.CostumeFramework.Costumes;

internal class CostumeRyoService
{
    private readonly IRyoApi ryo;
    private readonly Dictionary<Character, IContainerGroup?> currentCostumeGroups = [];

    public CostumeRyoService(IRyoApi ryo)
    {
        this.ryo = ryo;

        foreach (var character in Characters.PC)
        {
            this.currentCostumeGroups[character] = null;
        }
    }

    public void Refresh(Costume costume)
    {
        var character = costume.Character;
        var currentGroup = this.currentCostumeGroups[character];

        if (currentGroup == null)
        {
            var newGroup = this.ryo.GetContainerGroup(costume.RyoGroupId);
            this.currentCostumeGroups[character] = newGroup;
            newGroup.Enable();
        }
        else if (currentGroup.Id != costume.RyoGroupId)
        {
            currentGroup.Disable();
            var newGroup = this.ryo.GetContainerGroup(costume.RyoGroupId);
            this.currentCostumeGroups[character] = newGroup;
            newGroup.Enable();
        }
    }
}
