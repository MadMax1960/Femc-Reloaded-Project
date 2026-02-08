using p3rpc.femc.Configuration;

namespace p3rpc.femc.HexEditing
{
    public static class SocialStats
    {
        private static void ApplyRankUpParticlesColor(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Effects", "Niagara", "UI", "NS_FX_UI_RankUp_00.uasset");
            
            HexColorEditor.WriteFloat(filePath, 0xae8f, (float) config.SocialStatsParticlesColor.R / 255.0f); // Original color #00b1ff
            HexColorEditor.WriteFloat(filePath, 0xae93, (float) config.SocialStatsParticlesColor.G / 255.0f);
            HexColorEditor.WriteFloat(filePath, 0xae97, (float) config.SocialStatsParticlesColor.B / 255.0f);
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyRankUpParticlesColor(config, modDirectory);
        }
    }
}
