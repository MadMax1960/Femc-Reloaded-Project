using System.IO;
using p3rpc.femc.Configuration;

namespace p3rpc.femc.HexEditing
{
    public static class ExampleHexEdit
    {
        public static void Apply(Config config, string modDirectory)
        {
            // filepath
            string filePath = Path.Combine(modDirectory,
    "UnrealEssentials", "P3R", "Content", "Xrd777",
    "Blueprints", "UI", "Mail", "BP_MailDraw.uasset");

            // offset(s)
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

            //for single offset you can do

            //        // Offset inside the file where the colour should be placed.
            //        long offset = 0x10;

            // inject color
            //HexColorEditor.WriteColor(filePath, offset, config.ExampleHexEditColor);

            // Inject colors
            foreach (var entry in offsets)
                HexColorEditor.WriteColor(filePath, entry.Offset, config.ExampleHexEditColor, entry.Order);
        }
    }
}