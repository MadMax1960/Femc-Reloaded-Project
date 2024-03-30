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

namespace p3rpc.femc.Components
{
    public class KeyHelp : ModuleBase<FemcContext>
    {
        private UICommon _uiCommon;

        //private string FKeyHelpButtonAuto_DrawTextFillColor_SIG = "83 BF ?? ?? ?? ?? 00 0F 28 BC 24 ?? ?? ?? ?? 0F 28 B4 24 ?? ?? ?? ?? 0F 84 ?? ?? ?? ??";
        //private string FKeyHelpButtonAuto_DrawTextFillColor_SIG = "41 0F B6 D1 83 F8 01";
        private string FKeyHelpButtonAuto_DrawTextFillColor_SIG = "83 F8 01 77 ?? B2 24";
        private string FKeyHelpButtonAuto_DrawTextFillColorTransOut_SIG = "E8 ?? ?? ?? ?? 48 8B 4C 24 ?? 45 33 C0 33 D2 E8 ?? ?? ?? ?? B9 01 00 00 00";
        private string FKeyHelpButtonAuto_DrawTextTriangleColor_SIG = "48 8B 54 24 ?? 48 8D 4C 24 ?? 0F 57 DB 89 44 24 ??";

        private string FKeyHelpButtonFastForward_UpdateState_SIG = "48 8D 05 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 89 07 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ??";
        // this signature sucks, usually sigs for in function asm hooks are way shorter
        private string FKeyHelpButtonFastForward_TriangleColor1_SIG = "41 0F 28 D9 89 45 ?? 41 0F 28 D1 48 8D 4C 24 ?? 48 8B D6 E8 ?? ?? ?? ?? F3 0F 10 87 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? F3 0F 10 8F ?? ?? ?? ?? F3 0F 11 44 24 ?? 0F 28 05 ?? ?? ?? ?? 0F 29 44 24 ?? F3 0F 11 4C 24 ?? C7 44 24 ?? 00 00 00 00 C7 45 ?? 00 00 00 00 E8 ?? ?? ?? ?? F3 0F 59 05 ?? ?? ?? ?? F3 0F 59 05 ?? ?? ?? ??";
        private string FKeyHelpButtonFastForward_TriangleColor2_SIG = "41 0F 28 D9 89 45 ?? 41 0F 28 D1 48 8D 4C 24 ?? 48 8B D6 E8 ?? ?? ?? ?? 33 D2";
        private string FKeyHelpButtonFastForward_TriangleColor3_SIG = "41 0F 28 D9 89 45 ?? 41 0F 28 D1 48 8D 4C 24 ?? 48 8B D6 E8 ?? ?? ?? ?? F3 0F 10 87 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? F3 0F 10 8F ?? ?? ?? ?? F3 0F 11 44 24 ?? 0F 28 05 ?? ?? ?? ?? 0F 29 44 24 ?? F3 0F 11 4C 24 ?? C7 44 24 ?? 00 00 00 00 C7 45 ?? 00 00 00 00 E8 ?? ?? ?? ?? F3 0F 59 05 ?? ?? ?? ?? F3 41 0F 59 C0";

        private IAsmHook _autoDrawTextFillColor;
        private IAsmHook _autoDrawTextTriangleColor;
        private IAsmHook _autoDrawTextFillTransOutColor;

        private IAsmHook _ffwdDrawTriangle1;
        private IAsmHook _ffwdDrawTriangle2;
        private IAsmHook _ffwdDrawTriangle3;

        //private IReverseWrapper<FKeyHelpButtonAuto_DrawTextColor> _autoDrawTextFillColorWrapper;
        private IReverseWrapper<FKeyHelpButtonAuto_DrawTextColor> _autoDrawTextTriangleColorWrapper;
        private IReverseWrapper<FKeyHelpButtonFastForward_DrawTriangleColor> _ffwdDrawTriangleColorWrapper1;
        private IReverseWrapper<FKeyHelpButtonFastForward_DrawTriangleColor> _ffwdDrawTriangleColorWrapper2;
        private IReverseWrapper<FKeyHelpButtonFastForward_DrawTriangleColor> _ffwdDrawTriangleColorWrapper3;

        private IHook<FKeyHelpButtonFastForward_UpdateState> _ffwdUpdateState;

        public unsafe KeyHelp(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(FKeyHelpButtonAuto_DrawTextFillColor_SIG, "FKeyHelpButtonAuto::DrawTextFillColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"cmp eax, 0x1",
                    $"ja hookEnd",
                    $"mov r9b, ${_context._config.ButtonPromptHighlightColor.B:X}",
                    $"mov r8b, ${_context._config.ButtonPromptHighlightColor.G:X}",
                    $"mov dl, ${_context._config.ButtonPromptHighlightColor.R:X}",
                    $"label hookEnd",
                };
                _autoDrawTextFillColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.DoNotExecuteOriginal).Activate();
            });
            _context._utils.SigScan(FKeyHelpButtonAuto_DrawTextTriangleColor_SIG, "FKeyHelpButtonAuto::DrawTextTriangleColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(FKeyHelpButtonAuto_DrawTextTriangleColor, out _autoDrawTextTriangleColorWrapper)}",
                };
                _autoDrawTextTriangleColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(FKeyHelpButtonAuto_DrawTextFillColorTransOut_SIG, "FKeyHelpButtonAuto::DrawTextFillColorTransOut", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r9b, ${_context._config.ButtonPromptHighlightColor.B:X}",
                    $"mov r8b, ${_context._config.ButtonPromptHighlightColor.G:X}",
                    $"mov dl, ${_context._config.ButtonPromptHighlightColor.R:X}",
                };
                _autoDrawTextFillTransOutColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(FKeyHelpButtonFastForward_UpdateState_SIG, "FKeyHelpButtonFastForward::UpdateState", 
            offset =>
            {
                var vtableLoc = _context._utils.GetIndirectAddressLong(offset);
                return *((nuint*)vtableLoc + 1); // UpdateState is second entry
            }, 
            addr => _ffwdUpdateState = _context._utils.MakeHooker<FKeyHelpButtonFastForward_UpdateState>(FKeyHelpButtonFastForward_UpdateStateImpl, addr));
            _context._utils.SigScan(FKeyHelpButtonFastForward_TriangleColor1_SIG, "FKeyHelpButtonFastForward::DrawTriangleColor1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(FKeyHelpButtonFastForward_DrawTextTriangleColor, out _ffwdDrawTriangleColorWrapper1)}",
                };
                _ffwdDrawTriangle1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(FKeyHelpButtonFastForward_TriangleColor2_SIG, "FKeyHelpButtonFastForward::DrawTriangleColor2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(FKeyHelpButtonFastForward_DrawTextTriangleColor, out _ffwdDrawTriangleColorWrapper2)}",
                };
                _ffwdDrawTriangle2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(FKeyHelpButtonFastForward_TriangleColor3_SIG, "FKeyHelpButtonFastForward::DrawTriangleColor3", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(FKeyHelpButtonFastForward_DrawTextTriangleColor, out _ffwdDrawTriangleColorWrapper3)}",
                };
                _ffwdDrawTriangle3 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }
        public unsafe FSprColor FKeyHelpButtonAuto_DrawTextFillColor(FKeyHelpButtonAuto* self) => ConfigColor.ToFSprColor(_context._config.ButtonPromptHighlightColor);

        private unsafe float Clamp_1413033e0(FKeyHelpInterpolate* val)
        {
            var ret = val->Field1C / val->Field20;
            if (ret < 0) return 0;
            else if (ret > 1) return 1;
            else return ret;
        }

        public unsafe FSprColor FKeyHelpButtonAuto_DrawTextTriangleColor(FKeyHelpButtonAuto* self)
        {
            var newColor = ConfigColor.ToFSprColor(_context._config.ButtonPromptTriangleColor);
            newColor.A = (byte)((Clamp_1413033e0(&self->Field540) * 0.7 * 255 + 76.5) * self->Super.KeyHelpTransparency);
            return newColor;
        }

        public unsafe FSprColor FKeyHelpButtonFastForward_DrawTextTriangleColor(FKeyHelpButtonFastForward* self)
        {
            var newColor = ConfigColor.ToFSprColor(_context._config.ButtonPromptTriangleColor);
            newColor.A = (byte)((Clamp_1413033e0(&self->Field538) * 0.7 * 255 + 76.5) * self->Super.KeyHelpTransparency);
            return newColor;
        }

        public unsafe void FKeyHelpButtonFastForward_UpdateStateImpl(FKeyHelpButtonFastForward* self, float deltaTime, nint a3, float opacity)
        {
            _ffwdUpdateState.OriginalFunction(self, deltaTime, a3, opacity);
            if (self->ActivationState == 1 || self->ActivationState == 2)
            {
                var newColor = _context._config.ButtonPromptHighlightColor;
                newColor.A = (byte)(opacity * 255);
                self->Super.TextLayout.Color = ConfigColor.ToFSprColor(newColor);
                for (int i = 0; i < self->Super.SpriteCount; i++)
                    self->Super.GetSpriteLayout(i)->Color = ConfigColor.ToFSprColor(newColor);
            }
        }

        [Function(FunctionAttribute.Register.rdi, FunctionAttribute.Register.rax, false)]
        public unsafe delegate FSprColor FKeyHelpButtonAuto_DrawTextColor(FKeyHelpButtonAuto* self);
        [Function(FunctionAttribute.Register.rdi, FunctionAttribute.Register.rax, false)]
        public unsafe delegate FSprColor FKeyHelpButtonFastForward_DrawTriangleColor(FKeyHelpButtonFastForward* self);
        public unsafe delegate void FKeyHelpButtonFastForward_UpdateState(FKeyHelpButtonFastForward* self, float deltaTime, nint a3, float opacity);
    }
}
