using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class Minimap : ModuleBase<FemcContext>
    {
        private string AUIAccessInfoDraw_UpdateMinimapState_SIG = "40 55 53 48 8D 6C 24 ?? 48 81 EC F8 00 00 00 48 8B 81 ?? ?? ?? ??";
        private IHook<AUIAccessInfoDraw_UpdateMinimapState> _updateMinimapState;
        private unsafe delegate void AUIAccessInfoDraw_UpdateMinimapState(AUIAccessInfoDraw* self);
        private unsafe void AUIAccessInfoDraw_UpdateMinimapStateImpl(AUIAccessInfoDraw* self)
        {
            _updateMinimapState.OriginalFunction(self);
            ConfigColor.SetColor(ref self->PlaceInfoBgColor, _context._config.MinimapPlaceNameBgColor);
        }
        private string AUIAccessInfoDraw_UpdateMinimapState_SIG_EpAigis = "40 55 53 57 48 8D 6C 24 ?? 48 81 EC F0 00 00 00 48 8B D9";
        private IHook<AUIAccessInfoDraw_UpdateMinimapState_EpAigis> _updateMinimapState_EpAigis;
        private unsafe delegate void AUIAccessInfoDraw_UpdateMinimapState_EpAigis(nativetypes.Interfaces.Astrea.AUIAccessInfoDraw* self);
        private unsafe void AUIAccessInfoDraw_UpdateMinimapStateImpl_EpAigis(nativetypes.Interfaces.Astrea.AUIAccessInfoDraw* self)
        {
            _updateMinimapState_EpAigis.OriginalFunction(self);
            ConfigColor.SetColor(ref self->PlaceInfoBgColor, _context._config.MinimapPlaceNameBgColor);
        }

        private string UUIMinimapDraw_DrawMinimapBgCircle_SIG = "48 89 E0 48 89 70 ?? 57 48 81 EC C0 00 00 00";
        private string UUILocationSelect_DrawLocationSelect_SIG = "40 55 56 57 41 56 48 8D AC 24 ?? ?? ?? ?? 48 81 EC 88 04 00 00";

        private string UUIMinimapDraw_DrawMinimapFieldInnerCircle_SIG = "E8 ?? ?? ?? ?? 0F 28 DE 89 86 ?? ?? ?? ??";
        private string UUIMinimapDraw_DrawMinimapFieldOutterCircle_SIG = "E8 ?? ?? ?? ?? 44 0F 2F 2D ?? ?? ?? ??";
        private string UUIMinimapDraw_DrawMinimapLocationsHighStrip_SIG = "E8 ?? ?? ?? ?? F3 0F 10 15 ?? ?? ?? ?? 41 B0 CD";
        private string UUIMinimapDraw_DrawMinimapLocationsLowerStrip_SIG = "E8 ?? ?? ?? ?? 44 0F 28 64 24 ?? 0F 28 BC 24 ?? ?? ?? ??";

        private string UUIMinimapDraw_DrawMinimapLocationsHighlightedElement_SIG = "E8 ?? ?? ?? ?? 89 83 ?? ?? ?? ?? 0F 28 74 24 ??";

        private IAsmHook _DrawMinimapFieldInnerCircle;
        private IAsmHook _DrawMinimapFieldOutterCircle;
        private IAsmHook _DrawMinimapLocationsHighStrip;
        private IAsmHook _DrawMinimapLocationsLowerStrip;
        private IAsmHook _DrawMinimapLocationsHighlightedElement;

        private UICommon _uiCommon;
        public unsafe Minimap(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            if (_context.bIsAigis) _context._utils.SigScan(AUIAccessInfoDraw_UpdateMinimapState_SIG_EpAigis, "AUIAccessInfoDraw::UpdateMinimapState", _context._utils.GetDirectAddress, addr => _updateMinimapState_EpAigis = _context._utils.MakeHooker<AUIAccessInfoDraw_UpdateMinimapState_EpAigis>(AUIAccessInfoDraw_UpdateMinimapStateImpl_EpAigis, addr));
            else _context._utils.SigScan(AUIAccessInfoDraw_UpdateMinimapState_SIG, "AUIAccessInfoDraw::UpdateMinimapState", _context._utils.GetDirectAddress, addr => _updateMinimapState = _context._utils.MakeHooker<AUIAccessInfoDraw_UpdateMinimapState>(AUIAccessInfoDraw_UpdateMinimapStateImpl, addr));

            _context._utils.SigScan(UUIMinimapDraw_DrawMinimapFieldInnerCircle_SIG, "UUIMinimapDraw::DrawMinimapFieldInnerCircle", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.MinimapFieldInnerCircle.B:X}",
                    $"mov dl, ${_context._config.MinimapFieldInnerCircle.G:X}",
                    $"mov cl, ${_context._config.MinimapFieldInnerCircle.R:X}"
                };
                _DrawMinimapFieldInnerCircle = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUIMinimapDraw_DrawMinimapFieldOutterCircle_SIG, "UUIMinimapDraw::DrawMinimapFieldOutterCircle", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.MinimapFieldOutterCircle.B:X}",
                    $"mov dl, ${_context._config.MinimapFieldOutterCircle.G:X}",
                    $"mov cl, ${_context._config.MinimapFieldOutterCircle.R:X}"
                };
                _DrawMinimapFieldOutterCircle = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(UUIMinimapDraw_DrawMinimapLocationsHighStrip_SIG, "UUIMinimapDraw::DrawMinimapLocationsHighStrip", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.MinimapLocationsHighStrip.B:X}",
                    $"mov dl, ${_context._config.MinimapLocationsHighStrip.G:X}",
                    $"mov cl, ${_context._config.MinimapLocationsHighStrip.R:X}"
                };
                _DrawMinimapLocationsHighStrip = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUIMinimapDraw_DrawMinimapLocationsLowerStrip_SIG, "UUIMinimapDraw::DrawMinimapLocationsLowerStrip", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.MinimapLocationsLowerStrip.B:X}",
                    $"mov dl, ${_context._config.MinimapLocationsLowerStrip.G:X}",
                    $"mov cl, ${_context._config.MinimapLocationsLowerStrip.R:X}"
                };
                _DrawMinimapLocationsLowerStrip = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUIMinimapDraw_DrawMinimapLocationsHighlightedElement_SIG, "UUIMinimapDraw::DrawMinimapLocationsHighlightedElement", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.MinimapLocationsSelectionColor.B:X}",
                    $"mov dl, ${_context._config.MinimapLocationsSelectionColor.G:X}",
                    $"mov cl, ${_context._config.MinimapLocationsSelectionColor.R:X}"
                };
                _DrawMinimapLocationsHighlightedElement = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }
    }
}
