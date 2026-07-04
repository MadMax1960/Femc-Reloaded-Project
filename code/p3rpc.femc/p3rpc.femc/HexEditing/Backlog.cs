using p3rpc.femc.Configuration;

namespace p3rpc.femc.HexEditing
{
    public static class Backlog
    {
        private static void ApplyBPBacklogDraw(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "UI", "UIBackLog", "BP_UIBackLogDraw.uasset");

            HexColorEditor.WriteColor(filePath, 0x171E, config.UnselectedRipple1, HexColorEditor.ColorOrder.BGRA); // Original color #025958
            HexColorEditor.WriteColor(filePath, 0x1722, config.UnselectedRipple2, HexColorEditor.ColorOrder.BGRA); // Original color #014746
            HexColorEditor.WriteColor(filePath, 0x1726, config.UnselectedRipple3, HexColorEditor.ColorOrder.BGRA); // Original color #013130
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyBPBacklogDraw(config, modDirectory);
        }
    }
}
