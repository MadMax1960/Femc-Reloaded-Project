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
    public class MsgWindowSystem : ModuleBase<FemcContext> // also used by MsgWindowPerformance
    {
        // Background color is stored in BP_TutrialWindow
        //private string AitfMsgProgWindow_TUTRIALDraw_DrawInfoTextColor_SIG = "E8 ?? ?? ?? ?? 0F B6 93 ?? ?? ?? ?? 44 0F 28 4C 24 ??";
        private string AitfMsgProgWindow_TUTRIALDraw_DrawInfoTextColor_SIG = "40 88 BC 24 ?? ?? ?? ?? 44 8B 84 24 ?? ?? ?? ?? F3 0F 11 74 24 ?? F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? 0F B6 93 ?? ?? ?? ??";
        //private string AitfMsgProgWindow_TUTRIALDraw_DrawBottomRightColor_SIG = "E8 ?? ?? ?? ?? 44 38 B6 ?? ?? ?? ?? 0F 84 ?? ?? ?? ?? 48 8B 86d ?? ?? ?? ??";
        private string AitfMsgProgWindow_TUTRIALDraw_DrawBottomRightColor_SIG = "44 8B 45 ?? F3 44 0F 11 44 24 ??";
        private string AitfMsgProgWindow_TUTRIALDraw_Update_SIG = "80 B9 ?? ?? ?? ?? 00 0F 28 C1 F3 0F 58 81 ?? ?? ?? ?? 0F 28 D1";
        private UICommon _uiCommon;
        private IHook<AitfMsgProgWindow_TUTRIALDraw_Update> _update;
        private IAsmHook _drawInfoTextColor;
        private IAsmHook _drawBottomRightColor;
        //private IReverseWrapper<AitfMsgProgWindow_TUTRIALDraw_SetElementColor> _drawInfoTextColorWrapper;
        //private IReverseWrapper<AitfMsgProgWindow_TUTRIALDraw_SetElementColor> _drawBottomRightColorWrapper;

        //private bool firstTime = false;
        public unsafe MsgWindowSystem(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(AitfMsgProgWindow_TUTRIALDraw_DrawInfoTextColor_SIG, "AitfMsgProgWindow_TUTRIALDraw::DrawInfoTextColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rsp + 0xa8], {_context._config.MsgSimpleSystemLightColor.ToU32ARGB()}"
                    //$"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AitfMsgProgWindow_TUTRIALDraw_DrawElementLightColor, out _drawInfoTextColorWrapper)}",
                };
                _drawInfoTextColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AitfMsgProgWindow_TUTRIALDraw_DrawBottomRightColor_SIG, "AitfMsgProgWindow_TUTRIALDraw::DrawBottomRightColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rbp - 0x80], {_context._config.MsgSimpleSystemLightColor.ToU32ARGB()}",
                    $"mov byte [rbp - 0x7d], r15b"
                    //$"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AitfMsgProgWindow_TUTRIALDraw_DrawElementLightColor, out _drawBottomRightColorWrapper)}",
                };
                _drawBottomRightColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AitfMsgProgWindow_TUTRIALDraw_Update_SIG, "AitfMsgProgWindow_TUTRIALDraw::Update", _context._utils.GetDirectAddress, addr => _update = _context._utils.MakeHooker<AitfMsgProgWindow_TUTRIALDraw_Update>(AitfMsgProgWindow_TUTRIALDraw_UpdateImpl, addr));
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        //private unsafe FColor AitfMsgProgWindow_TUTRIALDraw_DrawElementLightColor(FColor color) => _uiCommon.ToFColorWithAlpha(_context._config.MsgSimpleSystemLightColor, color.A);
        private unsafe void AitfMsgProgWindow_TUTRIALDraw_UpdateImpl(AitfMsgProgWindow_TUTRIALDraw* self, float deltaTime)
        {
            /*
            if (!firstTime)
            {
                _context.FindObject("a");
                firstTime = true;
            }
            */
            _update.OriginalFunction(self, deltaTime);
            ConfigColor.SetColorIgnoreAlpha(ref self->NavyColor, _context._config.MsgSimpleSystemDarkColor);
            ConfigColor.SetColorIgnoreAlpha(ref self->GradationColor, _context._config.MsgSimpleSystemGradationColor);
        }

        [Function(FunctionAttribute.Register.r8, FunctionAttribute.Register.r8, false)]
        private unsafe delegate FColor AitfMsgProgWindow_TUTRIALDraw_SetElementColor(FColor color);
        private unsafe delegate void AitfMsgProgWindow_TUTRIALDraw_Update(AitfMsgProgWindow_TUTRIALDraw* self, float deltaTime);
    }
}
