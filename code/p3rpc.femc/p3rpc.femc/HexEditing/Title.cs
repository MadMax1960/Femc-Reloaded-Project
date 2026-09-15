using p3rpc.commonmodutils;
using p3rpc.femc.Components;
using p3rpc.femc.Configuration;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Structs.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using UE.Toolkit.Interfaces;
using UnrealEssentials.Interfaces;

namespace p3rpc.femc.HexEditing
{
    public static class Title
    {
        private static void ApplyTitleMaterialsBG(Config config, string modDirectory)
        {
            string filePathCloud = Path.Combine(modDirectory,
                "SunsetTitle", "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Field", "Resource", "TitleBG", "MI_Title_Cloud01.uasset");

            string filePathMoonAge = Path.Combine(modDirectory,
                "SunsetTitle", "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Field", "Resource", "TitleBG", "MI_Title_MoonAge.uasset");

            string filePathMoonGlow = Path.Combine(modDirectory,
                "SunsetTitle", "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Field", "Resource", "TitleBG", "MI_Title_MoonGlow.uasset");

            string filePathSkyClouds = Path.Combine(modDirectory,
                "SunsetTitle", "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Field", "Resource", "TitleBG", "MI_Title_SkyClouds.uasset");

            HexColorEditor.ComponentType type = HexColorEditor.ComponentType.FLOAT;

            HexColorEditor.WriteColor(filePathCloud, 0x1C74, config.TitleBgCloud1, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathCloud, 0x1D9E, config.TitleBgCloud2, HexColorEditor.ColorOrder.RGB, type);

            HexColorEditor.WriteColor(filePathMoonAge, 0xE0C, config.TitleBgMoonAge, HexColorEditor.ColorOrder.RGB, type);

            HexColorEditor.WriteColor(filePathMoonGlow, 0x956, config.TitleBgMoonGlow, HexColorEditor.ColorOrder.RGB, type);

            HexColorEditor.WriteColor(filePathSkyClouds, 0x15AA, config.TitleBgCloudColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathSkyClouds, 0x16D4, config.TitleBgOverallColor, HexColorEditor.ColorOrder.RGB, type);
        }

        private static void ApplyTitleMap(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "SunsetTitle", "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Maps", "Title", "LV_Title_Before.umap");

            HexColorEditor.ComponentType type = HexColorEditor.ComponentType.FLOAT;

            HexColorEditor.WriteColor(filePath, 0x895E, config.TitleMapFilterColor1, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePath, 0x89F3, config.TitleMapFogColor1, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePath, 0x8A34, config.TitleMapBGFogColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePath, 0x4533, config.TitleMapLightColor, HexColorEditor.ColorOrder.BGR, HexColorEditor.ComponentType.BYTE);
            HexColorEditor.WriteColor(filePath, 0x77A3, config.TitleMapGlowColor, HexColorEditor.ColorOrder.BGR, type);
            HexColorEditor.WriteColor(filePath, 0x819C, config.TitleMapMoonShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePath, 0x991F, config.TitleMapSunColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePath, 0x9A49, config.TitleMapHorizonColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePath, 0x9B73, config.TitleMapZenithColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePath, 0x9DC7, config.TitleMapCloudColor, HexColorEditor.ColorOrder.RGB, type);

            string filePath2 = Path.Combine(modDirectory,
                "SunsetTitle", "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Maps", "Title", "LV_Title_BG_Before.umap");

            HexColorEditor.WriteColor(filePath2, 0xB86, config.TitleMapBgLevelColor1, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePath2, 0xBF8, config.TitleMapBgLevelColor2, HexColorEditor.ColorOrder.RGB, type);

            string stupidMat = Path.Combine(modDirectory,
               "SunsetTitle", "UnrealEssentials", "P3R", "Content", "Xrd777",
               "Environments", "MaterialInstance", "MI_EN_P_TitleFil.uasset");

            HexColorEditor.WriteColor(stupidMat, 0x1124, config.StupidMatTitleColor1, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(stupidMat, 0x124E, config.StupidMatTitleColor2, HexColorEditor.ColorOrder.RGB, type);
        }

        private static void ApplySeesMaterials(Config config, string modDirectory)
        {
            string filePathProtag1 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0001", "Models", "MI_PC0001_C052_00_TiFiOpSp.uasset");

            string filePathProtag2 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0001", "Models", "MI_PC0001_C052_02_TiFiOpSp.uasset");

            string filePathProtag3 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0001", "Models", "MI_PC0001_H000_00_TiFiOp.uasset");

            HexColorEditor.ComponentType type = HexColorEditor.ComponentType.FLOAT;

            HexColorEditor.WriteColor(filePathProtag1, 0xA48, config.TitleFillColorA_1, HexColorEditor.ColorOrder.RGB, type); // 00ADF9
            HexColorEditor.WriteColor(filePathProtag1, 0xB72, config.TitleFillColorB_2, HexColorEditor.ColorOrder.RGB, type); // 00FDFF
            HexColorEditor.WriteColor(filePathProtag2, 0xA48, config.TitleFillColorA_1, HexColorEditor.ColorOrder.RGB, type); // 00ADF9
            HexColorEditor.WriteColor(filePathProtag3, 0x8CC, config.TitleFillColorA_1, HexColorEditor.ColorOrder.RGB, type); // 00ADF9

            // ------------------------------------------------------------------------------------------------------------------------

            string filePathYukari1 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0002", "Models", "MI_PC0002_C052_00_TiFiOpSp.uasset");

            string filePathYukari2 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0002", "Models", "MI_PC0002_C052_02_TiFiOpSp.uasset");

            string filePathYukari3 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0002", "Models", "MI_PC0002_H000_00_TiFiOp.uasset");

            HexColorEditor.WriteColor(filePathYukari1, 0xA48, config.TitleFillColorA_1, HexColorEditor.ColorOrder.RGB, type); // 00ADF9
            HexColorEditor.WriteColor(filePathYukari1, 0xB72, config.TitleFillColorB_1, HexColorEditor.ColorOrder.RGB, type); // 00FFFC
            HexColorEditor.WriteColor(filePathYukari2, 0xA48, config.TitleFillColorA_1, HexColorEditor.ColorOrder.RGB, type); // 00ADF9
            HexColorEditor.WriteColor(filePathYukari3, 0x8CC, config.TitleFillColorA_1, HexColorEditor.ColorOrder.RGB, type); // 00ADF9

            // ------------------------------------------------------------------------------------------------------------------------

            string filePathJunpei1 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0003", "Models", "MI_PC0003_C052_00_TiFiOpSp.uasset");

            string filePathJunpei2 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0003", "Models", "MI_PC0003_C052_02_TiFiOpSp.uasset");

            string filePathJunpei3 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0003", "Models", "MI_PC0003_H000_00_TiFiOp.uasset");

            HexColorEditor.WriteColor(filePathJunpei1, 0xA48, config.TitleFillColorA_1, HexColorEditor.ColorOrder.RGB, type); // 00ADF9 
            HexColorEditor.WriteColor(filePathJunpei1, 0xB72, config.TitleFillColorB_2, HexColorEditor.ColorOrder.RGB, type); // 00FDFF
            HexColorEditor.WriteColor(filePathJunpei2, 0xA48, config.TitleFillColorA_1, HexColorEditor.ColorOrder.RGB, type); // 00ADF9 
            HexColorEditor.WriteColor(filePathJunpei3, 0x8CC, config.TitleFillColorA_1, HexColorEditor.ColorOrder.RGB, type); // 00ADF9 

            // ------------------------------------------------------------------------------------------------------------------------

            string filePathAki1 = Path.Combine(modDirectory,
               "UnrealEssentials", "P3R", "Content", "Xrd777",
               "Characters", "Player", "PC0004", "Models", "MI_PC0004_C052_00_TiFiOpSp.uasset");

            string filePathAki2 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0004", "Models", "MI_PC0004_C052_02_TiFiOpSp.uasset");

            string filePathAki3 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0004", "Models", "MI_PC0004_H000_00_TiFiOp.uasset");

            HexColorEditor.WriteColor(filePathAki1, 0xA48, config.TitleFillColorA_2, HexColorEditor.ColorOrder.RGB, type); // 1448EA 
            HexColorEditor.WriteColor(filePathAki1, 0xB72, config.TitleFillColorB_3, HexColorEditor.ColorOrder.RGB, type); // 0F62EA
            HexColorEditor.WriteColor(filePathAki2, 0xA48, config.TitleFillColorA_2, HexColorEditor.ColorOrder.RGB, type); // 1448EA 
            HexColorEditor.WriteColor(filePathAki3, 0x8CC, config.TitleFillColorA_2, HexColorEditor.ColorOrder.RGB, type); // 1448EA 


            // ------------------------------------------------------------------------------------------------------------------------

            string filePathMitsuru1 = Path.Combine(modDirectory,
               "UnrealEssentials", "P3R", "Content", "Xrd777",
               "Characters", "Player", "PC0005", "Models", "MI_PC0005_C052_00_TiFiOpSp.uasset");

            string filePathMitsuru2 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0005", "Models", "MI_PC0005_C052_02_TiFiOpSp.uasset");

            string filePathMitsuru3 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0005", "Models", "MI_PC0005_H000_00_TiFiOp.uasset");

            HexColorEditor.WriteColor(filePathMitsuru1, 0xA48, config.TitleFillColorA_2, HexColorEditor.ColorOrder.RGB, type); // 1448EA 
            HexColorEditor.WriteColor(filePathMitsuru1, 0xB72, config.TitleFillColorB_3, HexColorEditor.ColorOrder.RGB, type); // 0F62EA
            HexColorEditor.WriteColor(filePathMitsuru2, 0xA48, config.TitleFillColorA_2, HexColorEditor.ColorOrder.RGB, type); // 1448EA 
            HexColorEditor.WriteColor(filePathMitsuru3, 0x8CC, config.TitleFillColorA_2, HexColorEditor.ColorOrder.RGB, type); // 1448EA 

            // ------------------------------------------------------------------------------------------------------------------------

            string filePathFuuka1 = Path.Combine(modDirectory,
               "UnrealEssentials", "P3R", "Content", "Xrd777",
               "Characters", "Player", "PC0006", "Models", "MI_PC0006_C052_00_TiFiOpSp.uasset");

            string filePathFuuka2 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0006", "Models", "MI_PC0006_C052_02_TiFiOpSp.uasset");

            string filePathFuuka3 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0006", "Models", "MI_PC0006_H000_00_TiFiOp.uasset");

            HexColorEditor.WriteColor(filePathFuuka1, 0xA48, config.TitleFillColorA_3, HexColorEditor.ColorOrder.RGB, type); // 2563F6 
            HexColorEditor.WriteColor(filePathFuuka1, 0xB72, config.TitleFillColorB_4, HexColorEditor.ColorOrder.RGB, type); // 0082E5
            HexColorEditor.WriteColor(filePathFuuka2, 0xA48, config.TitleFillColorA_3, HexColorEditor.ColorOrder.RGB, type); // 2563F6 
            HexColorEditor.WriteColor(filePathFuuka3, 0x8CC, config.TitleFillColorA_3, HexColorEditor.ColorOrder.RGB, type); // 2563F6 

            // ------------------------------------------------------------------------------------------------------------------------

            string filePathAigis1 = Path.Combine(modDirectory,
               "UnrealEssentials", "P3R", "Content", "Xrd777",
               "Characters", "Player", "PC0007", "Models", "MI_PC0007_C052_00_TiFiOpSp.uasset");

            string filePathAigis2 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0007", "Models", "MI_PC0007_C052_02_TiFiOpSp.uasset");

            string filePathAigis3 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0007", "Models", "MI_PC0007_H000_00_TiFiOp.uasset");

            string filePathAigis4 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0007", "Models", "MI_PC0007_H000_00_TiFiOpSp.uasset");

            HexColorEditor.WriteColor(filePathAigis1, 0xA48, config.TitleFillColorA_3, HexColorEditor.ColorOrder.RGB, type); // 2563F6 
            HexColorEditor.WriteColor(filePathAigis1, 0xB72, config.TitleFillColorB_4, HexColorEditor.ColorOrder.RGB, type); // 0082E5
            HexColorEditor.WriteColor(filePathAigis2, 0xA48, config.TitleFillColorA_3, HexColorEditor.ColorOrder.RGB, type); // 2563F6 
            HexColorEditor.WriteColor(filePathAigis3, 0x8CC, config.TitleFillColorA_3, HexColorEditor.ColorOrder.RGB, type); // 2563F6 
            HexColorEditor.WriteColor(filePathAigis4, 0xA48, config.TitleFillColorA_3, HexColorEditor.ColorOrder.RGB, type); // 2563F6 
            HexColorEditor.WriteColor(filePathAigis4, 0xB72, config.TitleFillColorB_4, HexColorEditor.ColorOrder.RGB, type); // 0082E5 

            // ------------------------------------------------------------------------------------------------------------------------

            string filePathKen1 = Path.Combine(modDirectory,
               "UnrealEssentials", "P3R", "Content", "Xrd777",
               "Characters", "Player", "PC0008", "Models", "MI_PC0008_C052_00_TiFiOpSp.uasset");

            string filePathKen2 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0008", "Models", "MI_PC0008_C052_02_TiFiOpSp.uasset");

            string filePathKen3 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0008", "Models", "MI_PC0008_H000_00_TiFiOp.uasset");

            HexColorEditor.WriteColor(filePathKen1, 0xA48, config.TitleFillColorA_3, HexColorEditor.ColorOrder.RGB, type); // 2563F6 
            HexColorEditor.WriteColor(filePathKen1, 0xB72, config.TitleFillColorB_5, HexColorEditor.ColorOrder.RGB, type); // 3A8BF0
            HexColorEditor.WriteColor(filePathKen2, 0xA48, config.TitleFillColorA_3, HexColorEditor.ColorOrder.RGB, type); // 2563F6 
            HexColorEditor.WriteColor(filePathKen3, 0x8CC, config.TitleFillColorA_3, HexColorEditor.ColorOrder.RGB, type); // 2563F6 

            // ------------------------------------------------------------------------------------------------------------------------

            string filePathKoro1 = Path.Combine(modDirectory,
               "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0009", "Models", "MI_PC0009_C052_00_TiFiOpSp.uasset");

            string filePathKoro2 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0009", "Models", "MI_PC0009_C052_02_TiFiOpSp.uasset");

            string filePathKoro3 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0009", "Models", "MI_PC0009_F000_00_TiFiOp.uasset");

            string filePathKoro4 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0009", "Models", "MI_PC0009_C052_01_TiFiOpSp.uasset");


            HexColorEditor.WriteColor(filePathKoro1, 0xA48, config.TitleFillColorA_3, HexColorEditor.ColorOrder.RGB, type); // 2563F6 
            HexColorEditor.WriteColor(filePathKoro1, 0xB72, config.TitleFillColorB_4, HexColorEditor.ColorOrder.RGB, type); // 0082E5
            HexColorEditor.WriteColor(filePathKoro2, 0xA48, config.TitleFillColorA_3, HexColorEditor.ColorOrder.RGB, type); // 2563F6 
            HexColorEditor.WriteColor(filePathKoro3, 0x8CC, config.TitleFillColorA_3, HexColorEditor.ColorOrder.RGB, type); // 2563F6 
            HexColorEditor.WriteColor(filePathKoro4, 0xA48, config.TitleFillColorA_3, HexColorEditor.ColorOrder.RGB, type); // 2563F6 
            HexColorEditor.WriteColor(filePathKoro4, 0xB72, config.TitleFillColorB_4, HexColorEditor.ColorOrder.RGB, type); // 0082E5

            // ------------------------------------------------------------------------------------------------------------------------

            string filePathShinji1 = Path.Combine(modDirectory,
               "UnrealEssentials", "P3R", "Content", "Xrd777",
               "Characters", "Player", "PC0010", "Models", "MI_PC0010_C052_00_TiFiOpSp.uasset");

            string filePathShinji2 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0010", "Models", "MI_PC0010_C052_02_TiFiOpSp.uasset");

            string filePathShinji3 = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Characters", "Player", "PC0010", "Models", "MI_PC0010_H000_00_TiFiOp.uasset");

            HexColorEditor.WriteColor(filePathShinji1, 0xA48, config.TitleFillColorA_2, HexColorEditor.ColorOrder.RGB, type); // 1448EA 
            HexColorEditor.WriteColor(filePathShinji1, 0xB72, config.TitleFillColorB_3, HexColorEditor.ColorOrder.RGB, type); // 0F62EA
            HexColorEditor.WriteColor(filePathShinji2, 0xA48, config.TitleFillColorA_2, HexColorEditor.ColorOrder.RGB, type); // 1448EA 
            HexColorEditor.WriteColor(filePathShinji3, 0x8CC, config.TitleFillColorA_2, HexColorEditor.ColorOrder.RGB, type); // 1448EA 
        }

        public static void LoadSunsetTitleScreen(
        IUnrealEssentials unrealEssentials,
        IModLoader modLoader,
        IModConfig modConfig,
        Config configuration,
        string modLocation)
        {
            if (configuration.EnableSunsetTitleScreen)
            {
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "SunsetTitle", "UnrealEssentials"));
                ApplyTitleMaterialsBG(configuration, modLocation);
                ApplyTitleMap(configuration, modLocation);
            }
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplySeesMaterials(config, modDirectory);

        }
    }
}
