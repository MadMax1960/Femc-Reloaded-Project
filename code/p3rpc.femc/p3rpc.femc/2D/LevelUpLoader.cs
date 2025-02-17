using System.IO;
using p3rpc.femc.Configuration;
using UnrealEssentials.Interfaces;
using static p3rpc.femc.Configuration.Config;

namespace p3rpc.femc
{
	public static class LevelUpLoader
	{
		public static void LoadLevelUpAssets(IUnrealEssentials unrealEssentials, Config configuration, string modLocation)
		{
			if (configuration.LevelUpTrue == LevelUpType.Esa)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "LevelUp", "Esa"));
			else if (configuration.LevelUpTrue == LevelUpType.Ely)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "LevelUp", "Ely"));
			else if (configuration.LevelUpTrue == LevelUpType.shiosakana)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "LevelUp", "shiosakana"));
			else if (configuration.LevelUpTrue == LevelUpType.ElyAlt)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "LevelUp", "ElyAlt"));
            else if (configuration.LevelUpTrue == LevelUpType.AngieDaGorl)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "LevelUp", "AngieDaGorl"));
            // Add other LevelUp conditions if needed.
        }
	}
}
