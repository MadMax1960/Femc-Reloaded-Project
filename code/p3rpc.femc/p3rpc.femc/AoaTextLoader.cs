using System.IO;
using p3rpc.femc.Configuration;
using UnrealEssentials.Interfaces;
using static p3rpc.femc.Configuration.Config;

namespace p3rpc.femc
{
	public static class AoaTextLoader
	{
		public static void LoadAoaTextAssets(IUnrealEssentials unrealEssentials, Config configuration, string modLocation)
		{
			if (configuration.AOAText == AOATextType.DontLookBack)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "AOAText", "DontLookBack"));
			else if (configuration.AOAText == AOATextType.SorryBoutThat)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "AOAText", "SorryBoutThat"));
			else if (configuration.AOAText == AOATextType.PerfectlyAccomplished)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "AOAText", "PerfectlyAccomplished"));
			// Add other AOAText conditions if needed.
		}
	}
}
