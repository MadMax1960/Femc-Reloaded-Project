using BGME.BattleThemes.Template.Configuration;
using System.ComponentModel;

namespace BGME.BattleThemes.Configuration
{
    public class Config : Configurable<Config>
    {
        /*
            User Properties:
                - Please put all of your configurable properties here.

            By default, configuration saves as "Config.json" in mod user config folder.    
            Need more config files/classes? See Configuration.cs

            Available Attributes:
            - Category
            - DisplayName
            - Description
            - DefaultValue

            // Technically Supported but not Useful
            - Browsable
            - Localizable

            The `DefaultValue` attribute is used as part of the `Reset` button in Reloaded-Launcher.
        */

        [DisplayName("Log Level")]
        [DefaultValue(LogLevel.Information)]
        public LogLevel LogLevel { get; set; } = LogLevel.Information;

        [DisplayName("Persona 5 Royal")]
        [Category("Base BGM ID")]
        [DefaultValue(12000)]
        public int BaseBgmId_P5R { get; set; } = 12000;

        [DisplayName("Persona 4 Golden")]
        [Category("Base BGM ID")]
        [DefaultValue(693)]
        public int BaseBgmId_P4G { get; set; } = 693;

        [DisplayName("Persona 3 Portable")]
        [Category("Base BGM ID")]
        [DefaultValue(4000)]
        public int BaseBgmId_P3P { get; set; } = 4000;

        [DisplayName("Persona 3 Reload")]
        [Category("Base BGM ID")]
        [DefaultValue(4000)]
        public int BaseBgmId_P3R { get; set; } = 4000;
    }

    /// <summary>
    /// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
    /// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
    /// </summary>
    public class ConfiguratorMixin : ConfiguratorMixinBase
    {
        // 
    }
}