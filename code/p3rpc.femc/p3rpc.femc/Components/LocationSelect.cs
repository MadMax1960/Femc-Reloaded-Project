using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using Reloaded.Hooks.Definitions.X64;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class LocationSelect : ModuleBase<FemcContext>
    {
        //private string UUILocationSelect_DrawLocationSelect_SIG = "40 55 56 57 41 56 48 8D AC 24 ?? ?? ?? ?? 48 81 EC 88 04 00 00";
        private string UUILocationSelect_DrawLocationSelectBaseColor_SIG = "0F 57 DB 89 85 ?? ?? ?? ?? 0F 57 D2 48 8D 4D ?? 49 8B D6 E8 ?? ?? ?? ?? BA 01 00 00 00";
        private string UUILocationSelect_DrawLocationSelectTintColor_SIG = "0F 57 DB 89 85 ?? ?? ?? ?? 0F 57 D2 48 8D 4D ?? 49 8B D6 E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ??";
        private string UUILocationSelect_DrawLocationSelectMarkerSprite_SIG = "4C 8B 47 ?? 48 8D 8D ?? ?? ?? ?? 0F 57 DB";
        private string FShortcutItem_SelectedShortcutColor_SIG = "0F 28 05 ?? ?? ?? ?? 48 8D 4B ?? F3 0F 10 5D ??";

        private IAsmHook _drawLocationSelBase;
        private IAsmHook _drawLocationSelTint;
        private IAsmHook _selMarkerSprite;
        private IAsmHook _selShortcutColor;

        private IReverseWrapper<UUILocationSelect_SetElementColor> _drawLocationSelBaseWrapper;
        private IReverseWrapper<UUILocationSelect_SetElementColor> _drawLocationSelTintWrapper;
        private IReverseWrapper<UUILocationSelect_SetElementColor> _drawLocationSelectMarkerWrapper;
        //private IReverseWrapper<UUILocationSelect_SetElementColor> _drawLocationSelTintWrapper;

        //private IHook<UUILocationSelect_DrawLocationSelect> _drawLocationSelect;

        private UICommon _uiCommon;

        public unsafe LocationSelect(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            //_context._utils.SigScan(UUILocationSelect_DrawLocationSelect_SIG, "UUILocationSelect::DrawLocationSelect", _context._utils.GetDirectAddress, addr => _drawLocationSelect = _context._utils.MakeHooker<UUILocationSelect_DrawLocationSelect>(UUILocationSelect_DrawLocationSelectImpl, addr));
            _context._utils.SigScan(UUILocationSelect_DrawLocationSelectBaseColor_SIG, "UUILocationSelect::DrawLocationSelectBaseColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UUILocationSelect_DrawLocationSelectBaseColor, out _drawLocationSelBaseWrapper)}"
                };
                _drawLocationSelBase = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUILocationSelect_DrawLocationSelectTintColor_SIG, "UUILocationSelect::DrawLocationSelectTintColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UUILocationSelect_DrawLocationSelectTintColor, out _drawLocationSelTintWrapper)}"
                };
                _drawLocationSelTint = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUILocationSelect_DrawLocationSelectMarkerSprite_SIG, "UUILocationSelect::DrawLocationSelectTintColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UUILocationSelect_DrawLocationSelectMarkerColor, out _drawLocationSelectMarkerWrapper)}"
                };
                _selMarkerSprite = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(FShortcutItem_SelectedShortcutColor_SIG, "FShortcutItem::SelectedShortcutColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"cmp byte [rbp + 0x67], 0x0",
                    $"jz whiteColor",
                    $"mov dword [rbx + 0x3c], {_context._config.LocationSelectSelColor.ToU32()}", // for text
                    $"mov edi, {_context._config.LocationSelectSelColor.ToU32()}", // for marker
                    $"label whiteColor"
                };
                _selShortcutColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        /*
        private unsafe void UUILocationSelect_DrawLocationSelectImpl(UUILocationSelect* self)
        {
            _drawLocationSelect.OriginalFunction(self);
        }
        private unsafe delegate void UUILocationSelect_DrawLocationSelect(UUILocationSelect* self);
        */
        private unsafe FSprColor UUILocationSelect_DrawLocationSelectBaseColor(UUILocationSelect* self)
        {
            var white = ConfigColor.ToFSprColor(_context.ColorWhite);
            white.A = 0x66;
            return white;
        }

        private unsafe FSprColor UUILocationSelect_DrawLocationSelectTintColor(UUILocationSelect* self) => ConfigColor.ToFSprColor(_context._config.LocationSelectBgColor);
        private unsafe FSprColor UUILocationSelect_DrawLocationSelectMarkerColor(UUILocationSelect* self) => ConfigColor.ToFSprColor(_context._config.LocationSelectMarkerColor);
        //private unsafe FSprColor FShortcutItem_SelectedShortcutColor(UUILocationSelect* self) => ConfigColor.ToFSprColor(_context._config.LocationSelectSelColor);

        [Function(FunctionAttribute.Register.rax, FunctionAttribute.Register.rdi, false)]
        private unsafe delegate FSprColor UUILocationSelect_SetElementColor(UUILocationSelect* self);
    }
}
