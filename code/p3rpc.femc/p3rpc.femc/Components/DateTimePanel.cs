using p3rpc.femc.Native;
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
        private IHook<UAgePanel_UpdateAgePanelParameters> _updateAgePanelParameters;
        public unsafe DateTimePanel(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(UAgePanel_UpdateAgePanelParameters_SIG, "UAgePanel::UpdateAgePanelParameters", _context._utils.GetDirectAddress, addr => _updateAgePanelParameters = _context._utils.MakeHooker<UAgePanel_UpdateAgePanelParameters>(UAgePanel_UpdateAgePanelParametersImpl, addr)); // Age Panel
        }

        public override void Register()
        {
            
        }

        private unsafe void UAgePanel_UpdateAgePanelParametersImpl(UAgePanel* self, float deltaTime)
        {
            self->TopColorNormal.SetColor(_context._config.DateTimePanelTopTextColor);
            self->BottomColorNormal.SetColor(_context._config.DateTimePanelBottomTextColor);
            _updateAgePanelParameters.OriginalFunction(self, deltaTime);
        }

        private unsafe delegate void UAgePanel_UpdateAgePanelParameters(UAgePanel* self, float deltaTime);
    }
}
