using p3rpc.commonmodutils;
using p3rpc.femc.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.HexEditing
{
    public static class PersonaStatus
    {
        private static void ApplyMIUICampPersonaStatusBG(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Camp", "Material", "Instance", "MI_UI_Camp_PersonaStatus_BG.uasset");

            Dictionary<float, ConfigColor> colorKeyFrames = new Dictionary<float, ConfigColor>();

            HexColorEditor.ComponentType type = HexColorEditor.ComponentType.FLOAT;

            HexColorEditor.WriteColor(filePath, 0xE70, config.PersonaStatusDeepColorFilter, HexColorEditor.ColorOrder.RGBA, type);
            HexColorEditor.WriteColor(filePath, 0xD46, config.PersonaStatusMediumStrongColorFilter, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePath, 0xC1C, config.PersonaStatusSoftColorFilter, HexColorEditor.ColorOrder.RGB, type);
        }

        private static void ApplyMMUICampPersonaStatusBG(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Camp", "Material", "MasterMaterials", "MM_UI_Camp_PersonaStatus_BG.uasset");

            Dictionary<float, ConfigColor> colorKeyFrames = new Dictionary<float, ConfigColor>();

            HexColorEditor.ComponentType type = HexColorEditor.ComponentType.FLOAT;

            HexColorEditor.WriteColor(filePath, 0x8A6C, config.PersonaStatusInheritanceSquareColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePath, 0x39AD, config.PersonaStatusInheritanceSquareColor, HexColorEditor.ColorOrder.RGB, type);

            HexColorEditor.WriteColor(filePath, 0x8A48, config.PersonaStatusStripColor, HexColorEditor.ColorOrder.RGBA, type);
            HexColorEditor.WriteColor(filePath, 0x396D, config.PersonaStatusStripColor, HexColorEditor.ColorOrder.RGBA, type);

            HexColorEditor.WriteColor(filePath, 0x8A24, config.PersonaStatusWavesStripColor, HexColorEditor.ColorOrder.RGBA, type);
            HexColorEditor.WriteColor(filePath, 0x395D, config.PersonaStatusWavesStripColor, HexColorEditor.ColorOrder.RGBA, type);

            HexColorEditor.WriteColor(filePath, 0x89b8, config.PersonaStatusMMUnk1, HexColorEditor.ColorOrder.RGBA, type);
            HexColorEditor.WriteColor(filePath, 0x394D, config.PersonaStatusMMUnk1, HexColorEditor.ColorOrder.RGBA, type);

            HexColorEditor.WriteColor(filePath, 0x38D7, config.PersonaStatusMMUnk2, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePath, 0x399D, config.PersonaStatusMMUnk2, HexColorEditor.ColorOrder.RGB, type);


            HexColorEditor.WriteColor(filePath, 0x388B, config.PersonaStatusMMUnk3, HexColorEditor.ColorOrder.RGBA, type);

            HexColorEditor.WriteColor(filePath, 0x3863, config.PersonaStatusMMUnk4, HexColorEditor.ColorOrder.RGBA, type);
        }

        private static void ApplyPersonaStatusBattleCurve(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Camp", "Material", "Curve", "CA_UI_Camp_PersonaStatus.uasset");

            Dictionary<float, ConfigColor> colorKeyframes = new Dictionary<float, ConfigColor>();

            colorKeyframes.Add(0.0f, config.PersonaStatusScreenshotFilterKeyframe1);
            colorKeyframes.Add(0.1f, config.PersonaStatusScreenshotFilterKeyframe2);
            colorKeyframes.Add(0.7f, config.PersonaStatusScreenshotFilterKeyframe3);
            colorKeyframes.Add(1.0f, config.PersonaStatusScreenshotFilterKeyframe4);

            HexColorEditor.WriteColorCurve(filePath, 0x4CE, colorKeyframes);
        }

        private static void ApplyCampPersonaMaterials(Config config, string modDirectory)
        {
            string filePathList = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Tables", "PersonaListLayoutDataAsset.uasset");

            string filePathStatus = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Tables", "PersonaStatusLayoutDataAsset.uasset");

            HexColorEditor.ComponentType type = HexColorEditor.ComponentType.FLOAT;

            HexColorEditor.WriteColor(filePathList, 0x770, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0xFC5, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x1721, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x1C25, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x2129, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x3695, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x3B99, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x409D, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x45A1, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x8795, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x798, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x2F64, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x3468, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x396C, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x3E70, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x4374, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x8310, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0xFED, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x1E51, config.CampPersonaLightColor, HexColorEditor.ColorOrder.RGB, type);

            HexColorEditor.WriteColor(filePathList, 0x81B, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x1070, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x17CC, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x1CD0, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x21D4, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x3740, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x3C44, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x4148, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x464C, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x8840, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x843, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x1098, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x300F, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x3513, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x3A17, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x3F1B, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x441F, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x83BB, config.CampPersonaShadowColor, HexColorEditor.ColorOrder.RGB, type);
            
            HexColorEditor.WriteColor(filePathList, 0x8C6, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x111B, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x1877, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x1D7B, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x227F, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x37EB, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x3CEF, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x41F3, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x46F7, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x88EB, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x8EE, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x1143, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x1DA6, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x30BA, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x35BE, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x3AC2, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x3FC6, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x44CA, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x8466, config.CampPersonaHiLightColor, HexColorEditor.ColorOrder.RGB, type);
            
            HexColorEditor.WriteColor(filePathList, 0x971, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x11C6, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x1922, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x1E26, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x232A, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x3896, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x3D9A, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x429E, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x47A2, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathList, 0x8996, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
            
            HexColorEditor.WriteColor(filePathStatus, 0x999, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x3165, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x3669, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x3B6D, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x4071, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x4575, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
            HexColorEditor.WriteColor(filePathStatus, 0x8511, config.CampPersonaRimLightColor, HexColorEditor.ColorOrder.RGB, type);
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyMIUICampPersonaStatusBG(config, modDirectory);
            ApplyMMUICampPersonaStatusBG(config, modDirectory);
            ApplyPersonaStatusBattleCurve(config, modDirectory);
            ApplyCampPersonaMaterials(config, modDirectory);
        }
    }
}
