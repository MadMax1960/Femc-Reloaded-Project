using p3rpc.commonmodutils;
using p3rpc.femc.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.HexEditing
{
    public static class Mail
    {
        private static void ApplyOpenAnimation(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "UI", "Mail", "BP_MailDraw.uasset");

            (long Offset, HexColorEditor.ColorOrder Order)[] offsets =
            {
                (0x24076, HexColorEditor.ColorOrder.BGRA),
                (0x23DD9, HexColorEditor.ColorOrder.BGRA),
                (0x23B3C, HexColorEditor.ColorOrder.BGRA),
                (0x238F4, HexColorEditor.ColorOrder.BGRA),
                (0x236C9, HexColorEditor.ColorOrder.BGRA),
                (0x2349E, HexColorEditor.ColorOrder.BGRA),
                (0x232EF, HexColorEditor.ColorOrder.BGRA),
                (0x2323E, HexColorEditor.ColorOrder.BGRA),
                (0x21EA1, HexColorEditor.ColorOrder.BGRA)
            };

            foreach (var entry in offsets)
                HexColorEditor.WriteColor(filePath, entry.Offset, config.MailStartAnimationColor, entry.Order);
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyOpenAnimation(config, modDirectory);
        }
    }
}
