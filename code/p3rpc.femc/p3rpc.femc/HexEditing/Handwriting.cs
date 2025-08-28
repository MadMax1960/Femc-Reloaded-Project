using p3rpc.femc.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.HexEditing
{
    public static class Handwriting
    {
        private static void ApplyDoubleExclamation(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Handwriting", "Materials", "Handwriting_P.ucas");

            // MI_UI_Handwriting_DoubleExclamation_00.uasset
            HexColorEditor.WriteColor(filePath, 0x3C64, config.HandwritingGradationColor2, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #00F7FF

            // MI_UI_Handwriting_DoubleExclamation_01.uasset
            HexColorEditor.WriteColor(filePath, 0x65E4, config.HandwritingGradationColor1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #CAFEFF
        }

        private static void ApplyExclamation(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Handwriting", "Materials", "Handwriting_P.ucas");

            // MI_UI_Handwriting_Exclamation_00.uasset
            HexColorEditor.WriteColor(filePath, 0x795E, config.HandwritingGradationColor1, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #D2FEFF

            // MI_UI_Handwriting_Exclamation_01.uasset
            HexColorEditor.WriteColor(filePath, 0x5222, config.HandwritingGradationColor2, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #00F7FF
        }

        private static void ApplyExclamationQuestion(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Handwriting", "Materials", "Handwriting_P.ucas");

            // MI_UI_Handwriting_ExclamationQuestion_00.uasset
            HexColorEditor.WriteColor(filePath, 0x8E2E, config.HandwritingGradationColor2, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #00F2FF
        }

        private static void ApplyQuestion(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Handwriting", "Materials", "Handwriting_P.ucas");

            // MI_UI_Handwriting_Question_01.uasset
            HexColorEditor.WriteColor(filePath, 0x268E, config.HandwritingGradationColor2, HexColorEditor.ColorOrder.RGB, HexColorEditor.ComponentType.FLOAT); // Original color #00F7FF

            // MI_UI_Handwriting_Question_02.uasset
            HexColorEditor.WriteFloat(filePath, 0x10D4, (config.HandwritingGradationColor1.R / 255.0f) * 5.0f); // Original color #ABD5FF
            HexColorEditor.WriteFloat(filePath, 0x10D8, (config.HandwritingGradationColor1.G / 255.0f) * 5.0f);
            HexColorEditor.WriteFloat(filePath, 0x10DC, (config.HandwritingGradationColor1.B / 255.0f) * 5.0f);

            HexColorEditor.WriteFloat(filePath, 0x11FE, (config.HandwritingGradationColor2.R / 255.0f) * 5.0f); // Original color #00AAFF
            HexColorEditor.WriteFloat(filePath, 0x1202, (config.HandwritingGradationColor2.G / 255.0f) * 5.0f);
            HexColorEditor.WriteFloat(filePath, 0x1206, (config.HandwritingGradationColor2.B / 255.0f) * 5.0f);
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyDoubleExclamation(config, modDirectory);
            ApplyExclamation(config, modDirectory);
            ApplyExclamationQuestion(config, modDirectory);
            ApplyQuestion(config, modDirectory);
        }
    }
}
