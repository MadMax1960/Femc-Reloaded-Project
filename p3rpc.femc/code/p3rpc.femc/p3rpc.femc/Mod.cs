﻿using p3rpc.commonmodutils;
using p3rpc.femc.Components;
using p3rpc.femc.Configuration;
using p3rpc.femc.Template;
using Reloaded.Hooks.Definitions;
using Reloaded.Memory;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using SharedScans.Interfaces;
using System;
using System.Diagnostics;
using System.Reflection;
using UnrealEssentials.Interfaces;
using Unreal.ObjectsEmitter.Interfaces;
using System;
using System.Collections.Generic;
using static p3rpc.femc.Configuration.Config;
using p3rpc.classconstructor.Interfaces;

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
			var memory = new Memory();
			_context = new(baseAddress, _configuration, _logger, startupScanner, _hooks, _modLoader.GetDirectoryForModId(_modConfig.ModId), utils, memory, sharedScans, classMethods, objectMethods);
			_modRuntime = new(_context);

			modName = _modConfig.ModName;
			// Load Modules/assets
			LoadEnabledAddons(unrealEssentials);
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

		private void LoadEnabledAddons(IUnrealEssentials unrealEssentials)
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

				if (_configuration.AOAText == AOATextType.DontLookBack)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOAText", "DontLookBack"));
				else if (_configuration.AOAText == AOATextType.SorryBoutThat)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "AOAText", "SorryBoutThat"));

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



				if (_configuration.ShardTrue == ShardType.Esa)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Shard", "Esa"));
				else if (_configuration.ShardTrue == ShardType.Ely)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Shard", "Ely"));

				if (_configuration.LevelUpTrue == LevelUpType.Esa)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "LevelUp", "Esa"));
				else if (_configuration.LevelUpTrue == LevelUpType.Ely)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "LevelUp", "Ely"));

				if (_configuration.CutinTrue == CutinType.berrycha)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Cutin", "berrycha"));
				else if (_configuration.CutinTrue == CutinType.ElyandPatmandx)
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "2d", "Cutin", "ElyandPatmandx"));


				if (_configuration.KotoneRoom)
				{
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Fun Stuff", "Kotone Room"));
				}

				if (_configuration.FunnyAnims)
				{
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Fun Stuff", "Funny Anims"));
				}

				if (!_configuration.FunnyAnims)
				{
					unrealEssentials.AddFromFolder(Path.Combine(_context._modLocation, "Fun Stuff", "Funny Animsog")); // game dies when 2 files loaded, this has the og files we had in mod but in their own folder, the ! is if the bool is disabled
				}


			}
			catch (Exception ex)
			{
				_context._utils.Log($"An error occured trying to read addons: \"{ex.Message}\"", System.Drawing.Color.Red);
			}
		}

		private void GenerateMusicScript()
		{
			try
			{

				//Initialise the music picker
				string path = _modLoader.GetDirectoryForModId(_modConfig.ModId);
				path = path + "/BGME/scripts";
				int added = 0;
				//Advantage Music Specific Code
				string advantage = "const advantageBgmList=[";
				var advantagecollection = new Dictionary<string, bool>
			{
				{"2000",_configuration.pullthetrigger},
				{"128",_configuration.itsgoingdown}
			};
				foreach (KeyValuePair<string, bool> adv in advantagecollection)
				{
					if (adv.Value)
					{
						if (added == 1)
						{
							advantage = advantage + "," + adv.Key;
						}
						else
						{
							advantage = advantage + adv.Key;
							added = 1;
						}

					}
				}
				if (added == 0)
				{
					advantage += "2000";
				}
				advantage = advantage + "]";
				//Disadvantage Specific Code
				string disadvantage = "const disadvantageBgmList=[";
				var disadvantagecollection = new Dictionary<string, bool>
			{
				{"31",_configuration.mast},
				{"2002",_configuration.dang}
			};
				added = 0;
				foreach (KeyValuePair<string, bool> disadv in disadvantagecollection)
				{
					if (disadv.Value)
					{
						if (added == 1)
						{
							disadvantage = disadvantage + "," + disadv.Key;
						}
						else
						{
							disadvantage = disadvantage + disadv.Key;
							added = 1;
						}

					}
				}
				if (added == 0)
				{
					disadvantage += "2002";
				}
				disadvantage = disadvantage + "]";
				//Normal Specific Code
				string normal = "const normalBgmList=[";
				var normalcollection = new Dictionary<string, bool>
			{
				{"26",_configuration.massdest},
				{"2001",_configuration.wipingall}
			};
				added = 0;
				foreach (KeyValuePair<string, bool> norm in normalcollection)
				{
					if (norm.Value)
					{
						if (added == 1)
						{
							normal = normal + "," + norm.Key;
						}
						else
						{
							normal = normal + norm.Key;
							added = 1;
						}

					}
				}
				if (added == 0)
				{
					normal += "2001";
				}
				normal = normal + "]";

				//Code for night themes
				string night = "const nightList=[";
				var nightcollection = new Dictionary<string, bool>
			{
				{"97",_configuration.colnight},
				{"2003",_configuration.midnight},
				{"2004",_configuration.femnight}
			};
				added = 0;
				foreach (KeyValuePair<string, bool> ni in nightcollection)
				{
					if (ni.Value)
					{
						if (added == 1)
						{
							night = night + "," + ni.Key;
						}
						else
						{
							night = night + ni.Key;
							added = 1;
						}

					}
				}
				if (added == 0)
				{
					night += "2004";
				}
				night = night + "]";

                string dayoutside1 = "const dayout1List=[";
                var daytimeoutsidephase1 = new Dictionary<string, bool>
            {
                {"25",_configuration.moon},
                {"2005",_configuration.wayoflife}
            };
                added = 0;
                foreach (KeyValuePair<string, bool> do1 in daytimeoutsidephase1)
                {
                    if (do1.Value)
                    {
                        if (added == 1)
                        {
                            dayoutside1 = dayoutside1 + "," + do1.Key;
                        }
                        else
                        {
                            dayoutside1 = dayoutside1 + do1.Key;
                            added = 1;
                        }

                    }
                }
                if (added == 0)
                {
                    dayoutside1 += "2005";
                }
                dayoutside1 = dayoutside1 + "]";
				
				string dayinside1 = "const dayin1List=[";
                var daytimeinsidephase1 = new Dictionary<string, bool>
            {
                {"50",_configuration.wantclose},
                {"2006",_configuration.timeschool}
            };
                added = 0;
                foreach (KeyValuePair<string, bool> di1 in daytimeinsidephase1)
                {
                    if (di1.Value)
                    {
                        if (added == 1)
                        {
                            dayinside1 = dayinside1 + "," + di1.Key;
                        }
                        else
                        {
                            dayinside1 = dayinside1 + di1.Key;
                            added = 1;
                        }

                    }
                }
                if (added == 0)
                {
                    dayinside1 += "2006";
                }
                dayinside1 = dayinside1 + "]";
				
				/* NOT TO BE USED IMPLEMENTATION CURRENTLY BEING TESTED
				string dayinside1;
				if (_configuration.dayinmusic1 == dayinmusic1sel.Want_to_be_close_reload)
				{
					dayinside1 = "const dayin1List=[50]";

                }
				else
				{
                    dayinside1 = "const dayin1List=[2006]";
                }

				*/
                //Writing the configuration File
                string[] lines = { normal, advantage, disadvantage, "const normalBgm = random_song(normalBgmList)", "const disadvantageBgm = random_song(disadvantageBgmList)", "const advantageBgm = random_song(advantageBgmList)", "encounter[\"Normal Battles\"]:", "music = battle_bgm(normalBgm, advantageBgm, disadvantageBgm)","end", night, "global_bgm[\"Color Your Night\"]:", "music = random_song(nightList)","end",dayinside1, "global_bgm[\"Want to Be Close\"]:", "music = random_song(dayin1List)","end", dayoutside1, "global_bgm[\"When The Moon's Reaching Out Stars\"]:", "music = random_song(dayout1List)", "end" };
				
				if (File.Exists(path + ".pme"))
				{
					File.Delete(path + ".pme");
				}
				using (StreamWriter outputFile = new StreamWriter(path))
				{
					foreach (string line in lines)
						outputFile.WriteLine(line);
				}
				File.Move(path, Path.ChangeExtension(path, ".pme"));
			}
            catch (Exception ex)
            {
                _context._utils.Log($"An error occured while trying to generate the music script: \"{ex.Message}\"", System.Drawing.Color.Red);
            }
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
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C159", "/Game/Xrd777/Characters/Player/PC0005/Models/SK_PC0005_C159"); // dorm apron
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C160", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C984"); // idk
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C161", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C980"); // work outfit for something
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C162", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C981"); // something
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C501", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C996"); //not  rise
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C502", "/Game/Xrd777/Characters/Player/PC0005/Models/SK_PC0005_C502"); // mitsuru shujin redirect
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_C503", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_C997"); // not best outfit, its naoto, look at her go, i need to use new yuha textures for coat (and maybe make textures for pants and hat while I wait, but either way its naoto, look at that woah, wow, naoto, noot, shirogane, tiny person, little short tiny not tall detective 
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H158", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_H999"); // hair
			this.RedirectAsset("/Game/Xrd777/Characters/Player/PC0001/Models/SK_PC0001_H501", "/Game/Xrd777/Characters/Player/PC0002/Models/SK_PC0002_H999"); // hair 2 (3 technically)
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
