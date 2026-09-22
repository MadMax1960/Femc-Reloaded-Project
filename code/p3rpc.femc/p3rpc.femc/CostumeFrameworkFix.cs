using p3rpc.commonmodutils;
using Reloaded.Mod.Interfaces;
using System.Collections;
using System.Reflection;

namespace p3rpc.femc
{
	internal static class CostumeFrameworkFix
	{
		private const string CostumeFrameworkThingyBobby = "P3R.CostumeFramework";
		private const string FemcSkeletonPath = "/Game/Xrd777/Characters/Player/FemC/Femc_Skeleton.uasset";
		private const string MudkipSkillIssue = "/Game/Xrd777/Characters/Player/FemC/Femc_Winter_School_Battle.uasset";

		public static void FixDefaultPlayerCostume(IModLoader modLoader, Utils utils)
		{
			try
			{
				var costumeFramework = modLoader.GetActiveMods().FirstOrDefault(x => x.Generic.ModId == CostumeFrameworkThingyBobby)?.Mod;
				if (costumeFramework == null)
				{
					utils.Log($"Couldn't find {CostumeFrameworkThingyBobby}, so shit is broken.", System.Drawing.Color.Red);
					return;
				}
				var patched = 0;
				foreach (var defaultCostumes in FindObjectsOfType(costumeFramework, "DefaultCostumes"))
				{
					foreach (var entry in (IEnumerable)defaultCostumes)
					{
						var entryType = entry.GetType();
						if (entryType.GetProperty("Key")?.GetValue(entry)?.ToString() != "Player") continue;

						var costume = entryType.GetProperty("Value")?.GetValue(entry);
						var config = costume?.GetType().GetProperty("Config")?.GetValue(costume);
						var baseSet = SetMeshPath(config, "Base", FemcSkeletonPath);
						var costumeSet = SetMeshPath(config, "Costume", MudkipSkillIssue);
						if (baseSet && costumeSet) patched++;
					}
				}

				if (patched == 0)
					utils.Log($"Couldn't find {CostumeFrameworkThingyBobby}'s default Player costume, so shit is once again broke.", System.Drawing.Color.Red);
				else
					utils.Log($"CF fix worky");
			}
			catch (Exception ex)
			{
				utils.Log($"How", System.Drawing.Color.Red);
			}
		}

		private static bool SetMeshPath(object? config, string part, string path)
		{
			var parts = config?.GetType().GetProperty(part)?.GetValue(config);
			var meshPath = parts?.GetType().GetProperty("MeshPath");
			if (meshPath == null) return false;

			meshPath.SetValue(parts, path);
			return true;
		}

		private static List<object> FindObjectsOfType(object root, string typeName)
		{
			var assembly = root.GetType().Assembly;
			var found = new List<object>();
			var visited = new HashSet<object>(ReferenceEqualityComparer.Instance);
			var pending = new Queue<object>();
			pending.Enqueue(root);

			while (pending.TryDequeue(out var obj))
			{
				if (!visited.Add(obj)) continue;
				if (obj.GetType().Name == typeName)
				{
					found.Add(obj);
					continue;
				}

				for (var type = obj.GetType(); type != null && type.Assembly == assembly; type = type.BaseType)
				{
					foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.DeclaredOnly))
					{
						if (field.FieldType.IsValueType || field.FieldType.IsPointer || field.FieldType.IsFunctionPointer) continue;

						var value = field.GetValue(obj);
						if (value != null && !value.GetType().IsValueType && value.GetType().Assembly == assembly)
							pending.Enqueue(value);
					}
				}
			}

			return found;
		}
	}
}
