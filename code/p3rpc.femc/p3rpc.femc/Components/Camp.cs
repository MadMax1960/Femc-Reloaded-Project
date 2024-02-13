using p3rpc.femc.Native;
using Reloaded.Hooks.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class Camp : ModuleBase
    {
        private string ACmpMainActor_GetCampParamTableCommon_SIG = "E8 ?? ?? ?? ?? 48 8B D8 83 FF 0C"; // inside of ACmpMainActor::DrawBackgroundUpdateInner
        private IHook<ACmpMainActor_GetCampParamTableCommon> _getCmpMainParams;

        public unsafe Camp(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(ACmpMainActor_GetCampParamTableCommon_SIG, "ACmpMainActor::GetCmpMainParams", _context._utils.GetIndirectAddressShort, addr => _getCmpMainParams = _context._utils.MakeHooker<ACmpMainActor_GetCampParamTableCommon>(ACmpMainActor_GetCampParamTableCommonImpl, addr)); // Camp Main
        }

        public override void Register()
        {
            
        }
        private unsafe FCampParamTableCommonRow* ACmpMainActor_GetCampParamTableCommonImpl(ACmpMainActor* self)
        {
            var return_value = _getCmpMainParams.OriginalFunction(self);
            return_value->AoItaColorHigh.SetColor(_context._config.UILightColor);
            return_value->AoItaColorMid.SetColor(_context._config.UILightColor);
            return_value->AoItaColorLow.SetColor(_context._config.UILightColor);
            return_value->GradADownColorHigh.SetColor(_context._config.UILightColor);
            return_value->GradADownColorMid.SetColor(_context._config.UILightColor);
            return_value->GradADownColorLow.SetColor(_context._config.UILightColor);
            return return_value;
        }

        private unsafe delegate FCampParamTableCommonRow* ACmpMainActor_GetCampParamTableCommon(ACmpMainActor* self);
    }
}
