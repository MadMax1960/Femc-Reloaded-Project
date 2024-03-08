using p3rpc.femc.Configuration;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Memory;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc
{
    public class Context
    {
        public long _baseAddress { get; }
        public Config _config { get; set; }
        public ILogger _logger { get; }
        public IStartupScanner _startupScanner { get; }
        public IReloadedHooks _hooks { get; }
        public Utils _utils { get; }
        public Memory _memory { get; }

        public string ModLocation;
        public unsafe FNamePool* g_namePool { get; private set; }
        public unsafe FUObjectArray* g_objectArray { get; private set; }

        public readonly ConfigColor ColorBlack = new ConfigColor(0x0, 0x0, 0x0, 0xff);
        public readonly ConfigColor ColorWhite = new ConfigColor(0xff, 0xff, 0xff, 0xff);

        private string FUObjectArray_SIG = "48 8B 05 ?? ?? ?? ?? 48 8B 0C ?? 48 8D 04 ?? 48 85 C0 74 ?? 44 39 40 ?? 75 ?? F7 40 ?? 00 00 00 30 75 ?? 48 8B 00";
        private string FGlobalNamePool_SIG = "4C 8D 05 ?? ?? ?? ?? EB ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 4C 8B C0 C6 05 ?? ?? ?? ?? 01 48 8B 44 24 ?? 48 8B D3 48 C1 E8 20 8D 0C ?? 49 03 4C ?? ?? E8 ?? ?? ?? ?? 48 8B C3";

        private nuint TransformAddressForFUObjectArray(int offset) => Utils.GetGlobalAddress((nint)(_baseAddress + offset + 3)) - 0x10;

        public Context(long baseAddress, Config config, ILogger logger, IStartupScanner startupScanner, IReloadedHooks hooks, string modLocation, Utils utils, Memory memory)
        {
            _baseAddress = baseAddress;
            _config = config;
            _logger = logger;
            _startupScanner = startupScanner;
            _hooks = hooks;
            ModLocation = modLocation;
            _utils = utils;
            _memory = memory;
            unsafe
            {
                _utils.SigScan(FUObjectArray_SIG, "FUObjectArray", TransformAddressForFUObjectArray, addr => g_objectArray = (FUObjectArray*)addr);
                _utils.SigScan(FGlobalNamePool_SIG, "FGlobalNamePool", _utils.GetIndirectAddressLong, addr => g_namePool = (FNamePool*)addr);
            }
        }
    }
}
