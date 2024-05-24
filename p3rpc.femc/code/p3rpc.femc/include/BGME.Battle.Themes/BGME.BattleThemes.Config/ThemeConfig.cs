using BGME.BattleThemes.Interfaces;
using Reloaded.Mod.Interfaces;
using System.Drawing;

namespace BGME.BattleThemes.Config;

public class ThemeConfig
{
    private readonly string modId;
    private readonly string modDir;
    private readonly ILogger log;
    private readonly IBattleThemesApi themesApi;
    private readonly Dictionary<ThemeSetting, Func<bool>> settings = new();

    private IUpdatableConfigurable config;
    
    /// <summary>
    /// Create a theme config.
    /// </summary>
    /// <param name="modLoader">Mod loader.</param>
    /// <param name="modConfig">Mod config.</param>
    /// <param name="config">Mod configuration containing the theme settings.</param>
    /// <param name="log">Logger.</param>
    public ThemeConfig(
        IModLoader modLoader,
        IModConfig modConfig,
        IUpdatableConfigurable config,
        ILogger log)
    {
        this.modId = modConfig.ModId;
        this.modDir = modLoader.GetDirectoryForModId(modConfig.ModId);
        this.config = config;
        this.log = log;

        modLoader.GetController<IBattleThemesApi>().TryGetTarget(out this.themesApi!);
        this.config.ConfigurationUpdated += this.OnConfigurationUpdated;
    }

    /// <summary>
    /// Initialize config after adding settings.
    /// </summary>
    public void Initialize()
    {
        this.ApplySettings();
    }

    /// <summary>
    /// Connect a config setting and theme.
    /// </summary>
    /// <param name="propertyName">Property name of config setting.</param>
    /// <param name="themeFileName">Name of theme file.</param>
    /// <remarks>Theme files are expected to be located in: <c>MOD_FOLDER/battle-themes/options</c></remarks>
    public void AddSetting(string propertyName, string themeFileName)
    {
        var configType = this.config.GetType();
        var configProp = configType.GetProperty(propertyName, typeof(bool));
        if (configProp == null)
        {
            this.log.WriteLine($"[ThemeConfig] Config missing bool property: {propertyName}", Color.Red);
            return;
        }

        var themeFile = Path.Join(this.modDir, "battle-themes", "options", themeFileName);
        if (!File.Exists(themeFile))
        {
            this.log.WriteLine($"[ThemeConfig] Theme file not found.\nFile: {themeFile}", Color.Red);
            return;
        }

        var option = new ThemeSetting(propertyName, themeFile);
        this.settings[option] = () =>
        {
            var enabled = (bool)(configProp.GetValue(this.config) ?? false);
            return enabled;
        };
    }

    private void ApplySettings()
    {
        foreach (var setting in this.settings)
        {
            setting.Key.Deconstruct(out var propertyName, out var themeFile);
            var enabled = setting.Value();

            if (enabled)
            {
                this.themesApi.AddPath(this.modId, themeFile);
            }
            else
            {
                this.themesApi.RemovePath(themeFile);
            }

            this.log.WriteLine($"[ThemeConfig] \"{propertyName}\": {(enabled ? "Enabled" : "Disabled")}");
        }
    }

    private void OnConfigurationUpdated(IUpdatableConfigurable config)
    {
        this.config = config;
        this.ApplySettings();
    }

    private record ThemeSetting(string PropertyName, string ThemeFile);
}
