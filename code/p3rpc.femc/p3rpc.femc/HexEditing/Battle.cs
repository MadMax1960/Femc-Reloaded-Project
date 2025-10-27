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

        private static void ApplyBPBtlResultUIBase(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "Battle", "GUI", "BP_BtlResultUIBase.uasset");

            // Left square color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x319B1, config.BtlResultLvlUpLeftSquareColor); // Original color #000679

            // Large strip color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x29837, config.BtlResultLvlUpLargeStripColor); // Original color #10a2ff
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2A572, config.BtlResultLvlUpLargeStripColor);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2CC23, config.BtlResultLvlUpLargeStripColor);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2E024, config.BtlResultLvlUpLargeStripColor);

            // Large strip shadow color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x28FF9, config.BtlResultLvlUpLargeStripShadowColor, HexColorEditor.ColorOrder.BGR); // Original color #05073E

            // Short strip color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x3F1E7, config.BtlResultLvlUpShortStripColor); // Original color #002380
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x436A0, config.BtlResultLvlUpShortStripColor);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x54A39, config.BtlResultLvlUpShortStripColor);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x39145, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x395D9, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4A1F4, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4A6B6, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4B575, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4BB62, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4C1C4, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4C868, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4CF65, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4D61F, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x55547, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x55FC5, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x56996, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x58D16, config.BtlResultLvlUpShortStripColor, HexColorEditor.ColorOrder.BGR);

            // Item Number color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x2468E, config.BtlResultLvlUpItemFontColor); // Original color #28BD9D
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x32230, config.BtlResultLvlUpItemFontColor);

            // Item left 0 number color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x32385, config.BtlResultLvlUpItemZeroFontColor); // Original color #1461A1

            // Special femc character level up screen persona arcana font colors
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4DCC7, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR); // Original color #0a73d0
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4E2EA, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR); 
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4E635, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4EAAE, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4F13E, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5ABB4, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5B1E9, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5BA09, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5BE99, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5C470, config.BtlResultFemcLvlUpPersonaInfoFont, HexColorEditor.ColorOrder.BGR);

            // Special femc character level up screen persona silhouette
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x4F3D5, config.BtlResultFemcLvlUpPersonaSilhouetteColor, HexColorEditor.ColorOrder.BGR); // Original color #00045f
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x5CB4C, config.BtlResultFemcLvlUpPersonaSilhouetteColor, HexColorEditor.ColorOrder.BGR);
        }

        private static void ApplyBPBtlSkillList(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "Battle", "GUI", "BP_BtlSkillList.uasset");

            // Selection color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x3E92D, config.BtlHighlightedColor); // Original color #FF0000

            // Left arrow color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x434F5, config.BtlHighlightedColor); // Original color #FF0000

            // Right arrow color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x43B20, config.BtlHighlightedColor); // Original color #FF0000
        }

        private static void ApplyBPBtlItemList(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "Battle", "GUI", "BP_BtlItemList.uasset");

            // Selection color
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x137CE, config.BtlHighlightedColor, HexColorEditor.ColorOrder.BGR); // Original color #FF0000
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1E2A6, config.BtlHighlightedColor, HexColorEditor.ColorOrder.BGR);
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
            HexColorEditor.WriteFloat(filePath, 0x1988, ((float) config.BtlWaterCausticColor.R / 255.0f) * 9.0f); // Original color (normalized to 0-1 per component) #0070FF
            HexColorEditor.WriteFloat(filePath, 0x198C, ((float) config.BtlWaterCausticColor.G / 255.0f) * 9.0f);
            HexColorEditor.WriteFloat(filePath, 0x1990, ((float) config.BtlWaterCausticColor.B / 255.0f) * 9.0f);
            HexColorEditor.WriteFloat(filePath, 0x1994, (float) config.BtlWaterCausticColor.A / 255.0f);

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
            HexColorEditor.WriteFloat(filePath, 0x76117, (float) Math.Pow(config.OverstockTitleColor.R / 255.0, 2.2)); // Original color #005bf4
            HexColorEditor.WriteFloat(filePath, 0x761DC, (float) Math.Pow(config.OverstockTitleColor.G / 255.0, 2.2));
            HexColorEditor.WriteFloat(filePath, 0x762A1, (float) Math.Pow(config.OverstockTitleColor.B / 255.0, 2.2));
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

        public static void Apply(Config config, string modDirectory)
        {
            ApplyBPBtlSkillList(config, modDirectory);
            ApplyBPBtlItemList(config, modDirectory);
            ApplyBattleResultUIBase(config, modDirectory);
            ApplyBPBtlGuiIcon(config, modDirectory);
            ApplyBPBtlGuiJyokyoHelp(config, modDirectory);
            ApplyBtlWaterCaustics(config, modDirectory);
            ApplyBPBtlResultUIBase(config, modDirectory);
            ApplyBPBtlShuffleUI(config, modDirectory);
            ApplyShiftColors(config, modDirectory);
        }
    }
}
