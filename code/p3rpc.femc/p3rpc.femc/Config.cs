using p3rpc.femc.Template.Configuration;
using Reloaded.Mod.Interfaces.Structs;
using System.ComponentModel;

namespace p3rpc.femc.Configuration
{
    public class Config : Configurable<Config>
    {
        [DisplayName("UI Kit: Light Color")]
        public ConfigColor UILightColor { get; set; } = ConfigColor.LightColor;

        [DisplayName("UI Kit: Mid Color")]
        public ConfigColor UIMidColor { get; set; } = ConfigColor.MidColor;

        [DisplayName("UI Kit: Dark Color")]
        public ConfigColor UIDarkColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Enable Mail Icon")]
        [Category("UI Components")]
        public bool EnableMailIcon { get; set; } = true;

        [DisplayName("Enable Date Time Panel")]
        [Category("UI Components")]
        public bool EnableDateTimePanel { get; set; } = true;

        [DisplayName("Enable Camp Menu")]
        [Category("UI Components")]
        public bool EnableCampMenu { get; set; } = true;

        [DisplayName("Enable Textbox (WIP)")]
        [Category("UI Components")]
        [DefaultValue(false)]
        public bool EnableTextbox { get; set; } = true;

    }

    /// <summary>
    /// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
    /// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
    /// </summary>
    public class ConfiguratorMixin : ConfiguratorMixinBase
    {
        // 
    }

    public class ConfigColor
    {
        public static readonly ConfigColor LightColor = new ConfigColor(0xff, 0xbf, 0xfc, 0xff);
        public static readonly ConfigColor DarkColor = new ConfigColor(0xd4, 0x15, 0x5b, 0xff);
        public static readonly ConfigColor MidColor = new ConfigColor(0xff, 0x8f, 0xec, 0xff);

        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }

        public ConfigColor(byte R, byte G, byte B, byte A) { this.R = R; this.G = G; this.B = B; this.A = A; }
    }
}
