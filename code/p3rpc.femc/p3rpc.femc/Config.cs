using p3rpc.femc.Template.Configuration;
using Reloaded.Mod.Interfaces.Structs;
using System.ComponentModel;

namespace p3rpc.femc.Configuration
{
    public class Config : Configurable<Config>
    {

        [DisplayName("Mail Icon: Outer Color")]
        public ConfigColor MailIconOuterCircleColor { get; set; } = ConfigColor.MidColor;

        [DisplayName("Mail Icon: Inner Color")]
        public ConfigColor MailIconInnerCircleColor { get; set; } = ConfigColor.LightColor;

        [DisplayName("Camp: High Color")]
        public ConfigColor CampHighColor { get; set; } = ConfigColor.CampHighColor;

        [DisplayName("Camp: Middle Color")]
        public ConfigColor CampMiddleColor { get; set; } = ConfigColor.CampHighColor;

        [DisplayName("Camp: Low Color")]
        public ConfigColor CampLowColor { get; set; } = ConfigColor.CampHighColor;

        [DisplayName("Date Time Panel: Top Text Color")]
        public ConfigColor DateTimePanelTopTextColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Date Time Panel: Bottom Text Color")]
        public ConfigColor DateTimePanelBottomTextColor { get; set; } = ConfigColor.MidColor;

        [DisplayName("Date Time Panel: Water Color")]
        public ConfigColor DateTimePanelWaterColor { get; set; } = ConfigColor.MidColor;

        [DisplayName("Text Box: Back Fill Color")]
        public ConfigColor TextBoxBackFillColor { get; set; } = ConfigColor.TextBoxBackFillColor;

        [DisplayName("Text Box: Front Fill Color")]
        public ConfigColor TextBoxFrontFillColor { get; set; } = ConfigColor.TextBoxFrontFillColor;

        [DisplayName("Text Box: Front Fill Border Color")]
        public ConfigColor TextBoxFrontBorderColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Text Box: Speaker Name Triangle Color")]
        public ConfigColor TextBoxSpeakerNameTriangle { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Text Box: Left Haze Color")]
        public ConfigColor TextBoxLeftHaze { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Mind Window: Outer Border")]
        public ConfigColor MindWindowOuterBorder { get; set; } = ConfigColor.MidColor;

        [DisplayName("Mind Window: Inner Color")]
        public ConfigColor MindWindowInnerColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Mind Window: Outer Haze")]
        public ConfigColor MindWindowOuterHaze { get; set; } = new ConfigColor(ConfigColor.MidColor.R, ConfigColor.MidColor.G, ConfigColor.MidColor.B, 128);

        [DisplayName("Minimap: Place Name Background Color")]
        public ConfigColor MinimapPlaceNameBgColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Interact Prompt: Background Color")]
        public ConfigColor CheckDrawBgColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Interact Prompt: Foreground Border Color")]
        public ConfigColor CheckDrawFgBorderColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Interact Prompt: Foregorund Color")]
        public ConfigColor CheckDrawFgColor { get; set; } = ConfigColor.MidColor;

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

        [DisplayName("Enable Mind Message Box (WIP)")]
        [Category("UI Components")]
        [DefaultValue(false)]
        public bool EnableMindMessageBox { get; set; } = true;

        [DisplayName("Enable Interact Prompt")]
        [Category("UI Components")]
        public bool EnableInteractPrompt { get; set; } = true;

        [DisplayName("Enable Minimap")]
        [Category("UI Components")]
        public bool EnableMinimap { get; set; } = true;

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
        public static readonly ConfigColor CampHighColor = new ConfigColor(0xe8, 0x64, 0xbc, 0xff);
        public static readonly ConfigColor TextBoxBackFillColor = new ConfigColor(0x6c, 0x7, 0x39, 0xff);
        public static readonly ConfigColor TextBoxFrontFillColor = new ConfigColor(0x49, 0x4, 0x21, 0xff);

        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }

        public ConfigColor(byte R, byte G, byte B, byte A) { this.R = R; this.G = G; this.B = B; this.A = A; }
    }
}
