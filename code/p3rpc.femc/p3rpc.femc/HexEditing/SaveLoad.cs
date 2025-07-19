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

            HexColorEditor.WriteColor(filePath, 0x3BA9B, config.SaveLoadGradientBottomTopColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteColor(filePath, 0x3BA66, config.SaveLoadGradientBottomColor, order);
            HexColorEditor.WriteColor(filePath, 0x3BA31, config.SaveLoadGradientTopColor, order);
            HexColorEditor.WriteColor(filePath, 0x3B9FC, config.SaveLoadGradientTopBottomColor, HexColorEditor.ColorOrder.BGR);
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplySaveLoadScreenshotFilter(config, modDirectory);
            ApplyBPSaveLoadDraw(config, modDirectory);
        }
    }
}
