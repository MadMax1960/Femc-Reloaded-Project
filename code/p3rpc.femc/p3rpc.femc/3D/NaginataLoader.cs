using System.IO;
using p3rpc.femc.Configuration;
using UnrealEssentials.Interfaces;

namespace p3rpc.femc
{
    public static class NaginataLoader
    {
        public static void LoadNaginataAssets(IUnrealEssentials unrealEssentials, Config configuration, string modLocation)
        {
            if (configuration.NagiWeap)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "3d", "Nagitana"));
        }
    }
}