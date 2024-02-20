using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class DateTimePanel : ModuleBase
    {
        private string UAgePanel_UpdateAgePanelParameters_SIG = "40 55 56 41 57 48 8B EC 48 81 EC 80 00 00 00";
        private string AUIDateDraw_UpdateParams_SIG = "40 53 48 83 EC 70 4C 8B 81 ?? ?? ?? ??";
        private IHook<UAgePanel_UpdateAgePanelParameters> _updateAgePanelParameters;
        private IHook<AUIDateDraw_UpdateParams> _drawActorInner;

        private UICommon _uiCommon;
        public unsafe DateTimePanel(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(UAgePanel_UpdateAgePanelParameters_SIG, "UAgePanel::UpdateAgePanelParameters", _context._utils.GetDirectAddress, addr => _updateAgePanelParameters = _context._utils.MakeHooker<UAgePanel_UpdateAgePanelParameters>(UAgePanel_UpdateAgePanelParametersImpl, addr));
            _context._utils.SigScan(AUIDateDraw_UpdateParams_SIG, "AUIDrateDraw::UpdateParams", _context._utils.GetDirectAddress, addr => _drawActorInner = _context._utils.MakeHooker<AUIDateDraw_UpdateParams>(AUIDateDraw_UpdateParamsImpl, addr));
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        private unsafe void UAgePanel_UpdateAgePanelParametersImpl(UAgePanel* self, float deltaTime)
        {
            _uiCommon.SetColor(ref self->TopColorNormal, _context._config.DateTimePanelTopTextColor);
            _uiCommon.SetColor(ref self->BottomColorNormal, _context._config.DateTimePanelBottomTextColor);
            _uiCommon.SetColor(ref self->WaterColorNormal, _context._config.DateTimePanelWaterColor);
            _updateAgePanelParameters.OriginalFunction(self, deltaTime);
        }

        private unsafe void AUIDateDraw_UpdateParamsImpl(AUIDateDraw* self, long a2, long a3, long a4)
        {
            _drawActorInner.OriginalFunction(self, a2, a3, a4);
            if (self->TimeOfDay != 8) self->TimeOfDayParams.color = _uiCommon.ToFSprColor(_context._config.DateTimePanelBottomTextColor);
        }

        private unsafe delegate void UAgePanel_UpdateAgePanelParameters(UAgePanel* self, float deltaTime);
        private unsafe delegate void AUIDateDraw_UpdateParams(AUIDateDraw* self, long a2, long a3, long a4);
    }
}
