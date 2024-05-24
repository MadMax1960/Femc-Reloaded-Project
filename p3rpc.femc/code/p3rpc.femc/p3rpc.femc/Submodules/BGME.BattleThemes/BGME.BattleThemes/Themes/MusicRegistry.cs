using BGME.BattleThemes.Utils;
using PersonaModdingMetadata.Shared.Games;
using Phos.MusicManager.Library.Audio.Encoders;
using Phos.MusicManager.Library.Audio.Encoders.VgAudio;
using System.Text.Json;

namespace BGME.BattleThemes.Themes;

internal class MusicRegistry
{
    private const int CURRENT_VERSION = 1;

    private readonly Game game;
    private readonly Configuration.Config config;
    private readonly HashSet<ModSong> previousMusic;
    private readonly HashSet<ModSong> currentMusic = new();
    private readonly Dictionary<Game, IEncoder> encoders = new();
    private readonly string[] supportedExts;
    private readonly string modDir;
    private readonly string gameFolder;
    private readonly string[] enabledMods;

    public MusicRegistry(
        Game game,
        Configuration.Config config,
        string modDir,
        string[] enabledMods)
    {
        this.game = game;
        this.config = config;
        this.modDir = modDir;
        this.enabledMods = enabledMods;

        this.gameFolder = game.GameFolder(modDir);
        var cachedDir = new DirectoryInfo(Path.Join(gameFolder, "cached"));
        cachedDir.Create();

        this.encoders[Game.P4G_PC] = new CachedEncoder(new VgAudioEncoder(new() { OutContainerFormat = "hca" }), cachedDir.FullName);
        this.encoders[Game.P3P_PC] = new CachedEncoder(new VgAudioEncoder(new() { OutContainerFormat = "adx" }), cachedDir.FullName);
        this.encoders[Game.P5R_PC] = new CachedEncoder(new VgAudioEncoder(new() { OutContainerFormat = "adx", KeyCode = 9923540143823782 }), cachedDir.FullName);
        this.encoders[Game.P3R_PC] = new CachedEncoder(new VgAudioEncoder(new() { OutContainerFormat = "hca", KeyCode = 11918920 }), cachedDir.FullName);
        this.supportedExts = this.encoders.First().Value.InputTypes;

        // Rebuild all music on new versions.
        if (this.IsNewVersion())
        {
            this.ResetMusic();
        }

        this.previousMusic = this.GetPreviousMusic();
        this.RegisterMusic();
    }

    /// <summary>
    /// Gets the list of songs added by the specified mod.
    /// </summary>
    /// <param name="modId">Mod ID to get songs for.</param>
    /// <returns>Array of songs.</returns>
    public ModSong[] GetModSongs(string modId) => this.currentMusic.Where(x => x.ModId == modId).ToArray();

    private void RegisterMusic()
    {
        var modsDir = Path.GetDirectoryName(this.modDir)!;
        foreach (var modDir in Directory.EnumerateDirectories(modsDir))
        {
            var modConfigFile = Path.Join(modDir, "ModConfig.json");
            if (!File.Exists(modConfigFile))
            {
                continue;
            }

            var modConfig = ReloadedConfigParser.Parse(modConfigFile);
            if (this.enabledMods.Contains(modConfig.ModId))
            {
                this.RegisterModMusic(modConfig.ModId, modDir);
            }
        }

        var activeBuildFiles = this.currentMusic.Select(x => x.BuildFilePath).ToArray();

        // Remove any files from songs that are not in current music
        // or whose build file path is no longer used.
        var unusedSongs = this.previousMusic
            .Except(this.currentMusic)
            .Where(x => activeBuildFiles.Contains(x.BuildFilePath) == false)
            .ToArray();

        foreach (var song in unusedSongs)
        {
            if (File.Exists(song.BuildFilePath))
            {
                File.Delete(song.BuildFilePath);
                Log.Debug($"Removed unused song file: {song.Name} || {song.BuildFilePath}");
            }
        }

        this.SaveCurrentMusic();
    }

    private void RegisterModMusic(string modId, string modDir)
    {
        var musicDir = Path.Join(modDir, "battle-themes", "music");
        if (!Directory.Exists(musicDir))
        {
            return;
        }

        var modSongs = Directory.GetFiles(musicDir, "*", SearchOption.AllDirectories)
            .Where(file => this.supportedExts
            .Contains(Path.GetExtension(file), StringComparer.OrdinalIgnoreCase))
            .Select(file =>
            {
                var bgmId = this.GetNextBgmId();
                var buildFile = Path.Join(modDir, this.GetReplacementPath(bgmId));
                var song = new ModSong(modId, Path.GetFileNameWithoutExtension(file), bgmId, file, buildFile);
                this.currentMusic.Add(song);
                return song;
            })
            .ToArray();

        //Task.WhenAll(modSongs.Select(this.RegisterSong)).Wait();
        foreach (var song in modSongs)
        {
            this.RegisterSong(song).Wait();
        }
    }

    private async Task RegisterSong(ModSong song)
    {
        // Don't rebuild songs that haven't changed.
        if (this.previousMusic.Contains(song))
        {
            Log.Debug($"Song already built: {song.Name}");
            return;
        }

        Log.Debug($"Building song: {song.FilePath}");

        var outputFile = new FileInfo(song.BuildFilePath);
        outputFile.Directory!.Create();

        var encoder = this.encoders[this.game];
        await encoder.Encode(song.FilePath, outputFile.FullName);

        Log.Debug($"Built song: {song.BuildFilePath}");
        Log.Information($"Registered song: {song.Name} || Mod: {song.ModId} || BGM ID: {song.BgmId}");
    }

    private void SaveCurrentMusic()
    {
        var musicFileList = Path.Join(this.gameFolder, "music.json");
        File.WriteAllText(musicFileList, JsonSerializer.Serialize(this.currentMusic, new JsonSerializerOptions { WriteIndented = true }));

        var versionFile = Path.Join(this.gameFolder, "version.txt");
        File.WriteAllText(versionFile, CURRENT_VERSION.ToString());
    }

    private HashSet<ModSong> GetPreviousMusic()
    {
        var musicFileList = Path.Join(this.gameFolder, "music.json");
        if (File.Exists(musicFileList))
        {
            try
            {
                return JsonSerializer.Deserialize<HashSet<ModSong>>(File.ReadAllText(musicFileList)) ?? new();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to parse previous music.");
            }
        }

        return new();
    }

    private void ResetMusic()
    {
        Log.Information("New version, rebuilding all music.");

        var encoder = this.encoders[this.game];
        var cachedFolder = Path.Join(this.gameFolder, "cached");
        if (Directory.Exists(cachedFolder))
        {
            foreach (var file in Directory.EnumerateFiles(cachedFolder, $"*{encoder.EncodedExt}"))
            {
                File.Delete(file);
                Log.Debug($"Cleared cached file: {file}");
            }
        }

        var musicFile = Path.Join(this.gameFolder, "music.json");
        File.Delete(musicFile);
        Log.Debug($"Cleared music file: {musicFile}");
    }

    private bool IsNewVersion()
    {
        var versionFile = Path.Join(this.gameFolder, "version.txt");
        if (!File.Exists(versionFile))
        {
            return true;
        }

        try
        {
            var version = int.Parse(File.ReadAllText(versionFile));
            if (version == CURRENT_VERSION)
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Failed to get saved version.");
            return true;
        }

        return true;
    }

    private string GetReplacementPath(int bgmId) => this.game switch
    {
        Game.P3P_PC => Path.Join("P5REssentials/CPK/Battle Themes/data/sound/bgm", $"{bgmId}.adx"),
        Game.P4G_PC => Path.Join("FEmulator/AWB/snd00_bgm.awb", $"{bgmId}.hca"),
        Game.P5R_PC => Path.Join("FEmulator/AWB/BGM_42.AWB", $"{bgmId - 10000}.adx"),
        Game.P3R_PC => Path.Join("BGME/P3R", $"{bgmId}.hca"),
        _ => throw new Exception("Unknown game."),
    };

    private int GetNextBgmId() => this.GetBaseBgmId() + this.currentMusic.Count;

    private int GetBaseBgmId() => this.game switch
    {
        Game.P3P_PC => this.config.BaseBgmId_P3P,
        Game.P4G_PC => this.config.BaseBgmId_P4G,
        Game.P5R_PC => this.config.BaseBgmId_P5R,
        Game.P3R_PC => this.config.BaseBgmId_P3R,
        _ => throw new Exception("Unknown game."),
    };
}

internal record ModSong(string ModId, string Name, int BgmId, string FilePath, string BuildFilePath);