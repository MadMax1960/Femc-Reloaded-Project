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
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "3d", "Anims", "Original Dummy"));
            else if (configuration.AnimTrue == AnimType.CustomAnims)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "3d", "Anims", "Custom Anims"));
            else if (configuration.AnimTrue == AnimType.VeryFunnyAnims)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "3d", "Anims", "Very Funny Anims"));
        }
    }
}