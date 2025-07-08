using System.IO;
using p3rpc.femc.Configuration;
using Reloaded.Mod.Interfaces;
using Ryo.Interfaces;
using static p3rpc.femc.Configuration.Config;

namespace p3rpc.femc.Audio
{
    public static class Voice
    {
        public static void LoadVoiceAssets(IModLoader modLoader, IModConfig modConfig, Config configuration, IRyoApi ryo)
        {
            var basePath = modLoader.GetDirectoryForModId(modConfig.ModId);

            if (configuration.bluehairandpronounce)
                ryo.AddAudioFolder(Path.Combine(basePath, "Voice"));

            if (configuration.VoiceTrue == VoiceType.Mellodi)
                ryo.AddAudioFolder(Path.Combine(basePath, "mellodi", "normal battle")); // if you ever wonder why event voices not loading, they're in a "events" folder, idk why they in there but I don't wanna touch
            else if (configuration.VoiceTrue == VoiceType.MellodiSilly)
                ryo.AddAudioFolder(Path.Combine(basePath, "mellodi", "april fools"));
            else if (configuration.VoiceTrue == VoiceType.Japanese)
                ryo.AddAudioFolder(Path.Combine(basePath, "mellodi", "nothing lmao"));
        }
    }
}