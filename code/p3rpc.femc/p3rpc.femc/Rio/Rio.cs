using System.IO;
using p3rpc.femc.Configuration;
using Reloaded.Mod.Interfaces;
using Ryo.Interfaces;
using UnrealEssentials.Interfaces;

namespace p3rpc.femc;

public static class Rio
{
    public static void LoadRioAssets(
        IUnrealEssentials unrealEssentials,
        IModLoader modLoader,
        IModConfig modConfig,
        IRyoApi ryo,
        Config configuration,
        string modLocation)
    {
        //if (configuration.thisalsofinishedbeforethumbnail)
        //{
        //    unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Rio", "Models"));
        //    ryo.AddAudioFolder(modLoader.GetDirectoryForModId(modConfig.ModId) + "/Rio/Voice/idr");
        //}
    }
}