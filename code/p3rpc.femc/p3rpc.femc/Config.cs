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
        
        // Debug

        [DisplayName("Debug Log Level")]
        [Category("Debug")]
        [Display(Order = 0)]
        [DefaultValue(LogLevel.Information)]
        public LogLevel DebugLogLevel { get; set; } = LogLevel.Information;

        // 2D Options

        [DisplayName("AOA Image")]
        [Description("The portrait used when finishing battles with an all-out attack initiated by FEMC.")]
        [Category("2D Options")]
        [Display(Order = 3)]
        [DefaultValue(AOAType.esaadrien)]
        public AOAType AOATrue { get; set; } = AOAType.esaadrien;

        public enum AOAType
        {
        [Display(Name = "Ely")]
        Ely,
        [Display(Name = "Chrysanthie")]
        Chrysanthie,
        [Display(Name = "Fernando")]
        Fernando,
        [Display(Name = "Monica")]
        Monica,
        [Display(Name = "Ronald Reagan")]
        RonaldReagan,
        [Display(Name = "Esa, Adrien")]
        esaadrien,
        [Display(Name = "Mekki")]
        mekki,
        [Display(Name = "shiosakana")]
        shiosakana,
        [Display(Name = "shiosakana (jacket closed)")]
        shiosakanaAlt,
        [Display(Name = "Namiweiko")]
        Nami,
        [Display(Name = "AngieDaGorl")]
        AngieDaGorl,
        [Display(Name = "StupidAle")]
        StupidAle,
        [Display(Name = "cielbell")]
        cielbell
        }

        [DisplayName("AOA Text Options")]
        [Description("The text used when finishing battles with an all-out attack initiated by FEMC.")]
        [Category("2D Options")]
        [Display(Order = 4)]
        [DefaultValue(AOATextType.SorryBoutThat)]
        public AOATextType AOAText { get; set; } = AOATextType.SorryBoutThat;

        public enum AOATextType
        {
        [Display(Name = "Don't look back.")]
        DontLookBack,
        [Display(Name = "Sorry 'bout that— bye-bye!")]
        SorryBoutThat,
        [Display(Name = "Perfectly accomplished!!")]
        PerfectlyAccomplished,
        }


        [DisplayName("Bustup")]
        [Description("The character portrait used in textboxes.")]
        [Category("2D Options")]
        [Display(Order = 5)]
        [DefaultValue(BustupType.Esa)]
        public BustupType BustupTrue { get; set; } = BustupType.Esa;

        public enum BustupType
        {
        [Display(Name = "Neptune")]
        Neptune,
        [Display(Name = "Ely")]
        Ely,
        [Display(Name = "Esa")]
        Esa,
        [Display(Name = "Betina")]
        Betina,
        [Display(Name = "P25th Anniversary Art")]
        Anniversary,
        [Display(Name = "Just Blue")]
        JustBlue,
        [Display(Name = "Sav")]
        Sav,
        [Display(Name = "Doodled")]
        Doodled,
        [Display(Name = "Ronald Reagan")]
        RonaldReagan,
        [Display(Name = "Ely (Alt)")]
        ElyAlt,
        [Display(Name = "Yuunagi")]
        Yuunagi,
        [Display(Name = "cielbell")]
        cielbell,
        [Display(Name = "axolotl")]
        axolotl,
        [Display(Name = "GhostedToast")]
        ghostedtoast,
        [Display(Name = "Strelko")]
        Strelko,
        [Display(Name = "gackt")]
        gackt,
        [Display(Name = "Jackie")]
        Jackie,
        [Display(Name = "Lisa9388")]
        Lisa,
        [Display(Name = "Mae (Beta FEMC)")]
        BetaFemcByMae,
        [Display(Name = "crezzstar")]
        crezzstar,
        [Display(Name = "crezzstar (Alt expression)")]
        crezzstarAlt,
        [Display(Name = "AngieDaGorl")]
        AngieDaGorl,
        [Display(Name = "namiweiko")]
        namiweiko,
        [Display(Name = "chitu")]
        chitu,
        [Display(Name = "shiosakana")]
        shiosakana,
        [Display(Name = "samythecoolkid")]
        samythecoolkid,
        [Display(Name = "Mixi_xiMi")]
        Mixi_xiMi,
        [Display(Name = "StupidAle")]
        StupidAle,
        [Display(Name = "Kiara")]
        Kiara,
        [Display(Name = "Autumn")]
        Autumn,
        [Display(Name = "P3 Portable by Yuha")]
        p3pYuha,
        [Display(Name = "Maru")]
        Maru,
        [Display(Name = "purpleoctogamer")]
        purpleoctogamer,
        [Display(Name = "purpleoctogamer Q2")]
        purpleoctogamerAlt,
        [Display(Name = "Anonymousfluffi")]
        Anonymousfluffi,
        [Display(Name = "WoodWhite")]
        woodwhite,
        [Display(Name = "Milky")]
        Milky
        }

        [DisplayName("Cutin")]
        [Description("The animation played occasionally when attacking weaknesses or hitting criticals.")]
        [Category("2D Options")]
        [Display(Order = 6)]
        [DefaultValue(CutinType.Mekki)]
        public CutinType CutinTrue { get; set; } = CutinType.Mekki;

        public enum CutinType
        {
        [Display(Name = "berrycha")]
        berrycha,
        [Display(Name = "Ely, PatManDX")]
        ElyandPatmandx,
        [Display(Name = "Mekki")]
        Mekki,
        [Display(Name = "shiosakana")]
        shiosakana
        }

        [DisplayName("Group Photo")]
        [Description("The group photo taken during a certain event.")]
        [Category("2D Options")]
        [Display(Order = 7)]
        [DefaultValue(GroupEventtype.mekki)]
        public GroupEventtype GroupEventTrue { get; set; } = GroupEventtype.mekki;

        public enum GroupEventtype
        {
        [Display(Name = "Bichelle")]
        bichelle,
        [Display(Name = "Ely")]
        ely,
        [Display(Name = "Mekki & Cpido & Dniwe")]
        mekki
        }

        [DisplayName("Kyoto Photos")]
        [Description("The photos taken during the Kyoto trip.")]
        [Category("2D Options")]
        [Display(Order = 8)]
        [DefaultValue(KyotoEventtype.ely)]
        public KyotoEventtype KyotoEventTrue { get; set; } = KyotoEventtype.ely;

        public enum KyotoEventtype
        {
        [Display(Name = "Ely")]
        ely,
        [Display(Name = "Mekki & Cpido & Dniwe")]
        mekki
        }

        [DisplayName("Level Up Art")]
        [Description("The character art used for the level up screen.")]
        [Category("2D Options")]
        [Display(Order = 9)]
        [DefaultValue(LevelUpType.Esa)]
        public LevelUpType LevelUpTrue { get; set; } = LevelUpType.Esa;

        public enum LevelUpType
        {
        [Display(Name = "Esa")]
        Esa,
        [Display(Name = "Ely")]
        Ely,
        [Display(Name = "shiosakana")]
        shiosakana,
        [Display(Name = "Ely (Alt)")]
        ElyAlt,
        [Display(Name = "AngieDaGorl")]
        AngieDaGorl,
        [Display(Name = "samythecoolkid")]
        samythecoolkid

        }

        [DisplayName("Party Panel")]
        [Description("The character icon on the right when dungeon crawling or in combat.")]
        [Category("2D Options")]
        [Display(Order = 10)]
        [DefaultValue(PartyPanelType.Esa)]
        public PartyPanelType PartyPanelTrue { get; set; } = PartyPanelType.Esa;

        public enum PartyPanelType
        {
        [Display(Name = "Kris")]
        Kris,
        [Display(Name = "Esa")]
        Esa
        }

        [DisplayName("Status Menu Art")]
        [Description("The character art used in the status menu.")]
        [Category("2D Options")]
        [Display(Order = 11)]
        [DefaultValue(ShardType.Esa)]
        public ShardType ShardTrue { get; set; } = ShardType.Esa;

        public enum ShardType
        {
        [Display(Name = "Esa")]
        Esa,
        [Display(Name = "Ely")]
        Ely,
        [Display(Name = "Ely (Alt)")]
        ElyAlt,
        [Display(Name = "shiosakana")]
        Shiosakana,
        [Display(Name = "namiweiko")]
        namiweiko,
        [Display(Name = "AngieDaGorl")]
        AngieDaGorl,
        [Display(Name = "StupidAle")]
        StupidAle,
        [Display(Name = "samythecoolkid")]
        samythecoolkid
        }

        // 3D Options

        [DisplayName("Animations")]
        [Description("Choose from a few animations.\n\nNote that some custom anims might not look correct if skeleton fix is enabled,\nsuch as the menu animations.")]
        [Category("3D Options")]
        [Display(Order = 12)]
        [DefaultValue(AnimType.OriginalAnims)]
        public AnimType AnimTrue { get; set; } = AnimType.OriginalAnims;

        public enum AnimType
        {
        [Display(Name = "Original Animations")]
        OriginalAnims,
        [Display(Name = "Custom Animations")]
        CustomAnims,
        [Display(Name = "Very Funny Animations")]
        VeryFunnyAnims
        }

        [DisplayName("Hair Options")]
        [Description("The hair model used on FEMC.")]
        [Category("3D Options")]
        [Display(Order = 13)]
        [DefaultValue(HairType.MudkipsHair)]
        public HairType HairTrue { get; set; } = HairType.MudkipsHair;

        public enum HairType
        {
        [Display(Name = "Default")]
        MudkipsHair,
        [Display(Name = "Kotone Bean")]
        KotoneBeanHair
        }

        [DisplayName("Naginata Weapons")]
        [Description("Changes FEMC's weapons from 1h swords to naginatas.")]
        [Category("3D Options")]
        [Display(Order = 14)]
        [DefaultValue(true)]
        public bool NagiWeap { get; set; } = true;

        // Voice

        [DisplayName("Voice Options")]
        [Description("The voice used ingame for FEMC.")]
        [Category("Voice")]
        [Display(Order = 20)]
        [DefaultValue(VoiceType.Mellodi)]
        public VoiceType VoiceTrue { get; set; } = VoiceType.Mellodi;

        public enum VoiceType
        {
        [Display(Name = "Mellodi")]
        Mellodi,
        [Display(Name = "Mellodi (Silly)")]
        MellodiSilly,
		[Display(Name = "Lantana")]
        Lantana,
        [Display(Name = "Japanese")]
        Japanese
        }

        [DisplayName("Gendered Audio")]
        [Category("Voice")]
        [Description("Uses custom voice lines to refer to FEMC with she/her pronouns where applicable.\nOnly English audio is supported currently.")]
        [Display(Order = 21)]
        [DefaultValue(true)]
        public bool bluehairandpronounce { get; set; } = true;

        // Music
        //  Battle Music - Advantage

        [DisplayName("Pull the Trigger (P3P Arrange) by Karma")]
		[Category("Battle Music - Advantage")]
		[Description("Enable Pull The Trigger (P3P Arrange) as advantage battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 30)]
		[DefaultValue(false)]
		public bool KarmaAdv { get; set; } = false;

		[DisplayName("Pull the Trigger -reload- by MOSQ")]
        [Category("Battle Music - Advantage")]
        [Description("Enable Pull The Trigger -reload- by MOSQ as advantage battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 31)]
		[DefaultValue(true)]
		public bool MosqAdv { get; set; } = true;

		[DisplayName("Pull the Trigger -reload- by EidieK87")]
        [Category("Battle Music - Advantage")]
        [Description("Enable Pull The Trigger -reload- by EidieK87 as advantage battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 32)]
		[DefaultValue(false)]
		public bool EidAdv { get; set; } = false;

        [DisplayName("It's Going Down Now")]
        [Category("Battle Music - Advantage")]
        [Description("Enable It's Going Down Now, which is used by default for advantage battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 33)]
        [DefaultValue(false)]
        public bool ItGoingDown { get; set; } = false;

        //  Battle Music - Normal

        [DisplayName("Wiping All Out (Reload Arrange) by MOSQ")]
        [Category("Battle Music - Normal")]
        [Description("Enable Wiping All Out (Reload Arrange) by MOSQ as normal battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 40)]
		[DefaultValue(true)]
		public bool MosqNom { get; set; } = true;

		[DisplayName("Wiping All Out -RELOADED- by Karma")]
        [Category("Battle Music - Normal")]
        [Description("Enable Wiping All Out -RELOADED- by Karma as normal battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 41)]
		[DefaultValue(false)]
		public bool KarmaNom { get; set; } = false;

		[DisplayName("Wiping All Out cover by Satella")]
        [Category("Battle Music - Normal")]
        [Description("Enable Wiping All Out by Satella and GillStudio as normal battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 42)]
		[DefaultValue(false)]
		public bool SgNom { get; set; } = false;

        [DisplayName("Wiping All Out (P3P)")]
        [Category("Battle Music - Normal")]
        [Description("Enable the original Wiping All Out from P3P as normal battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 43)]
        [DefaultValue(false)]
        public bool P3PNom { get; set; } = false;

        [DisplayName("Wiping All Out ATLUS Kozuka Remix")]
        [Category("Battle Music - Normal")]
        [Description("Enable Wiping All Out ATLUS Kozuka Remix from P3D as normal battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 44)]
        [DefaultValue(false)]
        public bool P3MidNomF { get; set; } = false;

        [DisplayName("Wiping All Out by EidieK87")]
        [Category("Battle Music - Normal")]
        [Description("Enable Wiping All Out by by EidieK87 as normal battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 45)]
        [DefaultValue(false)]
        public bool EidNom { get; set; } = false;

        [DisplayName("Wiping All Out Remix by Restless Artist")]
        [Category("Battle Music - Normal")]
        [Description("Enable Wiping All Out Remix by Restless Artist as advantage battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 32)]
        [DefaultValue(false)]
        public bool RestlessNom { get; set; } = false;

        [DisplayName("Mass Destruction -Reload-")]
        [Category("Battle Music - Normal")]
        [Description("Enable Mass Destruction -Reload-, which is used by default for normal battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 46)]
        [DefaultValue(false)]
        public bool MassDes { get; set; } = false;

        //  Tartarus Boss Music

        [DisplayName("Danger Zone - Guitar Cover by GillStudio")]
		[Category("Tartarus Boss Music")]
        [Description("Enable Danger Zone by GillStudio as Tartarus boss battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 50)]
		[DefaultValue(false)]
		public bool SgDis { get; set; } = false;

        [DisplayName("Danger Zone remix by EidieK87")]
        [Category("Tartarus Boss Music")]
        [Description("Enable Danger Zone by EidieK87 as Tartarus boss battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 51)]
        [DefaultValue(false)]
        public bool EidDis { get; set; } = false;

        [DisplayName("Danger Zone -Reloaded- by Karma")]
        [Category("Tartarus Boss Music")]
        [Description("Enable Danger Zone -Reloaded- by Karma as Tartarus boss battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 52)]
		[DefaultValue(false)]
		public bool KarmaDis { get; set; } = false;

		[DisplayName("Danger Zone (Reload Arrange) by MOSQ")]
        [Category("Tartarus Boss Music")]
        [Description("Enable Danger Zone (Reload Arrange) by MOSQ as Tartarus boss battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 53)]
		[DefaultValue(true)]
		public bool MosqDis { get; set; } = true;

        [DisplayName("Danger Zone (P3P)")]
        [Category("Tartarus Boss Music")]
        [Description("Enable the original Danger Zone from P3P as Tartarus boss battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 54)]
        [DefaultValue(false)]
        public bool P3PDis { get; set; } = false;

        [DisplayName("Restless Artist Danger Zone")]
        [Category("Tartarus Boss Music")]
        [Description("Enable Restless Artist's Danger Zone Tartarus boss battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 54)]
        [DefaultValue(false)]
        public bool RestlessDis { get; set; } = false;

        [DisplayName("Master of Tartarus -Reload-")]
        [Category("Tartarus Boss Music")]
        [Description("Enable Master of Tartarus -Reload-, which is used by default for Tartarus boss battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 55)]
        [DefaultValue(false)]
        public bool MasterTar { get; set; } = false;

        //  Special Boss Music

        [DisplayName("Nyx Final Battle: Burn My Dread -Last Battle Reload-")]
        [Category("Special Boss Music")]
        [Description("Enable Burn My Dread -Last Battle Reload-, the default Nyx boss battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 62)]
        [DefaultValue(true)]
        public bool BMD { get; set; } = true;

        [DisplayName("Nyx Final Battle: Soul Phrase -last battle- by Karma")]
        [Category("Special Boss Music")]
        [Description("Enable Soul Phrase -last battle- by Karma as the Nyx boss battle music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 63)]
        [DefaultValue(false)]
        public bool SoulPK { get; set; } = false;

        //  Overworld Music

        [DisplayName("A Way of Life (Reload Arrange) by MOSQ")]
        [Category("Daytime Music")]
        [Description("Enable A Way Of Life -Reload- (Vocal Version) by MOSQ as the daytime music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 71)]
        [DefaultValue(true)]
        public bool WayOfLife { get; set; } = false;

        [DisplayName("A Way of Life cover by Jen")]
        [Category("Daytime Music")]
        [Description("Enable A Way Of Life by Jen as the daytime music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 72)]
        [DefaultValue(false)]
        public bool WayOfLifeJen { get; set; } = false;

        [DisplayName("A Way of Life -Reload- (Vocal Version) by Super M Plush, MOSQ, Karma, cora")]
        [Category("Daytime Music")]
        [Description("Enable A Way Of Life -Reload- (Vocal Version) by Super M Plush, MOSQ, Karma and cora\nas the daytime music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 73)]
        [DefaultValue(false)]
        public bool WayLifeVocal { get; set; } = true;

        [DisplayName("A Way Of Life (P3P)")]
        [Category("Daytime Music")]
        [Description("Enable the original A Way Of Life from P3P as the daytime music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 74)]
        [DefaultValue(false)]
        public bool WayOfLifeP3P { get; set; } = false;

        [DisplayName("A Way Of Life -Deep inside my mind Remix-")]
        [Category("Daytime Music")]
        [Description("Enable A Way Of Life -Deep inside my mind Remix- from P3P as the daytime music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 75)]
        [DefaultValue(false)]
        public bool WayOfLifeRemix { get; set; } = false;

        [DisplayName("A Way Of Life ATLUS Kitajoh Remix")]
        [Category("Daytime Music")]
        [Description("Enable A Way Of Life ATLUS Kitajoh Remix from P3D as the daytime music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 76)]
        [DefaultValue(false)]
        public bool WayOfLifeP3D { get; set; } = false;

        [DisplayName("When the Moon's Reaching Out Stars -Reload-")]
        [Category("Daytime Music")]
        [Description("Enable When the Moon's Reaching Out Stars -Reload-, which is used by default for daytime music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 77)]
        [DefaultValue(false)]
        public bool Moon { get; set; } = true;

        [DisplayName("A Way of Life (Restless Artist)")]
        [Category("Daytime Music")]
        [Description("Enable A Way of Life (Restless Artist).\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 78)]
        [DefaultValue(false)]
        public bool RestlessWayofLife { get; set; } = true;

        //  School Music - 1st semester

        [DisplayName("Time (Reload Arrange) by MOSQ")]
        [Category("School Music (1st semester)")]
        [Description("Enable Time (Reload Arrange) by MOSQ as the 1st semester school music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 80)]
        [DefaultValue(false)]
        public bool TimeSchool { get; set; } = false;

        [DisplayName("Time -Reload- (Vocal Version) by GabiShy and MOSQ")]
        [Category("School Music (1st semester)")]
        [Description("Enable Time -Reload- (Vocal Version) by GabiShy and MOSQ as the 1st\nsemester school music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 81)]
        [DefaultValue(true)]
        public bool GabiTimeSchool { get; set; } = true;

        [DisplayName("Time (P3P)")]
        [Category("School Music (1st semester)")]
        [Description("Enable the original Time from P3P as the 1st semester school music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 82)]
        [DefaultValue(false)]
        public bool TimeSchoolP3P { get; set; } = false;

        [DisplayName("Time ATLUS Kitajoh Remix")]
        [Category("School Music (1st semester)")]
        [Description("Enable Time ATLUS Kitajoh Remix from P3D as the 1st semester school music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 83)]
        [DefaultValue(false)]
        public bool TimeSchoolP3D { get; set; } = false;

        [DisplayName("Want To Be Close -Reload-")]
        [Category("School Music (1st semester)")]
        [Description("Enable Want To Be Close -Reload-, which is used by default for  1st semester school music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 84)]
        [DefaultValue(false)]
        public bool WantClose { get; set; } = false;

        //  School Music - 2nd semester

        [DisplayName("Sun (Reload Arrange) by MOSQ")]
        [Category("School Music (2nd semester)")]
        [Description("Enable Sun (Reload Arrange) by MOSQ as the 2nd semester school music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 90)]
        [DefaultValue(true)]
        public bool Sun { get; set; } = true;

        [DisplayName("Sun -Reload- by MineFormer")]
        [Category("School Music (2nd semester)")]
        [Description("Enable Sun -Reload- by Mineformer as the 2nd semester school music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 91)]
        [DefaultValue(false)]
        public bool SunMForm { get; set; } = false;

        [DisplayName("Sun (P3P)")]
        [Category("School Music (2nd semester)")]
        [Description("Enable the original Sun from P3P as the 1st semester school music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 92)]
        [DefaultValue(false)]
        public bool SunP3P { get; set; } = false;

        [DisplayName("Changing Seasons -Reload-")]
        [Category("School Music (2nd semester)")]
        [Description("Enable Changing Seasons -Reload-, which is used by default for 1st semester school music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 93)]
        [DefaultValue(false)]
        public bool Seasons { get; set; } = false;

        //  Night Music

		[DisplayName("Time (Night Version) by MOSQ")]
		[Category("Night Music")]
        [Description("Enable Time (Night Version) by Mineformer as the night music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 100)]
        [DefaultValue(false)]
		public bool FemNight { get; set; } = false;

		[DisplayName("Time -Night- Vocal Version by GabiShy and MOSQ")]
        [Category("Night Music")]
        [Description("Enable Time -Night- Vocal Version by GabiShy and MOSQ as the night music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 101)]
        [DefaultValue(false)]
		public bool GabiFemNight { get; set; } = false;

        [DisplayName("Midnight Reverie by Mineformer")]
        [Category("Night Music")]
        [Description("Enable Midnight Reverie by Mineformer as the night music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 102)]
        [DefaultValue(false)]
        public bool MidNight { get; set; } = false;

        [DisplayName("Night Wanderer by MOSQ")]
        [Category("Night Music")]
        [Description("Enable Night Wanderer by MOSQ as the night music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 103)]
        [DefaultValue(true)]
		public bool NightWand { get; set; } = true;

        [DisplayName("Moonlight by MOSQ")]
        [Category("Night Music")]
        [Description("Enable Moonlight by MOSQ as the night music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 106)]
        [DefaultValue(false)]
        public bool EsaComm { get; set; } = false;

        [DisplayName("Color Your Night")]
        [Category("Night Music")]
        [Description("Enable Color Your Night, the default night music.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 104)]
        [DefaultValue(false)]
        public bool ColNight { get; set; } = false;

        //  Event Music

		[DisplayName("Social Link Events 1: After School (Reload Arrange) by MOSQ")]
        [Category("Event Music")]
        [Description("Enable After School by MOSQ to be played during social link events.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 110)]
        [DefaultValue(true)]
		public bool AfterSchool { get; set; } = true;

        [DisplayName("Social Link Events 1: After School")]
        [Category("Event Music")]
        [Description("Enable the original After School to be played during social link events.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 111)]
        [DefaultValue(false)]
        public bool AfterSchoolP3P { get; set; } = false;

        [DisplayName("Social Link Events 1: Joy")]
        [Category("Event Music")]
        [Description("Enable Joy, which is used by default for social link events.\nMultiple songs can be chosen for randomization!")]
        [Display(Order = 112)]
        [DefaultValue(false)]
        public bool Joy { get; set; } = false;

        // Commented out for now but whenever new social link music is added, uncomment this (and change the file/folder names accordingly too)
        //[DisplayName("Social Link Events: Tender Feelings")]
        //[Category("Music")]
        //[Description("Enable the original Tender Feelings to be played during social link events.\nMultiple songs can be chosen for randomization!")]
        //[DefaultValue(false)]
        //[Display(Order = 113)]
        //public bool TenderFeelings { get; set; } = false;

        // Fun Stuff

        [DisplayName("Kotone Room")]
        [Category("Fun Stuff")]
        [Description("Decorate your dorm room with FEMC artwork made by the community!")]
        [Display(Order = 120)]
        [DefaultValue(false)]
        public bool KotoneRoom { get; set; } = false;

        [DisplayName("Gregory House Apron")]
        [Category("Fun Stuff")]
        [Display(Order = 121)]
        [DefaultValue(false)]
        public bool GregoryHouseRatPoisonDeliverySystem { get; set; } = false;

        [DisplayName("Otome Arcade Game")]
        [Description("Changes the arcade game that raises charm to be gender swapped.")]
        [Category("Fun Stuff")]
        [Display(Order = 122)]
        [DefaultValue(false)]
        public bool OtomeArcade { get; set; } = false;

        // Theo

        [DisplayName("Enable Theodore")]
        [Category("Theo")]
        [Description("Enable Theodore to replace Elizabeth as FEMC's Velvet Room attendant.")]
        [Display(Order = 123)]
        [DefaultValue(false)]
        public bool TheodorefromAlvinandTheChipmunks { get; set; } = false; // soon this should be a whole thing, movies, bustups, etc 

        [DisplayName("Deck Compatibility Switch")]
        [Category("Testing")]
        [Description("Test option to disable some ui components that seem to be unstable on Linux. Please help us test this my windows 11 refugees.")]
        [DefaultValue(false)]
        public bool DeckCompatibilitySwitch { get; set; } = false;

        // Dorm Swap

        [DisplayName("Test Dorm Room Swap and Current Edited Events")]
        [Category("Testing")]
        [Description("This enables the dorm room swap as well as all the CURRENT edited events")]
        [DefaultValue(false)]
        public bool TesticlesEventsDorm { get; set; } = true; // yeah


        // UI Components

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
        /*
        [DisplayName("Enable MessageScript")]
        [Category("UI Components")]
        [Display(Order = 158)]
        [DefaultValue(true)]
        public bool EnableMessageScript { get; set; } = true;
        */
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

        [DisplayName("Enable Item List")]
        [Category("UI Components")]
        [Display(Order = 173)]
        [DefaultValue(true)]
        public bool EnableItemList { get; set; } = true;

        [DisplayName("Enable Social Link")]
        [Category("UI Components")]
        [Display(Order = 174)]
        [DefaultValue(true)]
        public bool EnableCommunity { get; set; } = true;

        [DisplayName("Enable Guidance")]
        [Category("UI Components")]
        [Display(Order = 175)]
        [DefaultValue(true)]
        public bool EnableGuidance { get; set; } = true;

        [DisplayName("Mail Icon: Outer Color")]
        [Category("UI Colors")]
        [Display(Order = 200)]
        public ConfigColor MailIconOuterCircleColorEx { get; set; } = new ConfigColor(0x90, 0x21, 0x4D, 0xAF);

        [DisplayName("Mail Icon: Inner Color")]
        [Category("UI Colors")]
        [Display(Order = 201)]
        public ConfigColor MailIconInnerCircleColorEx { get; set; } = new ConfigColor(0xFF, 0x5C, 0x94, 0xFF);

        [DisplayName("Camp: High Color")]
        [Category("UI Colors")]
        [Display(Order = 202)]
        public ConfigColor CampHighColor { get; set; } = new ConfigColor(0xFF, 0x9B, 0xCE, 0xFF);

        [DisplayName("Camp: High Color Gradation")]
        [Category("UI Colors")]
        [Display(Order = 203)]
        public ConfigColor CampHighColorGradation { get; set; } = new ConfigColor(0xE3, 0x96, 0xB9, 0xFF);

        [DisplayName("Camp: Middle Color")]
        [Category("UI Colors")]
        [Display(Order = 204)]
        public ConfigColor CampMiddleColor { get; set; } = new ConfigColor(0xE2, 0x5C, 0xA4, 0xFF);

        [DisplayName("Camp: Low Color")]
        [Category("UI Colors")]
        [Display(Order = 205)]
        public ConfigColor CampLowColor { get; set; } = new ConfigColor(0x9F, 0x1D, 0x91, 0xFF);

        [DisplayName("Date Time Panel: Top Text Color")]
        [Category("UI Colors")]
        [Display(Order = 206)]
        public ConfigColor DateTimePanelTopTextColor { get; set; } = new ConfigColor(0x50, 0x0A, 0x35, 0xF5);

        [DisplayName("Date Time Panel: Bottom Text Color")]
        [Category("UI Colors")]
        [Display(Order = 207)]
        public ConfigColor DateTimePanelBottomTextColor { get; set; } = new ConfigColor(0xFF, 0xD6, 0xAE, 0xFF);

        [DisplayName("Date Time Panel: Bottom Text Color")]
        [Category("UI Colors")]
        [Display(Order = 207)]
        public ConfigColor DateTimePanelBottomColor { get; set; } = new ConfigColor(0xFF, 0x8B, 0x8B, 0xFF);

        [DisplayName("Date Time Panel: Water Color")]
        [Category("UI Colors")]
        [Display(Order = 208)]
        public ConfigColor DateTimePanelWaterColor { get; set; } = new ConfigColor(0xFF, 0x5C, 0x94, 0xFF);

        [DisplayName("Text Box: Back Fill Color")]
        [Category("UI Colors")]
        [Display(Order = 209)]
        public ConfigColor TextBoxBackFillColor { get; set; } = new ConfigColor(0xE5, 0x46, 0x7D, 0xFF);

        [DisplayName("Text Box: Front Fill Color")]
        [Category("UI Colors")]
        [Display(Order = 210)]
        public ConfigColor TextBoxFrontFillColor { get; set; } = new ConfigColor(0x22, 0x00, 0x15, 0xFF);

        [DisplayName("Text Box: Front Fill Border Color")]
        [Category("UI Colors")]
        [Display(Order = 211)]
        public ConfigColor TextBoxFrontBorderColor { get; set; } = new ConfigColor(0xFA, 0x50, 0x8B, 0xFF);

        [DisplayName("Text Box: Speaker Name Triangle Color")]
        [Category("UI Colors")]
        [Display(Order = 212)]
        public ConfigColor TextBoxSpeakerNameTriangle { get; set; } = new ConfigColor(0x34, 0x06, 0x1C, 0xFF);

        [DisplayName("Text Box: Speaker Name Triangle Front Color")]
        [Category("UI Colors")]
        [Display(Order = 212)]
        public ConfigColor TextBoxSpeakerNameTriangleFront { get; set; } = new ConfigColor(0xEB, 0x46, 0x7F, 0xFF);

        [DisplayName("Text Box: Speaker Name")]
        [Category("UI Colors")]
        [Display(Order = 213)]
        public ConfigColor TextBoxSpeakerName { get; set; } = new ConfigColor(0xFF, 0xE6, 0xBF, 0xFF);

        [DisplayName("Text Box: Left Haze Color")]
        [Category("UI Colors")]
        [Display(Order = 214)]
        public ConfigColor TextBoxLeftHaze { get; set; } = new ConfigColor(0x79, 0x07, 0x2A, 0xFF);

        [DisplayName("Mind Window: Outer Border")]
        [Category("UI Colors")]
        [Display(Order = 215)]
        public ConfigColor MindWindowOuterBorderNew { get; set; } = new ConfigColor(0xBE, 0x1C, 0x53, 0xFF);

        [DisplayName("Mind Window: Inner Color")]
        [Category("UI Colors")]
        [Display(Order = 216)]
        public ConfigColor MindWindowInnerColorNew { get; set; } = new ConfigColor(0x39, 0x03, 0x21, 0xFF);

        /*[DisplayName("Mind Window: Outer Haze")] i'm hardcoding this it's broken for too many people lol
         * [Category("UI Colors")]
         * [Display(Order = 217)]
        public ConfigColor MindWindowOuterHazeEx { get; set; } = new ConfigColor(0xFF, 0x89, 0xA6, 0x80);
        */

        [DisplayName("Mind Window: Background Dots")]
        [Category("UI Colors")]
        [Display(Order = 218)]
        public ConfigColor MindWindowBgDotsNew { get; set; } = new ConfigColor(0xA6, 0x06, 0x52, 0xFF);

        [DisplayName("Minimap: Place Name Background Color")]
        [Category("UI Colors")]
        [Display(Order = 219)]
        public ConfigColor MinimapPlaceNameBgColor { get; set; } = new ConfigColor(0x73, 0x18, 0x3C, 0xF5);

        [DisplayName("Interact Prompt: Back Box Color")]
        [Category("UI Colors")]
        [Display(Order = 220)]
        public ConfigColor CheckPromptBackBoxColorNew { get; set; } = new ConfigColor(0xFA, 0x50, 0x8B, 0xFF);

        [DisplayName("Interact Prompt: Front Box Base Color")]
        [Category("UI Colors")]
        [Display(Order = 221)]
        public ConfigColor CheckPromptFrontBoxColorNew { get; set; } = new ConfigColor(0x22, 0x00, 0x15, 0xFF);

        [DisplayName("Interact Prompt: Front Box Highlight Color")]
        [Category("UI Colors")]
        [Display(Order = 222)]
        public ConfigColor CheckPromptFrontBoxColorHighNew { get; set; } = new ConfigColor(0x61, 0x00, 0x2C, 0xFF);

        [DisplayName("Bustup: Shadow Color")]
        [Category("UI Colors")]
        [Display(Order = 223)]
        public ConfigColor BustupShadowColor { get; set; } = new ConfigColor(0xD8, 0x39, 0x70, 0xFF);

        [DisplayName("Camp: Menu Item Color 1 (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 224)]
        public ConfigColor CampMenuItemColor1 { get; set; } = new ConfigColor(0xFF, 0xED, 0xC9, 0xFF);

        [DisplayName("Camp: Menu Item Color 2 (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 225)]
        public ConfigColor CampMenuItemColor2 { get; set; } = new ConfigColor(0xFF, 0xD7, 0x9D, 0xFF);

        [DisplayName("Camp: Menu Item Color 3 (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 226)]
        public ConfigColor CampMenuItemColor3 { get; set; } = new ConfigColor(0xFF, 0xBA, 0x67, 0xFF);

        [DisplayName("Camp: Menu Item Color No Select (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 227)]
        public ConfigColor CampMenuItemColorNoSel { get; set; } = new ConfigColor(0xFF, 0xB2, 0x9E, 0xFF);

        [DisplayName("Camp: Skill Text Color")]
        [Category("UI Colors")]
        [Display(Order = 228)]
        public ConfigColor CampSkillTextColor { get; set; } = new ConfigColor(0xFF, 0xE7, 0xAD, 0xFF);

        [DisplayName("Camp: Skill Text Color No Select")]
        [Category("UI Colors")]
        [Display(Order = 229)]
        public ConfigColor CampSkillTextColorNoSel { get; set; } = new ConfigColor(0x3D, 0x03, 0x1C, 0xFF);

        [DisplayName("Camp: Skill Text Color Current Select")]
        [Category("UI Colors")]
        [Display(Order = 230)]
        public ConfigColor CampSkillTextColorCurrSel { get; set; } = new ConfigColor(0x3D, 0x03, 0x1C, 0xFF);

        [DisplayName("Social Stats: Academics Circle Color")]
        [Category("UI Colors")]
        [Display(Order = 231)]
        public ConfigColor SocialStatsCircleAcademicsColor { get; set; } = new ConfigColor(0xA0, 0x0C, 0x42, 0xFF);

        [DisplayName("Social Stats: Charm Circle Color")]
        [Category("UI Colors")]
        [Display(Order = 232)]
        public ConfigColor SocialStatsCircleCharmColor { get; set; } = new ConfigColor(0xFF, 0x8F, 0xEC, 0xFF);

        [DisplayName("Social Stats: Courage Circle Color")]
        [Category("UI Colors")]
        [Display(Order = 233)]
        public ConfigColor SocialStatsCircleCourageColor { get; set; } = new ConfigColor(0xF5, 0x62, 0xA7, 0xFF);

        [DisplayName("Camp: Item Menu Character Top Color (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 234)]
        public ConfigColor CampItemMenuCharacterTopColor { get; set; } = new ConfigColor(0xDD, 0x76, 0x8C, 0xFF);

        [DisplayName("Camp: Item Menu Character Bottom Color (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 235)]
        public ConfigColor CampItemMenuCharacterBottomColor { get; set; } = new ConfigColor(0x5B, 0x0C, 0x33, 0xFF);

        [DisplayName("Assist Message Box: Background Color")]
        [Category("UI Colors")]
        [Display(Order = 236)]
        public ConfigColor MsgAssistBgColor { get; set; } = new ConfigColor(0xFF, 0x4A, 0x77, 0xFF);

        [DisplayName("Town Map: Border Color")]
        [Category("UI Colors")]
        [Display(Order = 237)]
        public ConfigColor TownMapBorderColor { get; set; } = new ConfigColor(0x49, 0x04, 0x28, 0xFF);

        [DisplayName("Town Map: Text Color")]
        [Category("UI Colors")]
        [Display(Order = 238)]
        public ConfigColor TownMapTextColor { get; set; } = new ConfigColor(0xFF, 0x58, 0x85, 0xFF);

        [DisplayName("Camp Social Link: Light Color")]
        [Category("UI Colors")]
        [Display(Order = 239)]
        public ConfigColor CampSocialLinkLight { get; set; } = new ConfigColor(0xFF, 0xE7, 0xAD, 0xFF);

        [DisplayName("Camp Social Link: Dark Color")]
        [Category("UI Colors")]
        [Display(Order = 240)]
        public ConfigColor CampSocialLinkDark { get; set; } = new ConfigColor(0x49, 0x04, 0x2E, 0xFF);

        [DisplayName("Camp Social Link: Desc BG")]
        [Category("UI Colors")]
        [Display(Order = 241)]
        public ConfigColor CampSocialLinkDetailDescBg { get; set; } = new ConfigColor(0x49, 0x04, 0x21, 0xFF);

        [DisplayName("Camp Social Link: Desc Triangle")]
        [Category("UI Colors")]
        [Display(Order = 242)]
        public ConfigColor CampSocialLinkDetailDescTriangle { get; set; } = new ConfigColor(0xE1, 0x2D, 0x69, 0xFF);

        [DisplayName("Camp Social Link: Desc Name")]
        [Category("UI Colors")]
        [Display(Order = 243)]
        public ConfigColor CampSocialLinkDetailDescName { get; set; } = new ConfigColor(0xFF, 0xE7, 0xAD, 0xFF);

        [DisplayName("Arcana Card Fall Color 1")]
        [Category("UI Colors")]
        [Display(Order = 244)]
        public ConfigColor ArcanaCardFallColor1 { get; set; } = new ConfigColor(0xD6, 0x54, 0x8D, 0xFF);

        [DisplayName("Arcana Card Fall Color 2")]
        [Category("UI Colors")]
        [Display(Order = 245)]
        public ConfigColor ArcanaCardFallColor2 { get; set; } = new ConfigColor(0xD6, 0x54, 0x8D, 0xFF);

        [DisplayName("Arcana Card Fall Color 3")]
        [Category("UI Colors")]
        [Display(Order = 246)]
        public ConfigColor ArcanaCardFallColor3 { get; set; } = new ConfigColor(0xD6, 0x54, 0x8D, 0xFF);

        [DisplayName("Camp Calendar: Sunday Color (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 247)]
        public ConfigColor CampCalendarSundayColor { get; set; } = new ConfigColor(0xFF, 0x00, 0x00, 0xFF);

        [DisplayName("Camp Calendar: Sunday Color 2 (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 248)]
        public ConfigColor CampCalendarSundayColor2 { get; set; } = new ConfigColor(0xEE, 0x00, 0x00, 0xFF);

        [DisplayName("Camp Calendar: Text Color (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 249)]
        public ConfigColor CampCalendarTextColor { get; set; } = new ConfigColor(0x3D, 0x03, 0x1C, 0xFF);

        [DisplayName("Camp Calendar: Highlight Color (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 250)]
        public ConfigColor CampCalendarHighlightColor { get; set; } = new ConfigColor(0x46, 0xE7, 0xFF, 0xFF);

        [DisplayName("Camp Calendar: Part Time Job Background")]
        [Category("UI Colors")]
        [Display(Order = 251)]
        public ConfigColor CampCalendarPartTimeJobBackground { get; set; } = new ConfigColor(0xB6, 0x3F, 0x67, 0xFF);

        [DisplayName("Party Panel Background Color")]
        [Category("UI Colors")]
        [Display(Order = 252)]
        public ConfigColor PartyPanelBgColor { get; set; } = new ConfigColor(0xE9, 0x57, 0x80, 0xFF);

        [DisplayName("Button Prompt Fill Color (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 253)]
        public ConfigColor ButtonPromptHighlightColor { get; set; } = new ConfigColor(0xFF, 0x58, 0x6A, 0xFF);

        [DisplayName("Button Prompt Triangle Color")]
        [Category("UI Colors")]
        [Display(Order = 254)]
        public ConfigColor ButtonPromptTriangleColor { get; set; } = new ConfigColor(0xFF, 0x58, 0x6A, 0xFF);

        [DisplayName("Back Log Blackboard Color")]
        [Category("UI Colors")]
        [Display(Order = 255)]
        public ConfigColor BackLogBlackboardColor { get; set; } = new ConfigColor(0x25, 0x00, 0x16, 0xFF);

        [DisplayName("Back Log Haze Color")]
        [Category("UI Colors")]
        [Display(Order = 256)]
        public ConfigColor BackLogGladationColor { get; set; } = new ConfigColor(0xFF, 0x4A, 0x77, 0xFF);

        [DisplayName("Back Log Blueboard Color")]
        [Category("UI Colors")]
        [Display(Order = 257)]
        public ConfigColor BackLogBlueboardColorEx { get; set; } = new ConfigColor(0xFF, 0x4A, 0x77, 0xFF);

        [DisplayName("Back Log Title Color (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 258)]
        public ConfigColor BackLogTitleColor { get; set; } = new ConfigColor(0xFF, 0x4A, 0x88, 0xFF);

        [DisplayName("Back Log Text/Icon Color Selected")]
        [Category("UI Colors")]
        [Display(Order = 259)]
        public ConfigColor BackLogTexColorSelected { get; set; } = new ConfigColor(0xFF, 0x89, 0xA6, 0xFF);

        [DisplayName("Back Log Text/Icon Color Unselected")]
        [Category("UI Colors")]
        [Display(Order = 260)]
        public ConfigColor BackLogTexColorUnselectedEx { get; set; } = new ConfigColor(0xB6, 0x3F, 0x67, 0xFF);

        [DisplayName("Location Select Background Color")]
        [Category("UI Colors")]
        [Display(Order = 261)]
        public ConfigColor LocationSelectBgColor { get; set; } = new ConfigColor(0xFF, 0x58, 0x9F, 0xFF);

        [DisplayName("Location Select Marker Color")]
        [Category("UI Colors")]
        [Display(Order = 262)]
        public ConfigColor LocationSelectMarkerColor { get; set; } = new ConfigColor(0xFF, 0x4A, 0x94, 0xFF);

        [DisplayName("Location Select Selected Item Color (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 263)]
        public ConfigColor LocationSelectSelColor { get; set; } = new ConfigColor(0xFF, 0x58, 0x95, 0xFF);

        [DisplayName("Time Skip Color")]
        [Category("UI Colors")]
        [Display(Order = 264)]
        public ConfigColor TimeSkipColor { get; set; } = new ConfigColor(0xFF, 0x58, 0x8A, 0xFF);

        [DisplayName("Next Day Band Color")]
        [Category("UI Colors")]
        [Display(Order = 265)]
        public ConfigColor NextDayBandColor { get; set; } = new ConfigColor(0xB6, 0x3F, 0x67, 0xFF);

        [DisplayName("Next Day Text Color")]
        [Category("UI Colors")]
        [Display(Order = 266)]
        public ConfigColor NextDayTextColor { get; set; } = new ConfigColor(0xCD, 0x62, 0x89, 0xFF);

        [DisplayName("Next Day Moon Shadow Color")]
        [Category("UI Colors")]
        [Display(Order = 267)]
        public ConfigColor NextDayMoonShadowColor { get; set; } = new ConfigColor(0xA3, 0x26, 0x50, 0xFF);

        [DisplayName("Next Day Ripple")]
        [Category("UI Colors")]
        [Display(Order = 268)]
        public ConfigColor NextDayRipple { get; set; } = new ConfigColor(0xFF, 0x58, 0x6A, 0xFF);

        [DisplayName("Shop Payment Color")]
        [Category("UI Colors")]
        [Display(Order = 269)]
        public ConfigColor ShopPayColor { get; set; } = new ConfigColor(0xFF, 0xB3, 0xCA, 0xFF);

        [DisplayName("Shop Fill Color")]
        [Category("UI Colors")]
        [Display(Order = 270)]
        public ConfigColor ShopFillColor { get; set; } = new ConfigColor(0xFF, 0x58, 0xA4, 0xFF);

        [DisplayName("Shop Shadow Color")]
        [Category("UI Colors")]
        [Display(Order = 271)]
        public ConfigColor ShopShadowColor { get; set; } = new ConfigColor(0xB6, 0x15, 0x5C, 0xFF);

        [DisplayName("Shop Payment Unselect Color")]
        [Category("UI Colors")]
        [Display(Order = 272)]
        public ConfigColor ShopPayUnselColor { get; set; } = new ConfigColor(0xD4, 0x45, 0x92, 0xFF);

        [DisplayName("Get Item Background Mask Color")]
        [Category("UI Colors")]
        [Display(Order = 273)]
        public ConfigColor GetItemBgMaskColor { get; set; } = new ConfigColor(0x54, 0x0D, 0x54, 0xFF);

        [DisplayName("Get Item Background Color")]
        [Category("UI Colors")]
        [Display(Order = 274)]
        public ConfigColor GetItemBgColor { get; set; } = new ConfigColor(0xFF, 0x4A, 0x8E, 0xFF);

        [DisplayName("Get Item Got Text Color")]
        [Category("UI Colors")]
        [Display(Order = 275)]
        public ConfigColor GetItemGotTextColor { get; set; } = new ConfigColor(0xFF, 0x41, 0xC8, 0xFF);

        [DisplayName("Get Item Got Item Count Background")]
        [Category("UI Colors")]
        [Display(Order = 276)]
        public ConfigColor GetItemCountBgColor { get; set; } = new ConfigColor(0xFF, 0x58, 0x9A, 0xFF);

        [DisplayName("Mind Select: Selected Text Color")]
        [Category("UI Colors")]
        [Display(Order = 277)]
        public ConfigColor MindSelActiveTextColor { get; set; } = new ConfigColor(0xDE, 0x12, 0x74, 0xFF);

        [DisplayName("Mind Select Window Fill (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 278)]
        public ConfigColor MindSelWindowFill { get; set; } = new ConfigColor(0x34, 0x06, 0x1C, 0xFF);

        [DisplayName("Mind Select Window Border (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 279)]
        public ConfigColor MindSelWindowBorder { get; set; } = new ConfigColor(0x34, 0x06, 0x1C, 0xFF);

        [DisplayName("Mind Select Dot Color (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 280)]
        public ConfigColor MindSelectDotColor { get; set; } = new ConfigColor(0x67, 0x00, 0x00, 0xFF);

        [DisplayName("Generic Select Character Backplate Color ")]
        [Category("UI Colors")]
        [Display(Order = 281)]
        public ConfigColor GenericSelectCharacterBackplate { get; set; } = new ConfigColor(0xFF, 0x58, 0x8A, 0xFF);

        [DisplayName("Generic Select List Color Morning")]
        [Category("UI Colors")]
        [Display(Order = 282)]
        public ConfigColor GenericSelectListColorMorning { get; set; } = new ConfigColor(0xFF, 0x4A, 0x88, 0xFF);

        [DisplayName("Generic Select List Color After School")]
        [Category("UI Colors")]
        [Display(Order = 283)]
        public ConfigColor GenericSelectListColorAfterSchool { get; set; } = new ConfigColor(0xFF, 0x58, 0x9A, 0xFF);

        [DisplayName("Generic Select List Color Night")]
        [Category("UI Colors")]
        [Display(Order = 284)]
        public ConfigColor GenericSelectListColorNight { get; set; } = new ConfigColor(0xCD, 0x62, 0x9E, 0xFF);

        [DisplayName("Generic Select Title Color")]
        [Category("UI Colors")]
        [Display(Order = 285)]
        public ConfigColor GenericSelectTitle { get; set; } = new ConfigColor(0xFF, 0x58, 0x9F, 0xFF);

        [DisplayName("Generic Select Character Shadow (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 286)]
        public ConfigColor GenericSelectCharacterShadow { get; set; } = new ConfigColor(0xD4, 0x45, 0x80, 0xFF);

        [DisplayName("Message Box Select Text Color")]
        [Category("UI Colors")]
        [Display(Order = 287)]
        public ConfigColor MsgSimpleSelectTextColor { get; set; } = new ConfigColor(0xFF, 0x58, 0x95, 0xFF);

        [DisplayName("Message Box Select Box Shadow Color")]
        [Category("UI Colors")]
        [Display(Order = 288)]
        /*
        public ConfigColor MsgSimpleSelectBoxShadow { get; set; } = new ConfigColor(0xB6, 0x3F, 0x67, 0xFF);

        [DisplayName("Message Box Shadow Color")]
        [Category("UI Colors")]
        [Display(Order = 289)]
        */

        //THAT BASTARD DOES NOTHING ARE YOU KIDDING
        public ConfigColor MsgSimpleSelectShadowEx { get; set; } = new ConfigColor(0x49, 0x04, 0x21, 0xFF);

        [DisplayName("Message Box Border Color")]
        [Category("UI Colors")]
        [Display(Order = 290)]
        public ConfigColor MsgSimpleSelectBorderColorEx { get; set; } = new ConfigColor(0x49, 0x04, 0x21, 0xFF);

        [DisplayName("Message Box Fill Color")]
        [Category("UI Colors")]
        public ConfigColor MsgSimpleFillColor { get; set; } = new ConfigColor(0xD4, 0x15, 0x5F, 0xFF);

        [DisplayName("System Message Light Color (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 291)]
        public ConfigColor MsgSimpleSystemLightColor { get; set; } = new ConfigColor(0xFF, 0x58, 0x8A, 0xFF);

        [DisplayName("System Message Dark Color")]
        [Category("UI Colors")]
        [Display(Order = 292)]
        public ConfigColor MsgSimpleSystemDarkColor { get; set; } = new ConfigColor(0x2F, 0x00, 0x1C, 0xFF);

        [DisplayName("System Message Dark Haze Color")]
        [Category("UI Colors")]
        [Display(Order = 293)]
        public ConfigColor MsgSimpleSystemGradationColor { get; set; } = new ConfigColor(0x49, 0x04, 0x28, 0xFF);

        [DisplayName("Persona Status Skill List Background Top Left")]
        [Category("UI Colors")]
        [Display(Order = 294)]
        public ConfigColor PersonaStatusSkillListBg { get; set; } = new ConfigColor(0x2A, 0x00, 0x1D, 0xFF);

        [DisplayName("Persona Status Skill List Background Lower Line")]
        [Category("UI Colors")]
        [Display(Order = 295)]
        public ConfigColor PersonaStatusSkillListBg2 { get; set; } = new ConfigColor(0xE9, 0x47, 0x7E, 0xFF);

        [DisplayName("Persona Status Skill List Checkerboard")]
        [Category("UI Colors")]
        [Display(Order = 296)]
        public ConfigColor PersonaStatusSkillListCheckboardAlt { get; set; } = new ConfigColor(0x55, 0x1F, 0x3F, 0xFF);

        [DisplayName("Persona Status Skill List Next Skill Color")]
        [Category("UI Colors")]
        [Display(Order = 297)]
        public ConfigColor PersonaSkillListNextSkillColor { get; set; } = new ConfigColor(0xFB, 0x67, 0x96, 0xFF);

        [DisplayName("Persona Status Skill List Level Color")]
        [Category("UI Colors")]
        [Display(Order = 298)]
        public ConfigColor PersonaSkillListNextLevelColor { get; set; } = new ConfigColor(0xFF, 0xE2, 0x89, 0xFF);

        [DisplayName("Persona Status Skill List Next Skill Name Color")]
        [Category("UI Colors")]
        [Display(Order = 299)]
        public ConfigColor PersonaSkillListNextSkillInfoName { get; set; } = new ConfigColor(0xFF, 0xDD, 0x9B, 0xFF);

        [DisplayName("Persona Status Info Color")]
        [Category("UI Colors")]
        [Display(Order = 300)]
        public ConfigColor PersonaStatusPlayerInfoColor { get; set; } = new ConfigColor(0xFF, 0xF5, 0x9E, 0xFF);

        [DisplayName("Persona Status Info Selected Persona Color 1")]
        [Category("UI Colors")]
        [Display(Order = 301)]
        public ConfigColor PersonaStatusInfoSelPersonaColor1 { get; set; } = new ConfigColor(0xFF, 0xF5, 0x9E, 0xFF);

        [DisplayName("Persona Status Info Selected Persona Color 2")]
        [Category("UI Colors")]
        [Display(Order = 302)]
        public ConfigColor PersonaStatusInfoSelPersonaColor2 { get; set; } = new ConfigColor(0xE0, 0x3F, 0x74, 0xFF);

        [DisplayName("Persona Status Param Background Color")]
        [Category("UI Colors")]
        [Display(Order = 303)]
        public ConfigColor PersonaStatusParamColor { get; set; } = new ConfigColor(0xF4, 0x5A, 0x85, 0xFF);

        [DisplayName("Persona Status Lore Title Color")]
        [Category("UI Colors")]
        [Display(Order = 304)]
        public ConfigColor PersonaStatusCommentaryTitleColor { get; set; } = new ConfigColor(0xFF, 0xE2, 0x9E, 0xFF);

        [DisplayName("Persona Status Base Stat Color")]
        [Category("UI Colors")]
        [Display(Order = 305)]
        public ConfigColor PersonaStatusBaseStat { get; set; } = new ConfigColor(0xFF, 0xE2, 0x9E, 0xFF);

        [DisplayName("Persona Status Skill Affinity Outline Color (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 306)]
        public ConfigColor PersonaStatusAttributeOutline { get; set; } = new ConfigColor(0xE9, 0x47, 0x7E, 0xFF);

        [DisplayName("Network: Daily Action Sticky Note Background Color 1")]
        [Category("UI Colors")]
        [Display(Order = 307)]
        public ConfigColor NetworkDailyActionStickyNoteBgColor1 { get; set; } = new ConfigColor(0xD8, 0x3D, 0x8F, 0xFF);

        [DisplayName("Network: Daily Action Sticky Note Background Color 2")]
        [Category("UI Colors")]
        [Display(Order = 308)]
        public ConfigColor NetworkDailyActionStickyNoteBgColor2 { get; set; } = new ConfigColor(0xFF, 0x58, 0x8F, 0xFF);

        [DisplayName("Network: Daily Action Sticky Note Dotpoint Color 1")]
        [Category("UI Colors")]
        [Display(Order = 309)]
        public ConfigColor NetworkDailyActionStickyNoteDotColor1 { get; set; } = new ConfigColor(0xFE, 0x9D, 0xB6, 0xFF);

        [DisplayName("Network: Daily Action Sticky Note Dotpoint Color 2")]
        [Category("UI Colors")]
        [Display(Order = 310)]
        public ConfigColor NetworkDailyActionStickyNoteDotColor2 { get; set; } = new ConfigColor(0xFF, 0x89, 0xB5, 0xFF);

        [DisplayName("Network: Daily Action Sticky Note Text Color 1")]
        [Category("UI Colors")]
        [Display(Order = 311)]
        public ConfigColor NetworkDailyActionStickyNoteTextColor1 { get; set; } = new ConfigColor(0xFF, 0xD1, 0xDC, 0xFF);

        [DisplayName("Network: Daily Action Sticky Note Text Color 2")]
        [Category("UI Colors")]
        [Display(Order = 312)]
        public ConfigColor NetworkDailyActionStickyNoteTextColor2 { get; set; } = new ConfigColor(0xFF, 0xBD, 0xCE, 0xFF);

        [DisplayName("Network: Daily Action Blue Background Color")]
        [Category("UI Colors")]
        [Display(Order = 313)]
        public ConfigColor NetworkDailyActionBlueBgColor { get; set; } = new ConfigColor(0xD4, 0x45, 0x92, 0xFF);

        [DisplayName("Network: Daily Action Network Icon Color")]
        [Category("UI Colors")]
        [Display(Order = 314)]
        public ConfigColor NetworkDailyActionNetworkIcon { get; set; } = new ConfigColor(0xFF, 0x58, 0x8F, 0xFF);

        [DisplayName("Simple Shop: Info Color")]
        [Category("UI Colors")]
        [Display(Order = 315)]
        public ConfigColor SimpleShopInfoColor { get; set; } = new ConfigColor(0xFF, 0x58, 0x6A, 0xFF);

        [DisplayName("Cutin: Outer Highlight Color")]
        [Category("UI Colors")]
        [Display(Order = 316)]
        public ConfigColor CutinOuterHighlight { get; set; } = new ConfigColor(0xFF, 0x4A, 0x8E, 0xFF);

        [DisplayName("Cutin: Emotion Gradient Color")]
        [Category("UI Colors")]
        [Display(Order = 317)]
        public ConfigColor CutinEmotionGradient { get; set; } = new ConfigColor(0xFF, 0x89, 0xA6, 0xFF);

        [DisplayName("Cutin: Emotion Tint Color")]
        [Category("UI Colors")]
        [Display(Order = 318)]
        public ConfigColor CutinEmotionTint { get; set; } = new ConfigColor(0xFF, 0x4A, 0x8E, 0xFF);

        [DisplayName("Title Menu: Select Rectangle Color")]
        [Category("UI Colors")]
        [Display(Order = 319)]
        public ConfigColor TitleMenuSelRectColor { get; set; } = new ConfigColor(0xFF, 0x58, 0x92, 0xFF);

        [DisplayName("Localization Staff Roll: Header Color (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 320)]
        public ConfigColor LocalStaffRollHeader { get; set; } = new ConfigColor(0xFF, 0x89, 0xA6, 0xFF);

        [DisplayName("Difficulty Selection Background")]
        [Category("UI Colors")]
        [Display(Order = 321)]
        public ConfigColor DifficultySelectBgColor { get; set; } = new ConfigColor(0x49, 0x04, 0x21, 0xFF);

        [DisplayName("Wipe Background")]
        [Category("UI Colors")]
        [Display(Order = 322)]
        public ConfigColor WipeBgColor { get; set; } = new ConfigColor(0x49, 0x04, 0x27, 0xFF);

        [DisplayName("Camp Equip: Item Stat Value Padding Color")]
        [Category("UI Colors")]
        [Display(Order = 323)]
        public ConfigColor CampItemStatValuePadColor { get; set; } = new ConfigColor(0xBC, 0x81, 0x5D, 0xFF);

        [DisplayName("Camp Equip: Item Stat Value Padding Color")]
        [Category("UI Colors")]
        [Display(Order = 324)]
        public ConfigColor CampItemStatValueValColor { get; set; } = new ConfigColor(0xFE, 0xE6, 0xAD, 0xFF);

        [DisplayName("Camp Equip: Overview List Type Color")]
        [Category("UI Colors")]
        [Display(Order = 325)]
        public ConfigColor CampEquipOverviewListType { get; set; } = new ConfigColor(0xF6, 0xCD, 0x95, 0xFF);

        [DisplayName("Camp Persona: Arcana Phrase Color (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 326)]
        public ConfigColor CampPersonaArcanaPhraseColor { get; set; } = new ConfigColor(0xFF, 0xF5, 0x9E, 0xFF);

        [DisplayName("Camp Persona: Name Color")]
        [Category("UI Colors")]
        [Display(Order = 327)]
        public ConfigColor CampPersonaNameColor { get; set; } = new ConfigColor(0xFF, 0xF5, 0x9E, 0xFF);

        [DisplayName("Camp Persona: Arcana Background Color")]
        [Category("UI Colors")]
        [Display(Order = 328)]
        public ConfigColor CampPersonaArcanaBgColor { get; set; } = new ConfigColor(0x49, 0x04, 0x21, 0xFF);

        [DisplayName("Camp Status: Kotone Line Color")]
        [Category("UI Colors")]
        [Display(Order = 329)]
        public ConfigColor CampStatusKotoneLineColor { get; set; } = new ConfigColor(0xFF, 0x89, 0xA6, 0xFF);

        [DisplayName("Camp Status: Inactive Party Member Background (Tartarus)")]
        [Category("UI Colors")]
        [Display(Order = 330)]
        public ConfigColor CampStatusInactiveMemberBgTartarus { get; set; } = new ConfigColor(0x63, 0x27, 0x3E, 0xFF);

        [DisplayName("Camp Status: Inactive Member Details Pale Pink (Tartarus)")]
        [Category("UI Colors")]
        [Display(Order = 331)]
        public ConfigColor CampStatusInactiveMemberDetailsPalePinkTartarus { get; set; } = new ConfigColor(0xED, 0xC0, 0xD8, 0xFF);

        [DisplayName("Camp Status: Inactive Member Details Dark Pink (Tartarus)")]
        [Category("UI Colors")]
        [Display(Order = 332)]
        public ConfigColor CampStatusInactiveMemberDetailsDarkPinkTartarus { get; set; } = new ConfigColor(0x78, 0x19, 0x46, 0xFF);

        [DisplayName("Camp Status: Inactive Member HP Bar (Tartarus)")]
        [Category("UI Colors")]
        [Display(Order = 333)]
        public ConfigColor CampStatusInactiveMemberHPBarTartarus { get; set; } = new ConfigColor(0x8B, 0x0D, 0x51, 0xFF);

        [DisplayName("Town Map: Location Details Background Tint")]
        [Category("UI Colors")]
        [Display(Order = 334)]
        public ConfigColor TownMapLocationDetailsBgTint { get; set; } = new ConfigColor(0xDD, 0x74, 0xA1, 0xFF);

        [DisplayName("Town Map: Location Details Top Left Bg")]
        [Category("UI Colors")]
        [Display(Order = 335)]
        public ConfigColor TownMapLocationDetailsTopLeftBg { get; set; } = new ConfigColor(0xF4, 0x41, 0x7F, 0xFF);

        [DisplayName("Town Map: Location Details Top Left Text")]
        [Category("UI Colors")]
        [Display(Order = 336)]
        public ConfigColor TownMapLocationDetailsTopLeftText { get; set; } = new ConfigColor(0xA7, 0x1D, 0x5B, 0xFF);

        [DisplayName("Town Map: Selected Marker Outline")]
        [Category("UI Colors")]
        [Display(Order = 337)]
        public ConfigColor TownMapSelectedMarkerOutline { get; set; } = new ConfigColor(0xFF, 0x4A, 0x77, 0xFF);

        [DisplayName("Social Stats: Stats Up Text")]
        [Category("UI Colors")]
        [Display(Order = 338)]
        public ConfigColor SocialStatsUpText { get; set; } = new ConfigColor(0xFF, 0xE7, 0xAD, 0xFF);

        [DisplayName("Social Stats: Stat Up Pulse Circle Color")]
        [Category("UI Colors")]
        [Display(Order = 339)]
        public ConfigColor SocialStatsPulseCircleColorMain { get; set; } = new ConfigColor(0xFF, 0xE7, 0xAD, 0xFF);

        [DisplayName("Social Stats: Stat Up Pulse Circle Fade")]
        [Category("UI Colors")]
        [Display(Order = 340)]
        public ConfigColor SocialStatsPulseCircleColorFade { get; set; } = new ConfigColor(0xFF, 0x58, 0x6A, 0xFF);

        [DisplayName("Assist Message Box: Text Background")]
        [Category("UI Colors")]
        [Display(Order = 341)]
        public ConfigColor MsgAssistTextBgColor { get; set; } = new ConfigColor(0x49, 0x04, 0x21, 0xFF);

        [DisplayName("Location Select: Map Background Color")]
        [Category("UI Colors")]
        [Display(Order = 342)]
        public ConfigColor LocationSelMapBg { get; set; } = new ConfigColor(0x5B, 0x2B, 0x41, 0xFF);

        [DisplayName("Location Select: Map Label Color")]
        [Category("UI Colors")]
        [Display(Order = 343)]
        public ConfigColor LocationSelMapLabel { get; set; } = new ConfigColor(0x1F, 0x11, 0x17, 0xFF);

        [DisplayName("System Message Picture Border Color (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 344)]
        public ConfigColor MsgSystemPicBorderColor { get; set; } = new ConfigColor(0xB6, 0x3F, 0x7A, 0xFF);

        [DisplayName("Tutorial List Entry Color (Requires Restart)")]
        [Category("UI Colors")]
        [Display(Order = 345)]
        public ConfigColor TutorialListEntryColor { get; set; } = new ConfigColor(0xFF, 0xE4, 0xA3, 0xFF);

        [DisplayName("Tutorial List Background Color")]
        [Category("UI Colors")]
        [Display(Order = 346)]
        public ConfigColor TutorialBgColor { get; set; } = new ConfigColor(0x49, 0x04, 0x28, 0xFF);

        [DisplayName("Missing Person: Selected Person \"Last Sighted\" Color")]
        [Category("UI Colors")]
        [Display(Order = 347)]
        public ConfigColor MissingLastSighted { get; set; } = new ConfigColor(0xFF, 0x89, 0xA6, 0xFF);

        [DisplayName("Missing Person: Page Background")]
        [Category("UI Colors")]
        [Display(Order = 348)]
        public ConfigColor MissingPageBg { get; set; } = new ConfigColor(0x49, 0x04, 0x21, 0xFF);

        [DisplayName("Missing Person: Light Text Color")]
        [Category("UI Colors")]
        [Display(Order = 349)]
        public ConfigColor MissingTextLight { get; set; } = new ConfigColor(0xFF, 0x89, 0xA6, 0xFF);

        [DisplayName("Missing Person: Dark Text Color")]
        [Category("UI Colors")]
        [Display(Order = 350)]
        public ConfigColor MissingTextDark { get; set; } = new ConfigColor(0x49, 0x04, 0x21, 0xFF);

        [DisplayName("Request/Missing Person: Sort by Triangle")]
        [Category("Ui Colors")]
        [Display(Order = 351)]
        public ConfigColor MissingSortTriangle { get; set; } = new ConfigColor(0xFF, 0x86, 0x83, 0xFF);


        //silly edits

        [DisplayName("Camp: Waves Top A Color")]
        [Category("UI Colors")]
        [Display(Order = 352)]
        public ConfigColor NamiTopAColor { get; set; } = new ConfigColor(0xF4, 0xE2, 0xB6, 0xFF);

        [DisplayName("Camp: Waves Top B Color")]
        [Category("UI Colors")]
        [Display(Order = 353)]
        public ConfigColor NamiTopBColor { get; set; } = new ConfigColor(0xCD, 0xC9, 0xB7, 0xFF);

        [DisplayName("Camp: Waves Skill A Color")]
        [Category("UI Colors")]
        [Display(Order = 354)]
        public ConfigColor NamiSkillAColor { get; set; } = new ConfigColor(0xFF, 0xE5, 0xA9, 0xFF);

        [DisplayName("Camp: Waves Skill B Color")]
        [Category("UI Colors")]
        [Display(Order = 355)]
        public ConfigColor NamiSkillBColor { get; set; } = new ConfigColor(0xFF, 0xE5, 0xA9, 0xFF);

        [DisplayName("Camp: Waves Item A Color")]
        [Category("UI Colors")]
        [Display(Order = 356)]
        public ConfigColor NamiItemAColor { get; set; } = new ConfigColor(0xFF, 0xE5, 0xA9, 0xFF);

        [DisplayName("Camp: Waves Item B Color")]
        [Category("UI Colors")]
        [Display(Order = 357)]
        public ConfigColor NamiItemBColor { get; set; } = new ConfigColor(0xFF, 0xE5, 0xA9, 0xFF);

        [DisplayName("Camp: Waves Equip A Color")]
        [Category("UI Colors")]
        [Display(Order = 358)]
        public ConfigColor NamiEquipAColor { get; set; } = new ConfigColor(0xF4, 0xE2, 0xB6, 0xFF);

        [DisplayName("Camp: Waves Equip B Color")]
        [Category("UI Colors")]
        [Display(Order = 359)]
        public ConfigColor NamiEquipBColor { get; set; } = new ConfigColor(0xFD, 0xB3, 0x9D, 0xFF);

        [DisplayName("Camp: Waves Persona A Color")]
        [Category("UI Colors")]
        [Display(Order = 360)]
        public ConfigColor NamiPersonaAColor { get; set; } = new ConfigColor(0xFF, 0xE5, 0xA9, 0xFF);

        [DisplayName("Camp: Waves Persona B Color")]
        [Category("UI Colors")]
        [Display(Order = 361)]
        public ConfigColor NamiPersonaBColor { get; set; } = new ConfigColor(0xFF, 0xE5, 0xA9, 0xFF);

        [DisplayName("Camp: Waves Status A Color")]
        [Category("UI Colors")]
        [Display(Order = 362)]
        public ConfigColor NamiStatusAColor { get; set; } = new ConfigColor(0xF4, 0xE2, 0xB6, 0xFF);

        [DisplayName("Camp: Waves Status B Color")]
        [Category("UI Colors")]
        [Display(Order = 363)]
        public ConfigColor NamiStatusBColor { get; set; } = new ConfigColor(0xFD, 0xB3, 0x9D, 0xFF);

        [DisplayName("Camp: Waves Quest A Color")]
        [Category("UI Colors")]
        [Display(Order = 364)]
        public ConfigColor NamiQuestAColor { get; set; } = new ConfigColor(0xF4, 0xE2, 0xB6, 0xFF);

        [DisplayName("Camp: Waves Quest B Color")]
        [Category("UI Colors")]
        [Display(Order = 365)]
        public ConfigColor NamiQuestBColor { get; set; } = new ConfigColor(0xFD, 0xB3, 0x9D, 0xFF);

        [DisplayName("Camp: Waves Commu A Color")]
        [Category("UI Colors")]
        [Display(Order = 366)]
        public ConfigColor NamiCommuAColor { get; set; } = new ConfigColor(0xF4, 0xE2, 0xB6, 0xFF);

        [DisplayName("Camp: Waves Commu B Color")]
        [Category("UI Colors")]
        [Display(Order = 367)]
        public ConfigColor NamiCommuBColor { get; set; } = new ConfigColor(0xFD, 0xB3, 0x9D, 0xFF);

        [DisplayName("Camp: Waves Calendar A Color")]
        [Category("UI Colors")]
        [Display(Order = 368)]
        public ConfigColor NamiCalendarAColor { get; set; } = new ConfigColor(0xF4, 0xE2, 0xB6, 0xFF);

        [DisplayName("Camp: Waves Calendar B Color")]
        [Category("UI Colors")]
        [Display(Order = 369)]
        public ConfigColor NamiCalendarBColor { get; set; } = new ConfigColor(0xFD, 0xB3, 0x9D, 0xFF);

        [DisplayName("Camp: Waves System A Color")]
        [Category("UI Colors")]
        [Display(Order = 370)]
        public ConfigColor NamiSystemAColor { get; set; } = new ConfigColor(0xFF, 0xE5, 0xA9, 0xFF);

        [DisplayName("Camp: Waves System B Color")]
        [Category("UI Colors")]
        [Display(Order = 371)]
        public ConfigColor NamiSystemBColor { get; set; } = new ConfigColor(0xFF, 0xE5, 0xA9, 0xFF);

        [DisplayName("Camp: Waves Tutorial A Color")]
        [Category("UI Colors")]
        [Display(Order = 372)]
        public ConfigColor NamiTutorialAColor { get; set; } = new ConfigColor(0xF4, 0xE2, 0xB6, 0xFF);

        [DisplayName("Camp: Waves Tutorial B Color")]
        [Category("UI Colors")]
        [Display(Order = 373)]
        public ConfigColor NamiTutorialBColor { get; set; } = new ConfigColor(0xFF, 0xB7, 0x97, 0xFF);

        [DisplayName("Camp: Waves Config A Color")]
        [Category("UI Colors")]
        [Display(Order = 374)]
        public ConfigColor NamiConfigAColor { get; set; } = new ConfigColor(0xF4, 0xE2, 0xB6, 0xFF);

        [DisplayName("Camp: Waves Config B Color")]
        [Category("UI Colors")]
        [Display(Order = 375)]
        public ConfigColor NamiConfigBColor { get; set; } = new ConfigColor(0xFF, 0xD3, 0xB5, 0xFF);

        // silly edits end

        [DisplayName("Camp: GradAUpColorHigh")]
        [Category("UI Colors")]
        [Display(Order = 376)]
        public ConfigColor GradAUpColorHigh { get; set; } = new ConfigColor(0xFF, 0xFF, 0xFF, 0xFF);

        [DisplayName("Camp: GradBUpColorHigh")]
        [Category("UI Colors")]
        [Display(Order = 377)]
        public ConfigColor GradBUpColorHigh { get; set; } = new ConfigColor(0x64, 0xFF, 0x3B, 0xFF);

        [DisplayName("Camp: GradBDownColorHigh")]
        [Category("UI Colors")]
        [Display(Order = 378)]
        public ConfigColor GradBDownColorHigh { get; set; } = new ConfigColor(0xFF, 0xCE, 0xAA, 0xFF);

        [DisplayName("Camp: GradAUpColorMid")]
        [Category("UI Colors")]
        [Display(Order = 379)]
        public ConfigColor GradAUpColorMid { get; set; } = new ConfigColor(0xFF, 0xFF, 0xFF, 0xFF);

        [DisplayName("Camp: GradBUpColorMid")]
        [Category("UI Colors")]
        [Display(Order = 380)]
        public ConfigColor GradBUpColorMid { get; set; } = new ConfigColor(0xFF, 0xEA, 0x00, 0xFF);

        [DisplayName("Camp: GradBDownColorMid")]
        [Category("UI Colors")]
        [Display(Order = 381)]
        public ConfigColor GradBDownColorMid { get; set; } = new ConfigColor(0xFF, 0xD1, 0x00, 0xFF);

        [DisplayName("Camp: GradAUpColorLow")]
        [Category("UI Colors")]
        [Display(Order = 382)]
        public ConfigColor GradAUpColorLow { get; set; } = new ConfigColor(0xFF, 0xFF, 0xFF, 0xFF);

        [DisplayName("Camp: GradBUpColorLow")]
        [Category("UI Colors")]
        [Display(Order = 383)]
        public ConfigColor GradBUpColorLow { get; set; } = new ConfigColor(0xFF, 0x00, 0x00, 0xFF);

        [DisplayName("Camp: GradBDownColorLow")]
        [Category("UI Colors")]
        [Display(Order = 384)]
        public ConfigColor GradBDownColorLow { get; set; } = new ConfigColor(0xFF, 0x00, 0x00, 0xFF);

        [DisplayName("Camp: HeroCaptureBgColor")]
        [Category("UI Colors")]
        [Display(Order = 385)]
        public ConfigColor HeroCaptureBgColor { get; set; } = new ConfigColor(0xE8, 0x64, 0xBC, 0xFF);

        // sillies

        [DisplayName("Missing Person: Shadows Femc and Chairs in Detail Color")]
        public ConfigColor MissingDetailFemcChairsShadow { get; set; } = new ConfigColor(0x36, 0x0C, 0x18, 0xFF);

        [DisplayName("Request: Back Card Color")]
        public ConfigColor RequestBackCard { get; set; } = new ConfigColor(0x60, 0x00, 0x2A, 0xFF);

        [DisplayName("Request: Back Squares Color")]
        public ConfigColor RequestBackSquares { get; set; } = new ConfigColor(0x38, 0x00, 0x19, 0xFF);

        [DisplayName("Request: Back Card Detail Color")]
        public ConfigColor RequestBackCardDetail { get; set; } = new ConfigColor(0x2E, 0x09, 0x19, 0xFF);

        [DisplayName("Request: Back Card Detail Right Down Solid Color")]
        public ConfigColor RequestBackCardRightDownDetail { get; set; } = new ConfigColor(0x5D, 0x00, 0x2C, 0xFF);

        [DisplayName("Camp: Quest shadows Femc and Chairs in Detail Color")]
        public ConfigColor RequestDetailFemcChairsShadow { get; set; } = new ConfigColor(0x48, 0x11, 0x23, 0xFF);

        [DisplayName("Request: 'Task' Font Color")]
        public ConfigColor RequestTaskFont { get; set; } = new ConfigColor(0xFF, 0xC8, 0x91, 0xFF);

        [DisplayName("Request: Detail 'Request Details' Font Color")]
        public ConfigColor RequestDetailsFont { get; set; } = new ConfigColor(0xFF, 0xE7, 0xAD, 0xFF);

        [DisplayName("Request: Detail 'Complete' Tag Color")]
        public ConfigColor RequestDetailCompleted { get; set; } = new ConfigColor(0x43, 0x0D, 0x1B, 0xFF);

        [DisplayName("Request: Detail Background 'Complete' Tag Color")]
        public ConfigColor RequestDetailBackgroundCompleted { get; set; } = new ConfigColor(0x8C, 0x09, 0x3D, 0xFF);

        [DisplayName("Request: Detail 'Earned' Tag Color")]
        public ConfigColor RequestDetailEarned { get; set; } = new ConfigColor(0xFF, 0xD3, 0x91, 0xFF);

        [DisplayName("Request: Detail Difficulty Rank Upper Part Color")]
        public ConfigColor RequestDifficultyRankUp { get; set; } = new ConfigColor(0x17, 0x03, 0x0C, 0xFF);

        [DisplayName("Request: Detail Difficulty Rank Lower Part Color")]
        public ConfigColor RequestDifficultyRankDown { get; set; } = new ConfigColor(0x41, 0x03, 0x22, 0xFF);

        [DisplayName("Request: Detail Difficulty Butterfly Indicator Color")]
        public ConfigColor RequestDifficultyIndicator { get; set; } = new ConfigColor(0x71, 0x0D, 0x3E, 0xFF);

        [DisplayName("Request: Detail Difficulty Font Color")]
        public ConfigColor RequestDifficultyFont { get; set; } = new ConfigColor(0x7D, 0x25, 0x36, 0xFF);

        [DisplayName("Request: Status Light Font, Tag Background and ! color in report quest icon")]
        public ConfigColor RequestStatusFontTagBack { get; set; } = new ConfigColor(0xFF, 0xE7, 0xAD, 0xFF);

        [DisplayName("Request: Status Tag Font Color")]
        public ConfigColor RequestStatusTagFont { get; set; } = new ConfigColor(0x68, 0x01, 0x3D, 0xFF);

        [DisplayName("Request: Status Tag Underlay Color")]
        public ConfigColor RequestStatusTagUnderlay { get; set; } = new ConfigColor(0x6A, 0x00, 0x42, 0xFF);

        [DisplayName("Social Stats: Musical Notes Color")]
        public ConfigColor MusicNotesColor { get; set; } = new ConfigColor(0xFF, 0x8F, 0xB6, 0xFF);

        [DisplayName("Camp: Party Panel Missing Health/SP Color")]
        public ConfigColor PartyPanelMissingHealthSp { get; set; } = new ConfigColor(0x68, 0x01, 0x08, 0xFF);

        [DisplayName("Camp: Transition between menus color")]
        public ConfigColor CampColorTransition { get; set; } = new ConfigColor(0xFF, 0x89, 0xA6, 0xFF);

        [DisplayName("Camp: Skill Card Sub Menu Background Color")]
        public ConfigColor CampSkillCardBackground { get; set; } = new ConfigColor(0x78, 0x68, 0x6F, 0xFF);

        [DisplayName("Camp: Skill Card Sub Menu Frame Color")]
        public ConfigColor CampSkillCardFrame { get; set; } = new ConfigColor(0x65, 0x35, 0x48, 0xFF);

        [DisplayName("Camp: Skill Card Femc Sub Menu Color")]
        public ConfigColor CampSkillCardFemc { get; set; } = new ConfigColor(0x21, 0x08, 0x12, 0xFF);

        [DisplayName("Camp: Femc Shadow Color")]
        public ConfigColor CampFemcShadow { get; set; } = new ConfigColor(0xB7, 0x9A, 0xA0, 0xFF);

        [DisplayName("Camp: Highlighted selection color high")]
        public ConfigColor CampHighlightedColor { get; set; } = new ConfigColor(0x32, 0xBE, 0xFF, 0xFF);

        [DisplayName("Camp: Highlighted selection color lower high")]
        public ConfigColor CampHighlightedLowerColor { get; set; } = new ConfigColor(0x00, 0xD8, 0xFF, 0xFF);

        [DisplayName("Camp: Highlighted selection color middle (involves highlighted party member with lower high)")]
        public ConfigColor CampHighlightedMidColor { get; set; } = new ConfigColor(0x00, 0x00, 0x00, 0xFF);

        [DisplayName("Camp: Social Link Arcana selection color")]
        public ConfigColor CampSocialLinkArcanaHighlightedColor { get; set; } = new ConfigColor(0x6D, 0x03, 0x0D, 0x7F);

        [DisplayName("Camp: System falling words starting color")]
        public ConfigColor CampSystemStartFallingWordsColor { get; set; } = new ConfigColor(0x86, 0x02, 0x4B, 0xFF);

        [DisplayName("Camp: System falling words end color")]
        public ConfigColor CampSystemEndFallingWordsColor { get; set; } = new ConfigColor(0xA6, 0x09, 0x6F, 0xFF);

        [DisplayName("Camp Equip: Square Background")]
        public ConfigColor EquipSquareBack { get; set; } = new ConfigColor(0x49, 0x04, 0x2E, 0xFF);

        [DisplayName("Camp Equip: Menu title inside square color")]
        public ConfigColor EquipTitleBackground { get; set; } = new ConfigColor(0x3B, 0x02, 0x25, 0xFF);

        [DisplayName("Camp Equip: 'Effect' font color in equipment description")]
        public ConfigColor EquipEffectColor { get; set; } = new ConfigColor(0x55, 0x1F, 0x3B, 0xFF);

        [DisplayName("Camp: In-game screenshot color filter curve keyframe 1")]
        public ConfigColor CampScreenshotFilterKeyframe1 { get; set; } = new ConfigColor(0x0C, 0x01, 0x05, 0xFF);

        [DisplayName("Camp: In-game screenshot color filter curve keyframe 2")]
        public ConfigColor CampScreenshotFilterKeyframe2 { get; set; } = new ConfigColor(0xCC, 0x19, 0x52, 0xFF);

        [DisplayName("Camp: In-game screenshot color filter curve keyframe 3")]
        public ConfigColor CampScreenshotFilterKeyframe3 { get; set; } = new ConfigColor(0xF2, 0x26, 0x67, 0xFF);

        [DisplayName("Camp: In-game screenshot color filter curve keyframe 4")]
        public ConfigColor CampScreenshotFilterKeyframe4 { get; set; } = new ConfigColor(0xFF, 0xFF, 0xFF, 0xFF);

        [DisplayName("Camp: Shards color curve keyframe 1")]
        public ConfigColor CampShardsKeyframe1 { get; set; } = new ConfigColor(0xFF, 0x4D, 0x70, 0x66);

        [DisplayName("Camp: Shards color curve keyframe 2")]
        public ConfigColor CampShardsKeyframe2 { get; set; } = new ConfigColor(0x64, 0x96, 0xFB, 0xD6);

        [DisplayName("Camp: Shards color curve keyframe 3")]
        public ConfigColor CampShardsKeyframe3 { get; set; } = new ConfigColor(0x7E, 0x80, 0xFB, 0xF5);

        [DisplayName("Camp: Shards color curve keyframe 4")]
        public ConfigColor CampShardsKeyframe4 { get; set; } = new ConfigColor(0xFF, 0x83, 0x8A, 0xFF);

        [DisplayName("Camp: Shards color curve keyframe 5")]
        public ConfigColor CampShardsKeyframe5 { get; set; } = new ConfigColor(0xFF, 0xC5, 0x85, 0xDF);

        [DisplayName("Camp: Shards color curve keyframe 6")]
        public ConfigColor CampShardsKeyframe6 { get; set; } = new ConfigColor(0xB8, 0x1C, 0x3B, 0xCB);

        [DisplayName("Camp: Shards color curve keyframe 7")]
        public ConfigColor CampShardsKeyframe7 { get; set; } = new ConfigColor(0xED, 0x5F, 0x9D, 0xA9);

        [DisplayName("Camp: Quest shadows Femc and Chairs Color")]
        public ConfigColor QuestFemcChairsShadow { get; set; } = new ConfigColor(0x58, 0x0F, 0x36, 0xFF);

        [DisplayName("Camp: Main Toggler Background Color")]
        public ConfigColor MainToggler { get; set; } = new ConfigColor(0x2E, 0x09, 0x17, 0xFF);

        [DisplayName("Camp: Secondary Toggler Background Color")]
        public ConfigColor SecondaryToggler { get; set; } = new ConfigColor(0x2F, 0x12, 0x1E, 0xFF);

        [DisplayName("Persona Status: Highlighted selection color")]
        public ConfigColor PersonaStatusHighlightedColor { get; set; } = new ConfigColor(0x00, 0xD8, 0xFF, 0x99);

        [DisplayName("Persona Status: Skill Card Skill Background color")]
        public ConfigColor SkillCardSkillBg { get; set; } = new ConfigColor(0x66, 0x2B, 0x47, 0xFF);

        [DisplayName("Persona Status: Skill Card Selected Skill animation color")]
        public ConfigColor SkillCardSelectedSkillAnimation { get; set; } = new ConfigColor(0xD1, 0x62, 0x87, 0xFF);

        [DisplayName("Persona Status: Skill Description Main Background color")]
        public ConfigColor SkillDescriptionMainBg { get; set; } = new ConfigColor(0x57, 0x21, 0x3D, 0xFF);

        [DisplayName("Persona Status: Skill Description Corner and Title Background color")]
        public ConfigColor SkillDescriptionCornerBg { get; set; } = new ConfigColor(0x7D, 0x4D, 0x66, 0xFF);

        [DisplayName("Persona Status: --NONE-- skill color")]
        public ConfigColor NoneSkillColor { get; set; } = new ConfigColor(0x9F, 0x83, 0x8C, 0xFF);

        [DisplayName("Persona Status: Selected skill font color")]
        public ConfigColor SelectedSkillFontColor { get; set; } = new ConfigColor(0x2A, 0x00, 0x12, 0xFF);

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
        public ConfigColor FusionTopRightIndicatorColors { get; set; } = new ConfigColor(0xFF, 0xBD, 0xCE, 0xFF);

        [DisplayName("Battle: Squares colors from battle result animation")]
        public ConfigColor BtlResultSquaresColor { get; set; } = new ConfigColor(0xD1, 0x00, 0x5A, 0xFF);

        [DisplayName("Party Panel Femc Background Color")]
        public ConfigColor PartyPanelFemcBgColor { get; set; } = new ConfigColor(0xFF, 0x89, 0xA6, 0xFF);

        [DisplayName("Request/Missing Person: Column titles color")]
        public ConfigColor DataColumnColor { get; set; } = new ConfigColor(0x92, 0x72, 0x7B, 0xFF);

        [DisplayName("Request: Selected Sort By Column Title")]
        public ConfigColor SelectedSortColumnTitle { get; set; } = new ConfigColor(0xFF, 0xF4, 0xE9, 0xFF);

        [DisplayName("Simple Shop: Highlighted Selection Color")]
        public ConfigColor SimpleShopHighlightedColor { get; set; } = new ConfigColor(0xED, 0x6D, 0x91, 0xFF);

        [DisplayName("Simple Shop: Blur filter color when choosing amount to buy")]
        public ConfigColor SimpleShopBlurFilterColor { get; set; } = new ConfigColor(0x68, 0x01, 0x08, 0xFF);

        [DisplayName("Simple Shop: Zero font color when selecting amount to buy")]
        public ConfigColor SimpleShopZeroFontColor { get; set; } = new ConfigColor(0xFF, 0x00, 0x00, 0xFF);

        [DisplayName("Simple Shop: Shadow color in buy menu")]
        public ConfigColor SimpleShopBuyShadowColor { get; set; } = new ConfigColor(0xEB, 0x44, 0x7D, 0xFF);

        [DisplayName("Simple Shop: Buy menu selected option font color")]
        public ConfigColor SimpleShopBuyFontColor { get; set; } = new ConfigColor(0x5C, 0x00, 0x06, 0xFF);

        [DisplayName("Date Time Panel: Weekday triangle color")]
        public ConfigColor DateTimePanelWeekdayTriangleColor { get; set; } = new ConfigColor(0x24, 0x07, 0x09, 0xFF);

        [DisplayName("Item List: Highlighted selection color")]
        public ConfigColor ItemListHighlightedColor { get; set; } = new ConfigColor(0xFF, 0x75, 0x9C, 0xFF);

        [DisplayName("Minimap: Field minimap inner circle background color")]
        public ConfigColor MinimapFieldInnerCircle { get; set; } = new ConfigColor(0xEB, 0x00, 0x4E, 0xFF);

        [DisplayName("Minimap: Field minimap outter circle background color")]
        public ConfigColor MinimapFieldOutterCircle { get; set; } = new ConfigColor(0x2B, 0x10, 0x13, 0xFF);

        [DisplayName("Minimap: Minimap locations view higher strip background color")]
        public ConfigColor MinimapLocationsHighStrip { get; set; } = new ConfigColor(0x2B, 0x10, 0x13, 0xFF);

        [DisplayName("Minimap: Minimap locations view lower strip background color")]
        public ConfigColor MinimapLocationsLowerStrip { get; set; } = new ConfigColor(0xEB, 0x00, 0x4E, 0xFF);

        [DisplayName("Minimap: Minimap locations highlighted selection color")]
        public ConfigColor MinimapLocationsSelectionColor { get; set; } = new ConfigColor(0xE1, 0x14, 0x51, 0xFF);

        [DisplayName("Town Map: Selected Rounded Outline Color")]
        public ConfigColor PreviewRoundedOutline { get; set; } = new ConfigColor(0xFD, 0x9B, 0xB7, 0xFF);

        [DisplayName("Town Map: Preview Taint Color")]
        public ConfigColor PreviewTaintColor { get; set; } = new ConfigColor(0xBB, 0x96, 0xA0, 0xFF);

        [DisplayName("Town Map: Location Subtle Shadow")]
        public ConfigColor LocationSubtleShadowColor { get; set; } = new ConfigColor(0x53, 0x00, 0x04, 0xFF);

        [DisplayName("Town Map: Mini Location Centered Circle when changing selection")]
        public ConfigColor MiniLocationCircleColor { get; set; } = new ConfigColor(0xEB, 0x44, 0x7D, 0xFF);

        [DisplayName("SaveLoad: In-game screenshot color filter curve keyframe 1")]
        public ConfigColor SaveLoadScreenshotFilterKeyframe1 { get; set; } = new ConfigColor(0x99, 0x25, 0x60, 0xFF);

        [DisplayName("SaveLoad: In-game screenshot color filter curve keyframe 2")]
        public ConfigColor SaveLoadScreenshotFilterKeyframe2 { get; set; } = new ConfigColor(0xCC, 0x19, 0x6B, 0xFF);

        [DisplayName("SaveLoad: In-game screenshot color filter curve keyframe 3")]
        public ConfigColor SaveLoadScreenshotFilterKeyframe3 { get; set; } = new ConfigColor(0xF2, 0x26, 0x86, 0xFF);

        [DisplayName("Mail: Open animation color")]
        public ConfigColor MailStartAnimationColor { get; set; } = new ConfigColor(0xC2, 0x00, 0x44, 0xFF);
        /*
        [DisplayName("Battle Result: Left square color")]
        public ConfigColor BattleResultLeftSquare { get; set; } = new ConfigColor(0x6E, 0x03, 0x0E, 0xFF);

        [DisplayName("Battle Result: Left 0 font color in item count")]
        public ConfigColor BattleResultLeftZeroFontColor { get; set; } = new ConfigColor(0xEB, 0x44, 0x7D, 0xFF);

        [DisplayName("Battle Result: Font color in item count")]
        public ConfigColor BattleResultFontColor { get; set; } = new ConfigColor(0xFD, 0x9B, 0xB7, 0xFF);
        */
        [DisplayName("Camp Configuration: Light reflective material 1")]
        public ConfigColor CampConfigurationLightReflectiveColor1 { get; set; } = new ConfigColor(0xFF, 0x2E, 0x70, 0xFF);

        [DisplayName("Camp Configuration: Light reflective material 2")]
        public ConfigColor CampConfigurationLightReflectiveColor2 { get; set; } = new ConfigColor(0xFF, 0x60, 0x92, 0xFF);

        [DisplayName("SaveLoad: Gradient bottom top color")]
        public ConfigColor SaveLoadGradientBottomTopColor { get; set; } = new ConfigColor(0xB2, 0x22, 0x62, 0xFF);

        [DisplayName("SaveLoad: Gradient bottom color")]
        public ConfigColor SaveLoadGradientBottomColor { get; set; } = new ConfigColor(0xB2, 0x22, 0x62, 0xFF);

        [DisplayName("SaveLoad: Gradient top color")]
        public ConfigColor SaveLoadGradientTopColor { get; set; } = new ConfigColor(0xFF, 0xDE, 0x99, 0xFF);

        [DisplayName("SaveLoad: Gradient top bottom color")]
        public ConfigColor SaveLoadGradientTopBottomColor { get; set; } = new ConfigColor(0xFF, 0x8C, 0xA8, 0xFF);

        [DisplayName("Persona Status: Velvet Room in-game screenshot deep color filter")]
        public ConfigColor PersonaStatusDeepColorFilter { get; set; } = new ConfigColor(0xFF, 0x00, 0x58, 0xA9);

        [DisplayName("Persona Status: Velvet Room in-game screenshot medium strong color filter")]
        public ConfigColor PersonaStatusMediumStrongColorFilter { get; set; } = new ConfigColor(0x77, 0x00, 0x42, 0xFF);

        [DisplayName("Persona Status: Velvet Room in-game screenshot soft strong color filter")]
        public ConfigColor PersonaStatusSoftColorFilter { get; set; } = new ConfigColor(0x8B, 0x01, 0x48, 0xFF);

        [DisplayName("Persona Status: Inheritance skill selection square color")]
        public ConfigColor PersonaStatusInheritanceSquareColor { get; set; } = new ConfigColor(0x00, 0xD8, 0xFF, 0x00);

        [DisplayName("Persona Status: Strip main color")]
        public ConfigColor PersonaStatusStripColor { get; set; } = new ConfigColor(0xF4, 0x5A, 0x85, 0xFF);

        [DisplayName("Persona Status: Waves over the strip")]
        public ConfigColor PersonaStatusWavesStripColor { get; set; } = new ConfigColor(0x00, 0xD8, 0xFF, 0xFF);

        [DisplayName("Persona Status: Master Material unknown color 1")]
        public ConfigColor PersonaStatusMMUnk1 { get; set; } = new ConfigColor(0x00, 0xD8, 0xFF, 0xB2);

        [DisplayName("Persona Status: Master Material unknown color 2")]
        public ConfigColor PersonaStatusMMUnk2 { get; set; } = new ConfigColor(0x00, 0xD8, 0xFF, 0x00);

        [DisplayName("Persona Status: Master Material unknown color 3")]
        public ConfigColor PersonaStatusMMUnk3 { get; set; } = new ConfigColor(0x00, 0xD8, 0xFF, 0xFF);

        [DisplayName("Persona Status: Master Material unknown color 4")]
        public ConfigColor PersonaStatusMMUnk4 { get; set; } = new ConfigColor(0x00, 0xD8, 0xFF, 0xFF);

        [DisplayName("Quest: Elizabeth Quest Menu top gradient")]
        public ConfigColor QuestElizabethTopGradient1 { get; set; } = new ConfigColor(0xAD, 0x00, 0x4C, 0xCC);

        [DisplayName("Quest: Elizabeth Quest Menu bottom gradient")]
        public ConfigColor QuestElizabethBottomGradient { get; set; } = new ConfigColor(0xAD, 0x00, 0x89, 0x00);

        [DisplayName("Quest: Elizabeth Quest Menu additional top gradient")]
        public ConfigColor QuestElizabethTopGradient2 { get; set; } = new ConfigColor(0xC3, 0x5E, 0x04, 0x00);

        [DisplayName("Persona Status: In-game screenshot color filter curve keyframe 1")]
        public ConfigColor PersonaStatusScreenshotFilterKeyframe1 { get; set; } = new ConfigColor(0xB3, 0x00, 0x5D, 0xFF);

        [DisplayName("Persona Status: In-game screenshot color filter curve keyframe 2")]
        public ConfigColor PersonaStatusScreenshotFilterKeyframe2 { get; set; } = new ConfigColor(0xCC, 0x19, 0x71, 0xFF);

        [DisplayName("Persona Status: In-game screenshot color filter curve keyframe 3")]
        public ConfigColor PersonaStatusScreenshotFilterKeyframe3 { get; set; } = new ConfigColor(0xD9, 0x99, 0xAA, 0xFF);

        [DisplayName("Persona Status: In-game screenshot color filter curve keyframe 4")]
        public ConfigColor PersonaStatusScreenshotFilterKeyframe4 { get; set; } = new ConfigColor(0xE5, 0xCC, 0xD7, 0xFF);

        [DisplayName("Camp: Dormitory Calendar in-game screenshot color filter curve keyframe 1")]
        public ConfigColor CampCalendarScreenshotFilterKeyframe1 { get; set; } = new ConfigColor(0xCC, 0x40, 0x6A, 0xFF);

        [DisplayName("Camp: Dormitory Calendar in-game screenshot color filter curve keyframe 2")]
        public ConfigColor CampCalendarScreenshotFilterKeyframe2 { get; set; } = new ConfigColor(0xE6, 0x66, 0x8A, 0xFF);

        [DisplayName("Camp: Dormitory Calendar in-game screenshot color filter curve keyframe 3")]
        public ConfigColor CampCalendarScreenshotFilterKeyframe3 { get; set; } = new ConfigColor(0xEF, 0x0E, 0x64, 0xFF);

        [DisplayName("Camp: Dormitory Calendar in-game screenshot color filter curve keyframe 4")]
        public ConfigColor CampCalendarScreenshotFilterKeyframe4 { get; set; } = new ConfigColor(0xED, 0x57, 0xAC, 0xFF);

        [DisplayName("Camp: Configuration main menu in-game screenshot color filter curve keyframe 1")]
        public ConfigColor CampMainMenuConfigScreenshotFilterKeyframe1 { get; set; } = new ConfigColor(0x4D, 0x00, 0x26, 0xFF);

        [DisplayName("Camp: Configuration main menu in-game screenshot color filter curve keyframe 2")]
        public ConfigColor CampMainMenuConfigScreenshotFilterKeyframe2 { get; set; } = new ConfigColor(0x66, 0x00, 0x36, 0xFF);

        [DisplayName("Camp: Configuration main menu in-game screenshot color filter curve keyframe 3")]
        public ConfigColor CampMainMenuConfigScreenshotFilterKeyframe3 { get; set; } = new ConfigColor(0x99, 0x00, 0x47, 0xFF);

        [DisplayName("Camp: Configuration main menu in-game screenshot color filter curve keyframe 4")]
        public ConfigColor CampMainMenuConfigScreenshotFilterKeyframe4 { get; set; } = new ConfigColor(0xCA, 0x73, 0x8F, 0xFF);

        [DisplayName("Battle: Party members silhouette rounded selection color")]
        public ConfigColor PartyMemberSilhouetteSelectionColor { get; set; } = new ConfigColor(0xFE, 0x9B, 0xB8, 0xFF);

        [DisplayName("Battle: Informative upper-left panel, unkwnown color 1")]
        public ConfigColor JyokyoHelpUnkColor1 { get; set; } = new ConfigColor(0xFF, 0x2D, 0x7E, 0xFF);

        [DisplayName("Battle: Informative upper-left panel window in color with some transparency applied")]
        public ConfigColor JyokyoHelpWindowIn1 { get; set; } = new ConfigColor(0x23, 0x12, 0x1B, 0xE5);

        [DisplayName("Battle: Informative upper-left panel window out/plate color")]
        public ConfigColor JyokyoHelpWindowOut { get; set; } = new ConfigColor(0x4B, 0x30, 0x3D, 0xFF);

        [DisplayName("Battle: Informative upper-left panel window in color")]
        public ConfigColor JyokyoHelpWindowIn2 { get; set; } = new ConfigColor(0x23, 0x12, 0x1B, 0xBF);

        [DisplayName("Battle: Informative upper-left panel color gradation")]
        public ConfigColor JyokyoHelpColorGradation { get; set; } = new ConfigColor(0x40, 0x26, 0x34, 0x66);

        [DisplayName("Mail: Running figure color when checking a mail that allows fast travel")]
        public ConfigColor MailRunningFigureColor { get; set; } = new ConfigColor(0xEA, 0x00, 0x4A, 0xFF);

        [DisplayName("Mail: Running figure color when message prompt shows up")]
        public ConfigColor MailDarkRunningFigureColor { get; set; } = new ConfigColor(0x3F, 0x00, 0x14, 0xFF);

        [DisplayName("Mail: list selected subject color font/line/mail icon")]
        public ConfigColor MailSelectedSubjectColor { get; set; } = new ConfigColor(0xFF, 0x4A, 0x77, 0xFF);

        [DisplayName("Mail: Highlighted mail selection color")]
        public ConfigColor HighlightedSelectionColor { get; set; } = new ConfigColor(0xFF, 0x00, 0x62, 0xFF);

        [DisplayName("Mail: Mail detail highlighted title color")]
        public ConfigColor MailDetailTitleHighlightedColor { get; set; } = new ConfigColor(0xFF, 0x58, 0x92, 0xFF);

        [DisplayName("Mail: Mail detail highlighted title color when message prompt shows up")]
        public ConfigColor MailDetailDarkTitleHighlightedColor { get; set; } = new ConfigColor(0x80, 0x08, 0x45, 0xFF);

        [DisplayName("Battle: Water caustic colors in skill/item list/guard menus")]
        public ConfigColor BtlWaterCausticColor { get; set; } = new ConfigColor(0xFF, 0x00, 0x6A, 0xFF);

        [DisplayName("Battle: Highlighted selection color high")]
        public ConfigColor BtlHighlightedColor { get; set; } = new ConfigColor(0x00, 0xF0, 0xFF, 0xFF);

        [DisplayName("Battle: Result level up left square color when leveling up")]
        public ConfigColor BtlResultLvlUpLeftSquareColor { get; set; } = new ConfigColor(0x3B, 0x02, 0x07, 0xFF);

        [DisplayName("Battle: Result level up large strip color")]
        public ConfigColor BtlResultLvlUpLargeStripColor { get; set; } = new ConfigColor(0xFF, 0x73, 0x98, 0xFF);

        [DisplayName("Battle: Result level up large strip shadow color")]
        public ConfigColor BtlResultLvlUpLargeStripShadowColor { get; set; } = new ConfigColor(0x3E, 0x05, 0x0B, 0xFF);

        [DisplayName("Battle: Result level up large strip color")]
        public ConfigColor BtlResultLvlUpShortStripColor { get; set; } = new ConfigColor(0x54, 0x03, 0x1D, 0xFF);

        [DisplayName("Battle: Result level up item number font color")]
        public ConfigColor BtlResultLvlUpItemFontColor { get; set; } = new ConfigColor(0xFF, 0xA2, 0x85, 0xFF);

        [DisplayName("Battle: Result level up item number 0 font color")]
        public ConfigColor BtlResultLvlUpItemZeroFontColor { get; set; } = new ConfigColor(0xF7, 0x5D, 0x72, 0xFF);

        [DisplayName("Battle: Result femc level up persona arcana/lvl font color")]
        public ConfigColor BtlResultFemcLvlUpPersonaSilhouetteColor { get; set; } = new ConfigColor(0x5F, 0x00, 0x1C, 0xFF);

        [DisplayName("Battle: Result femc level up persona silhouette color")]
        public ConfigColor BtlResultFemcLvlUpPersonaInfoFont { get; set; } = new ConfigColor(0xE3, 0x14, 0x65, 0xFF);

        [DisplayName("Social Link: Rank up background 3 middle/down color")]
        public ConfigColor CmmuRankUpBG3MiddownColor { get; set; } = new ConfigColor(0x21, 0x12, 0x2B, 0xFF);

        [DisplayName("Social Link: Rank up background 4 color")]
        public ConfigColor CmmuRankUpBG4Color { get; set; } = new ConfigColor(0xCF, 0xB4, 0xE5, 0xFF);

        [DisplayName("Social Link: Rank up background taint color 1")]
        public ConfigColor CmmuRankUpColor1 { get; set; } = new ConfigColor(0xA9, 0x43, 0x60, 0xFF);

        [DisplayName("Social Link: Rank up background taint color 2")]
        public ConfigColor CmmuRankUpColor2 { get; set; } = new ConfigColor(0xDC, 0x3C, 0x6C, 0xFF);

        [DisplayName("Social Link: Rank up background taint color 3")]
        public ConfigColor CmmuRankUpColor3 { get; set; } = new ConfigColor(0xF5, 0x43, 0x78, 0xFF);

        [DisplayName("Social Link: Rank up color curve keyframe 1")]
        public ConfigColor CmmuRankUpKeyframe1 { get; set; } = new ConfigColor(0x99, 0x26, 0x47, 0xFF);

        [DisplayName("Social Link: Rank up color curve keyframe 2")]
        public ConfigColor CmmuRankUpKeyframe2 { get; set; } = new ConfigColor(0xCC, 0x33, 0x5C, 0xFF);

        [DisplayName("Social Link: Rank up color curve keyframe 3")]
        public ConfigColor CmmuRankUpKeyframe3 { get; set; } = new ConfigColor(0xD9, 0x33, 0x62, 0xFF);

        [DisplayName("Social Link: Rank up color curve keyframe 4")]
        public ConfigColor CmmuRankUpKeyframe4 { get; set; } = new ConfigColor(0xFF, 0x4D, 0x7C, 0xFF);

        [DisplayName("Social Link: Rank up color curve keyframe 5")]
        public ConfigColor CmmuRankUpKeyframe5 { get; set; } = new ConfigColor(0xFF, 0xB3, 0xC9, 0xFF);

        [DisplayName("Social Link: Rank up strip upper part color")]
        public ConfigColor CmmuRankUpStripColorUp { get; set; } = new ConfigColor(0xA6, 0x2E, 0x4E, 0xFF);

        [DisplayName("Social Link: Rank up strip lower part color")]
        public ConfigColor CmmuRankUpStripColorDown { get; set; } = new ConfigColor(0xA6, 0x08, 0x56, 0xFF);

        [DisplayName("Social Link: Rank up dark color cards")]
        public ConfigColor CmmuRankUpDarkCardColor { get; set; } = new ConfigColor(0x4D, 0x08, 0x19, 0xFF);

        [DisplayName("Social Link: Rank up light color cards")]
        public ConfigColor CmmuRankUpLightCardColor { get; set; } = new ConfigColor(0xF6, 0x00, 0x6F, 0xFF);

        [DisplayName("Social Link: Rank up MAX words")]
        public ConfigColor CmmuRankUpMaxColor { get; set; } = new ConfigColor(0xB3, 0x52, 0x6D, 0xFF);

        [DisplayName("Persona Status Highlighted Line Color")]
        public ConfigColor PersonaStatusHighlightedLine { get; set; } = new ConfigColor(0x00, 0xD8, 0xFF, 0xFF);

        [DisplayName("Battle: Shuffle time card type font inside rectangle color")]
        public ConfigColor ShuffleCardTypeFontColor { get; set; } = new ConfigColor(0x43, 0x02, 0x28, 0xFF);

        [DisplayName("Battle: Shuffle time card type rectangle and owned rhomb color")]
        public ConfigColor ShuffleCardTypeAndRhomb { get; set; } = new ConfigColor(0xFF, 0x9A, 0xB7, 0xFF);

        [DisplayName("Battle: Shuffle time owned font color")]
        public ConfigColor ShuffleOwnedFontColor { get; set; } = new ConfigColor(0x43, 0x02, 0x28, 0xFF);

        [DisplayName("Battle: Shuffle time owned count number font color")]
        public ConfigColor ShuffleOwnedCountFontColor { get; set; } = new ConfigColor(0x5A, 0x05, 0x36, 0xFF);

        [DisplayName("Battle: Shuffle time owned count left zero font color")]
        public ConfigColor ShuffleOwnedLeftZeroFontColor { get; set; } = new ConfigColor(0xFF, 0x9A, 0xCA, 0xFF);

        [DisplayName("Battle: Shuffle time big background cards 1")]
        public ConfigColor ShuffleBigBGCardsColor1 { get; set; } = new ConfigColor(0xA1, 0x18, 0x60, 0xFF);

        [DisplayName("Battle: Shuffle time arcana symbol color")]
        public ConfigColor ShuffleArcanaSymbolColor { get; set; } = new ConfigColor(0x97, 0x33, 0x5C, 0xFF);

        [DisplayName("Battle: Shuffle time persona overstock background color")]
        public ConfigColor ShufflePersonaOverstockBG { get; set; } = new ConfigColor(0xC0, 0x25, 0x6D, 0xFF);

        [DisplayName("Battle: Shuffle time down gradient color")]
        public ConfigColor ShuffleDownGradient { get; set; } = new ConfigColor(0xFF, 0x67, 0xA3, 0xFF);

        [DisplayName("Battle: Shuffle time down gradient color when selecting arcana")]
        public ConfigColor ShuffleDownGradientArcanaSelection { get; set; } = new ConfigColor(0x83, 0x0A, 0x4A, 0xFF);

        [DisplayName("Battle: Shuffle time big background cards 2")]
        public ConfigColor ShuffleBigBGCardsColor2 { get; set; } = new ConfigColor(0xCC, 0x2A, 0x60, 0xFF);

        [DisplayName("Battle: Shuffle time top gradient color when selecting arcana")]
        public ConfigColor ShuffleTopGradientAndCardsTaint { get; set; } = new ConfigColor(0xBD, 0x1A, 0x5B, 0xFF);

        [DisplayName("Battle: Shuffle time title underlay color 1")]
        public ConfigColor ShuffleTitleUnderlayColor1 { get; set; } = new ConfigColor(0xC2, 0x14, 0x58, 0xFF);

        [DisplayName("Battle: Shuffle time title underlay color 2")]
        public ConfigColor ShuffleTitleUnderlayColor2 { get; set; } = new ConfigColor(0x7D, 0x07, 0x46, 0xFF);

        [DisplayName("Battle: Shuffle time title font color")]
        public ConfigColor ShuffleTitleFontColor { get; set; } = new ConfigColor(0x66, 0x00, 0x37, 0xFF);

        [DisplayName("Battle: Shuffle time unknown color 1")]
        public ConfigColor ShuffleUnkColor1 { get; set; } = new ConfigColor(0xB8, 0x1D, 0x58, 0xFF);

        [DisplayName("Battle: Shuffle time unknown color 2")]
        public ConfigColor ShuffleUnkColor2 { get; set; } = new ConfigColor(0xB8, 0x1D, 0x58, 0xFF);

        [DisplayName("Battle: Shuffle time unknown color 3")]
        public ConfigColor ShuffleUnkColor3 { get; set; } = new ConfigColor(0xB8, 0x1D, 0x58, 0xFF);

        [DisplayName("Battle: Shuffle time unknown color 4")]
        public ConfigColor ShuffleUnkColor4 { get; set; } = new ConfigColor(0xB8, 0x1D, 0x58, 0xFF);

        [DisplayName("Battle: Shuffle time unknown color 5")]
        public ConfigColor ShuffleUnkColor5 { get; set; } = new ConfigColor(0xB8, 0x1D, 0x58, 0xFF);

        [DisplayName("Battle: Shuffle time unknown color 6")]
        public ConfigColor ShuffleUnkColor6 { get; set; } = new ConfigColor(0x77, 0x00, 0x45, 0xFF);

        [DisplayName("Battle: Persona Overstock equipped persona font color")]
        public ConfigColor OverstockFontEquippedArcanaColor { get; set; } = new ConfigColor(0xD4, 0x7E, 0x6A, 0xFF);

        [DisplayName("Battle: Persona Overstock selected persona arcana font color")]
        public ConfigColor OverstockFontSelectedArcanaColor { get; set; } = new ConfigColor(0x44, 0x04, 0x27, 0xFF);

        [DisplayName("Battle: Persona Overstock selected arcana rectangle background color")]
        public ConfigColor OverstockBGSelectedColor { get; set; } = new ConfigColor(0xFF, 0xE2, 0x9E, 0xFF);

        [DisplayName("Battle: Persona Overstock unselected arcana/persona name font color")]
        public ConfigColor OverstockFontUnselectedNameArcanaColor { get; set; } = new ConfigColor(0xFF, 0xE2, 0x9E, 0xFF);

        [DisplayName("Battle: Persona Overstock unselected arcana rectangle background color")]
        public ConfigColor OverstockBGUnselectedColor { get; set; } = new ConfigColor(0x44, 0x04, 0x27, 0xFF);

        [DisplayName("Battle: Persona Overstock title color")]
        public ConfigColor OverstockTitleColor { get; set; } = new ConfigColor(0xB9, 0x00, 0x56, 0xFF);

        [DisplayName("Camp: Animated triangle color when assigning personas/equipment")]
        public ConfigColor EquipTriangleColor { get; set; } = new ConfigColor(0xFF, 0xA1, 0xCA, 0xFF);

        [DisplayName("Events: Handwriting gradation color 1")]
        public ConfigColor HandwritingGradationColor1 { get; set; } = new ConfigColor(0xFF, 0xA4, 0xC7, 0xFF);

        [DisplayName("Events: Handwriting gradation color 2")]
        public ConfigColor HandwritingGradationColor2 { get; set; } = new ConfigColor(0xFF, 0x00, 0x66, 0xFF);

        [DisplayName("Camp: Stats menu background underlay")]
        public ConfigColor CampStatsMenuUnderlay { get; set; } = new ConfigColor(0x40, 0x01, 0x0A, 0xFF);

        [DisplayName("Camp: Highlighted dark color")]
        public ConfigColor CampHighlightedDark { get; set; } = new ConfigColor(0x00, 0x30, 0x42, 0xFF);

        [DisplayName("Field: Icons over character's head indicating an event (Koromaru walk/Linked episodes) 1")]
        public ConfigColor AccessIconColor1 { get; set; } = new ConfigColor(0x7C, 0x03, 0x18, 0xFF);

        [DisplayName("Field: Icons over character's head indicating an event (Koromaru walk/Linked episodes) 2")]
        public ConfigColor AccessIconColor2 { get; set; } = new ConfigColor(0x80, 0x20, 0x36, 0xFF);

        [DisplayName("Field: Icons over character's head indicating an event (Koromaru walk/Linked episodes) 3")]
        public ConfigColor AccessIconColor3 { get; set; } = new ConfigColor(0x66, 0x05, 0x1B, 0xFF);

        [DisplayName("Camp: Highlighted up/down arrows color")]
        public ConfigColor HighlightedUpDownArrows { get; set; } = new ConfigColor(0x00, 0xD8, 0xFF, 0xFF);

        [DisplayName("Camp: Compare menu circle BG")]
        public ConfigColor CampEquipCompareCircle { get; set; } = new ConfigColor(0x5F, 0x00, 0x20, 0xFF);

        [DisplayName("Camp: Compare menu femc shadow inside circle")]
        public ConfigColor CampEquipCompareFemcShadowCircle { get; set; } = new ConfigColor(0xB0, 0x9C, 0xA2, 0xFF);

        [DisplayName("DayChange: Day change transition background color")]
        public ConfigColor DayChangeBGColor { get; set; } = new ConfigColor(0x27, 0x18, 0x1F, 0xFF);

        [DisplayName("Request: Report icon background color")]
        public ConfigColor RequestReportBG { get; set; } = new ConfigColor(0xA3, 0x20, 0x5F, 0xFF);

        [DisplayName("Camp: Quest chairs color")]
        public ConfigColor RequestChairsColor { get; set; } = new ConfigColor(0x76, 0x01, 0x3D, 0xFF);

        [DisplayName("Camp: Status shards color")]
        public ConfigColor StatusShardsColor { get; set; } = new ConfigColor(0xDD, 0x63, 0x8B, 0xFF);

        [DisplayName("Camp: Falling nine femc is grabbing in System")]
        public ConfigColor FallingNineColor { get; set; } = new ConfigColor(0xA3, 0x80, 0x8A, 0xFF);

        [DisplayName("Camp: Skill menu gun color")]
        public ConfigColor SkillGunColor { get; set; } = new ConfigColor(0xC5, 0x85, 0x85, 0xFF);

        [DisplayName("Camp: Stats Gekkoukan logo dark color")]
        public ConfigColor StatsGekkoukanDark { get; set; } = new ConfigColor(0x9C, 0x6B, 0x79, 0xFF);

        [DisplayName("Camp: Stats title spinning font color")]
        public ConfigColor StatsFontColor { get; set; } = new ConfigColor(0xB5, 0xB4, 0xB4, 0xFF);

        [DisplayName("Camp: Stats shadows over background taint color")]
        public ConfigColor StatsShadowsColor { get; set; } = new ConfigColor(0x66, 0x08, 0x29, 0xFF);

        [DisplayName("Camp: Status detail Gekkoukan logo dark color and status title spinning font color")]
        public ConfigColor StatusDetailTitleAndGekkoukanDark { get; set; } = new ConfigColor(0x2B, 0x1E, 0x22, 0xFF);

        [DisplayName("Camp: Status detail Gekkoukan logo/femc background main color")]
        public ConfigColor StatusDetailMainBackground { get; set; } = new ConfigColor(0x46, 0x3D, 0x40, 0xFF);

        [DisplayName("Social Link: Check Social Link status when in field strip color")]
        public ConfigColor CmmuStatusStrip { get; set; } = new ConfigColor(0x9F, 0x00, 0x4B, 0xFF);

        [DisplayName("Camp: Status detail character shard BG shard gradation")]
        public ConfigColor StatusDetailBigShard { get; set; } = new ConfigColor(0x87, 0x6F, 0x7B, 0xFF);

        [DisplayName("Social Stats: Triangle background color")]
        public ConfigColor SocialStatsTriangle { get; set; } = new ConfigColor(0x30, 0x22, 0x29, 0xFF);

        [DisplayName("Camp: Status detail Theurgy/Persona/Stats tags background color")]
        public ConfigColor StatusDetailTagColors { get; set; } = new ConfigColor(0x4D, 0x34, 0x3D, 0xFF);

        [DisplayName("Camp: Status detail character shard BG in theurgy detail")]
        public ConfigColor StatusTheurgyBigShard { get; set; } = new ConfigColor(0x75, 0x4D, 0x5F, 0xFF);

        [DisplayName("Camp: Status theurgy detail titles font color")]
        public ConfigColor StatusTheurgyDetailTitlesFont { get; set; } = new ConfigColor(0x67, 0x47, 0x60, 0xFF);

        [DisplayName("Camp: Status theurgy detail background color")]
        public ConfigColor StatusTheurgyDetailBGColor { get; set; } = new ConfigColor(0x4B, 0x2B, 0x40, 0xFF);

        [DisplayName("Camp: Status detail character shard transition BG light color")]
        public ConfigColor StatusDetailTransitionBGLight { get; set; } = new ConfigColor(0xD8, 0xD1, 0xD4, 0xFF);

        [DisplayName("Camp: Status detail character shard transition BG dark color")]
        public ConfigColor StatusDetailTransitionBGDark { get; set; } = new ConfigColor(0xC1, 0xB0, 0xB6, 0xFF);

        [DisplayName("Camp: Equip selection menu dots separator color")]
        public ConfigColor EquipDotsColor { get; set; } = new ConfigColor(0x90, 0x36, 0x55, 0xFF);

        [DisplayName("Camp: Calendar past day color")]
        public ConfigColor CalendarPastDay { get; set; } = new ConfigColor(0xC8, 0x91, 0xA5, 0xFF);

        [DisplayName("Camp: Calendar current selected day highlighted color")]
        public ConfigColor CalendarHighlightedDay { get; set; } = new ConfigColor(0x07, 0x40, 0xFD, 0xFF);

        [DisplayName("Camp: Calendar current highlighted job color")]
        public ConfigColor CalendarHighlightedJob { get; set; } = new ConfigColor(0x00, 0x00, 0xF1, 0xFF);

        [DisplayName("Camp: Calendar job detail font color")]
        public ConfigColor CalendarJobDetailFont { get; set; } = new ConfigColor(0xFF, 0xBD, 0xCE, 0xFF);

        [DisplayName("Camp: Item Effect tag background color")]
        public ConfigColor CampItemEffectBG { get; set; } = new ConfigColor(0xFF, 0xBD, 0xCE, 0xFF);

        [DisplayName("Camp: Item Effect font color")]
        public ConfigColor CampItemEffectFont { get; set; } = new ConfigColor(0x49, 0x04, 0x21, 0xFF);

        [DisplayName("Camp: System Menu Item Color 1")]
        [Category("UI Colors")]
        public ConfigColor CampMenuSystemItemColor1 { get; set; } = new ConfigColor(0xFD, 0xDF, 0xA1, 0xFF);

        [DisplayName("Camp: System Menu Item Color 2")]
        [Category("UI Colors")]
        public ConfigColor CampMenuSystemItemColor2 { get; set; } = new ConfigColor(0xFF, 0xD7, 0x9D, 0xFF);

        [DisplayName("Camp: System Menu Item Color 3")]
        [Category("UI Colors")]
        public ConfigColor CampMenuSystemItemColor3 { get; set; } = new ConfigColor(0xFF, 0xBA, 0x67, 0xFF);

        [DisplayName("Camp: System Menu Item Color No Select")]
        [Category("UI Colors")]
        public ConfigColor CampMenuSystemItemColorNoSel { get; set; } = new ConfigColor(0xFF, 0xB2, 0x9E, 0xFF);

        [DisplayName("Battle: Shift from strip color")]
        public ConfigColor ShiftFromColor { get; set; } = new ConfigColor(0xFF, 0x05, 0x13, 0xFF);

        [DisplayName("Battle: Shift to middle strip color")]
        public ConfigColor ShiftToMiddleColor { get; set; } = new ConfigColor(0xFF, 0x17, 0x23, 0xFF);

        [DisplayName("Battle: Shift to up/down strips color")]
        public ConfigColor ShiftToUpDownColor { get; set; } = new ConfigColor(0xFF, 0x5C, 0x49, 0xFF);

        [DisplayName("Camp Configuration: BGM Selection Text and Icon Color")]
        public ConfigColor CampConfSelTexColor { get; set; } = new ConfigColor(0xFF, 0xFC, 0x9F, 0xFF);

        [DisplayName("Camp Configuration: Option Current Setting Background Color")]
        public ConfigColor CampConfOptFmtBgColor { get; set; } = new ConfigColor(0x1A, 0x00, 0x10, 0xFF);

        [DisplayName("Camp Configuration: Option Name Text Color")]
        public ConfigColor CampConfSelNameColor { get; set; } = new ConfigColor(0xFF, 0xFC, 0x9F, 0xFF);

        [DisplayName("Camp Configuration: Key Configuration Inactive Option")]
        public ConfigColor CampConfigControlSetInactive { get; set; } = new ConfigColor(0xFF, 0xAC, 0x8C, 0xFF);

        [DisplayName("Camp Configuration: Option Unselected Area")]
        public ConfigColor CampConfigOptionUnselectedArea { get; set; } = new ConfigColor(0xEE, 0x8A, 0x7C, 0xFF);

        [DisplayName("Camp Configuration: Boolean Unselected Area")]
        public ConfigColor CampConfigBooleanUnselectedArea { get; set; } = new ConfigColor(0xDF, 0x9A, 0x87, 0xFF);

        [DisplayName("Camp Configuration: Music Player Glow Color")]
        public ConfigColor CampConfigMusicPlayerGlow { get; set; } = new ConfigColor(0xFF, 0xFC, 0x9F, 0xFF);

        [DisplayName("Camp Configuration: Top Description Text Color")]
        public ConfigColor CampConfigTopDescColor { get; set; } = new ConfigColor(0xFF, 0xFC, 0x9F, 0xFF);

        [DisplayName("Camp Configuration: Background Color")]
        public ConfigColor CampConfigBgColor { get; set; } = new ConfigColor(0x55, 0x1E, 0x3F, 0xFF);

        // public ConfigColor CampConfigUnk { get; set; } = new ConfigColor(0x8f, 0x65, 0x73, 0xff);

        [DisplayName("Camp Configuration: Playlist Title Color")]
        public ConfigColor CampConfigPlistHeadColor { get; set; } = new ConfigColor(0xE2, 0x41, 0x89, 0xFF);

        [DisplayName("Camp Equip: Unavailable Party Member Color")]
        public ConfigColor EquipPMUnavailableColor { get; set; } = new ConfigColor(0xB6, 0x3F, 0x68, 0xff);

        [DisplayName("Camp Equip: Unavailable Party Member Parallelogram")]
        public ConfigColor EquipPMUnavailableParallelogram { get; set; } = new ConfigColor(0xB6, 0x3F, 0x68, 0xFF);

        [DisplayName("Camp Root: Main camp menu highlighted color 1")]
        public ConfigColor CampRootHighlightedColor1 { get; set; } = new ConfigColor(0x00, 0xF9, 0xFF, 0xFF);

        [DisplayName("Camp Root: Main camp menu highlighted color 2")]
        public ConfigColor CampRootHighlightedColor2 { get; set; } = new ConfigColor(0x00, 0xD2, 0xFF, 0xFF);

        [DisplayName("Persona Status: Equip bonus color")]
        public ConfigColor PersonaStatusEquipBonusColor { get; set; } = new ConfigColor(0x00, 0xD8, 0xFF, 0xFF);

        [DisplayName("Save Load: Highlighted color")]
        public ConfigColor SaveLoadHighlightedOption { get; set; } = new ConfigColor(0x00, 0xF0, 0xFF, 0xFF);

        [DisplayName("Save Load: Accent Color")]
        public ConfigColor SaveLoadAccentColor { get; set; } = new ConfigColor(0xF2, 0xC9, 0x95, 0xFF);

        [DisplayName("Save Load: Slot box Color")]
        public ConfigColor SaveLoadSlotBox { get; set; } = new ConfigColor(0x48, 0x04, 0x2D, 0xFF);

        [DisplayName("Save Load: Corner triangle Color")]
        public ConfigColor SaveLoadCornerTriangle { get; set; } = new ConfigColor(0x36, 0x00, 0x21, 0xFF);

        [DisplayName("Save Load: Unhighlighted number Color")]
        public ConfigColor SaveLoadUnhighlightedNumber { get; set; } = new ConfigColor(0x5D, 0x0B, 0x34, 0xFF);

        [DisplayName("Save Load: Selected slot box Color")]
        public ConfigColor SaveLoadSelectedSlotBox { get; set; } = new ConfigColor(0xF4, 0x3A, 0x75, 0xFF);

        [DisplayName("Save Load: Grey Color")]
        public ConfigColor SaveLoadGrey { get; set; } = new ConfigColor(0x3F, 0x39, 0x39, 0xFF);

        [DisplayName("Save Load: Scroll bar Color")]
        public ConfigColor SaveLoadScrollBar { get; set; } = new ConfigColor(0x69, 0x03, 0x36, 0xFF);

        [DisplayName("Camp: System Curve Color")]
        public ConfigColor CampSystemCurveColor { get; set; } = new ConfigColor(0xAC, 0x27, 0xBF, 0xFF);

        [DisplayName("Message Box Selection Background Fill Color")]
        public ConfigColor MsgSimpleSelectBgFill { get; set; } = new ConfigColor(0xB5, 0x3C, 0x66, 0xFF);

        [DisplayName("Message Box Selection Background Main Fill Color")]
        public ConfigColor MsgSimpleSelectBgMainColor { get; set; } = new ConfigColor(0xFF, 0xAF, 0x00, 0xFF);


        [DisplayName("Camp: Kotone Shadow Color")]
        public ConfigColor CampKotoneShadowColor { get; set; } = new ConfigColor(0xFF, 0xD4, 0xA0, 0xFF);


        [DisplayName("Camp: Kotone Shadow Color 2")]
        public ConfigColor CampKotoneShadowColor2 { get; set; } = new ConfigColor(0xFF, 0xAD, 0x9D, 0xFF);

        [DisplayName("Camp: Kotone Inner Shadow Color")]
        public ConfigColor CampKotoneInnerShadowColor { get; set; } = new ConfigColor(0xFF, 0xDE, 0x8E, 0xFF);




        [DisplayName("Battle: Fade Manager 1")]
        public ConfigColor FadeManager1 { get; set; } = new ConfigColor(0xFF, 0x82, 0x91, 0xFF);

        [DisplayName("Battle: Fade Manager 2")]
        public ConfigColor FadeManager2 { get; set; } = new ConfigColor(0x22, 0xD7, 0xFA, 0xFF);

        [DisplayName("Battle: Fade Manager 3")]
        public ConfigColor FadeManager3 { get; set; } = new ConfigColor(0xCA, 0x08, 0x5E, 0xFF);

        [DisplayName("Battle: Fade Manager 4")]
        public ConfigColor FadeManager4 { get; set; } = new ConfigColor(0x02, 0x2E, 0x33, 0xFF);

        [DisplayName("Battle: Fade Manager 5")]
        public ConfigColor FadeManager5 { get; set; } = new ConfigColor(0xFF, 0x82, 0x91, 0xFF);

        [DisplayName("Battle: Fade Manager 6")]
        public ConfigColor FadeManager6 { get; set; } = new ConfigColor(0x57, 0x05, 0x2F, 0xFF);

        [DisplayName("Battle: Fade Manager 7")]
        public ConfigColor FadeManager7 { get; set; } = new ConfigColor(0xE3, 0x14, 0x55, 0xFF);


        [DisplayName("Battle: Guard Top Left Text")]
        public ConfigColor BtlGuardTopLeftText { get; set; } = new ConfigColor(0xAA, 0x0E, 0x53, 0xFF);

        [DisplayName("Battle: Guard Bottom Right Text")]
        public ConfigColor BtlGuardBottomRightText { get; set; } = new ConfigColor(0x64, 0x06, 0x38, 0xFF);

        [DisplayName("Battle: Guard Misc")]
        public ConfigColor BtlGuardMisc { get; set; } = new ConfigColor(0xAA, 0x0E, 0x53, 0xFF);

        [DisplayName("Battle: Guard Top Left BG")]
        public ConfigColor BtlGuardTopLeftBG { get; set; } = new ConfigColor(0xF3, 0x26, 0x6D, 0xFF);

        [DisplayName("Battle: Guard Bottom Right BG")]
        public ConfigColor BtlGuardBottomRightBG { get; set; } = new ConfigColor(0x89, 0x0A, 0x49, 0xFF);

        [DisplayName("Battle: Encounter Wipe")]
        public ConfigColor BtlEncountWipe { get; set; } = new ConfigColor(0xFF, 0x46, 0x77, 0xFF);

        [DisplayName("Battle: Item List 1")]
        public ConfigColor BtlItemList1 { get; set; } = new ConfigColor(0xFF, 0x00, 0x00, 0xFF);

        [DisplayName("Battle: Item List 2")]
        public ConfigColor BtlItemList2 { get; set; } = new ConfigColor(0x00, 0xFF, 0x04, 0xFF);

        [DisplayName("Battle: Item List 3")]
        public ConfigColor BtlItemList3 { get; set; } = new ConfigColor(0xB6, 0x19, 0x52, 0xFF);

        [DisplayName("Battle: Item List 4")]
        public ConfigColor BtlItemList4 { get; set; } = new ConfigColor(0xC7, 0x1F, 0x5C, 0xFF);

        [DisplayName("Battle: Item List 5")]
        public ConfigColor BtlItemList5 { get; set; } = new ConfigColor(0xFF, 0x73, 0x98, 0xFF);

        [DisplayName("Battle: Item List Accent")]
        public ConfigColor BtlItemListAccent { get; set; } = new ConfigColor(0xFF, 0xED, 0x8E, 0xFF);

        [DisplayName("Battle: Item List Model Dark Color")]
        public ConfigColor BtlItemModelDarkColor { get; set; } = new ConfigColor(0x94, 0x15, 0x43, 0xFF);

        [DisplayName("Battle: Item List Model Light Color")]
        public ConfigColor BtlItemModelLightColor { get; set; } = new ConfigColor(0xAC, 0x16, 0x4C, 0xFF);

        [DisplayName("Battle: Promise Common 1")]
        public ConfigColor BtlPromiseCommon1 { get; set; } = new ConfigColor(0xB9, 0x00, 0x52, 0xFF);

        [DisplayName("Battle: Promise Common 2")]
        public ConfigColor BtlPromiseCommon2 { get; set; } = new ConfigColor(0xA3, 0x5F, 0x81, 0xFF);

        [DisplayName("Battle: Promise Common 3")]
        public ConfigColor BtlPromiseCommon3 { get; set; } = new ConfigColor(0xFF, 0x73, 0x98, 0xFF);

        [DisplayName("Battle: Promise Common 4")]
        public ConfigColor BtlPromiseCommon4 { get; set; } = new ConfigColor(0x7A, 0x0C, 0x48, 0xFF);

        [DisplayName("Battle: Promise Common 5")]
        public ConfigColor BtlPromiseCommon5 { get; set; } = new ConfigColor(0x6D, 0x32, 0x53, 0xFF);

        [DisplayName("Battle: Promise Common Highlight")]
        public ConfigColor BtlPromiseCommonHighlight { get; set; } = new ConfigColor(0x00, 0xDA, 0xFF, 0xFF);

        [DisplayName("Battle: Result Level Up Top Exp BG Color")]
        public ConfigColor BtlResultLvlUpTopExpBGColor { get; set; } = new ConfigColor(0x69, 0x08, 0x33, 0xFF);


        [DisplayName("Battle: Result Level Up Top Item Number Color")]
        public ConfigColor BtlResultLvlUpTopItemNumColor { get; set; } = new ConfigColor(0xFF, 0xB3, 0x7F, 0xFF);

        [DisplayName("Battle: Result Level Up Top Item Number Dark Color")]
        public ConfigColor BtlResultLvlUpTopItemNumColorDark { get; set; } = new ConfigColor(0xF6, 0x82, 0xAE, 0xFF);

        [DisplayName("Battle: Result Level Up Parallelogram Color")]
        public ConfigColor BtlResultLvlUpParallelogram { get; set; } = new ConfigColor(0xB6, 0x18, 0x52, 0xFF);

        [DisplayName("Battle: Result Level Up Background Panel Color")]
        public ConfigColor BtlResultLvlUpBgPanel { get; set; } = new ConfigColor(0xB3, 0x18, 0x51, 0xFF);

        [DisplayName("Battle: Result Level Up Behind Background Panel Color")]
        public ConfigColor BtlResultLvlUpBgBehindPanel { get; set; } = new ConfigColor(0xB6, 0x18, 0x52, 0xFF);

        [DisplayName("Battle: Skill List Accent Color")]
        public ConfigColor BtlSkillListAccentColor { get; set; } = new ConfigColor(0xFF, 0xED, 0x8E, 0xFF);

        [DisplayName("Battle: Skill List Unknown Color")]
        public ConfigColor BtlSkillListUnk1 { get; set; } = new ConfigColor(0x88, 0x12, 0x3F, 0xFF);

        [DisplayName("Battle: Skill List Unknown Color")]
        public ConfigColor BtlSkillListUnk2 { get; set; } = new ConfigColor(0x1F, 0xFF, 0x00, 0xFF);

        [DisplayName("Battle: Skill List Unknown Color")]
        public ConfigColor BtlSkillListUnk3 { get; set; } = new ConfigColor(0xC1, 0x21, 0x66, 0xFF);

        [DisplayName("Battle: Skill List Unknown Color")]
        public ConfigColor BtlSkillListUnk4 { get; set; } = new ConfigColor(0xA8, 0x14, 0x46, 0xFF);

        [DisplayName("Battle: Skill List Unknown Color")]
        public ConfigColor BtlSkillListUnk5 { get; set; } = new ConfigColor(0x88, 0x0A, 0x49, 0xFF);

        [DisplayName("Battle: Skill List Unknown Color")]
        public ConfigColor BtlSkillListUnk6 { get; set; } = new ConfigColor(0xA3, 0x14, 0x44, 0xFF);

        [DisplayName("Battle: Skill List Unknown Color")]
        public ConfigColor BtlSkillListUnk7 { get; set; } = new ConfigColor(0x5C, 0x02, 0x34, 0xFF);

        [DisplayName("Battle: Skill List Unknown Color")]
        public ConfigColor BtlSkillListUnk8 { get; set; } = new ConfigColor(0xFF, 0x73, 0x9C, 0xFF);

        [DisplayName("Battle: Skill List Unknown Color")]
        public ConfigColor BtlSkillListUnk9 { get; set; } = new ConfigColor(0xFF, 0x73, 0x9C, 0xFF);

        [DisplayName("Battle: Skill List Unknown Color")]
        public ConfigColor BtlSkillListUnk10 { get; set; } = new ConfigColor(0xFF, 0x73, 0xD2, 0xFF);

        [DisplayName("Battle: Skill List Model Color")]
        public ConfigColor BtlSkillListModelColor { get; set; } = new ConfigColor(0xE3, 0x6B, 0xA2, 0xFF);

        [DisplayName("Message Box Background Color")]
        public ConfigColor MsgSimpleBgColor { get; set; } = new ConfigColor(0x23, 0x12, 0x19, 0xFF);

        [DisplayName("Message Box Unselected Text Color")]
        public ConfigColor MsgSimpleUnselectedTextColor { get; set; } = new ConfigColor(0xFC, 0xF0, 0xF4, 0xFF);

        [DisplayName("System Message Tutorial Title Font Color")]
        public ConfigColor MsgSimpleSystemTutorialTitleFontColor { get; set; } = new ConfigColor(0x26, 0x00, 0x10, 0xFF);

        [DisplayName("Camp System: No tutorial message font color")]
        public ConfigColor CampSystemNoTutorialColor { get; set; } = new ConfigColor(0xFF, 0xBD, 0xCE, 0xFF);

        [DisplayName("Camp System: Tutorial Battle BG card keyframe 1")]
        public ConfigColor CampTutorialBattleKeyframe1 { get; set; } = new ConfigColor(0x00, 0x00, 0x00, 0xFF);

        [DisplayName("Camp System: Tutorial Battle BG card keyframe 2")]
        public ConfigColor CampTutorialBattleKeyframe2 { get; set; } = new ConfigColor(0x1D, 0x00, 0x0F, 0xFF);

        [DisplayName("Camp System: Tutorial Battle BG card keyframe 3")]
        public ConfigColor CampTutorialBattleKeyframe3 { get; set; } = new ConfigColor(0x33, 0x00, 0x1A, 0xFF);

        [DisplayName("Camp System: Tutorial Battle BG card keyframe 4")]
        public ConfigColor CampTutorialBattleKeyframe4 { get; set; } = new ConfigColor(0x3F, 0x03, 0x23, 0xFF);

        [DisplayName("Camp System: Tutorial Fusion BG card keyframe 1")]
        public ConfigColor CampTutorialFusionKeyframe1 { get; set; } = new ConfigColor(0x00, 0x00, 0x00, 0xFF);

        [DisplayName("Camp System: Tutorial Fusion BG card keyframe 2")]
        public ConfigColor CampTutorialFusionKeyframe2 { get; set; } = new ConfigColor(0x3F, 0x03, 0x23, 0xFF);

        [DisplayName("Camp System: Tutorial Fusion BG card keyframe 3")]
        public ConfigColor CampTutorialFusionKeyframe3 { get; set; } = new ConfigColor(0x41, 0x05, 0x2A, 0xFF);

        [DisplayName("Camp System: Tutorial Fusion BG card keyframe 4")]
        public ConfigColor CampTutorialFusionKeyframe4 { get; set; } = new ConfigColor(0x33, 0x06, 0x4C, 0xFF);

        [DisplayName("Camp System: Tutorial Daily BG card keyframe 1")]
        public ConfigColor CampTutorialDailyKeyframe1 { get; set; } = new ConfigColor(0x00, 0x00, 0x00, 0xFF);

        [DisplayName("Camp System: Tutorial Daily BG card keyframe 2")]
        public ConfigColor CampTutorialDailyKeyframe2 { get; set; } = new ConfigColor(0x9E, 0x08, 0x47, 0xFF);

        [DisplayName("Camp System: Tutorial Daily BG card keyframe 3")]
        public ConfigColor CampTutorialDailyKeyframe3 { get; set; } = new ConfigColor(0x8C, 0x14, 0x4C, 0xFF);

        [DisplayName("Camp System: Tutorial Daily BG card keyframe 4")]
        public ConfigColor CampTutorialDailyKeyframe4 { get; set; } = new ConfigColor(0x46, 0x20, 0x00, 0xFF);

        [DisplayName("Camp System: Tutorial Dictionary BG card keyframe 1")]
        public ConfigColor CampTutorialDictionaryKeyframe1 { get; set; } = new ConfigColor(0x00, 0x00, 0x00, 0xFF);

        [DisplayName("Camp System: Tutorial Dictionary BG card keyframe 2")]
        public ConfigColor CampTutorialDictionaryKeyframe2 { get; set; } = new ConfigColor(0x33, 0x00, 0x1E, 0xFF);

        [DisplayName("Camp System: Tutorial Dictionary BG card keyframe 3")]
        public ConfigColor CampTutorialDictionaryKeyframe3 { get; set; } = new ConfigColor(0x7F, 0x00, 0x3D, 0xFF);

        [DisplayName("Camp System: Tutorial Dungeon BG card keyframe 1")]
        public ConfigColor CampTutorialDungeonKeyframe1 { get; set; } = new ConfigColor(0x00, 0x00, 0x00, 0xFF);

        [DisplayName("Camp System: Tutorial Dungeon BG card keyframe 2")]
        public ConfigColor CampTutorialDungeonKeyframe2 { get; set; } = new ConfigColor(0x29, 0x00, 0x15, 0xFF);

        [DisplayName("Camp System: Tutorial Dungeon BG card keyframe 3")]
        public ConfigColor CampTutorialDungeonKeyframe3 { get; set; } = new ConfigColor(0x39, 0x00, 0x1B, 0xFF);

        [DisplayName("Camp System: Tutorial Dungeon BG card keyframe 4")]
        public ConfigColor CampTutorialDungeonKeyframe4 { get; set; } = new ConfigColor(0x00, 0x33, 0x0D, 0xFF);

        [DisplayName("Camp System: Tutorial System BG card keyframe 1")]
        public ConfigColor CampTutorialSystemKeyframe1 { get; set; } = new ConfigColor(0x00, 0x00, 0x00, 0xFF);

        [DisplayName("Camp System: Tutorial System BG card keyframe 2")]
        public ConfigColor CampTutorialSystemKeyframe2 { get; set; } = new ConfigColor(0x40, 0x00, 0x1D, 0xFF);

        [DisplayName("Camp System: Tutorial System BG card keyframe 3")]
        public ConfigColor CampTutorialSystemKeyframe3 { get; set; } = new ConfigColor(0x99, 0x33, 0x63, 0xFF);


        [DisplayName("Battle: Theurgy Unk 1")]
        public ConfigColor BtlTheurgySpark1 { get; set; } = new ConfigColor(0xEA, 0x4A, 0xA3, 0xFF);

        [DisplayName("Battle: Theurgy Unk 2")]
        public ConfigColor BtlTheurgyPersonalityDescription { get; set; } = new ConfigColor(0xFF, 0xE9, 0xAC, 0xFF);

        [DisplayName("Battle: Theurgy Unk 3")]
        public ConfigColor BtlTheurgySpark2 { get; set; } = new ConfigColor(0xDC, 0x3F, 0x8C, 0xFF);

        [DisplayName("Battle: Theurgy Unk 5")]
        public ConfigColor BtlTheurgyDescription { get; set; } = new ConfigColor(0xFF, 0xE9, 0xAC, 0xFF);

        [DisplayName("Battle: Theurgy Unk 6")]
        public ConfigColor BtlTheurgyBarHighlight { get; set; } = new ConfigColor(0xCC, 0x22, 0x60, 0xFF);

        [DisplayName("Battle: Theurgy Unk 7")]
        public ConfigColor BtlTheurgyBGColour { get; set; } = new ConfigColor(0xCC, 0x22, 0x60, 0xFF);

        [DisplayName("Battle: Theurgy Unk 8")]
        public ConfigColor BtlTheurgyPersonaShadow { get; set; } = new ConfigColor(0xFF, 0x5F, 0xAA, 0xFF);

        [DisplayName("Battle: Theurgy Unk 9")]
        public ConfigColor BtlTheurgyPersonaShadow2 { get; set; } = new ConfigColor(0x6B, 0x3D, 0x5F, 0xFF);

        [DisplayName("Battle: Theurgy Unk 10")]
        public ConfigColor BtlTheurgyPersonalityCircleHighlight { get; set; } = new ConfigColor(0x45, 0x27, 0x45, 0xFF);

        [DisplayName("Battle: Theurgy Unk 11")]
        public ConfigColor BtlTheurgyPersonalityCircleBG { get; set; } = new ConfigColor(0x4B, 0x2B, 0x46, 0xFF);

        [DisplayName("Battle: Theurgy Unk 12")]
        public ConfigColor BtlTheurgyPersonalityTitle { get; set; } = new ConfigColor(0x67, 0x47, 0x5B, 0xFF);

        [DisplayName("Battle: Theurgy Unk 13")]
        public ConfigColor BtlTheurgyModelColour1 { get; set; } = new ConfigColor(0x99, 0x15, 0x44, 0xFF);

        [DisplayName("Battle: Theurgy Unk 14")]
        public ConfigColor BtlTheurgyPersonalityCircleDescription { get; set; } = new ConfigColor(0x85, 0x3D, 0x52, 0xFF);

        [DisplayName("Battle: Theurgy Unk 15")]
        public ConfigColor BtlTheurgyUnk15 { get; set; } = new ConfigColor(0x00, 0xD6, 0xFF, 0xFF);

        [DisplayName("Battle: Theurgy Model Colour 2")]
        public ConfigColor BtlTheurgyModelColour2 { get; set; } = new ConfigColor(0xCC, 0x22, 0x60, 0xFF);

        [DisplayName("Camp Root: Character Outline")]
        public ConfigColor EditRootFillColor { get; set; } = new ConfigColor(0xE5, 0x5E, 0x84, 0xFF);

        [DisplayName("Camp Skill: Character Outline")]
        public ConfigColor EditSkillFillColor { get; set; } = new ConfigColor(0xE5, 0x5E, 0x84, 0xFF);

        [DisplayName("Camp Item: Character Outline")]
        public ConfigColor EditItemFillColor { get; set; } = new ConfigColor(0xE5, 0x5E, 0x84, 0xFF);

        [DisplayName("Camp Equip: Character Outline")]
        public ConfigColor EditEquipFillColor { get; set; } = new ConfigColor(0xE5, 0x5E, 0x84, 0xFF);

        [DisplayName("Camp Status: Character Outline")]
        public ConfigColor EditStatusFillColor { get; set; } = new ConfigColor(0xE5, 0x5E, 0x84, 0xFF);

        [DisplayName("Camp Quest: Character Outline")]
        public ConfigColor EditQuestFillColor { get; set; } = new ConfigColor(0xE5, 0x5E, 0x84, 0xFF);

        [DisplayName("Camp Commu: Character Outline")]
        public ConfigColor EditCommuFillColor { get; set; } = new ConfigColor(0xFF, 0x93, 0xB2, 0xFF);

        [DisplayName("Camp System: Character Outline")]
        public ConfigColor EditSystemFillColor { get; set; } = new ConfigColor(0xE5, 0x5E, 0x84, 0xFF);

        [DisplayName("Camp Config: Character Outline")]
        public ConfigColor EditConfigFillColor { get; set; } = new ConfigColor(0x81, 0x2C, 0x61, 0xFF);


        [DisplayName("Common: Universe Bustup Ambient Color")]
        public ConfigColor BustupUniverseAmbientColor { get; set; } = new ConfigColor(0xFF, 0x7C, 0xB5, 0xFF);

        [DisplayName("Common: Universe Bustup Light Color")]
        public ConfigColor BustupUniverseLightColor { get; set; } = new ConfigColor(0xFF, 0xE6, 0x7C, 0xFF);



        [DisplayName("Battle: Top UI Unkown 1")]
        public ConfigColor BtlTopUnk1 { get; set; } = new ConfigColor(0xFF, 0x71, 0xBD, 0xFF);

        [DisplayName("Battle: Top UI Main Circle Color")]
        public ConfigColor BtlTopMainCircleColor { get; set; } = new ConfigColor(0xFF, 0x6F, 0xC1, 0xFF);

        [DisplayName("Battle: Top UI Character Outline Color")]
        public ConfigColor BtlTopCharOutlineColor { get; set; } = new ConfigColor(0xDD, 0x0B, 0x73, 0xFF);

        [DisplayName("Battle: Top UI Theurgy Circle Color")]
        public ConfigColor BtlTopTheurgyCircleColor { get; set; } = new ConfigColor(0x6E, 0x05, 0x40, 0xFF);


        [DisplayName("Battle: Damage Text Color 1")]
        public ConfigColor BtlGuiDamageTextColor1 { get; set; } = new ConfigColor(0x72, 0x08, 0x4B, 0xFF);

        [DisplayName("Battle: Damage Text Color 2")]
        public ConfigColor BtlGuiDamageTextColor2 { get; set; } = new ConfigColor(0xFF, 0x82, 0xC1, 0xFF);

        [DisplayName("Battle: Damage Text Color 3")]
        public ConfigColor BtlGuiDamageTextColor3 { get; set; } = new ConfigColor(0xFF, 0x82, 0xC1, 0xFF);


        [DisplayName("Battle: One More 1")]
        public ConfigColor BtlGuiOneMoreColor1 { get; set; } = new ConfigColor(0xFF, 0x85, 0xAF, 0xFF);


        [DisplayName("Battle: One More 2")]
        public ConfigColor BtlGuiOneMoreColor2 { get; set; } = new ConfigColor(0xDD, 0x18, 0x5D, 0xFF);

        [DisplayName("Battle: One More 3")]
        public ConfigColor BtlGuiOneMoreColor3 { get; set; } = new ConfigColor(0xA3, 0x17, 0x50, 0xFF);


        [DisplayName("Battle: Rush 1")]
        public ConfigColor BtlGuiRush1 { get; set; } = new ConfigColor(0xD4, 0x17, 0x64, 0xFF);

        [DisplayName("Battle: Rush 2")]
        public ConfigColor BtlGuiRush2 { get; set; } = new ConfigColor(0x67, 0x0A, 0x3F, 0xFF);


        [DisplayName("Battle: Skill Name 1")]
        public ConfigColor BtlSkillName1 { get; set; } = new ConfigColor(0xFF, 0x87, 0xB8, 0xFF);

        [DisplayName("Battle: Skill Name 2")]
        public ConfigColor BtlSkillName2 { get; set; } = new ConfigColor(0xD4, 0x13, 0x68, 0xFF);

        [DisplayName("Battle: Skill Name 3")]
        public ConfigColor BtlSkillName3 { get; set; } = new ConfigColor(0x8D, 0x13, 0x60, 0xFF);


        [DisplayName("Battle: Target Info 1")]
        public ConfigColor BtlTargetInfo1 { get; set; } = new ConfigColor(0xCA, 0x2B, 0x67, 0xFF);

        [DisplayName("Battle: Target Info 2")]
        public ConfigColor BtlTargetInfo2 { get; set; } = new ConfigColor(0x94, 0x17, 0x56, 0xFF);

        [DisplayName("Battle: Target Info 3")]
        public ConfigColor BtlTargetInfo3 { get; set; } = new ConfigColor(0x94, 0x17, 0x56, 0xFF);

        [DisplayName("Battle: Target Info 4")]
        public ConfigColor BtlTargetInfo4 { get; set; } = new ConfigColor(0xF1, 0x8D, 0xCC, 0xFF);


        [DisplayName("Battle: Target Panel 1")]
        public ConfigColor BtlTargetPanel1 { get; set; } = new ConfigColor(0xEE, 0x50, 0xA0, 0xFF);

        [DisplayName("Battle: Target Panel 2")]
        public ConfigColor BtlTargetPanel2 { get; set; } = new ConfigColor(0x83, 0x1E, 0x57, 0xFF);

        [DisplayName("Battle: Target Panel 3")]
        public ConfigColor BtlTargetPanel3 { get; set; } = new ConfigColor(0xFA, 0x7C, 0xB7, 0xFF);

        [DisplayName("Battle: Target Panel 4")]
        public ConfigColor BtlTargetPanel4 { get; set; } = new ConfigColor(0xFF, 0x9C, 0xC4, 0xFF);

        [DisplayName("Battle: Target Panel 5")]
        public ConfigColor BtlTargetPanel5 { get; set; } = new ConfigColor(0xEE, 0x50, 0xA0, 0xFF);


        [DisplayName("Battle: Advantage BG Color")]
        public ConfigColor BtlAdvantageBGColor { get; set; } = new ConfigColor(0xD2, 0x0B, 0x63, 0xFF);

        [DisplayName("Battle: Advantage Line Color")]
        public ConfigColor BtlAdvantageLine { get; set; } = new ConfigColor(0xD2, 0x0B, 0x63, 0xFF);

        [DisplayName("Battle: Advantage SEES BG")]
        public ConfigColor BtlAdvantageSEESBG { get; set; } = new ConfigColor(0xD2, 0x0B, 0x63, 0xFF);


        [DisplayName("Field: Access Icon 00 Color 1")]
        public ConfigColor AccessIconTalk00Color1 { get; set; } = new ConfigColor(0xFF, 0x93, 0xA4, 0xFF);

        [DisplayName("Field: Access Icon 00 Color 1")]
        public ConfigColor AccessIconTalk00Color2 { get; set; } = new ConfigColor(0xD0, 0x39, 0x54, 0xFF);

        [DisplayName("Field: Access Icon 00 Color 1")]
        public ConfigColor AccessIconTalk01Color1 { get; set; } = new ConfigColor(0x7D, 0x06, 0x1F, 0xFF);

        [DisplayName("Field: Access Icon 00 Color 1")]
        public ConfigColor AccessIconTalk02Color1 { get; set; } = new ConfigColor(0x50, 0x00, 0x1B, 0xFF);

        [DisplayName("Town Map: Town Info detail highlighted arrows")]
        public ConfigColor TownMapHighlightedArrows { get; set; } = new ConfigColor(0x00, 0xD8, 0xFF, 0xFF);

        [DisplayName("Camp: System Menu Item starting fade animation color")]
        public ConfigColor CampSystemStartFadeColor { get; set; } = new ConfigColor(0x9f, 0x04, 0x38, 0xff);

        [DisplayName("Guidance: Guidance elements main background color")]
        public ConfigColor GuidanceMainBGColor { get; set; } = new ConfigColor(0x48, 0x44, 0x46, 0xff);

        [DisplayName("Guidance: Guidance elements squared background color")]
        public ConfigColor GuidanceSquareColor { get; set; } = new ConfigColor(0x72, 0x6c, 0x6e, 0xff);

        [DisplayName("Guidance: Guidance exclamation glow color")]
        public ConfigColor GuidanceExclamationGlowColor { get; set; } = new ConfigColor(0xff, 0x00, 0x6a, 0xff);

        [DisplayName("Guidance: Guidance exclamation main color")]
        public ConfigColor GuidanceExclamationMainColor { get; set; } = new ConfigColor(0xfc, 0xbb, 0xd6, 0xff);

        [DisplayName("End Game Selections: First selection background glow color")]
        public ConfigColor EndGameFirstGlowColor { get; set; } = new ConfigColor(0x8f, 0x00, 0x34, 0xff);

        [DisplayName("End Game Selections: First selection font color")]
        public ConfigColor EndGameFirstFontColor { get; set; } = new ConfigColor(0xff, 0x00, 0x62, 0xff);

        [DisplayName("End Game Selections: First selection background color")]
        public ConfigColor EndGameFirstBGColor { get; set; } = new ConfigColor(0xfc, 0xf0, 0xf6, 0xff);

        [DisplayName("End Game Selections: Subs font tint before second selection 1")]
        public ConfigColor EndGamePreSecondFontTint1 { get; set; } = new ConfigColor(0x97, 0x01, 0x38, 0xff);

        [DisplayName("End Game Selections: Subs font tint before second selection 2")]
        public ConfigColor EndGamePreSecondFontTint2 { get; set; } = new ConfigColor(0xb7, 0x01, 0x4a, 0xff);

        [DisplayName("End Game Selections: Second selection glow color 1")]
        public ConfigColor EndGameSecondGlowColor1 { get; set; } = new ConfigColor(0x9d, 0x3d, 0x62, 0xff);

        [DisplayName("End Game Selections: Second selection glow color 2")]
        public ConfigColor EndGameSecondGlowColor2 { get; set; } = new ConfigColor(0xcd, 0x00, 0x4b, 0xff);

        [DisplayName("End Game Selections: Second selection font glow color 1")]
        public ConfigColor EndGameSecondFontGlowColor1 { get; set; } = new ConfigColor(0xfe, 0x55, 0x96, 0xff);

        [DisplayName("End Game Selections: Second selection font glow color 2")]
        public ConfigColor EndGameSecondFontGlowColor2 { get; set; } = new ConfigColor(0xfe, 0x14, 0x6e, 0xff);

        [DisplayName("End Game Selections: Second selection font glow color 3")]
        public ConfigColor EndGameSecondFontGlowColor3 { get; set; } = new ConfigColor(0xff, 0x12, 0x75, 0xff);



        [DisplayName("Dungeon: DUI Situation Help 1")]
        public ConfigColor DUISituationHelp1 { get; set; } = new ConfigColor(0xB8, 0x00, 0x55, 0xFF);

        [DisplayName("Dungeon: DUI Situation Help 2")]
        public ConfigColor DUISituationHelp2 { get; set; } = new ConfigColor(0xCA, 0x24, 0x64, 0xFF);

        [DisplayName("Dungeon: DUI Situation Help 3")]
        public ConfigColor DUISituationHelp3 { get; set; } = new ConfigColor(0x70, 0x26, 0x46, 0xFF);

        [DisplayName("Dungeon: DUI Situation Help 4")]
        public ConfigColor DUISituationHelp4 { get; set; } = new ConfigColor(0x23, 0x12, 0x1B, 0xFF);


        [DisplayName("Battle: GUI Damage Color")]
        public ConfigColor BtlGuiDamageColor { get; set; } = new ConfigColor(0xFF, 0x82, 0xC1, 0xFF);



        [DisplayName("Mail: Main BG Color")]
        public ConfigColor MailDrawMainColor { get; set; } = new ConfigColor(0xD4, 0x2E, 0x65, 0xFF);

        [DisplayName("Mail: Main Color 1")]
        public ConfigColor MailDrawColor1 { get; set; } = new ConfigColor(0xCE, 0x2C, 0x62, 0xFF);

        [DisplayName("Mail: Main Color 2")]
        public ConfigColor MailDrawColor2 { get; set; } = new ConfigColor(0xE0, 0x37, 0x70, 0xFF);

        [DisplayName("Battle: Total Damage Color")]
        public ConfigColor BtlGuiTotalDamageColor { get; set; } = new ConfigColor(0xFF, 0x38, 0x95, 0xFF);

        [DisplayName("Battle: Total Damage Number Dropshadow Color 2")]
        public ConfigColor BtlGuiTotalDamageNumberDropshadowColor2 { get; set; } = new ConfigColor(0x28, 0x02, 0x1B, 0xFF);

        [DisplayName("Battle: Stupid Circle")]
        public ConfigColor BtlStupidCircleBehind { get; set; } = new ConfigColor(0xEC, 0x4F, 0x85, 0xFF);


        [DisplayName("Battle: Theurgy Arrows")]
        public ConfigColor BtlTheurgyArrows { get; set; } = new ConfigColor(0x00, 0xD6, 0xFF, 0xFF);


        [DisplayName("Assist Message Box: SUPPORT font color")]
        public ConfigColor MsgAssistSupportFontColor { get; set; } = new ConfigColor(0xEA, 0x17, 0x5D, 0xff);

        [DisplayName("System Network Message: Network background icon")]
        public ConfigColor MsgWindowSystemNetworkBgColor { get; set; } = new ConfigColor(0xC9, 0x00, 0x54, 0xff);

        [DisplayName("Network: Daily Action Second Blue Background Color")]
        public ConfigColor NetworkDailyActionSecondBlueBgColor { get; set; } = new ConfigColor(0x2E, 0x10, 0x1C, 0xE5);

        [DisplayName("Social Stats: Musical Notes Background Color")]
        public ConfigColor MusicNotesBgColor { get; set; } = new ConfigColor(0xFF, 0x1F, 0x75, 0xFF);


        [DisplayName("Battle: Strategy Instruct")]
        public ConfigColor BtlStrategyInstructAccent { get; set; } = new ConfigColor(0xFF, 0xD3, 0x99, 0xFF);

        [DisplayName("Battle: Strategy Instruct Color 1")]
        public ConfigColor BtlStrategyInstructColor1 { get; set; } = new ConfigColor(0xB3, 0x18, 0x51, 0xFF);

        [DisplayName("Battle: Strategy Instruct Color 2")]
        public ConfigColor BtlStrategyInstructColor2 { get; set; } = new ConfigColor(0xB3, 0x18, 0x51, 0xFF);

        [DisplayName("Battle: Strategy Instruct Color 3")]
        public ConfigColor BtlStrategyInstructColor3 { get; set; } = new ConfigColor(0x66, 0x05, 0x39, 0xFF);

        [DisplayName("Battle: Strategy Instruct Color Highlight")]
        public ConfigColor BtlStrategyInstructColorHighlight { get; set; } = new ConfigColor(0x00, 0xC2, 0xFF, 0xFF);


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
    }


    /// <summary>
    /// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
    /// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
    /// </summary>
    public class ConfiguratorMixin : ConfiguratorMixinBase
    {

        
    }
}
