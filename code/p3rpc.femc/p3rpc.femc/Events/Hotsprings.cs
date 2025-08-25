using System.IO;
using p3rpc.femc.Configuration;
using Reloaded.Mod.Interfaces;
using Ryo.Interfaces;
using Unreal.AtlusScript.Interfaces;
using UnrealEssentials.Interfaces;

namespace p3rpc.femc;

public static class HotspringsLoader
{
    public static void LoadHotspringsAssets(
        IUnrealEssentials unrealEssentials,
        IModLoader modLoader,
        IModConfig modConfig,
        IRyoApi ryo,
        IAtlusAssets atlusAssets,
        Config configuration,
        string modLocation)
    {
        if (configuration.TesticlesDorm)
        {
            unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Events", "Ray", "Oscar Fortnite", "Hotsprings"));
            atlusAssets.RegisterAssetsFolderWithModData(Path.Combine(modLocation, "Events", "Ray", "Oscar Fortnite", "Hotsprings", "MessageScripts"), new (modConfig.ModId, modLocation), AssetMode.Default, ESystemLanguage.UNIVERSAL);
            atlusAssets.RegisterAssetsFolderWithModData(Path.Combine(modLocation, "Events", "Ray", "Oscar Fortnite", "DormHang", "MessageScripts"), new(modConfig.ModId, modLocation), AssetMode.Default, ESystemLanguage.UNIVERSAL);
            //ryo.AddAudioFolder(modLoader.GetDirectoryForModId(modConfig.ModId) + "/Events/Ray/Oscar Fortnite/Hotsprings Voice");
            unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Events", "Ray", "Oscar Fortnite", "DormHang"));
        }
    }
}