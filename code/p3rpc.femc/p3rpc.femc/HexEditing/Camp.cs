using p3rpc.commonmodutils;
using p3rpc.femc.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.HexEditing
{
    public static class CampCommon
    {
        public static void Apply(Config config, string modDirectory)
        {
            CampRoot.Apply(config, modDirectory);
            CampQuest.Apply(config, modDirectory);
            CampCalendar.Apply(config, modDirectory);
            CampConfiguration.Apply(config, modDirectory);
            CampStats.Apply(config, modDirectory);
            CampSystem.Apply(config, modDirectory);
            CampSkill.Apply(config, modDirectory);
        }
    }

    public static class CampRoot
    {
        private static void ApplyCampScreenshotFilter(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Camp", "Material", "CA_UI_CampColorCurve.uasset");

            long offset = 0x552;
            Dictionary<float, ConfigColor> colorKeyframes = new Dictionary<float, ConfigColor>();

            colorKeyframes.Add(0.0f, config.CampScreenshotFilterKeyframe1);
            colorKeyframes.Add(0.15f, config.CampScreenshotFilterKeyframe2);
            colorKeyframes.Add(0.357f, config.CampScreenshotFilterKeyframe3);
            colorKeyframes.Add(1.0f, config.CampScreenshotFilterKeyframe4);

            // There's 10 CRV_UI_Monochrome_00 included, we gotta edit all of them the same way
            for (int i = 0; i < 10; i++)
            {
                HexColorEditor.WriteColorCurve(filePath, offset, colorKeyframes);
                offset += 0x200; // All curve blocks included are 0x200 long
            }
        }

        private static void ApplyCampShards(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Camp", "Material", "CA_UI_CampColorCurve.uasset");

            // CRV_UI_CampHologram_00, shard colors in camp menu
            Dictionary<float, ConfigColor> colorKeyframes = new Dictionary<float, ConfigColor>();

            colorKeyframes.Add(0.0f, config.CampShardsKeyframe1);
            colorKeyframes.Add(0.1996f, config.CampShardsKeyframe2);
            colorKeyframes.Add(0.3601f, config.CampShardsKeyframe3);
            colorKeyframes.Add(0.5096f, config.CampShardsKeyframe4);
            colorKeyframes.Add(0.6389f, config.CampShardsKeyframe5);
            colorKeyframes.Add(0.7913f, config.CampShardsKeyframe6);
            colorKeyframes.Add(1.0f, config.CampShardsKeyframe7);

            HexColorEditor.WriteColorCurve(filePath, 0x1952, colorKeyframes);
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyCampScreenshotFilter(config, modDirectory);
            ApplyCampShards(config, modDirectory);
        }
    }

    public static class CampSkill
    {
        private static void ApplyMIGunColor(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0051", "Models", "MI_PC0051_C002_03_CaFiOp.uasset");

            HexColorEditor.ComponentType type = HexColorEditor.ComponentType.FLOAT;

            HexColorEditor.WriteColor(filePath, 0xA50, config.SkillGunColor, HexColorEditor.ColorOrder.RGBA, type); // Original color #566891
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyMIGunColor(config, modDirectory);
        }
    }

    public static class CampStats
    {
        private static void ApplyMIBackgroundShards(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0051", "Models", "MI_PC0051_C002_02_CaFiOp.uasset");

            HexColorEditor.ComponentType type = HexColorEditor.ComponentType.FLOAT;

            HexColorEditor.WriteColor(filePath, 0xA50, config.StatusShardsColor, HexColorEditor.ColorOrder.RGBA, type); // Original color #1B80FF
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyMIBackgroundShards(config, modDirectory);
        }
    }

    public static class CampQuest
    {
        private static void ApplyMIUICampQuestBG(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Camp", "Material", "Instance", "MI_UI_Camp_Quest_BG.uasset");

            HexColorEditor.ComponentType type = HexColorEditor.ComponentType.FLOAT;

            HexColorEditor.WriteColor(filePath, 0xCE6, config.QuestElizabethTopGradient1, HexColorEditor.ColorOrder.RGBA, type);
            HexColorEditor.WriteColor(filePath, 0xA92, config.QuestElizabethTopGradient2, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePath, 0xBBC, config.QuestElizabethBottomGradient, HexColorEditor.ColorOrder.RGB, type);
        }

        private static void ApplyMIBackgroundChairs(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0051", "Models", "MI_PC0051_C002_05_CaFiOp.uasset");

            HexColorEditor.ComponentType type = HexColorEditor.ComponentType.FLOAT;

            HexColorEditor.WriteColor(filePath, 0xA50, config.RequestChairsColor, HexColorEditor.ColorOrder.RGBA, type); // Original color #011E76
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyMIUICampQuestBG(config, modDirectory);
            ApplyMIBackgroundChairs(config, modDirectory);
        }
    }

    public static class CampCalendar
    {
        private static void ApplyDormitoryCalendarCurve(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Camp", "Material", "Curve", "CA_UI_Camp_Calendar.uasset");

            Dictionary<float, ConfigColor> colorKeyframes = new Dictionary<float, ConfigColor>();

            colorKeyframes.Add(0.0f, config.CampCalendarScreenshotFilterKeyframe1);
            colorKeyframes.Add(0.2f, config.CampCalendarScreenshotFilterKeyframe2);
            colorKeyframes.Add(0.8f, config.CampCalendarScreenshotFilterKeyframe3);
            colorKeyframes.Add(1.0f, config.CampCalendarScreenshotFilterKeyframe4);

            HexColorEditor.WriteColorCurve(filePath, 0x4BE, colorKeyframes);
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyDormitoryCalendarCurve(config, modDirectory);
        }
    }

    public static class CampConfiguration
    {
        private static void ApplyBPUIConfiguration(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "UI", "Configuration", "BP_UIConfiguration.uasset");

            HexColorEditor.ColorOrder order = HexColorEditor.ColorOrder.BGRA;
            // Updated to use BP_UIConfiguration from 1.0.10 (originally used 1.0.1 file)
            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.Read);
            HexColorEditor.WriteBlueprintByteColor(stream, 0xc275, config.CampConfigBgColor, order);
            HexColorEditor.WriteBlueprintByteColor(stream, 0x108c5, config.CampConfSelTexColor, order); // was 0xf87d (+ 0x1048)
            HexColorEditor.WriteBlueprintByteColor(stream, 0x15ed9, config.CampConfOptFmtBgColor, order); // was 0x145ad (+ 0x192c)
            HexColorEditor.WriteBlueprintByteColor(stream, 0x15f75, config.CampConfSelNameColor, order); // was 0x14649 (+ 0x192c)
            HexColorEditor.WriteBlueprintByteColor(stream, 0x15fa9, config.CampConfigControlSetInactive, order); // was 0x1467d (+ 0x192c)
            HexColorEditor.WriteBlueprintSplitColor(stream, 0x16341, config.CampConfigTopDescColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(stream, 0x1667d, config.CampConfigTopDescColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintByteColor(stream, 0x200a9, config.CampConfigOptionUnselectedArea, order);
            HexColorEditor.WriteBlueprintByteColor(stream, 0x200dd, config.CampConfigOptionUnselectedArea, order);
            HexColorEditor.WriteBlueprintByteColor(stream, 0x20111, config.CampConfigOptionUnselectedArea, order);
            HexColorEditor.WriteBlueprintByteColor(stream, 0x20145, config.CampConfigOptionUnselectedArea, order);
            HexColorEditor.WriteBlueprintByteColor(stream, 0x20179, config.CampConfigOptionUnselectedArea, order);
            HexColorEditor.WriteBlueprintByteColor(stream, 0x201e1, config.CampConfigOptionUnselectedArea, order);
            HexColorEditor.WriteBlueprintByteColor(stream, 0x22cad, config.CampConfigBooleanUnselectedArea, order);
            // HexColorEditor.WriteBlueprintSplitColor(stream, 0x2c4f3, config.CampConfig2C4F3, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(stream, 0x38587, config.CampConfigMusicPlayerGlow, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteColor(stream, 0x42f40, config.CampConfigurationLightReflectiveColor1, order); // was 0x40798
            HexColorEditor.WriteColor(stream, 0x42f75, config.CampConfigurationLightReflectiveColor2, order); // was 0x407cd
            HexColorEditor.WriteColor(stream, 0x456d2, config.CampHighlightedLowerColor, order); // was 0x42586
            var PlaylistTitleColorComp = new[] {
                config.CampConfigPlistHeadColor.B, config.CampConfigPlistHeadColor.G, config.CampConfigPlistHeadColor.R};
            for (var i = 0; i < 3; i++)
            {
                stream.Seek(0x4d817 + (0x22 * i), SeekOrigin.Begin);
                stream.WriteByte(PlaylistTitleColorComp[i]);
            }
        }

        private static void ApplyMainMenuConfigCurve(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Camp", "Material", "Curve", "CA_UI_Camp_Config.uasset");

            Dictionary<float, ConfigColor> colorKeyframes = new Dictionary<float, ConfigColor>();

            colorKeyframes.Add(0.0000f, config.CampMainMenuConfigScreenshotFilterKeyframe1);
            colorKeyframes.Add(0.5856f, config.CampMainMenuConfigScreenshotFilterKeyframe2);
            colorKeyframes.Add(0.7212f, config.CampMainMenuConfigScreenshotFilterKeyframe3);
            colorKeyframes.Add(1.0000f, config.CampMainMenuConfigScreenshotFilterKeyframe4);

            HexColorEditor.WriteColorCurve(filePath, 0x4B6, colorKeyframes);
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyBPUIConfiguration(config, modDirectory);
            ApplyMainMenuConfigCurve(config, modDirectory);
        }
    }

    public static class CampSystem
    {
        private static void ApplyMIFallingNine(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0051", "Models", "MI_PC0051_C002_06_CaFiOp.uasset");

            HexColorEditor.ComponentType type = HexColorEditor.ComponentType.FLOAT;

            HexColorEditor.WriteColor(filePath, 0xA50, config.FallingNineColor, HexColorEditor.ColorOrder.RGBA, type); // Original color #808CA3
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyMIFallingNine(config, modDirectory);
        }
    }
}
