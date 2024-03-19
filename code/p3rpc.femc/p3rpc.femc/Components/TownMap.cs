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

        private UICommon _uiCommon;

        private IAsmHook _townMapTextColor;
        private IAsmHook _townMapBorderColor;

        private IReverseWrapper<AUITownMapActor_TownMapSetUICompColor> _townMapTextColorWrapper;
        private IReverseWrapper<AUITownMapActor_TownMapSetUICompColor> _townMapBorderColorWrapper;

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
            // todo: recolor marker icons for T_UI_TownMap_00_texture to a color that's visible
            //_context._utils.SigScan(FTownMapMarker2_UpdateState_SIG, "FTownMapMarker2::UpdateState", _context._utils.GetDirectAddress, addr => _townMapMarkerUpdateState = _context._utils.MakeHooker<FTownMapMarker2_UpdateState>(FTownMapMarker2_UpdateStateImpl, addr));
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        private unsafe FSprColor AUITownMapActor_TownMapTextColorImpl() => ConfigColor.ToFSprColor(_context._config.TownMapTextColor);
        private unsafe FSprColor AUITownMapActor_TownMapBorderColorImpl() => ConfigColor.ToFSprColor(_context._config.TownMapBorderColor);

        private unsafe void FTownMapMarker2_UpdateStateImpl(FTownMapMarker2* self, float deltaTime)
        {
            _townMapMarkerUpdateState.OriginalFunction(self, deltaTime);
            ConfigColor.SetColor(ref self->IconColor, _context.ColorWhite);
        }

        [Function(new Register[] {}, FunctionAttribute.Register.rax, false)]
        private unsafe delegate FSprColor AUITownMapActor_TownMapSetUICompColor();

        private unsafe delegate void FTownMapMarker2_UpdateState(FTownMapMarker2* self, float deltaTime);
    }
}
