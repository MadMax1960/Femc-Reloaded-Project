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

        public static void Apply(Config config, string modDirectory)
        {
            ApplyBPBtlSkillList(config, modDirectory);
            ApplyBPBtlItemList(config, modDirectory);
            ApplyBattleResultUIBase(config, modDirectory);
            ApplyBPBtlGuiIcon(config, modDirectory);
            ApplyBPBtlGuiJyokyoHelp(config, modDirectory);
            ApplyBtlWaterCaustics(config, modDirectory);
        }
    }
}
