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
    public class DayChange : ModuleBase
    {
        private UICommon _uiCommon;
        private string AUIDayChange_UpdateParams_SIG = "48 8B C4 55 53 56 57 41 54 41 55 48 8D 6C 24 ??";
        private string AUIDayChange_CurrentDayMoonShadowColor_SIG = "F3 0F 10 03 F3 41 0F 58 FE";
        // AUIDayChange::DrawDaysUntilFullMoon
        private string AUIDayChange_DrawDaysUntilFullMoon1_SIG = "F3 0F 10 05 ?? ?? ?? ?? 45 33 ED F3 0F 10 0D ?? ?? ?? ?? 48 8B CB";
        private string AUIDayChange_DrawDaysUntilFullMoon2_SIG = "F3 0F 10 0D ?? ?? ?? ?? F3 44 0F 10 1D ?? ?? ?? ?? F3 0F 11 4D ??";
        private string AUIDayChange_DrawDaysUntilFullMoon3_SIG = "F3 0F 10 05 ?? ?? ?? ?? 48 8B CB F3 0F 10 1D ?? ?? ?? ?? F3 0F 10 15 ?? ?? ?? ?? F3 0F 10 0D ?? ?? ?? ??";
        // In AUIDayChange::DrawRippleEffect
        private string AUIDayChange_DrawNextDayRipple1_SIG = "0F 28 05 ?? ?? ?? ?? 48 8D 54 24 ?? 48 8B CF 89 44 24 ??";
        private string AUIDayChange_DrawNextDayRipple2_SIG = "0F 28 05 ?? ?? ?? ?? 48 8D 54 24 ?? 48 8B CF 89 45 ?? 0F 11 45 ?? C7 45 ?? 00 00 00 00 C7 45 ?? 00 00 00 00 C7 45 ?? 00 00 00 40 E8 ?? ?? ?? ?? F3 0F 10 40 ??";

        private IHook<AUIDayChange_UpdateParams> _updateParams;

        private IAsmHook _currentDayMoonShadowColor;
        private IAsmHook _drawDaysUntilFullMoon1;
        private IAsmHook _drawDaysUntilFullMoon2;
        private IAsmHook _drawDaysUntilFullMoon3;
        private IAsmHook _drawNextDayRipple1;
        private IAsmHook _drawNextDayRipple2;
        private IReverseWrapper<AUIDayChange_SetColorPassthrough> _currentDayMoonShadowColorWrapper;
        private IReverseWrapper<AUIDayChange_SetColorPassthrough> _drawDaysUntilFullMoon1Wrapper;
        private IReverseWrapper<AUIDayChange_SetColorPassthrough> _drawDaysUntilFullMoon2Wrapper;
        private IReverseWrapper<AUIDayChange_SetColorPassthrough> _drawDaysUntilFullMoon3Wrapper;
        private IReverseWrapper<AUIDayChange_SetColorPassthrough> _drawNextDayRipple1Wrapper;
        private IReverseWrapper<AUIDayChange_SetColorPassthrough> _drawNextDayRipple2Wrapper;
        public unsafe DayChange(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUIDayChange_UpdateParams_SIG, "AUIDayChange::UpdateParams", _context._utils.GetDirectAddress, addr => _updateParams = _context._utils.MakeHooker<AUIDayChange_UpdateParams>(AUIDayChange_UpdateParamsImpl, addr));
            _context._utils.SigScan(AUIDayChange_CurrentDayMoonShadowColor_SIG, "AUIDayChange::CurrentDayMoonSahdowColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUIDayChange_CurrentDayMoonShadowColor, out _currentDayMoonShadowColorWrapper)}",
                };
                _currentDayMoonShadowColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIDayChange_DrawDaysUntilFullMoon1_SIG, "AUIDayChange::DaysUntilFullMoonColor1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUIDayChange_DrawDaysUntilFullMoon, out _drawDaysUntilFullMoon1Wrapper)}",
                };
                _drawDaysUntilFullMoon1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIDayChange_DrawDaysUntilFullMoon2_SIG, "AUIDayChange::DaysUntilFullMoonColor2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUIDayChange_DrawDaysUntilFullMoon, out _drawDaysUntilFullMoon2Wrapper)}",
                };
                _drawDaysUntilFullMoon2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIDayChange_DrawDaysUntilFullMoon3_SIG, "AUIDayChange::DaysUntilFullMoonColor3", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUIDayChange_DrawDaysUntilFullMoon, out _drawDaysUntilFullMoon3Wrapper)}",
                };
                _drawDaysUntilFullMoon3 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIDayChange_DrawNextDayRipple1_SIG, "AUIDayChange::DrawNextDayRipple1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUIDayChange_DrawNextDayRipple, out _drawNextDayRipple1Wrapper)}",
                };
                _drawNextDayRipple1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIDayChange_DrawNextDayRipple2_SIG, "AUIDayChange::DrawNextDayRipple2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUIDayChange_DrawNextDayRipple, out _drawNextDayRipple2Wrapper)}",
                };
                _drawNextDayRipple2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        public unsafe void AUIDayChange_UpdateParamsImpl(AUIDayChange* self, float deltaTime)
        {
            _updateParams.OriginalFunction(self, deltaTime);
            _uiCommon.SetColor(ref self->BandColorPrevDay, _context._config.NextDayBandColor);
            _uiCommon.SetColor(ref self->BandColorNextDay, _context._config.NextDayBandColor);
            _uiCommon.SetColor(ref self->LimitTextColor, _context._config.NextDayTextColor);
        }

        private unsafe FSprColor AUIDayChange_SetColorIgnoreAlpha(FSprColor source, Configuration.ConfigColor confColor)
        {
            var oldAlpha = source.A;
            var newColor = _uiCommon.ToFSprColor(confColor);
            newColor.A = oldAlpha;
            return newColor;
        }
        private unsafe FSprColor AUIDayChange_CurrentDayMoonShadowColor(FSprColor source) => AUIDayChange_SetColorIgnoreAlpha(source, _context._config.NextDayMoonShadowColor);
        private unsafe FSprColor AUIDayChange_DrawDaysUntilFullMoon(FSprColor source) => AUIDayChange_SetColorIgnoreAlpha(source, _context._config.NextDayTextColor);
        private unsafe FSprColor AUIDayChange_DrawNextDayRipple(FSprColor source) => AUIDayChange_SetColorIgnoreAlpha(source, _context._config.NextDayRipple);

        public unsafe delegate void AUIDayChange_UpdateParams(AUIDayChange* self, float deltaTime);
        [Function(FunctionAttribute.Register.rax, FunctionAttribute.Register.rax, false)]
        private unsafe delegate FSprColor AUIDayChange_SetColorPassthrough(FSprColor source);
    }

    public class TimeChange : ModuleBase
    {
        private UICommon _uiCommon;
        private string AUITimeChange_UpdateParams_SIG = "48 8B C4 48 89 58 ?? 48 89 70 ?? 48 89 78 ?? 55 41 56 41 57 48 8D 68 ?? 48 81 EC E0 00 00 00 0F 29 70 ??";
        private string AUITimeChange_TimeOfDayOverlapColor_SIG = "89 86 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ?? 4C 8B 46 ??";

        private IHook<AUITimeChange_UpdateParams> _updateParams;
        private IAsmHook _todOverlapColor;
        private IReverseWrapper<AUITimeChange_TimeOfDayOverlapColor> _todOverlapColorWrapper;
        public unsafe TimeChange(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUITimeChange_UpdateParams_SIG, "AUITimeChange::UpdateParams", _context._utils.GetDirectAddress, addr => _updateParams = _context._utils.MakeHooker<AUITimeChange_UpdateParams>(AUITimeChange_UpdateParamsImpl, addr));
            _context._utils.SigScan(AUITimeChange_TimeOfDayOverlapColor_SIG, "AUITimeChange::TimeOfDayOverlapColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUITimeChange_TimeOfDayOverlapColorImpl, out _todOverlapColorWrapper)}",
                };
                _todOverlapColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        public unsafe void AUITimeChange_UpdateParamsImpl(AUITimeChange* self, float deltaTime)
        {
            _updateParams.OriginalFunction(self, deltaTime);
            _uiCommon.SetColor(ref self->MainBarColor, _context._config.TimeSkipColor);
            _uiCommon.SetColor(ref self->TopBarColor, _context._config.TimeSkipColor);
        }
        private unsafe FSprColor AUITimeChange_TimeOfDayOverlapColorImpl() => _uiCommon.ToFSprColor(_context._config.TimeSkipColor);
        public unsafe delegate void AUITimeChange_UpdateParams(AUITimeChange* self, float deltaTime);
        [Function(new Register[] { }, FunctionAttribute.Register.rax, false)]
        private unsafe delegate FSprColor AUITimeChange_TimeOfDayOverlapColor();
    }
}
