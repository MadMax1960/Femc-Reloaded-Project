using System.IO;
using p3rpc.femc.Configuration;
using Reloaded.Mod.Interfaces;
using Ryo.Interfaces;
using UnrealEssentials.Interfaces;

namespace p3rpc.femc;

public static class Testing
{
    public static void LoadTesticles(
        IUnrealEssentials unrealEssentials,
        IModLoader modLoader,
        IModConfig modConfig,
        IRyoApi ryo,
        Config configuration,
        string modLocation)
    {
        if (configuration.TesticlesDorm)
        {
            unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Testing", "DormRoomSwap"));
        }
    }
}