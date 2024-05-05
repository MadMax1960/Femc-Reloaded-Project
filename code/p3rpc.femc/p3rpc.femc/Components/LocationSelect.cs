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
        // (1.0.0, 1.0.1)
        private string AUIAccessInfoDraw_DrawMinimap_SIG_0 = "4C 8B DC 55 57 49 8D AB ?? ?? ?? ?? 48 81 EC D8 01 00 00 45 0F 29 A3 ?? ?? ?? ??";
        // (1.0.4)
        private string AUIAccessInfoDraw_DrawMinimap_SIG_1 = "4C 8B DC 55 57 49 8D AB ?? ?? ?? ?? 48 81 EC 88 01 00 00 41 0F 29 7B ??"; 
        // All versions
        private string UUILocationSelect_DrawLocationSelectBaseColor_SIG = "0F 57 DB 89 85 ?? ?? ?? ?? 0F 57 D2 48 8D 4D ?? 49 8B D6 E8 ?? ?? ?? ?? BA 01 00 00 00";
        private string UUILocationSelect_DrawLocationSelectTintColor_SIG = "0F 57 DB 89 85 ?? ?? ?? ?? 0F 57 D2 48 8D 4D ?? 49 8B D6 E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ??";
        private string UUILocationSelect_DrawLocationSelectMarkerSprite_SIG = "4C 8B 47 ?? 48 8D 8D ?? ?? ?? ?? 0F 57 DB";
        //private string FShortcutItem_SelectedShortcutColor_SIG = "0F 28 05 ?? ?? ?? ?? 48 8D 4B ?? F3 0F 10 5D ??";
        private string FShortcutItem_SelectedShortcutColor_SIG = "48 8D 53 ?? 89 7B ?? 48 8D 4B ??";
        private string AUIAccessInfoDraw_DrawMinimapLabel_SIG = "BA 04 00 00 00 89 44 24 ??";

        private IAsmHook _drawLocationSelBase;
        private IAsmHook _drawLocationSelTint;
        private IAsmHook _selMarkerSprite;
        private IAsmHook _selShortcutColor;
        private IAsmHook _drawMinimapLabel;

        private IReverseWrapper<UUILocationSelect_SetElementColor> _drawLocationSelBaseWrapper;
        private IReverseWrapper<UUILocationSelect_SetElementColor> _drawLocationSelTintWrapper;
        private IReverseWrapper<UUILocationSelect_SetElementColor> _drawLocationSelectMarkerWrapper;
        //private IReverseWrapper<UUILocationSelect_SetElementColor> _drawLocationSelTintWrapper;
        private IReverseWrapper<AUIAccessInfoDraw_DrawMinimapLabel> _drawMinimapLabelWrapper;

        //private IHook<UUILocationSelect_DrawLocationSelect> _drawLocationSelect;
        private IHook<AUIAccessInfoDraw_DrawMinimap> _drawMinimap;

        private UICommon _uiCommon;

        private MultiSignature _drawMinimapMS;

        public unsafe LocationSelect(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _drawMinimapMS = new MultiSignature();
            _context._utils.MultiSigScan(
                new string[] { AUIAccessInfoDraw_DrawMinimap_SIG_0, AUIAccessInfoDraw_DrawMinimap_SIG_1 },
                "AUIAccessInfoDraw::DrawMinimap", _context._utils.GetDirectAddress,
                addr => _drawMinimap = _context._utils.MakeHooker<AUIAccessInfoDraw_DrawMinimap>(AUIAccessInfoDraw_DrawMinimapImpl, addr),
                _drawMinimapMS
            );
            _context._utils.SigScan(UUILocationSelect_DrawLocationSelectBaseColor_SIG, "UUILocationSelect::DrawLocationSelectBaseColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._utils.PreserveMicrosoftRegisters()}",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UUILocationSelect_DrawLocationSelectBaseColor, out _drawLocationSelBaseWrapper)}",
                    $"{_context._utils.RetrieveMicrosoftRegisters()}",
                };
                _drawLocationSelBase = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUILocationSelect_DrawLocationSelectTintColor_SIG, "UUILocationSelect::DrawLocationSelectTintColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._utils.PreserveMicrosoftRegisters()}",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UUILocationSelect_DrawLocationSelectTintColor, out _drawLocationSelTintWrapper)}",
                    $"{_context._utils.RetrieveMicrosoftRegisters()}",
                };
                _drawLocationSelTint = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUILocationSelect_DrawLocationSelectMarkerSprite_SIG, "UUILocationSelect::DrawLocationSelectTintColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._utils.PreserveMicrosoftRegisters()}",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UUILocationSelect_DrawLocationSelectMarkerColor, out _drawLocationSelectMarkerWrapper)}",
                    $"{_context._utils.RetrieveMicrosoftRegisters()}",
                };
                _selMarkerSprite = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(FShortcutItem_SelectedShortcutColor_SIG, "FShortcutItem::SelectedShortcutColor", _context._utils.GetDirectAddress, addr =>
            {
                /* old signature
                string[] function =
                {
                    "use64",
                    $"cmp byte [rbp + 0x67], 0x0",
                    $"jz whiteColor",
                    $"mov dword [rbx + 0x3c], {_context._config.LocationSelectSelColor.ToU32()}", // for text
                    $"mov edi, {_context._config.LocationSelectSelColor.ToU32()}", // for marker
                    $"label whiteColor"
                };
                */
                string[] function =
                {
                    "use64",
                    $"cmp byte [rbp + 0x67], 0x0",
                    $"jz whiteColor",
                    $"mov edi, {_context._config.LocationSelectSelColor.ToU32()}", // for marker
                    $"label whiteColor"
                };
                _selShortcutColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIAccessInfoDraw_DrawMinimapLabel_SIG, "UUILocationSelect::DrawLocationSelectTintColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._utils.PreserveMicrosoftRegisters()}",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUIAccessInfoDraw_DrawMinimapLabelImpl, out _drawMinimapLabelWrapper)}",
                    $"{_context._utils.RetrieveMicrosoftRegisters()}",
                };
                _drawMinimapLabel = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
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
        */
        private unsafe void AUIAccessInfoDraw_DrawMinimapImpl(AUIAccessInfoDraw* self)
        {
            self->mapBg.Color = ConfigColor.ToFSprColorWithAlpha(_context._config.LocationSelMapLabel, self->mapBg.Color.A);
            _drawMinimap.OriginalFunction(self);
        }
        private unsafe FSprColor UUILocationSelect_DrawLocationSelectBaseColor(UUILocationSelect* self) => ConfigColor.ToFSprColorWithAlpha(_context.ColorWhite, 0x66);
        private unsafe FSprColor AUIAccessInfoDraw_DrawMinimapLabelImpl(FSprColor source) => ConfigColor.ToFSprColorWithAlpha(_context._config.LocationSelMapBg, source.A);

        private unsafe FSprColor UUILocationSelect_DrawLocationSelectTintColor(UUILocationSelect* self) => ConfigColor.ToFSprColor(_context._config.LocationSelectBgColor);
        private unsafe FSprColor UUILocationSelect_DrawLocationSelectMarkerColor(UUILocationSelect* self) => ConfigColor.ToFSprColor(_context._config.LocationSelectMarkerColor);
        //private unsafe FSprColor FShortcutItem_SelectedShortcutColor(UUILocationSelect* self) => ConfigColor.ToFSprColor(_context._config.LocationSelectSelColor);

        private unsafe delegate void AUIAccessInfoDraw_DrawMinimap(AUIAccessInfoDraw* self);
        //private unsafe delegate void UUILocationSelect_DrawLocationSelect(UUILocationSelect* self);

        [Function(FunctionAttribute.Register.rax, FunctionAttribute.Register.rax, false)]
        private unsafe delegate FSprColor AUIAccessInfoDraw_DrawMinimapLabel(FSprColor source);

        [Function(FunctionAttribute.Register.rax, FunctionAttribute.Register.rdi, false)]
        private unsafe delegate FSprColor UUILocationSelect_SetElementColor(UUILocationSelect* self);
    }
}
