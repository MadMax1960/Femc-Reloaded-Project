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
    public class TitleMenu : ModuleBase<FemcContext>
    {
        private string ATitleActor_DrawPressAnyRectColor_SIG = "48 8D 55 ?? 89 45 ?? 48 8D 8B ?? ?? ?? ??";
        private string ATitleActor_DrawGameModeSelectRectColor_SIG = "48 8D 8F ?? ?? ?? ?? 89 45 ?? E8 ?? ?? ?? ?? 8B 8F ?? ?? ?? ??";

        private IAsmHook _pressAnyRectColor;
        private IAsmHook _gameModeSelectRectColor;
        private IReverseWrapper<ATitleActor_InjectColorAfterCtorCall> _pressAnyRectColorWrapper;
        private IReverseWrapper<ATitleActor_InjectColorAfterCtorCall> _gameModeSelectRectColorWrapper;
        public unsafe TitleMenu(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(ATitleActor_DrawPressAnyRectColor_SIG, "ATitleActor::DrawPressAnyRectColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._utils.PreserveMicrosoftRegisters()}",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(ATitleActor_InjectColorAfterCtorCallImpl, out _pressAnyRectColorWrapper)}",
                    $"{_context._utils.RetrieveMicrosoftRegisters()}",
                };
                _pressAnyRectColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(ATitleActor_DrawGameModeSelectRectColor_SIG, "ATitleActor::DrawGameModeSelectRectColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._utils.PreserveMicrosoftRegisters()}",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(ATitleActor_InjectColorAfterCtorCallImpl, out _gameModeSelectRectColorWrapper)}",
                    $"{_context._utils.RetrieveMicrosoftRegisters()}",
                };
                _gameModeSelectRectColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }
        public override void Register()
        {
        }

        [Function(FunctionAttribute.Register.rax, FunctionAttribute.Register.rax, false)]
        public unsafe FSprColor ATitleActor_InjectColorAfterCtorCallImpl(FSprColor source) => ConfigColor.ToFSprColorWithAlpha(_context._config.TitleMenuSelRectColor, source.A);

        [Function(FunctionAttribute.Register.rax, FunctionAttribute.Register.rax, false)]
        public unsafe delegate FSprColor ATitleActor_InjectColorAfterCtorCall(FSprColor source);
    }
}
