using System.IO;
using p3rpc.femc.Configuration;
using UnrealEssentials.Interfaces;
using static p3rpc.femc.Configuration.Config;

namespace p3rpc.femc
{
	public static class CutinLoader
	{
		public static void LoadCutinAssets(IUnrealEssentials unrealEssentials, Config configuration, string modLocation)
		{
			if (configuration.CutinTrue == CutinType.berrycha)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Cutin", "berrycha"));
			else if (configuration.CutinTrue == CutinType.ElyandPatmandx)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Cutin", "ElyandPatmandx"));
			else if (configuration.CutinTrue == CutinType.Mekki)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Cutin", "Mekki"));
			else if (configuration.CutinTrue == CutinType.shiosakana)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Cutin", "shiosakana"));
			// Add other Cutin conditions if needed.
		}
	}
}
