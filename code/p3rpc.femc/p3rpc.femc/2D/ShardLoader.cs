using System.IO;
using p3rpc.femc.Configuration;
using UnrealEssentials.Interfaces;
using static p3rpc.femc.Configuration.Config;

namespace p3rpc.femc
{
	public static class ShardLoader
	{
		public static void LoadShardAssets(IUnrealEssentials unrealEssentials, Config configuration, string modLocation)
		{
			if (configuration.ShardTrue == ShardType.Esa)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Shard", "Esa"));
			else if (configuration.ShardTrue == ShardType.Ely)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Shard", "Ely"));
			else if (configuration.ShardTrue == ShardType.ElyAlt)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Shard", "ElyAlt"));
			else if (configuration.ShardTrue == ShardType.Shiosakana)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Shard", "Shiosakana"));
			else if (configuration.ShardTrue == ShardType.namiweiko)
				unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Shard", "namiweiko"));
            else if (configuration.ShardTrue == ShardType.AngieDaGorl)
                unrealEssentials.AddFromFolder(Path.Combine(modLocation, "2d", "Shard", "AngieDaGorl"));
            // Add other Shard conditions if needed.
        }
	}
}
