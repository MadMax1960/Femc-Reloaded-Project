using p3rpc.commonmodutils;
using p3rpc.femc.Components;
using p3rpc.femc.Template.Configuration;
using Reloaded.Mod.Interfaces.Structs;
using System.ComponentModel;

namespace p3rpc.femc.Configuration
{
    public class Config : Configurable<Config>
    {

        [DisplayName("Mail Icon: Outer Color")]
        public ConfigColor MailIconOuterCircleColorEx { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Mail Icon: Inner Color")]
        public ConfigColor MailIconInnerCircleColorEx { get; set; } = ConfigColor.MailIconInnerColor;

        [DisplayName("Camp: High Color")]
        public ConfigColor CampHighColor { get; set; } = ConfigColor.CampBgColor;

        [DisplayName("Camp: High Color Gradation")]
        public ConfigColor CampHighColorGradation { get; set; } = ConfigColor.CampBgColor;

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

        /*[DisplayName("Mind Window: Outer Haze")] i'm hardcoding this it's broken for too many people lol
        public ConfigColor MindWindowOuterHazeEx { get; set; } = new ConfigColor(ConfigColor.MellodiColorLight3.R, ConfigColor.MellodiColorLight3.G, ConfigColor.MellodiColorLight3.B, 128);
        */

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

        [DisplayName("Camp: Skill Text Color")]
        public ConfigColor CampSkillTextColor { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Camp: Skill Text Color No Select")]
        public ConfigColor CampSkillTextColorNoSel { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Camp: Skill Text Color Current Select")]
        public ConfigColor CampSkillTextColorCurrSel { get; set; } = ConfigColor.MellodiColorDark2;

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

        [DisplayName("Party Panel Background Color")]
        public ConfigColor PartyPanelBgColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Button Prompt Fill Color (Requires Restart)")]
        public ConfigColor ButtonPromptHighlightColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Button Prompt Triangle Color")]
        public ConfigColor ButtonPromptTriangleColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Back Log Blackboard Color")]
        public ConfigColor BackLogBlackboardColor { get; set; } = ConfigColor.BackLogBlackBoard;

        [DisplayName("Back Log Haze Color")]
        public ConfigColor BackLogGladationColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Back Log Blueboard Color")]
        public ConfigColor BackLogBlueboardColorEx { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Back Log Title Color (Requires Restart)")]
        public ConfigColor BackLogTitleColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Back Log Text/Icon Color Selected")]
        public ConfigColor BackLogTexColorSelected { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Back Log Text/Icon Color Unselected")]
        public ConfigColor BackLogTexColorUnselectedEx { get; set; } = ConfigColor.MellodiColorDark1;

        [DisplayName("Location Select Background Color")]
        public ConfigColor LocationSelectBgColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Location Select Marker Color")]
        public ConfigColor LocationSelectMarkerColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Location Select Selected Item Color (Requires Restart)")]
        public ConfigColor LocationSelectSelColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Time Skip Color")]
        public ConfigColor TimeSkipColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Next Day Band Color")]
        public ConfigColor NextDayBandColor { get; set; } = ConfigColor.MellodiColorDark1;

        [DisplayName("Next Day Text Color")]
        public ConfigColor NextDayTextColor { get; set; } = ConfigColor.MellodiColorMid3;

        [DisplayName("Next Day Moon Shadow Color")]
        public ConfigColor NextDayMoonShadowColor { get; set; } = ConfigColor.DayChangeMoonShadow;

        [DisplayName("Next Day Ripple")]
        public ConfigColor NextDayRipple { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Shop Payment Color")]
        public ConfigColor ShopPayColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Shop Fill Color")]
        public ConfigColor ShopFillColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Shop Shadow Color")]
        public ConfigColor ShopShadowColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Shop Payment Unselect Color")]
        public ConfigColor ShopPayUnselColor { get; set; } = ConfigColor.MellodiColorMid4;

        [DisplayName("Get Item Background Mask Color")]
        public ConfigColor GetItemBgMaskColor { get; set; } = ConfigColor.GetItemFillMask;

        [DisplayName("Get Item Background Color")]
        public ConfigColor GetItemBgColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Get Item Got Text Color")]
        public ConfigColor GetItemGotTextColor { get; set; } = ConfigColor.GetItemGotTextColor;

        [DisplayName("Get Item Got Item Count Background")]
        public ConfigColor GetItemCountBgColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Mind Select: Selected Text Color")]
        public ConfigColor MindSelActiveTextColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Mind Select Window Fill (Requires Restart)")]
        public ConfigColor MindSelWindowFill { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Mind Select Window Border (Requires Restart)")]
        public ConfigColor MindSelWindowBorder { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Mind Select Dot Color (Requires Restart)")]
        public ConfigColor MindSelectDotColor { get; set; } = ConfigColor.MindSelectDotColor;

        [DisplayName("Generic Select Character Backplate Color ")]
        public ConfigColor GenericSelectCharacterBackplate { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Generic Select List Color Morning")]
        public ConfigColor GenericSelectListColorMorning { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Generic Select List Color After School")]
        public ConfigColor GenericSelectListColorAfterSchool { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Generic Select List Color Night")]
        public ConfigColor GenericSelectListColorNight { get; set; } = ConfigColor.MellodiColorMid3;

        [DisplayName("Generic Select Title Color")]
        public ConfigColor GenericSelectTitle { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Generic Select Character Shadow (Requires Restart)")]
        public ConfigColor GenericSelectCharacterShadow { get; set; } = ConfigColor.MellodiColorMid4;

        [DisplayName("Message Box Select Text Color")]
        public ConfigColor MsgSimpleSelectTextColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Message Box Select Box Shadow Color")]
        public ConfigColor MsgSimpleSelectBoxShadow { get; set; } = ConfigColor.MellodiColorDark1;

        [DisplayName("Message Box Shadow Color")]
        public ConfigColor MsgSimpleSelectShadowEx { get; set; } = ConfigColor.TextBoxFrontFillColor;

        [DisplayName("Message Box Border Color")]
        public ConfigColor MsgSimpleSelectBorderColorEx { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("System Message Light Color (Requires Restart)")]
        public ConfigColor MsgSimpleSystemLightColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("System Message Dark Color")]
        public ConfigColor MsgSimpleSystemDarkColor { get; set; } = ConfigColor.MsgWindowSystemDark;

        [DisplayName("System Message Dark Haze Color")]
        public ConfigColor MsgSimpleSystemGradationColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Persona Status Skill List Background Top Left")]
        public ConfigColor PersonaStatusSkillListBg { get; set; } = ConfigColor.PersonaStatusSkillListBg;

        [DisplayName("Persona Status Skill List Background Lower Line")]
        public ConfigColor PersonaStatusSkillListBg2 { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Persona Status Skill List Checkerboard")]
        public ConfigColor PersonaStatusSkillListCheckboardAlt { get; set; } = ConfigColor.PersonaStatusSkillListCheckboardAlt;

        [DisplayName("Persona Status Skill List Next Skill Color")]
        public ConfigColor PersonaSkillListNextSkillColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Persona Status Skill List Level Color")]
        public ConfigColor PersonaSkillListNextLevelColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Persona Status Skill List Next Skill Name Color")]
        public ConfigColor PersonaSkillListNextSkillInfoName { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Persona Status Info Color")]
        public ConfigColor PersonaStatusPlayerInfoColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Persona Status Info Selected Persona Color 1")]
        public ConfigColor PersonaStatusInfoSelPersonaColor1 { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Persona Status Info Selected Persona Color 2")]
        public ConfigColor PersonaStatusInfoSelPersonaColor2 { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Persona Status Param Background Color")]
        public ConfigColor PersonaStatusParamColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Persona Status Lore Title Color")]
        public ConfigColor PersonaStatusCommentaryTitleColor { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Persona Status Base Stat Color")]
        public ConfigColor PersonaStatusBaseStat { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Persona Status Skill Affinity Outline Color (Requires Restart)")]
        public ConfigColor PersonaStatusAttributeOutline { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Network: Daily Action Sticky Note Background Color 1")]
        public ConfigColor NetworkDailyActionStickyNoteBgColor1 { get; set; } = UICommon.NetStickyNoteBgColor1;

        [DisplayName("Network: Daily Action Sticky Note Background Color 2")]
        public ConfigColor NetworkDailyActionStickyNoteBgColor2 { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Network: Daily Action Sticky Note Dotpoint Color 1")]
        public ConfigColor NetworkDailyActionStickyNoteDotColor1 { get; set; } = ConfigColor.MellodiColorLight2;

        [DisplayName("Network: Daily Action Sticky Note Dotpoint Color 2")]
        public ConfigColor NetworkDailyActionStickyNoteDotColor2 { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Network: Daily Action Sticky Note Text Color 1")]
        public ConfigColor NetworkDailyActionStickyNoteTextColor1 { get; set; } = UICommon.NetStickyNoteTextColor1;

        [DisplayName("Network: Daily Action Sticky Note Text Color 2")]
        public ConfigColor NetworkDailyActionStickyNoteTextColor2 { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Network: Daily Action Blue Background Color")]
        public ConfigColor NetworkDailyActionBlueBgColor { get; set; } = ConfigColor.MellodiColorMid4;

        [DisplayName("Network: Daily Action Network Icon Color")]
        public ConfigColor NetworkDailyActionNetworkIcon { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Simple Shop: Info Color")]
        public ConfigColor SimpleShopInfoColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Cutin: Outer Highlight Color")]
        public ConfigColor CutinOuterHighlight { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Cutin: Emotion Gradient Color")]
        public ConfigColor CutinEmotionGradient { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Cutin: Emotion Tint Color")]
        public ConfigColor CutinEmotionTint { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Enable Mail Icon")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableMailIcon { get; set; } = true;

        [DisplayName("Enable Date Time Panel")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableDateTimePanel { get; set; } = true;

        [DisplayName("Enable Camp Menu")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableCampMenu { get; set; } = true;

        [DisplayName("Enable Standard Message Box")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableTextbox { get; set; } = true;

        [DisplayName("Enable Mind Message Box")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableMindMessageBox { get; set; } = true;

        [DisplayName("Enable Interact Prompt")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableInteractPrompt { get; set; } = true;

        [DisplayName("Enable Minimap")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableMinimap { get; set; } = true;

        [DisplayName("Enable Bustup")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableBustup { get; set; } = true;

        [DisplayName("Enable MessageScript")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableMessageScript { get; set; } = true;

        [DisplayName("Enable Town Map")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableTownMap { get; set; } = true;

        [DisplayName("Enable Party Panel")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnablePartyPanel { get; set; } = true;

        [DisplayName("Enable Time Skip")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableTimeSkip { get; set; } = true;

        [DisplayName("Enable Get Item")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableGetItem { get; set; } = true;

        [DisplayName("Enable Network Features")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableNetworkFeatures { get; set; } = true;

        [DisplayName("Enable Shop")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableShop { get; set; } = true;

        [DisplayName("Enable Persona Status")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnablePersonaStatus { get; set; } = true;

        [DisplayName("Enable Backlog")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableBacklog { get; set; } = true;

        [DisplayName("Enable Button Prompts")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableButtonPrompts { get; set; } = true;

        [DisplayName("Enable Cutin")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableCutin { get; set; } = true;

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
