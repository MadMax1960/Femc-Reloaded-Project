using p3rpc.femc.Configuration;
using UnrealEssentials.Interfaces;

namespace p3rpc.femc
{
    public static class HandsOutLoader
    {
        public static void LoadHandsOutAssets(IUnrealEssentials unrealEssentials, Config configuration, string modLocation)
        {
            unrealEssentials.AddFromFolder(Path.Combine(modLocation, "3d", "Anims", "Hands Out"));
        }
    }
}
