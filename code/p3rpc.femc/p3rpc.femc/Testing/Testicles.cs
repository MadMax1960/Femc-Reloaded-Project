using p3rpc.commonmodutils;
using p3rpc.femc.Configuration;
using Reloaded.Mod.Interfaces;
using Ryo.Interfaces;
using System.IO;
using UE.Toolkit.Core.Types.Unreal.UE4_27_2;
using UE.Toolkit.Interfaces;
using UE.Toolkit.Interfaces;
using UnrealEssentials.Interfaces;
using static p3rpc.femc.UeToolkit.ArmorData;

namespace p3rpc.femc;

public class Testing
{
    public static void LoadTesticles(
        IUnrealEssentials unrealEssentials,
        IModLoader modLoader,
        IModConfig modConfig,
        IRyoApi ryo,
        IToolkit toolKit,
        FemcContext context,
        Config configuration,
        string modLocation)
    {

        if (configuration.TesticlesEventsDorm)
        {
            unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Testing", "DormRoomSwap"));
        }

        string path = Path.Combine(modLoader.GetDirectoryForModId(modConfig.ModId), "UEToolkitAssets");

        if (configuration.TesticlesEventsDorm)
        {
            toolKit.AddObjectsPath(Path.Combine(path, "DormTest"));
        }

    }
}