using BGME.BattleThemes.Interfaces;
using BGME.Framework.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using Timer = System.Timers.Timer;

namespace BGME.BattleThemes.Themes;

internal class BattleThemesService : IBattleThemesApi
{
    private readonly IModLoader modLoader;
    private readonly IBgmeApi bgme;
    private readonly MusicRegistry musicRegistry;

    private readonly ObservableCollection<ThemePath> themePaths = new();
    private readonly List<string> themes = new();
    private readonly StringBuilder musicScriptBuilder = new();
    private Func<string> themeScriptCallback = () => string.Empty;
    private readonly Timer themesRefreshTimer;

    public BattleThemesService(
        IModLoader modLoader,
        IBgmeApi bgme,
        MusicRegistry musicRegistry)
    {
        this.modLoader = modLoader;
        this.bgme = bgme;
        this.musicRegistry = musicRegistry;

        this.themesRefreshTimer = new(TimeSpan.FromMilliseconds(250))
        {
            AutoReset = false,
        };

        // Add temp callback to retain mod priority
        // in music scripts.
        this.bgme.AddMusicScript(this.themeScriptCallback);

        this.themesRefreshTimer.Elapsed += (sender, args) => this.ApplyThemeScript();
        this.themePaths.CollectionChanged += (sender, args) =>
        {
            this.themesRefreshTimer.Stop();
            this.themesRefreshTimer.Start();
        };

        this.modLoader.ModLoading += this.OnModLoading;
    }

    public void AddPath(string modId, string path)
    {
        var themePath = new ThemePath(modId, path);
        if (!this.themePaths.Contains(themePath))
        {
            this.themePaths.Add(new ThemePath(modId, path));
            Log.Debug($"Added theme path.\nPath: {path}");
        }
    }

    public void RemovePath(string path)
    {
        if (this.themePaths.FirstOrDefault(x => x.Path == path) is ThemePath themePath)
        {
            this.themePaths.Remove(themePath);
            Log.Debug($"Removed theme path.\nPath: {path}");
        }
        else
        {
            Log.Verbose($"Could not find theme path to remove.\nPath: {path}");
        }
    }

    private void OnModLoading(IModV1 mod, IModConfigV1 config)
    {
        if (!config.ModDependencies.Contains("BGME.BattleThemes"))
        {
            return;
        }

        var modDir = this.modLoader.GetDirectoryForModId(config.ModId);
        var battleThemesDir = Path.Join(modDir, "battle-themes");
        if (Directory.Exists(battleThemesDir))
        {
            this.AddPath(config.ModId, battleThemesDir);
        }
    }

    private void ApplyThemeScript()
    {
        this.musicScriptBuilder.Clear();
        this.themes.Clear();

        foreach (var theme in this.themePaths)
        {
            if (theme.IsFile)
            {
                this.ProcessFile(theme.ModId, theme.Path);
            }
            else
            {
                this.ProcessFolder(theme.ModId, theme.Path);
            }
        }

        if (this.themes.Count == 0)
        {
            return;
        }

        musicScriptBuilder.AppendLine($"const allThemes = [{string.Join(',', this.themes)}]");
        musicScriptBuilder.AppendLine($"const randomizedThemes = random_music(allThemes)");
        musicScriptBuilder.AppendLine("encounter[\"Normal Battles\"]:");
        musicScriptBuilder.AppendLine("  music = randomizedThemes");
        musicScriptBuilder.AppendLine("end");

        var musicScript = this.musicScriptBuilder.ToString();
        string newCallback() => musicScript;

        // Replace current callback with new one.
        this.bgme.AddMusicScript(newCallback, this.themeScriptCallback);
        this.themeScriptCallback = newCallback;

        Log.Debug($"Battle Themes Script:\n{musicScript}");
    }

    private void ProcessFile(string modId, string filePath)
    {
        try
        {
            var modSongs = this.musicRegistry.GetModSongs(modId);
            var musicScriptText = File.ReadAllText(filePath);
            foreach (var song in modSongs)
            {
                var pattern = $@"\b({song.Name})\b";
                musicScriptText = Regex.Replace(musicScriptText, pattern, song.BgmId.ToString());
            }

            var uniqueThemeId = $"theme_{this.themes.Count}";
            musicScriptText = musicScriptText.Replace("BATTLE_THEME", uniqueThemeId);
            this.themes.Add(uniqueThemeId);
            this.musicScriptBuilder.AppendLine(musicScriptText);

            Log.Information($"Added battle theme from {modId}: {Path.GetFileName(filePath)}");
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"Failed to add battle theme from {modId}.\nFile: {filePath}");
        }
    }

    private void ProcessFolder(string modId, string folderPath)
    {
        foreach (var themeFile in Directory.EnumerateFiles(folderPath, "*.theme.pme", SearchOption.TopDirectoryOnly))
        {
            this.ProcessFile(modId, themeFile);
        }
    }

    private record ThemePath(string ModId, string Path)
    {
        public bool IsFile { get; } = File.Exists(Path);
    }
}
