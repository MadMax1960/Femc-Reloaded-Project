using System.IO;
using p3rpc.femc.Configuration;
using UnrealEssentials.Interfaces;

namespace p3rpc.femc
{
    /// <summary>
    /// Loads optional fun assets depending on configuration.
    /// </summary>
    public static class FunStuffLoader
    {
        /// <summary>
        /// Adds fun asset folders to UnrealEssentials based on configuration.
        /// </summary>
        public static void LoadFunStuffAssets(IUnrealEssentials unrealEssentials, Config configuration, string modLocation)
        {
            if (configuration.KotoneRoom)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Fun Stuff", "Kotone Room"));

            if (configuration.GregoryHouseRatPoisonDeliverySystem)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Fun Stuff", "GregoryHouseRatPoisonDeliverySystem"));
            else
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Fun Stuff", "GregoryHouseRatPoisonDeliverySystemog"));

            if (configuration.OtomeArcade)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "Fun Stuff", "Otome Arcade"));
        }
    }
}