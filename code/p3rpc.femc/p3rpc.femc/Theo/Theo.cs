using System.IO;
using p3rpc.femc.Configuration;
using Reloaded.Mod.Interfaces;
using Ryo.Interfaces;
using UnrealEssentials.Interfaces;

namespace p3rpc.femc;

public static class Theo
{
    public static void LoadTheoAssets(
        IUnrealEssentials unrealEssentials,
        IModLoader modLoader,
        IModConfig modConfig,
        IRyoApi ryo,
        Config configuration,
        string modLocation)
    {
        if (configuration.TheodorefromAlvinandTheChipmunks)
        {
            unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Theo", "TheodorefromAlvinandTheChipmunks"));
            unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Theo", "cutin", "mekkipatman"));
            unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Theo", "message"));
            unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Theo", "Bustup"));
            ryo.AddAudioFolder(modLoader.GetDirectoryForModId(modConfig.ModId) + "/Theo/voice/Landon");
        }
    }
}