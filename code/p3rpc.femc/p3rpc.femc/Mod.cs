using p3rpc.commonmodutils;
using p3rpc.femc.Components;
using p3rpc.femc.Configuration;
using p3rpc.femc.Template;
using Reloaded.Hooks.Definitions;
using Reloaded.Memory;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using SharedScans.Interfaces;
using System.Diagnostics;
using UnrealEssentials.Interfaces;
using Unreal.ObjectsEmitter.Interfaces;
using static p3rpc.femc.Configuration.Config;
using p3rpc.classconstructor.Interfaces;
using BGME.BattleThemes.Interfaces;
using BGME.BattleThemes.Config;
using Ryo.Interfaces;
using System.IO;


/// ok maybe p3rpc.femc.music.interfaces is required, but it's not in repo and randomization doesn't work leading me to believe they're connected, or randomization never worked idk

namespace p3rpc.femc
{
	/// <summary>
	/// Your mod logic goes here.
	/// </summary>
	public class Mod : ModBase // <= Do not Remove.
	{
		/// <summary>
		/// Provides access to the mod loader API.
		/// </summary>
		private readonly IModLoader _modLoader;

		/// <summary>
		/// Provides access to the Reloaded.Hooks API.
		/// </summary>
		/// <remarks>This is null if you remove dependency on Reloaded.SharedLib.Hooks in your mod.</remarks>
		private readonly IReloadedHooks? _hooks;

		/// <summary>
		/// Provides access to the Reloaded logger.
		/// </summary>
		private readonly ILogger _logger;

		/// <summary>
		/// Entry point into the mod, instance that created this class.
		/// </summary>
		private readonly IMod _owner;

		/// <summary>
		/// Provides access to this mod's configuration.
		/// </summary>
		private Config _configuration;

		/// <summary>
		/// The configuration of the currently executing mod.
		/// </summary>
		private readonly IModConfig _modConfig;
		private FemcContext _context;
		private ModuleRuntime<FemcContext> _modRuntime;
		private readonly IUnreal unreal;
        private readonly ThemeConfig themeConfig;


        private string modName { get; set; }

		public Mod(ModContext context)
		{
            _modLoader = context.ModLoader;
			_hooks = context.Hooks;
			_logger = context.Logger;
			_owner = context.Owner;
			_configuration = context.Configuration;
			_modConfig = context.ModConfig;
            // Get dependencies and initialize context
            var mainModule = Process.GetCurrentProcess().MainModule;
			if (mainModule == null) throw new Exception($"[{_modConfig.ModName}] Could not get main module (this should never happen)");
			var baseAddress = mainModule.BaseAddress;
            unreal = GetDependency<IUnreal>("Unreal Objects Emitter");
			var startupScanner = GetDependency<IStartupScanner>("Reloaded Startup Scanner");
			if (_hooks == null) throw new Exception($"[{_modConfig.ModName}] Could not get controller for Reloaded hooks");
			var sharedScans = GetDependency<ISharedScans>("Shared Scans");
			Utils utils = new(startupScanner, _logger, _hooks, baseAddress, "Femc Project", System.Drawing.Color.Thistle, _configuration.DebugLogLevel);
			var unrealEssentials = GetDependency<IUnrealEssentials>("Unreal Essentials");
			var classMethods = GetDependency<IClassMethods>("Class Constructor (Class Methods)");
            var objectMethods = GetDependency<IObjectMethods>("Class Constructor (Object Methods)");
            var ryo = GetDependency<IRyoApi>("Ryo");
            var memory = new Memory();
            this.themeConfig = new ThemeConfig(this._modLoader, this._modConfig, this._configuration, this._logger);
            _context = new(baseAddress, _configuration, _logger, startupScanner, _hooks, _modLoader.GetDirectoryForModId(_modConfig.ModId), utils, memory, sharedScans, classMethods, objectMethods);
			_modRuntime = new(_context);

			modName = _modConfig.ModName;
			// Load Modules/assets
			LoadEnabledAddons(unrealEssentials, ryo);
			InitializeModules();
			GenerateMusicScript();
			RedirectPlayerAssets();
		}

		private IControllerType GetDependency<IControllerType>(string modName) where IControllerType : class
		{
			var controller = _modLoader.GetController<IControllerType>();
			if (controller == null || !controller.TryGetTarget(out var target))
				throw new Exception($"[{_modConfig.ModName}] Could not get controller for \"{modName}\". This depedency is likely missing.");
			return target;

		}

        private void LoadEnabledAddons(IUnrealEssentials unrealEssentials, IRyoApi ryo)
		{
			try
			{
				if (_configuration.HairTrue == HairType.MudkipsHair)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "hair", "MudkipHair"));
				else if (_configuration.HairTrue == HairType.KotoneBeanHair)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "hair", "NaobeanHair"));

				if (_configuration.AOATrue == AOAType.Ely)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "Ely"));
				else if (_configuration.AOATrue == AOAType.Chrysanthie)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "Chrysanthie"));
				else if (_configuration.AOATrue == AOAType.Fernando)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "Fernando"));
				else if (_configuration.AOATrue == AOAType.Monica)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "Monica"));
				else if (_configuration.AOATrue == AOAType.RonaldReagan)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "RonaldReagan"));
				else if (_configuration.AOATrue == AOAType.esaadrien)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "esaadrien"));
				else if (_configuration.AOATrue == AOAType.mekki)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "mekki"));
				else if (_configuration.AOATrue == AOAType.shiosakana)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "shiosakana"));
				else if (_configuration.AOATrue == AOAType.shiosakanaAlt)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOA", "shiosakanaAlt"));

				if (_configuration.AOAText == AOATextType.DontLookBack)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOAText", "DontLookBack"));
				else if (_configuration.AOAText == AOATextType.SorryBoutThat)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOAText", "SorryBoutThat"));
				else if (_configuration.AOAText == AOATextType.PerfectlyAccomplished)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOAText", "PerfectlyAccomplished"));

				if (_configuration.BustupTrue == BustupType.Neptune)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Neptune"));
				else if (_configuration.BustupTrue == BustupType.Ely)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Ely"));
				else if (_configuration.BustupTrue == BustupType.Esa)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Esa"));
				else if (_configuration.BustupTrue == BustupType.Betina)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Betina"));
				else if (_configuration.BustupTrue == BustupType.Anniversary)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "25thAnniversary"));
				else if (_configuration.BustupTrue == BustupType.JustBlue)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "JustBlue"));
				else if (_configuration.BustupTrue == BustupType.Sav)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Sav"));
				else if (_configuration.BustupTrue == BustupType.Doodled)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Doodled"));
				else if (_configuration.BustupTrue == BustupType.RonaldReagan)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "RonaldReagan"));
				else if (_configuration.BustupTrue == BustupType.ElyAlt)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "ElyAlt"));
				else if (_configuration.BustupTrue == BustupType.Yuunagi)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Yuunagi"));
				else if (_configuration.BustupTrue == BustupType.cielbell)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "cielbell"));
				else if (_configuration.BustupTrue == BustupType.axolotl)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "axolotl"));
				else if (_configuration.BustupTrue == BustupType.ghostedtoast)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "ghostedtoast"));
				else if (_configuration.BustupTrue == BustupType.Strelko)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Strelko"));
				else if (_configuration.BustupTrue == BustupType.gackt)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "gackt"));
				else if (_configuration.BustupTrue == BustupType.Jackie)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Jackie"));
				else if (_configuration.BustupTrue == BustupType.Lisa)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "Lisa9388"));
				else if (_configuration.BustupTrue == BustupType.BetaFemcByMae)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Bustup", "BetaFemcByMae"));



				if (_configuration.ShardTrue == ShardType.Esa)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Shard", "Esa"));
				else if (_configuration.ShardTrue == ShardType.Ely)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Shard", "Ely"));
				else if (_configuration.ShardTrue == ShardType.ElyAlt)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Shard", "ElyAlt"));
				else if (_configuration.ShardTrue == ShardType.Shiosakana)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Shard", "Shiosakana"));

				if (_configuration.LevelUpTrue == LevelUpType.Esa)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "LevelUp", "Esa"));
				else if (_configuration.LevelUpTrue == LevelUpType.Ely)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "LevelUp", "Ely"));
				
				if (_configuration.PartyPanelTrue == PartyPanelType.Kris)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "PartyPanel", "Kris"));
				else if (_configuration.PartyPanelTrue == PartyPanelType.Esa)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "PartyPanel", "Esa"));

				if (_configuration.CutinTrue == CutinType.berrycha)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Cutin", "berrycha"));
				else if (_configuration.CutinTrue == CutinType.ElyandPatmandx)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Cutin", "ElyandPatmandx"));


				if (_configuration.KotoneRoom)
				{
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Fun Stuff", "Kotone Room"));
				}

				//if (_configuration.FunnyAnims)
				{
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Fun Stuff", "Funny Anims"));
				}

				//if (!_configuration.FunnyAnims)
				{
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Fun Stuff", "Funny Animsog")); // game dies when 2 files loaded, this has the og files we had in mod but in their own folder, the ! is if the bool is disabled
				}

				if (_configuration.GregoryHouseRatPoisonDeliverySystem)
				{
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Fun Stuff", "GregoryHouseRatPoisonDeliverySystem"));
				}

				if (!_configuration.GregoryHouseRatPoisonDeliverySystem)
				{
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Fun Stuff", "GregoryHouseRatPoisonDeliverySystemog")); // game dies when 2 files loaded, this has the og files we had in mod but in their own folder, the ! is if the bool is disabled
				}

                if (_configuration.TheodorefromAlvinandTheChipmunks)
                {
                    unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Theo", "TheodorefromAlvinandTheChipmunks"));
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Theo", "cutin", "mekkipatman"));
					ryo.AddAudioFolder(_modLoader.GetDirectoryForModId(_modConfig.ModId) + "/Theo/voice/Landon");

				}

				if (_configuration.SkirtEtcFix)
				{
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "TestSkeleton"));
				}

				if (_configuration.NagiWeap)
				{
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "Nagitana"));
				}

				if (_configuration.AnimTrue == AnimType.OriginalAnims)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "Anims", "Original Dummy"));
				else if (_configuration.AnimTrue == AnimType.CustomAnims)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "Anims", "Custom Anims"));
				else if (_configuration.AnimTrue == AnimType.VeryFunnyAnims)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "3d", "Anims", "Very Funny Anims"));
				if (_configuration.bluehairandpronounce)
					ryo.AddAudioFolder(_modLoader.GetDirectoryForModId(_modConfig.ModId) + "/Voice");
					

			}
			catch (Exception ex)
			{
				_context._utils.Log($"An error occured trying to read addons: \"{ex.Message}\"", System.Drawing.Color.Red);
			}
		}
        private void BattleMusicGeneration()
		{
			//Do nothing as the old function is deprecated but still being kept till testing is done
		}

        private void BattleMusicGenerationDeprecated() // this should be battle themes man
        {
			throw new Exception("The BattleMusicGeneration Function was run. This is now deprecated but still kept in the code till testing is done.");
			try
			{
                var battlethemes = GetDependency<IBattleThemesApi>("Battle Themes");
                string path = _modLoader.GetDirectoryForModId(_modConfig.ModId) + "/BGM/";
                battlethemes.RemovePath(path);
                string advantage = "const adv_music=[";
                string normal = "const nom_music=[";
                string disadvantage = "const dis_music=[";
                var added = new Dictionary<string, int>
				{
					{"advantage",0},
					{"normal",0},
					{"disadvantage",0}
				};
                var collection = new Dictionary<string, Tuple<string, bool>>
				{
					{"p3r_MPTTR", new Tuple<string, bool>("advantage", _configuration.MosqAdv)},
					{"p3r_KPPTR", new Tuple<string, bool>("advantage", _configuration.KarmaAdv)},
					{"p3r_EPTTR", new Tuple<string, bool>("advantage", _configuration.Eidadv)},
					{"p3r_MWPAO", new Tuple<string, bool>("normal", _configuration.MosqNom)},
					{"p3r_KWPAO", new Tuple<string, bool>("normal", _configuration.Karmanom)},
					{"p3r_SGWPAO", new Tuple<string, bool>("normal", _configuration.Sgnom)},
					{"p3r_MDZ", new Tuple<string, bool>("disadvantage", _configuration.Mosqdis)},
					{"p3r_KDZ", new Tuple<string, bool>("disadvantage", _configuration.Karmadis)},
					{"p3r_EDZ", new Tuple<string, bool>("disadvantage", _configuration.Eddis)},
					{"p3r_SGDZ", new Tuple<string, bool>("disadvantage", _configuration.Sgdis)},
					{"p3r_ITS", new Tuple<string, bool>("advantage", _configuration.ItGoingDown)},
					{"p3r_MSD", new Tuple<string, bool>("normal", _configuration.MassDes)},
					{"p3r_MAT", new Tuple<string, bool>("disadvantage", _configuration.MasterTar)}
				};

                foreach (KeyValuePair<string, Tuple<string, bool>> col in collection)
                {
                    if (col.Value.Item2)
                    {
                        if (col.Value.Item1 == "advantage")
                        {
                            if (added[col.Value.Item1] == 0)
                            {
                                advantage += col.Key;
                                added[col.Value.Item1] = 1;
                            }
                            else
                            {
                                advantage += "," + col.Key;
                            }
                        }
                        else if (col.Value.Item1 == "normal")
                        {
                            if (added[col.Value.Item1] == 0)
                            {
                                normal += col.Key;
                                added[col.Value.Item1] = 1;
                            }
                            else
                            {
                                normal += "," + col.Key;
                            }
                        }
                        else if (col.Value.Item1 == "disadvantage")
                        {
                            if (added[col.Value.Item1] == 0)
                            {
                                disadvantage += col.Key;
                                added[col.Value.Item1] = 1;
                            }
                            else
                            {
                                disadvantage += "," + col.Key;
                            }
                        }
						else
						{
                            _logger.WriteLineAsync("The Collection dictionary in mod.cs has been improperly configured, one of the specified categories DOES NOT exist.");
                        }
                    }
                }
                advantage += (added["advantage"] == 0) ? "p3r_MPTTR]" : "]";
                normal += (added["normal"] == 0) ? "p3r_MWPAO]" : "]";
                disadvantage += (added["disadvantage"] == 0) ? "p3r_MDZ]" : "]";
                string[] lines = { advantage, normal, disadvantage, "const BATTLE_THEME = battle_bgm(random_song(nom_music),random_song(adv_music),random_song(dis_music))" };
                if (File.Exists(path + "script" + ".theme.pme"))
                {
                    File.Delete(path + "script" + ".theme.pme");
                }
                using (StreamWriter outputFile = new StreamWriter(path + "script"))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }
                File.Move(path + "script", Path.ChangeExtension(path + "script", ".theme.pme"));
                battlethemes.AddPath(_modConfig.ModId, path);
            }
			catch(Exception ex)
			{
                _context._utils.Log($"An error occured while trying to generate the music script: \"{ex.Message}\"", System.Drawing.Color.Red);
            }
        }

        private void GenerateMusicScript()
		{
            //Author: TheBestAstroNOT
            //Credit for all the music goes to Atlus, Mosq, Mineformer, Karma, Stella and GillStudio, EidieK87, GabiShy
            try
            {
                var ryo = GetDependency<IRyoApi>("Ryo");
                BattleMusicGeneration();
                _logger.WriteLineAsync("Regenerating music script");
                //Initialise the music picker
                string path = _modLoader.GetDirectoryForModId(_modConfig.ModId) + "\\BGM\\BGM.acb\\";
                var nightmusic = new Dictionary<string, bool>
                {
                    {Path.Combine(path,"Mosq\\link_97.cue"),_configuration.FemNight},
                    {Path.Combine(path,"Mineformer\\link_97.cue"),_configuration.Midnight},
                    {Path.Combine(path,"Gabi\\link_97.cue"),_configuration.GabiFemNight},
                    {Path.Combine(path,"Mosq\\NightWanderer\\link_97.cue"),_configuration.NightWand},
					{Path.Combine(path,"Reload\\link_97.cue"),_configuration.ColNight}
                };
                foreach (KeyValuePair<string, bool> nm in nightmusic)
                {
                    if (nm.Value)
                        ryo.AddAudioFolder(nm.Key);
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
                        ryo.AddAudioFolder(di1m.Key);
                }
                var dayin2music = new Dictionary<string, bool>
                {
                    {Path.Combine(path, "Mosq\\link_51.cue"),_configuration.Sun},
                    {Path.Combine(path, "Reload\\link_51.cue"),_configuration.Seasons}
                };
                foreach (KeyValuePair<string, bool> di2m in dayin2music)
                {
                    if (di2m.Value)
                        ryo.AddAudioFolder(di2m.Key);
                }
                var dayout1music = new Dictionary<string, bool>
                {
                    {Path.Combine(path, "Mosq\\link_25.cue"),_configuration.WayOfLife},
                    {Path.Combine(path, "Jen\\link_25.cue"),_configuration.WayOfLifeJen},
                    {Path.Combine(path, "Reload\\link_25.cue"),_configuration.Moon}
                };
                foreach (KeyValuePair<string, bool> do1m in dayout1music)
                {
                    if (do1m.Value)
                        ryo.AddAudioFolder(do1m.Key);
                }
                var finalbattlemusic = new Dictionary<string, bool>
                {
                    {Path.Combine(path, "Karma\\link_29.cue"),_configuration.SoulPK},
                    {Path.Combine(path, "Reload\\link_29.cue"),_configuration.BMD}
                };
                foreach (KeyValuePair<string, bool> fbm in finalbattlemusic)
                {
                    if (fbm.Value)
                        ryo.AddAudioFolder(fbm.Key);
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
                        ryo.AddAudioFolder(sm.Key);
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
                        ryo.AddAudioFolder(sm.Key);
                }
                var disadvantagemusic = new Dictionary<string, bool>
                {
                    {Path.Combine(path, "Mosq\\link_31.cue"),_configuration.Mosqdis},
                    {Path.Combine(path, "Karma\\link_31.cue"),_configuration.Karmadis},
                    {Path.Combine(path, "Satella&GillStudio\\link_31.cue"),_configuration.Sgdis},
                    {Path.Combine(path, "Reload\\link_31.cue"),_configuration.MasterTar},
                    {Path.Combine(path, "EidieK87\\link_31.cue"),_configuration.Eiddis}
                };
                foreach (KeyValuePair<string, bool> ds in disadvantagemusic)
                {
                    if (ds.Value)
                        ryo.AddAudioFolder(ds.Key);
                }
				var normalmusic = new Dictionary<string, bool>
                {
                    {Path.Combine(path, "Mosq\\link_26.cue"),_configuration.MosqNom},
                    {Path.Combine(path, "Karma\\link_26.cue"),_configuration.Karmanom},
                    {Path.Combine(path, "Satella&GillStudio\\link_26.cue"),_configuration.Sgnom},
                    {Path.Combine(path, "Reload\\link_26.cue"),_configuration.MassDes},
                };
                foreach (KeyValuePair<string, bool> nm in normalmusic)
                {
                    if (nm.Value)
                        ryo.AddAudioFolder(nm.Key);
                }
                var advantagemusic = new Dictionary<string, bool>
                {
                    {Path.Combine(path, "Mosq\\link_128.cue"),_configuration.MosqAdv},
                    {Path.Combine(path, "Karma\\link_128.cue"),_configuration.KarmaAdv},
                    {Path.Combine(path, "Reload\\link_128.cue"),_configuration.ItGoingDown},
                    {Path.Combine(path, "Jen\\link_128.cue"),_configuration.Jenadv},
                    {Path.Combine(path, "EidieK87\\link_128.cue"),_configuration.Eidadv}
                };
                foreach (KeyValuePair<string, bool> asm in advantagemusic)
                {
                    if (asm.Value)
                        ryo.AddAudioFolder(asm.Key);
                }
            }
            catch (Exception ex)
            {
                _context._utils.Log($"An error occured while trying to generate the music script: \"{ex.Message}\"", System.Drawing.Color.Red);
            } // this should just be ryo bruh it could be bools
        }


        private void InitializeModules()
		{
			_modRuntime.AddModule<UICommon>();
			if (_configuration.EnableMailIcon) _modRuntime.AddModule<MailIcon>();
			if (_configuration.EnableCampMenu)
			{
				_modRuntime.AddModule<CampCommon>();
				_modRuntime.AddModule<CampRoot>();
				_modRuntime.AddModule<CampSkill>();
				_modRuntime.AddModule<CampItem>();
				_modRuntime.AddModule<CampEquip>();
				_modRuntime.AddModule<CampPersona>();
				_modRuntime.AddModule<CampStats>();
				_modRuntime.AddModule<CampSocialLink>();
				_modRuntime.AddModule<CampCalendar>();
				_modRuntime.AddModule<CampSystem>();
				_modRuntime.AddModule<SocialStats>();
				_modRuntime.AddModule<Tutorial>();
				_modRuntime.AddModule<MissingPerson>();
			}
			if (_configuration.EnableDateTimePanel) _modRuntime.AddModule<DateTimePanel>();
			if (_configuration.EnableTextbox)
			{
				_modRuntime.AddModule<MsgWindowSimpleCommon>();
				_modRuntime.AddModule<MsgWindowSimple>();
				_modRuntime.AddModule<MsgWindowSelectSimple>();
				_modRuntime.AddModule<MsgWindowAssist>();
				_modRuntime.AddModule<MsgWindowSystem>();
				_modRuntime.AddModule<GenericSelect>();
			}
			if (_configuration.EnableMindMessageBox)
			{
				_modRuntime.AddModule<MsgWindowMind>();
				_modRuntime.AddModule<MsgWindowSelectMind>();
			}
			if (_configuration.EnableInteractPrompt) _modRuntime.AddModule<MiscCheckDraw>();
			if (_configuration.EnableMinimap)
			{
				_modRuntime.AddModule<Minimap>();
				_modRuntime.AddModule<LocationSelect>();
			}
			if (_configuration.EnableBustup)
			{
				_modRuntime.AddModule<Bustup>();
			}
			if (_configuration.EnableMessageScript)
			{
				_modRuntime.AddModule<MessageScript>();
			}
			if (_configuration.EnableTownMap) _modRuntime.AddModule<TownMap>();
			if (_configuration.EnablePartyPanel) _modRuntime.AddModule<PartyPanel>();
			if (_configuration.EnableBacklog) _modRuntime.AddModule<Backlog>();
			if (_configuration.EnableButtonPrompts) _modRuntime.AddModule<KeyHelp>();
			if (_configuration.EnableGetItem) _modRuntime.AddModule<MiscGetItemDraw>();
			if (_configuration.EnableTimeSkip)
			{
				_modRuntime.AddModule<DayChange>();
				_modRuntime.AddModule<TimeChange>();
			}
			if (_configuration.EnablePersonaStatus) _modRuntime.AddModule<PersonaStatus>();
			if (_configuration.EnableNetworkFeatures)
			{
				_modRuntime.AddModule<VoiceAction>();
				_modRuntime.AddModule<VoiceAnswer>();
			}
			if (_configuration.EnableShop)
			{
				_modRuntime.AddModule<SimpleShop>();
				_modRuntime.AddModule<MiscMoneyDraw>();
			}
			if (_configuration.EnableCutin) _modRuntime.AddModule<Cutin>();
			if (_configuration.EnableTitleMenu)
			{
				_modRuntime.AddModule<TitleMenu>();
				_modRuntime.AddModule<DifficultySelection>();
			}
			if (_configuration.EnableStaffRoll)
			{
				_modRuntime.AddModule<LocalizationStaffRoll>();
				//_modRuntime.AddModule<StaffRoll>();
			}
			if (_configuration.EnableWipe) _modRuntime.AddModule<Wipe>();
			_modRuntime.RegisterModules();
        }
	

		// ADD ASSET REDIRECTS HERE.
		private void RedirectPlayerAssets()
		{
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_F000", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_F999"); // face
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H000", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_H999"); // hair
			// this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H000", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_H998"); // aigis hair
			this.RedirectAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_CombineAnim", "/Game/Xrd777/Characters/Data/DataAsset/Player/PC0002/DA_PC0002_CombineAnim"); // idk what this is, its something
			this.RedirectAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_CommonAnim", "/Game/Xrd777/Characters/Data/DataAsset/Player/PC0002/DA_PC0002_CommonAnim"); // common anim stuff, walking, sitting, griddying, etc
			//this.RedirectAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_EventAnim", "/Game/Xrd777/Characters/Data/DataAsset/Player/PC0002/DA_PC0002_EventAnim"); // Event anims, so specific events, probably why velvet room dies tbqh
			this.RedirectAsset("/Game/Xrd777/Characters/Data/DataAsset/Player/PC0001/DA_PC0001_FaceAnim", "/Game/Xrd777/Characters/Data/DataAsset/Player/PC0002/DA_PC0002_FaceAnim"); // read the filename to my left
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/ABP_PC0001", "/Game/Xrd777/Characters/Player/PC0002/ABP_PC0002"); // might omega die
			// this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/AnmCommon/A_PC0001_CMA0055_ADDP_BagLNoPocket", "/Game/Xrd777/Characters/Player/PC0002/AnmCommon/A_PC0002_CMA0056_ADDP_BagL"); // might die 
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/AnmCommon/A_PC0001_CMA0056_ADDP_BagL", "/Game/Xrd777/Characters/Player/PC0002/AnmCommon/A_PC0002_CMA0056_ADDP_BagL"); // might die 2
			//this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/AnmCommon/A_PC0001_CMA0063_ADDP_TravelBagL", "/Game/Xrd777/Characters/Player/PC0002/AnmCommon/A_PC0002_CMA0056_ADDP_BagL"); // might die 3
			//this.RedirectAsset("/Game/Xrd777/Blueprints/Characters/Player/Bag/BP_AppCharBag_0001_000", "/Game/Xrd777/Blueprints/Characters/Player/Bag/BP_AppCharBag_0002_000"); // idk what these 2 do
			//this.RedirectAsset("/Game/Xrd777/Blueprints/Characters/Player/Bag/BP_AppCharBag_0001_099", "/Game/Xrd777/Blueprints/Characters/Player/Bag/BP_AppCharBag_0002_001"); // this is the 2nd 
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_BaseSkelton", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_BaseSkelton"); // trent crimm the indepedent
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C001", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C991"); // summer school I think?
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C002", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C992"); // winter school
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C005", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C993"); // summer casual
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C006", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C992"); // winter casual
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C051", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C998"); // joker persona 5 reference
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C052", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C999"); // STRETCHING SKIRT MAKE LOOK BAD :((((((((
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C101", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C985"); // idk what this is, its something though
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C102", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C986"); // idk what this is, its something though
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C103", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C982"); // bikini I think?
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C106", "/Game/Xrd777/Characters/Player/PC0005/Models/SK_PC0005_C106"); // this is something too
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C151", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C985"); // :idk:
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C154", "/Game/Xrd777/Characters/Player/PC0005/Models/SK_PC0005_C154"); // never gonna give you up, never gonna let you down
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C155", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C155"); // yukata i believe
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C158", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C983"); // idk
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C159", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C970"); // dorm apron
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C160", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C984"); // idk
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C161", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C980"); // work outfit for something
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C162", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C981"); // something
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C501", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C996"); //not  rise
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C502", "/Game/Xrd777/Characters/Player/PC0005/Models/SK_PC0005_C502"); // mitsuru shujin redirect
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C503", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C997"); // not best outfit, its naoto, look at her go, i need to use new yuha textures for coat (and maybe make textures for pants and hat while I wait, but either way its naoto, look at that woah, wow, naoto, noot, shirogane, tiny person, little short tiny not tall detective 
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H158", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_H999"); // hair
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H501", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_H999"); // hair 2 (3 technically)
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H159", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_H998"); // yuha hair 3 (4 technically)
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C504", "/Game/Xrd777/Characters/Player/PC0006/Models/SK_PC0006_C504");
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H504", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_H999"); // forgor velvet hair
			// saori and rio will be added as dummy slots, idk who they will replace yet, probably kaz or something 
			// theo will need to be redirected here 



		}

		private void RedirectAsset(string ogAssetPath, string newAssetPath)
		{
			var ogFnames = new AssetFNames(ogAssetPath);
			var newFnames = new AssetFNames(newAssetPath);

			this.unreal.AssignFName(modName, ogFnames.AssetName, newFnames.AssetName);
			this.unreal.AssignFName(modName, ogFnames.AssetPath, newFnames.AssetPath);
		}

		#region Standard Overrides
		public override void ConfigurationUpdated(Config configuration)
		{
			// Apply settings from configuration.
			// ... your code here.
			_configuration = configuration;
			_logger.WriteLine($"[{_modConfig.ModId}] Config Updated: Applying");
			_modRuntime.UpdateConfiguration(configuration);
        }
		#endregion

		#region For Exports, Serialization etc.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public Mod() { }
#pragma warning restore CS8618
		#endregion
	}
}

internal static class AssetUtils
{
	/// <summary>
	/// Gets the expected asset file for the given character's costume ID and asset type.
	/// </summary>
	/// <param name="character">Character.</param>
	/// <param name="costumeId">Costume ID.</param>
	/// <param name="type">Asset type.</param>
	/// <returns></returns>
	public static string GetAssetPath(Character character, AssetType type, int costumeId = 0)
		=> type switch
		{
			AssetType.BaseMesh => FormatAssetPath($"/Game/Xrd777/Characters/Player/PC{FormatCharId(character)}/Models/SK_PC{FormatCharId(character)}_BaseSkelton", character),
			AssetType.CostumeMesh => FormatAssetPath($"/Game/Xrd777/Characters/Player/PC{FormatCharId(character)}/Models/SK_PC{FormatCharId(character)}_C{costumeId:000}", character),
			AssetType.HairMesh => FormatAssetPath($"/Game/Xrd777/Characters/Player/PC{FormatCharId(character)}/Models/SK_PC{FormatCharId(character)}_H{costumeId:000}", character),
			AssetType.FaceMesh => FormatAssetPath($"/Game/Xrd777/Characters/Player/PC{FormatCharId(character)}/Models/SK_PC{FormatCharId(character)}_F{costumeId:000}", character),
			AssetType.CommonAnim => FormatAssetPath($"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{FormatCharId(character)}/DA_PC{FormatCharId(character)}_CommonAnim", character),
			AssetType.CombineAnim => FormatAssetPath($"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{FormatCharId(character)}/DA_PC{FormatCharId(character)}_CombineAnim", character),
			AssetType.EventAnim => FormatAssetPath($"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{FormatCharId(character)}/DA_PC{FormatCharId(character)}_EventAnim", character),
			AssetType.FaceAnim => FormatAssetPath($"/Game/Xrd777/Characters/Data/DataAsset/Player/PC{FormatCharId(character)}/DA_PC{FormatCharId(character)}_FaceAnim", character),
			_ => throw new Exception(),
		};

	public static string GetAssetFile(Character character, AssetType type, Outfit outfit)
		=> GetAssetPath(character, type, (int)outfit);

	/// <summary>
	/// Gets the expected asset path from asset file path.
	/// Simply removes the .uasset extension and/or adds the game content path.
	/// </summary>
	/// <param name="assetFile">Asset .uasset file path.</param>
	/// <returns>Asset path.</returns>
	public static string GetAssetPath(string assetFile)
	{
		var adjustedPath = assetFile.Replace('\\', '/').Replace(".uasset", string.Empty);

		if (adjustedPath.IndexOf("Content") is int contentIndex && contentIndex > -1)
		{
			adjustedPath = adjustedPath.Substring(contentIndex + 8);
		}

		if (!adjustedPath.StartsWith("/Game/"))
		{
			adjustedPath = $"/Game/{adjustedPath}";
		}

		return adjustedPath;
	}

	public static string FormatCharId(Character character)
		=> ((int)character).ToString("0000");

	private static string FormatAssetPath(string path, Character character)
	{
		if (character >= Character.Player && character <= Character.Shinjiro)
		{
			return path;
		}
		else
		{
			return path.Replace("PC", "SC").Replace("Player", "Sub");
		}
	}
}

public enum AssetType
{
	BaseMesh,
	CostumeMesh,
	HairMesh,
	FaceMesh,

	CommonAnim,
	CombineAnim,
	EventAnim,
	FaceAnim,
}

public enum Character
{
	NONE,
	Player,
	Yukari,
	Stupei,
	Akihiko,
	Mitsuru,
	Fuuka,
	Aigis,
	Ken,
	Koromaru,
	Shinjiro = 10,

	// Side-characters.
	////Kenji = 101,
	////Hidetoshi,
	////Bunkichi,
	////Mitsuko,
	////Kazushi,
	////Yuko,
	////Keisuke = 108,
	////Chihiro,
	//Maiko,
	//Pharos = 110,
	//Andre_Laurent_Jean_Geraux,
	//Tanaka,
	//Mutatsu,
	//Mamoru,
	//Akinari,

	//Igor = 201,
	//Elizabeth,

	//Takaya = 211,
	//Jin,
	//Chidori,

	//Ryoji = 221,
	//Ikutsuki,
	//Natsuki,
	//Takeharu,

	FEMC = 999,
}

public class CharacterConfig
{
	public CharacterBase Base { get; set; } = new();

	public CharacterAnims Animations { get; set; } = new();

	public Dictionary<Outfit, string?> Outfits { get; set; } = new();
}

public class CharacterBase
{
	public Character Character { get; set; } = Character.Player;

	public string? BaseSkeleton { get; set; }

	public string? Hair { get; set; }

	public string? Face { get; set; }
}

public class CharacterAnims
{
	public string? Common { get; set; }

	public string? Combine { get; set; }

	public string? Event { get; set; }

	public string? Face { get; set; }
}

public enum Outfit
{
	Missing = 0,
	Summer_Uniform = 1,
	Winter_Uniform = 2,
	Summer_Casual = 5,
	Winter_Casual = 6,
	Uniform_Armband = 51,
	SEES_Uniform = 52,
	Gekkoukan_Jersey = 101,
	Swimsuit = 102,
	Nightwear = 103,
	Battle_Armor = 104,
	Butler_Suit = 106,
	Track_Team_Shirt = 151,
	Hot_Springs_Towel = 154,
	Hotel_Yukata = 155,
	Shrine_Festival_Yukata = 156,
	New_Years_Kimono = 157,
	Wilduck_Burger_Uniform = 158,
	Dorm_Apron = 159,
	Cafe_Uniform = 160,
	Be_Blue_V_Uniform = 161,
	Screen_Shot_Uniform = 162,
	SEES_Outfit = 201,
	SEES_Uniform_2 = 202,
	Damaged_Ribbon = 203,
	Ocean_Sundress = 204,
	Ocean_Sundress_2 = 205,
	Firearms = 206,
	Phantom_Suit = 501,
	Shujin_Uniform = 502,
	Yasogami_Uniform = 503,
}

internal record AssetFNames(string AssetFile)
{
	public string AssetName { get; } = Path.GetFileNameWithoutExtension(AssetFile);

	public string AssetPath { get; } = AssetUtils.GetAssetPath(AssetFile);
};

