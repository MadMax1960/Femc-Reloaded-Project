using p3rpc.commonmodutils;
using p3rpc.femc.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.HexEditing
{
    public static class Battle
    {
        /*
        private static void ApplyBattleResultUIBase(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "Battle", "GUI", "BP_BtlResultUIBase.uasset");

            HexColorEditor.ColorOrder order = HexColorEditor.ColorOrder.BGRA;

            HexColorEditor.WriteColor(filePath, 0x71294, config.BattleResultLeftSquare, order);
            HexColorEditor.WriteColor(filePath, 0x7139D, config.BattleResultFontColor, order);
            HexColorEditor.WriteColor(filePath, 0x713D2, config.BattleResultLeftZeroFontColor, order);
        }
        */
        private static void ApplyBPBtlResultUIBase(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "Battle", "GUI", "BP_BtlResultUIBase.uasset");

            // Left square color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x333C6, config.BtlResultLvlUpLeftSquareColor); // Original color #000679 - old offset 0x319b1

            // Large strip color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2AC53, config.BtlResultLvlUpLargeStripColor); // Original color #10a2ff - old offset 0x29837
            /*
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2A572, config.BtlResultLvlUpLargeStripColor);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2CC23, config.BtlResultLvlUpLargeStripColor);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2E024, config.BtlResultLvlUpLargeStripColor);
            */
            HexColorEditor.WriteColor(filePath, 0x7348C, config.BtlResultLvlUpTopExpBGColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteColor(filePath, 0x73595, config.BtlResultLvlUpTopItemNumColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteColor(filePath, 0x735CA, config.BtlResultLvlUpTopItemNumColorDark, HexColorEditor.ColorOrder.BGR);

            // Large strip shadow color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2A415, config.BtlResultLvlUpLargeStripShadowColor, HexColorEditor.ColorOrder.BGR); // Original color #05073E - old offset 28FF9

            // Short strip color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x3AE05, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR); // Original color #002380 - reworked offsets
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x3B299, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x40EA7, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4BEB4, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4C376, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4D235, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4D822, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4DE84, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4E528, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4EC25, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4F2DF, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x566F9, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x57207, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x57C85, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x58656, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5A9D6, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);

            // Item Number color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x25395, config.BtlResultLvlUpItemFontColor); // Original color #28B29D - old offset 0x2468E
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x33C45, config.BtlResultLvlUpItemFontColor);

            // Item left 0 number color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x33D9A, config.BtlResultLvlUpItemZeroFontColor); // Original color #1461A1 - old offset 0x32385

            // Special femc character level up screen persona arcana font colors
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4F987, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR); // Original color #0a73d0 - old offset 0x4DCC7
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4FFAA, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x502F5, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5076E, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x50DFE, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5C874, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5CEA9, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5D6C9, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5DB59, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5E130, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);

            // Special femc character level up screen persona silhouette
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x51095, config.BtlResultFemcLvlUpPersonaSilhouetteColor, HexColorEditor.ColorOrder.BGR); // Original color #00045f - old offset 0x4F3D5
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5E80C, config.BtlResultFemcLvlUpPersonaSilhouetteColor, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1CB88, config.BtlResultLvlUpParallelogram, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1D407, config.BtlResultLvlUpParallelogram, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1DBED, config.BtlResultLvlUpParallelogram, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x232D4, config.BtlResultLvlUpParallelogram, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xE5C1, config.BtlResultLvlUpBgPanel, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x12EAF, config.BtlResultLvlUpBgPanel, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1AD4F, config.BtlResultLvlUpBgPanel, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1A50E, config.BtlResultLvlUpBgBehindPanel, HexColorEditor.ColorOrder.BGR);

            // fuck it got updated i think
        }

        private static void ApplyBPBtlSkillList(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "Battle", "GUI", "BP_BtlSkillList.uasset");
            // updated file
            // Selection color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x3EAFE, config.BtlHighlightedColor, HexColorEditor.ColorOrder.BGR); // Original color #FF0000

            // Left arrow color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x436C6, config.BtlHighlightedColor, HexColorEditor.ColorOrder.BGR); // Original color #FF0000

            // Right arrow color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x43CF1, config.BtlHighlightedColor, HexColorEditor.ColorOrder.BGR); // Original color #FF0000

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x24D85, config.BtlSkillListAccentColor, HexColorEditor.ColorOrder.BGR); // 0x00FFFF
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2698C, config.BtlSkillListAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x26F7F, config.BtlSkillListAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x27572, config.BtlSkillListAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x28791, config.BtlSkillListAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x28D8A, config.BtlSkillListAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2924E, config.BtlSkillListAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x29712, config.BtlSkillListAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x307A5, config.BtlSkillListAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x334B0, config.BtlSkillListAccentColor, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x28198, config.BtlSkillListUnk1, HexColorEditor.ColorOrder.BGR); // info glow
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x29BD6, config.BtlSkillListUnk2, HexColorEditor.ColorOrder.BGR); // 

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x38B19, config.BtlSkillListUnk3, HexColorEditor.ColorOrder.BGR);// bg 1
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x38C26, config.BtlSkillListUnk4, HexColorEditor.ColorOrder.BGR); // bg2
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x3B249, config.BtlSkillListUnk5, HexColorEditor.ColorOrder.BGR); // persona silhouette off bg
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x3CDE4, config.BtlSkillListUnk6, HexColorEditor.ColorOrder.BGR); // persona silhouette bg 1
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x3D3CE, config.BtlSkillListUnk7, HexColorEditor.ColorOrder.BGR); // 2
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x3F647, config.BtlSkillListUnk8, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x3FF74, config.BtlSkillListUnk9, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x40086, config.BtlSkillListUnk10, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.ComponentType type = HexColorEditor.ComponentType.FLOAT;

            HexColorEditor.WriteBlueprintFloatColor(filePath, 0x45861, config.BtlSkillListModelColor, HexColorEditor.ColorOrder.RGB);
        }

        private static void ApplyBPBtlItemList(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "Battle", "GUI", "BP_BtlItemList.uasset");

            // Selection color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x137CE, config.BtlHighlightedColor, HexColorEditor.ColorOrder.BGR); // Original color #FF0000
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1E2A6, config.BtlHighlightedColor, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xEF0E, config.BtlItemList1, HexColorEditor.ColorOrder.BGR); // unk

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xF6DE, config.BtlItemList2, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x24541, config.BtlItemList2, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xFC01, config.BtlItemList3, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xFD22, config.BtlItemList4, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x11A4C, config.BtlItemList5, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2104A, config.BtlItemList5, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x24205, config.BtlItemList5, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x12236, config.BtlItemListAccent, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x126C8, config.BtlItemListAccent, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x12B5A, config.BtlItemListAccent, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x12FED, config.BtlItemListAccent, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1FBEB, config.BtlItemListAccent, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1FF8C, config.BtlItemListAccent, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x20487, config.BtlItemListAccent, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x20982, config.BtlItemListAccent, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2628A, config.BtlItemListAccent, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteColor(filePath, 0x2C23E, config.BtlItemModelDarkColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteColor(filePath, 0x2C273, config.BtlItemModelLightColor, HexColorEditor.ColorOrder.BGR);
        }

        private static void ApplyBPBtlGuiIcon(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "Battle", "GUI", "BP_BtlGuiIcon.uasset");

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x18470, config.PartyMemberSilhouetteSelectionColor); // Original color #00B6F9
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x14B6B, config.PartyMemberSilhouetteSelectionColor);
        }

        private static void ApplyBPBtlGuiJyokyoHelp(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "Battle", "GUI", "Icon", "BP_BtlGuiJyokyoHelp.uasset");

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xEAAC, config.JyokyoHelpUnkColor1); // Original color #2D35FF
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xEECA, config.JyokyoHelpUnkColor1);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xFFDA, config.JyokyoHelpWindowIn1); // Original color #121423, alpha 0xE5

            HexColorEditor.WriteColor(filePath, 0x130ED, config.JyokyoHelpWindowOut, HexColorEditor.ColorOrder.BGRA); // Original color #30334B
            HexColorEditor.WriteColor(filePath, 0x1318C, config.JyokyoHelpWindowOut, HexColorEditor.ColorOrder.BGRA);

            HexColorEditor.WriteColor(filePath, 0x13122, config.JyokyoHelpWindowIn2, HexColorEditor.ColorOrder.BGRA); // Original color #121423, aplha 0xBF
            HexColorEditor.WriteColor(filePath, 0x13157, config.JyokyoHelpColorGradation, HexColorEditor.ColorOrder.BGRA); // Original color #262840, aplha 0x66
        }

        private static void ApplyBtlWaterCaustics(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Common", "2D", "BaseMaterials", "MB_UI_2D_Caustics_01.uasset"); // Guard water caustics

            // Original components (other than alpha) go from 0.0 - 9.0, we have to normalize values and convert them to 9.0 max
            HexColorEditor.WriteFloat(filePath, 0x1988, ((float)config.BtlWaterCausticColor.R / 255.0f) * 9.0f); // Original color (normalized to 0-1 per component) #0070FF
            HexColorEditor.WriteFloat(filePath, 0x198C, ((float)config.BtlWaterCausticColor.G / 255.0f) * 9.0f);
            HexColorEditor.WriteFloat(filePath, 0x1990, ((float)config.BtlWaterCausticColor.B / 255.0f) * 9.0f);
            HexColorEditor.WriteFloat(filePath, 0x1994, (float)config.BtlWaterCausticColor.A / 255.0f);

            filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Common", "2D", "BaseMaterials", "MB_UI_2D_Caustics_02.uasset"); // Skill/Item list water caustics

            // Same applies for these caustics, we gotta convert them to 9.0 max
            HexColorEditor.WriteFloat(filePath, 0x1988, ((float)config.BtlWaterCausticColor.R / 255.0f) * 9.0f); // Original color (normalized to 0-1 per component) #0070FF
            HexColorEditor.WriteFloat(filePath, 0x198C, ((float)config.BtlWaterCausticColor.G / 255.0f) * 9.0f);
            HexColorEditor.WriteFloat(filePath, 0x1990, ((float)config.BtlWaterCausticColor.B / 255.0f) * 9.0f);
            HexColorEditor.WriteFloat(filePath, 0x1994, (float)config.BtlWaterCausticColor.A / 255.0f);
        }

        private static void ApplyBPBtlShuffleUI(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "Battle", "GUI", "BP_BtlShuffleUI.uasset");

            // Card type font color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2374B, config.ShuffleCardTypeFontColor); // Original color #00036D
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x364E0, config.ShuffleCardTypeFontColor);

            // Card type rectangle color and owned rhomb
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x23AFF, config.ShuffleCardTypeAndRhomb); // Original color #3BFFEA
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x25A22, config.ShuffleCardTypeAndRhomb);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x36120, config.ShuffleCardTypeAndRhomb);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x37C1A, config.ShuffleCardTypeAndRhomb);

            // Owned font color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x25D8D, config.ShuffleOwnedFontColor); // Original color #000394
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x38054, config.ShuffleOwnedFontColor);

            // Owned count number font color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x261CF, config.ShuffleOwnedCountFontColor); // Original color #000294
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x3FF2E, config.ShuffleOwnedCountFontColor);
            HexColorEditor.WriteFloat(filePath, 0x4002E, config.ShuffleOwnedCountFontColor.R); // Fade transition into left zero font color
            HexColorEditor.WriteFloat(filePath, 0x400AA, config.ShuffleOwnedCountFontColor.G);
            HexColorEditor.WriteFloat(filePath, 0x4015F, config.ShuffleOwnedCountFontColor.B);

            // Owned count number left zero font color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x3FE22, config.ShuffleOwnedLeftZeroFontColor); // Original color #32D9DD
            HexColorEditor.WriteFloat(filePath, 0x40033, config.ShuffleOwnedLeftZeroFontColor.R); // Fade transition from normal count font color
            HexColorEditor.WriteFloat(filePath, 0x400AF, config.ShuffleOwnedLeftZeroFontColor.G);
            HexColorEditor.WriteFloat(filePath, 0x40164, config.ShuffleOwnedLeftZeroFontColor.B);

            // Big background cards 1
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x26A95, config.ShuffleBigBGCardsColor1); // Original color #004EFF
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2DA3E, config.ShuffleBigBGCardsColor1);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x38B5D, config.ShuffleBigBGCardsColor1);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x3C9A9, config.ShuffleBigBGCardsColor1);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5AC00, config.ShuffleBigBGCardsColor1);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5B269, config.ShuffleBigBGCardsColor1);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5B8D2, config.ShuffleBigBGCardsColor1);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x67652, config.ShuffleBigBGCardsColor1);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x26E79, config.ShuffleUnkColor1); // Original color #0072FF
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x38F97, config.ShuffleUnkColor1);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x28728, config.ShuffleUnkColor2); // Original color #2F4DFF

            // Arcana symbol in right down corner
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2A3F7, config.ShuffleArcanaSymbolColor); // Original color #0352AB
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x34698, config.ShuffleArcanaSymbolColor);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x355C5, config.ShuffleArcanaSymbolColor);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2D6C7, config.ShuffleUnkColor3); // Original color #0090FF
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x3C3A7, config.ShuffleUnkColor3);

            // Persona overstock background color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x43963, config.ShufflePersonaOverstockBG, HexColorEditor.ColorOrder.BGR); // Original color #0006F1
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x43ECB, config.ShufflePersonaOverstockBG, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x44282, config.ShuffleUnkColor4); // Original color #001BE5
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x44672, config.ShuffleUnkColor4);

            // Down gradient color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x57E37, config.ShuffleDownGradient, HexColorEditor.ColorOrder.BGR); // Original color #027CFF
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x68690, config.ShuffleDownGradient, HexColorEditor.ColorOrder.BGR);

            // Down gradient overlay when selecting arcana color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5882B, config.ShuffleDownGradientArcanaSelection); // Original color #0C1C94
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x58F34, config.ShuffleDownGradientArcanaSelection);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5C567, config.ShuffleDownGradientArcanaSelection);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5CC70, config.ShuffleDownGradientArcanaSelection);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x65B32, config.ShuffleDownGradientArcanaSelection);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x661CE, config.ShuffleDownGradientArcanaSelection);

            // Big background cards 2
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x59519, config.ShuffleBigBGCardsColor2); // Original color #0036FF
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x59B82, config.ShuffleBigBGCardsColor2);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x67478, config.ShuffleBigBGCardsColor2);

            // Top gradient and background cards taint
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5A47E, config.ShuffleTopGradientAndCardsTaint); // Original color #002BFB
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x682BB, config.ShuffleTopGradientAndCardsTaint);

            // Shuffle time title underlay color 1
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5D922, config.ShuffleTitleUnderlayColor1); // Original color #0033FF
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5E568, config.ShuffleTitleUnderlayColor1);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x602ED, config.ShuffleTitleUnderlayColor1);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x648DE, config.ShuffleTitleUnderlayColor1);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x64F6A, config.ShuffleTitleUnderlayColor1);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x655F6, config.ShuffleTitleUnderlayColor1);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5DF45, config.ShuffleUnkColor5); // Original color #0088FF
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5EB8B, config.ShuffleUnkColor5);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x64C24, config.ShuffleUnkColor5);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x652B0, config.ShuffleUnkColor5);

            // Shuffle time title underlay color 2
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5F1AF, config.ShuffleTitleUnderlayColor2); // Original color #0028AB
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5F788, config.ShuffleTitleUnderlayColor2);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x64252, config.ShuffleTitleUnderlayColor2);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x64598, config.ShuffleTitleUnderlayColor2);

            // Shuffle time title font color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5FD61, config.ShuffleTitleFontColor, HexColorEditor.ColorOrder.BGR); // Original color #001998
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x6404F, config.ShuffleTitleFontColor, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x6678C, config.ShuffleUnkColor6); // Original color #000B77
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x66D56, config.ShuffleUnkColor6);

            // Persona overstock title - We gotta convert colors to linear colors so they get converted later to sRGB correctly
            HexColorEditor.WriteFloat(filePath, 0x76117, (float)Math.Pow(config.OverstockTitleColor.R / 255.0, 2.2)); // Original color #005bf4
            HexColorEditor.WriteFloat(filePath, 0x761DC, (float)Math.Pow(config.OverstockTitleColor.G / 255.0, 2.2));
            HexColorEditor.WriteFloat(filePath, 0x762A1, (float)Math.Pow(config.OverstockTitleColor.B / 255.0, 2.2));
        }

        private static void ApplyShiftColors(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Effects", "Niagara", "Battle", "ShiftFrom00ShiftTo00_P.ucas");

            // ShiftFrom_00 -> first animation file
            HexColorEditor.WriteFloat(filePath, 0x15793, config.ShiftFromColor.R / 255.0f);
            HexColorEditor.WriteFloat(filePath, 0x157B3, config.ShiftFromColor.G / 255.0f);
            HexColorEditor.WriteFloat(filePath, 0x157B7, config.ShiftFromColor.B / 255.0f);

            // ShiftTo_00 -> second animation file
            HexColorEditor.WriteFloat(filePath, 0x5980, config.ShiftToMiddleColor.R / 255.0f);
            HexColorEditor.WriteFloat(filePath, 0x59B4, config.ShiftToMiddleColor.G / 255.0f);
            HexColorEditor.WriteFloat(filePath, 0x59BC, config.ShiftToMiddleColor.B / 255.0f);

            HexColorEditor.WriteFloat(filePath, 0x5984, config.ShiftToUpDownColor.R / 255.0f);
            HexColorEditor.WriteFloat(filePath, 0x59B8, config.ShiftToUpDownColor.G / 255.0f);
            HexColorEditor.WriteFloat(filePath, 0x59C0, config.ShiftToUpDownColor.B / 255.0f);
        }

        private static void ApplyBPBtlFadeManager(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "Battle", "GUI", "BP_BtlFadeManager.uasset");


            HexColorEditor.ColorOrder order = HexColorEditor.ColorOrder.BGR;
            //mostly unknown
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xCC80, config.FadeManager1, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xCD54, config.FadeManager2, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xCFA7, config.FadeManager3, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xD07B, config.FadeManager4, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x10A2F, config.FadeManager5, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x10F53, config.FadeManager3, order);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x127C6, config.FadeManager6, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1306C, config.FadeManager6, order);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1177C, config.FadeManager7, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1229F, config.FadeManager7, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x12CED, config.FadeManager7, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1177C, config.FadeManager7, order);
        }

        private static void ApplyBPBtlGuard(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "Battle", "GUI", "BP_BtlGuard.uasset");


            HexColorEditor.ColorOrder order = HexColorEditor.ColorOrder.BGR;
            //mostly unknown
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xCFF9, config.BtlGuardTopLeftText, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xD789, config.BtlGuardTopLeftText, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xDF89, config.BtlGuardTopLeftText, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xE719, config.BtlGuardTopLeftText, order);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xEF0D, config.BtlGuardBottomRightText, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xF69D, config.BtlGuardBottomRightText, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xFEC3, config.BtlGuardBottomRightText, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x10691, config.BtlGuardBottomRightText, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x10F33, config.BtlGuardBottomRightText, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1173F, config.BtlGuardBottomRightText, order);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x193AC, config.BtlGuardMisc, order);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x19596, config.BtlGuardTopLeftBG, order);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1A12D, config.BtlGuardBottomRightBG, order);
        }

        private static void ApplyBtlGuiEncountWipe(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "Battle", "GUI", "BP_BtlGuiEncountWipe.uasset");


            HexColorEditor.ColorOrder order = HexColorEditor.ColorOrder.BGR;
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x9B84, config.BtlEncountWipe, order);
        }
        private static void ApplyBtlPromiseCommon(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "Battle", "GUI", "BP_BtlPromiseCommon.uasset");

            // prommy
            HexColorEditor.ColorOrder order = HexColorEditor.ColorOrder.BGR;
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x7CDF, config.BtlPromiseCommon1, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xAD06, config.BtlPromiseCommon1, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xC280, config.BtlPromiseCommon1, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xC6F1, config.BtlPromiseCommon1, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xCFE5, config.BtlPromiseCommon1, order);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x81DD, config.BtlPromiseCommon2, order);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x880E, config.BtlPromiseCommonHighlight, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x9AE7, config.BtlPromiseCommonHighlight, order);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x8CCF, config.BtlPromiseCommon3, order);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x9FF2, config.BtlPromiseCommon3, order);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xB368, config.BtlPromiseCommon4, order);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xB94B, config.BtlPromiseCommon5, order);

        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyBPBtlSkillList(config, modDirectory);
            ApplyBPBtlItemList(config, modDirectory);
            //ApplyBattleResultUIBase(config, modDirectory);
            ApplyBPBtlGuiIcon(config, modDirectory);
            ApplyBPBtlGuiJyokyoHelp(config, modDirectory);
            ApplyBtlWaterCaustics(config, modDirectory);
            ApplyBPBtlResultUIBase(config, modDirectory);
            ApplyBPBtlShuffleUI(config, modDirectory);
            ApplyShiftColors(config, modDirectory);
            ApplyBPBtlFadeManager(config, modDirectory);
            ApplyBPBtlGuard(config, modDirectory);
            ApplyBtlGuiEncountWipe(config, modDirectory);
            ApplyBtlPromiseCommon(config, modDirectory);
        }
    }
}
