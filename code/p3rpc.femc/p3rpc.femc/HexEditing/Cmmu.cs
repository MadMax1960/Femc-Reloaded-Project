using p3rpc.commonmodutils;
using p3rpc.femc.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.HexEditing
{
    public static class Cmmu
    {
        private static void ApplyBPUICmmRankUPAnim(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "UI", "Community", "RankUp", "BP_UICmmRankUPAnim.uasset");

            (long Offset, HexColorEditor.ColorOrder Order)[] offsets =
            {
                (0x16063, HexColorEditor.ColorOrder.BGRA),
                (0x16098, HexColorEditor.ColorOrder.BGRA)
            };

            // Normal middle/down background 3
            foreach (var entry in offsets)
                HexColorEditor.WriteColor(filePath, entry.Offset, config.CmmuRankUpBG3MiddownColor, entry.Order); // Original color #121f2b

            // Normal background color 4
            HexColorEditor.WriteColor(filePath, 0x160CD, config.CmmuRankUpBG4Color, HexColorEditor.ColorOrder.BGRA); // Original color #B4B8E5
        }

        private static void ApplyBPUICmmRankUpBG(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "UI", "Community", "BP_UICmmRankUpBG.uasset");

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x14F3, config.CmmuRankUpColor1); // Original color #434FA9

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x15DE, config.CmmuRankUpColor2); // Original color #3C98DC

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x16B2, config.CmmuRankUpColor3); // Original color #43A9F5
        }

        private static void ApplyRankUpColorCurve(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "UI", "Camp", "Material", "Community", "Curve", "CA_UI_Community.uasset");

            Dictionary<float, ConfigColor> colorKeyframes = new Dictionary<float, ConfigColor>();

            colorKeyframes.Add(0.0f, config.CmmuRankUpKeyframe1);
            colorKeyframes.Add(0.2f, config.CmmuRankUpKeyframe2);
            colorKeyframes.Add(0.5f, config.CmmuRankUpKeyframe3);
            colorKeyframes.Add(0.9f, config.CmmuRankUpKeyframe4);
            colorKeyframes.Add(1.0f, config.CmmuRankUpKeyframe5);

            HexColorEditor.WriteColorCurve(filePath, 0x56E, colorKeyframes);
        }

        private static void ApplyBPUICmmMax(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Effects", "Niagara", "UI", "NS_FX_UI_CommuMax_00.ucas");

            HexColorEditor.WriteFloat(filePath, 0x8832, (config.CmmuRankUpSparkles1.R) / 255.0f); // Original color #59BAFF
            HexColorEditor.WriteFloat(filePath, 0x8836, (config.CmmuRankUpSparkles1.G) / 255.0f);
            HexColorEditor.WriteFloat(filePath, 0x883A, (config.CmmuRankUpSparkles1.B) / 255.0f);

            HexColorEditor.WriteFloat(filePath, 0xCBE7, ((config.CmmuRankUpSparkles2.R) / 255.0f) * 5.0f); // Original color #0057FF
            HexColorEditor.WriteFloat(filePath, 0xCBEB, ((config.CmmuRankUpSparkles2.G) / 255.0f) * 5.0f);
            HexColorEditor.WriteFloat(filePath, 0xCBEF, ((config.CmmuRankUpSparkles2.B) / 255.0f) * 5.0f);

            HexColorEditor.WriteFloat(filePath, 0xF13B, (config.CmmuRankUpSparkles3.R) / 255.0f); // Original color #5900ff
            HexColorEditor.WriteFloat(filePath, 0xF13F, (config.CmmuRankUpSparkles3.G) / 255.0f);
            HexColorEditor.WriteFloat(filePath, 0xF143, (config.CmmuRankUpSparkles3.B) / 255.0f);

            HexColorEditor.WriteFloat(filePath, 0xF147, ((config.CmmuRankUpSparkles4.R) / 255.0f) * 1.2f); // Original color #0057FF
            HexColorEditor.WriteFloat(filePath, 0xF14B, ((config.CmmuRankUpSparkles4.G) / 255.0f) * 1.2f);
            HexColorEditor.WriteFloat(filePath, 0xF14F, ((config.CmmuRankUpSparkles4.B) / 255.0f) * 1.2f);

            HexColorEditor.WriteFloat(filePath, 0x16240, (config.CmmuRankUpSparkleTrails.R) / 255.0f); // Original color #5AE9FF
            HexColorEditor.WriteFloat(filePath, 0x16244, (config.CmmuRankUpSparkleTrails.G) / 255.0f);
            HexColorEditor.WriteFloat(filePath, 0x16248, (config.CmmuRankUpSparkleTrails.B) / 255.0f);

            HexColorEditor.WriteFloat(filePath, 0x1A4D7, ((config.CmmuRankUpMovingSparkles.R) / 255.0f) * 1.2f); // Original color #00CCFF
            HexColorEditor.WriteFloat(filePath, 0x1A4DB, ((config.CmmuRankUpMovingSparkles.G) / 255.0f) * 1.2f);
            HexColorEditor.WriteFloat(filePath, 0x1A4DF, ((config.CmmuRankUpMovingSparkles.B) / 255.0f) * 1.2f);
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyBPUICmmRankUpBG(config, modDirectory);
            ApplyBPUICmmRankUPAnim(config, modDirectory);
            ApplyRankUpColorCurve(config, modDirectory);
            ApplyBPUICmmMax(config, modDirectory);
        }
    }
}
 