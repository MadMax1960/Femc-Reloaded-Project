using System.IO;
using p3rpc.femc.Configuration;
using UnrealEssentials.Interfaces;
using static p3rpc.femc.Configuration.Config;

namespace p3rpc.femc
{
    public static class AnimLoader
    {
        public static void LoadAnimAssets(IUnrealEssentials unrealEssentials, Config configuration, string modLocation)
        {
            if (configuration.AnimTrue == AnimType.OriginalAnims)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "3d", "Anims", "Original Dummy")); // empty folder that just loads vanilla anims 
            else if (configuration.AnimTrue == AnimType.CustomAnims)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "3d", "Anims", "Original Dummy")); // aoa might be seperate from all of these maybe, depends on if we do custom ending poses per aoa 2d option. Would need to pass the 2d aoa conditionals if we do
            else if (configuration.AnimTrue == AnimType.VeryFunnyAnims)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "3d", "Anims", "Very Funny Anims")); // the funny anims 
        }
    }
}