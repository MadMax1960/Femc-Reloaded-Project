using System.IO;
using p3rpc.femc.Configuration;
using UnrealEssentials.Interfaces;
using static p3rpc.femc.Configuration.Config;

namespace p3rpc.femc
{
	public static class GroupEventLoader
	{
		public static void LoadGroupEventAssets(IUnrealEssentials unrealEssentials, Config configuration, string modLocation)
		{
			if (configuration.GroupEventTrue == GroupEventtype.bichelle)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Events", "Group", "bichelle"));
			else if (configuration.GroupEventTrue == GroupEventtype.ely)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Events", "Group", "ely"));
            else if (configuration.GroupEventTrue == GroupEventtype.mekki)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Events", "Group", "Mekki"));
            // Add other Group Event conditions if needed.
        }
	}
}
