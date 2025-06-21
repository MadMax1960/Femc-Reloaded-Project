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

        private string ASimpleShopDraw_DrawHighlightedColor_SIG = "E8 ?? ?? ?? ?? 48 8B 9F ?? ?? ?? ?? 45 0F 57 E4";
        private string ASimpleShopDraw_DrawBuyItemCount_BackgroundFilter1_SIG = "E8 ?? ?? ?? ?? 0F B6 83 ?? ?? ?? ?? 41 B1 07 88 44 24 ?? 41 B0 06 C6 44 24 ?? 0F";
        private string ASimpleShopDraw_DrawBuyItemCount_BackgroundFilter2_SIG = "E8 ?? ?? ?? ?? 0F B6 83 ?? ?? ?? ?? 88 44 24 ?? C6 44 24 ?? 0F";
        private string ASimpleShopDraw_DrawBuyItemCount_ZeroNumberColor_SIG = "44 88 64 24 ?? 48 85 C9 75";

        private string ASimpleShopDraw_DrawBuyMenu_ShadowColor_SIG = "E8 ?? ?? ?? ?? 0F B6 83 ?? ?? ?? ?? 41 B1 05 88 44 24 ?? 41 B0 04 C6 44 24 ?? 0F 33 D2 C6 44 24 ?? 01 48 8B CE";
        private string ASimpleShopDraw_DrawBuyMenu_BuyFontColor_SIG = "8B 44 24 ?? 0F 57 DB F3 0F 10 0D ?? ?? ?? ??";
        private string ASimpleShopDraw_DrawBuyMenu_QuitFontColor_SIG = "8B 44 24 ?? 0F 57 DB F3 0F 10 15 ?? ?? ?? ??";

        private IAsmHook _shopInfoColor;
        private IAsmHook _drawHighlightedColor;
        private IAsmHook _drawBuyItemCountBackgroundFilter1;
        private IAsmHook _drawBuyItemCountBackgroundFilter2;
        private IAsmHook _drawBuyItemCountZeroNumberColor;
        private IAsmHook _drawBuyMenuShadowColor;
        private IAsmHook _drawBuyMenuBuyFontColor;
        private IAsmHook _drawBuyMenuQuitFontColor;

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

            _context._utils.SigScan(ASimpleShopDraw_DrawHighlightedColor_SIG, "ASimpleShopDraw::DrawHighlightedColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp+0x72], ${_context._config.SimpleShopHighlightedColor.R:X}",
                    $"mov byte [rsp+0x71], ${_context._config.SimpleShopHighlightedColor.G:X}",
                    $"mov byte [rsp+0x70], ${_context._config.SimpleShopHighlightedColor.B:X}"
                };
                _drawHighlightedColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(ASimpleShopDraw_DrawBuyItemCount_BackgroundFilter1_SIG, "ASimpleShopDraw::DrawBuyItemCountBackgroundFilter1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp+0x18a], ${_context._config.SimpleShopBlurFilterColor.R:X}",
                    $"mov byte [rsp+0x189], ${_context._config.SimpleShopBlurFilterColor.G:X}",
                    $"mov byte [rsp+0x188], ${_context._config.SimpleShopBlurFilterColor.B:X}"
                };
                _drawBuyItemCountBackgroundFilter1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(ASimpleShopDraw_DrawBuyItemCount_BackgroundFilter2_SIG, "ASimpleShopDraw::DrawBuyItemCountBackgroundFilter2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp+0x18a], ${_context._config.SimpleShopBlurFilterColor.R:X}",
                    $"mov byte [rsp+0x189], ${_context._config.SimpleShopBlurFilterColor.G:X}",
                    $"mov byte [rsp+0x188], ${_context._config.SimpleShopBlurFilterColor.B:X}"
                };
                _drawBuyItemCountBackgroundFilter2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(ASimpleShopDraw_DrawBuyItemCount_ZeroNumberColor_SIG, "ASimpleShopDraw::DrawBuyItemCountZeroNumberColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp+0x62], ${_context._config.SimpleShopZeroFontColor.R:X}",
                    $"mov byte [rsp+0x61], ${_context._config.SimpleShopZeroFontColor.G:X}",
                    $"mov byte [rsp+0x60], ${_context._config.SimpleShopZeroFontColor.B:X}"
                };
                _drawBuyItemCountZeroNumberColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(ASimpleShopDraw_DrawBuyMenu_ShadowColor_SIG, "ASimpleShopDraw::DrawBuyMenuShadowColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp+0x62], ${_context._config.SimpleShopBuyShadowColor.R:X}",
                    $"mov byte [rsp+0x61], ${_context._config.SimpleShopBuyShadowColor.G:X}",
                    $"mov byte [rsp+0x60], ${_context._config.SimpleShopBuyShadowColor.B:X}"
                };
                _drawBuyMenuShadowColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(ASimpleShopDraw_DrawBuyMenu_BuyFontColor_SIG, "ASimpleShopDraw::DrawBuyMenuBuyFontColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    "jnz .original",
                    $"mov byte [rsp+0x62], ${_context._config.SimpleShopBuyFontColor.R:X}",
                    $"mov byte [rsp+0x61], ${_context._config.SimpleShopBuyFontColor.G:X}",
                    $"mov byte [rsp+0x60], ${_context._config.SimpleShopBuyFontColor.B:X}",
                    ".original:"
                };
                _drawBuyMenuBuyFontColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(ASimpleShopDraw_DrawBuyMenu_QuitFontColor_SIG, "ASimpleShopDraw::DrawBuyMenuQuitFontColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    "jnz .original",
                    $"mov byte [rsp+0x62], ${_context._config.SimpleShopBuyFontColor.R:X}",
                    $"mov byte [rsp+0x61], ${_context._config.SimpleShopBuyFontColor.G:X}",
                    $"mov byte [rsp+0x60], ${_context._config.SimpleShopBuyFontColor.B:X}",
                    ".original:"
                };
                _drawBuyMenuQuitFontColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }
        public override void Register()
        {
            //_uiCommon = GetModule<UICommon>();
        }
    }
}
