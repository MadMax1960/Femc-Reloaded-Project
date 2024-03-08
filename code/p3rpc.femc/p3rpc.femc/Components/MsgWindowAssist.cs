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
    public class MsgWindowAssist : ModuleBase
    {
        private string UMsgProcWindow_Assist_SetBgColor_SIG = "F3 0F 10 83 ?? ?? ?? ?? 44 8B C0 8B D0";

        private UICommon _uiCommon;

        private IAsmHook _assistSetBgColor;
        private IReverseWrapper<UMsgProcWindow_Assist_SetBgColor> _assistSetBgColorWrapper;
        public unsafe MsgWindowAssist(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
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
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }
        private unsafe FSprColor UMsgProcWindow_Assist_SetBgColorImpl(UMsgProcWindow_Assist* self)
        {
            var targetColor = _context._config.MsgAssistBgColor;
            targetColor.A = (byte)(self->Opacity * 255);
            return _uiCommon.ToFSprColor(targetColor);
        }

        [Function(FunctionAttribute.Register.rbx, FunctionAttribute.Register.rax, false)]
        private unsafe delegate FSprColor UMsgProcWindow_Assist_SetBgColor(UMsgProcWindow_Assist* self);
    }
}
