using p3rpc.commonmodutils;
using p3rpc.femc.Components;
using p3rpc.femc.Template.Configuration;
using System.ComponentModel;
using System.Diagnostics;
using p3rpc.femc;
using System.ComponentModel.DataAnnotations;

namespace p3rpc.femc.Configuration
{

    public class Config : Configurable<Config>
    {
        //Config Editing Standards: Any bool designed to be accessed by the config app must be in CamelCase

		[DisplayName("Pull the Trigger (Karma Remix)")]
		[Category("Battle Music")]
		[Description("Enable Karma's pull the trigger?")]
        [Display(Order = 24)]
		[DefaultValue(false)]
		public bool KarmaAdv { get; set; } = true;

		[DisplayName("Pull the trigger (Mosq Remix)")]
		[Category("Battle Music")]
		[Description("Enable Mosq's pull the trigger?")]
        [Display(Order = 23)]
		[DefaultValue(true)]
		public bool MosqAdv { get; set; } = true;

		[DisplayName("Pull the Trigger (EidieK87 Remix)")]
		[Category("Battle Music")]
		[Description("Enable EidieK87's pull the trigger?")]
        [Display(Order = 25)]
		[DefaultValue(false)]
		public bool EidAdv { get; set; } = true;

        [DisplayName("Danger Zone (EidieK87 Remix)")]
        [Category("Battle Music")]
        [Description("Enable EidieK87's Danger Zone?")]
        [Display(Order = 35)]
        [DefaultValue(false)]
        public bool EidDis { get; set; } = true;

        [DisplayName("Wiping All Out (Mosq Remix)")]
		[Category("Battle Music")]
		[Description("Enable Mosq's Wiping All Out?")]
        [Display(Order = 42)]
		[DefaultValue(true)]
		public bool MosqNom { get; set; } = true;

		[DisplayName("Wiping All Out (Karma Remix)")]
		[Category("Battle Music")]
		[Description("Enable Karma's Wiping All Out?")]
        [Display(Order = 43)]
		[DefaultValue(false)]
		public bool KarmaNom { get; set; } = true;

		[DisplayName("Wiping All Out (Stella and GillStudio Remix)")]
		[Category("Battle Music")]
		[Description("Enable Stella and GillStudio's Wiping All Out?")]
        [Display(Order = 44)]
		[DefaultValue(false)]
		public bool SgNom { get; set; } = true;

        [DisplayName("Wiping All Out")]
        [Category("Battle Music")]
        [Description("Enable Wiping All Out (P3P)?")]
        [Display(Order = 41)]
        [DefaultValue(true)]
        public bool P3PNom { get; set; } = true;

        [DisplayName("Danger Zone (Stella and GillStudio Remix)")]
		[Category("Battle Music")]
		[Description("Enable Stella and GillStudio's Danger Zone?")]
        [Display(Order = 34)]
		[DefaultValue(false)]
		public bool SgDis { get; set; } = true;

		[DisplayName("Danger Zone (Karma Remix)")]
		[Category("Battle Music")]
		[Description("Enable Karma's Danger Zone?")]
        [Display(Order = 33)]
		[DefaultValue(false)]
		public bool KarmaDis { get; set; } = true;

		[DisplayName("Danger Zone (Mosq Remix)")]
		[Category("Battle Music")]
		[Description("Enable Mosq's Danger Zone?")]
        [Display(Order = 32)]
		[DefaultValue(true)]
		public bool MosqDis { get; set; } = true;

        [DisplayName("Danger Zone")]
        [Category("Battle Music")]
        [Description("Enable Danger Zone (P3P)?")]
        [Display(Order = 31)]
        [DefaultValue(true)]
        public bool P3PDis { get; set; } = true;

        [DisplayName("It's Going Down Now")]
		[Category("Battle Music")]
		[Description("Enable Atlus's It's Going down now?")]
        [Display(Order = 20)]
		[DefaultValue(false)]
		public bool ItGoingDown { get; set; } = true;

        [DisplayName("It's Going Down Now (Jen Remix)")]
        [Category("Battle Music")]
        [Description("Enable Jen's It's Going down now?")]
        [Display(Order = 21)]
        [DefaultValue(false)]
        public bool JenAdv { get; set; } = true;

        [DisplayName("Daytime Music (Outside School/Phase 1): Way of life by Jen")]
        [Category("Music")]
        [Description("Enable Way of life by Jen as the daytime music?")]
        [Display(Order = 66)]
        [DefaultValue(false)]
        public bool WayOfLifeJen { get; set; } = true;

        [DisplayName("Master of Tartarus -Reload-")]
		[Category("Battle Music")]
		[Description("Enable Atlus's Master of Tartarus -Reload-?")]
        [Display(Order = 30)]
		[DefaultValue(false)]
		public bool MasterTar { get; set; } = true;

		[DisplayName("Mass Destruction -Reload-")]
		[Category("Battle Music")]
		[Description("Enable Atlus's Mass Destruction -Reload-?")]
        [Display(Order = 40)]
		[DefaultValue(false)]
		public bool MassDes { get; set; } = true;

		[DisplayName("Night Music: Color your Night")]
		[Category("Music")]
		[Description("Enable Color your Night as the night music?")]
        [Display(Order = 84)]
        [DefaultValue(false)]
		public bool ColNight { get; set; } = true;

		[DisplayName("Night Music: Midnight Reverie by Mineformer")]
		[Category("Music")]
		[Description("Enable Midnight Reverie as the night music?")]
        [Display(Order = 82)]
        [DefaultValue(false)]
		public bool MidNight { get; set; } = true;

		[DisplayName("Night Music: Time (Night Version) by Mosq")]
		[Category("Music")]
		[Description("Enable Time (Night Version) as the night music?")]
        [Display(Order = 80)]
        [DefaultValue(true)]
		public bool FemNight { get; set; } = true;

		[DisplayName("Night Music: Time (Night Version) by Mosq with Vocals by GabiShy")]
		[Category("Music")]
		[Description("Enable Time (Night Version GabiShy Remix) as the night music?")]
        [Display(Order = 81)]
        [DefaultValue(false)]
		public bool GabiFemNight { get; set; } = true;

		[DisplayName("Night Music: Night Wanderer by Mosq")]
		[Category("Music")]
		[Description("Enable Night Wanderer as the night music?")]
        [Display(Order = 83)]
        [DefaultValue(false)]
		public bool NightWand { get; set; } = true;

		[DisplayName("Night Music: Moonlight by Mosq")]
		[Category("Music")]
		[Description("Enable Moonlight as the night music?")]
        [Display(Order = 86)]
        [DefaultValue(false)]
		public bool EsaComm { get; set; } = true;

		[DisplayName("Night Music: Color your night by Pealeaf and ChewieMelodies")]
        [Category("Music")]
        [Description("Enable Night Color your night as the night music?")]
        [Display(Order = 85)]
        [DefaultValue(false)]
        public bool PeaColNight { get; set; } = true;

        [DisplayName("Daytime Music (Outside School/Phase 1): When the Moon's reaching out stars -Reload-")]
		[Description("Enable When the moon's reaching out stars as the daytime music?")]
		[Category("Music")]
        [Display(Order = 67)]
        [DefaultValue(false)]
		public bool Moon { get; set; } = true;

        [DisplayName("Daytime Music (Outside School/Phase 1): Way of Life -Reload- Mayumi ver")]
        [Description("Enable Way of Life by Super M Plush, Mosq, Karma and cora as the daytime music?")]
        [Category("Music")]
        [Display(Order = 70)]
        [DefaultValue(false)]
        public bool WayLifeVocal { get; set; } = true;

        [DisplayName("Daytime Music (Outside School/Phase 1): Way of life by Mosq")]
		[Category("Music")]
		[Description("Enable Way of life as the daytime music?")]
        [Display(Order = 65)]
		[DefaultValue(true)]
		public bool WayOfLife { get; set; } = true;

        [DisplayName("Daytime Music (Outside School/Phase 1): Way of life")]
        [Category("Music")]
        [Description("Enable Way of life (P3P) as the daytime music?")]
        [Display(Order = 68)]
        [DefaultValue(true)]
        public bool WayOfLifeP3P { get; set; } = true;

        [DisplayName("Daytime Music (Outside School/Phase 1): Way of life -Deep inside my mind Remix-")]
        [Category("Music")]
        [Description("Enable Way of life -Deep inside my mind Remix- as the daytime music?")]
        [Display(Order = 69)]
        [DefaultValue(true)]
        public bool WayOfLifeRemix { get; set; } = true;

        [DisplayName("Daytime Music (Inside School/Phase 1): Want to Be Close -Reload-")]
		[Category("Music")]
		[Description("Enable Want to Be Close -Reload- as the daytime music inside the school (Phase 1)?")]
        [Display(Order = 57)]
        [DefaultValue(false)]
		public bool WantClose { get; set; } = true;

		[DisplayName("Daytime Music (Inside School/Phase 1): Time by Mosq")]
		[Category("Music")]
		[Description("Enable Time as the daytime music inside the school?")]
        [Display(Order = 55)]
		[DefaultValue(true)]
		public bool TimeSchool { get; set; } = true;

		[DisplayName("Daytime Music (Inside School/Phase 1): Time -Reload- Mayumi ver")]
		[Category("Music")]
		[Description("Enable Time -Reload- by GabiShy and Mosq as the daytime music inside the school?")]
        [Display(Order = 56)]
        [DefaultValue(false)]
		public bool GabiTimeSchool { get; set; } = true;

        [DisplayName("Daytime Music (Inside School/Phase 1): Time")]
        [Category("Music")]
        [Description("Enable Time (P3P) as the daytime music inside the school?")]
        [Display(Order = 58)]
        [DefaultValue(true)]
        public bool TimeSchoolP3P { get; set; } = true;

        [DisplayName("Social Link Events: Joy")]
		[Category("Music")]
		[Description("Enable Joy to be the music played during social link events?")]
        [Display(Order = 90)]
        [DefaultValue(false)]
		public bool Joy { get; set; } = true;

		[DisplayName("Social Link Events: After School by Mosq")]
		[Category("Music")]
		[Description("Enable Mosq's After School to be the music played during social link events?")]
        [Display(Order = 92)]
        [DefaultValue(true)]
		public bool AfterSchool { get; set; } = true;

        [DisplayName("Social Link Events: After School")]
        [Category("Music")]
        [Description("Enable After School (P3P) to be the music played during social link events?")]
        [Display(Order = 91)]
        [DefaultValue(true)]
        public bool AfterSchoolP3P { get; set; } = true;

        [DisplayName("Daytime Music(Inside School/Phase 2): Changing Seasons -Reload-")]
		[Category("Music")]
		[Description("Enable Changing Seasons as the daytime music inside the school?")]
        [Display(Order = 62)]
        [DefaultValue(false)]
		public bool Seasons { get; set; } = true;

		[DisplayName("Daytime Music(Inside School/Phase 2): Sun by Mosq")]
		[Category("Music")]
		[Description("Enable Sun as the daytime music inside the school?")]
        [Display(Order = 60)]
        [DefaultValue(true)]
		public bool Sun { get; set; } = true;

        [DisplayName("Daytime Music(Inside School/Phase 2): Sun by MineFormer")]
        [Category("Music")]
        [Description("Enable Sun as the daytime music inside the school?")]
        [Display(Order = 61)]
        [DefaultValue(false)]
        public bool SunMForm { get; set; } = true;

        [DisplayName("Daytime Music(Inside School/Phase 2): Sun")]
        [Category("Music")]
        [Description("Enable Sun (P3P) as the daytime music inside the school?")]
        [Display(Order = 63)]
        [DefaultValue(false)]
        public bool SunP3P { get; set; } = true;

        [DisplayName("Final Battle with NYX: Soul Phrase Final Battle by Karma")]
		[Category("Music")]
		[Description("Enable Soul Phrase as the music played during the battle with Nyx?")]
        [Display(Order = 76)]
        [DefaultValue(false)]
		public bool SoulPK { get; set; } = true;

		[DisplayName("Final Battle with NYX: Burn my dread Final Battle")]
		[Category("Music")]
		[Description("Enable Burn my dread as the music played during the battle with Nyx?")]
        [Display(Order = 75)]
        [DefaultValue(true)]
		public bool BMD { get; set; } = true;

		[DisplayName("Boss Battles: Master of Shadow -Reload")]
		[Category("Music")]
		[Description("Enable Master of Shadow -Reload to be the music played during boss battles?")]
        [Display(Order = 45)]
		[DefaultValue(false)]
		public bool BMS { get; set; } = true;

		[DisplayName("Boss Battles: Master of Shadow Fate Mix by Mosq")]
		[Category("Music")]
		[Description("Enable Master of Shadow Fate Mix to be the music played during boss battles?")]
        [Display(Order = 46)]
		[DefaultValue(true)]
		public bool BMSF { get; set; } = true;

        // Commented out for now but whenever new social link music is added, uncomment this (and change the file/folder names accordingly too)
        //[DisplayName("Social Link Events: Tender Feelings")]
        //[Category("Music")]
        //[Description("Enable Tender Feelings (P3P) to be the music played during social link events?")]
        //[DefaultValue(false)]
        //[Display(Order = 93)]
        //public bool TenderFeelings { get; set; } = true;

        [DisplayName("Gendered Audio")]
		[Category("Voice")]
		[Description("Enable Gio's Gendered Audio?")]
        [Display(Order = 96)]
		[DefaultValue(false)]
		public bool bluehairandpronounce { get; set; } = true;

		[DisplayName("Mail Icon: Outer Color")]
        [Category("Ui Colors")]
        [Display(Order = 200)]
        public ConfigColor MailIconOuterCircleColorEx { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Mail Icon: Inner Color")]
        [Category("Ui Colors")]
        [Display(Order = 201)]
        public ConfigColor MailIconInnerCircleColorEx { get; set; } = ConfigColor.MailIconInnerColor;

        [DisplayName("Camp: High Color")]
        [Category("Ui Colors")]
        [Display(Order = 202)]
        public ConfigColor CampHighColor { get; set; } = ConfigColor.CampBgColor;

        [DisplayName("Camp: High Color Gradation")]
        [Category("Ui Colors")]
        [Display(Order = 203)]
        public ConfigColor CampHighColorGradation { get; set; } = ConfigColor.CampBgColor;

        [DisplayName("Camp: Middle Color")]
        [Category("Ui Colors")]
        [Display(Order = 204)]
        public ConfigColor CampMiddleColor { get; set; } = ConfigColor.CampBgColor;

        [DisplayName("Camp: Low Color")]
        [Category("Ui Colors")]
        [Display(Order = 205)]
        public ConfigColor CampLowColor { get; set; } = ConfigColor.CampBgColor;

        [DisplayName("Date Time Panel: Top Text Color")]
        [Category("Ui Colors")]
        [Display(Order = 206)]
        public ConfigColor DateTimePanelTopTextColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Date Time Panel: Bottom Text Color")]
        [Category("Ui Colors")]
        [Display(Order = 207)]
        public ConfigColor DateTimePanelBottomTextColor { get; set; } = ConfigColor.MidColor;

        [DisplayName("Date Time Panel: Water Color")]
        [Category("Ui Colors")]
        [Display(Order = 208)]
        public ConfigColor DateTimePanelWaterColor { get; set; } = ConfigColor.DateTimeWaterColor;

        [DisplayName("Text Box: Back Fill Color")]
        [Category("Ui Colors")]
        [Display(Order = 209)]
        public ConfigColor TextBoxBackFillColor { get; set; } = ConfigColor.TextBoxBackFillColor;

        [DisplayName("Text Box: Front Fill Color")]
        [Category("Ui Colors")]
        [Display(Order = 210)]
        public ConfigColor TextBoxFrontFillColor { get; set; } = ConfigColor.TextBoxFrontFillColor;

        [DisplayName("Text Box: Front Fill Border Color")]
        [Category("Ui Colors")]
        [Display(Order = 211)]
        public ConfigColor TextBoxFrontBorderColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Text Box: Speaker Name Triangle Color")]
        [Category("Ui Colors")]
        [Display(Order = 212)]
        public ConfigColor TextBoxSpeakerNameTriangle { get; set; } = ConfigColor.TextBoxSpeakerNameTriangle;

        [DisplayName("Text Box: Speaker Name")]
        [Category("Ui Colors")]
        [Display(Order = 213)]
        public ConfigColor TextBoxSpeakerName { get; set; } = ConfigColor.LightColor;

        [DisplayName("Text Box: Left Haze Color")]
        [Category("Ui Colors")]
        [Display(Order = 214)]
        public ConfigColor TextBoxLeftHaze { get; set; } = ConfigColor.TextBoxLeftHaze;

        [DisplayName("Mind Window: Outer Border")]
        [Category("Ui Colors")]
        [Display(Order = 215)]
        public ConfigColor MindWindowOuterBorderNew { get; set; } = UICommon.MindWindowOuterBorder;

        [DisplayName("Mind Window: Inner Color")]
        [Category("Ui Colors")]
        [Display(Order = 216)]
        public ConfigColor MindWindowInnerColorNew { get; set; } = UICommon.MindWindowInnerColor;

        /*[DisplayName("Mind Window: Outer Haze")] i'm hardcoding this it's broken for too many people lol
         * [Category("Ui Colors")]
         * [Display(Order = 217)]
        public ConfigColor MindWindowOuterHazeEx { get; set; } = new ConfigColor(ConfigColor.MellodiColorLight3.R, ConfigColor.MellodiColorLight3.G, ConfigColor.MellodiColorLight3.B, 128);
        */

        [DisplayName("Mind Window: Background Dots")]
        [Category("Ui Colors")]
        [Display(Order = 218)]
        public ConfigColor MindWindowBgDotsNew { get; set; } = UICommon.MindWindowOuterBorder;

        [DisplayName("Minimap: Place Name Background Color")]
        [Category("Ui Colors")]
        [Display(Order = 219)]
        public ConfigColor MinimapPlaceNameBgColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Interact Prompt: Back Box Color")]
        [Category("Ui Colors")]
        [Display(Order = 220)]
        public ConfigColor CheckPromptBackBoxColorNew { get; set; } = UICommon.CheckPromptBgBox;

        [DisplayName("Interact Prompt: Front Box Base Color")]
        [Category("Ui Colors")]
        [Display(Order = 221)]
        public ConfigColor CheckPromptFrontBoxColorNew { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Interact Prompt: Front Box Highlight Color")]
        [Category("Ui Colors")]
        [Display(Order = 222)]
        public ConfigColor CheckPromptFrontBoxColorHighNew { get; set; } = UICommon.CheckPromptFgBox;

        [DisplayName("Bustup: Shadow Color")]
        [Category("Ui Colors")]
        [Display(Order = 223)]
        public ConfigColor BustupShadowColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Camp: Menu Item Color 1 (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 224)]
        public ConfigColor CampMenuItemColor1 { get; set; } = ConfigColor.CampMenuItemColor1;

        [DisplayName("Camp: Menu Item Color 2 (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 225)]
        public ConfigColor CampMenuItemColor2 { get; set; } = ConfigColor.CampMenuItemColor2;

        [DisplayName("Camp: Menu Item Color 3 (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 226)]
        public ConfigColor CampMenuItemColor3 { get; set; } = ConfigColor.CampMenuItemColor3;

        [DisplayName("Camp: Menu Item Color No Select (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 227)]
        public ConfigColor CampMenuItemColorNoSel { get; set; } = ConfigColor.CampMenuItemColorNoSel;

        [DisplayName("Camp: Skill Text Color")]
        [Category("Ui Colors")]
        [Display(Order = 228)]
        public ConfigColor CampSkillTextColor { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Camp: Skill Text Color No Select")]
        [Category("Ui Colors")]
        [Display(Order = 229)]
        public ConfigColor CampSkillTextColorNoSel { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Camp: Skill Text Color Current Select")]
        [Category("Ui Colors")]
        [Display(Order = 230)]
        public ConfigColor CampSkillTextColorCurrSel { get; set; } = ConfigColor.MellodiColorDark2;

        [DisplayName("Social Stats: Academics Circle Color")]
        [Category("Ui Colors")]
        [Display(Order = 231)]
        public ConfigColor SocialStatsCircleAcademicsColor { get; set; } = ConfigColor.SocialStatsAcademics;

        [DisplayName("Social Stats: Charm Circle Color")]
        [Category("Ui Colors")]
        [Display(Order = 232)]
        public ConfigColor SocialStatsCircleCharmColor { get; set; } = ConfigColor.SocialStatsCharm;

        [DisplayName("Social Stats: Courage Circle Color")]
        [Category("Ui Colors")]
        [Display(Order = 233)]
        public ConfigColor SocialStatsCircleCourageColor { get; set; } = ConfigColor.SocialStatsCourage;

        [DisplayName("Camp: Item Menu Character Top Color (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 234)]
        public ConfigColor CampItemMenuCharacterTopColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Camp: Item Menu Character Bottom Color (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 235)]
        public ConfigColor CampItemMenuCharacterBottomColor { get; set; } = ConfigColor.DarkColor;

        [DisplayName("Assist Message Box: Background Color")]
        [Category("Ui Colors")]
        [Display(Order = 236)]
        public ConfigColor MsgAssistBgColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Town Map: Border Color")]
        [Category("Ui Colors")]
        [Display(Order = 237)]
        public ConfigColor TownMapBorderColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Town Map: Text Color")]
        [Category("Ui Colors")]
        [Display(Order = 238)]
        public ConfigColor TownMapTextColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Camp Social Link: Light Color")]
        [Category("Ui Colors")]
        [Display(Order = 239)]
        public ConfigColor CampSocialLinkLight { get; set; } = ConfigColor.MellodiColorLight2;

        [DisplayName("Camp Social Link: Dark Color")]
        [Category("Ui Colors")]
        [Display(Order = 240)]
        public ConfigColor CampSocialLinkDark { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Camp Social Link: Desc BG")]
        [Category("Ui Colors")]
        [Display(Order = 241)]
        public ConfigColor CampSocialLinkDetailDescBg { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Camp Social Link: Desc Triangle")]
        [Category("Ui Colors")]
        [Display(Order = 242)]
        public ConfigColor CampSocialLinkDetailDescTriangle { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Camp Social Link: Desc Name")]
        [Category("Ui Colors")]
        [Display(Order = 243)]
        public ConfigColor CampSocialLinkDetailDescName { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Arcana Card Fall Color 1")]
        [Category("Ui Colors")]
        [Display(Order = 244)]
        public ConfigColor ArcanaCardFallColor1 { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Arcana Card Fall Color 2")]
        [Category("Ui Colors")]
        [Display(Order = 245)]
        public ConfigColor ArcanaCardFallColor2 { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Arcana Card Fall Color 3")]
        [Category("Ui Colors")]
        [Display(Order = 246)]
        public ConfigColor ArcanaCardFallColor3 { get; set; } = ConfigColor.MellodiColorMid3;

        [DisplayName("Camp Calendar: Sunday Color (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 247)]
        public ConfigColor CampCalendarSundayColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Camp Calendar: Sunday Color 2 (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 248)]
        public ConfigColor CampCalendarSundayColor2 { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Camp Calendar: Text Color (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 249)]
        public ConfigColor CampCalendarTextColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Camp Calendar: Highlight Color (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 250)]
        public ConfigColor CampCalendarHighlightColor { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Camp Calendar: Part Time Job Background")]
        [Category("Ui Colors")]
        [Display(Order = 251)]
        public ConfigColor CampCalendarPartTimeJobBackground { get; set; } = ConfigColor.MellodiColorDark1;

        [DisplayName("Party Panel Background Color")]
        [Category("Ui Colors")]
        [Display(Order = 252)]
        public ConfigColor PartyPanelBgColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Button Prompt Fill Color (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 253)]
        public ConfigColor ButtonPromptHighlightColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Button Prompt Triangle Color")]
        [Category("Ui Colors")]
        [Display(Order = 254)]
        public ConfigColor ButtonPromptTriangleColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Back Log Blackboard Color")]
        [Category("Ui Colors")]
        [Display(Order = 255)]
        public ConfigColor BackLogBlackboardColor { get; set; } = ConfigColor.BackLogBlackBoard;

        [DisplayName("Back Log Haze Color")]
        [Category("Ui Colors")]
        [Display(Order = 256)]
        public ConfigColor BackLogGladationColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Back Log Blueboard Color")]
        [Category("Ui Colors")]
        [Display(Order = 257)]
        public ConfigColor BackLogBlueboardColorEx { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Back Log Title Color (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 258)]
        public ConfigColor BackLogTitleColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Back Log Text/Icon Color Selected")]
        [Category("Ui Colors")]
        [Display(Order = 259)]
        public ConfigColor BackLogTexColorSelected { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Back Log Text/Icon Color Unselected")]
        [Category("Ui Colors")]
        [Display(Order = 260)]
        public ConfigColor BackLogTexColorUnselectedEx { get; set; } = ConfigColor.MellodiColorDark1;

        [DisplayName("Location Select Background Color")]
        [Category("Ui Colors")]
        [Display(Order = 261)]
        public ConfigColor LocationSelectBgColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Location Select Marker Color")]
        [Category("Ui Colors")]
        [Display(Order = 262)]
        public ConfigColor LocationSelectMarkerColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Location Select Selected Item Color (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 263)]
        public ConfigColor LocationSelectSelColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Time Skip Color")]
        [Category("Ui Colors")]
        [Display(Order = 264)]
        public ConfigColor TimeSkipColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Next Day Band Color")]
        [Category("Ui Colors")]
        [Display(Order = 265)]
        public ConfigColor NextDayBandColor { get; set; } = ConfigColor.MellodiColorDark1;

        [DisplayName("Next Day Text Color")]
        [Category("Ui Colors")]
        [Display(Order = 266)]
        public ConfigColor NextDayTextColor { get; set; } = ConfigColor.MellodiColorMid3;

        [DisplayName("Next Day Moon Shadow Color")]
        [Category("Ui Colors")]
        [Display(Order = 267)]
        public ConfigColor NextDayMoonShadowColor { get; set; } = ConfigColor.DayChangeMoonShadow;

        [DisplayName("Next Day Ripple")]
        [Category("Ui Colors")]
        [Display(Order = 268)]
        public ConfigColor NextDayRipple { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Shop Payment Color")]
        [Category("Ui Colors")]
        [Display(Order = 269)]
        public ConfigColor ShopPayColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Shop Fill Color")]
        [Category("Ui Colors")]
        [Display(Order = 270)]
        public ConfigColor ShopFillColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Shop Shadow Color")]
        [Category("Ui Colors")]
        [Display(Order = 271)]
        public ConfigColor ShopShadowColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Shop Payment Unselect Color")]
        [Category("Ui Colors")]
        [Display(Order = 272)]
        public ConfigColor ShopPayUnselColor { get; set; } = ConfigColor.MellodiColorMid4;

        [DisplayName("Get Item Background Mask Color")]
        [Category("Ui Colors")]
        [Display(Order = 273)]
        public ConfigColor GetItemBgMaskColor { get; set; } = ConfigColor.GetItemFillMask;

        [DisplayName("Get Item Background Color")]
        [Category("Ui Colors")]
        [Display(Order = 274)]
        public ConfigColor GetItemBgColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Get Item Got Text Color")]
        [Category("Ui Colors")]
        [Display(Order = 275)]
        public ConfigColor GetItemGotTextColor { get; set; } = ConfigColor.GetItemGotTextColor;

        [DisplayName("Get Item Got Item Count Background")]
        [Category("Ui Colors")]
        [Display(Order = 276)]
        public ConfigColor GetItemCountBgColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Mind Select: Selected Text Color")]
        [Category("Ui Colors")]
        [Display(Order = 277)]
        public ConfigColor MindSelActiveTextColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Mind Select Window Fill (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 278)]
        public ConfigColor MindSelWindowFill { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Mind Select Window Border (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 279)]
        public ConfigColor MindSelWindowBorder { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Mind Select Dot Color (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 280)]
        public ConfigColor MindSelectDotColor { get; set; } = ConfigColor.MindSelectDotColor;

        [DisplayName("Generic Select Character Backplate Color ")]
        [Category("Ui Colors")]
        [Display(Order = 281)]
        public ConfigColor GenericSelectCharacterBackplate { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Generic Select List Color Morning")]
        [Category("Ui Colors")]
        [Display(Order = 282)]
        public ConfigColor GenericSelectListColorMorning { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Generic Select List Color After School")]
        [Category("Ui Colors")]
        [Display(Order = 283)]
        public ConfigColor GenericSelectListColorAfterSchool { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Generic Select List Color Night")]
        [Category("Ui Colors")]
        [Display(Order = 284)]
        public ConfigColor GenericSelectListColorNight { get; set; } = ConfigColor.MellodiColorMid3;

        [DisplayName("Generic Select Title Color")]
        [Category("Ui Colors")]
        [Display(Order = 285)]
        public ConfigColor GenericSelectTitle { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Generic Select Character Shadow (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 286)]
        public ConfigColor GenericSelectCharacterShadow { get; set; } = ConfigColor.MellodiColorMid4;

        [DisplayName("Message Box Select Text Color")]
        [Category("Ui Colors")]
        [Display(Order = 287)]
        public ConfigColor MsgSimpleSelectTextColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Message Box Select Box Shadow Color")]
        [Category("Ui Colors")]
        [Display(Order = 288)]
        public ConfigColor MsgSimpleSelectBoxShadow { get; set; } = ConfigColor.MellodiColorDark1;

        [DisplayName("Message Box Shadow Color")]
        [Category("Ui Colors")]
        [Display(Order = 289)]
        public ConfigColor MsgSimpleSelectShadowEx { get; set; } = ConfigColor.TextBoxFrontFillColor;

        [DisplayName("Message Box Border Color")]
        [Category("Ui Colors")]
        [Display(Order = 290)]
        public ConfigColor MsgSimpleSelectBorderColorEx { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("System Message Light Color (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 291)]
        public ConfigColor MsgSimpleSystemLightColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("System Message Dark Color")]
        [Category("Ui Colors")]
        [Display(Order = 292)]
        public ConfigColor MsgSimpleSystemDarkColor { get; set; } = ConfigColor.MsgWindowSystemDark;

        [DisplayName("System Message Dark Haze Color")]
        [Category("Ui Colors")]
        [Display(Order = 293)]
        public ConfigColor MsgSimpleSystemGradationColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Persona Status Skill List Background Top Left")]
        [Category("Ui Colors")]
        [Display(Order = 294)]
        public ConfigColor PersonaStatusSkillListBg { get; set; } = ConfigColor.PersonaStatusSkillListBg;

        [DisplayName("Persona Status Skill List Background Lower Line")]
        [Category("Ui Colors")]
        [Display(Order = 295)]
        public ConfigColor PersonaStatusSkillListBg2 { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Persona Status Skill List Checkerboard")]
        [Category("Ui Colors")]
        [Display(Order = 296)]
        public ConfigColor PersonaStatusSkillListCheckboardAlt { get; set; } = ConfigColor.PersonaStatusSkillListCheckboardAlt;

        [DisplayName("Persona Status Skill List Next Skill Color")]
        [Category("Ui Colors")]
        [Display(Order = 297)]
        public ConfigColor PersonaSkillListNextSkillColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Persona Status Skill List Level Color")]
        [Category("Ui Colors")]
        [Display(Order = 298)]
        public ConfigColor PersonaSkillListNextLevelColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Persona Status Skill List Next Skill Name Color")]
        [Category("Ui Colors")]
        [Display(Order = 299)]
        public ConfigColor PersonaSkillListNextSkillInfoName { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Persona Status Info Color")]
        [Category("Ui Colors")]
        [Display(Order = 300)]
        public ConfigColor PersonaStatusPlayerInfoColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Persona Status Info Selected Persona Color 1")]
        [Category("Ui Colors")]
        [Display(Order = 301)]
        public ConfigColor PersonaStatusInfoSelPersonaColor1 { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Persona Status Info Selected Persona Color 2")]
        [Category("Ui Colors")]
        [Display(Order = 302)]
        public ConfigColor PersonaStatusInfoSelPersonaColor2 { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Persona Status Param Background Color")]
        [Category("Ui Colors")]
        [Display(Order = 303)]
        public ConfigColor PersonaStatusParamColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Persona Status Lore Title Color")]
        [Category("Ui Colors")]
        [Display(Order = 304)]
        public ConfigColor PersonaStatusCommentaryTitleColor { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Persona Status Base Stat Color")]
        [Category("Ui Colors")]
        [Display(Order = 305)]
        public ConfigColor PersonaStatusBaseStat { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Persona Status Skill Affinity Outline Color (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 306)]
        public ConfigColor PersonaStatusAttributeOutline { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Network: Daily Action Sticky Note Background Color 1")]
        [Category("Ui Colors")]
        [Display(Order = 307)]
        public ConfigColor NetworkDailyActionStickyNoteBgColor1 { get; set; } = UICommon.NetStickyNoteBgColor1;

        [DisplayName("Network: Daily Action Sticky Note Background Color 2")]
        [Category("Ui Colors")]
        [Display(Order = 308)]
        public ConfigColor NetworkDailyActionStickyNoteBgColor2 { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Network: Daily Action Sticky Note Dotpoint Color 1")]
        [Category("Ui Colors")]
        [Display(Order = 309)]
        public ConfigColor NetworkDailyActionStickyNoteDotColor1 { get; set; } = ConfigColor.MellodiColorLight2;

        [DisplayName("Network: Daily Action Sticky Note Dotpoint Color 2")]
        [Category("Ui Colors")]
        [Display(Order = 310)]
        public ConfigColor NetworkDailyActionStickyNoteDotColor2 { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Network: Daily Action Sticky Note Text Color 1")]
        [Category("Ui Colors")]
        [Display(Order = 311)]
        public ConfigColor NetworkDailyActionStickyNoteTextColor1 { get; set; } = UICommon.NetStickyNoteTextColor1;

        [DisplayName("Network: Daily Action Sticky Note Text Color 2")]
        [Category("Ui Colors")]
        [Display(Order = 312)]
        public ConfigColor NetworkDailyActionStickyNoteTextColor2 { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Network: Daily Action Blue Background Color")]
        [Category("Ui Colors")]
        [Display(Order = 313)]
        public ConfigColor NetworkDailyActionBlueBgColor { get; set; } = ConfigColor.MellodiColorMid4;

        [DisplayName("Network: Daily Action Network Icon Color")]
        [Category("Ui Colors")]
        [Display(Order = 314)]
        public ConfigColor NetworkDailyActionNetworkIcon { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Simple Shop: Info Color")]
        [Category("Ui Colors")]
        [Display(Order = 315)]
        public ConfigColor SimpleShopInfoColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Cutin: Outer Highlight Color")]
        [Category("Ui Colors")]
        [Display(Order = 316)]
        public ConfigColor CutinOuterHighlight { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Cutin: Emotion Gradient Color")]
        [Category("Ui Colors")]
        [Display(Order = 317)]
        public ConfigColor CutinEmotionGradient { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Cutin: Emotion Tint Color")]
        [Category("Ui Colors")]
        [Display(Order = 318)]
        public ConfigColor CutinEmotionTint { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Title Menu: Select Rectangle Color")]
        [Category("Ui Colors")]
        [Display(Order = 319)]
        public ConfigColor TitleMenuSelRectColor { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Localization Staff Roll: Header Color (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 320)]
        public ConfigColor LocalStaffRollHeader { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Difficulty Selection Background")]
        [Category("Ui Colors")]
        [Display(Order = 321)]
        public ConfigColor DifficultySelectBgColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Wipe Background")]
        [Category("Ui Colors")]
        [Display(Order = 322)]
        public ConfigColor WipeBgColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Camp Equip: Item Stat Value Padding Color")]
        [Category("Ui Colors")]
        [Display(Order = 323)]
        public ConfigColor CampItemStatValuePadColor { get; set; } = ConfigColor.MellodiColorDark1;

        [DisplayName("Camp Equip: Item Stat Value Padding Color")]
        [Category("Ui Colors")]
        [Display(Order = 324)]
        public ConfigColor CampItemStatValueValColor { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Camp Equip: Overview List Type Color")]
        [Category("Ui Colors")]
        [Display(Order = 325)]
        public ConfigColor CampEquipOverviewListType { get; set; } = ConfigColor.MellodiColorMid3;

        [DisplayName("Camp Persona: Arcana Phrase Color (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 326)]
        public ConfigColor CampPersonaArcanaPhraseColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Camp Persona: Name Color")]
        [Category("Ui Colors")]
        [Display(Order = 327)]
        public ConfigColor CampPersonaNameColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Camp Persona: Arcana Background Color")]
        [Category("Ui Colors")]
        [Display(Order = 328)]
        public ConfigColor CampPersonaArcanaBgColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Camp Status: Kotone Line Color")]
        [Category("Ui Colors")]
        [Display(Order = 329)]
        public ConfigColor CampStatusKotoneLineColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Camp Status: Inactive Party Member Background (Tartarus)")]
        [Category("Ui Colors")]
        [Display(Order = 330)]
        public ConfigColor CampStatusInactiveMemberBgTartarus { get; set; } = UICommon.InactivePartyMemberTartarusBG;

        [DisplayName("Camp Status: Inactive Member Details Pale Pink (Tartarus)")]
        [Category("Ui Colors")]
        [Display(Order = 331)]
        public ConfigColor CampStatusInactiveMemberDetailsPalePinkTartarus { get; set; } = UICommon.InactivePartyMemberPalePink;

        [DisplayName("Camp Status: Inactive Member Details Dark Pink (Tartarus)")]
        [Category("Ui Colors")]
        [Display(Order = 332)]
        public ConfigColor CampStatusInactiveMemberDetailsDarkPinkTartarus { get; set; } = UICommon.InactivePartyMemberDarkPink;

        [DisplayName("Camp Status: Inactive Member HP Bar (Tartarus)")]
        [Category("Ui Colors")]
        [Display(Order = 333)]
        public ConfigColor CampStatusInactiveMemberHPBarTartarus { get; set; } = UICommon.InactivePartyMemberHPColor;

        [DisplayName("Town Map: Location Details Background Tint")]
        [Category("Ui Colors")]
        [Display(Order = 334)]
        public ConfigColor TownMapLocationDetailsBgTint { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Town Map: Location Details Top Left Bg")]
        [Category("Ui Colors")]
        [Display(Order = 335)]
        public ConfigColor TownMapLocationDetailsTopLeftBg { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Town Map: Location Details Top Left Text")]
        [Category("Ui Colors")]
        [Display(Order = 336)]
        public ConfigColor TownMapLocationDetailsTopLeftText { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Town Map: Selected Marker Outline")]
        [Category("Ui Colors")]
        [Display(Order = 337)]
        public ConfigColor TownMapSelectedMarkerOutline { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Social Stats: Stats Up Text")]
        [Category("Ui Colors")]
        [Display(Order = 338)]
        public ConfigColor SocialStatsUpText { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Social Stats: Stat Up Pulse Circle Color")]
        [Category("Ui Colors")]
        [Display(Order = 339)]
        public ConfigColor SocialStatsPulseCircleColorMain { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Social Stats: Stat Up Pulse Circle Fade")]
        [Category("Ui Colors")]
        [Display(Order = 340)]
        public ConfigColor SocialStatsPulseCircleColorFade { get; set; } = ConfigColor.MellodiColorMid1;

        [DisplayName("Assist Message Box: Text Background")]
        [Category("Ui Colors")]
        [Display(Order = 341)]
        public ConfigColor MsgAssistTextBgColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Location Select: Map Background Color")]
        [Category("Ui Colors")]
        [Display(Order = 342)]
        public ConfigColor LocationSelMapBg { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Location Select: Map Label Color")]
        [Category("Ui Colors")]
        [Display(Order = 343)]
        public ConfigColor LocationSelMapLabel { get; set; } = UICommon.LocationSelectMapLabel;

        [DisplayName("System Message Picture Border Color (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 344)]
        public ConfigColor MsgSystemPicBorderColor { get; set; } = ConfigColor.MellodiColorDark1;

        [DisplayName("Tutorial List Entry Color (Requires Restart)")]
        [Category("Ui Colors")]
        [Display(Order = 345)]
        public ConfigColor TutorialListEntryColor { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Tutorial List Background Color")]
        [Category("Ui Colors")]
        [Display(Order = 346)]
        public ConfigColor TutorialBgColor { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Missing Person: Selected Person \"Last Sighted\" Color")]
        [Category("Ui Colors")]
        [Display(Order = 347)]
        public ConfigColor MissingLastSighted { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Missing Person: Page Background")]
        [Category("Ui Colors")]
        [Display(Order = 348)]
        public ConfigColor MissingPageBg { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Missing Person: Light Text Color")]
        [Category("Ui Colors")]
        [Display(Order = 349)]
        public ConfigColor MissingTextLight { get; set; } = ConfigColor.MellodiColorLight3;

        [DisplayName("Missing Person: Dark Text Color")]
        [Category("Ui Colors")]
        [Display(Order = 350)]
        public ConfigColor MissingTextDark { get; set; } = ConfigColor.MellodiColorDark3;

        [DisplayName("Missing Person: Sort by Triangle")]
        [Category("Ui Colors")]
        [Display(Order = 351)]
        public ConfigColor MissingSortTriangle { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Missing Person: Sort by Triangle")]
        public ConfigColor RequestSortTriangle { get; set; } = ConfigColor.MellodiColorMid2;

        [DisplayName("Missing Person: Shadows Femc and Chairs in Detail Color")]
        public ConfigColor MissingDetailFemcChairsShadow { get; set; } = new ConfigColor(0x36, 0x0c, 0x18, 0xFF);

        [DisplayName("Request: Back Card Color")]
        public ConfigColor RequestBackCard { get; set; } = new ConfigColor(0x60, 0x00, 0x21, 0xFF);

        [DisplayName("Request: Back Squares Color")]
        public ConfigColor RequestBackSquares { get; set; } = new ConfigColor(0x38, 0x00, 0x10, 0xFF);

        [DisplayName("Request: Back Card Detail Color")]
        public ConfigColor RequestBackCardDetail { get; set; } = new ConfigColor(0x2e, 0x09, 0x17, 0xFF);

        [DisplayName("Request: Back Card Detail Right Down Solid Color")]
        public ConfigColor RequestBackCardRightDownDetail { get; set; } = new ConfigColor(0x5d, 0x00, 0x20, 0xFF);

        [DisplayName("Request: Shadows Femc and Chairs in Detail Color")] 
        public ConfigColor RequestDetailFemcChairsShadow { get; set; } = new ConfigColor(0x48, 0x11, 0x23, 0xFF);

        [DisplayName("Request: 'Task' Font Color")]
        public ConfigColor RequestTaskFont { get; set; } = new ConfigColor(0xFF, 0x91, 0xb0, 0xFF);

        [DisplayName("Request: Detail 'Request Details' Font Color")]
        public ConfigColor RequestDetailsFont { get; set; } = new ConfigColor(0xFD, 0x9B, 0xb7, 0xFF);

        [DisplayName("Request: Detail 'Complete' Tag Color")]
        public ConfigColor RequestDetailCompleted { get; set; } = new ConfigColor(0x43, 0x0d, 0x1b, 0xFF);

        [DisplayName("Request: Detail Background 'Complete' Tag Color")]
        public ConfigColor RequestDetailBackgroundCompleted { get; set; } = new ConfigColor(0x8c, 0x09, 0x30, 0xFF);

        [DisplayName("Request: Detail 'Earned' Tag Color")]
        public ConfigColor RequestDetailEarned { get; set; } = new ConfigColor(0xFF, 0x91, 0xb0, 0xFF);

        [DisplayName("Request: Detail Difficulty Rank Upper Part Color")]
        public ConfigColor RequestDifficultyRankUp { get; set; } = new ConfigColor(0x17, 0x03, 0x0c, 0xFF);

        [DisplayName("Request: Detail Difficulty Rank Lower Part Color")]
        public ConfigColor RequestDifficultyRankDown { get; set; } = new ConfigColor(0x41, 0x03, 0x20, 0xFF);

        [DisplayName("Request: Detail Difficulty Butterfly Indicator Color")]
        public ConfigColor RequestDifficultyIndicator { get; set; } = new ConfigColor(0x73, 0x0e, 0x38, 0xFF);

        [DisplayName("Request: Detail Difficulty Font Color")]
        public ConfigColor RequestDifficultyFont { get; set; } = new ConfigColor(0x71, 0x0d, 0x2b, 0xFF);

        [DisplayName("Request: Status Light Font and Tag Background Color")]
        public ConfigColor RequestStatusFontTagBack { get; set; } = new ConfigColor(0xfc, 0x9a, 0xb6, 0xFF);

        [DisplayName("Request: Status Tag Font Color")]
        public ConfigColor RequestStatusTagFont { get; set; } = new ConfigColor(0x68, 0x01, 0x08, 0xFF);

        [DisplayName("Request: Status Tag Underlay Color")]
        public ConfigColor RequestStatusTagUnderlay { get; set; } = new ConfigColor(0x6a, 0x00, 0x19, 0xFF);

        [DisplayName("Camp: Skill Card Sub Menu Background Color")]
        public ConfigColor CampSkillCardBackground { get; set; } = new ConfigColor(0x78, 0x68, 0x6f, 0xFF);

        [DisplayName("Camp: Skill Card Sub Menu Frame Color")]
        public ConfigColor CampSkillCardFrame { get; set; } = new ConfigColor(0x65, 0x35, 0x48, 0xFF);

        [DisplayName("Camp: Skill Card Femc Sub Menu Color")]
        public ConfigColor CampSkillCardFemc { get; set; } = new ConfigColor(0x21, 0x08, 0x12, 0xFF);

        [DisplayName("Camp: Femc Shadow Color")]
        public ConfigColor CampFemcShadow { get; set; } = UICommon.FemcShadowColor;

        [DisplayName("Camp: Highlighted selection color high")]
        public ConfigColor CampHighlightedColor { get; set; } = ConfigColor.Blue;

        [DisplayName("Camp: Highlighted selection color lower high")]
        public ConfigColor CampHighlightedLowerColor { get; set; } = new ConfigColor(0x00, 0x00, 0xEE, 0xFF);

        [DisplayName("Camp: Highlighted selection color middle (involves highlighted party member with lower high)")]
        public ConfigColor CampHighlightedMidColor { get; set; } = new ConfigColor(0x00, 0x00, 0x6A, 0xFF);

        [DisplayName("Camp: Social Link Arcana selection color")]
        public ConfigColor CampSocialLinkArcanaHighlightedColor { get; set; } = new ConfigColor(0x6d, 0x03, 0x0d, 0x7F);

        [DisplayName("Camp: System falling words starting color")]
        public ConfigColor CampSystemStartFallingWordsColor { get; set; } = new ConfigColor(0x2B, 0x00, 0x00, 0xFF);

        [DisplayName("Camp: System falling words end color")]
        public ConfigColor CampSystemEndFallingWordsColor { get; set; } = new ConfigColor(0xA3, 0x20, 0x26, 0xFF);

        [DisplayName("Quest: Shadows Femc and Chairs Color")]
        public ConfigColor QuestFemcChairsShadow { get; set; } = new ConfigColor(0x58, 0x0F, 0x21, 0xFF);

        [DisplayName("Quest: Request/Missing Person Toggler Background Color")]
        public ConfigColor QuestToggler { get; set; } = new ConfigColor(0x2e, 0x09, 0x17, 0xFF);

        [DisplayName("Persona Status: Highlighted selection color")]
        public ConfigColor PersonaStatusHighlightedColor { get; set; } = new ConfigColor(0x29, 0x00, 0xEA, 0xFF);

        [DisplayName("Persona Status: Skill Card Skill Background color")]
        public ConfigColor SkillCardSkillBg { get; set; } = new ConfigColor(0x66, 0x2b, 0x47, 0xFF);

        [DisplayName("Persona Status: Skill Description Main Background color")]
        public ConfigColor SkillDescriptionMainBg { get; set; } = new ConfigColor(0x57, 0x21, 0x3D, 0xFF);

        [DisplayName("Persona Status: Skill Description Corner and Title Background color")]
        public ConfigColor SkillDescriptionCornerBg { get; set; } = new ConfigColor(0x7D, 0x4D, 0x66, 0xFF);

        [DisplayName("Persona Status: --NONE-- skill color")]
        public ConfigColor NoneSkillColor { get; set; } = new ConfigColor(0x9F, 0x83, 0x8C, 0xFF);

        [DisplayName("Persona Status: Selected skill font color")]
        public ConfigColor SelectedSkillFontColor { get; set; } = ConfigColor.PersonaStatusSkillListBg;

        [DisplayName("Persona Status: Skill swap selected skill shadow font color")]
        public ConfigColor SwapSkillShadowSelectedFontColor { get; set; } = new ConfigColor(0xFE, 0x9B, 0xB8, 0xFF);

        [DisplayName("Persona Status: Skill swap unselected skill background color")]
        public ConfigColor SwapSkillUnselectedFontColor { get; set; } = new ConfigColor(0x9E, 0x3C, 0x5E, 0xFF);

        [DisplayName("Persona Status: Skill swap unselected skill background color")]
        public ConfigColor SwapSkillUnselectedBgColor { get; set; } = new ConfigColor(0xFD, 0x75, 0x9B, 0xFF);

        [DisplayName("Persona Status: Inheritable skill tick color")]
        public ConfigColor InheritableSkillTick { get; set; } = new ConfigColor(0xCC, 0x7C, 0x93, 0xFF);

        [DisplayName("Persona Status: Inheritable skill tick tag background color")]
        public ConfigColor InheritableSkillTickBg { get; set; } = new ConfigColor(0x71, 0x36, 0x4D, 0xFF);
        
        [DisplayName("Persona Status: Next skill left zero color")]
        public ConfigColor NextSkillZero { get; set; } = new ConfigColor(0x99, 0x53, 0x64, 0xFF);

        [DisplayName("Persona Status: Next skill outter outline question mark color")]
        public ConfigColor NextSkillOutterOutlineColor { get; set; } = new ConfigColor(0x59, 0x02, 0x23, 0xFF);

        [DisplayName("Persona Status: Next skill inner outline question mark color")]
        public ConfigColor NextSkillInnerOutlineColor { get; set; } = new ConfigColor(0xFD, 0x9B, 0xB7, 0xFF);

        [DisplayName("Persona Status: Persona shadow when selecting inheritance skills/high level persona")]
        public ConfigColor PersonaFusionShadow { get; set; } = new ConfigColor(0x30, 0x10, 0x27, 0xFF);

        [DisplayName("Persona Status: Social Link Bonus color when choosing inheritance skills")]
        public ConfigColor PersonaSocialLinkInheritance { get; set; } = new ConfigColor(0x6E, 0x03, 0x0A, 0xFF);

        [DisplayName("Persona Status: Mutation animation strip colors")]
        public ConfigColor MutationStripColor { get; set; } = new ConfigColor(0xC6, 0x00, 0x35, 0xFF);

        [DisplayName("Persona Status: Fusion level up new learned skill info animation background color")]
        public ConfigColor PersonaLvlUpSkillListNextSkillColor { get; set; } = new ConfigColor(0xFF, 0x7D, 0xA9, 0xFF);

        [DisplayName("Persona Status: Fusion top left corner numbers/result color")]
        public ConfigColor FusionTopRightIndicatorColors { get; set; } = ConfigColor.MellodiColorLight1;

        [DisplayName("Battle: Squares colors from battle result animation")]
        public ConfigColor BtlResultSquaresColor { get; set; } = new ConfigColor(0xD1, 0x00, 0x3F, 0xFF);

        [DisplayName("Enable Mail Icon")]
        [Category("UI Components")]
        [Display(Order = 150)]
        [DefaultValue(true)]
        public bool EnableMailIcon { get; set; } = true;

        [DisplayName("Enable Date Time Panel")]
        [Category("UI Components")]
        [Display(Order = 151)]
        [DefaultValue(true)]
        public bool EnableDateTimePanel { get; set; } = true;

        [DisplayName("Enable Camp Menu")]
        [Category("UI Components")]
        [Display(Order = 152)]
        [DefaultValue(true)]
        public bool EnableCampMenu { get; set; } = true;

        [DisplayName("Enable Standard Message Box")]
        [Category("UI Components")]
        [Display(Order = 153)]
        [DefaultValue(true)]
        public bool EnableTextbox { get; set; } = true;

        [DisplayName("Enable Mind Message Box")]
        [Category("UI Components")]
        [Display(Order = 154)]
        [DefaultValue(true)]
        public bool EnableMindMessageBox { get; set; } = true;

        [DisplayName("Enable Interact Prompt")]
        [Category("UI Components")]
        [Display(Order = 155)]
        [DefaultValue(true)]
        public bool EnableInteractPrompt { get; set; } = true;

        [DisplayName("Enable Minimap")]
        [Category("UI Components")]
        [Display(Order = 156)]
        [DefaultValue(true)]
        public bool EnableMinimap { get; set; } = true;

        [DisplayName("Enable Bustup")]
        [Category("UI Components")]
        [Display(Order = 157)]
        [DefaultValue(true)]
        public bool EnableBustup { get; set; } = true;

        [DisplayName("Enable MessageScript")]
        [Category("UI Components")]
        [Display(Order = 158)]
        [DefaultValue(true)]
        public bool EnableMessageScript { get; set; } = true;

        [DisplayName("Enable Town Map")]
        [Category("UI Components")]
        [Display(Order = 159)]
        [DefaultValue(true)]
        public bool EnableTownMap { get; set; } = true;

        [DisplayName("Enable Party Panel")]
        [Category("UI Components")]
        [Display(Order = 160)]
        [DefaultValue(true)]
        public bool EnablePartyPanel { get; set; } = true;

        [DisplayName("Enable Time Skip")]
        [Category("UI Components")]
        [Display(Order = 161)]
        [DefaultValue(true)]
        public bool EnableTimeSkip { get; set; } = true;

        [DisplayName("Enable Get Item")]
        [Category("UI Components")]
        [Display(Order = 162)]
        [DefaultValue(true)]
        public bool EnableGetItem { get; set; } = true;

        [DisplayName("Enable Network Features")]
        [Category("UI Components")]
        [Display(Order = 163)]
        [DefaultValue(true)]
        public bool EnableNetworkFeatures { get; set; } = true;

        [DisplayName("Enable Shop")]
        [Category("UI Components")]
        [Display(Order = 164)]
        [DefaultValue(true)]
        public bool EnableShop { get; set; } = true;

        [DisplayName("Enable Persona Status")]
        [Category("UI Components")]
        [Display(Order = 165)]
        [DefaultValue(true)]
        public bool EnablePersonaStatus { get; set; } = true;

        [DisplayName("Enable Backlog")]
        [Category("UI Components")]
        [Display(Order = 166)]
        [DefaultValue(true)]
        public bool EnableBacklog { get; set; } = true;

        [DisplayName("Enable Button Prompts")]
        [Category("UI Components")]
        [Display(Order = 167)]
        [DefaultValue(true)]
        public bool EnableButtonPrompts { get; set; } = true;

        [DisplayName("Enable Title Menu")]
        [Category("UI Components")]
        [Display(Order = 168)]
        [DefaultValue(true)]
        public bool EnableTitleMenu { get; set; } = true;

        [DisplayName("Enable Staff Roll")]
        [Category("UI Components")]
        [Display(Order = 169)]
        [DefaultValue(true)]
        public bool EnableStaffRoll { get; set; } = true;

        [DisplayName("Enable Cutin")]
        [Category("UI Components")]
        [Display(Order = 170)]
        [DefaultValue(true)]
        public bool EnableCutin { get; set; } = true;

        [DisplayName("Enable Wipe")]
        [Category("UI Components")]
        [Display(Order = 171)]
        [DefaultValue(true)]
        public bool EnableWipe { get; set; } = true;

        [DisplayName("Enable Battle")]
        [Category("UI Components")]
        [Display(Order = 172)]
        [DefaultValue(true)]
        public bool EnableBattle { get; set; } = true;

        /*[DisplayName("Draw Original Select Box")]
        [Category("Debug")]
        [Display(Order = 1)]
        [DefaultValue(true)]
        public bool DebugDrawOgSelBox { get; set; } = true;
        */
        /*
        [DisplayName("Draw Original Missing Person")]
        [Category("Debug")]
        [Display(Order = 2)]
        [DefaultValue(true)]
        public bool DebugDrawMissingPerson { get; set; } = true;
        */

        [DisplayName("Hair Options")]
        [Description("The hair on top of Kotone.")]
        [Category("3D Options")]
        [Display(Order = 12)]
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
        [Display(Order = 3)]
        [DefaultValue(AOAType.esaadrien)]
        public AOAType AOATrue { get; set; } = AOAType.esaadrien;

        public enum AOAType
        {
            Ely,
            Chrysanthie,
            Fernando,
            Monica,
            RonaldReagan,
            esaadrien,
			mekki,
			shiosakana,
			shiosakanaAlt,
			Nami,
            AngieDaGorl,
            StupidAle
        }

        [DisplayName("AOA Text Options")]
        [Description("The AOA Foreground Text.")]
        [Category("2D Options")]
        [Display(Order = 4)]
        [DefaultValue(AOATextType.SorryBoutThat)]
        public AOATextType AOAText { get; set; } = AOATextType.SorryBoutThat;

        public enum AOATextType
        {
            DontLookBack,
            SorryBoutThat,
			PerfectlyAccomplished
        }


        [DisplayName("Bustup")]
        [Description("The Bustup.")]
        [Category("2D Options")]
        [Display(Order = 5)]
        [DefaultValue(BustupType.Esa)]
        public BustupType BustupTrue { get; set; } = BustupType.Esa;

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
            RonaldReagan,
			ElyAlt,
			Yuunagi,
			cielbell,
			axolotl,
			ghostedtoast,
			Strelko,
			gackt,
			Jackie,
			Lisa,
			BetaFemcByMae,
			crezzstar,
            crezzstarAlt,
            AngieDaGorl,
			namiweiko,
			chitu,
            shiosakana,
            samythecoolkid,
            Mixi_xiMi,
            StupidAle,
            Kiara
        }

        [DisplayName("Glass Shard")]
        [Description("The Glass Shard in that one menu when pausing.")]
        [Category("2D Options")]
        [Display(Order = 7)]
        [DefaultValue(ShardType.Esa)]
        public ShardType ShardTrue { get; set; } = ShardType.Esa;

        public enum ShardType
        {
            Esa,
            Ely,
            ElyAlt,
            Shiosakana,
			namiweiko,
            AngieDaGorl
        }

        [DisplayName("Level Up")]
        [Description("The Level Up :adachitrue:.")]
        [Category("2D Options")]
        [Display(Order = 10)]
        [DefaultValue(LevelUpType.Esa)]
        public LevelUpType LevelUpTrue { get; set; } = LevelUpType.Esa;

        public enum LevelUpType
        {
            Esa,
            Ely,
            shiosakana,
            ElyAlt,
            AngieDaGorl

        }

        [DisplayName("Party Panel")]
        [Description("The face icons in battle and pause menu")]
        [Category("2D Options")]
        [Display(Order = 11)]
        [DefaultValue(PartyPanelType.Esa)]
        public PartyPanelType PartyPanelTrue { get; set; } = PartyPanelType.Esa;

        public enum PartyPanelType
        {
            Kris,
            Esa
        }

        [DisplayName("Cutin")]
        [Description("Cutin Movie")]
        [Category("2D Options")]
        [Display(Order = 6)]
        [DefaultValue(CutinType.Mekki)]
        public CutinType CutinTrue { get; set; } = CutinType.Mekki;

        public enum CutinType
        {
            berrycha,
            ElyandPatmandx,
			Mekki,
            shiosakana
        }
		
		[DisplayName("Group Photo")]
        [Description("The group photo")]
        [Category("2D Options")]
        [Display(Order = 8)]
        [DefaultValue(GroupEventtype.ely)]
        public GroupEventtype GroupEventTrue { get; set; } = GroupEventtype.bichelle;

        public enum GroupEventtype
        {
            bichelle,
            ely
        }
		
		[DisplayName("Kyoto trip Photos")]
        [Description("The photos from the Kyoto trip")]
        [Category("2D Options")]
        [Display(Order = 9)]
        [DefaultValue(KyotoEventtype.ely)]
        public KyotoEventtype KyotoEventTrue { get; set; } = KyotoEventtype.ely;

        public enum KyotoEventtype
        {
            ely
        }

		[DisplayName("Animations")]
		[Description("Choose from a few Animations, note that some custom anims might not look correct if skeleton fix is enabled.")]
		[Category("3D Options")]
        [Display(Order = 13)]
        [DefaultValue(AnimType.OriginalAnims)]
		public AnimType AnimTrue { get; set; } = AnimType.OriginalAnims;

		public enum AnimType
		{
			OriginalAnims,
			CustomAnims,
			VeryFunnyAnims
		}

		[DisplayName("Kotone Room")]
        [Description("Decorate your dorm room with femc artwork made by the community")]
        [Category("Fun Stuff")]
        [Display(Order = 97)]
        [DefaultValue(false)]
        public bool KotoneRoom { get; set; } = false;

		[DisplayName("Gregory House Apron")]
		[Category("Fun Stuff")]
        [Display(Order = 99)]
        [DefaultValue(false)]
		public bool GregoryHouseRatPoisonDeliverySystem { get; set; } = false;

        [DisplayName("Otome Arcade game")]
        [Description("Changes the Arcade game that raises charm, to be gender swapped")]
        [Category("Fun Stuff")]
        [Display(Order = 98)]
        [DefaultValue(false)]
        public bool OtomeArcade { get; set; } = false;

        [DisplayName("Debug Log Level")]
        [Category("Debug")]
        [Display(Order = 0)]
        [DefaultValue(LogLevel.Information)]
        public LogLevel DebugLogLevel { get; set; } = LogLevel.Information;

        [DisplayName("Naginata Weapons")]
        [Description("Gives FemC Naginatas for weapons")]
        [Category("3D Options")]
        [Display(Order = 14)]
        [DefaultValue(true)]
        public bool NagiWeap { get; set; } = true;

		[DisplayName("Theo")]
		[Category("Theo")]
        [Display(Order = 100)]
		[DefaultValue(false)]
		public bool TheodorefromAlvinandTheChipmunks { get; set; } = false; // soon this should be a whole thing, movies, bustups, etc 


		[DisplayName("Voice Options")]
		[Description("The Voice of Kotone.")]
		[Category("Voice")]
        [Display(Order = 95)]
		[DefaultValue(VoiceType.Mellodi)]
		public VoiceType VoiceTrue { get; set; } = VoiceType.Mellodi;

		public enum VoiceType
		{
			Mellodi,
			MellodiSilly,
            Japanese
		}
	}


    /// <summary>
    /// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
    /// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
    /// </summary>
    public class ConfiguratorMixin : ConfiguratorMixinBase
    {

        
}
}
