using System.IO;
using p3rpc.femc.Configuration;
using Reloaded.Mod.Interfaces;
using Ryo.Interfaces;
using UE.Toolkit.Interfaces;
using UnrealEssentials.Interfaces;

namespace p3rpc.femc;

public static class Theo
{
    public static void LoadTheoAssets(
        IUnrealEssentials unrealEssentials,
        IToolkit toolKit,
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
            unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Theo", "Event"));
            ryo.AddAudioFolder(modLoader.GetDirectoryForModId(modConfig.ModId) + "/Theo/voice/Landon");
            var uePath = Path.Combine(modLocation, "UEToolkitAssets", "Theo");
            if (Directory.Exists(uePath))
            {
                toolKit.AddObjectsPath(uePath);
            }
        }
    }
}