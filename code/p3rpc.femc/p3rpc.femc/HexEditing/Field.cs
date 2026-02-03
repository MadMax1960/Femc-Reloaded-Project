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

        private static void ApplyQuest(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_Quest_00.uasset");

            HexColorEditor.WriteColor(filePath, 0xC54, config.AccessIconColor1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #020318
            HexColorEditor.WriteColor(filePath, 0xD7E, config.AccessIconColor2, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #0077B3

            filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_Quest_01.uasset");

            HexColorEditor.WriteColor(filePath, 0xABC, config.AccessIconColor3, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #010183
        }

        private static void ApplyStudy(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_StudyGroup_00.uasset");

            HexColorEditor.WriteColor(filePath, 0xC64, config.AccessIconColor1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #020318
            HexColorEditor.WriteColor(filePath, 0xD8E, config.AccessIconColor2, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #0077B3

            filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_StudyGroup_01.uasset");

            HexColorEditor.WriteColor(filePath, 0xADC, config.AccessIconColor3, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #010183
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

        private static void ApplyAccessIconTalk(Config config, string modDirectory)
        {
            string filePath00 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_Talk_00.uasset");

            HexColorEditor.WriteColor(filePath00, 0xC4C, config.AccessIconTalk00Color1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);
            HexColorEditor.WriteColor(filePath00, 0xD76, config.AccessIconTalk00Color2, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);

            string filePath01 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_Talk_01.uasset");

            HexColorEditor.WriteColor(filePath01, 0xC34, config.AccessIconTalk01Color1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);

            string filePath02 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_Talk_02.uasset");

            HexColorEditor.WriteColor(filePath02, 0xB36, config.AccessIconTalk02Color1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);
        }

        private static void ApplyAccessIconListen(Config config, string modDirectory)
        {
            string filePath0000 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_Listen_00_00.uasset");

            HexColorEditor.WriteColor(filePath0000, 0xE90, config.AccessIconTalk00Color1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);
            HexColorEditor.WriteColor(filePath0000, 0xFBA, config.AccessIconTalk00Color2, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);

            string filePath0001 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_Listen_00_01.uasset");

            HexColorEditor.WriteColor(filePath0001, 0xE90, config.AccessIconTalk00Color1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);
            HexColorEditor.WriteColor(filePath0001, 0xFBA, config.AccessIconTalk00Color2, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);

            string filePath0002 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_Listen_00_02.uasset");

            HexColorEditor.WriteColor(filePath0002, 0xE90, config.AccessIconTalk00Color1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);
            HexColorEditor.WriteColor(filePath0002, 0xFBA, config.AccessIconTalk00Color2, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);


            string filePath0100 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_Listen_01_00.uasset");

            HexColorEditor.WriteColor(filePath0100, 0xA20, config.AccessIconTalk01Color1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);

            string filePath0101 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_Listen_01_01.uasset");

            HexColorEditor.WriteColor(filePath0101, 0xA20, config.AccessIconTalk01Color1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);

            string filePath0102 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_Listen_01_02.uasset");

            HexColorEditor.WriteColor(filePath0102, 0xA20, config.AccessIconTalk01Color1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);
        }

        private static void ApplyDormitoryLife(Config config, string modDirectory)
        {
            string filePath00 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_DormitoryLife_00.uasset");

            HexColorEditor.WriteColor(filePath00, 0xC74, config.AccessIconColor1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);
            HexColorEditor.WriteColor(filePath00, 0xD9E, config.AccessIconColor2, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);

            string filePath01 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Field", "AccessIcon", "Materials", "MI_UI_AccessIcon_DormitoryLife_01.uasset");

            HexColorEditor.WriteColor(filePath01, 0xAEC, config.AccessIconColor3, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT);
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyMaleQuest(config, modDirectory);
            ApplyWalking(config, modDirectory);
            ApplyMBUIBustupUniverse(config, modDirectory);
            ApplyAccessIconTalk(config, modDirectory);
            ApplyStudy(config, modDirectory);
            ApplyAccessIconListen(config, modDirectory);
            ApplyDormitoryLife(config, modDirectory);
            ApplyQuest(config, modDirectory);
        }
    }
}
