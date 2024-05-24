using p3rpc.commonmodutils;
using p3rpc.femc.Components;
using p3rpc.femc.Template.Configuration;
using Reloaded.Hooks.Definitions.Internal;
using Reloaded.Mod.Interfaces.Structs;
using System;
using System.ComponentModel;
using System.Numerics;

namespace p3rpc.femc.Configuration
{
    public class Config : Configurable<Config>
    {

        [DisplayName("Battle Pack: Mosq")]
        [Category("Music")]
        [Description("Enable Mosq's battle music?")]
        [DefaultValue(true)]
        public bool mosq { get; set; } = true;

        [DisplayName("Battle Pack: Karma")]
        [Category("Music")]
        [Description("Enable Karma's battle music?")]
        [DefaultValue(false)]
        public bool karma { get; set; } = true;

        [DisplayName("Battle Pack: Stella and GillStudio's Rock Covers")]
        [Category("Music")]
        [Description("Enable Stella and GillStudio's battle music?")]
        [DefaultValue(false)]
        public bool rock { get; set; } = true;

        [DisplayName("Night Music: Color your Night")]
        [Category("Music")]
        [Description("Enable Color your Night as the night music?")]
        [DefaultValue(false)]
        public bool colnight { get; set; } = true;

        [DisplayName("Night Music: Midnight Reverie by Mineformer")]
        [Category("Music")]
        [Description("Enable Midnight Reverie as the night music?")]
        [DefaultValue(false)]
        public bool midnight { get; set; } = true;

        [DisplayName("Night Music: Time (Night Version) by Mosq")]
        [Category("Music")]
        [Description("Enable Time (Night Version) as the night music?")]
        [DefaultValue(true)]
        public bool femnight { get; set; } = true;

        [DisplayName("Daytime Music (Outside School/Phase 1): When the Moon's reaching out stars -Reload-")]
        [Description("Enable When the moon's reaching out stars as the daytime music?")]
        [Category("Music")]
        [DefaultValue(false)]
        public bool moon { get; set; } = true;

        [DisplayName("Daytime Music (Outside School/Phase 1): Way of life by Mosq")]
        [Category("Music")]
        [Description("Enable Way of life as the daytime music?")]
        [DefaultValue(true)]
        public bool wayoflife { get; set; } = true;

        [DisplayName("Daytime Music (Inside School/Phase 1): Want to Be Close -Reload-")]
        [Category("Music")]
        [Description("Enable Want to Be Close -Reload- as the daytime music inside the school (Phase 1)?")]
        [DefaultValue(false)]
        public bool wantclose { get; set; } = true;

        [DisplayName("Daytime Music (Inside School/Phase 1): Time by Mosq")]
        [Category("Music")]
        [Description("Enable Time as the daytime music inside the school?")]
        [DefaultValue(true)]
        public bool timeschool { get; set; } = true;

        [DisplayName("Social Link Events: Joy")]
        [Category("Music")]
        [Description("Enable Joy to be the music played during social link events?")]
        [DefaultValue(false)]
        public bool joy { get; set; } = true;

        [DisplayName("Social Link Events: After School by Mosq")]
        [Category("Music")]
        [Description("Enable Mosq's After School to be the music played during social link events?")]
        [DefaultValue(true)]
        public bool afterschool { get; set; } = true;

        [DisplayName("Daytime Music(Inside School/Phase 2): Changing Seasons -Reload-")]
        [Category("Music")]
        [Description("Enable Changing Seasons as the daytime music inside the school?")]
        [DefaultValue(false)]
        public bool seasons { get; set; } = true;

        [DisplayName("Daytime Music(Inside School/Phase 2): Sun by Mosq")]
        [Category("Music")]
        [Description("Enable Sun as the daytime music inside the school?")]
        [DefaultValue(true)]
        public bool sun { get; set; } = true;

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
        public ConfigColor MindWindowOuterBorderNew { get; set; } = UICommon.MindWindowOuterBorder;

        [DisplayName("Mind Window: Inner Color")]
        public ConfigColor MindWindowInnerColorNew { get; set; } = UICommon.MindWindowInnerColor;

        /*[DisplayName("Mind Window: Outer Haze")] i'm hardcoding this it's broken for too many people lol
        public ConfigColor MindWindowOuterHazeEx { get; set; } = new ConfigColor(ConfigColor.MellodiColorLight3.R, ConfigColor.MellodiColorLight3.G, ConfigColor.MellodiColorLight3.B, 128);
        */

        [DisplayName("Mind Window: Background Dots")]
		[Category("Ui Colors")]
		public ConfigColor MindWindowBgDotsNew { get; set; } = UICommon.MindWindowOuterBorder;

        [DisplayName("Minimap: Place Name Background Color")]
		[Category("Ui Colors")]
		public ConfigColor MinimapPlaceNameBgColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Interact Prompt: Back Box Color")]
        public ConfigColor CheckPromptBackBoxColorNew { get; set; } = UICommon.CheckPromptBgBox;

        [DisplayName("Interact Prompt: Front Box Base Color")]
        public ConfigColor CheckPromptFrontBoxColorNew { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Interact Prompt: Front Box Highlight Color")]
        public ConfigColor CheckPromptFrontBoxColorHighNew { get; set; } = UICommon.CheckPromptFgBox;

        [DisplayName("Bustup: Shadow Color")]
		[Category("Ui Colors")]
		public ConfigColor BustupShadowColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Camp: Menu Item Color 1 (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor CampMenuItemColor1 { get; set; } = ConfigColor.CampMenuItemColor1;

        [DisplayName("Camp: Menu Item Color 2 (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor CampMenuItemColor2 { get; set; } = ConfigColor.CampMenuItemColor2;

        [DisplayName("Camp: Menu Item Color 3 (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor CampMenuItemColor3 { get; set; } = ConfigColor.CampMenuItemColor3;

        [DisplayName("Camp: Menu Item Color No Select (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor CampMenuItemColorNoSel { get; set; } = ConfigColor.CampMenuItemColorNoSel;

        [DisplayName("Camp: Skill Text Color")]
		[Category("Ui Colors")]
		public ConfigColor CampSkillTextColor { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Camp: Skill Text Color No Select")]
		[Category("Ui Colors")]
		public ConfigColor CampSkillTextColorNoSel { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Camp: Skill Text Color Current Select")]
		[Category("Ui Colors")]
		public ConfigColor CampSkillTextColorCurrSel { get; set; } = ConfigColor.MellodiColorDark2;

        [DisplayName("Social Stats: Academics Circle Color")]
		[Category("Ui Colors")]
		public ConfigColor SocialStatsCircleAcademicsColor { get; set; } = ConfigColor.SocialStatsAcademics;

        [DisplayName("Social Stats: Charm Circle Color")]
		[Category("Ui Colors")]
		public ConfigColor SocialStatsCircleCharmColor { get; set; } = ConfigColor.SocialStatsCharm;

        [DisplayName("Social Stats: Courage Circle Color")]
		[Category("Ui Colors")]
		public ConfigColor SocialStatsCircleCourageColor { get; set; } = ConfigColor.SocialStatsCourage;

        [DisplayName("Camp: Item Menu Character Top Color (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor CampItemMenuCharacterTopColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Camp: Item Menu Character Bottom Color (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor CampItemMenuCharacterBottomColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Assist Message Box: Background Color")]
		[Category("Ui Colors")]
		public ConfigColor MsgAssistBgColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Town Map: Border Color")]
		[Category("Ui Colors")]
		public ConfigColor TownMapBorderColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Town Map: Text Color")]
		[Category("Ui Colors")]
		public ConfigColor TownMapTextColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Camp Social Link: Light Color")]
		[Category("Ui Colors")]
		public ConfigColor CampSocialLinkLight { get; set; } = ConfigColor.MellodiColorLight2;

        [DisplayName("Camp Social Link: Dark Color")]
		[Category("Ui Colors")]
		public ConfigColor CampSocialLinkDark { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Camp Social Link: Desc BG")]
		[Category("Ui Colors")]
		public ConfigColor CampSocialLinkDetailDescBg { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Camp Social Link: Desc Triangle")]
		[Category("Ui Colors")]
		public ConfigColor CampSocialLinkDetailDescTriangle { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Camp Social Link: Desc Name")]
		[Category("Ui Colors")]
		public ConfigColor CampSocialLinkDetailDescName { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Arcana Card Fall Color 1")]
		[Category("Ui Colors")]
		public ConfigColor ArcanaCardFallColor1 { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Arcana Card Fall Color 2")]
		[Category("Ui Colors")]
		public ConfigColor ArcanaCardFallColor2 { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Arcana Card Fall Color 3")]
		[Category("Ui Colors")]
		public ConfigColor ArcanaCardFallColor3 { get; set; } = ConfigColor.MellodiColorMid3;

        [DisplayName("Camp Calendar: Sunday Color (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor CampCalendarSundayColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Camp Calendar: Sunday Color 2 (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor CampCalendarSundayColor2 { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Camp Calendar: Text Color (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor CampCalendarTextColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Camp Calendar: Highlight Color (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor CampCalendarHighlightColor { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Camp Calendar: Part Time Job Background")]
		[Category("Ui Colors")]
		public ConfigColor CampCalendarPartTimeJobBackground { get; set; } = ConfigColor.MellodiColorDark1;

        [DisplayName("Party Panel Background Color")]
		[Category("Ui Colors")]
		public ConfigColor PartyPanelBgColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Button Prompt Fill Color (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor ButtonPromptHighlightColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Button Prompt Triangle Color")]
		[Category("Ui Colors")]
		public ConfigColor ButtonPromptTriangleColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Back Log Blackboard Color")]
		[Category("Ui Colors")]
		public ConfigColor BackLogBlackboardColor { get; set; } = ConfigColor.BackLogBlackBoard;

        [DisplayName("Back Log Haze Color")]
		[Category("Ui Colors")]
		public ConfigColor BackLogGladationColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Back Log Blueboard Color")]
		[Category("Ui Colors")]
		public ConfigColor BackLogBlueboardColorEx { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Back Log Title Color (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor BackLogTitleColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Back Log Text/Icon Color Selected")]
		[Category("Ui Colors")]
		public ConfigColor BackLogTexColorSelected { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Back Log Text/Icon Color Unselected")]
		[Category("Ui Colors")]
		public ConfigColor BackLogTexColorUnselectedEx { get; set; } = ConfigColor.MellodiColorDark1;

        [DisplayName("Location Select Background Color")]
		[Category("Ui Colors")]
		public ConfigColor LocationSelectBgColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Location Select Marker Color")]
		[Category("Ui Colors")]
		public ConfigColor LocationSelectMarkerColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Location Select Selected Item Color (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor LocationSelectSelColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Time Skip Color")]
		[Category("Ui Colors")]
		public ConfigColor TimeSkipColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Next Day Band Color")]
		[Category("Ui Colors")]
		public ConfigColor NextDayBandColor { get; set; } = ConfigColor.MellodiColorDark1;

        [DisplayName("Next Day Text Color")]
		[Category("Ui Colors")]
		public ConfigColor NextDayTextColor { get; set; } = ConfigColor.MellodiColorMid3;

        [DisplayName("Next Day Moon Shadow Color")]
		[Category("Ui Colors")]
		public ConfigColor NextDayMoonShadowColor { get; set; } = ConfigColor.DayChangeMoonShadow;

        [DisplayName("Next Day Ripple")]
		[Category("Ui Colors")]
		public ConfigColor NextDayRipple { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Shop Payment Color")]
		[Category("Ui Colors")]
		public ConfigColor ShopPayColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Shop Fill Color")]
		[Category("Ui Colors")]
		public ConfigColor ShopFillColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Shop Shadow Color")]
		[Category("Ui Colors")]
		public ConfigColor ShopShadowColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Shop Payment Unselect Color")]
		[Category("Ui Colors")]
		public ConfigColor ShopPayUnselColor { get; set; } = ConfigColor.MellodiColorMid4;

        [DisplayName("Get Item Background Mask Color")]
		[Category("Ui Colors")]
		public ConfigColor GetItemBgMaskColor { get; set; } = ConfigColor.GetItemFillMask;

        [DisplayName("Get Item Background Color")]
		[Category("Ui Colors")]
		public ConfigColor GetItemBgColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Get Item Got Text Color")]
		[Category("Ui Colors")]
		public ConfigColor GetItemGotTextColor { get; set; } = ConfigColor.GetItemGotTextColor;

        [DisplayName("Get Item Got Item Count Background")]
		[Category("Ui Colors")]
		public ConfigColor GetItemCountBgColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Mind Select: Selected Text Color")]
		[Category("Ui Colors")]
		public ConfigColor MindSelActiveTextColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Mind Select Window Fill (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor MindSelWindowFill { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Mind Select Window Border (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor MindSelWindowBorder { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Mind Select Dot Color (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor MindSelectDotColor { get; set; } = ConfigColor.MindSelectDotColor;

        [DisplayName("Generic Select Character Backplate Color ")]
		[Category("Ui Colors")]
		public ConfigColor GenericSelectCharacterBackplate { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Generic Select List Color Morning")]
		[Category("Ui Colors")]
		public ConfigColor GenericSelectListColorMorning { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Generic Select List Color After School")]
		[Category("Ui Colors")]
		public ConfigColor GenericSelectListColorAfterSchool { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Generic Select List Color Night")]
		[Category("Ui Colors")]
		public ConfigColor GenericSelectListColorNight { get; set; } = ConfigColor.MellodiColorMid3;

        [DisplayName("Generic Select Title Color")]
		[Category("Ui Colors")]
		public ConfigColor GenericSelectTitle { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Generic Select Character Shadow (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor GenericSelectCharacterShadow { get; set; } = ConfigColor.MellodiColorMid4;

        [DisplayName("Message Box Select Text Color")]
		[Category("Ui Colors")]
		public ConfigColor MsgSimpleSelectTextColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Message Box Select Box Shadow Color")]
		[Category("Ui Colors")]
		public ConfigColor MsgSimpleSelectBoxShadow { get; set; } = ConfigColor.MellodiColorDark1;

        [DisplayName("Message Box Shadow Color")]
		[Category("Ui Colors")]
		public ConfigColor MsgSimpleSelectShadowEx { get; set; } = ConfigColor.TextBoxFrontFillColor;

        [DisplayName("Message Box Border Color")]
		[Category("Ui Colors")]
		public ConfigColor MsgSimpleSelectBorderColorEx { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("System Message Light Color (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor MsgSimpleSystemLightColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("System Message Dark Color")]
		[Category("Ui Colors")]
		public ConfigColor MsgSimpleSystemDarkColor { get; set; } = ConfigColor.MsgWindowSystemDark;

        [DisplayName("System Message Dark Haze Color")]
		[Category("Ui Colors")]
		public ConfigColor MsgSimpleSystemGradationColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Persona Status Skill List Background Top Left")]
		[Category("Ui Colors")]
		public ConfigColor PersonaStatusSkillListBg { get; set; } = ConfigColor.PersonaStatusSkillListBg;

        [DisplayName("Persona Status Skill List Background Lower Line")]
		[Category("Ui Colors")]
		public ConfigColor PersonaStatusSkillListBg2 { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Persona Status Skill List Checkerboard")]
		[Category("Ui Colors")]
		public ConfigColor PersonaStatusSkillListCheckboardAlt { get; set; } = ConfigColor.PersonaStatusSkillListCheckboardAlt;

        [DisplayName("Persona Status Skill List Next Skill Color")]
		[Category("Ui Colors")]
		public ConfigColor PersonaSkillListNextSkillColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Persona Status Skill List Level Color")]
		[Category("Ui Colors")]
		public ConfigColor PersonaSkillListNextLevelColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Persona Status Skill List Next Skill Name Color")]
		[Category("Ui Colors")]
		public ConfigColor PersonaSkillListNextSkillInfoName { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Persona Status Info Color")]
		[Category("Ui Colors")]
		public ConfigColor PersonaStatusPlayerInfoColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Persona Status Info Selected Persona Color 1")]
		[Category("Ui Colors")]
		public ConfigColor PersonaStatusInfoSelPersonaColor1 { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Persona Status Info Selected Persona Color 2")]
		[Category("Ui Colors")]
		public ConfigColor PersonaStatusInfoSelPersonaColor2 { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Persona Status Param Background Color")]
		[Category("Ui Colors")]
		public ConfigColor PersonaStatusParamColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Persona Status Lore Title Color")]
		[Category("Ui Colors")]
		public ConfigColor PersonaStatusCommentaryTitleColor { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Persona Status Base Stat Color")]
		[Category("Ui Colors")]
		public ConfigColor PersonaStatusBaseStat { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Persona Status Skill Affinity Outline Color (Requires Restart)")]
		[Category("Ui Colors")]
		public ConfigColor PersonaStatusAttributeOutline { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Network: Daily Action Sticky Note Background Color 1")]
		[Category("Ui Colors")]
		public ConfigColor NetworkDailyActionStickyNoteBgColor1 { get; set; } = UICommon.NetStickyNoteBgColor1;

        [DisplayName("Network: Daily Action Sticky Note Background Color 2")]
		[Category("Ui Colors")]
		public ConfigColor NetworkDailyActionStickyNoteBgColor2 { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Network: Daily Action Sticky Note Dotpoint Color 1")]
		[Category("Ui Colors")]
		public ConfigColor NetworkDailyActionStickyNoteDotColor1 { get; set; } = ConfigColor.MellodiColorLight2;

        [DisplayName("Network: Daily Action Sticky Note Dotpoint Color 2")]
		[Category("Ui Colors")]
		public ConfigColor NetworkDailyActionStickyNoteDotColor2 { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Network: Daily Action Sticky Note Text Color 1")]
		[Category("Ui Colors")]
		public ConfigColor NetworkDailyActionStickyNoteTextColor1 { get; set; } = UICommon.NetStickyNoteTextColor1;

        [DisplayName("Network: Daily Action Sticky Note Text Color 2")]
		[Category("Ui Colors")]
		public ConfigColor NetworkDailyActionStickyNoteTextColor2 { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Network: Daily Action Blue Background Color")]
		[Category("Ui Colors")]
		public ConfigColor NetworkDailyActionBlueBgColor { get; set; } = ConfigColor.MellodiColorMid4;

        [DisplayName("Network: Daily Action Network Icon Color")]
		[Category("Ui Colors")]
		public ConfigColor NetworkDailyActionNetworkIcon { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Simple Shop: Info Color")]
		[Category("Ui Colors")]
		public ConfigColor SimpleShopInfoColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Cutin: Outer Highlight Color")]
		[Category("Ui Colors")]
		public ConfigColor CutinOuterHighlight { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Cutin: Emotion Gradient Color")]
		[Category("Ui Colors")]
		public ConfigColor CutinEmotionGradient { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Cutin: Emotion Tint Color")]
		[Category("Ui Colors")]
		public ConfigColor CutinEmotionTint { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Title Menu: Select Rectangle Color")]
        public ConfigColor TitleMenuSelRectColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Localization Staff Roll: Header Color (Requires Restart)")]
        public ConfigColor LocalStaffRollHeader { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Difficulty Selection Background")]
        public ConfigColor DifficultySelectBgColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Wipe Background")]
        public ConfigColor WipeBgColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Camp Equip: Item Stat Value Padding Color")]
        public ConfigColor CampItemStatValuePadColor { get; set; } = ConfigColor.MellodiColorDark1;

        [DisplayName("Camp Equip: Item Stat Value Padding Color")]
        public ConfigColor CampItemStatValueValColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Camp Equip: Overview List Type Color")]
        public ConfigColor CampEquipOverviewListType { get; set; } = ConfigColor.MellodiColorMid3;

        [DisplayName("Camp Persona: Arcana Phrase Color (Requires Restart)")]
        public ConfigColor CampPersonaArcanaPhraseColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Camp Persona: Name Color")]
        public ConfigColor CampPersonaNameColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Camp Persona: Arcana Background Color")]
        public ConfigColor CampPersonaArcanaBgColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Camp Status: Kotone Line Color")]
        public ConfigColor CampStatusKotoneLineColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Camp Status: Inactive Party Member Background (Tartarus)")]
        public ConfigColor CampStatusInactiveMemberBgTartarus { get; set; } = UICommon.InactivePartyMemberTartarusBG;

        [DisplayName("Camp Status: Inactive Member Details Pale Pink (Tartarus)")]
        public ConfigColor CampStatusInactiveMemberDetailsPalePinkTartarus { get; set; } = UICommon.InactivePartyMemberPalePink;
        
        [DisplayName("Camp Status: Inactive Member Details Dark Pink (Tartarus)")]
        public ConfigColor CampStatusInactiveMemberDetailsDarkPinkTartarus { get; set; } = UICommon.InactivePartyMemberDarkPink;
        
        [DisplayName("Camp Status: Inactive Member HP Bar (Tartarus)")]
        public ConfigColor CampStatusInactiveMemberHPBarTartarus { get; set; } = UICommon.InactivePartyMemberHPColor;

        [DisplayName("Town Map: Location Details Background Tint")]
        public ConfigColor TownMapLocationDetailsBgTint { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Town Map: Location Details Top Left Bg")]
        public ConfigColor TownMapLocationDetailsTopLeftBg { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Town Map: Location Details Top Left Text")]
        public ConfigColor TownMapLocationDetailsTopLeftText { get; set; } = ConfigColor.MellodiColorMid1;

		[DisplayName("Town Map: Selected Marker Outline")]
		public ConfigColor TownMapSelectedMarkerOutline { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Social Stats: Stats Up Text")]
        public ConfigColor SocialStatsUpText { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Social Stats: Stat Up Pulse Circle Color")]
        public ConfigColor SocialStatsPulseCircleColorMain { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Social Stats: Stat Up Pulse Circle Fade")]
        public ConfigColor SocialStatsPulseCircleColorFade { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Assist Message Box: Text Background")]
        public ConfigColor MsgAssistTextBgColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Location Select: Map Background Color")]
        public ConfigColor LocationSelMapBg { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Location Select: Map Label Color")]
        public ConfigColor LocationSelMapLabel { get; set; } = UICommon.LocationSelectMapLabel;

        [DisplayName("System Message Picture Border Color (Requires Restart)")]
        public ConfigColor MsgSystemPicBorderColor { get; set; } = ConfigColor.MellodiColorDark1;

        [DisplayName("Tutorial List Entry Color (Requires Restart)")]
        public ConfigColor TutorialListEntryColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Tutorial List Background Color")]
        public ConfigColor TutorialBgColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Missing Person: Selected Person \"Last Sighted\" Color")]
        public ConfigColor MissingLastSighted { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Missing Person: Page Background")]
        public ConfigColor MissingPageBg { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Missing Person: Light Text Color")]
        public ConfigColor MissingTextLight { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Missing Person: Dark Text Color")]
        public ConfigColor MissingTextDark { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Missing Person: Sort by Triangle")]
        public ConfigColor MissingSortTriangle { get; set; } = ConfigColor.MellodiColorMid2;


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

        [DisplayName("Enable Title Menu")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableTitleMenu { get; set; } = true;

        [DisplayName("Enable Staff Roll")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableStaffRoll { get; set; } = true;

        [DisplayName("Enable Cutin")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableCutin { get; set; } = true;

        [DisplayName("Enable Wipe")]
        [Category("UI Components")]
        [DefaultValue(true)]
        public bool EnableWipe { get; set; } = true;

        /*[DisplayName("Draw Original Select Box")]
        [Category("Debug")]
        [DefaultValue(true)]
        public bool DebugDrawOgSelBox { get; set; } = true;
        */
        /*
        [DisplayName("Draw Original Missing Person")]
        [Category("Debug")]
        [DefaultValue(true)]
        public bool DebugDrawMissingPerson { get; set; } = true;
        */

        [DisplayName("Hair Options")]
		[Description("This is an enumerable.")]
		[Category("3D Options")]
		[DefaultValue(HairType.MudkipsHair)]
		public HairType HairTrue { get; set; } = HairType.MudkipsHair;

		public enum HairType
		{
			MudkipsHair,
			KotoneBeanHair
		}

		[DisplayName("AOA Options")]
		[Description("The AOA Image.")]
		[Category("2D Options")]
		[DefaultValue(AOAType.Fernando)]
		public AOAType AOATrue { get; set; } = AOAType.Ely;

		public enum AOAType
		{
			Ely,
			Chrysanthie,
			Fernando,
			Monica,
			RonaldReagan
		}

		[DisplayName("AOA Text Options")]
		[Description("The AOA Foreground Text.")]
		[Category("2D Options")]
		[DefaultValue(AOATextType.SorryBoutThat)]
		public AOATextType AOAText { get; set; } = AOATextType.SorryBoutThat;

		public enum AOATextType
		{
			DontLookBack,
			SorryBoutThat
		}


		[DisplayName("Bustup")]
		[Description("The Bustup.")]
		[Category("2D Options")]
		[DefaultValue(BustupType.Neptune)]
		public BustupType BustupTrue { get; set; } = BustupType.Neptune;

		public enum BustupType
		{
			Neptune,
			Ely,
			Esa,
			Betina,
			Anniversary,
			JustBlue,
			Sav,
			Doodled,
			RonaldReagan
		}

		[DisplayName("Glass Shard")]
		[Description("The Glass Shard in that one menu when pausing.")]
		[Category("2D Options")]
		[DefaultValue(ShardType.Esa)]
		public ShardType ShardTrue { get; set; } = ShardType.Esa;

		public enum ShardType
		{
			Esa,
			Ely
		}

		[DisplayName("Level Up")]
		[Description("The Level Up :adachitrue:.")]
		[Category("2D Options")]
		[DefaultValue(LevelUpType.Esa)]
		public LevelUpType LevelUpTrue { get; set; } = LevelUpType.Esa;

		public enum LevelUpType
		{
			Esa,
			Ely
		}

		[DisplayName("Cutin")]
		[Description("Cutin Movie")]
		[Category("2D Options")]
		[DefaultValue(CutinType.berrycha)]
		public CutinType CutinTrue { get; set; } = CutinType.berrycha;

		public enum CutinType
		{
			berrycha,
			ElyandPatmandx
		}

		[DisplayName("Kotone Room")]
		[Category("Fun Stuff")]
		[DefaultValue(false)]
		public bool KotoneRoom { get; set; } = false;

		[DisplayName("Funny Anims")]
		[Category("Fun Stuff")]
		[DefaultValue(false)]
		public bool FunnyAnims { get; set; } = false;

        [DisplayName("Debug Log Level")]
        [Category("Debug")]
        [DefaultValue(LogLevel.Information)]
        public LogLevel DebugLogLevel { get; set; } = LogLevel.Information;

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
