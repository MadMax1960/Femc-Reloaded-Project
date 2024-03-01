using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using Reloaded.Hooks.Definitions.X64;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Reloaded.Hooks.Definitions.X64.FunctionAttribute;

namespace p3rpc.femc.Components
{
    public class TownMap : ModuleBase
    {
        // In AUITownMapActor::DrawTownMapUIInner
        private string AUITownMapActor_TownMapTextColor_SIG = "48 8D 54 24 ?? 89 44 24 ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ??";
        private string AUITownMapActor_TownMapBorderColor_SIG = "48 8D 54 24 ?? 89 44 24 ?? 48 8D 8F ?? ?? ?? ?? 89 45 ??";

        private UICommon _uiCommon;

        private IAsmHook _townMapTextColor;
        private IAsmHook _townMapBorderColor;

        private IReverseWrapper<AUITownMapActor_TownMapSetUICompColor> _townMapTextColorWrapper;
        private IReverseWrapper<AUITownMapActor_TownMapSetUICompColor> _townMapBorderColorWrapper;

        public unsafe TownMap(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
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
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        private unsafe FSprColor AUITownMapActor_TownMapTextColorImpl() => _uiCommon.ToFSprColor(_context._config.TownMapTextColor);
        private unsafe FSprColor AUITownMapActor_TownMapBorderColorImpl() => _uiCommon.ToFSprColor(_context._config.TownMapBorderColor);

        [Function(new Register[] {}, FunctionAttribute.Register.rax, false)]
        private unsafe delegate FSprColor AUITownMapActor_TownMapSetUICompColor();
    }
}
