using System.IO;
using p3rpc.femc.Configuration;
using Reloaded.Mod.Interfaces;
using Ryo.Interfaces;
using UnrealEssentials.Interfaces;

namespace p3rpc.femc;

public static class HotspringsLoader
{
    public static void LoadHotspringsAssets(
        IUnrealEssentials unrealEssentials,
        IModLoader modLoader,
        IModConfig modConfig,
        IRyoApi ryo,
        Config configuration,
        string modLocation)
    {
        if (configuration.TesticlesDorm)
        {
            unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Events", "Ray", "Oscar Fortnite", "Hotsprings"));
            //ryo.AddAudioFolder(modLoader.GetDirectoryForModId(modConfig.ModId) + "/Events/Ray/Oscar Fortnite/Hotsprings Voice");
            unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Events", "Ray", "Oscar Fortnite", "DormHang"));
        }
    }
}