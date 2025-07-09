using System.IO;
using p3rpc.femc.Configuration;
using Reloaded.Mod.Interfaces;
using Ryo.Interfaces;
using UnrealEssentials.Interfaces;

namespace p3rpc.femc;

public static class Saori
{
    public static void LoadSaoriAssets(
        IUnrealEssentials unrealEssentials,
        IModLoader modLoader,
        IModConfig modConfig,
        IRyoApi ryo,
        Config configuration,
        string modLocation)
    {
        //if (configuration.thisfinishedbeforethumbnail)
        //{
        //    unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Saori", "Models"));
        //    ryo.AddAudioFolder(modLoader.GetDirectoryForModId(modConfig.ModId) + "/Saori/Voice/idr");
        //}
    }
}