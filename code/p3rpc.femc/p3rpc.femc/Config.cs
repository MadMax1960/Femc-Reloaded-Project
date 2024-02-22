using p3rpc.femc.Template.Configuration;
using Reloaded.Mod.Interfaces.Structs;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace p3rpc.femc.Configuration
{
    public class Config : Configurable<Config>
    {

        [DisplayName("Mail Icon: Outer Color")]
        public ConfigColor MailIconOuterCircleColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Mail Icon: Inner Color")]
        public ConfigColor MailIconInnerCircleColor { get; set; } = ConfigColor.MailIconInnerColor;

        [DisplayName("Camp: High Color")]
        public ConfigColor CampHighColor { get; set; } = ConfigColor.CampBgColor;

        [DisplayName("Camp: Middle Color")]
        public ConfigColor CampMiddleColor { get; set; } = ConfigColor.CampBgColor;

        [DisplayName("Camp: Low Color")]
        public ConfigColor CampLowColor { get; set; } = ConfigColor.CampBgColor;

        [DisplayName("Date Time Panel: Top Text Color")]
        public ConfigColor DateTimePanelTopTextColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Date Time Panel: Bottom Text Color")]
        public ConfigColor DateTimePanelBottomTextColor { get; set; } = ConfigColor.MidColor;

        [DisplayName("Date Time Panel: Water Color")]
        public ConfigColor DateTimePanelWaterColor { get; set; } = ConfigColor.DateTimeWaterColor;

        [DisplayName("Text Box: Back Fill Color")]
        public ConfigColor TextBoxBackFillColor { get; set; } = ConfigColor.TextBoxBackFillColor;

        [DisplayName("Text Box: Front Fill Color")]
        public ConfigColor TextBoxFrontFillColor { get; set; } = ConfigColor.TextBoxFrontFillColor;

        [DisplayName("Text Box: Front Fill Border Color")]
        public ConfigColor TextBoxFrontBorderColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Text Box: Speaker Name Triangle Color")]
        public ConfigColor TextBoxSpeakerNameTriangle { get; set; } = ConfigColor.TextBoxSpeakerNameTriangle;

        [DisplayName("Text Box: Left Haze Color")]
        public ConfigColor TextBoxLeftHaze { get; set; } = ConfigColor.TextBoxLeftHaze;

        [DisplayName("Mind Window: Outer Border")]
        public ConfigColor MindWindowOuterBorder { get; set; } = ConfigColor.MidColor;

        [DisplayName("Mind Window: Inner Color")]
        public ConfigColor MindWindowInnerColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Mind Window: Outer Haze")]
        public ConfigColor MindWindowOuterHaze { get; set; } = new ConfigColor(ConfigColor.MidColor.R, ConfigColor.MidColor.G, ConfigColor.MidColor.B, 128);

        [DisplayName("Mind Window: Background Dots")]
        public ConfigColor MindWindowBgDots { get; set; } = ConfigColor.MidColor;

        [DisplayName("Minimap: Place Name Background Color")]
        public ConfigColor MinimapPlaceNameBgColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Interact Prompt: Background Color")]
        public ConfigColor CheckDrawBgColor { get; set; } = ConfigColor.CheckFgBorder;

        [DisplayName("Interact Prompt: Foreground Border Color")]
        public ConfigColor CheckDrawFgBorderColor { get; set; } = ConfigColor.CheckFgBorder;

        [DisplayName("Interact Prompt: Foreground Color")]
        public ConfigColor CheckDrawFgColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Bustup: Shadow Color")]
        public ConfigColor BustupShadowColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Camp: Menu Item Color 1 (Requires Restart)")]
        public ConfigColor CampMenuItemColor1 { get; set; } = ConfigColor.CampMenuItemColor1;

        [DisplayName("Camp: Menu Item Color 2 (Requires Restart)")]
        public ConfigColor CampMenuItemColor2 { get; set; } = ConfigColor.CampMenuItemColor2;

        [DisplayName("Camp: Menu Item Color 3 (Requires Restart)")]
        public ConfigColor CampMenuItemColor3 { get; set; } = ConfigColor.CampMenuItemColor3;

        [DisplayName("Camp: Skill Text Color (Requires Restart)")]
        public ConfigColor CampSkillTextColor { get; set; } = ConfigColor.MidColor;

        [DisplayName("Social Stats: Academics Circle Color")]
        public ConfigColor SocialStatsCircleAcademicsColor { get; set; } = ConfigColor.SocialStatsAcademics;

        [DisplayName("Social Stats: Charm Circle Color")]
        public ConfigColor SocialStatsCircleCharmColor { get; set; } = ConfigColor.SocialStatsCharm;

        [DisplayName("Social Stats: Courage Circle Color")]
        public ConfigColor SocialStatsCircleCourageColor { get; set; } = ConfigColor.SocialStatsCourage;

        [DisplayName("Camp: Item Menu Character Top Color (Requires Restart)")]
        public ConfigColor CampItemMenuCharacterTopColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Camp: Item Menu Character Bottom Color (Requires Restart)")]
        public ConfigColor CampItemMenuCharacterBottomColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Enable Mail Icon")]
        [Category("UI Components")]
        public bool EnableMailIcon { get; set; } = true;

        [DisplayName("Enable Date Time Panel")]
        [Category("UI Components")]
        public bool EnableDateTimePanel { get; set; } = true;

        [DisplayName("Enable Camp Menu")]
        [Category("UI Components")]
        public bool EnableCampMenu { get; set; } = true;

        [DisplayName("Enable Standard Message Box (WIP)")]
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

        [DisplayName("Enable Bustup")]
        [Category("UI Components")]
        public bool EnableBustup { get; set; } = true;

        [DisplayName("Enable MessageScript")]
        [Category("UI Components")]
        public bool EnableMessageScript { get; set; } = true;

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
        // DEFAULT COLORS
        public static readonly ConfigColor LightColor = new ConfigColor(0xff, 0xbf, 0xfc, 0xff);
        public static readonly ConfigColor DarkColor = new ConfigColor(0xd4, 0x15, 0x5b, 0xff);
        public static readonly ConfigColor MidColor = new ConfigColor(0xff, 0x8f, 0xec, 0xff);

        public static readonly ConfigColor CampBgColor = new ConfigColor(0xe8, 0x64, 0xbc, 0xff);
        public static readonly ConfigColor TextBoxBackFillColor = new ConfigColor(0x6c, 0x7, 0x39, 0xff);
        public static readonly ConfigColor TextBoxFrontFillColor = new ConfigColor(0x49, 0x4, 0x21, 0xff);
        public static readonly ConfigColor CampMenuItemColor1 = new ConfigColor(0xff, 0x8f, 0xec, 0xff);
        public static readonly ConfigColor CampMenuItemColor2 = new ConfigColor(0xf7, 0x83, 0xe4, 0xff);
        public static readonly ConfigColor CampMenuItemColor3 = new ConfigColor(0xe0, 0x79, 0xcf, 0xff);
        public static readonly ConfigColor CheckFgBorder = new ConfigColor(0x9b, 0x0b, 0x47, 0xff);
        public static readonly ConfigColor SocialStatsCourage = new ConfigColor(0xf5, 0x62, 0xa7, 0xff);
        public static readonly ConfigColor SocialStatsCharm = new ConfigColor(0xff, 0x8f, 0xec, 0xff); // same as mid color
        public static readonly ConfigColor SocialStatsAcademics = new ConfigColor(0xa0, 0x0c, 0x42, 0xff);
        public static readonly ConfigColor MailIconInnerColor = new ConfigColor(0xff, 0x7f, 0x9f, 0xff);
        public static readonly ConfigColor DateTimeWaterColor = new ConfigColor(0xf0, 0x7c, 0xcd, 0xff);
        public static readonly ConfigColor TextBoxLeftHaze = new ConfigColor(0x83, 0x06, 0x51, 0xff);
        public static readonly ConfigColor TextBoxSpeakerNameTriangle = new ConfigColor(0xc8, 0x05, 0x4b, 0xff);


        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }

        public ConfigColor(byte R, byte G, byte B, byte A) { this.R = R; this.G = G; this.B = B; this.A = A; }

        public uint ToU32() => (uint)(R << 0x18) | (uint)(G << 0x10) | (uint)(B << 0x8) | A;
    }
}
