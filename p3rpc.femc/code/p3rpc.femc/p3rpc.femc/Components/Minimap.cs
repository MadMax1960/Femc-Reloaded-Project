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
    public class Minimap : ModuleBase<FemcContext>
    {
        private string AUIAccessInfoDraw_UpdateMinimapState_SIG = "40 55 53 48 8D 6C 24 ?? 48 81 EC F8 00 00 00 48 8B 81 ?? ?? ?? ??";
        private string UUIMinimapDraw_DrawMinimapBgCircle_SIG = "48 89 E0 48 89 70 ?? 57 48 81 EC C0 00 00 00";
        private string UUILocationSelect_DrawLocationSelect_SIG = "40 55 56 57 41 56 48 8D AC 24 ?? ?? ?? ?? 48 81 EC 88 04 00 00";
        private IHook<AUIAccessInfoDraw_UpdateMinimapState> _updateMinimapState;

        private UICommon _uiCommon;
        public unsafe Minimap(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUIAccessInfoDraw_UpdateMinimapState_SIG, "AUIAccessInfoDraw::UpdateMinimapState", _context._utils.GetDirectAddress, addr => _updateMinimapState = _context._utils.MakeHooker<AUIAccessInfoDraw_UpdateMinimapState>(AUIAccessInfoDraw_UpdateMinimapStateImpl, addr));
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        private unsafe void AUIAccessInfoDraw_UpdateMinimapStateImpl(AUIAccessInfoDraw* self)
        {
            _updateMinimapState.OriginalFunction(self);
            ConfigColor.SetColor(ref self->PlaceInfoBgColor, _context._config.MinimapPlaceNameBgColor);
        }

        private unsafe delegate void AUIAccessInfoDraw_UpdateMinimapState(AUIAccessInfoDraw* self);
    }
}
