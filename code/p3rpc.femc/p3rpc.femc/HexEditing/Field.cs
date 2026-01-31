using p3rpc.femc.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.HexEditing
{
    public static class Field
    {
        private static void ApplyMaleQuest(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_MaleQuest_Field_00.uasset");

            HexColorEditor.WriteColor(filePath, 0xDE2, config.AccessIconColor1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #020318
            HexColorEditor.WriteColor(filePath, 0xCB8, config.AccessIconColor2, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #0077B3

            filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_MaleQuest_Field_01.uasset");

            HexColorEditor.WriteColor(filePath, 0xA74, config.AccessIconColor3, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #010183

            filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_MaleQuest_00.uasset");

            HexColorEditor.WriteColor(filePath, 0xDCA, config.AccessIconColor1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #020318
            HexColorEditor.WriteColor(filePath, 0xCA0, config.AccessIconColor2, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #0077B3

            filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_MaleQuest_01.uasset");

            HexColorEditor.WriteColor(filePath, 0xB4C, config.AccessIconColor3, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #010183
        }

        private static void ApplyWalking(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_Walking_00.uasset");

            HexColorEditor.WriteColor(filePath, 0xD86, config.AccessIconColor1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #020318
            HexColorEditor.WriteColor(filePath, 0xC5C, config.AccessIconColor2, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #0077B3

            filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_Walking_01.uasset");

            HexColorEditor.WriteColor(filePath, 0xACC, config.AccessIconColor3, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #010183
        }

        // this really shouldnt be here but whatever

        private static void ApplyMBUIBustupUniverse(Config config, string modDirectory)
        {
            // this should not be here oops
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Common", "2d", "BaseMaterials", "MB_UI_BustupUniverse.uasset");

            HexColorEditor.WriteColor(filePath, 0x113A, config.BustupUniverseAmbientColor, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);
            HexColorEditor.WriteColor(filePath, 0x1264, config.BustupUniverseLightColor, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);
            /*
            string filePathYko = Path.Combine(modDirectory,
               "UnrealEssentials", "P3R", "Content", "Xrd777",
               "UI", "Common", "2d", "BaseMaterials", "MB_UI_BustupUniverseYko.uasset");

            HexColorEditor.WriteColor(filePath, 0x1294, config.BustupUniverseAmbientColorYko, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);
            HexColorEditor.WriteColor(filePath, 0x13be, config.BustupUniverseLightColorYko, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);
            */
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyMaleQuest(config, modDirectory);
            ApplyWalking(config, modDirectory);
            ApplyMBUIBustupUniverse(config, modDirectory);
        }
    }
}
