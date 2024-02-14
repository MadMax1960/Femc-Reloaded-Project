using p3rpc.femc.Native;
using Reloaded.Hooks.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class LocationSelect : ModuleBase
    {
        private string UUILocationSelect_DrawLocationSelect_SIG = "40 55 56 57 41 56 48 8D AC 24 ?? ?? ?? ?? 48 81 EC 88 04 00 00";
        private IHook<UUILocationSelect_DrawLocationSelect> _drawLocationSelect;

        public unsafe LocationSelect(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(UUILocationSelect_DrawLocationSelect_SIG, "UUILocationSelect::DrawLocationSelect", _context._utils.GetDirectAddress, addr => _drawLocationSelect = _context._utils.MakeHooker<UUILocationSelect_DrawLocationSelect>(UUILocationSelect_DrawLocationSelectImpl, addr));
        }

        public override void Register()
        {
        }

        private unsafe void UUILocationSelect_DrawLocationSelectImpl(UUILocationSelect* self)
        {
            _drawLocationSelect.OriginalFunction(self);
        }
        private unsafe delegate void UUILocationSelect_DrawLocationSelect(UUILocationSelect* self);
    }
}
