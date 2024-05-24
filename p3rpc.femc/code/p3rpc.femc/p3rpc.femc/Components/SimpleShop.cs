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
    public class SimpleShop : ModuleBase<FemcContext>
    {
        private string ASimpleShopDraw_DrawShopDetails_InfoColor_SIG = "48 8B B3 ?? ?? ?? ?? 8B 84 24 ?? ?? ?? ??";
        private IAsmHook _shopInfoColor;
        public unsafe SimpleShop(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(ASimpleShopDraw_DrawShopDetails_InfoColor_SIG, "ASimpleShopDraw::DrawShopDetailsInfoColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"jbe hookEnd", // cmp flag is preserved, skip gray
                    $"mov dword [rsp + 0x1b8], {_context._config.SimpleShopInfoColor.ToU32ARGB()}",
                    $"mov byte [rsp + 0x1bb], al",
                    $"label hookEnd"
                };
                _shopInfoColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }
        public override void Register()
        {
            //_uiCommon = GetModule<UICommon>();
        }
    }
}
