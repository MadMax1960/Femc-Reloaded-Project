using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using Reloaded.Hooks.Definitions.X64;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Reloaded.Hooks.Definitions.X64.FunctionAttribute;

namespace p3rpc.femc.Components
{
    public class TownMap : ModuleBase<FemcContext>
    {
        // In AUITownMapActor::DrawTownMapUIInner
        private string AUITownMapActor_TownMapTextColor_SIG = "48 8D 54 24 ?? 89 44 24 ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ??";
        private string AUITownMapActor_TownMapBorderColor_SIG = "48 8D 54 24 ?? 89 44 24 ?? 48 8D 8F ?? ?? ?? ?? 89 45 ??";
        private string FTownMapMarker2_UpdateState_SIG = "48 89 5C 24 ?? 57 48 83 EC 50 48 8D B9 ?? ?? ?? ??";

        private string AUITownMapActor_LocationDetailsTintColor_SIG = "41 B1 FF 89 85 ?? ?? ?? ?? 45 0F B6 C1 41 0F B6 D1";
        private string AUITownMapActor_LocationDetailsTopLeft_SIG = "41 B1 FF 89 85 ?? ?? ?? ?? 41 B0 EC";
        private string AUITownMapActor_LocationDetailsLowerBand_SIG = "F3 0F 10 1D ?? ?? ?? ?? 48 8D 8D ?? ?? ?? ?? F3 0F 10 15 ?? ?? ?? ?? 49 8B D6 89 85 ?? ?? ?? ??";
        private string AUITownMapActor_LocationDetailsText_SIG = "48 8D 54 24 ?? 89 85 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ??";

        private string AUITownMap_LocationSubtleShadow_SIG = "E8 ?? ?? ?? ?? 41 B1 FF 89 83 ?? ?? ?? ?? 41 B0 FE";
        private string AUITownMap_LocationRoundedOutline_SIG = "E8 ?? ?? ?? ?? B2 96 89 83 ?? ?? ?? ??";
        private string AUITownMap_LocationPreviewTaint_SIG = "E8 ?? ?? ?? ?? 89 83 ?? ?? ?? ?? 83 FF 05";
        private string AUITownMap_LocationMiniIndicator_SIG = "E8 ?? ?? ?? ?? 45 33 C9 89 87 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ??";
        private string AUITownMap_LocationMiniIndicatorSubtleShadow_SIG = "E8 ?? ?? ?? ?? 41 B1 4C";

        private UICommon _uiCommon;

        private IAsmHook _townMapTextColor;
        private IAsmHook _townMapBorderColor;

        private IAsmHook _bgTintColor;
        private IAsmHook _topLeftColor;
        private IAsmHook _lowerBand;
        private IAsmHook _detailsText;
        private IAsmHook _locationSubtleShadow;
        private IAsmHook _locationRoundedOutline;
        private IAsmHook _locationPreviewTaint;
        private IAsmHook _locationMiniIndicator;
        private IAsmHook _locationMiniIndicatorSubtleShadow;

        private IReverseWrapper<AUITownMapActor_TownMapSetUICompColor> _townMapTextColorWrapper;
        private IReverseWrapper<AUITownMapActor_TownMapSetUICompColor> _townMapBorderColorWrapper;

        private IReverseWrapper<AUITownMapActor_InjectColorAfterCtor> _bgTintColorWrapper;
        private IReverseWrapper<AUITownMapActor_InjectColorAfterCtor> _topLeftColorWrapper;
        private IReverseWrapper<AUITownMapActor_InjectColorAfterCtor> _lowerBandWrapper;
        private IReverseWrapper<AUITownMapActor_InjectColorAfterCtor> _detailsTextWrapper;

        private IHook<FTownMapMarker2_UpdateState> _townMapMarkerUpdateState;

        public unsafe TownMap(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUITownMapActor_TownMapTextColor_SIG, "AUITownMapActor::TownMapTextColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUITownMapActor_TownMapTextColorImpl, out _townMapTextColorWrapper)}",
                };
                _townMapTextColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMapActor_TownMapBorderColor_SIG, "AUITownMapActor::TownMapTextColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUITownMapActor_TownMapBorderColorImpl, out _townMapBorderColorWrapper)}",
                };
                _townMapBorderColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(FTownMapMarker2_UpdateState_SIG, "FTownMapMarker2::UpdateState", _context._utils.GetDirectAddress, addr => _townMapMarkerUpdateState = _context._utils.MakeHooker<FTownMapMarker2_UpdateState>(FTownMapMarker2_UpdateStateImpl, addr));
            _context._utils.SigScan(AUITownMapActor_LocationDetailsTintColor_SIG, "AUITownMapActor::LocationDetailsTintColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUITownMapActor_LocationDetailsTintColorImpl, out _bgTintColorWrapper)}",
                };
                _bgTintColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMapActor_LocationDetailsTopLeft_SIG, "AUITownMapActor::LocationDetailsTopLeft", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUITownmapActor_LocationDetailsTopLeftTextImpl, out _topLeftColorWrapper)}",
                };
                _topLeftColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMapActor_LocationDetailsLowerBand_SIG, "AUITownMapActor::LocationDetailsLowerBand", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUITownmapActor_LocationDetailsTopLeftBgImpl, out _lowerBandWrapper)}",
                };
                _lowerBand = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMapActor_LocationDetailsText_SIG, "AUITownMapActor::LocationDetailsText", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUITownmapActor_LocationDetailsTopLeftTextImpl, out _detailsTextWrapper)}",
                };
                _detailsText = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUITownMap_LocationSubtleShadow_SIG, "AUITownMap::LocationSubtleShadow", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.LocationSubtleShadowColor.B:X}",
                    $"mov dl, ${_context._config.LocationSubtleShadowColor.G:X}",
                    $"mov cl, ${_context._config.LocationSubtleShadowColor.R:X}"
                };
                _locationSubtleShadow = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMap_LocationRoundedOutline_SIG, "AUITownMap::LocationRoundedOutline", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.PreviewRoundedOutline.B:X}",
                    $"mov dl, ${_context._config.PreviewRoundedOutline.G:X}",
                    $"mov cl, ${_context._config.PreviewRoundedOutline.R:X}"
                };
                _locationRoundedOutline = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMap_LocationPreviewTaint_SIG, "AUITownMap::LocationPreviewTaint", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.PreviewTaintColor.B:X}",
                    $"mov dl, ${_context._config.PreviewTaintColor.G:X}",
                    $"mov cl, ${_context._config.PreviewTaintColor.R:X}"
                };
                _locationPreviewTaint = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMap_LocationMiniIndicator_SIG, "AUITownMap::LocationMiniIndicator", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.MiniLocationCircleColor.B:X}",
                    $"mov dl, ${_context._config.MiniLocationCircleColor.G:X}",
                    $"mov cl, ${_context._config.MiniLocationCircleColor.R:X}"
                };
                _locationMiniIndicator = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMap_LocationMiniIndicatorSubtleShadow_SIG, "AUITownMap::LocationMiniIndicatorSubtleShadow", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.LocationSubtleShadowColor.B:X}",
                    $"mov dl, ${_context._config.LocationSubtleShadowColor.G:X}",
                    $"mov cl, ${_context._config.LocationSubtleShadowColor.R:X}"
                };
                _locationMiniIndicatorSubtleShadow = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
    }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        private unsafe FSprColor AUITownmapActor_LocationDetailsTopLeftBgImpl(FSprColor source) => ConfigColor.ToFSprColorWithAlpha(_context._config.TownMapLocationDetailsTopLeftBg, source.A);
        private unsafe FSprColor AUITownmapActor_LocationDetailsTopLeftTextImpl(FSprColor source) => ConfigColor.ToFSprColorWithAlpha(_context._config.TownMapLocationDetailsTopLeftText, source.A);
        private unsafe FSprColor AUITownMapActor_LocationDetailsTintColorImpl(FSprColor source) => ConfigColor.ToFSprColorWithAlpha(_context._config.TownMapLocationDetailsBgTint, source.A);

        private unsafe FSprColor AUITownMapActor_TownMapTextColorImpl() => ConfigColor.ToFSprColor(_context._config.TownMapTextColor);
        private unsafe FSprColor AUITownMapActor_TownMapBorderColorImpl() => ConfigColor.ToFSprColor(_context._config.TownMapBorderColor);

        private unsafe void FTownMapMarker2_UpdateStateImpl(FTownMapMarker2* self, float deltaTime)
        {
            _townMapMarkerUpdateState.OriginalFunction(self, deltaTime);
            ConfigColor.SetColorIgnoreAlpha(ref self->IconColor, _context.ColorWhite);
            ConfigColor.SetColorCustomAlpha(ref self->MarkerOutline.color, _context._config.TownMapSelectedMarkerOutline, 0x80);
        }

        [Function(new Register[] {}, FunctionAttribute.Register.rax, false)]
        private unsafe delegate FSprColor AUITownMapActor_TownMapSetUICompColor();

        [Function(FunctionAttribute.Register.rax, FunctionAttribute.Register.rax, false)]
        private unsafe delegate FSprColor AUITownMapActor_InjectColorAfterCtor(FSprColor source);

        private unsafe delegate void FTownMapMarker2_UpdateState(FTownMapMarker2* self, float deltaTime);
    }
}
