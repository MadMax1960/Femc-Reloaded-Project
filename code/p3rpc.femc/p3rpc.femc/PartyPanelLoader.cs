using System.IO;
using p3rpc.femc.Configuration;
using UnrealEssentials.Interfaces;
using static p3rpc.femc.Configuration.Config;

namespace p3rpc.femc
{
	public static class PartyPanelLoader
	{
		public static void LoadPartyPanelAssets(IUnrealEssentials unrealEssentials, Config configuration, string modLocation)
		{
			if (configuration.PartyPanelTrue == PartyPanelType.Kris)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "PartyPanel", "Kris"));
			else if (configuration.PartyPanelTrue == PartyPanelType.Esa)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "PartyPanel", "Esa"));
			// Add other PartyPanel conditions if needed.
		}
	}
}
