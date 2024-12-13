using p3rpc.femc.Configuration;
using Reloaded.Mod.Interfaces;
using Ryo.Interfaces;

namespace p3rpc.femc
{
	public class MusicManager
	{
		private readonly IRyoApi _ryo;
		private readonly ILogger _logger;
		private readonly IModLoader _modLoader;
		private readonly IModConfig _modConfig;
		private readonly Config _configuration;
		private readonly FemcContext _context;

		public MusicManager(IModLoader modLoader, IModConfig modConfig, Config configuration, IRyoApi ryo, ILogger logger, FemcContext context)
		{
			_modLoader = modLoader;
			_modConfig = modConfig;
			_configuration = configuration;
			_ryo = ryo;
			_logger = logger;
			_context = context;
		}

		public void GenerateMusicScript()
		{
			try
			{
				_logger.WriteLineAsync("Regenerating music script");

				string path = _modLoader.GetDirectoryForModId(_modConfig.ModId) + "\\BGM\\BGM.acb\\";
				var nightmusic = new Dictionary<string, bool>
				{
					{Path.Combine(path,"Mosq\\link_97.cue"),_configuration.FemNight},
                    {Path.Combine(path,"Pealeaf\\link_97.cue"),_configuration.PeaColNight},
                    {Path.Combine(path,"Mineformer\\link_97.cue"),_configuration.MidNight},
					{Path.Combine(path,"Gabi\\link_97.cue"),_configuration.GabiFemNight},
					{Path.Combine(path,"Mosq\\NightWanderer\\link_97.cue"),_configuration.NightWand},
					{Path.Combine(path,"Reload\\link_97.cue"),_configuration.ColNight}
				};
				foreach (KeyValuePair<string, bool> nm in nightmusic)
				{
					if (nm.Value)
						_ryo.AddAudioFolder(nm.Key);
				}

				var dayin1music = new Dictionary<string, bool>
				{
					{Path.Combine(path, "Mosq\\link_50.cue"),_configuration.TimeSchool},
					{Path.Combine(path,   "Gabi\\link_50.cue"),_configuration.GabiTimeSchool},
					{Path.Combine(path,   "Reload\\link_50.cue"),_configuration.WantClose}
				};
				foreach (KeyValuePair<string, bool> di1m in dayin1music)
				{
					if (di1m.Value)
						_ryo.AddAudioFolder(di1m.Key);
				}

				var dayin2music = new Dictionary<string, bool>
				{
					{Path.Combine(path, "Mosq\\link_51.cue"),_configuration.Sun},
                    {Path.Combine(path, "Mineformer\\link_51.cue"),_configuration.SunMForm},
                    {Path.Combine(path, "Reload\\link_51.cue"),_configuration.Seasons}
				};
				foreach (KeyValuePair<string, bool> di2m in dayin2music)
				{
					if (di2m.Value)
						_ryo.AddAudioFolder(di2m.Key);
				}

				var dayout1music = new Dictionary<string, bool>
				{
					{Path.Combine(path, "Mosq\\link_25.cue"),_configuration.WayOfLife},
					{Path.Combine(path, "Jen\\link_25.cue"),_configuration.WayOfLifeJen},
					{Path.Combine(path, "SuperMPlush\\link_25.cue"),_configuration.WayLifeVocal},
                    {Path.Combine(path, "Reload\\link_25.cue"),_configuration.Moon}
                };
				foreach (KeyValuePair<string, bool> do1m in dayout1music)
				{
					if (do1m.Value)
						_ryo.AddAudioFolder(do1m.Key);
				}

				var finalbattlemusic = new Dictionary<string, bool>
				{
					{Path.Combine(path, "Karma\\link_29.cue"),_configuration.SoulPK},
					{Path.Combine(path, "Reload\\link_29.cue"),_configuration.BMD}
				};
				foreach (KeyValuePair<string, bool> fbm in finalbattlemusic)
				{
					if (fbm.Value)
						_ryo.AddAudioFolder(fbm.Key);
				}

				var sociallinkmusic = new Dictionary<string, bool>
				{
					{Path.Combine(path, "Mosq\\link_38.cue"),_configuration.AfterSchool},
					{Path.Combine(path, "Mosq\\link_43.cue"),_configuration.AfterSchool},
					{Path.Combine(path, "Reload\\link_38.cue"),_configuration.Joy},
					{Path.Combine(path, "Reload\\link_43.cue"),_configuration.Joy}
				};
				foreach (KeyValuePair<string, bool> sm in sociallinkmusic)
				{
					if (sm.Value)
						_ryo.AddAudioFolder(sm.Key);
				}

				var bosslinkmusic = new Dictionary<string, bool>
				{
					{Path.Combine(path, "Mosq\\link_129.cue"),_configuration.BMSF},
					{Path.Combine(path, "Mosq\\link_27.cue"),_configuration.BMSF},
					{Path.Combine(path, "Reload\\link_129.cue"),_configuration.BMS},
					{Path.Combine(path, "Reload\\link_27.cue"),_configuration.BMS}
				};
				foreach (KeyValuePair<string, bool> sm in bosslinkmusic)
				{
					if (sm.Value)
						_ryo.AddAudioFolder(sm.Key);
				}

				var disadvantagemusic = new Dictionary<string, bool>
				{
					{Path.Combine(path, "Mosq\\link_31.cue"),_configuration.MosqDis},
					{Path.Combine(path, "Karma\\link_31.cue"),_configuration.KarmaDis},
					{Path.Combine(path, "Satella&GillStudio\\link_31.cue"),_configuration.SgDis},
					{Path.Combine(path, "Reload\\link_31.cue"),_configuration.MasterTar},
					{Path.Combine(path, "EidieK87\\link_31.cue"),_configuration.EidDis}
				};
				foreach (KeyValuePair<string, bool> ds in disadvantagemusic)
				{
					if (ds.Value)
						_ryo.AddAudioFolder(ds.Key);
				}

				var normalmusic = new Dictionary<string, bool>
				{
					{Path.Combine(path, "Mosq\\link_26.cue"),_configuration.MosqNom},
					{Path.Combine(path, "Karma\\link_26.cue"),_configuration.KarmaNom},
					{Path.Combine(path, "Satella&GillStudio\\link_26.cue"),_configuration.SgNom},
					{Path.Combine(path, "Reload\\link_26.cue"),_configuration.MassDes},
				};
				foreach (KeyValuePair<string, bool> nm in normalmusic)
				{
					if (nm.Value)
						_ryo.AddAudioFolder(nm.Key);
				}

				var advantagemusic = new Dictionary<string, bool>
				{
					{Path.Combine(path, "Mosq\\link_128.cue"),_configuration.MosqAdv},
					{Path.Combine(path, "Karma\\link_128.cue"),_configuration.KarmaAdv},
					{Path.Combine(path, "Reload\\link_128.cue"),_configuration.ItGoingDown},
					{Path.Combine(path, "Jen\\link_128.cue"),_configuration.JenAdv},
					{Path.Combine(path, "EidieK87\\link_128.cue"),_configuration.EidAdv}
				};
				foreach (KeyValuePair<string, bool> asm in advantagemusic)
				{
					if (asm.Value)
						_ryo.AddAudioFolder(asm.Key);
				}
			}
			catch (Exception ex)
			{
				_context._utils.Log($"An error occurred while trying to generate the music script: \"{ex.Message}\"", System.Drawing.Color.Red);
			}
		}
	}
}
