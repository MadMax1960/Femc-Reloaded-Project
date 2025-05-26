﻿using p3rpc.femc.Configuration;
using Reloaded.Mod.Interfaces;
using UE.Toolkit.Core.Types.Unreal.UE4_27_2;
using UE.Toolkit.Interfaces;

namespace p3rpc.femc {
    public class ArmorData
    {
        private readonly IUnrealObjects _uObjects;
        private readonly IUnrealMemory _unreal;
        private readonly ILogger _logger;
        private readonly IModLoader _modLoader;
        private readonly IModConfig _modConfig;
        private readonly Config _configuration;
        private readonly FemcContext _context;
        private unsafe delegate ESystemLanguage GetLanguage();
        private GetLanguage _getLanguage;
        private ESystemLanguage _actualGameLanguage;

        public enum ESystemLanguage : byte
        {
            JA = 0,
            EN = 1,
            FR = 2,
            IT = 3,
            DE = 4,
            ES = 5,
            ZH_HANS = 6,
            ZH_HANT = 7,
            KO = 8,
            RU = 9,
            PT = 10,
            TR = 11,
            PL = 12,
        };

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public ArmorData(IModLoader modLoader, IModConfig modConfig, Config configuration, IUnrealObjects uObjects, IUnrealMemory unreal, ILogger logger,IToolkit toolKit, FemcContext context)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            _uObjects = uObjects;
            _unreal = unreal;
            _configuration = configuration;
            _logger = logger;
            _modLoader = modLoader;
            _modConfig = modConfig;
            _context = context;

            unsafe
            {
                _context._utils.SigScan("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 56 41 57 48 83 EC 30 E8", "GetGameLanguage", _context._utils.GetDirectAddress, addr =>
                {
                    _context._utils.Log($"Found GetGameLanguage at {addr:X}", System.Drawing.Color.Green);
                    _getLanguage = _context._utils.MakeWrapper<GetLanguage>(addr);

                });

                _uObjects.OnObjectLoadedByName<UObjectBase>("WhiteSquareTexture", obj =>
                {
                    _context._utils.Log("WhiteSquareTexture", System.Drawing.Color.Green);
                    try
                    {
                        _actualGameLanguage = _getLanguage!();
                        _context._utils.Log($"Game language is: {_actualGameLanguage}", System.Drawing.Color.Green);
                        string path = Path.Combine(_modLoader.GetDirectoryForModId(_modConfig.ModId), "UEToolkitAssets");
                        
                        if (Directory.Exists(path))
                        {
                            toolKit.AddObjectsPath(Path.Combine(path, "AlwaysGlobal"));
                            switch (_actualGameLanguage)
                            {
                                case ESystemLanguage.JA:
                                    toolKit.AddObjectsPath(Path.Combine(path, "ja"));
                                    break;
                                case ESystemLanguage.ZH_HANS:
                                    toolKit.AddObjectsPath(Path.Combine(path, "zh-Hans"));
                                    break;
                                case ESystemLanguage.ZH_HANT:
                                    toolKit.AddObjectsPath(Path.Combine(path, "zh-Hant"));
                                    break;
                                case ESystemLanguage.KO:
                                    toolKit.AddObjectsPath(Path.Combine(path, "ko"));
                                    break;
                                case ESystemLanguage.RU:
                                    toolKit.AddObjectsPath(Path.Combine(path, "ru"));
                                    break;
                                case ESystemLanguage.FR:
                                    toolKit.AddObjectsPath(Path.Combine(path, "fr"));
                                    break;
                                case ESystemLanguage.IT:
                                    toolKit.AddObjectsPath(Path.Combine(path, "it"));
                                    break;
                                case ESystemLanguage.DE:
                                    toolKit.AddObjectsPath(Path.Combine(path, "de"));
                                    break;
                                case ESystemLanguage.ES:
                                    toolKit.AddObjectsPath(Path.Combine(path, "es"));
                                    break;
                                case ESystemLanguage.PT:
                                    toolKit.AddObjectsPath(Path.Combine(path, "pt"));
                                    break;
                                case ESystemLanguage.TR:
                                    toolKit.AddObjectsPath(Path.Combine(path, "tr"));
                                    break;
                                case ESystemLanguage.PL:
                                    toolKit.AddObjectsPath(Path.Combine(path, "pl"));
                                    break;
                                default:
                                    toolKit.AddObjectsPath(Path.Combine(path, "en"));
                                    break;
                            }
                        }
                    }
                    catch
                    {
                        _context._utils.Log("Failed to get game language, falling back to english", System.Drawing.Color.Red);
                    }
                });
            }
        }

    }
}
