using System.IO;
using p3rpc.femc.Configuration;
using UnrealEssentials.Interfaces;
using static p3rpc.femc.Configuration.Config;

namespace p3rpc.femc
{
	public static class BustupLoader
	{
		public static void LoadBustups(IUnrealEssentials unrealEssentials, Config configuration, string modLocation)
		{
			// Each condition corresponds to a different bustup folder.
			if (configuration.BustupTrue == BustupType.Neptune)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "Neptune"));
			else if (configuration.BustupTrue == BustupType.Ely)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "Ely"));
			else if (configuration.BustupTrue == BustupType.Esa)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "Esa"));
			else if (configuration.BustupTrue == BustupType.Betina)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "Betina"));
			else if (configuration.BustupTrue == BustupType.Anniversary)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "25thAnniversary"));
			else if (configuration.BustupTrue == BustupType.JustBlue)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "JustBlue"));
			else if (configuration.BustupTrue == BustupType.Sav)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "Sav"));
			else if (configuration.BustupTrue == BustupType.Doodled)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "Doodled"));
			else if (configuration.BustupTrue == BustupType.RonaldReagan)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "RonaldReagan"));
			else if (configuration.BustupTrue == BustupType.ElyAlt)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "ElyAlt"));
			else if (configuration.BustupTrue == BustupType.Yuunagi)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "Yuunagi"));
			else if (configuration.BustupTrue == BustupType.cielbell)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "cielbell"));
			else if (configuration.BustupTrue == BustupType.axolotl)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "axolotl"));
			else if (configuration.BustupTrue == BustupType.ghostedtoast)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "ghostedtoast"));
			else if (configuration.BustupTrue == BustupType.Strelko)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "Strelko"));
			else if (configuration.BustupTrue == BustupType.gackt)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "gackt"));
			else if (configuration.BustupTrue == BustupType.Jackie)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "Jackie"));
			else if (configuration.BustupTrue == BustupType.Lisa)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "Lisa9388"));
			else if (configuration.BustupTrue == BustupType.BetaFemcByMae)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "BetaFemcByMae"));
			else if (configuration.BustupTrue == BustupType.crezzstar)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "crezzstar"));
			else if (configuration.BustupTrue == BustupType.AngieDaGorl)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "AngieDaGorl"));
			else if (configuration.BustupTrue == BustupType.namiweiko)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "namiweiko"));
			else if (configuration.BustupTrue == BustupType.chitu)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "chitu"));
			else if (configuration.BustupTrue == BustupType.crezzstarAlt)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "crezzstarAlt"));
			else if (configuration.BustupTrue == BustupType.shiosakana)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "shiosakana"));
            else if (configuration.BustupTrue == BustupType.samythecoolkid)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "samythecoolkid"));
            else if (configuration.BustupTrue == BustupType.Mixi_xiMi)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "Mixi_xiMi"));
            else if (configuration.BustupTrue == BustupType.StupidAle)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "stupidale"));
            else if (configuration.BustupTrue == BustupType.Kiara)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Bustup", "Kiara"));
        }
	}
}