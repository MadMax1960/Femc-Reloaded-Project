using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class DateTimePanel : ModuleBase<FemcContext>
    {
        private string UAgePanel_UpdateAgePanelParameters_SIG = "40 55 56 41 57 48 8B EC 48 81 EC 80 00 00 00";
        private unsafe delegate void UAgePanel_UpdateAgePanelParameters(UAgePanel* self, float deltaTime);
        private IHook<UAgePanel_UpdateAgePanelParameters> _updateAgePanelParameters;

        private unsafe void UAgePanel_UpdateAgePanelParametersImpl(UAgePanel* self, float deltaTime)
        {
            ConfigColor.SetColor(ref self->TopColorNormal, _context._config.DateTimePanelTopTextColor);
            ConfigColor.SetColor(ref self->BottomColorNormal, _context._config.DateTimePanelBottomTextColor);
            ConfigColor.SetColor(ref self->WaterColorNormal, _context._config.DateTimePanelWaterColor);
            _updateAgePanelParameters.OriginalFunction(self, deltaTime);
        }

        private string UAgePanel_UpdateAgePanelParameters_EpAigis_SIG = "40 55 56 41 54 48 8B EC 48 81 EC 80 00 00 00";
        private unsafe delegate void UAgePanel_UpdateAgePanelParameters_EpAigis(nativetypes.Interfaces.Astrea.UAgePanel* self, float deltaTime);
        private IHook<UAgePanel_UpdateAgePanelParameters_EpAigis> _updateAgePanelParametersEpAigis;
        private unsafe void UAgePanel_UpdateAgePanelParameters_EpAigisImpl(nativetypes.Interfaces.Astrea.UAgePanel* self, float deltaTime)
        {
            ConfigColor.SetColor(ref self->TopColorNormal, _context._config.DateTimePanelTopTextColor);
            ConfigColor.SetColor(ref self->BottomColorNormal, _context._config.DateTimePanelBottomTextColor);
            ConfigColor.SetColor(ref self->WaterColorNormal, _context._config.DateTimePanelWaterColor);
            _updateAgePanelParametersEpAigis.OriginalFunction(self, deltaTime);
        }

        private string AUIDateDraw_UpdateParams_SIG = "40 53 48 83 EC 70 4C 8B 81 ?? ?? ?? ??";
        private unsafe delegate void AUIDateDraw_UpdateParams(AUIDateDraw* self, long a2, long a3, long a4);
        private IHook<AUIDateDraw_UpdateParams> _drawActorInner;
        private unsafe void AUIDateDraw_UpdateParamsImpl(AUIDateDraw* self, long a2, long a3, long a4)
        {
            _drawActorInner.OriginalFunction(self, a2, a3, a4);
            if (self->TimeOfDay != 8) self->TimeOfDayParams.color = ConfigColor.ToFSprColor(_context._config.DateTimePanelBottomTextColor);
        }

        private string AUIDateDraw_UpdateParams_EpAigis_SIG = "40 53 48 81 EC A0 00 00 00 48 8B 81 ?? ?? ?? ??";
        private unsafe delegate void AUIDateDraw_UpdateParams_EpAigis(nativetypes.Interfaces.Astrea.AUIDateDraw* self, long a2, long a3, long a4);
        private IHook<AUIDateDraw_UpdateParams_EpAigis> _drawActorInnerEpAigis;
        private unsafe void AUIDateDraw_UpdateParamsEpAigisImpl(nativetypes.Interfaces.Astrea.AUIDateDraw* self, long a2, long a3, long a4)
        {
            _drawActorInnerEpAigis.OriginalFunction(self, a2, a3, a4);
            if (self->TimeOfDay != 8) self->TimeOfDayParams.color = ConfigColor.ToFSprColor(_context._config.DateTimePanelBottomTextColor);
        }

        private UICommon _uiCommon;
        public unsafe DateTimePanel(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            if (_context.bIsAigis)
            {
                _context._utils.SigScan(UAgePanel_UpdateAgePanelParameters_EpAigis_SIG, "UAgePanel::UpdateAgePanelParameters", _context._utils.GetDirectAddress, addr => _updateAgePanelParametersEpAigis = _context._utils.MakeHooker<UAgePanel_UpdateAgePanelParameters_EpAigis>(UAgePanel_UpdateAgePanelParameters_EpAigisImpl, addr));
                _context._utils.SigScan(AUIDateDraw_UpdateParams_EpAigis_SIG, "AUIDrateDraw::UpdateParams", _context._utils.GetDirectAddress, addr => _drawActorInnerEpAigis = _context._utils.MakeHooker<AUIDateDraw_UpdateParams_EpAigis>(AUIDateDraw_UpdateParamsEpAigisImpl, addr));
            } else
            {
                _context._utils.SigScan(UAgePanel_UpdateAgePanelParameters_SIG, "UAgePanel::UpdateAgePanelParameters", _context._utils.GetDirectAddress, addr => _updateAgePanelParameters = _context._utils.MakeHooker<UAgePanel_UpdateAgePanelParameters>(UAgePanel_UpdateAgePanelParametersImpl, addr));
                _context._utils.SigScan(AUIDateDraw_UpdateParams_SIG, "AUIDrateDraw::UpdateParams", _context._utils.GetDirectAddress, addr => _drawActorInner = _context._utils.MakeHooker<AUIDateDraw_UpdateParams>(AUIDateDraw_UpdateParamsImpl, addr));
            }
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }
    }
}
