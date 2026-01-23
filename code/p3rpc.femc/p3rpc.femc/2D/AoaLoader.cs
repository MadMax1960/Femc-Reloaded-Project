using System.IO;
using p3rpc.femc.Configuration;
using UnrealEssentials.Interfaces;
using static p3rpc.femc.Configuration.Config;

namespace p3rpc.femc
{
	public static class AoaLoader
	{
		public static void LoadAoaAssets(IUnrealEssentials unrealEssentials, Config configuration, string modLocation)
		{
			if (configuration.AOATrue == AOAType.Ely)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "AOA", "Ely"));
			else if (configuration.AOATrue == AOAType.Chrysanthie)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "AOA", "Chrysanthie"));
			else if (configuration.AOATrue == AOAType.Fernando)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "AOA", "Fernando"));
			else if (configuration.AOATrue == AOAType.Monica)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "AOA", "Monica"));
			else if (configuration.AOATrue == AOAType.RonaldReagan)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "AOA", "RonaldReagan"));
			else if (configuration.AOATrue == AOAType.esaadrien)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "AOA", "esaadrien"));
			else if (configuration.AOATrue == AOAType.mekki)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "AOA", "mekki"));
			else if (configuration.AOATrue == AOAType.shiosakana)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "AOA", "shiosakana"));
			else if (configuration.AOATrue == AOAType.shiosakanaAlt)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "AOA", "shiosakanaAlt"));
			else if (configuration.AOATrue == AOAType.Nami)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "AOA", "Nami"));
            else if (configuration.AOATrue == AOAType.AngieDaGorl)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "AOA", "AngieDaGorl"));
            else if (configuration.AOATrue == AOAType.StupidAle)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "AOA", "StupidAle"));
            else if (configuration.AOATrue == AOAType.cielbell)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "AOA", "cielbell"));
            // Add other AOA conditions if needed.
        }
	}
}
