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
    public class MsgWindowAssist : ModuleBase<FemcContext>
    {
        private string UMsgProcWindow_Assist_SetBgColor_SIG = "F3 0F 10 83 ?? ?? ?? ?? 44 8B C0 8B D0";
        private string UMsgProcWindow_Assist_SetTextBgColor_SIG = "41 B8 08 00 00 00 48 8D 54 24 ?? 49 8B CE";
        private string UMsgProcWindow_Assist_SetSupportFontColor_SIG = "E8 ?? ?? ?? ?? 66 0F 6E 83 ?? ?? ?? ?? 48 8D 8D";

        private UICommon _uiCommon;

        private IAsmHook _assistSetBgColor;
        private IReverseWrapper<UMsgProcWindow_Assist_SetBgColor> _assistSetBgColorWrapper;
        private IAsmHook _assistSetTextBgColor;
        private IReverseWrapper<UMsgProcWindow_Assist_SetBgColor> _assistSetTextBgColorWrapper;
        private IAsmHook _assistSetSupportFontColor;
        public unsafe MsgWindowAssist(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(UMsgProcWindow_Assist_SetBgColor_SIG, "UMsgProcWindow_Assist::SetBgColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UMsgProcWindow_Assist_SetBgColorImpl, out _assistSetBgColorWrapper)}",
                };
                _assistSetBgColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UMsgProcWindow_Assist_SetTextBgColor_SIG, "UMsgProcWindow_Assist::SetTextBgColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UMsgProcWindow_Assist_SetTextBgColorImpl, out _assistSetTextBgColorWrapper)}",
                };
                _assistSetTextBgColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UMsgProcWindow_Assist_SetSupportFontColor_SIG, "UMsgProcWindow_Assist::SetSupportFontColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.MsgAssistSupportFontColor.B:X}",
                    $"mov dl, ${_context._config.MsgAssistSupportFontColor.G:X}",
                    $"mov cl, ${_context._config.MsgAssistSupportFontColor.R:X}"
                };
                _assistSetSupportFontColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }
        private unsafe FSprColor UMsgProcWindow_Assist_SetBgColorImpl(UMsgProcWindow_Assist* self)
        {
            var targetColor = _context._config.MsgAssistBgColor;
            targetColor.A = (byte)(self->Opacity * 255);
            return ConfigColor.ToFSprColor(targetColor);
        }

        private unsafe FSprColor UMsgProcWindow_Assist_SetTextBgColorImpl(UMsgProcWindow_Assist* self) => ConfigColor.ToFSprColorWithAlpha(_context._config.MsgAssistTextBgColor, (byte)(self->Opacity * 183.6f));

        [Function(FunctionAttribute.Register.rbx, FunctionAttribute.Register.rax, false)]
        private unsafe delegate FSprColor UMsgProcWindow_Assist_SetBgColor(UMsgProcWindow_Assist* self);
    }
}
