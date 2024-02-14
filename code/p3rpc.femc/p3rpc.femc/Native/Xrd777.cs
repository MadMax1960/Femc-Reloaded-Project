using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Native
{
    // ===================================
    // GENERATED FROM UE4SS CXX HEADER DUMP
    // ===================================

    public enum EAppPauseObjectFlag : byte
    {
        Unknown = 0,
        CampUI = 1,
        CharacterModel = 2,
        FieldLocal = 4,
        SystemUI = 8,
        FacilityUI = 16,
        FieldSound = 32,
        FieldCrowd = 64,
        Always = 255,
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x278)]
    public unsafe struct AAppActor // : AActor
    {
        [FieldOffset(0x230)] public EAppPauseObjectFlag AppPauseFlags;
    }
    public enum UIGenericSelectDrawTitleType : uint
    {
        List = 0,
        Select = 1,
        Item = 2,
        Nothing = 3
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x428)]
    public unsafe struct AUIGenericSelectDraw // : AUIDrawBaseActor
    {
        [FieldOffset(0x02B8)] public FVector2D Edit_PointA;
        [FieldOffset(0x02C0)] public FVector2D Edit_PointD;
        [FieldOffset(0x02C8)] public FVector2D Edit_PointG;
        [FieldOffset(0x02D0)] public FVector2D Edit_PointH;
        [FieldOffset(0x02D8)] public float Edit_TitleLogo_LoopAnima_Offset_Min;
        [FieldOffset(0x02DC)] public float Edit_TitleLogo_LoopAnima_Offset_Max;
        [FieldOffset(0x02E0)] public float Edit_Character_LoopAnima_Offset_Min;
        [FieldOffset(0x02E4)] public float Edit_Character_LoopAnima_Offset_Max;
        [FieldOffset(0x02E8)] public int Edit_Cursor_AnimationFrame;
        [FieldOffset(0x02EC)] public int Edit_SubCursor_AnimationFrame;
        [FieldOffset(0x02F0)] public int Edit_InAnimation_1_1;
        [FieldOffset(0x02F4)] public int Edit_InAnimation_1_1_2;
        [FieldOffset(0x02F8)] public int Edit_InAnimation_1_3;
        [FieldOffset(0x02FC)] public int Edit_InAnimation_1_3_CharacterMask_DelayFrame;
        [FieldOffset(0x0300)] public int Edit_InAnimation_1_4_ListItem_InFrame;
        [FieldOffset(0x0304)] public int Edit_InAnimation_1_4_ListItem_DelayFrame;
        [FieldOffset(0x0308)] public int Edit_InAnimation_1_4_Cursor_InFrame;
        [FieldOffset(0x030C)] public int Edit_InAnimation_1_4_Cursor_DelayFrame;
        [FieldOffset(0x0310)] public int Edit_LoopAnima_Frame_Min;
        [FieldOffset(0x0314)] public int Edit_LoopAnima_Frame_Max;
        [FieldOffset(0x0318)] public int Edit_OutAnimation_3_1;
        [FieldOffset(0x031C)] public int Edit_CharacterChange_In_Frame;
        [FieldOffset(0x0320)] public int Edit_CharacterChange_Out_Frame;
        [FieldOffset(0x0324)] public int Edit_CharacterChange_Slide_Frame;
        [FieldOffset(0x0328)] public FColor Edit_TitleLogo_MorninColor;
        [FieldOffset(0x032C)] public FColor Edit_TitleLogo_AfterschoolColor;
        [FieldOffset(0x0330)] public FColor Edit_TitleLogo_NightColor;
        [FieldOffset(0x0334)] public FColor Edit_ListAndCharacter_MorninColor;
        [FieldOffset(0x0338)] public FColor Edit_ListAndCharacter_AfterschoolColor;
        [FieldOffset(0x033C)] public FColor Edit_ListAndCharacter_NightColor;
        [FieldOffset(0x0340)] public FColor Edit_CharacterBackPlate_MorninColor;
        [FieldOffset(0x0344)] public FColor Edit_CharacterBackPlate_AfterschoolColor;
        [FieldOffset(0x0348)] public FColor Edit_CharacterBackPlate_NightColor;
        [FieldOffset(0x0350)] public USprAsset* pSprAsset;
        [FieldOffset(0x0358)] public UPlgAsset* pPlgAsset;
        [FieldOffset(0x0360)] public UGenericSelectCharacterDataAsset* pCharacterDataAsset;
        [FieldOffset(0x03dc)] public UIGenericSelectDrawTitleType DrawTitleType;
        [FieldOffset(0x03e0)] public UGenericSelectSystemBase* PSystem;
        [FieldOffset(0x03e8)] public TArray<nint> CharacterEnableList; // TArray<UUIGenericSelectCharacter*>
        [FieldOffset(0x03f8)] public TArray<nint> CharacterDisableList; // TArray<UUIGenericSelectCharacter*>
        [FieldOffset(0x0408)] public AUIGenericSelect* Field408;
    }

    [StructLayout(LayoutKind.Sequential, Size = 0x10)]
    public unsafe struct FGenericSelectCharacterTextureItem
    {
        uint characterId;
        UTexture* pTexture;
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public unsafe struct UGenericSelectCharacterDataAsset //: public UAppDataAsset
    {
        [FieldOffset(0x30)] TArray<FGenericSelectCharacterTextureItem> Assets;
    };

    [StructLayout(LayoutKind.Sequential, Size = 0x28)]
    public unsafe struct UGenericSelectSystemBase //: public UObject
    {
    };

    [StructLayout(LayoutKind.Sequential, Size = 0x60)]
    public unsafe struct UUIGenericSelectCharacter //: public UObject
    {
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x370)]
    public unsafe struct AUIGenericSelect //: public AUIBaseActor
    {
        [FieldOffset(0x02F8)] public UGenericSelectSystemBase* System_;
        [FieldOffset(0x0300)] public UObjectBase* pAssetLoader; // UAssetLoader*
        [FieldOffset(0x0308)] public AUIGenericSelectDraw* pDrawClass;
        [FieldOffset(0x0310)] public AUIGenericSelectDraw* pDrawActor;
        [FieldOffset(0x0318)] public UDataTable* LayoutData;
        [FieldOffset(0x0320)] public UUILayoutDataTable* LayoutDataTable;
    };
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public unsafe struct UUILayoutDataTable //: public UObject
    {
        [FieldOffset(0x28)] public UDataTable* LayoutTable;
        [FieldOffset(0x30)] public TArray<nint> Entries;
    };
    [StructLayout(LayoutKind.Explicit, Size = 0x490)]
    public unsafe struct AUIMailIconDraw //: public AUIBaseActor
    {
        [FieldOffset(0x2a8)] public USprAsset* Sprite_;
        [FieldOffset(0x2C8)] public float Field2C8;
        [FieldOffset(0x2CC)] public float Field2CC;
        [FieldOffset(0x2D0)] public float Field2D0;
        [FieldOffset(0x318)] public float Field318;
        [FieldOffset(0x368)] public float Field368;
        [FieldOffset(0x3b8)] public float Field3B8;
        [FieldOffset(0x408)] public float Field408;
        [FieldOffset(0x458)] public float Field458;
    };

    // CAMP MENU

    [StructLayout(LayoutKind.Explicit, Size = 0x38)]
    public unsafe struct UCmpMenuBase //: public UObject
    {
        [FieldOffset(0x0030)] public ACmpMainActor* pMainActor;
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x30F0)]
    public unsafe struct ACmpMainActor //: public AAppActor
    {
        [FieldOffset(0x290)] public int MenuState;
        [FieldOffset(0x12C8)] public nint pAssetLoader;
        [FieldOffset(0x12D0)] public nint SceneCaptureClass;
        [FieldOffset(0x12D8)] public nint pSceneCapture2D;
        [FieldOffset(0x12E0)] public nint pCaptureMaterial;
        [FieldOffset(0x12E8)] public nint pCaptureInstanceDynamic;
        [FieldOffset(0x12F0)] public nint pOutlineMaterial;
        [FieldOffset(0x12F8)] public nint pOutlineInstanceDynamic;
        [FieldOffset(0x1300)] public nint pSimpleCopyMaterial;
        [FieldOffset(0x1308)] public nint pSimpleCopyMateDynamic;
        [FieldOffset(0x1310)] public nint pHologramMaterial;
        [FieldOffset(0x1318)] public nint pHologramMateDynamic;
        [FieldOffset(0x1320)] public UTexture2D* HologMaskTexAAry;
        [FieldOffset(0x1328)] public UTexture2D* HologMaskTexBAry;
        [FieldOffset(0x1330)] public UTexture2D* HologMaskTexCAry;
        [FieldOffset(0x1338)] public UTexture2D* HologMaskTexDAry;
        [FieldOffset(0x1340)] public nint pGlassMateDynamic;
        [FieldOffset(0x1348)] public nint pCaptureRenderTarget;
        [FieldOffset(0x1350)] public UTexture2D* HeroGaussMaskTexAry;
        [FieldOffset(0x13A8)] public UTexture2D* pOutAnimationTexture;
        [FieldOffset(0x13B0)] public USprAsset* pSprCommon;
        [FieldOffset(0x13B8)] public UUimAsset* pUimBgAry;
        [FieldOffset(0x13C8)] public UDataTable* pParamHologTable; // FCampParamTableHologRow
        [FieldOffset(0x13D0)] public UDataTable* pParamTopTable; // FCampParamTableTopRow
        [FieldOffset(0x13D8)] public UDataTable* pParamSkillTable; // FCampParamTableSkillRow
        [FieldOffset(0x13E0)] public UDataTable* pParamItemTable; // FCampParamTableItemRow
        [FieldOffset(0x13E8)] public UDataTable* pParamEquipTable; // FCampParamTableEquipRow
        [FieldOffset(0x13F0)] public UDataTable* pParamPersonaTable; // FCampParamTablePersonaRow
        [FieldOffset(0x13F8)] public UDataTable* pParamStatusTable; // FCampParamTableStatusRow
        [FieldOffset(0x1400)] public UDataTable* pParamRankUpTable; // FCampParamTableRankUpRow
        [FieldOffset(0x1408)] public UDataTable* pParamCommuTable; // FCampParamTableCommuRow
        [FieldOffset(0x1410)] public UDataTable* pParamSystemTable; // FCampParamTableSystemRow
        [FieldOffset(0x1418)] public UDataTable* pParamCommonTable; // FCampParamTableCommonRow
        [FieldOffset(0x1420)] public UDataTable* pCameraTable;
        [FieldOffset(0x1428)] public UDataTable* pHologramTable;
        [FieldOffset(0x1430)] public nint pMateWaveCaustics;
        [FieldOffset(0x1438)] public UDataTable* pParamLayoutDataRoot;
        [FieldOffset(0x1440)] public UDataTable* pParamLayoutDataSystem;
        [FieldOffset(0x1448)] public UDataTable* pParamTriangularCursorDataRoot;
        [FieldOffset(0x1450)] public UDataTable* pParamTriangularCursorDataSystem;
        [FieldOffset(0x1458)] public UDataTable* pParamLayoutDataQuest;
        [FieldOffset(0x1460)] public UDataTable* pParamLayoutDataQuestDate;
        [FieldOffset(0x1468)] public UDataTable* pParamLayoutPersonaList;
        [FieldOffset(0x1470)] public UDataTable* pParamLayoutDataItem;
        [FieldOffset(0x1478)] public UDataTable* pParamLayoutDataSkill;
        [FieldOffset(0x1480)] public UDataTable* pParamLayoutDataSkill2;
        [FieldOffset(0x1488)] public UDataTable* pParamLayoutDataOthers;
        [FieldOffset(0x1490)] public UDataTable* pParamLayoutDataHelpOthers;
        [FieldOffset(0x1498)] public UDataTable* pParamLayoutDataPartyPanel;
        [FieldOffset(0x14A0)] public UDataTable* pParamLayoutDataTutorialText;
        [FieldOffset(0x14A8)] public UDataTable* pParamLayoutDataDictionaryText;
        [FieldOffset(0x14B0)] public UDataTable* pParamLayoutDataCalendarText;
        [FieldOffset(0x14B8)] public UDataTable* pParamLayoutDataEquipTextCol;
        [FieldOffset(0x14C0)] public UDataTable* pParamLayoutDataItemTextCol;
        [FieldOffset(0x14C8)] public UDataTable* pParamLayoutDataQuestTextCol;
        [FieldOffset(0x14D0)] public UDataTable* pParamLayoutDataQuestTextPos;
        [FieldOffset(0x14D8)] public UDataTable* pParamLayoutDataCommuTextCol;
        [FieldOffset(0x14E0)] public UDataTable* pParamLayoutDataStatusTextCol;
        [FieldOffset(0x14E8)] public UDataTable* pParamLayoutDataOkNext;
        [FieldOffset(0x14F0)] public UDataTable* pParamLayoutDataOkNextMask;
        [FieldOffset(0x14F8)] public UDataTable* pParamLayoutDataRootTouchColl;
        [FieldOffset(0x1500)] public UDataTable* pParamLayoutDataSystemTouchColl;
        [FieldOffset(0x1508)] public UUimAsset* pUimNamiRootAAry;
        [FieldOffset(0x15F8)] public UUimAsset* pUimNamiRootBAry;
        [FieldOffset(0x16E8)] public UUimAsset* pUimNamiSkillAAry;
        [FieldOffset(0x17D8)] public UUimAsset* pUimNamiSkillBAry;
        [FieldOffset(0x18C8)] public UUimAsset* pUimNamiItemAAry;
        [FieldOffset(0x19B8)] public UUimAsset* pUimNamiItemBAry;
        [FieldOffset(0x1AA8)] public UUimAsset* pUimNamiEquipAAry;
        [FieldOffset(0x1B98)] public UUimAsset* pUimNamiEquipBAry;
        [FieldOffset(0x1C88)] public UUimAsset* pUimNamiPersonaAAry;
        [FieldOffset(0x1D78)] public UUimAsset* pUimNamiPersonaBAry;
        [FieldOffset(0x1E68)] public UUimAsset* pUimNamiStatusAAry;
        [FieldOffset(0x1F58)] public UUimAsset* pUimNamiStatusBAry;
        [FieldOffset(0x2048)] public UUimAsset* pUimNamiQuestAAry;
        [FieldOffset(0x2138)] public UUimAsset* pUimNamiQuestBAry;
        [FieldOffset(0x2228)] public UUimAsset* pUimNamiCommuAAry;
        [FieldOffset(0x2318)] public UUimAsset* pUimNamiCommuBAry;
        [FieldOffset(0x2408)] public UUimAsset* pUimNamiCalendarAAry;
        [FieldOffset(0x24F8)] public UUimAsset* pUimNamiCalendarBAry;
        [FieldOffset(0x25E8)] public UUimAsset* pUimNamiSystemAAry;
        [FieldOffset(0x26D8)] public UUimAsset* pUimNamiSystemBAry;
        [FieldOffset(0x27C8)] public UUimAsset* pUimNamiTutorialAAry;
        [FieldOffset(0x28B8)] public UUimAsset* pUimNamiTutorialBAry;
        [FieldOffset(0x29A8)] public UUimAsset* pUimNamiConfigAAry;
        [FieldOffset(0x2A98)] public UUimAsset* pUimNamiConfigBAry;
        [FieldOffset(0x2B88)] public UTexture2D* pCharaGlassAry;
        [FieldOffset(0x2BD8)] public UTexture2D* pCharaDetailAry;
        [FieldOffset(0x2C28)] public UTexture2D* pCharaDetailShdAry;
        [FieldOffset(0x2C98)] public TArray<nint> MenuList;
        [FieldOffset(0x2CB0)] public UCmpMenuBase* pCurrentMenu;
        [FieldOffset(0x2CB8)] public UCmpMenuBase* pNextMenu;
        [FieldOffset(0x2CC0)] public UCmpMenuBase* pPrevMenu;
        [FieldOffset(0x2CC8)] public nint pModelController;
        [FieldOffset(0x2CD0)] public nint pCmpMainLoadActor;
        [FieldOffset(0x2CE0)] public nint pHeroCharaClass;
        [FieldOffset(0x2CE8)] public nint pHeroAnimCtrl;
        [FieldOffset(0x2CF0)] public TArray<nint> MateInterAry;
        [FieldOffset(0x2D00)] public bool bIsDisableForceTermination;
        [FieldOffset(0x2D02)] public bool bEquipChange;
        [FieldOffset(0x2D03)] public bool bReturnCommuToField;
        [FieldOffset(0x2D08)] public nint pUIRequest;
        [FieldOffset(0x2D10)] public nint pUIMissingPerson;
        [FieldOffset(0x2D18)] public nint pUITheurgia;
        [FieldOffset(0x3028)] public UUILayoutDataTable* RootLayoutDataTable;
        [FieldOffset(0x3030)] public UUILayoutDataTable* SystemLayoutDataTable;
        [FieldOffset(0x3038)] public UUILayoutDataTable* QuestLayoutDataTable;
        [FieldOffset(0x3040)] public UUILayoutDataTable* QuestDateLayoutDataTable;
        [FieldOffset(0x3048)] public UUILayoutDataTable* OthersLayoutDataTable;
        [FieldOffset(0x3050)] public UUILayoutDataTable* HelpOthersLayoutDataTable;
        [FieldOffset(0x3058)] public UUILayoutDataTable* PersonaListLayoutDataTable;
        [FieldOffset(0x3060)] public UUILayoutDataTable* ItemLayoutDataTable;
        [FieldOffset(0x3068)] public UUILayoutDataTable* SkillLayoutDataTable;
        [FieldOffset(0x3070)] public UUILayoutDataTable* SkillLayoutDataTable2;
        [FieldOffset(0x3078)] public UUILayoutDataTable* PartyPanelLayoutDataTable;
        [FieldOffset(0x3080)] public UUILayoutDataTable* TutorialTextLayoutDataTable;
        [FieldOffset(0x3088)] public UUILayoutDataTable* DictionaryTextLayoutDataTable;
        [FieldOffset(0x3090)] public UUILayoutDataTable* CalendarTextLayoutDataTable;
        [FieldOffset(0x3098)] public UUILayoutDataTable* EquipTextColLayoutDataTable;
        [FieldOffset(0x30A0)] public UUILayoutDataTable* ItemTextColLayoutDataTable;
        [FieldOffset(0x30A8)] public UUILayoutDataTable* QuestTextColLayoutDataTable;
        [FieldOffset(0x30B0)] public UUILayoutDataTable* QuestTextPosLayoutDataTable;
        [FieldOffset(0x30B8)] public UUILayoutDataTable* CommuTextColLayoutDataTable;
        [FieldOffset(0x30C0)] public UUILayoutDataTable* StatusTextColLayoutDataTable;
        [FieldOffset(0x30C8)] public UUILayoutDataTable* OkNextLayoutDataTable;
        [FieldOffset(0x30D0)] public UUILayoutDataTable* OkNextMaskLayoutDataTable;
        [FieldOffset(0x30D8)] public UUILayoutDataTable* RootTouchCollLayoutDataTable;
        [FieldOffset(0x30E0)] public UUILayoutDataTable* SystemTouchCollLayoutDataTable;
    };

    public enum EOneAnimType : byte
    {
        Linear = 0,
        Sin90 = 1,
        Sin180 = 2,
        Sin360 = 3,
        HSin180 = 4,
        EaseInOut = 5,
        EaseOut1 = 6,
        EaseOut2 = 7,
        EaseOut3 = 8,
        CurveUp1 = 9,
        CurveUp2 = 10,
        CurveUp3 = 11,
        CurveDown1 = 12,
        CurveDown2 = 13,
        CurveDown3 = 14,
        Haneru1 = 15,
        Haneru1ST1 = 16,
        Haneru2 = 17,
        Haneru3 = 18,
        Fuwari1 = 19,
        Bowa1 = 20,
        Gachan2 = 21,
        KaesiSlide2 = 22,
        ButtonPush = 23,
        YureruRot = 24,
        Max = 25,
    };

    public enum EUIGaussType : byte
    {
        VeryWeak1 = 0,
        Weak2 = 1,
        Normal3 = 2,
        Strong4 = 3,
        VeryStrong5 = 4,
        MostWeak0 = 5,
        Off = 6,
        EUIGaussType_MAX = 7,
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x4D8)]
    public unsafe struct FCampParamTableCommonRow //: public FTableRowBase
    {
        [FieldOffset(0x0008)] public EOneAnimType ListAllSlideAnimType;
        [FieldOffset(0x000C)] public uint ListAllSlideFrame;
        [FieldOffset(0x0010)] public uint ListAllSlideBackFrame;
        [FieldOffset(0x0014)] public EOneAnimType Edit_List_Cursor_Anim_Type;
        [FieldOffset(0x0018)] public uint Edit_List_Cursor_Slide_Frame;
        [FieldOffset(0x001C)] public EOneAnimType Edit_List_Party_RedCursor_Anim_Type;
        [FieldOffset(0x0020)] public uint Edit_List_Party_RedCursor_Slide_Frame;
        [FieldOffset(0x0024)] public EOneAnimType Edit_List_Commu_RedCursor_Anim_Type;
        [FieldOffset(0x0028)] public uint Edit_List_Commu_RedCursor_Slide_Frame;
        [FieldOffset(0x002C)] public EOneAnimType ListRedSlideAnimType;
        [FieldOffset(0x0030)] public uint ListRedSlideFrame;
        [FieldOffset(0x0034)] public uint ListRedSlideWait;
        [FieldOffset(0x0038)] public uint ListRedSlideBackFrame;
        [FieldOffset(0x003C)] public uint HPSPFlashFrame;
        [FieldOffset(0x0040)] public EOneAnimType TabShakeAnimType;
        [FieldOffset(0x0044)] public uint TabShakeFrame;
        [FieldOffset(0x0048)] public EOneAnimType TabLoopAnimType;
        [FieldOffset(0x004C)] public uint TabLoopFrame;
        [FieldOffset(0x0050)] public EOneAnimType CampOKScaleAnimType;
        [FieldOffset(0x0054)] public uint CampOKScaleFrame;
        [FieldOffset(0x0058)] public uint CampOKScaleWait;
        [FieldOffset(0x005C)] public float CampOKEndScale;
        [FieldOffset(0x0060)] public EOneAnimType CampOKInScaleAnimType;
        [FieldOffset(0x0064)] public uint CampOKInScaleFrame;
        [FieldOffset(0x0068)] public uint CampOKInScaleWait;
        [FieldOffset(0x006C)] public float CampOKInEndScale;
        [FieldOffset(0x0070)] public float CampOKCaptureScale;
        [FieldOffset(0x0074)] public EOneAnimType PartyPanelInFlagSlideAnimType;
        [FieldOffset(0x0078)] public uint PartyPanelInFlagSlideFrame;
        [FieldOffset(0x007C)] public uint PartyPanelInFlagSlideBackFrame;
        [FieldOffset(0x0080)] public EOneAnimType WipeChangeMaskAAnimType;
        [FieldOffset(0x0084)] public uint WipeChangeMaskAFrame;
        [FieldOffset(0x0088)] public EOneAnimType WipeChangeMaskBAnimType;
        [FieldOffset(0x008C)] public uint WipeChangeMaskBFrame;
        [FieldOffset(0x0090)] public uint WipeChangeMaskBWait;
        [FieldOffset(0x0094)] public float WipeChangeCaptureScale;
        [FieldOffset(0x0098)] public uint WipeCloseMaskAFrame;
        [FieldOffset(0x009C)] public uint WipeCloseMaskBWait;
        [FieldOffset(0x00A0)] public EOneAnimType SuitekiAnimType;
        [FieldOffset(0x00A4)] public uint SuitekiFrame;
        [FieldOffset(0x00A8)] public byte HighpassBrightThreshold;
        [FieldOffset(0x00AC)] public float HighpassBrightScale;
        [FieldOffset(0x00B0)] public FColor AoItaColorHigh;
        [FieldOffset(0x00B4)] public FColor AoItaColorMid;
        [FieldOffset(0x00B8)] public FColor AoItaColorLow;
        [FieldOffset(0x00BC)] public FColor GradAUpColorHigh;
        [FieldOffset(0x00C0)] public FColor GradADownColorHigh;
        [FieldOffset(0x00C4)] public FColor GradBUpColorHigh;
        [FieldOffset(0x00C8)] public FColor GradBDownColorHigh;
        [FieldOffset(0x00CC)] public FColor GradAUpColorMid;
        [FieldOffset(0x00D0)] public FColor GradADownColorMid;
        [FieldOffset(0x00D4)] public FColor GradBUpColorMid;
        [FieldOffset(0x00D8)] public FColor GradBDownColorMid;
        [FieldOffset(0x00DC)] public FColor GradAUpColorLow;
        [FieldOffset(0x00E0)] public FColor GradADownColorLow;
        [FieldOffset(0x00E4)] public FColor GradBUpColorLow;
        [FieldOffset(0x00E8)] public FColor GradBDownColorLow;
        [FieldOffset(0x00EC)] public FColor HeroCaptureBgColor;
        [FieldOffset(0x00F0)] public EUIGaussType HeroGaussType;
        [FieldOffset(0x00F1)] public byte HeroGaussHorizontal;
        [FieldOffset(0x00F2)] public byte HeroGaussVertical;
        [FieldOffset(0x00F4)] public float HeroGaussScale;
        [FieldOffset(0x00F8)] public float HeroBlurPrev1Offset;
        [FieldOffset(0x00FC)] public byte HeroBlurPrev1Alpha;
        [FieldOffset(0x0100)] public float HeroBlurPrev2Offset;
        [FieldOffset(0x0104)] public byte HeroBlurPrev2Alpha;
        [FieldOffset(0x0108)] public uint NamiOneFrame;
        [FieldOffset(0x010C)] public float NamiAlpha;
        [FieldOffset(0x0110)] public EUIGaussType NamiGaussType;
        [FieldOffset(0x0114)] public FVector2D NamiTopAOfsPos;
        [FieldOffset(0x011C)] public FVector2D NamiTopAScale;
        [FieldOffset(0x0124)] public FColor NamiTopAColor;
        [FieldOffset(0x0128)] public bool NamiTopAAddBlend;
        [FieldOffset(0x012C)] public FVector2D NamiTopBOfsPos;
        [FieldOffset(0x0134)] public FVector2D NamiTopBScale;
        [FieldOffset(0x013C)] public FColor NamiTopBColor;
        [FieldOffset(0x0140)] public bool NamiTopBAddBlend;
        [FieldOffset(0x0144)] public FVector2D NamiSkillAOfsPos;
        [FieldOffset(0x014C)] public FVector2D NamiSkillAScale;
        [FieldOffset(0x0154)] public FColor NamiSkillAColor;
        [FieldOffset(0x0158)] public bool NamiSkillAAddBlend;
        [FieldOffset(0x015C)] public FVector2D NamiSkillBOfsPos;
        [FieldOffset(0x0164)] public FVector2D NamiSkillBScale;
        [FieldOffset(0x016C)] public FColor NamiSkillBColor;
        [FieldOffset(0x0170)] public bool NamiSkillBAddBlend;
        [FieldOffset(0x0174)] public FVector2D NamiItemAOfsPos;
        [FieldOffset(0x017C)] public FVector2D NamiItemAScale;
        [FieldOffset(0x0184)] public FColor NamiItemAColor;
        [FieldOffset(0x0188)] public bool NamiItemAAddBlend;
        [FieldOffset(0x018C)] public FVector2D NamiItemBOfsPos;
        [FieldOffset(0x0194)] public FVector2D NamiItemBScale;
        [FieldOffset(0x019C)] public FColor NamiItemBColor;
        [FieldOffset(0x01A0)] public bool NamiItemBAddBlend;
        [FieldOffset(0x01A4)] public FVector2D NamiEquipAOfsPos;
        [FieldOffset(0x01AC)] public FVector2D NamiEquipAScale;
        [FieldOffset(0x01B4)] public FColor NamiEquipAColor;
        [FieldOffset(0x01B8)] public bool NamiEquipAAddBlend;
        [FieldOffset(0x01BC)] public FVector2D NamiEquipBOfsPos;
        [FieldOffset(0x01C4)] public FVector2D NamiEquipBScale;
        [FieldOffset(0x01CC)] public FColor NamiEquipBColor;
        [FieldOffset(0x01D0)] public bool NamiEquipBAddBlend;
        [FieldOffset(0x01D4)] public FVector2D NamiPersonaAOfsPos;
        [FieldOffset(0x01DC)] public FVector2D NamiPersonaAScale;
        [FieldOffset(0x01E4)] public FColor NamiPersonaAColor;
        [FieldOffset(0x01E8)] public bool NamiPersonaAAddBlend;
        [FieldOffset(0x01EC)] public FVector2D NamiPersonaBOfsPos;
        [FieldOffset(0x01F4)] public FVector2D NamiPersonaBScale;
        [FieldOffset(0x01FC)] public FColor NamiPersonaBColor;
        [FieldOffset(0x0200)] public bool NamiPersonaBAddBlend;
        [FieldOffset(0x0204)] public FVector2D NamiStatusAOfsPos;
        [FieldOffset(0x020C)] public FVector2D NamiStatusAScale;
        [FieldOffset(0x0214)] public FColor NamiStatusAColor;
        [FieldOffset(0x0218)] public bool NamiStatusAAddBlend;
        [FieldOffset(0x021C)] public FVector2D NamiStatusBOfsPos;
        [FieldOffset(0x0224)] public FVector2D NamiStatusBScale;
        [FieldOffset(0x022C)] public FColor NamiStatusBColor;
        [FieldOffset(0x0230)] public bool NamiStatusBAddBlend;
        [FieldOffset(0x0234)] public FVector2D NamiQuestAOfsPos;
        [FieldOffset(0x023C)] public FVector2D NamiQuestAScale;
        [FieldOffset(0x0244)] public FColor NamiQuestAColor;
        [FieldOffset(0x0248)] public bool NamiQuestAAddBlend;
        [FieldOffset(0x024C)] public FVector2D NamiQuestBOfsPos;
        [FieldOffset(0x0254)] public FVector2D NamiQuestBScale;
        [FieldOffset(0x025C)] public FColor NamiQuestBColor;
        [FieldOffset(0x0260)] public bool NamiQuestBAddBlend;
        [FieldOffset(0x0264)] public FVector2D NamiCommuAOfsPos;
        [FieldOffset(0x026C)] public FVector2D NamiCommuAScale;
        [FieldOffset(0x0274)] public FColor NamiCommuAColor;
        [FieldOffset(0x0278)] public bool NamiCommuAAddBlend;
        [FieldOffset(0x027C)] public FVector2D NamiCommuBOfsPos;
        [FieldOffset(0x0284)] public FVector2D NamiCommuBScale;
        [FieldOffset(0x028C)] public FColor NamiCommuBColor;
        [FieldOffset(0x0290)] public bool NamiCommuBAddBlend;
        [FieldOffset(0x0294)] public FVector2D NamiCalendarAOfsPos;
        [FieldOffset(0x029C)] public FVector2D NamiCalendarAScale;
        [FieldOffset(0x02A4)] public FColor NamiCalendarAColor;
        [FieldOffset(0x02A8)] public bool NamiCalendarAAddBlend;
        [FieldOffset(0x02AC)] public FVector2D NamiCalendarBOfsPos;
        [FieldOffset(0x02B4)] public FVector2D NamiCalendarBScale;
        [FieldOffset(0x02BC)] public FColor NamiCalendarBColor;
        [FieldOffset(0x02C0)] public bool NamiCalendarBAddBlend;
        [FieldOffset(0x02C4)] public FVector2D NamiSystemAOfsPos;
        [FieldOffset(0x02CC)] public FVector2D NamiSystemAScale;
        [FieldOffset(0x02D4)] public FColor NamiSystemAColor;
        [FieldOffset(0x02D8)] public bool NamiSystemAAddBlend;
        [FieldOffset(0x02DC)] public FVector2D NamiSystemBOfsPos;
        [FieldOffset(0x02E4)] public FVector2D NamiSystemBScale;
        [FieldOffset(0x02EC)] public FColor NamiSystemBColor;
        [FieldOffset(0x02F0)] public bool NamiSystemBAddBlend;
        [FieldOffset(0x02F4)] public FVector2D NamiTutorialAOfsPos;
        [FieldOffset(0x02FC)] public FVector2D NamiTutorialAScale;
        [FieldOffset(0x0304)] public FColor NamiTutorialAColor;
        [FieldOffset(0x0308)] public bool NamiTutorialAAddBlend;
        [FieldOffset(0x030C)] public FVector2D NamiTutorialBOfsPos;
        [FieldOffset(0x0314)] public FVector2D NamiTutorialBScale;
        [FieldOffset(0x031C)] public FColor NamiTutorialBColor;
        [FieldOffset(0x0320)] public bool NamiTutorialBAddBlend;
        [FieldOffset(0x0324)] public FVector2D NamiConfigAOfsPos;
        [FieldOffset(0x032C)] public FVector2D NamiConfigAScale;
        [FieldOffset(0x0334)] public FColor NamiConfigAColor;
        [FieldOffset(0x0338)] public bool NamiConfigAAddBlend;
        [FieldOffset(0x033C)] public FVector2D NamiConfigBOfsPos;
        [FieldOffset(0x0344)] public FVector2D NamiConfigBScale;
        [FieldOffset(0x034C)] public FColor NamiConfigBColor;
        [FieldOffset(0x0350)] public bool NamiConfigBAddBlend;
        [FieldOffset(0x0354)] public FColor LightVecOfsTop;
        [FieldOffset(0x0364)] public FColor LightVecOfsSkill;
        [FieldOffset(0x0374)] public FColor LightVecOfsItem;
        [FieldOffset(0x0384)] public FColor LightVecOfsEquip;
        [FieldOffset(0x0394)] public FColor LightVecOfsPersona;
        [FieldOffset(0x03A4)] public FColor LightVecOfsStatus;
        [FieldOffset(0x03B4)] public FColor LightVecOfsQuest;
        [FieldOffset(0x03C4)] public FColor LightVecOfsCommu;
        [FieldOffset(0x03D4)] public FColor LightVecOfsCalender;
        [FieldOffset(0x03E4)] public FColor LightVecOfsSystem;
        [FieldOffset(0x03F4)] public uint Edit_Key_Lock_Frame;
        [FieldOffset(0x03F8)] public float Edit_GuideLine_X;
        [FieldOffset(0x03FC)] public uint Edit_StatusKeyLockFrame;
        [FieldOffset(0x0400)] public FColor Edit_Root_FillColor;
        [FieldOffset(0x0410)] public float Edit_Root_Near;
        [FieldOffset(0x0414)] public float Edit_Root_Far;
        [FieldOffset(0x0418)] public FColor Edit_Skill_FillColor;
        [FieldOffset(0x0428)] public float Edit_Skill_Near;
        [FieldOffset(0x042C)] public float Edit_Skill_Far;
        [FieldOffset(0x0430)] public FColor Edit_Item_FillColor;
        [FieldOffset(0x0440)] public float Edit_Item_Near;
        [FieldOffset(0x0444)] public float Edit_Item_Far;
        [FieldOffset(0x0448)] public FColor Edit_Equip_FillColor;
        [FieldOffset(0x0458)] public float Edit_Equip_Near;
        [FieldOffset(0x045C)] public float Edit_Equip_Far;
        [FieldOffset(0x0460)] public FColor Edit_Status_FillColor;
        [FieldOffset(0x0470)] public float Edit_Status_Near;
        [FieldOffset(0x0474)] public float Edit_Status_Far;
        [FieldOffset(0x0478)] public FColor Edit_Quest_FillColor;
        [FieldOffset(0x0488)] public float Edit_Quest_Near;
        [FieldOffset(0x048C)] public float Edit_Quest_Far;
        [FieldOffset(0x0490)] public FColor Edit_Commu_FillColor;
        [FieldOffset(0x04A0)] public float Edit_Commu_Near;
        [FieldOffset(0x04A4)] public float Edit_Commu_Far;
        [FieldOffset(0x04A8)] public FColor Edit_System_FillColor;
        [FieldOffset(0x04B8)] public float Edit_System_Near;
        [FieldOffset(0x04BC)] public float Edit_System_Far;
        [FieldOffset(0x04C0)] public FColor Edit_Config_FillColor;
        [FieldOffset(0x04D0)] public float Edit_Config_Near;
        [FieldOffset(0x04D4)] public float Edit_Config_Far;
    };

    [StructLayout(LayoutKind.Explicit, Size = 0xa0)]
    public unsafe struct FCampParamTableCommuRow //: public FTableRowBase
    {
        [FieldOffset(0x0008)] public EOneAnimType CommListInSilhouetteAnimType;
        [FieldOffset(0x000C)] public uint CommListInSilhouetteFrame;
        [FieldOffset(0x0010)] public uint CommListInSilhouetteWait;
        [FieldOffset(0x0014)] public EOneAnimType CommListInSiroItaAnimType;
        [FieldOffset(0x0018)] public uint CommListInSiroItaFrame;
        [FieldOffset(0x001C)] public uint CommListInSiroItaWait;
        [FieldOffset(0x0020)] public uint CommListOutSiroItaFrame;
        [FieldOffset(0x0024)] public EOneAnimType CommListInListAnimType;
        [FieldOffset(0x0028)] public uint CommListInListFrame;
        [FieldOffset(0x002C)] public uint CommListInListWait;
        [FieldOffset(0x0030)] public uint CommListOutListFrame;
        [FieldOffset(0x0034)] public EOneAnimType CommDetlInDetailAnimType;
        [FieldOffset(0x0038)] public uint CommDetlInDetailFrame;
        [FieldOffset(0x003C)] public uint CommDetlInDetailWait;
        [FieldOffset(0x0040)] public uint CommDetlOutDetailFrame;
        [FieldOffset(0x0044)] public EOneAnimType CommDetlInDescriAnimType;
        [FieldOffset(0x0048)] public uint CommDetlInDescriFrame;
        [FieldOffset(0x004C)] public uint CommDetlInDescriWait;
        [FieldOffset(0x0050)] public EOneAnimType CommDetlInMemberAnimType;
        [FieldOffset(0x0054)] public uint CommDetlInMemberFrame;
        [FieldOffset(0x0058)] public uint CommDetlInMemberWait;
        [FieldOffset(0x005C)] public EOneAnimType CommDetlInBustupAnimType;
        [FieldOffset(0x0060)] public uint CommDetlInBustupFrame;
        [FieldOffset(0x0064)] public uint CommDetlInBustupWait;
        [FieldOffset(0x0068)] public uint CommDetlBustupChangeFrame;
        [FieldOffset(0x006C)] public EOneAnimType CommuCardAnimType;
        [FieldOffset(0x0070)] public uint CommuCardFrameMin;
        [FieldOffset(0x0074)] public uint CommuCardFrameMax;
        [FieldOffset(0x0078)] public uint CommuCardWaitMin;
        [FieldOffset(0x007C)] public uint CommuCardWaitMax;
        [FieldOffset(0x0080)] public float CommuCardScaleMin;
        [FieldOffset(0x0084)] public float CommuCardScaleMax;
        [FieldOffset(0x0088)] public float CommuCardXAccMin;
        [FieldOffset(0x008C)] public float CommuCardXAccMax;
        [FieldOffset(0x0090)] public float CommuCardRotAxis1Min;
        [FieldOffset(0x0094)] public float CommuCardRotAxis1Max;
        [FieldOffset(0x0098)] public float CommuCardRotAxis2Min;
        [FieldOffset(0x009C)] public float CommuCardRotAxis2Max;
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x170)]
    public unsafe struct FCampParamTableEquipRow //: public FTableRowBase
    {
        [FieldOffset(0x0008)] public EOneAnimType CategoChangeOutAnimType;
        [FieldOffset(0x000C)] public uint CategoChangeOutFrame;
        [FieldOffset(0x0010)] public EOneAnimType CategoChangeInAnimType;
        [FieldOffset(0x0014)] public uint CategoChangeInFrame;
        [FieldOffset(0x0018)] public EOneAnimType EquipListChangeOutAnimType;
        [FieldOffset(0x001C)] public uint EquipListChangeOutFrame;
        [FieldOffset(0x0020)] public EOneAnimType EquipListChangeInAnimType;
        [FieldOffset(0x0024)] public uint EquipListChangeInFrame;
        [FieldOffset(0x0028)] public EOneAnimType EquipListEquipChangeOutAnimType;
        [FieldOffset(0x002C)] public uint EquipListEquipChangeOutFrame;
        [FieldOffset(0x0030)] public EOneAnimType EquipListEquipChangeInAnimType;
        [FieldOffset(0x0034)] public uint EquipListEquipChangeInFrame;
        [FieldOffset(0x0038)] public uint EquipListParamArrowSelectFrame;
        [FieldOffset(0x003C)] public uint EquipListParamArrowLoopFrame;
        [FieldOffset(0x0040)] public uint EquipCompChangeInInfoWait;
        [FieldOffset(0x0044)] public float EquipInPartyPanelDist;
        [FieldOffset(0x0048)] public EOneAnimType EquipInSilhouetteAnimType;
        [FieldOffset(0x004C)] public uint EquipInSilhouetteFrame;
        [FieldOffset(0x0050)] public uint EquipInSilhouetteWait;
        [FieldOffset(0x0054)] public EOneAnimType EquipInSiroItaAnimType;
        [FieldOffset(0x0058)] public uint EquipInSiroItaFrame;
        [FieldOffset(0x005C)] public uint EquipInSiroItaWait;
        [FieldOffset(0x0060)] public EOneAnimType EquipInAoItaAnimType;
        [FieldOffset(0x0064)] public uint EquipInAoItaFrame;
        [FieldOffset(0x0068)] public uint EquipInAoItaWait;
        [FieldOffset(0x006C)] public EOneAnimType EquipInTitleAnimType;
        [FieldOffset(0x0070)] public uint EquipInTitleFrame;
        [FieldOffset(0x0074)] public uint EquipInTitleWait;
        [FieldOffset(0x0078)] public EOneAnimType EquipInBgPlusAnimType;
        [FieldOffset(0x007C)] public uint EquipInBgPlusFrame;
        [FieldOffset(0x0080)] public uint EquipInBgPlusWait;
        [FieldOffset(0x0084)] public float EquipInCharaEquipDist;
        [FieldOffset(0x0088)] public EOneAnimType EquipInCharaEquipSlideAnimType;
        [FieldOffset(0x008C)] public uint EquipInCharaEquipSlideFrame;
        [FieldOffset(0x0090)] public uint EquipInCharaEquipSlideWait;
        [FieldOffset(0x0094)] public uint EquipInCharaEquipSlideInterval;
        [FieldOffset(0x0098)] public uint EquipInCharaEquipFadeFrame;
        [FieldOffset(0x009C)] public uint EquipInPartyPanelWait;
        [FieldOffset(0x00A0)] public uint ToCateCharaEquipFadeFrame;
        [FieldOffset(0x00A4)] public EOneAnimType ToCateSiroItaAnimType;
        [FieldOffset(0x00A8)] public uint ToCateSiroItaFrame;
        [FieldOffset(0x00AC)] public uint ToCateSiroItaWait;
        [FieldOffset(0x00B0)] public EOneAnimType CategoInSelPartySlideAnimType;
        [FieldOffset(0x00B4)] public uint CategoInSelPartySlideFrame;
        [FieldOffset(0x00B8)] public uint CategoInSelPartyFadeFrame;
        [FieldOffset(0x00BC)] public EOneAnimType CategoInBgPlusAnimType;
        [FieldOffset(0x00C0)] public uint CategoInBgPlusFrame;
        [FieldOffset(0x00C4)] public uint CategoInBgPlusWait;
        [FieldOffset(0x00C8)] public EOneAnimType CategoInTabSlideAnimType;
        [FieldOffset(0x00CC)] public uint CategoInTabSlideFrame;
        [FieldOffset(0x00D0)] public float CategoInCategoryDist;
        [FieldOffset(0x00D4)] public EOneAnimType CategoInCategorySlideAnimType;
        [FieldOffset(0x00D8)] public uint CategoInCategorySlideFrame;
        [FieldOffset(0x00DC)] public uint CategoInCategorySlideInterval;
        [FieldOffset(0x00E0)] public uint CategoInCategoryFadeFrame;
        [FieldOffset(0x00E4)] public EOneAnimType BackCateSelPartyOutAnimType;
        [FieldOffset(0x00E8)] public uint BackCateSelPartyOutFrame;
        [FieldOffset(0x00EC)] public EOneAnimType BackCateSiroItaAnimType;
        [FieldOffset(0x00F0)] public uint BackCateSiroItaFrame;
        [FieldOffset(0x00F4)] public uint ToListCharaEquipOutFrame;
        [FieldOffset(0x00F8)] public EOneAnimType ToListSiroItaAnimType;
        [FieldOffset(0x00FC)] public uint ToListSiroItaFrame;
        [FieldOffset(0x0100)] public EOneAnimType ListInPartyExBgSlideAnimType;
        [FieldOffset(0x0104)] public uint ListInPartyExBgSlideFrame;
        [FieldOffset(0x0108)] public uint ListInPartyExInfoFadeFrame;
        [FieldOffset(0x010C)] public float ListInEquipListDist;
        [FieldOffset(0x0110)] public EOneAnimType ListInEquipListSlideAnimType;
        [FieldOffset(0x0114)] public uint ListInEquipListSlideFrame;
        [FieldOffset(0x0118)] public uint ListInEquipListSlideWait;
        [FieldOffset(0x011C)] public uint ListInEquipListFadeFrame;
        [FieldOffset(0x0120)] public uint BackEquipListOutFrame;
        [FieldOffset(0x0124)] public EOneAnimType ToCompBg1ScaleAnimType;
        [FieldOffset(0x0128)] public uint ToCompBg1ScaleFrame;
        [FieldOffset(0x012C)] public uint ToCompBg1ScaleWait;
        [FieldOffset(0x0130)] public uint ToCompBg2ScaleFrame;
        [FieldOffset(0x0134)] public uint ToCompBg2ScaleWait;
        [FieldOffset(0x0138)] public EOneAnimType CompInSelectListSlideAnimType;
        [FieldOffset(0x013C)] public uint CompInSelectListSlideFrame;
        [FieldOffset(0x0140)] public uint CompInSelectListSlideWait;
        [FieldOffset(0x0144)] public EOneAnimType CompInScrollBarSlideAnimType;
        [FieldOffset(0x0148)] public uint CompInScrollBarSlideFrame;
        [FieldOffset(0x014C)] public EOneAnimType CompInArrowSlideAnimType;
        [FieldOffset(0x0150)] public uint CompInArrowSlideFrame;
        [FieldOffset(0x0154)] public EOneAnimType CompInDetailSlideAnimType;
        [FieldOffset(0x0158)] public uint CompInDetailSlideFrame;
        [FieldOffset(0x015C)] public uint BackEquipCompOutFrame;
        [FieldOffset(0x0160)] public EOneAnimType BackCompBgScaleAnimType;
        [FieldOffset(0x0164)] public uint BackCompBgScaleFrame;
        [FieldOffset(0x0168)] public uint BackCompBgScaleWait;
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public unsafe struct FCampParamTableHologRow //: public FTableRowBase
    {
        [FieldOffset(0x0008)] public EOneAnimType HologAnimType;
        [FieldOffset(0x000C)] public uint HologTransFrame;
        [FieldOffset(0x0010)] public uint HologTransWait;
        [FieldOffset(0x0014)] public uint HologColorWait;
    };
    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public unsafe struct FCampParamTableItemRow //: public FTableRowBase
    {
        [FieldOffset(0x0008)] public float ItemInDist;
        [FieldOffset(0x000C)] public EOneAnimType ItemSilhouetteAnimType;
        [FieldOffset(0x0010)] public uint ItemSilhouetteFrame;
        [FieldOffset(0x0014)] public uint ItemSilhouetteWait;
        [FieldOffset(0x0018)] public EOneAnimType ItemSiroItaAnimType;
        [FieldOffset(0x001C)] public uint ItemSiroItaFrame;
        [FieldOffset(0x0020)] public uint ItemSiroItaWait;
        [FieldOffset(0x0024)] public EOneAnimType ItemTitleAnimType;
        [FieldOffset(0x0028)] public uint ItemTitleFrame;
        [FieldOffset(0x002C)] public uint ItemTitleWait;
        [FieldOffset(0x0030)] public EOneAnimType ItemListAnimType;
        [FieldOffset(0x0034)] public uint ItemListFrame;
        [FieldOffset(0x0038)] public uint ItemListWait;
        [FieldOffset(0x003C)] public EOneAnimType ItemTabAnimType;
        [FieldOffset(0x0040)] public uint ItemTabFrame;
        [FieldOffset(0x0044)] public uint ItemTabWait;
    };
    [StructLayout(LayoutKind.Explicit, Size = 0xa8)]
    public unsafe struct FCampParamTablePersonaRow //: public FTableRowBase
    {
        [FieldOffset(0x0008)] EOneAnimType PersonaEquipScaleAnimType;
        [FieldOffset(0x000C)] uint PersonaEquipScaleFrame;
        [FieldOffset(0x0010)] uint PersonaEquipScaleWait;
        [FieldOffset(0x0014)] EOneAnimType PersonaEquipRotAnimType;
        [FieldOffset(0x0018)] uint PersonaEquipRotFrame;
        [FieldOffset(0x001C)] uint PersonaEquipRotWait;
        [FieldOffset(0x0020)] EOneAnimType PersonaEquipSlideAnimType;
        [FieldOffset(0x0024)] uint PersonaEquipSlideFrame;
        [FieldOffset(0x0028)] uint PersonaEquipSlideWait;
        [FieldOffset(0x002C)] float PersonaLightSpeed;
        [FieldOffset(0x0030)] float PersonaWaveSpeed;
        [FieldOffset(0x0034)] EOneAnimType PersonaArcanaFadeAnimType;
        [FieldOffset(0x0038)] uint PersonaArcanaFadeFrame;
        [FieldOffset(0x003C)] float PersonaInDist;
        [FieldOffset(0x0040)] EOneAnimType PersonaInSilhouetteAnimType;
        [FieldOffset(0x0044)] uint PersonaInSilhouetteFrame;
        [FieldOffset(0x0048)] uint PersonaInSilhouetteWait;
        [FieldOffset(0x004C)] EOneAnimType PersonaInPersonaAnimType;
        [FieldOffset(0x0050)] uint PersonaInPersonaFrame;
        [FieldOffset(0x0054)] uint PersonaInPersonaWait;
        [FieldOffset(0x0058)] float PersonaInPersonaDist;
        [FieldOffset(0x005C)] EOneAnimType PersonaInSiroItaAnimType;
        [FieldOffset(0x0060)] uint PersonaInSiroItaFrame;
        [FieldOffset(0x0064)] uint PersonaInSiroItaWait;
        [FieldOffset(0x0068)] EOneAnimType PersonaInTitleAnimType;
        [FieldOffset(0x006C)] uint PersonaInTitleFrame;
        [FieldOffset(0x0070)] uint PersonaInTitleWait;
        [FieldOffset(0x0074)] EOneAnimType PersonaInListAnimType;
        [FieldOffset(0x0078)] uint PersonaInListFrame;
        [FieldOffset(0x007C)] uint PersonaInListWait;
        [FieldOffset(0x0080)] EOneAnimType PersonaInArcanaAnimType;
        [FieldOffset(0x0084)] uint PersonaInArcanaFrame;
        [FieldOffset(0x0088)] uint PersonaInArcanaWait;
        [FieldOffset(0x008C)] EOneAnimType ItemPerListInAnimType;
        [FieldOffset(0x0090)] uint ItemPerListInFrame;
        [FieldOffset(0x0094)] uint ItemPerListInWait;
        [FieldOffset(0x0098)] uint ItemPerListInBackFrame;
        [FieldOffset(0x009C)] EOneAnimType ItemPerListInBgAnimType;
        [FieldOffset(0x00A0)] uint ItemPerListInBgFrame;
        [FieldOffset(0x00A4)] uint ItemPerListInBgBackFrame;

    };
    [StructLayout(LayoutKind.Explicit, Size = 0x318)]
    public unsafe struct FCampParamTableRankUpRow //: public FTableRowBase
    {
        [FieldOffset(0x0008)] public FColor HumanSankakuRed;
        [FieldOffset(0x000C)] public FColor HumanSankakuGreen;
        [FieldOffset(0x0010)] public FColor HumanBokasiRed;
        [FieldOffset(0x0014)] public FColor HumanBokasiGreen;
        [FieldOffset(0x0018)] public FColor HumanPointUpLightblue;
        [FieldOffset(0x001C)] public FColor HumanBrainBlue;
        [FieldOffset(0x0020)] public FColor HumanCharmBlue;
        [FieldOffset(0x0024)] public FColor HumanCourageBlue;
        [FieldOffset(0x0028)] public FColor CampHumanBrainBlue;
        [FieldOffset(0x002C)] public FColor CampHumanCharmBlue;
        [FieldOffset(0x0030)] public FColor CampHumanCourageBlue;
        [FieldOffset(0x0034)] public FColor ParameterNameYellow;
        [FieldOffset(0x0038)] public FColor CircleYellow;
        [FieldOffset(0x003C)] public FColor HelpTextYellow;
        [FieldOffset(0x0040)] public FVector2D PointUpTextStartPos;
        [FieldOffset(0x0048)] public FVector2D PointUpTextEndPos;
        [FieldOffset(0x0050)] public FVector2D RankUpTextStartPos;
        [FieldOffset(0x0058)] public FVector2D RankUpTextEndPos;
        [FieldOffset(0x0060)] public uint HumanInBgSankakuFrame;
        [FieldOffset(0x0064)] public uint HumanInSankakuFrame;
        [FieldOffset(0x0068)] public uint HumanInAllBGFrame;
        [FieldOffset(0x006C)] public uint HumanInHamonFrame;
        [FieldOffset(0x0070)] public uint HumanInRankRotFrame;
        [FieldOffset(0x0074)] public uint HumanInRankSlideFrame;
        [FieldOffset(0x0078)] public uint HumanInHelpSlideFrame;
        [FieldOffset(0x007C)] public uint HumanInTitleSlideFrame;
        [FieldOffset(0x0080)] public uint HumanInBgSankakuFrameWait;
        [FieldOffset(0x0084)] public uint HumanInSankakuFrameWaitWhite;
        [FieldOffset(0x0088)] public uint HumanInSankakuFrameWaitGreen;
        [FieldOffset(0x008C)] public uint HumanInSankakuFrameWaitRed;
        [FieldOffset(0x0090)] public uint HumanInAllBGFrameWait;
        [FieldOffset(0x0094)] public uint HumanInHamonFrameWait;
        [FieldOffset(0x0098)] public uint HumanInHamonFrameWaitSecond;
        [FieldOffset(0x009C)] public uint HumanInHamonFrameWaitThird;
        [FieldOffset(0x00A0)] public uint HumanInRankRotFrameWait;
        [FieldOffset(0x00A4)] public uint HumanInRankSlideFrameWait;
        [FieldOffset(0x00A8)] public uint HumanInHelpSlideFrameWait;
        [FieldOffset(0x00AC)] public uint HumanInTitleSlideFrameWait;
        [FieldOffset(0x00B0)] public EOneAnimType HumanInBgSankakuType;
        [FieldOffset(0x00B1)] public EOneAnimType HumanInSankakuType;
        [FieldOffset(0x00B2)] public EOneAnimType HumanInAllBGType;
        [FieldOffset(0x00B3)] public EOneAnimType HumanInHamonType;
        [FieldOffset(0x00B4)] public EOneAnimType HumanInRankRotType;
        [FieldOffset(0x00B5)] public EOneAnimType HumanInRankSlideType;
        [FieldOffset(0x00B6)] public EOneAnimType HumanInHelpSlideType;
        [FieldOffset(0x00B7)] public EOneAnimType HumanInTitleSlideType;
        [FieldOffset(0x00B8)] public uint HumanPointUpTextSlideOneFrame;
        [FieldOffset(0x00BC)] public uint HumanPointUpTextSlideTwoFrame;
        [FieldOffset(0x00C0)] public uint HumanPointUpTextSlideThreeFrame;
        [FieldOffset(0x00C4)] public uint HumanPointUpTextFadeOneFrame;
        [FieldOffset(0x00C8)] public uint HumanPointUpTextFadeTwoFrame;
        [FieldOffset(0x00CC)] public uint HumanPointUpTextFadeThreeFrame;
        [FieldOffset(0x00D0)] public uint HumanPointUpHamonScaleFrame;
        [FieldOffset(0x00D4)] public uint HumanPointUpHamonFadeFrame;
        [FieldOffset(0x00D8)] public uint HumanPointUpBlueCircleFadeOneFrame;
        [FieldOffset(0x00DC)] public uint HumanPointUpBlueCircleFadeTwoFrame;
        [FieldOffset(0x00E0)] public uint HumanPointUpBlueCircleFadeThreeFrame;
        [FieldOffset(0x00E4)] public uint HumanPointUpBlueCircleScaleOneFrame;
        [FieldOffset(0x00E8)] public uint HumanPointUpBlueCircleScaleTwoFrame;
        [FieldOffset(0x00EC)] public uint HumanPointUpBlueCircleScaleThreeFrame;
        [FieldOffset(0x00F0)] public uint HumanPointUpTextSlideOneFrameWait;
        [FieldOffset(0x00F4)] public uint HumanPointUpTextSlideTwoFrameWait;
        [FieldOffset(0x00F8)] public uint HumanPointUpTextSlideThreeFrameWait;
        [FieldOffset(0x00FC)] public uint HumanPointUpTextFadeOneFrameWait;
        [FieldOffset(0x0100)] public uint HumanPointUpTextFadeTwoFrameWait;
        [FieldOffset(0x0104)] public uint HumanPointUpTextFadeThreeFrameWait;
        [FieldOffset(0x0108)] public uint HumanPointUpHamonScaleFrameWait;
        [FieldOffset(0x010C)] public uint HumanPointUpHamonFadeFrameWait;
        [FieldOffset(0x0110)] public uint HumanPointUpBlueCircleFadeOneFrameWait;
        [FieldOffset(0x0114)] public uint HumanPointUpBlueCircleFadeTwoFrameWait;
        [FieldOffset(0x0118)] public uint HumanPointUpBlueCircleFadeThreeFrameWait;
        [FieldOffset(0x011C)] public uint HumanPointUpBlueCircleScaleOneFrameWait;
        [FieldOffset(0x0120)] public uint HumanPointUpBlueCircleScaleTwoFrameWait;
        [FieldOffset(0x0124)] public uint HumanPointUpBlueCircleScaleThreeFrameWait;
        [FieldOffset(0x0128)] public EOneAnimType HumanPointUpTextSlideOneType;
        [FieldOffset(0x0129)] public EOneAnimType HumanPointUpTextSlideTwoType;
        [FieldOffset(0x012A)] public EOneAnimType HumanPointUpTextSlideThreeType;
        [FieldOffset(0x012B)] public EOneAnimType HumanPointUpTextFadeOneType;
        [FieldOffset(0x012C)] public EOneAnimType HumanPointUpTextFadeTwoType;
        [FieldOffset(0x012D)] public EOneAnimType HumanPointUpTextFadeThreeType;
        [FieldOffset(0x012E)] public EOneAnimType HumanPointUpHamonScaleType;
        [FieldOffset(0x012F)] public EOneAnimType HumanPointUpHamonFadeType;
        [FieldOffset(0x0130)] public EOneAnimType HumanPointUpBlueCircleFadeScaleOneType;
        [FieldOffset(0x0131)] public EOneAnimType HumanPointUpBlueCircleFadeScaleTwoType;
        [FieldOffset(0x0132)] public EOneAnimType HumanPointUpBlueCircleFadeScaleThreeType;
        [FieldOffset(0x0134)] public uint HumanRankUpTextSlideOneFrame;
        [FieldOffset(0x0138)] public uint HumanRankUpTextSlideTwoFrame;
        [FieldOffset(0x013C)] public uint HumanRankUpTextSlideThreeFrame;
        [FieldOffset(0x0140)] public uint HumanRankUpTextFadeOneFrame;
        [FieldOffset(0x0144)] public uint HumanRankUpTextFadeTwoFrame;
        [FieldOffset(0x0148)] public uint HumanRankUpTextFadeThreeFrame;
        [FieldOffset(0x014C)] public uint HumanRankUpHamonScaleFrame;
        [FieldOffset(0x0150)] public uint HumanRankUpHamonFadeFrame;
        [FieldOffset(0x0154)] public uint HumanRankUpWhiteCircleColorOneFrame;
        [FieldOffset(0x0158)] public uint HumanRankUpWhiteCircleColorTwoFrame;
        [FieldOffset(0x015C)] public uint HumanRankUpWhiteCircleColorThreeFrame;
        [FieldOffset(0x0160)] public uint HumanRankUpWhiteCircleScaleOneFrame;
        [FieldOffset(0x0164)] public uint HumanRankUpWhiteCircleScaleTwoFrame;
        [FieldOffset(0x0168)] public uint HumanRankUpWhiteCircleScaleThreeFrame;
        [FieldOffset(0x016C)] public uint HumanRankUpTextSlideOneFrameWait;
        [FieldOffset(0x0170)] public uint HumanRankUpTextSlideTwoFrameWait;
        [FieldOffset(0x0174)] public uint HumanRankUpTextSlideThreeFrameWait;
        [FieldOffset(0x0178)] public uint HumanRankUpTextFadeOneFrameWait;
        [FieldOffset(0x017C)] public uint HumanRankUpTextFadeTwoFrameWait;
        [FieldOffset(0x0180)] public uint HumanRankUpTextFadeThreeFrameWait;
        [FieldOffset(0x0184)] public uint HumanRankUpHamonScaleFrameWait;
        [FieldOffset(0x0188)] public uint HumanRankUpHamonFadeFrameWait;
        [FieldOffset(0x018C)] public uint HumanRankUpWhiteCircleColorOneFrameWait;
        [FieldOffset(0x0190)] public uint HumanRankUpWhiteCircleColorTwoFrameWait;
        [FieldOffset(0x0194)] public uint HumanRankUpWhiteCircleColorThreeFrameWait;
        [FieldOffset(0x0198)] public uint HumanRankUpWhiteCircleScaleOneFrameWait;
        [FieldOffset(0x019C)] public uint HumanRankUpWhiteCircleScaleTwoFrameWait;
        [FieldOffset(0x01A0)] public uint HumanRankUpWhiteCircleScaleThreeFrameWait;
        [FieldOffset(0x01A4)] public EOneAnimType HumanRankUpTextSlideOneType;
        [FieldOffset(0x01A5)] public EOneAnimType HumanRankUpTextSlideTwoType;
        [FieldOffset(0x01A6)] public EOneAnimType HumanRankUpTextSlideThreeType;
        [FieldOffset(0x01A7)] public EOneAnimType HumanRankUpTextFadeOneType;
        [FieldOffset(0x01A8)] public EOneAnimType HumanRankUpTextFadeTwoType;
        [FieldOffset(0x01A9)] public EOneAnimType HumanRankUpTextFadeThreeType;
        [FieldOffset(0x01AA)] public EOneAnimType HumanRankUpHamonScaleType;
        [FieldOffset(0x01AB)] public EOneAnimType HumanRankUpHamonFadeType;
        [FieldOffset(0x01AC)] public EOneAnimType HumanRankUpWhiteCircleColorOneType;
        [FieldOffset(0x01AD)] public EOneAnimType HumanRankUpWhiteCircleColorTwoType;
        [FieldOffset(0x01AE)] public EOneAnimType HumanRankUpWhiteCircleColorThreeType;
        [FieldOffset(0x01AF)] public EOneAnimType HumanRankUpWhiteCircleScaleOneType;
        [FieldOffset(0x01B0)] public EOneAnimType HumanRankUpWhiteCircleScaleTwoType;
        [FieldOffset(0x01B1)] public EOneAnimType HumanRankUpWhiteCircleScaleThreeType;
        [FieldOffset(0x01B4)] public uint HumanRankUpAllCircleScaleFrame;
        [FieldOffset(0x01B8)] public uint HumanRankUpCurrentNumberFadeFrame;
        [FieldOffset(0x01BC)] public uint HumanRankUpNextNumberFadeSlideFrame;
        [FieldOffset(0x01C0)] public uint HumanRankUpCurrentHelpTextFadeFrame;
        [FieldOffset(0x01C4)] public uint HumanRankUpNextHelpTextFadeSlideFrame;
        [FieldOffset(0x01C8)] public uint HumanRankUpMaskCircleFrame;
        [FieldOffset(0x01CC)] public uint HumanRankUpAllCircleScaleFrameWait;
        [FieldOffset(0x01D0)] public uint HumanRankUpCurrentNumberFadeFrameWait;
        [FieldOffset(0x01D4)] public uint HumanRankUpNextNumberFadeSlideFrameWait;
        [FieldOffset(0x01D8)] public uint HumanRankUpCurrentHelpTextFadeFrameWait;
        [FieldOffset(0x01DC)] public uint HumanRankUpNextHelpTextFadeSlideFrameWait;
        [FieldOffset(0x01E0)] public uint HumanRankUpMaskCircleFrameWait;
        [FieldOffset(0x01E4)] public EOneAnimType HumanRankUpAllCircleScaleType;
        [FieldOffset(0x01E5)] public EOneAnimType HumanRankUpCurrentNumberFadeType;
        [FieldOffset(0x01E6)] public EOneAnimType HumanRankUpNextNumberFadeSlideType;
        [FieldOffset(0x01E7)] public EOneAnimType HumanRankUpCurrentHelpTextFadeType;
        [FieldOffset(0x01E8)] public EOneAnimType HumanRankUpNextHelpTextFadeSlideType;
        [FieldOffset(0x01E9)] public EOneAnimType HumanRankUpMaskCircleType;
        [FieldOffset(0x01EC)] public uint HumanRankUpNextNumberFadeFrame;
        [FieldOffset(0x01F0)] public uint HumanRankUpNextHelpTextFadeFrame;
        [FieldOffset(0x01F4)] public uint HumanRankUpNextNumberFadeFrameWait;
        [FieldOffset(0x01F8)] public uint HumanRankUpNextHelpTextFadeFrameWait;
        [FieldOffset(0x01FC)] public EOneAnimType HumanRankUpNextNumberFadeType;
        [FieldOffset(0x01FD)] public EOneAnimType HumanRankUpNextHelpTextFadeType;
        [FieldOffset(0x0200)] public uint KeyHelpFadeInFrame;
        [FieldOffset(0x0204)] public uint HumanKeyHelpInFrameWait;
        [FieldOffset(0x0208)] public uint KeyHelpFadeOutFrame;
        [FieldOffset(0x020C)] public uint HumanKeyHelpOutFrameWait;
        [FieldOffset(0x0210)] public uint KeyHelpMaskSlideOneFrame;
        [FieldOffset(0x0214)] public uint KeyHelpMaskSlideTwoFrame;
        [FieldOffset(0x0218)] public uint KeyHelpMaskSlideThreeFrame;
        [FieldOffset(0x021C)] public uint KeyHelpMaskSlideOneWaitFrame;
        [FieldOffset(0x0220)] public uint KeyHelpMaskSlideTwoWaitFrame;
        [FieldOffset(0x0224)] public uint KeyHelpMaskSlideThreeWaitFrame;
        [FieldOffset(0x0228)] public EOneAnimType KeyHelpMaskSlideOneType;
        [FieldOffset(0x0229)] public EOneAnimType KeyHelpMaskSlideTwoType;
        [FieldOffset(0x022A)] public EOneAnimType KeyHelpMaskSlideThreeType;
        [FieldOffset(0x022B)] public EOneAnimType KeyHelpMaskSlideOneWaitType;
        [FieldOffset(0x022C)] public EOneAnimType KeyHelpMaskSlideTwoWaitType;
        [FieldOffset(0x022D)] public EOneAnimType KeyHelpMaskSlideThreeWaitType;
        [FieldOffset(0x022E)] public EOneAnimType KeyHelpOutScaleType;
        [FieldOffset(0x0230)] public uint KeyHelpOutScaleFrame;
        [FieldOffset(0x0234)] public float KeyHelpFadeOutScaleSize;
        [FieldOffset(0x0238)] public uint MaxHamonShiftWaitFlame;
        [FieldOffset(0x023C)] public uint HumanMaxHamonScaleInFlame;
        [FieldOffset(0x0240)] public uint HumanMaxHamonScaleInFlameWait;
        [FieldOffset(0x0244)] public uint HumanMaxHamonFadeInAllFlameWait;
        [FieldOffset(0x0248)] public uint HumanMaxHamonFadeInFlame;
        [FieldOffset(0x024C)] public uint HumanMaxHamonFadeInFlameWait;
        [FieldOffset(0x0250)] public uint HumanMaxHamonFadeOutFlame;
        [FieldOffset(0x0254)] public uint HumanMaxHamonFadeOutFlameWait;
        [FieldOffset(0x0258)] public uint HumanMaxHamonFadeOutLastFlame;
        [FieldOffset(0x025C)] public uint HumanMaxHamonFadeOutLastFlameWait;
        [FieldOffset(0x0260)] public EOneAnimType HumanMaxHamonScaleOutType;
        [FieldOffset(0x0264)] public uint MaxTriangleBlurFadeInFlame;
        [FieldOffset(0x0268)] public uint MaxTriangleBlurFadeInFlameWait;
        [FieldOffset(0x026C)] public uint MaxTriangleBlurFadeOutFlame;
        [FieldOffset(0x0270)] public uint HumanMaxCircleFadeInFlame;
        [FieldOffset(0x0274)] public uint HumanMaxCircleFadeInFlameWait;
        [FieldOffset(0x0278)] public uint HumanMaxCircleFadeOutFlame;
        [FieldOffset(0x027C)] public uint MaxCircleFinishFlameWait;
        [FieldOffset(0x0280)] public EOneAnimType HumanMaxHamonScaleType;
        [FieldOffset(0x0281)] public EOneAnimType HumanMaxHamonFadeInType;
        [FieldOffset(0x0282)] public EOneAnimType HumanMaxHamonFadeOutType;
        [FieldOffset(0x0283)] public EOneAnimType MaxTriangleBlurFadeInType;
        [FieldOffset(0x0284)] public EOneAnimType MaxTriangleBlurFadeOutType;
        [FieldOffset(0x0285)] public EOneAnimType HumanMaxCircleFadeInType;
        [FieldOffset(0x0286)] public EOneAnimType HumanMaxCircleFadeTwoType;
        [FieldOffset(0x0288)] public uint HumanCircleFadeLoop_Wait_0;
        [FieldOffset(0x028C)] public uint HumanCircleFadeLoop_Frame_0;
        [FieldOffset(0x0290)] public uint HumanCircleFadeLoop_Wait_1;
        [FieldOffset(0x0294)] public uint HumanCircleFadeLoop_Frame_1;
        [FieldOffset(0x0298)] public uint HumanCircleColorLoop_Wait_0;
        [FieldOffset(0x029C)] public uint HumanCircleColorLoop_Frame_0;
        [FieldOffset(0x02A0)] public uint HumanCircleColorLoop_Wait_1;
        [FieldOffset(0x02A4)] public uint HumanCircleColorLoop_Frame_1;
        [FieldOffset(0x02A8)] public uint HumanCircleScaleUpLoop_Wait;
        [FieldOffset(0x02AC)] public uint HumanCircleScaleUpLoop_Frame;
        [FieldOffset(0x02B0)] public EOneAnimType HumanCircleFadeLoopType;
        [FieldOffset(0x02B1)] public EOneAnimType HumanCircleScaleLoopType;
        [FieldOffset(0x02B2)] public EOneAnimType HumanCircleColorLoopType;
        [FieldOffset(0x02B4)] public uint HumanPlusHamonFlame;
        [FieldOffset(0x02B8)] public uint HumanCircleLoopStartWait;
        [FieldOffset(0x02BC)] public uint HumanOutHelpSlideFrame;
        [FieldOffset(0x02C0)] public uint HumanOutTitleSlideFrame;
        [FieldOffset(0x02C4)] public uint HumanOutHamonFrame;
        [FieldOffset(0x02C8)] public uint HumanOutSankakuFrame;
        [FieldOffset(0x02CC)] public uint HumanOutRankRotFrame;
        [FieldOffset(0x02D0)] public uint HumanOutBgSankakuFrame;
        [FieldOffset(0x02D4)] public uint HumanOutAllBgFrame;
        [FieldOffset(0x02D8)] public uint HumanOutHelpSlideFrameWait;
        [FieldOffset(0x02DC)] public uint HumanOutTitleSlideFrameWait;
        [FieldOffset(0x02E0)] public uint HumanOutHamonFrameWait;
        [FieldOffset(0x02E4)] public uint HumanOutSankakuFrameWait;
        [FieldOffset(0x02E8)] public uint HumanOutRankRotFrameWait;
        [FieldOffset(0x02EC)] public uint HumanOutBgSankakuFrameWait;
        [FieldOffset(0x02F0)] public uint HumanOutAllBgFrameWait;
        [FieldOffset(0x02F4)] public EOneAnimType HumanOutHelpSlideType;
        [FieldOffset(0x02F5)] public EOneAnimType HumanOutTitleSlideType;
        [FieldOffset(0x02F6)] public EOneAnimType HumanOutHamonType;
        [FieldOffset(0x02F7)] public EOneAnimType HumanOutSankakuType;
        [FieldOffset(0x02F8)] public EOneAnimType HumanOutRankRotType;
        [FieldOffset(0x02F9)] public EOneAnimType HumanOutBgSankakuType;
        [FieldOffset(0x02FA)] public EOneAnimType HumanOutAllBgType;
        [FieldOffset(0x02FB)] public EOneAnimType HumanKeyHelpOutType;
        [FieldOffset(0x02FC)] public uint HumanHamonLoopScaleDownFrame;
        [FieldOffset(0x0300)] public uint HumanHamonLoopScaleUpFrameWait;
        [FieldOffset(0x0304)] public EOneAnimType HumanHamonLoopScaleDownType;
        [FieldOffset(0x0308)] public uint HumanHamonLoopWaitFrame;
        [FieldOffset(0x030C)] public EOneAnimType HumanHamonLoopWaitType;
        [FieldOffset(0x0310)] public uint HumanHamonLoopScaleUpFrame;
        [FieldOffset(0x0314)] public EOneAnimType HumanHamonLoopScaleUpType;

    };

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public unsafe struct FCampParamTableSkillRow //: public FTableRowBase
    {
        [FieldOffset(0x0008)] public float SkillInDist;
        [FieldOffset(0x000C)] public EOneAnimType SkillSilhouetteAnimType;
        [FieldOffset(0x0010)] public uint SkillSilhouetteFrame;
        [FieldOffset(0x0014)] public uint SkillSilhouetteWait;
        [FieldOffset(0x0018)] public EOneAnimType SkillSiroItaAnimType;
        [FieldOffset(0x001C)] public uint SkillSiroItaFrame;
        [FieldOffset(0x0020)] public uint SkillSiroItaWait;
        [FieldOffset(0x0024)] public EOneAnimType SkillTitleAnimType;
        [FieldOffset(0x0028)] public uint SkillTitleFrame;
        [FieldOffset(0x002C)] public uint SkillTitleWait;
        [FieldOffset(0x0030)] public EOneAnimType SkillListAnimType;
        [FieldOffset(0x0034)] public uint SkillListFrame;
        [FieldOffset(0x0038)] public uint SkillListWait;
        [FieldOffset(0x003C)] public EOneAnimType SkillPartyAnimType;
        [FieldOffset(0x0040)] public uint SkillPartyFrame;
        [FieldOffset(0x0044)] public uint SkillPartyWait;
        [FieldOffset(0x0048)] public uint SkillPartyFadeFrame;
        [FieldOffset(0x004C)] public uint SkillPartyInterval;
        [FieldOffset(0x0050)] public EOneAnimType GunRefRotAnimType;
        [FieldOffset(0x0054)] public uint GunRefInFrame;
        [FieldOffset(0x0058)] public uint GunRefInWait;
        [FieldOffset(0x005C)] public uint GunRefNextFrame;
        [FieldOffset(0x0060)] public FVector2D GunRefPos;
        [FieldOffset(0x0068)] public float GunRefOffset;

    };
    [StructLayout(LayoutKind.Explicit, Size = 0x310)]
    public unsafe struct FCampParamTableStatusRow //: public FTableRowBase
    {
        [FieldOffset(0x0008)] public uint ListTabChangeFrame;
        [FieldOffset(0x000C)] public uint StatListPartyRightSideFadeOutFrame;
        [FieldOffset(0x0010)] public uint StatListPartyRightSideFadeInFrame;
        [FieldOffset(0x0014)] public uint StatListKoshoLogoRotFrame;
        [FieldOffset(0x0018)] public uint StatListGlassCharaFrame;
        [FieldOffset(0x001C)] public uint StatListGlassCharaWait;
        [FieldOffset(0x0020)] public uint StatListBgNoiseRandFrameMin;
        [FieldOffset(0x0024)] public uint StatListBgNoiseRandFrameMax;
        [FieldOffset(0x0028)] public float StatListInDist;
        [FieldOffset(0x002C)] public EOneAnimType StatListInSilhouetteAnimType;
        [FieldOffset(0x0030)] public uint StatListInSilhouetteFrame;
        [FieldOffset(0x0034)] public uint StatListInSilhouetteWait;
        [FieldOffset(0x0038)] public EOneAnimType StatListInKoshoAnimType;
        [FieldOffset(0x003C)] public uint StatListInKoshoFrame;
        [FieldOffset(0x0040)] public uint StatListInKoshoWait;
        [FieldOffset(0x0044)] public EOneAnimType StatListInTabAnimType;
        [FieldOffset(0x0048)] public uint StatListInTabFrame;
        [FieldOffset(0x004C)] public uint StatListInTabWait;
        [FieldOffset(0x0050)] public EOneAnimType StatListBgNoiseAnimType;
        [FieldOffset(0x0054)] public uint StatListBgNoiseFrame;
        [FieldOffset(0x0058)] public EOneAnimType StatListBgTextAnimType;
        [FieldOffset(0x005C)] public uint StatListBgTextFrame;
        [FieldOffset(0x0060)] public EOneAnimType StatListOpeListAnimType;
        [FieldOffset(0x0064)] public uint StatListOpeListFrame;
        [FieldOffset(0x0068)] public float StatDetailRotation;
        [FieldOffset(0x006C)] public EOneAnimType StatDetailInfoSlideAnimType;
        [FieldOffset(0x0070)] public uint StatDetailInfoSlideFrame;
        [FieldOffset(0x0074)] public EOneAnimType StatDetailBgNumSlideAnimType;
        [FieldOffset(0x0078)] public uint StatDetailBgNumSlideOutFrame;
        [FieldOffset(0x007C)] public uint StatDetailBgNumSlideInFrame;
        [FieldOffset(0x0080)] public EOneAnimType StatDetailHanshaSlideAnimType;
        [FieldOffset(0x0084)] public uint StatDetailHanshaSlideFrame;
        [FieldOffset(0x0088)] public EOneAnimType StatDetailHahenShadowSlideAnimType;
        [FieldOffset(0x008C)] public uint StatDetailHahenShadowSlideFrame;
        [FieldOffset(0x0090)] public EOneAnimType StatDetailCharaShadowSlideAnimType;
        [FieldOffset(0x0094)] public uint StatDetailCharaShadowSlideFrame;
        [FieldOffset(0x0098)] public EOneAnimType StatDetailLeaderRotAnimType;
        [FieldOffset(0x009C)] public uint StatDetailLeaderRotOutFrame;
        [FieldOffset(0x00A0)] public uint StatDetailLeaderRotInFrame;
        [FieldOffset(0x00A4)] public EOneAnimType StatDetailInOutlineAnimType;
        [FieldOffset(0x00A8)] public uint StatDetailInOutlineFrame;
        [FieldOffset(0x00AC)] public uint StatDetailInOutlineWait;
        [FieldOffset(0x00B0)] public uint StatDetailInOutlineOutFrame;
        [FieldOffset(0x00B4)] public EOneAnimType StatDetailPanelSlideAnimType;
        [FieldOffset(0x00B8)] public uint StatDetailPanelSlideFrame;
        [FieldOffset(0x00BC)] public uint StatDetailToTheurLeaderRotFrame;
        [FieldOffset(0x00C0)] public EOneAnimType StatDetailToTheurDetailInfoSlideAnimType;
        [FieldOffset(0x00C4)] public uint StatDetailToTheurDetailInfoSlideFrame;
        [FieldOffset(0x00C8)] public uint StatDetailToTheurBgNumSlideFrame;
        [FieldOffset(0x00CC)] public uint HumanHamonAlphaFrameDown;
        [FieldOffset(0x00D0)] public uint HumanHamonAlphaFrameUp;
        [FieldOffset(0x00D4)] public uint HumanHamonAlphaFrameStay;
        [FieldOffset(0x00D8)] public uint HumanHamonAlphaInterval;
        [FieldOffset(0x00DC)] public FColor HumanSankakuRed;
        [FieldOffset(0x00E0)] public FColor HumanSankakuGreen;
        [FieldOffset(0x00E4)] public FColor HumanBokasiRed;
        [FieldOffset(0x00E8)] public FColor HumanBokasiGreen;
        [FieldOffset(0x00EC)] public uint HumanInBgSankakuFrame;
        [FieldOffset(0x00F0)] public uint HumanInSankakuFrame;
        [FieldOffset(0x00F4)] public uint HumanInHamonFrame;
        [FieldOffset(0x00F8)] public uint HumanInRankRotFrame;
        [FieldOffset(0x00FC)] public uint HumanInRankSlideFrame;
        [FieldOffset(0x0100)] public uint HumanInHelpSlideFrame;
        [FieldOffset(0x0104)] public uint HumanInTitleSlideFrame;
        [FieldOffset(0x0108)] public uint HumanPointUpTextSlideOneFrame;
        [FieldOffset(0x010C)] public uint HumanPointUpTextSlideTwoFrame;
        [FieldOffset(0x0110)] public uint HumanPointUpTextSlideThreeFrame;
        [FieldOffset(0x0114)] public uint HumanPointUpTextFadeOneFrame;
        [FieldOffset(0x0118)] public uint HumanPointUpTextFadeTwoFrame;
        [FieldOffset(0x011C)] public uint HumanPointUpTextFadeThreeFrame;
        [FieldOffset(0x0120)] public uint HumanPointUpHamonScaleFrame;
        [FieldOffset(0x0124)] public uint HumanPointUpHamonFadeFrame;
        [FieldOffset(0x0128)] public uint HumanPointUpBlueCircleFadeScaleOneFrame;
        [FieldOffset(0x012C)] public uint HumanPointUpBlueCircleFadeScaleTwoFrame;
        [FieldOffset(0x0130)] public uint HumanPointUpBlueCircleFadeScaleThreeFrame;
        [FieldOffset(0x0134)] public uint HumanRankUpTextSlideOneFrame;
        [FieldOffset(0x0138)] public uint HumanRankUpTextSlideTwoFrame;
        [FieldOffset(0x013C)] public uint HumanRankUpTextSlideThreeFrame;
        [FieldOffset(0x0140)] public uint HumanRankUpTextFadeOneFrame;
        [FieldOffset(0x0144)] public uint HumanRankUpTextFadeTwoFrame;
        [FieldOffset(0x0148)] public uint HumanRankUpTextFadeThreeFrame;
        [FieldOffset(0x014C)] public uint HumanRankUpHamonScaleFrame;
        [FieldOffset(0x0150)] public uint HumanRankUpHamonFadeFrame;
        [FieldOffset(0x0154)] public uint HumanRankUpWhiteCircleColorOneFrame;
        [FieldOffset(0x0158)] public uint HumanRankUpWhiteCircleColorTwoFrame;
        [FieldOffset(0x015C)] public uint HumanRankUpWhiteCircleColorThreeFrame;
        [FieldOffset(0x0160)] public uint HumanRankUpWhiteCircleScaleOneFrame;
        [FieldOffset(0x0164)] public uint HumanRankUpWhiteCircleScaleTwoFrame;
        [FieldOffset(0x0168)] public uint HumanRankUpWhiteCircleScaleThreeFrame;
        [FieldOffset(0x016C)] public uint HumanRankUpAllCircleScaleFrame;
        [FieldOffset(0x0170)] public uint HumanRankUpCurrentNumberFadeFrame;
        [FieldOffset(0x0174)] public uint HumanRankUpNextNumberFadeSlideFrame;
        [FieldOffset(0x0178)] public uint HumanRankUpCurrentHelpTextFadeFrame;
        [FieldOffset(0x017C)] public uint HumanRankUpNextHelpTextFadeSlideFrame;
        [FieldOffset(0x0180)] public uint HumanRankUpMaskCircleFrame;
        [FieldOffset(0x0184)] public uint KeyHelpFadeFrame;
        [FieldOffset(0x0188)] public uint KeyHelpMaskSlideOneFrame;
        [FieldOffset(0x018C)] public uint KeyHelpMaskSlideTwoFrame;
        [FieldOffset(0x0190)] public uint KeyHelpMaskSlideThreeFrame;
        [FieldOffset(0x0194)] public uint KeyHelpMaskSlideOneWaitFrame;
        [FieldOffset(0x0198)] public uint KeyHelpMaskSlideTwoWaitFrame;
        [FieldOffset(0x019C)] public uint KeyHelpMaskSlideThreeWaitFrame;
        [FieldOffset(0x01A0)] public uint HumanMaxHamonScaleFlame;
        [FieldOffset(0x01A4)] public uint HumanMaxHamonFadeOneFlame;
        [FieldOffset(0x01A8)] public uint HumanMaxHamonFadeTwoFlame;
        [FieldOffset(0x01AC)] public uint HumanMaxCircleFadeOneFlame;
        [FieldOffset(0x01B0)] public uint HumanMaxCircleFadeTwoFlame;
        [FieldOffset(0x01B4)] public uint HumanCircleLoopFlame;
        [FieldOffset(0x01B8)] public uint HumanPlusHamonFlame;
        [FieldOffset(0x01BC)] public uint HumanOutHelpSlideFrame;
        [FieldOffset(0x01C0)] public uint HumanOutHamonFrame;
        [FieldOffset(0x01C4)] public uint HumanOutSankakuFrame;
        [FieldOffset(0x01C8)] public uint HumanOutRankRotFrame;
        [FieldOffset(0x01CC)] public uint HumanOutBgSankakuFrame;
        [FieldOffset(0x01D0)] public uint HumanHamonLoopScaleDownFrame;
        [FieldOffset(0x01D4)] public uint HumanHamonLoopWaitFrame;
        [FieldOffset(0x01D8)] public uint HumanHamonLoopScaleUpFrame;
        [FieldOffset(0x01DC)] public EOneAnimType FldTheurPanelSlideAnimType;
        [FieldOffset(0x01E0)] public uint FldTheurPanelSlideFrame;
        [FieldOffset(0x01E4)] public uint FldTheurPanelSlideWait;
        [FieldOffset(0x01E8)] public uint FldTheurBgNumSlideFrame;
        [FieldOffset(0x01EC)] public uint FldTheurBgNumSlideWait;
        [FieldOffset(0x01F0)] public EOneAnimType FldTheurBustupSlideAnimType;
        [FieldOffset(0x01F4)] public uint FldTheurBustupSlideInFrame;
        [FieldOffset(0x01F8)] public uint FldTheurBustupSlideInWait;
        [FieldOffset(0x01FC)] public uint FldTheurBustupSlideOutFrame;
        [FieldOffset(0x0200)] public FColor TheurCharaMaskColor;
        [FieldOffset(0x0204)] public FVector2D TheurCharaPosHero;
        [FieldOffset(0x020C)] public FVector2D TheurShadowPosHero;
        [FieldOffset(0x0214)] public FVector2D TheurCharaPosYukari;
        [FieldOffset(0x021C)] public FVector2D TheurShadowPosYukari;
        [FieldOffset(0x0224)] public FVector2D TheurCharaPosJunpei;
        [FieldOffset(0x022C)] public FVector2D TheurShadowPosJunpei;
        [FieldOffset(0x0234)] public FVector2D TheurCharaPosSanada;
        [FieldOffset(0x023C)] public FVector2D TheurShadowPosSanada;
        [FieldOffset(0x0244)] public FVector2D TheurCharaPosMituru;
        [FieldOffset(0x024C)] public FVector2D TheurShadowPosMituru;
        [FieldOffset(0x0254)] public FVector2D TheurCharaPosFuka;
        [FieldOffset(0x025C)] public FVector2D TheurShadowPosFuka;
        [FieldOffset(0x0264)] public FVector2D TheurCharaPosAegis;
        [FieldOffset(0x026C)] public FVector2D TheurShadowPosAegis;
        [FieldOffset(0x0274)] public FVector2D TheurCharaPosAmada;
        [FieldOffset(0x027C)] public FVector2D TheurShadowPosAmada;
        [FieldOffset(0x0284)] public FVector2D TheurCharaPosKoromaru;
        [FieldOffset(0x028C)] public FVector2D TheurShadowPosKoromaru;
        [FieldOffset(0x0294)] public FVector2D TheurCharaPosAragaki;
        [FieldOffset(0x029C)] public FVector2D TheurShadowPosAragaki;
        [FieldOffset(0x02A4)] public EOneAnimType Edit_MaskA_InAnimation_SlideIn_Type;
        [FieldOffset(0x02A8)] public int Edit_MaskA_InAnimation_SlideIn_Frame;
        [FieldOffset(0x02AC)] public int Edit_MaskA_InAnimation_SlideIn_Delay;
        [FieldOffset(0x02B0)] public EOneAnimType Edit_MaskA_OutAnimation_SlideIn_Type;
        [FieldOffset(0x02B4)] public int Edit_MaskA_OutAnimation_SlideIn_Frame;
        [FieldOffset(0x02B8)] public int Edit_MaskA_OutAnimation_SlideIn_Delay;
        [FieldOffset(0x02BC)] public EOneAnimType Edit_MaskA_Change_SlideIn_Type;
        [FieldOffset(0x02C0)] public int Edit_MaskA_Change_SlideIn_Frame;
        [FieldOffset(0x02C4)] public int Edit_MaskA_Change_SlideIn_Delay;
        [FieldOffset(0x02C8)] public EOneAnimType Edit_MaskB_InAnimation_SlideIn_Type;
        [FieldOffset(0x02CC)] public int Edit_MaskB_InAnimation_SlideIn_Frame;
        [FieldOffset(0x02D0)] public int Edit_MaskB_InAnimation_SlideIn_Delay;
        [FieldOffset(0x02D4)] public EOneAnimType Edit_MaskB_OutAnimation_SlideIn_Type;
        [FieldOffset(0x02D8)] public int Edit_MaskB_OutAnimation_SlideIn_Frame;
        [FieldOffset(0x02DC)] public int Edit_MaskB_OutAnimation_SlideIn_Delay;
        [FieldOffset(0x02E0)] public EOneAnimType Edit_MaskB_Change_SlideIn_Type;
        [FieldOffset(0x02E4)] public int Edit_MaskB_Change_SlideIn_Frame;
        [FieldOffset(0x02E8)] public int Edit_MaskB_Change_SlideIn_Delay;
        [FieldOffset(0x02EC)] public EOneAnimType Edit_CharacterShadow_InAnimation_SlideIn_Type;
        [FieldOffset(0x02F0)] public int Edit_CharacterShadow_InAnimation_SlideIn_Frame;
        [FieldOffset(0x02F4)] public int Edit_CharacterShadow_InAnimation_SlideIn_Delay;
        [FieldOffset(0x02F8)] public EOneAnimType Edit_CharacterShadow_Change_SlideIn_Type;
        [FieldOffset(0x02FC)] public int Edit_CharacterShadow_Change_SlideIn_Frame;
        [FieldOffset(0x0300)] public int Edit_CharacterShadow_Change_SlideIn_Delay;
        [FieldOffset(0x0304)] public int Edit_Theurgia_Icon_Fade_In_Frame;
        [FieldOffset(0x0308)] public int Edit_Theurgia_Icon_Fade_In_Delay;
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x168)]
    public unsafe struct FCampParamTableSystemRow //: public FTableRowBase
    {
        [FieldOffset(0x0008)] public float SystemTopInMenuDist;
        [FieldOffset(0x000C)] public uint SystemTopInTopMenuFrame1;
        [FieldOffset(0x0010)] public uint SystemTopInTopMenuFrame2;
        [FieldOffset(0x0014)] public uint SystemTopInTopMenuRotFrame;
        [FieldOffset(0x0018)] public EOneAnimType SystemTopInAoItaAnimType;
        [FieldOffset(0x001C)] public uint SystemTopInAoItaFrame;
        [FieldOffset(0x0020)] public uint SystemTopInAoItaWait;
        [FieldOffset(0x0024)] public EOneAnimType SystemTopInTitleAnimType;
        [FieldOffset(0x0028)] public uint SystemTopInTitleFrame;
        [FieldOffset(0x002C)] public uint SystemTopInTitleWait;
        [FieldOffset(0x0030)] public FVector2D SystemTopTutorialOnPos;
        [FieldOffset(0x0038)] public float SystemTopTutorialOnRot;
        [FieldOffset(0x003C)] public FVector2D SystemTopConfigOnPos;
        [FieldOffset(0x0044)] public float SystemTopConfigOnRot;
        [FieldOffset(0x0048)] public FVector2D SystemTopDictionaryOnPos;
        [FieldOffset(0x0050)] public float SystemTopDictionaryOnRot;
        [FieldOffset(0x0054)] public FVector2D SystemTopDataloadOnPos;
        [FieldOffset(0x005C)] public float SystemTopDataloadOnRot;
        [FieldOffset(0x0060)] public FVector2D SystemTopDatasaveOnPos;
        [FieldOffset(0x0068)] public float SystemTopDatasaveOnRot;
        [FieldOffset(0x006C)] public FVector2D SystemTopRollbackOnPos;
        [FieldOffset(0x0074)] public float SystemTopRollbackOnRot;
        [FieldOffset(0x0078)] public FVector2D SystemTopTitleOnPos;
        [FieldOffset(0x0080)] public float SystemTopTitleOnRot;
        [FieldOffset(0x0084)] public FVector2D SystemTopTutorialOffPos;
        [FieldOffset(0x008C)] public float SystemTopTutorialOffRot;
        [FieldOffset(0x0090)] public FVector2D SystemTopConfigOffPos;
        [FieldOffset(0x0098)] public float SystemTopConfigOffRot;
        [FieldOffset(0x009C)] public FVector2D SystemTopDictionaryOffPos;
        [FieldOffset(0x00A4)] public float SystemTopDictionaryOffRot;
        [FieldOffset(0x00A8)] public FVector2D SystemTopDataloadOffPos;
        [FieldOffset(0x00B0)] public float SystemTopDataloadOffRot;
        [FieldOffset(0x00B4)] public FVector2D SystemTopDatasaveOffPos;
        [FieldOffset(0x00BC)] public float SystemTopDatasaveOffRot;
        [FieldOffset(0x00C0)] public FVector2D SystemTopRollbackOffPos;
        [FieldOffset(0x00C8)] public float SystemTopRollbackOffRot;
        [FieldOffset(0x00CC)] public FVector2D SystemTopTitleOffPos;
        [FieldOffset(0x00D4)] public float SystemTopTitleOffRot;
        [FieldOffset(0x00D8)] public FVector2D Edit_CursorOn_Tutorial_Text_Scale;
        [FieldOffset(0x00E0)] public FVector2D Edit_CursorOn_Tutorial_Cursor_Scale;
        [FieldOffset(0x00E8)] public FVector2D Edit_CursorOn_Config_Text_Scale;
        [FieldOffset(0x00F0)] public FVector2D Edit_CursorOn_Config_Cursor_Scale;
        [FieldOffset(0x00F8)] public FVector2D Edit_CursorOn_Dictionary_Text_Scale;
        [FieldOffset(0x0100)] public FVector2D Edit_CursorOn_Dictionary_Cursor_Scale;
        [FieldOffset(0x0108)] public FVector2D Edit_CursorOn_DataLoad_Text_Scale;
        [FieldOffset(0x0110)] public FVector2D Edit_CursorOn_DataLoad_Cursor_Scale;
        [FieldOffset(0x0118)] public FVector2D Edit_CursorOn_DataSave_Text_Scale;
        [FieldOffset(0x0120)] public FVector2D Edit_CursorOn_DataSave_Cursor_Scale;
        [FieldOffset(0x0128)] public FVector2D Edit_CursorOn_RollBack_Text_Scale;
        [FieldOffset(0x0130)] public FVector2D Edit_CursorOn_RollBack_Cursor_Scale;
        [FieldOffset(0x0138)] public FVector2D Edit_CursorOn_ReturnToTitle_Text_Scale;
        [FieldOffset(0x0140)] public FVector2D Edit_CursorOn_ReturnToTitle_Cursor_Scale;
        [FieldOffset(0x0148)] public float Edit_CursorOn_Tutorial_Cursor_Angle;
        [FieldOffset(0x014C)] public float Edit_CursorOn_Config_Cursor_Angle;
        [FieldOffset(0x0150)] public float Edit_CursorOn_Dictionary_Cursor_Angle;
        [FieldOffset(0x0154)] public float Edit_CursorOn_DataLoad_Cursor_Angle;
        [FieldOffset(0x0158)] public float Edit_CursorOn_DataSave_Cursor_Angle;
        [FieldOffset(0x015C)] public float Edit_CursorOn_RollBack_Cursor_Angle;
        [FieldOffset(0x0160)] public float Edit_CursorOn_ReturnToTitle_Cursor_Angle;

    };
    [StructLayout(LayoutKind.Explicit, Size = 0x48)]
    public unsafe struct FCampParamTableTopRow //: public FTableRowBase
    {
        [FieldOffset(0x0008)] public float TopInDist;
        [FieldOffset(0x000C)] public float TopInMenuDist;
        [FieldOffset(0x0010)] public EOneAnimType TopInTitleAnimType;
        [FieldOffset(0x0014)] public uint TopInTitleFrame;
        [FieldOffset(0x0018)] public uint TopInTitleWait;
        [FieldOffset(0x001C)] public EOneAnimType TopInMenuAnimType;
        [FieldOffset(0x0020)] public uint TopInMenuFrame;
        [FieldOffset(0x0024)] public uint TopInMenuWait;
        [FieldOffset(0x0028)] public uint TopInMenuInterval;
        [FieldOffset(0x002C)] public EOneAnimType TopInWhiteCursorAnimType;
        [FieldOffset(0x0030)] public uint TopInWhiteCursorFrame;
        [FieldOffset(0x0034)] public uint TopInWhiteCursorWait;
        [FieldOffset(0x0038)] public EOneAnimType TopInRedCursorAnimType;
        [FieldOffset(0x003C)] public uint TopInRedCursorFrame;
        [FieldOffset(0x0040)] public uint TopInRedCursorWait;
        [FieldOffset(0x0044)] public uint Edit_Top_Reselect_Key_Lock_Frame;
    };

    // UI DATE

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct UAgePanelSection
    {
        [FieldOffset(0x0)] public float X1;
        [FieldOffset(0x4)] public float X2;
        [FieldOffset(0x8)] public float Y1;
        [FieldOffset(0xC)] public float Y2;
        [FieldOffset(0x20)] public UMaterialInstanceDynamic* MaterialInstance;
        [FieldOffset(0x28)] public int Field28;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x370)]
    public unsafe struct UAgePanel //: public UObject
    {
        [FieldOffset(0x0038)] public USprAsset* _readSpr;                                                        // 0x0038 (size: 0x8)
        [FieldOffset(0x0040)] public UMaterial* _readMat;                                                        // 0x0040 (size: 0x10)
        [FieldOffset(0x0050)] public UMaterialInterface* _readMatInst;                                     // 0x0050 (size: 0x10)
        [FieldOffset(0x0058)] public UMaterialInstanceDynamic* _readMatInstDyn;                                     // 0x0050 (size: 0x10)
        //FCurveVectorAnimation _fadeCurve;                                                 // 0x0060 (size: 0x30)
        //UAssetLoader* Loader_;                                                      // 0x02E8 (size: 0x8)
        [FieldOffset(0x270)] public UAgePanelSection BottomMaterial;
        [FieldOffset(0x2a0)] public UAgePanelSection TopMaterial;
        [FieldOffset(0x310)] public FLinearColor BottomColorNormal;
        [FieldOffset(0x320)] public FLinearColor BottomColorDarkHour;
        [FieldOffset(0x330)] public FLinearColor TopColorNormal;
        [FieldOffset(0x340)] public FLinearColor TopColorDarkHour;
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x7e0)]
    public unsafe struct AUIDateDraw //: public AUIBaseActor
    {
        [FieldOffset(0x02A8)] public UAgePanel* m_pAgePanel;
        [FieldOffset(0x02B0)] public USprAsset* m_pFieldSpr;
        [FieldOffset(0x07D0)] public UDataTable* LayoutData;
        [FieldOffset(0x07D8)] public UUILayoutDataTable* LayoutDataTable;

    };

    // AUIMailIcon (colors are hardcoded, not in struct, check DrawMailIconInner)

    [StructLayout(LayoutKind.Explicit, Size = 0x1060)]
    public unsafe struct AUIAccessInfoDraw //: public AUIBaseActor
    {
        [FieldOffset(0x02F0)] public USprAsset* m_pMiniMapSpr;
        [FieldOffset(0x02F8)] public USprAsset* m_pPlaceSpr;
        [FieldOffset(0x0300)] public UUIMiniMapDraw* m_pMiniMap;
        //[FieldOffset(0x0308)] public UAssetLoader* m_pLoader;
        //[FieldOffset(0x0310)] public AScrActor* m_pScrActor;
        [FieldOffset(0x0318)] public UBfAsset* m_pBfAsset;
        [FieldOffset(0x0320)] public UBmdAsset* m_pBmdAsset;
        //[FieldOffset(0x0328)] public UUILocationSelect* m_pLocationSelect;
        [FieldOffset(0x0330)] public UPlgAsset* m_pPlacePlg;
        [FieldOffset(0x0E00)] public FGetUIParameter m_tagUip;
        [FieldOffset(0x0E78)] public FCurveFloatAnimation m_tagFadeInCurve;
        [FieldOffset(0x0EA8)] public FCurveFloatAnimation m_tagFadeOutCurve;
        [FieldOffset(0xee0)] public FVector2D PlaceInfoBgPosition;
        [FieldOffset(0xf04)] public FSprColor PlaceInfoBgColor;
        [FieldOffset(0x0F30)] public UDataTable* LayoutData;
        [FieldOffset(0x0F38)] public UUILayoutDataTable* LayoutDataTable;
        [FieldOffset(0x0F40)] public UDataTable* LayoutParamData;
        [FieldOffset(0x0F48)] public UDataTable* PlaceNameLayoutData;
        [FieldOffset(0x0F50)] public UUILayoutDataTable* PlaceNameLayoutDataTable;
        [FieldOffset(0x0F58)] public UDataTable* MapNameLayoutData;
        [FieldOffset(0x0F60)] public UUILayoutDataTable* MapNameLayoutDataTable;
        [FieldOffset(0x0F68)] public UDataTable* IwatodaiFloorNoLayoutData;
        [FieldOffset(0x0F70)] public UUILayoutDataTable* IwatodaiFloorNoLayoutDataTable;
        [FieldOffset(0x0F78)] public UDataTable* MallFloorNoLayoutData;
        [FieldOffset(0x0F80)] public UUILayoutDataTable* MallFloorNoLayoutDataTable;
        [FieldOffset(0x0F88)] public UDataTable* SchoolFloorNoLayoutData;
        [FieldOffset(0x0F90)] public UUILayoutDataTable* SchoolFloorNoLayoutDataTable;
        [FieldOffset(0x0F98)] public UDataTable* DormitoryFloorNoLayoutData;
        [FieldOffset(0x0FA0)] public UUILayoutDataTable* DormitoryFloorNoLayoutDataTable;
        [FieldOffset(0x0FA8)] public UDataTable* RyokanFloorNoLayoutData;
        [FieldOffset(0x0FB0)] public UUILayoutDataTable* RyokanFloorNoLayoutDataTable;
        [FieldOffset(0x0FB8)] public UDataTable* HotelFloorNoLayoutData;
        [FieldOffset(0x0FC0)] public UUILayoutDataTable* HotelFloorNoLayoutDataTable;
        [FieldOffset(0x0FC8)] public UDataTable* ThebelFloorNoLayoutData;
        [FieldOffset(0x0FD0)] public UUILayoutDataTable* ThebelFloorNoLayoutDataTable;
        [FieldOffset(0x0FD8)] public UDataTable* ArqaFloorNoLayoutData;
        [FieldOffset(0x0FE0)] public UUILayoutDataTable* ArqaFloorNoLayoutDataTable;
        [FieldOffset(0x0FE8)] public UDataTable* YabbashahFloorNoLayoutData;
        [FieldOffset(0x0FF0)] public UUILayoutDataTable* YabbashahFloorNoLayoutDataTable;
        [FieldOffset(0x0FF8)] public UDataTable* TziahFloorNoLayoutData;
        [FieldOffset(0x1000)] public UUILayoutDataTable* TziahFloorNoLayoutDataTable;
        [FieldOffset(0x1008)] public UDataTable* HarabahFloorNoLayoutData;
        [FieldOffset(0x1010)] public UUILayoutDataTable* HarabahFloorNoLayoutDataTable;
        [FieldOffset(0x1018)] public UDataTable* AdamahFloorNoLayoutData;
        [FieldOffset(0x1020)] public UUILayoutDataTable* AdamahFloorNoLayoutDataTable;
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x680)]
    public unsafe struct UUIMiniMapDraw //: public UObject
    {
        [FieldOffset(0x0058)] public USprAsset* m_pMiniMapIcon00Spr;
        [FieldOffset(0x0060)] public USprAsset* m_pMiniMapIcon01Spr;
        [FieldOffset(0x0068)] public USprAsset* m_pPartMaskSpr;
        [FieldOffset(0x0070)] public USprAsset* m_pNoiseSpr;
        [FieldOffset(0x0078)] public UTexture* m_pMapTex;
        [FieldOffset(0x0080)] public UTexture* m_pPrevMapTex1;
        [FieldOffset(0x0088)] public UTexture* m_pPrevMapTex2;
        [FieldOffset(0x0090)] public UTexture* m_pPrevMapTex3;
        [FieldOffset(0x0098)] public UMaterial* m_pVelvetRoomIconMat;
        [FieldOffset(0x00A0)] public UMaterialInstanceDynamic* m_pVelvetRoomIconMID;
        //[FieldOffset(0x00A8)] public UMiniMapIconListTable* m_pFldMiniMapIconTable;
        [FieldOffset(0x00B0)] public UAssetLoader* m_pIconLoader;
        [FieldOffset(0x00B8)] public UAssetLoader* m_pMapLoader;
        [FieldOffset(0x00C0)] public TArray<nint> m_pMapLoaders;
        [FieldOffset(0xF250)] public UTexture* m_pMapParts;
        [FieldOffset(0xF660)] public UTexture* m_pWallTex;
        //[FieldOffset(0xF668)] public UFldDungeonPartVariationDataAsset* m_pPartVariationDataAsset;
        [FieldOffset(0xF760)] public UDataTable* m_pSchoolUpDownLayoutData;
        [FieldOffset(0xF768)] public UUILayoutDataTable* m_pSchoolUpDownLayoutDataTable;
        [FieldOffset(0xF770)] public UDataTable* m_pDormitoryUpDownLayoutData;
        [FieldOffset(0xF778)] public UUILayoutDataTable* m_pDormitoryUpDownLayoutDataTable;
        [FieldOffset(0xF780)] public UDataTable* m_pArcadeUpDownLayoutData;
        [FieldOffset(0xF788)] public UUILayoutDataTable* m_pArcadeUpDownLayoutDataTable;
        [FieldOffset(0xF790)] public UDataTable* m_pMallUpDownLayoutData;
        [FieldOffset(0xF798)] public UUILayoutDataTable* m_pMallUpDownLayoutDataTable;
        [FieldOffset(0xF7A0)] public UDataTable* m_pClubUpDownLayoutData;
        [FieldOffset(0xF7A8)] public UUILayoutDataTable* m_pClubUpDownLayoutDataTable;
        [FieldOffset(0xF7B0)] public UDataTable* m_pRyokanUpDownLayoutData;
        [FieldOffset(0xF7B8)] public UUILayoutDataTable* m_pRyokanUpDownLayoutDataTable;
        [FieldOffset(0xF7C0)] public UDataTable* m_pHotelUpDownLayoutData;
        [FieldOffset(0xF7C8)] public UUILayoutDataTable* m_pHotelUpDownLayoutDataTable;
        [FieldOffset(0xF7D0)] public UDataTable* m_pDungeonUpDownLayoutData;
        [FieldOffset(0xF7D8)] public UUILayoutDataTable* m_pDungeonUpDownLayoutDataTable;
        [FieldOffset(0xF7E0)] public UDataTable* m_pIconLayoutData;
        [FieldOffset(0xF7E8)] public UUILayoutDataTable* m_pIconLayoutDataTable;
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x680)]
    public unsafe struct AUIConfigurationDraw //: public AUIDrawBaseActor
    {
        [FieldOffset(0x02F8)] public FVector2D ItemDrawOffset;
        //[FieldOffset(0x0340)] public TArray<FDrawBGMParam> BgmParams;
        [FieldOffset(0x0350)] public USprAsset* pKeySpr;
        [FieldOffset(0x0668)] public UUILayoutDataTable* LayoutDataTable;
        [FieldOffset(0x0670)] public UUILayoutDataTable* HelpLayoutDataTable;
        [FieldOffset(0x0678)] public UUILayoutDataTable* ConfigTextLayoutDataTable;
    };
    [StructLayout(LayoutKind.Explicit, Size = 0x40f0)]
    public unsafe struct AUITownMapActor //: public AUIBaseActor
    {
        [FieldOffset(0x02F0)] public UDataTable* m_pTownMapDT;
        [FieldOffset(0x02F8)] public USprAsset* m_pTownMapSpr;
        [FieldOffset(0x0300)] public USprAsset* m_pMiniMapIcon00Spr;
        [FieldOffset(0x0308)] public USprAsset* m_pMiniMapIcon01Spr;
        //[FieldOffset(0x0310)] public UAssetLoader* m_pLoader;
        //[FieldOffset(0x0318)] public FGetUIParameter m_tagUip;
        //[FieldOffset(0x0390)] public FCurveVectorAnimation m_curveHeadInAnim;
        //[FieldOffset(0x03C0)] public FCurveVectorAnimation m_curveBlueDiamondAnim;
        //[FieldOffset(0x03F0)] public FCurveVectorAnimation m_curveWhiteDiamondAnim;
        //[FieldOffset(0x0420)] public FCurveVectorAnimation m_curveInfoInAnim;
        //[FieldOffset(0x0450)] public FCurveVectorAnimation m_curveIconAnim;
        [FieldOffset(0x0480)] public UUILocationSelect* m_pLocationSelect;
        //[FieldOffset(0x0488)] public AFldAnimObj* m_pSymbolRefList;
        //[FieldOffset(0x04B8)] public USkinnedMeshComponent* m_pSymbolSkinnedRefList;
        [FieldOffset(0x04E8)] public AActor* m_pFieldCamera;
        [FieldOffset(0x04F0)] public AActor* m_pMainCamera;
        [FieldOffset(0x04F8)] public AActor* m_pStartCamera;
        [FieldOffset(0x0500)] public AActor* m_pInfoCamera;
        [FieldOffset(0x0530)] public AActor* m_pNameLocator;
        [FieldOffset(0x0560)] public UBmdAsset* m_pTownMapDetailText;
        [FieldOffset(0x3ED8)] public FVector MarginRot;
        [FieldOffset(0x3F20)] public UUILayoutDataTable* m_notSelectedLayoutDataTables;
        [FieldOffset(0x3F50)] public UUILayoutDataTable* m_selectedLayoutDataTables;
        [FieldOffset(0x3F80)] public UUILayoutDataTable* m_infoLayoutDataTable;
        [FieldOffset(0x3F88)] public UUILayoutDataTable* m_infoLayoutDataTable2;
        [FieldOffset(0x3F90)] public UDataTable* m_notSelectedParamLayouts;
        [FieldOffset(0x3FC0)] public UDataTable* m_selectedParamLayouts;
        [FieldOffset(0x3FF0)] public UDataTable* m_infoParamLayout;
        [FieldOffset(0x3FF8)] public UDataTable* m_infoParamLayout2;
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x68)]
    public unsafe struct UAssetLoader //: public UObject
    {
    };

    // SAVE FILE

    public enum ECldTimeZone : byte
    {
        None = 0,
        EarlyMorning = 1,
        Morning = 2,
        AM = 3,
        Noon = 4,
        PM = 5,
        AfterSchool = 6,
        Night = 7,
        Shadow = 8,
        Midnight = 9,
        TimeMax = 10,
        ECldTimeZone_MAX = 11,
    };

    public enum ECldWeek : byte
    {
        Sunday = 0,
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        WeekMax = 7,
        ECldWeek_MAX = 8,
    };

    public enum ECldMoonAge : byte
    {
        Moon01 = 0,
        Moon02 = 1,
        Moon03 = 2,
        Moon04 = 3,
        Moon05 = 4,
        Moon06 = 5,
        Moon07 = 6,
        Moon08 = 7,
        Moon09 = 8,
        Moon10 = 9,
        Moon11 = 10,
        Moon12 = 11,
        Moon13 = 12,
        Moon14 = 13,
        Moon15 = 14,
        Moon16 = 15,
        Moon17 = 16,
        Moon18 = 17,
        Moon19 = 18,
        Moon20 = 19,
        Moon21 = 20,
        Moon22 = 21,
        Moon23 = 22,
        Moon24 = 23,
        Moon25 = 24,
        Moon26 = 25,
        Moon27 = 26,
        Moon28 = 27,
        Moon29 = 28,
        Moon30 = 29,
        MoonMax = 30,
        ECldMoonAge_MAX = 31,
    };

    [StructLayout(LayoutKind.Explicit, Size = 0xd0)]
    public unsafe struct FSaveGameHeadder
    {
        [FieldOffset(0x0000)] public FString GameName;
        [FieldOffset(0x0010)] public FString SaveSlotName;
        [FieldOffset(0x0020)] public uint UserIndex;
        [FieldOffset(0x0024)] public byte FirstName;
        [FieldOffset(0x0064)] public byte LastName;
        [FieldOffset(0x00A4)] public int Month;
        [FieldOffset(0x00A8)] public int Day;
        [FieldOffset(0x00AC)] public ECldWeek Week;
        [FieldOffset(0x00AD)] public ECldTimeZone TimeZone;
        [FieldOffset(0x00B0)] public int FldMajorID;
        [FieldOffset(0x00B4)] public int FldMinorID;
        [FieldOffset(0x00B8)] public int FldPartsID;
        [FieldOffset(0x00BC)] public uint PlayerLevel;
        [FieldOffset(0x00C0)] public ushort Difficulty;
        [FieldOffset(0x00C4)] public uint PlayTime;
        [FieldOffset(0x00C8)] public ECldMoonAge Age;
        [FieldOffset(0x00CC)] public int ClearStatus;
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x3806F8)]
    public unsafe struct UXRD777SaveGame //: public USaveGame
    {
        [FieldOffset(0x0028)] public FSaveGameHeadder SaveDataHeadder;
        [FieldOffset(0x00F8)] public uint SaveDataArea;
    };
    [StructLayout(LayoutKind.Explicit, Size = 0x32C0)]
    public unsafe struct UTCSSaveData //: public UObject
    {
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public unsafe struct UXrd777SaveManager //: public UObject
    {
        [FieldOffset(0x0058)] public UTCSSaveData* TCSSaveData;
        [FieldOffset(0x0070)] public UXRD777SaveGame* NetworkSaveInstance;
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x250E0)]
    public unsafe struct UGlobalWork //: public UGameInstance
    {
        //[FieldOffset(0x24778)] public USequence* mSequenceInstance_;
        //[FieldOffset(0x24780)] public UCalendar* mCalendarInstance_;
        //[FieldOffset(0x24788)] public UCldCommonData* mCldCommonData_;
        //[FieldOffset(0x24790)] public UFileNameManager* mFileNameData_;
        //[FieldOffset(0x24798)] public UFldCommonData* mFldCommonData_;
        //[FieldOffset(0x247A0)] public UDatItem* mItemData_;
        //[FieldOffset(0x247A8)] public UTrophyManager* mTrophy_;
        //[FieldOffset(0x247B0)] public ULeaderBoardManager* mLeaderBoard_;
        //[FieldOffset(0x247B8)] public USignedInDialog* mSignedInDialog_;
        //[FieldOffset(0x247C0)] public UErrorDialog* mErrorDialog_;
        //[FieldOffset(0x247C8)] public UMessageDialog* mMessageDialog_;
        //[FieldOffset(0x247D0)] public UBustupController* pBustupController;
        //[FieldOffset(0x247D8)] public UCommunityWork* pCommunityWork;
        //[FieldOffset(0x247E0)] public UMsgWork* pMsgWork;
        //[FieldOffset(0x247E8)] public UEvtDataLoad* pEvtDataLoad;
        //[FieldOffset(0x247F0)] public UFrameBufferCapture* pFrameBufferCapture;
        //[FieldOffset(0x247F8)] public UPadRumble* pPadRumble;
        //[FieldOffset(0x248C8)] public UFldCharParamTable* mFldCharParamTable_;
        //[FieldOffset(0x248D0)] public UAppCharFootstepsTable* mFootstepsTable_;
        //[FieldOffset(0x248D8)] public UAppCharacterPoolManager* mCharacterPoolManager_;
        //[FieldOffset(0x248E0)] public UDatSystemText* mSystemTextTable;
        //[FieldOffset(0x248E8)] public UDatUIUseText* mUIUseTextTable;
        //[FieldOffset(0x248F0)] public UDatUICalendarText* mUICalendarTextTable;
        //[FieldOffset(0x248F8)] public UXrd777SaveManager* mSaveManager_;
        //[FieldOffset(0x24900)] public UAddContent* mAddContent_;
        //[FieldOffset(0x24F78)] public ULoading* pLoadingInst;
        //[FieldOffset(0x24F80)] public ACmpMainActor* mCmpMainActor_;
        //[FieldOffset(0x24F88)] public ABtlGuiResourcesBase* mBtlGuiResourcesActor_;
        //[FieldOffset(0x24F90)] public UBtlEncountWipeLoader* mBtlEncountWipeLoader_;
        //[FieldOffset(0x24F98)] public ABtlEncountWipeCore* mBtlEncountWipeCore_;
        //[FieldOffset(0x24FA0)] public AFldLevelPoolManager* mLevelPoolManager_;
        //[FieldOffset(0x24FA8)] public bool mPoolSetting_;
        //[FieldOffset(0x24FE8)] public FSaveGameHeadder mTempSaveHeader_;
        //[FieldOffset(0x250B8)] public bool bTempSaveHeaderUsed_;
        //[FieldOffset(0x250C0)] public UGlobalGameData* mGameDataProc_;
        //[FieldOffset(0x250C8)]  public AAppActor* mSystemMonitor_;
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x64)]
    public unsafe struct SprDefStruct1
    {
        [FieldOffset(0x0)] public FVector2D Position;
        [FieldOffset(0x8)] public float Field08;
        [FieldOffset(0xC)] public float Field0C;
        [FieldOffset(0x10)] public float Field10;
        [FieldOffset(0x14)] public float Field14;
        [FieldOffset(0x18)] public FSprColor color;
        [FieldOffset(0x1C)] public float Field1C;
        [FieldOffset(0x20)] public FVector4 Size;
        [FieldOffset(0x30)] public float Field30;
        [FieldOffset(0x34)] public float Field34;
        [FieldOffset(0x38)] public float Field38;
        [FieldOffset(0x3c)] public float Field3C;
        [FieldOffset(0x40)] public float Field40;
        [FieldOffset(0x44)] public float Field44;
        [FieldOffset(0x48)] public uint Field48;
        [FieldOffset(0x4c)] public int SpriteIndex2;
        [FieldOffset(0x64)] public int SpriteIndex;

        public SprDefStruct1(FVector2D Position, float Field08, float Field0C, float Field10, float Field14, FSprColor color, float Field1C,
            FVector4 Size, float Field30, float Field34, float Field38, float Field3C, float Field40, float Field44, int spriteIndex)
        {
            this.Position = Position;
            this.Field08 = Field08;
            this.Field0C = Field0C;
            this.Field10 = Field10;
            this.Field14 = Field14;
            this.color = color;
            this.Field1C = Field1C;
            this.Size = Size;
            this.Field30 = Field30;
            this.Field34 = Field34;
            this.Field38 = Field38;
            this.Field3C = Field3C;
            this.Field40 = Field40;
            this.Field44 = Field44;
            this.Field48 = 0;
            this.SpriteIndex = spriteIndex;
            this.SpriteIndex2 = SpriteIndex;
        }

        public SprDefStruct1(int spriteIndex, FVector2D Position, FSprColor color, float Field0C, float Field08, float Field14)
        {
            Size = new FVector4(960, 540, 0, 1);
            Field30 = 0;
            Field34 = 0;
            this.Field14 = Field14;
            Field40 = 1;
            Field44 = 0;
            Field38 = 0;
            Field3C = 1;
            Field48 = 0;
            Field1C = 1;
            this.color = color;
            this.Position = Position;
            this.Field0C = Field0C;
            Field10 = Field0C;
            this.Field08 = Field08;
            this.SpriteIndex = spriteIndex;
            this.SpriteIndex2 = SpriteIndex;
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public unsafe struct PlgDefStruct1
    {
        [FieldOffset(0x0)] public FVector2D Position;
        [FieldOffset(0x8)] public float Field08;
        [FieldOffset(0xc)] public FVector2D Stretch;
        [FieldOffset(0x14)] public float Field14;
        [FieldOffset(0x18)] public float Field18;
        [FieldOffset(0x1c)] public float Rotation;
        [FieldOffset(0x20)] public float Field20;
        [FieldOffset(0x24)] public FSprColor Color;
        [FieldOffset(0x28)] public int VertexIndex;
        [FieldOffset(0x2c)] public FVector4 Size;
        [FieldOffset(0x3c)] public int Field3C;

        public PlgDefStruct1(FVector2D position, FSprColor color, int vertexIndex, float rotation, FVector2D stretch)
        {
            Size = new FVector4(960, 540, 0, 1);
            Field3C = 0;
            Field08 = 0;
            Field14 = 1;
            Position = position;
            VertexIndex = vertexIndex;
            Stretch = stretch;
            Rotation = rotation;
            Field18 = 0;
            Field20 = 0;
            Color = color;
        }

        public void SetColor(FSprColor color) => Color = color;
    }

    // MESSAGE BOX

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct FMsgItemInfo
    {
    }; // Size: 0x10

    [StructLayout(LayoutKind.Explicit, Size = 0x108)]
    public unsafe struct UMsgProcWindowBase //: public UObject
    {
        [FieldOffset(0x88)] public byte MessageBoxStatus;
        [FieldOffset(0x90)] UMsgItem* pMsgWork;                                                         // 0x0090 (size: 0x8)
        [FieldOffset(0x98)] UTutorialManager* pTutorialManager;                                         // 0x0098 (size: 0x8)

    }; // Size: 0x108

    [StructLayout(LayoutKind.Explicit, Size = 0xB0)]
    public unsafe struct UMsgItem //: public UObject
    {
        [FieldOffset(0x0068)] public TArray<FMsgItemInfo> MssageList;
        [FieldOffset(0x0078)] public TArray<FMsgItemInfo> SpeakerList;
        [FieldOffset(0x0088)] public UMsgProcWindowBase* mpMsgProcWindow;

    };

    [StructLayout(LayoutKind.Explicit, Size = 0xB0)]
    public unsafe struct UMsgAssist //: public UMsgItem
    {
    }; // Size: 0xB0

    [StructLayout(LayoutKind.Explicit, Size = 0xC8)]
    public unsafe struct UMsgDLC //: public UMsgItem
    {
    }; // Size: 0xC8
    [StructLayout(LayoutKind.Explicit, Size = 0xC8)]
    public unsafe struct UMsgDictionary //: public UMsgItem
    {
    }; // Size: 0xC8
    [StructLayout(LayoutKind.Explicit, Size = 0xB0)]
    public unsafe struct UMsgMessage //: public UMsgItem
    {
    }; // Size: 0xB0
    [StructLayout(LayoutKind.Explicit, Size = 0xC0)]
    public unsafe struct UMsgMind //: public UMsgItem
    {
    }; // Size: 0xC0
    [StructLayout(LayoutKind.Explicit, Size = 0x110)]
    public unsafe struct UMsgMindSubtitles //: public UMsgItem
    {
        [FieldOffset(0x0100)] public UTexture* pTexture;
        [FieldOffset(0x0108)] public UAssetLoader* pAssetLoader;
    }; // Size: 0x110
    [StructLayout(LayoutKind.Explicit, Size = 0xE0)]
    public unsafe struct UMsgPerformance //: public UMsgItem
    {
    }; // Size: 0xE0
    [StructLayout(LayoutKind.Explicit, Size = 0xD0)]
    public unsafe struct UMsgSubtitles //: public UMsgItem
    {
    }; // Size: 0xD0
    [StructLayout(LayoutKind.Explicit, Size = 0xE8)]
    public unsafe struct UMsgSystem //: public UMsgItem
    {
    }; // Size: 0xE8
    [StructLayout(LayoutKind.Explicit, Size = 0xC8)]
    public unsafe struct UMsgTutorial //: public UMsgItem
    {
    }; // Size: 0xC8

    public enum EMsgProcWindowLayout_ASSIST
    {
        ASSIST_POSITION = 0,
        LINE_SPACE_OFFSET = 1,
        SUPPORT_INTERVAL = 2,
    };

    public enum EMsgProcWindowLayout_DIALOG
    {
        TITLE_TEXT = 0,
        MAIN_TEXT = 1,
    };

    public enum EMsgProcWindowLayout_MIND
    {
        MSG_OFFSET = 0,
        MSG_ROW = 1,
        SELECT_OFS = 2,
    };

    public enum EMsgProcWindowLayout_SELECT
    {
        SELECT_TEXT_COL = 0,
        NON_SELECT_TEXT_COL = 1,
        SELECT_TEXT_OFFSET = 2,
        NON_SELECT_TEXT_OFFSET = 3,
    };

    public enum EMsgProcWindowLayout_SIMPLE
    {
        MSG_TEXT_COL = 0,
        MSG_OFFSET = 1,
        MSG_ROW = 2,
    };

    public enum EMsgProcWindowTextColLayout_ASSIST
    {
        TEXT_SIZE = 0,
    };
    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public unsafe struct UTutorialManager //: public UObject
    {
        [FieldOffset(0x0048)] public UAssetLoader* pAssetLoader;
        [FieldOffset(0x0050)] public UBmdAsset* pBmdAsset;
        [FieldOffset(0x0058)] public TArray<nint> Textures;
        [FieldOffset(0x0068)] public TArray<FString> Paths;

    }; // Size: 0x78
    [StructLayout(LayoutKind.Explicit, Size = 0x528)]
    public unsafe struct AitfMsgProgWindow_TUTRIALDraw //: public AUIDrawBaseActor
    {
        [FieldOffset(0x02B8)] public float FadeInNonThumbnailMovePosFrame;
        [FieldOffset(0x02BC)] public float FadeInWaitNonThumbnailMovePosFrame;
        [FieldOffset(0x02C0)] public float FadeOutNonThumbnailMovePosFrame;
        [FieldOffset(0x02C4)] public float FadeOutWaitNonThumbnailMovePosFrame;
        [FieldOffset(0x02C8)] public float FadeInNonThumbnailAlphaFrame;
        [FieldOffset(0x02CC)] public float FadeInWaitNonThumbnailAlphaFrame;
        [FieldOffset(0x02D0)] public float FadeOutNonThumbnailAlphaFrame;
        [FieldOffset(0x02D4)] public float FadeOutWaitNonThumbnailAlphaFrame;
        [FieldOffset(0x02D8)] public float FadeInThumbnailMovePosFrame;
        [FieldOffset(0x02DC)] public float FadeInWaitThumbnailMovePosFrame;
        [FieldOffset(0x02E0)] public float FadeOutThumbnailMovePosFrame;
        [FieldOffset(0x02E4)] public float FadeOutWaitThumbnailMovePosFrame;
        [FieldOffset(0x02E8)] public float FadeInThumbnailAlphaFrame;
        [FieldOffset(0x02EC)] public float FadeInWaitThumbnailAlphaFrame;
        [FieldOffset(0x02F0)] public float FadeOutThumbnailAlphaFrame;
        [FieldOffset(0x02F4)] public float FadeOutWaitThumbnailAlphaFrame;
        [FieldOffset(0x02F8)] public float FadeInThumbnailAngleFrame;
        [FieldOffset(0x02FC)] public float FadeInWaitThumbnailAngleFrame;
        [FieldOffset(0x0300)] public float FadeOutThumbnailAngleFrame;
        [FieldOffset(0x0304)] public float FadeOutWaitThumbnailAngleFrame;
        [FieldOffset(0x0308)] public float FixThumbnailAngle;
        [FieldOffset(0x030C)] public float FixThumbnailPosX;
        [FieldOffset(0x0310)] public float FixThumbnailPosY;
        [FieldOffset(0x0314)] public float FixThumbnailPlusAngle;
        [FieldOffset(0x0318)] public float FadeInGroundAlphaFrame;
        [FieldOffset(0x031C)] public float FadeInWaitGroundAlphaFrame;
        [FieldOffset(0x0320)] public float FadeOutGroundAlphaFrame;
        [FieldOffset(0x0324)] public float FadeOutWaitGroundAlphaFrame;
        [FieldOffset(0x0328)] public FColor NavyColor;
        [FieldOffset(0x032C)] public FColor GradationColor;
        [FieldOffset(0x0330)] public FColor UnderShadowColor;
        [FieldOffset(0x0334)] public FColor BackColor;
        [FieldOffset(0x0338)] public float PageOutButtonFrame;
        [FieldOffset(0x033C)] public float PageOutWaitButtonFrame;
        [FieldOffset(0x0340)] public float PageInButtonFrame;
        [FieldOffset(0x0344)] public float PageInWaitButtonFrame;
        [FieldOffset(0x0348)] public float PageOutTextFrame;
        [FieldOffset(0x034C)] public float PageOutWaitTextFrame;
        [FieldOffset(0x0350)] public float PageInTextFrame;
        [FieldOffset(0x0354)] public float PageInWaitTextFrame;
        [FieldOffset(0x0358)] public float PageOutTextAlphaFrame;
        [FieldOffset(0x035C)] public float PageOutWaitTextAlphaFrame;
        [FieldOffset(0x0360)] public float PageInTextAlphaFrame;
        [FieldOffset(0x0364)] public float PageInWaitTextAlphaFrame;
        [FieldOffset(0x0368)] public float PageOutThumbnailFrame;
        [FieldOffset(0x036C)] public float PageOutWaitThumbnailFrame;
        [FieldOffset(0x0370)] public float PageInThumbnailFrame;
        [FieldOffset(0x0374)] public float PageInWaitThumbnailFrame;
        [FieldOffset(0x0378)] public float InWaitThumbnailShadowFrame;
        [FieldOffset(0x037C)] public float InThumbnailShadowFrame;
        [FieldOffset(0x0380)] public int MaskLoopWaitFrameFirst;
        [FieldOffset(0x0384)] public int MaskLoopWaitFrameSecond;
        [FieldOffset(0x0388)] public int MaskLoopWaitFrameThird;
        [FieldOffset(0x038C)] public int MaskLoopMoveFrameFirst;
        [FieldOffset(0x0390)] public int MaskLoopMoveFrameSecond;
        [FieldOffset(0x0394)] public int MaskLoopMoveFrameThird;
        [FieldOffset(0x0398)] public int ButtonScaleWaitFrameFirst;
        [FieldOffset(0x039C)] public int ButtonScaleWaitFrameSecond;
        [FieldOffset(0x03A0)] public int ButtonScaleWaitFrameThird;
        [FieldOffset(0x03A4)] public int ButtonScaleMoveFrameFirst;
        [FieldOffset(0x03A8)] public int ButtonScaleMoveFrameSecond;
        [FieldOffset(0x03AC)] public int ButtonScaleMoveFrameThird;
        [FieldOffset(0x03B0)] public int Edit_Icon_Animation_Start_Delay;
        [FieldOffset(0x03B4)] public int Edit_Icon_Angle_Frame;
        [FieldOffset(0x03B8)] public int Edit_Icon_Angle_Delay;
        [FieldOffset(0x03BC)] public int Edit_Icon_Scale_1Loop_Frame;
    }; // Size: 0x528

    [StructLayout(LayoutKind.Explicit, Size = 0xB0)]
    public unsafe struct USelItem //: public UObject
    {
        [FieldOffset(0x00A0)] UMsgProcWindow_Select* mpSelProcWindow;
    }; // Size: 0xB0
    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public unsafe struct UBustupAnimDataAsset //: public UAppMultiDataAsset
    {
        [FieldOffset(0x0030)] public TArray<FBustupAnim> EyeAnim;
        [FieldOffset(0x0040)] public TArray<FBustupMouthAnim> MouthAnim;

    }; // Size: 0x50
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public unsafe struct USupportBustupDataAsset //: public UAppDataAsset
    {
        [FieldOffset(0x30)] TArray<FSupportBustupParam> Data;
    }; // Size: 0x40

    public struct FBustupAnim
    {
        byte Type;                                                                       // 0x0000 (size: 0x1)
        float Duration;                                                                   // 0x0004 (size: 0x4)
        float Random;                                                                     // 0x0008 (size: 0x4)

    }; // Size: 0xC

    public struct FBustupMouthAnim
    {
        TArray<FBustupAnim> Anim;                                                         // 0x0000 (size: 0x10)

    }; // Size: 0x10

    public struct FSupportBustupParam
    {
        ushort CharaID;                                                                   // 0x0000 (size: 0x2)
        FString Pose;                                                                     // 0x0008 (size: 0x10)
        float OffsetLeft_X;                                                               // 0x0018 (size: 0x4)
        float OffsetLeft_Y;                                                               // 0x001C (size: 0x4)
        float MaskOffsetLeft_Y;                                                           // 0x0020 (size: 0x4)
        float OffsetRight_X;                                                              // 0x0024 (size: 0x4)
        float OffsetRight_Y;                                                              // 0x0028 (size: 0x4)
        float MaskOffsetRight_Y;                                                          // 0x002C (size: 0x4)

    }; // Size: 0x30

    [StructLayout(LayoutKind.Explicit, Size = 0x128)]
    public unsafe struct UBustupObject //: public UObject
    {
        [FieldOffset(0x0028)] public UMaterialInterface* BaseMaterial_;
        [FieldOffset(0x0030)] public UMaterialInstanceDynamic* DrawableMaterial_;
        [FieldOffset(0x0040)] public UTexture* BaseTex_;
        [FieldOffset(0x0048)] public UTexture* ShadowMask_;
        [FieldOffset(0x0050)] public UTexture* RimLightMask_;
        [FieldOffset(0x0058)] public UTexture* EyeTex_;
        [FieldOffset(0x0070)] public UTexture* MouthTex_;
        [FieldOffset(0x0088)] public UTexture* BlushTex_;
        [FieldOffset(0x0090)] public UTexture* SweatTex_;
        [FieldOffset(0x0098)] public UTexture* BaseMask_;
        [FieldOffset(0x00A0)] public UTexture* DropMask_;
        [FieldOffset(0x00A8)] public UAssetLoader* Loader_;
        [FieldOffset(0x0118)] public UBustupAnimDataAsset* BustupAnim_;
        [FieldOffset(0x0120)] public USupportBustupDataAsset* SupportBustupOffset_;

    }; // Size: 0x128

    [StructLayout(LayoutKind.Explicit, Size = 0x1D8)]
    public unsafe struct UMsgProcWindow_Assist //: public UMsgProcWindowBase
    {
        [FieldOffset(0x0108)] public UAssetLoader* Loader_;
        [FieldOffset(0x0110)] public USprAsset* MsgSpr_;
        [FieldOffset(0x0118)] public TArray<FVector> SupportPos;
    }; // Size: 0x1D8

    [StructLayout(LayoutKind.Explicit, Size = 0x228)]
    public unsafe struct UMsgProcWindow_Mind //: public UMsgProcWindowBase
    {
        [FieldOffset(0x0108)] public UAssetLoader* Loader_;
        [FieldOffset(0x0110)] public UMaterial* ReadMat_;
        [FieldOffset(0x0118)] public UMaterial* ReadaddMat_;
        [FieldOffset(0x0120)] public UMaterial* ReadblurMat_;
        [FieldOffset(0x0128)] public UMaterialInstanceDynamic* ReadMatInst_;
        [FieldOffset(0x0130)] public UMaterialInstanceDynamic* ReadaddMatInst_;
        [FieldOffset(0x0138)] public UMaterialInstanceDynamic* ReadblurMatInst_;
        [FieldOffset(0x0140)] public USprAsset* _readSpr;
        [FieldOffset(0x0148)] public UPlgAsset* MsgPlg_;
        [FieldOffset(0x1ec)] public FLinearColor OuterBorderColor;
        [FieldOffset(0x1fc)] public FLinearColor InnerContentsColor;
        [FieldOffset(0x20c)] public FLinearColor OutsideMistColor;
        [FieldOffset(0x0220)] public UUILayoutDataTable* LayoutDataTable;
    }; // Size: 0x228

    [StructLayout(LayoutKind.Explicit, Size = 0x158)]
    public unsafe struct UMsgProcWindow_Performance //: public UMsgProcWindowBase
    {
        [FieldOffset(0x0108)] public UAssetLoader* m_pPerformanceLoader;
        [FieldOffset(0x0110)] public AitfMsgProgWindow_TUTRIALDraw* PerformanceDrawClass;
        [FieldOffset(0x0118)] public AitfMsgProgWindow_TUTRIALDraw* pPerformanceDraw;
        [FieldOffset(0x0120)] public UDataTable* TextColDataTable;
        [FieldOffset(0x0128)] public UUILayoutDataTable* TextColLayoutDataTable;
        [FieldOffset(0x0130)] public UDataTable* OkNextLayoutData;
        [FieldOffset(0x0138)] public UUILayoutDataTable* OkNextLayoutDataTable;
        [FieldOffset(0x0140)] public UDataTable* OkNextMaskLayoutData;
        [FieldOffset(0x0148)] public UUILayoutDataTable* OkNextMaskLayoutDataTable;
    }; // Size: 0x158

    [StructLayout(LayoutKind.Explicit, Size = 0x110)]
    public unsafe struct UMsgProcWindow_Select //: public UMsgProcWindowBase
    {
        [FieldOffset(0x0108)] public USelItem* pSelWork;
    }; // Size: 0x110

    [StructLayout(LayoutKind.Explicit, Size = 0x238)]
    public unsafe struct UMsgProcWindow_Select_Mind //: public UMsgProcWindow_Select
    {
        [FieldOffset(0x0128)] public UBustupObject* BustupObject_;
        [FieldOffset(0x0130)] public USprAsset* MsgSpr_;
        [FieldOffset(0x0138)] public UPlgAsset* MsgPlg_;
        [FieldOffset(0x0228)] public UAssetLoader* Loader_;
        [FieldOffset(0x0230)] public UUILayoutDataTable* LayoutDataTable;
    }; // Size: 0x238

    [StructLayout(LayoutKind.Explicit, Size = 0x1D0)]
    public unsafe struct UMsgProcWindow_Select_Simple //: public UMsgProcWindow_Select
    {
        [FieldOffset(0x0190)] public UBustupObject* BustupObject_;
        [FieldOffset(0x0198)] public USprAsset* MsgSpr_;
        [FieldOffset(0x01A0)] public UPlgAsset* MsgPlg_;
        [FieldOffset(0x01A8)] public UUILayoutDataTable* LayoutDataTable;
    }; // Size: 0x1D0

    [StructLayout(LayoutKind.Explicit, Size = 0x1B8)]
    public unsafe struct UMsgProcWindow_Simple //: public UMsgProcWindowBase
    {
        [FieldOffset(0x0108)] public UAssetLoader* Loader_;
        [FieldOffset(0x0110)] public USprAsset* MsgSpr_;
        [FieldOffset(0x0118)] public UPlgAsset* MsgPlg_;
        [FieldOffset(0x158)] public float OffsetX;
        [FieldOffset(0x15c)] public float SizeX;
        [FieldOffset(0x160)] public float Opacity;
        [FieldOffset(0x164)] public float Field164;
        [FieldOffset(0x168)] public float BgPieceRotation;
        [FieldOffset(0x170)] public float Field170;
        [FieldOffset(0x174)] public float BgPieceTransparency;
        [FieldOffset(0x180)] public uint MsgProcWindowStatus;
        [FieldOffset(0x184)] public int MessageBoxWidth;
        [FieldOffset(0x188)] public int MessageBoxHeight;
        [FieldOffset(0x18c)] public int MessageBoxSubWidth;
        [FieldOffset(0x190)] public int MessageBoxSubHeight;
        [FieldOffset(0x01B0)] public UUILayoutDataTable* LayoutDataTable;

    }; // Size: 0x1B8

    [StructLayout(LayoutKind.Explicit, Size = 0x158)]
    public unsafe struct UMsgProcWindow_System //: public UMsgProcWindowBase
    {
        [FieldOffset(0x0108)] public UAssetLoader* m_pSystemLoader;
        [FieldOffset(0x0110)] public AitfMsgProgWindow_TUTRIALDraw* SystemDrawClass;
        [FieldOffset(0x0118)] public AitfMsgProgWindow_TUTRIALDraw* pSystemDraw;
        [FieldOffset(0x0120)] public UDataTable* TextColDataTable;
        [FieldOffset(0x0128)] public UUILayoutDataTable* TextColLayoutDataTable;
        [FieldOffset(0x0130)] public UDataTable* OkNextLayoutData;
        [FieldOffset(0x0138)] public UUILayoutDataTable* OkNextLayoutDataTable;
        [FieldOffset(0x0140)] public UDataTable* OkNextMaskLayoutData;
        [FieldOffset(0x0148)] public UUILayoutDataTable* OkNextMaskLayoutDataTable;
    }; // Size: 0x158

    [StructLayout(LayoutKind.Explicit, Size = 0x158)]
    public unsafe struct UMsgProcWindow_Tutorial //: public UMsgProcWindowBase
    {
        [FieldOffset(0x0108)] public UAssetLoader* m_pTutrialLoader;
        [FieldOffset(0x0110)] public AitfMsgProgWindow_TUTRIALDraw* TutrialDrawClass;
        [FieldOffset(0x0118)] public AitfMsgProgWindow_TUTRIALDraw* pTutrialDraw;
        [FieldOffset(0x0120)] public UDataTable* TextColDataTable;
        [FieldOffset(0x0128)] public UUILayoutDataTable* TextColLayoutDataTable;
        [FieldOffset(0x0130)] public UDataTable* OkNextLayoutData;
        [FieldOffset(0x0138)] public UUILayoutDataTable* OkNextLayoutDataTable;
        [FieldOffset(0x0140)] public UDataTable* OkNextMaskLayoutData;
        [FieldOffset(0x0148)] public UUILayoutDataTable* OkNextMaskLayoutDataTable;
    }; // Size: 0x158

    public struct FSaveSlotItem
    {
        int SlotNo;                                                                     // 0x0000 (size: 0x4)
        int Month;                                                                      // 0x0004 (size: 0x4)
        int Day;                                                                        // 0x0008 (size: 0x4)
        int PLV;                                                                        // 0x000C (size: 0x4)
        int Week;                                                                       // 0x0010 (size: 0x4)
        bool bHoliday;                                                                    // 0x0014 (size: 0x1)
        int PTimeHour;                                                                  // 0x0018 (size: 0x4)
        int PTimeMin;                                                                   // 0x001C (size: 0x4)
        int Diff;                                                                       // 0x0020 (size: 0x4)
        int MoonAge;                                                                    // 0x0024 (size: 0x4)
        int TimeZone;                                                                   // 0x0028 (size: 0x4)
        FString PlayerName;                                                               // 0x0030 (size: 0x10)
        FString LocationName;                                                             // 0x0040 (size: 0x10)
        bool bIsGoodEnd;                                                                  // 0x0050 (size: 0x1)
        bool bIsBadEnd;                                                                   // 0x0051 (size: 0x1)
        bool bIsLoaded;                                                                   // 0x0052 (size: 0x1)
        bool bHasData;                                                                    // 0x0053 (size: 0x1)
        bool bUseDefaultHeroName;                                                         // 0x0054 (size: 0x1)

    }; // Size: 0x58

    public enum ESaveDrawOpenType
    {
        TYPE_FIELD = 0,
        TYPE_CAMP = 1,
        TYPE_TITLE = 2,
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x338)]
    public unsafe struct ASaveLoadDraw //: public AUIDrawBaseActor
    {
        [FieldOffset(0x02EC)] public int BootMode;
        [FieldOffset(0x02F0)] public bool bIsStartInAnim;
        [FieldOffset(0x02F1)] public bool bIsUseCapture;
        [FieldOffset(0x02F2)] public bool bIsOpenCamp;
        [FieldOffset(0x02F3)] public bool bIsUseScrollBar;
        [FieldOffset(0x02F4)] public bool bIsStartCloseAnim;
        [FieldOffset(0x02F8)] public int CursorIndex;
        [FieldOffset(0x02FC)] public int ListTopIndex;
        [FieldOffset(0x0300)] public int CurrentIndex;
        [FieldOffset(0x0308)] public TArray<FSaveSlotItem> SaveSlotItems;
        [FieldOffset(0x0318)] public ESaveDrawOpenType OpenType;
        [FieldOffset(0x031C)] public int AllSlotNum;
        [FieldOffset(0x0320)] public int CheckOverListIndex;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public unsafe struct FGetUIParameter
    {
        //[FieldOffset(0x0018)] public UUIParameterAsset* ParameterAsset;                                          //  (size: 0x8)
        [FieldOffset(0x0020)] public TMap ParameterMap;                                                //  (size: 0x50)
        [FieldOffset(0x0070)] public UAssetLoader* AssetLoader;                                                  //  (size: 0x8)
    }; // Size: 0x78

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public unsafe struct FCurveLinearColorAnimation //: public FBaseCurveAnimation
    {
        [FieldOffset(0x0028)] UCurveLinearColor* m_pCurveLinearColor;                                     //  (size: 0x8)

    }; // Size: 0x30

    [StructLayout(LayoutKind.Explicit, Size = 0x11c0)]
    public unsafe struct AUIMiscCheckDraw //: public AUIBaseActor
    {
        [FieldOffset(0x02B8)] public USprAsset* m_pAlphaSpr;
        [FieldOffset(0x02C0)] public USprAsset* m_pKeySpr;
        [FieldOffset(0x02C8)] public UAssetLoader* m_pLoader;
        [FieldOffset(0x02D0)] public FCurveLinearColorAnimation m_tagMaxColorWave;
        [FieldOffset(0x0300)] public FGetUIParameter m_uip;
        [FieldOffset(0x1198)] public UDataTable* LayoutData;
        [FieldOffset(0x11A0)] public UDataTable* TextLayoutData;
        [FieldOffset(0x11A8)] public UUILayoutDataTable* LayoutDataTable;
        [FieldOffset(0x11B0)] public UUILayoutDataTable* TextLayoutDataTable;
    };

    public unsafe struct FCurveFloatAnimation //: public FBaseCurveAnimation
    {
        //UCurveFloat* m_pCurveFloat;                                                 // 0x0028 (size: 0x8)
    }; // Size: 0x30

    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public struct FFldShortcutData
    {
        [FieldOffset(0x0000)] public short mShortcutIndex;                                                             //  (size: 0x2)
        [FieldOffset(0x0008)] public FString mName;                                                                    //  (size: 0x10)
        [FieldOffset(0x0018)] public bool mEnable;                                                                     //  (size: 0x1)

    }; // Size: 0x30

    [StructLayout(LayoutKind.Explicit, Size = 0xf0)]
    public struct FShortcutItem
    {
        [FieldOffset(0x0)] FFldShortcutData Data;                                                            // 0x0000 (size: 0x30)
    }; // Size: 0xF0

    [StructLayout(LayoutKind.Explicit, Size = 0x358)]
    public unsafe struct UUILocationSelect //: public UObject
    {
        [FieldOffset(0x0048)] public USprAsset* m_pMiniMapSpr;
        [FieldOffset(0x0050)] public UAssetLoader* m_pLoader;
        [FieldOffset(0x0058)] public FGetUIParameter m_tagUip;
        [FieldOffset(0x00D0)] public TArray<FShortcutItem> m_aShortcutList;
        [FieldOffset(0x0308)] public UDataTable* m_pLayoutData;
        [FieldOffset(0x0310)] public UUILayoutDataTable* m_pLayoutDataTable;
        [FieldOffset(0x0318)] public UDataTable* m_pLayoutData2;
        [FieldOffset(0x0320)] public UUILayoutDataTable* m_pLayoutDataTable2;

    }; // Size: 0x358
}