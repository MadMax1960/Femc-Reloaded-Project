using p3rpc.commonmodutils;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    internal class ItemList : ModuleBase<FemcContext>
    {
        private string AUIItemList_DrawHighlightedColor_SIG = "E8 ?? ?? ?? ?? F3 41 0F 10 86 ?? ?? ?? ?? 48 8D 95 ?? ?? ?? ??";

        private IAsmHook _DrawHighlightedColor;

        public unsafe ItemList(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUIItemList_DrawHighlightedColor_SIG, "AUIItemList::DrawHighlightedColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp+0x7a], ${_context._config.ItemListHighlightedColor.R:X}",
                    $"mov byte [rsp+0x79], ${_context._config.ItemListHighlightedColor.G:X}",
                    $"mov byte [rsp+0x78], ${_context._config.ItemListHighlightedColor.B:X}"
                };
                _DrawHighlightedColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }

        public override void Register() { }
    }
}
