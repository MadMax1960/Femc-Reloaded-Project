using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using Reloaded.Hooks.Definitions.X64;
using Reloaded.Memory.Pointers;
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

        private string FKeyHelpButtonAuto_DrawTextFillColor_SIG = "83 F8 01 77 ?? B2 24";
        private string FKeyHelpButtonAuto_DrawTextFillColorTransOut_SIG = "E8 ?? ?? ?? ?? 48 8B 4C 24 ?? 45 33 C0 33 D2 E8 ?? ?? ?? ?? B9 01 00 00 00";
        private string FKeyHelpButtonAuto_DrawTextTriangleColor_SIG = "48 8B 54 24 ?? 48 8D 4C 24 ?? 0F 57 DB 89 44 24 ??";

        private string FKeyHelpButtonFastForward_UpdateState_SIG = "48 8D 05 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 48 89 07 E8 ?? ?? ?? ?? 48 8D 05 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ??";
        // this signature sucks, usually sigs for in function asm hooks are way shorter
        private string FKeyHelpButtonFastForward_TriangleColor1_SIG = "41 0F 28 D9 89 45 ?? 41 0F 28 D1 48 8D 4C 24 ?? 48 8B D6 E8 ?? ?? ?? ?? F3 0F 10 87 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? F3 0F 10 8F ?? ?? ?? ?? F3 0F 11 44 24 ?? 0F 28 05 ?? ?? ?? ?? 0F 29 44 24 ?? F3 0F 11 4C 24 ?? C7 44 24 ?? 00 00 00 00 C7 45 ?? 00 00 00 00 E8 ?? ?? ?? ?? F3 0F 59 05 ?? ?? ?? ?? F3 0F 59 05 ?? ?? ?? ??";
        private string FKeyHelpButtonFastForward_TriangleColor2_SIG = "41 0F 28 D9 89 45 ?? 41 0F 28 D1 48 8D 4C 24 ?? 48 8B D6 E8 ?? ?? ?? ?? 33 D2";
        private string FKeyHelpButtonFastForward_TriangleColor3_SIG = "41 0F 28 D9 89 45 ?? 41 0F 28 D1 48 8D 4C 24 ?? 48 8B D6 E8 ?? ?? ?? ?? F3 0F 10 87 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? F3 0F 10 8F ?? ?? ?? ?? F3 0F 11 44 24 ?? 0F 28 05 ?? ?? ?? ?? 0F 29 44 24 ?? F3 0F 11 4C 24 ?? C7 44 24 ?? 00 00 00 00 C7 45 ?? 00 00 00 00 E8 ?? ?? ?? ?? F3 0F 59 05 ?? ?? ?? ?? F3 41 0F 59 C0";

        private string FKeyHelpButtonMovie_UpdateState_SIG = "40 55 56 41 55 48 8D 6C 24 ?? 48 81 EC 20 01 00 00";

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
        private IHook<FKeyHelpButtonMovie_UpdateState> _movieUpdateState;

        public unsafe KeyHelp(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(FKeyHelpButtonAuto_DrawTextFillColor_SIG, "FKeyHelpButtonAuto::DrawTextFillColor", _context._utils.GetDirectAddress, addr =>
            {
                // get expected length of hook, min 7 bytes to be safe
                // https://github.com/Reloaded-Project/Reloaded.Hooks/blob/master/source/Reloaded.Hooks.Definitions/AsmHookOptions.cs
                // if hook is expected to be more than 7 bytes, it'll overwrite the call instruction
                var hookLength = _context._hooks.Utilities.GetHookLength((nint)addr, 7, true);
                List<string> function = new()
                {
                    "use64",
                    $"cmp eax, 0x1",
                    $"ja hookEnd",
                    $"mov r9b, ${_context._config.ButtonPromptHighlightColor.B:X}",
                    $"mov r8b, ${_context._config.ButtonPromptHighlightColor.G:X}",
                    $"mov dl, ${_context._config.ButtonPromptHighlightColor.R:X}",
                    $"label hookEnd"
                };
                if (hookLength > 7)
                    function.Add($"call {Utils.GetGlobalAddress((nint)(addr + 8))}");
                _autoDrawTextFillColor = _context._hooks.CreateAsmHook(function.ToArray(), addr, AsmHookBehaviour.DoNotExecuteOriginal).Activate();
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
            _context._utils.SigScan(FKeyHelpButtonMovie_UpdateState_SIG, "FKeyHelpButtonMovie::UpdateState", _context._utils.GetDirectAddress, addr => _movieUpdateState = _context._utils.MakeHooker<FKeyHelpButtonMovie_UpdateState>(FKeyHelpButtonMovie_UpdateStateImpl, addr));
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }
        public unsafe FSprColor FKeyHelpButtonAuto_DrawTextFillColor(FKeyHelpButtonAuto* self) => ConfigColor.ToFSprColor(_context._config.ButtonPromptHighlightColor);

        public unsafe FSprColor FKeyHelpButtonAuto_DrawTextTriangleColor(FKeyHelpButtonAuto* self)
        {
            var newColor = ConfigColor.ToFSprColor(_context._config.ButtonPromptTriangleColor);
            newColor.A = (byte)((UICommon.Clamp_1413033e0(&self->Field540) * 0.7 * 255 + 76.5) * self->Super.KeyHelpTransparency);
            return newColor;
        }

        public unsafe FSprColor FKeyHelpButtonFastForward_DrawTextTriangleColor(FKeyHelpButtonFastForward* self)
        {
            var newColor = ConfigColor.ToFSprColor(_context._config.ButtonPromptTriangleColor);
            newColor.A = (byte)((UICommon.Clamp_1413033e0(&self->Field538) * 0.7 * 255 + 76.5) * self->Super.KeyHelpTransparency);
            return newColor;
        }

        private unsafe void FKeyHelpButtonBase_SetTextButtonColor(FKeyHelpButtonBase* self, float opacity)
        {
            var newColor = _context._config.ButtonPromptHighlightColor;
            newColor.A = (byte)(opacity * 255);
            self->TextLayout.Color = ConfigColor.ToFSprColor(newColor);
            for (int i = 0; i < self->SpriteCount; i++)
                self->GetSpriteLayout(i)->Color = ConfigColor.ToFSprColor(newColor);
        }

        public unsafe void FKeyHelpButtonFastForward_UpdateStateImpl(FKeyHelpButtonFastForward* self, float deltaTime, nint a3, float opacity)
        {
            _ffwdUpdateState.OriginalFunction(self, deltaTime, a3, opacity);
            if (self->ActivationState == 1 || self->ActivationState == 2)
            {
                FKeyHelpButtonBase_SetTextButtonColor(&self->Super, opacity);
            }
        }
        public unsafe void FKeyHelpButtonMovie_UpdateStateImpl(FKeyHelpButtonBase* self, float deltaTime, nint a3, float opacity)
        {
            _movieUpdateState.OriginalFunction(self, deltaTime, a3, opacity);
            FKeyHelpButtonBase_SetTextButtonColor(self, opacity);
            self->moviePauseMainColor = ConfigColor.ToFSprColorWithAlpha(_context._config.ButtonPromptHighlightColor, self->moviePauseMainColor.A);
            self->moviePausePulseColor = ConfigColor.ToFSprColorWithAlpha(_context._config.ButtonPromptHighlightColor, self->moviePausePulseColor.A);
        }

        [Function(FunctionAttribute.Register.rdi, FunctionAttribute.Register.rax, false)]
        public unsafe delegate FSprColor FKeyHelpButtonAuto_DrawTextColor(FKeyHelpButtonAuto* self);
        [Function(FunctionAttribute.Register.rdi, FunctionAttribute.Register.rax, false)]
        public unsafe delegate FSprColor FKeyHelpButtonFastForward_DrawTriangleColor(FKeyHelpButtonFastForward* self);
        public unsafe delegate void FKeyHelpButtonFastForward_UpdateState(FKeyHelpButtonFastForward* self, float deltaTime, nint a3, float opacity);
        public unsafe delegate void FKeyHelpButtonMovie_UpdateState(FKeyHelpButtonBase* self, float deltaTime, nint a3, float opacity);
    }
}
