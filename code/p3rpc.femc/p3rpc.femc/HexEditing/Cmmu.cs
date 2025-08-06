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

        public static void Apply(Config config, string modDirectory)
        {
            ApplyBPUICmmRankUpBG(config, modDirectory);
            ApplyBPUICmmRankUPAnim(config, modDirectory);
            ApplyRankUpColorCurve(config, modDirectory);
        }
    }
}
 