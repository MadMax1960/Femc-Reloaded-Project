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
    public class DifficultySelection : ModuleBase<FemcContext>
    {
        private string ADifficultySelectionActor_BackgroundColor_SIG = "F3 0F 10 83 ?? ?? ?? ?? 48 8D 4C 24 ?? F3 0F 10 9B ?? ?? ?? ??";
        private IAsmHook _bgColor;
        private IReverseWrapper<ADifficultySelectionActor_InjectColorAfterCtorCall> _bgColorWrapper;
        public unsafe DifficultySelection(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(ADifficultySelectionActor_BackgroundColor_SIG, "ADifficultySelectionActor::BackgroundColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(ADifficultySelectionActor_BackgroundColor, out _bgColorWrapper)}",
                };
                _bgColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }
        public override void Register()
        {
            
        }

        private unsafe FSprColor ADifficultySelectionActor_BackgroundColor(FSprColor source) => ConfigColor.ToFSprColorWithAlpha(_context._config.DifficultySelectBgColor, source.A);

        [Function(FunctionAttribute.Register.rax, FunctionAttribute.Register.rax, false)]
        public unsafe delegate FSprColor ADifficultySelectionActor_InjectColorAfterCtorCall(FSprColor self);
    }
}
