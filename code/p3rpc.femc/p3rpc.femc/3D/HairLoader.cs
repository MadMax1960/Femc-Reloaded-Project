using System.IO;
using p3rpc.femc.Configuration;
using UnrealEssentials.Interfaces;
using static p3rpc.femc.Configuration.Config;

namespace p3rpc.femc
{
    public static class HairLoader
    {
        public static void LoadHairAssets(IUnrealEssentials unrealEssentials, Config configuration, string modLocation)
        {
            if (configuration.HairTrue == HairType.MudkipsHair)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "3d", "hair", "MudkipHair")); // I'd like to phase these out, but I forgor people actually use it. Make sure when new hair is done to rename it to "esa hair" and nuke old hair
            else if (configuration.HairTrue == HairType.KotoneBeanHair)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "3d", "hair", "NaobeanHair")); 
        }
    }
}