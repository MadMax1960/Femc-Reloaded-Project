using p3rpc.femc.Configuration;
using Reloaded.Hooks.Definitions;
using Reloaded.Memory.SigScan.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    // Copied from P5R Research Project
    public abstract class ModuleBase
    {
        // Reloaded-II APIs
        protected Context _context;
        protected readonly Dictionary<string, ModuleBase> _modules;

        public ModuleBase(Context context, Dictionary<string, ModuleBase> modules)
        {
            _context = context;
            _modules = modules;
        }

        public abstract void Register();

        public T GetModule<T>() where T : ModuleBase
        {
            _modules.TryGetValue(typeof(T).Name, out var module);
            if (module == null) throw new Exception($"No module exists with the name \"{typeof(T).Name}\"");
            return (T)module;
        }

        public virtual void OnConfigUpdated(Config newConfig) => _context._config = newConfig;
    }

    public abstract class ModuleAsmInlineColorEdit : ModuleBase
    {
        protected List<AddressToMemoryWrite> _asmMemWrites;

        public unsafe ModuleAsmInlineColorEdit(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _asmMemWrites = new();
        }

        public override void OnConfigUpdated(Config newConfig)
        {
            base.OnConfigUpdated(newConfig);
            foreach (var mem in _asmMemWrites) mem.WriteAtAddress(mem.Address);
        }
    }
}
