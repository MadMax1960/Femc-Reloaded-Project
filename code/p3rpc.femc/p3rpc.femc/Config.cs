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

        [DisplayName("Text Box: Speaker Name")]
        public ConfigColor TextBoxSpeakerName { get; set; } = ConfigColor.LightColor;

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

        [DisplayName("Camp: Menu Item Color No Select (Requires Restart)")]
        public ConfigColor CampMenuItemColorNoSel { get; set; } = ConfigColor.CampMenuItemColorNoSel;

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

        [DisplayName("Assist Message Box: Background Color")]
        public ConfigColor MsgAssistBgColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Town Map: Border Color")]
        public ConfigColor TownMapBorderColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Town Map: Text Color")]
        public ConfigColor TownMapTextColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Camp Social Link: Light Color")]
        public ConfigColor CampSocialLinkLight { get; set; } = ConfigColor.MellodiColorLight2;

        [DisplayName("Camp Social Link: Dark Color")]
        public ConfigColor CampSocialLinkDark { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Camp Social Link: Desc BG")]
        public ConfigColor CampSocialLinkDetailDescBg { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Camp Social Link: Desc Triangle")]
        public ConfigColor CampSocialLinkDetailDescTriangle { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Camp Social Link: Desc Name")]
        public ConfigColor CampSocialLinkDetailDescName { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Arcana Card Fall Color 1")]
        public ConfigColor ArcanaCardFallColor1 { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Arcana Card Fall Color 2")]
        public ConfigColor ArcanaCardFallColor2 { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Arcana Card Fall Color 3")]
        public ConfigColor ArcanaCardFallColor3 { get; set; } = ConfigColor.MellodiColorMid3;

        [DisplayName("Camp Calendar: Sunday Color (Requires Restart)")]
        public ConfigColor CampCalendarSundayColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Camp Calendar: Sunday Color 2 (Requires Restart)")]
        public ConfigColor CampCalendarSundayColor2 { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Camp Calendar: Text Color (Requires Restart)")]
        public ConfigColor CampCalendarTextColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Camp Calendar: Highlight Color (Requires Restart)")]
        public ConfigColor CampCalendarHighlightColor { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Camp Calendar: Part Time Job Background")]
        public ConfigColor CampCalendarPartTimeJobBackground { get; set; } = ConfigColor.MellodiColorDark1;

        [DisplayName("Enable Mail Icon")]
        [Category("UI Components")]
        public bool EnableMailIcon { get; set; } = true;

        [DisplayName("Enable Date Time Panel")]
        [Category("UI Components")]
        public bool EnableDateTimePanel { get; set; } = true;

        [DisplayName("Enable Camp Menu")]
        [Category("UI Components")]
        public bool EnableCampMenu { get; set; } = true;

        [DisplayName("Enable Standard Message Box")]
        [Category("UI Components")]
        [DefaultValue(false)]
        public bool EnableTextbox { get; set; } = true;

        [DisplayName("Enable Mind Message Box")]
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

        [DisplayName("Enable Town Map")]
        [Category("UI Components")]
        public bool EnableTownMap { get; set; } = true;

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
        public static readonly ConfigColor CampMenuItemColorNoSel = new ConfigColor(0xcf, 0x7c, 0xc1, 0xff);
        public static readonly ConfigColor CheckFgBorder = new ConfigColor(0x9b, 0x0b, 0x47, 0xff);
        public static readonly ConfigColor SocialStatsCourage = new ConfigColor(0xf5, 0x62, 0xa7, 0xff);
        public static readonly ConfigColor SocialStatsCharm = new ConfigColor(0xff, 0x8f, 0xec, 0xff); // same as mid color
        public static readonly ConfigColor SocialStatsAcademics = new ConfigColor(0xa0, 0x0c, 0x42, 0xff);
        public static readonly ConfigColor MailIconInnerColor = new ConfigColor(0xff, 0x7f, 0x9f, 0xff);
        public static readonly ConfigColor DateTimeWaterColor = new ConfigColor(0xf0, 0x7c, 0xcd, 0xff);
        public static readonly ConfigColor TextBoxLeftHaze = new ConfigColor(0x83, 0x06, 0x51, 0xff);
        public static readonly ConfigColor TextBoxSpeakerNameTriangle = new ConfigColor(0xc8, 0x05, 0x4b, 0xff);
        // I'd put the discord attachment here but they're time limited now
        public static readonly ConfigColor MellodiColorLight1 = new ConfigColor(0xff, 0xbd, 0xce, 0xff);
        public static readonly ConfigColor MellodiColorLight2 = new ConfigColor(0xfe, 0x9d, 0xb6, 0xff);
        public static readonly ConfigColor MellodiColorLight3 = new ConfigColor(0xff, 0x89, 0xa6, 0xff);
        public static readonly ConfigColor MellodiColorMid1 = new ConfigColor(0xd4, 0x15, 0x5b, 0xff);
        public static readonly ConfigColor MellodiColorMid2 = new ConfigColor(0xff, 0x4a, 0x77, 0xff);
        public static readonly ConfigColor MellodiColorMid3 = new ConfigColor(0xcd, 0x62, 0x90, 0xff);
        public static readonly ConfigColor MellodiColorMid4 = new ConfigColor(0xd4, 0x45, 0x92, 0xff);
        public static readonly ConfigColor MellodiColorDark1 = new ConfigColor(0xb6, 0x3f, 0x67, 0xff);
        public static readonly ConfigColor MellodiColorDark2 = new ConfigColor(0x81, 0x0, 0x6, 0xff);
        public static readonly ConfigColor MellodiColorDark3 = new ConfigColor(0x49, 0x4, 0x21, 0xff);


        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }

        public ConfigColor(byte R, byte G, byte B, byte A) { this.R = R; this.G = G; this.B = B; this.A = A; }

        public uint ToU32() => (uint)(R << 0x18) | (uint)(G << 0x10) | (uint)(B << 0x8) | A;
        public uint ToU32ARGB() => (uint)(A << 0x18) | (uint)(R << 0x10) | (uint)(G << 0x8) | B;
    }
}
