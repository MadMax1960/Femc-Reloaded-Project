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
        private IHook<AUIAccessInfoDraw_UpdateMinimapState> _updateMinimapState;
        private unsafe delegate void AUIAccessInfoDraw_UpdateMinimapState(AUIAccessInfoDraw* self);
        private unsafe void AUIAccessInfoDraw_UpdateMinimapStateImpl(AUIAccessInfoDraw* self)
        {
            _updateMinimapState.OriginalFunction(self);
            ConfigColor.SetColor(ref self->PlaceInfoBgColor, _context._config.MinimapPlaceNameBgColor);
        }
        private string AUIAccessInfoDraw_UpdateMinimapState_SIG_EpAigis = "40 55 53 57 48 8D 6C 24 ?? 48 81 EC F0 00 00 00 48 8B D9";
        private IHook<AUIAccessInfoDraw_UpdateMinimapState_EpAigis> _updateMinimapState_EpAigis;
        private unsafe delegate void AUIAccessInfoDraw_UpdateMinimapState_EpAigis(nativetypes.Interfaces.Astrea.AUIAccessInfoDraw* self);
        private unsafe void AUIAccessInfoDraw_UpdateMinimapStateImpl_EpAigis(nativetypes.Interfaces.Astrea.AUIAccessInfoDraw* self)
        {
            _updateMinimapState_EpAigis.OriginalFunction(self);
            ConfigColor.SetColor(ref self->PlaceInfoBgColor, _context._config.MinimapPlaceNameBgColor);
        }

        private string UUIMinimapDraw_DrawMinimapBgCircle_SIG = "48 89 E0 48 89 70 ?? 57 48 81 EC C0 00 00 00";
        private string UUILocationSelect_DrawLocationSelect_SIG = "40 55 56 57 41 56 48 8D AC 24 ?? ?? ?? ?? 48 81 EC 88 04 00 00";

        private UICommon _uiCommon;
        public unsafe Minimap(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            if (_context.bIsAigis) _context._utils.SigScan(AUIAccessInfoDraw_UpdateMinimapState_SIG_EpAigis, "AUIAccessInfoDraw::UpdateMinimapState", _context._utils.GetDirectAddress, addr => _updateMinimapState_EpAigis = _context._utils.MakeHooker<AUIAccessInfoDraw_UpdateMinimapState_EpAigis>(AUIAccessInfoDraw_UpdateMinimapStateImpl_EpAigis, addr));
            else _context._utils.SigScan(AUIAccessInfoDraw_UpdateMinimapState_SIG, "AUIAccessInfoDraw::UpdateMinimapState", _context._utils.GetDirectAddress, addr => _updateMinimapState = _context._utils.MakeHooker<AUIAccessInfoDraw_UpdateMinimapState>(AUIAccessInfoDraw_UpdateMinimapStateImpl, addr));
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }
    }
}
