using p3rpc.femc.Configuration;
using Reloaded.Mod.Interfaces;
using Ryo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UE.Toolkit.Interfaces;
using UnrealEssentials.Interfaces;

namespace p3rpc.femc
{
public static class CustomBustups
{
    public static void LoadCustomBustupsAssets(
        IUnrealEssentials unrealEssentials,
        IToolkit toolKit,
        IModLoader modLoader,
        IModConfig modConfig,
        IRyoApi ryo,
        Config configuration,
        string modLocation)
        {
            if (configuration.CustomBustups)
            {
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2D", "CustomBustups", "SC0221"));
                var uePath = Path.Combine(modLocation, "UEToolkitAssets", "CustomBustups", "SC0221");
                if (Directory.Exists(uePath))
                {
                    toolKit.AddObjectsPath(uePath);
                }
            }
        }
    }
    }