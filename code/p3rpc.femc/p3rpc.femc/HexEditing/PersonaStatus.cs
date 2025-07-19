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

        public static void Apply(Config config, string modDirectory)
        {
            ApplyMIUICampPersonaStatusBG(config, modDirectory);
            ApplyMMUICampPersonaStatusBG(config, modDirectory);
            ApplyPersonaStatusBattleCurve(config, modDirectory);
        }
    }
}
