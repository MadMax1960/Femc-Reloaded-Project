using p3rpc.commonmodutils;
using p3rpc.femc.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.HexEditing
{
    public static class Battle
    {
        private static void ApplyBattleResultUIBase(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "Battle", "GUI", "BP_BtlResultUIBase.uasset");

            HexColorEditor.ColorOrder order = HexColorEditor.ColorOrder.BGRA;

            HexColorEditor.WriteColor(filePath, 0x71294, config.BattleResultLeftSquare, order);
            HexColorEditor.WriteColor(filePath, 0x7139D, config.BattleResultFontColor, order);
            HexColorEditor.WriteColor(filePath, 0x713D2, config.BattleResultLeftZeroFontColor, order);
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyBattleResultUIBase(config, modDirectory);
        }
    }
}
