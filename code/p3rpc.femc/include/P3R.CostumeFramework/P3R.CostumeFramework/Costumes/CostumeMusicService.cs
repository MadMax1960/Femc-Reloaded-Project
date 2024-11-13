using BGME.BattleThemes.Interfaces;
using BGME.Framework.Interfaces;
using P3R.CostumeFramework.Configuration;
using P3R.CostumeFramework.Costumes.Models;
using P3R.CostumeFramework.Hooks;

namespace P3R.CostumeFramework.Costumes;

internal class CostumeMusicService
{
    private readonly IBgmeApi bgme;
    private readonly IBattleThemesApi battleThemes;
    private readonly CostumeRegistry costumes;

    private readonly Dictionary<Character, CostumeMusic> costumeMusic = new();
    private readonly List<Character> currentParty = new();
    private readonly FlowFunctions flow;

    private bool currentPartyBgmOnly = false;
    private bool isEnabled_BGME = true;
    private bool isEnabled_BattleThemes = true;

    public CostumeMusicService(
        IBgmeApi bgme,
        IBattleThemesApi battleThemes,
        CostumeRegistry costumes)
    {
        this.bgme = bgme;
        this.battleThemes = battleThemes;
        this.costumes = costumes;
        this.flow = new FlowFunctions();

        foreach (var character in Enum.GetValues<Character>())
        {
            costumeMusic[character] = new();
        }
    }

    public void Refresh()
    {
        currentParty.Clear();
        currentParty.Add(Character.Player);
        currentParty.Add(Character.Fuuka);
        for (int i = 1; i < 4; i++)
        {
            // TODO: Support party limited music.
            //currentParty.Add((Character)this.flow.GetParty(i));
        }

        Log.Debug("Current Party");
        foreach (var character in currentParty)
        {
            Log.Debug(character.ToString());
        }

        foreach (var character in Enum.GetValues<Character>())
        {
            //var outfitItemId = p5rLib.GET_EQUIP(character, EquipSlot.Costume);
            //this.Refresh(outfitItemId);
        }
    }

    public void Refresh(Costume costume)
    {
        if (this.isEnabled_BGME)
        {
            this.UpdateBgmeMusic(costume);
        }

        if (this.isEnabled_BattleThemes)
        {
            this.UpdateBattleThemeMusic(costume);
        }
    }

    public void SetConfig(Config config)
    {
        //this.currentPartyBgmOnly = config.CurrentPartyBgmOnly;
        this.isEnabled_BGME = config.Integration_BGME;
        this.isEnabled_BattleThemes = config.Integration_BattleThemes;
        //this.Refresh();
    }

    private void UpdateBgmeMusic(Costume costume)
    {
        var currentBgmeFile = costumeMusic[costume.Character].MusicScriptFile;
        var newBgmeFile = costume.MusicScriptFile;
        if (this.currentPartyBgmOnly && !currentParty.Contains(costume.Character))
        {
            newBgmeFile = null;
        }

        // Costume music has changed.
        if (currentBgmeFile != newBgmeFile)
        {
            // Remove previous music, if any.
            if (currentBgmeFile != null)
            {
                bgme.RemovePath(currentBgmeFile);
                Log.Debug($"Costume music script removed: {costume.Character}");
            }

            // Add new costume music, if any.
            if (newBgmeFile != null)
            {
                bgme.AddPath(newBgmeFile);
                Log.Debug($"Costume music script added: {costume.Character} || {costume.Name}");
            }
        }

        costumeMusic[costume.Character].MusicScriptFile = newBgmeFile;
    }

    private void UpdateBattleThemeMusic(Costume costume)
    {
        var currentThemeFile = costumeMusic[costume.Character].BattleThemeFile;
        var newThemeFile = costume.BattleThemeFile;
        if (this.currentPartyBgmOnly && !currentParty.Contains(costume.Character))
        {
            newThemeFile = null;
        }

        // Costume music has changed.
        if (currentThemeFile != newThemeFile)
        {
            // Remove previous music, if any.
            if (currentThemeFile != null)
            {
                battleThemes.RemovePath(currentThemeFile);
                Log.Debug($"Costume battle theme removed: {costume.Character}");
            }

            // Add new costume music, if any.
            if (newThemeFile != null && costume.OwnerModId != null)
            {
                battleThemes.AddPath(costume.OwnerModId, newThemeFile);
                Log.Debug($"Costume battle theme added: {costume.Character} || {costume.Name}");
            }
        }

        costumeMusic[costume.Character].BattleThemeFile = newThemeFile;
    }

    private class CostumeMusic
    {
        public string? MusicScriptFile { get; set; }

        public string? BattleThemeFile { get; set; }
    }
}
