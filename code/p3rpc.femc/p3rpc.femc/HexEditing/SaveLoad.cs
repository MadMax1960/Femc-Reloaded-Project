using p3rpc.commonmodutils;
using p3rpc.femc.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.HexEditing
{
    public static class SaveLoad
    {
        private static void ApplySaveLoadScreenshotFilter(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "SaveLoad", "Curve", "CA_UI_SaveLoad.uasset");

            Dictionary<float, ConfigColor> colorKeyFrames = new Dictionary<float, ConfigColor>();

            colorKeyFrames.Add(0.0f, config.SaveLoadScreenshotFilterKeyframe1);
            colorKeyFrames.Add(0.4f, config.SaveLoadScreenshotFilterKeyframe2);
            colorKeyFrames.Add(1.0f, config.SaveLoadScreenshotFilterKeyframe3);

            HexColorEditor.WriteColorCurve(filePath, 0x4a6, colorKeyFrames);
        }

        private static void ApplyBPSaveLoadDraw(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "UI", "SaveLoad", "BP_SaveLoadDraw.uasset");

            HexColorEditor.ColorOrder order = HexColorEditor.ColorOrder.BGRA;

            HexColorEditor.WriteColor(filePath, 0x41299, config.SaveLoadSlotBox, order);
            HexColorEditor.WriteColor(filePath, 0x412CE, config.SaveLoadSlotBox, order);
            HexColorEditor.WriteColor(filePath, 0x41d2a, config.SaveLoadHighlightedOption, order);
            HexColorEditor.WriteColor(filePath, 0x41686, config.SaveLoadSlotBox, order);

            HexColorEditor.WriteColor(filePath, 0x41bf4, config.SaveLoadGradientBottomTopColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteColor(filePath, 0x41c29, config.SaveLoadGradientBottomColor, order);
            HexColorEditor.WriteColor(filePath, 0x41c5e, config.SaveLoadGradientTopColor, order);
            HexColorEditor.WriteColor(filePath, 0x41c93, config.SaveLoadGradientTopBottomColor, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xF491, config.SaveLoadAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xF918, config.SaveLoadAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x121FC, config.SaveLoadAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x12751, config.SaveLoadAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x12884, config.SaveLoadAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x13D2B, config.SaveLoadAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x14D28, config.SaveLoadAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x16624, config.SaveLoadAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x17096, config.SaveLoadAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x176E1, config.SaveLoadAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x17EF6, config.SaveLoadAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x18A7C, config.SaveLoadAccentColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1A227, config.SaveLoadAccentColor, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xF6D4, config.SaveLoadSlotBox, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xFBAB, config.SaveLoadSlotBox, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xFDFA, config.SaveLoadSlotBox, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x18BA3, config.SaveLoadSlotBox, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x34EFE, config.SaveLoadSlotBox, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x982B, config.SaveLoadCornerTriangle, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x15837, config.SaveLoadUnhighlightedNumber, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x15AAE, config.SaveLoadUnhighlightedNumber, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1BEB5, config.SaveLoadSelectedSlotBox, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1C5E9, config.SaveLoadSelectedSlotBox, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1D40A, config.SaveLoadSelectedSlotBox, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1D80B, config.SaveLoadSelectedSlotBox, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1D9EF, config.SaveLoadSelectedSlotBox, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x201CD, config.SaveLoadSelectedSlotBox, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x20910, config.SaveLoadSelectedSlotBox, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x20CAF, config.SaveLoadSelectedSlotBox, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x21084, config.SaveLoadSelectedSlotBox, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x21555, config.SaveLoadSelectedSlotBox, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintByteColor(filePath, 0xD8DA, config.SaveLoadSlotBox, HexColorEditor.ColorOrder.RGB);
            HexColorEditor.WriteBlueprintByteColor(filePath, 0xDA1D, config.SaveLoadSlotBox, HexColorEditor.ColorOrder.RGB);
            HexColorEditor.WriteBlueprintByteColor(filePath, 0xDB16, config.SaveLoadSlotBox, HexColorEditor.ColorOrder.RGB);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x10859, config.SaveLoadGrey, HexColorEditor.ColorOrder.BGR);


        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplySaveLoadScreenshotFilter(config, modDirectory);
            ApplyBPSaveLoadDraw(config, modDirectory);
        }
    }
}
