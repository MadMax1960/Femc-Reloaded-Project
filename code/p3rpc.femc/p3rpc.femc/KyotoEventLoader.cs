using System.IO;
using p3rpc.femc.Configuration;
using UnrealEssentials.Interfaces;
using static p3rpc.femc.Configuration.Config;

namespace p3rpc.femc
{
	public static class KyotoEventLoader
	{
		public static void LoadKyotoEventAssets(IUnrealEssentials unrealEssentials, Config configuration, string modLocation)
		{
			if (configuration.KyotoEventTrue == KyotoEventtype.ely)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Events", "Kyoto", "ely"));
			// Add other Kyoto Event conditions if needed.
		}
	}
}
