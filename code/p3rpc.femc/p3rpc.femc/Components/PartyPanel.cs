using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class PartyPanel : ModuleBase<FemcContext>
    {

        private string FBattleHeadPanel_PartyPanelHeadUpdate_SIG = "4C 8B DC 49 89 4B ?? 55 53 49 8D 6B ??";
        private string FFieldHeadPanel_PartyPanelHeadUpdate_SIG = "48 8B C4 48 89 58 ?? 55 48 8D 68 ?? 48 81 EC C0 00 00 00 0F 29 70 ??";
        private IHook<FBattleHeadPanel_PartyPanelHeadUpdate> _btlHeadUpdate;
        private IHook<FFieldHeadPanel_PartyPanelHeadUpdate> _fldHeadUpdate;
        private UICommon _uiCommon;
        public unsafe PartyPanel(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(FBattleHeadPanel_PartyPanelHeadUpdate_SIG, "FBattleHeadPanel::PartyPanelHeadUpdate", _context._utils.GetDirectAddress, addr => _btlHeadUpdate = _context._utils.MakeHooker<FBattleHeadPanel_PartyPanelHeadUpdate>(FBattleHeadPanel_PartyPanelHeadUpdateImpl, addr));
            _context._utils.SigScan(FFieldHeadPanel_PartyPanelHeadUpdate_SIG, "FFieldHeadPanel::PartyPanelHeadUpdate", _context._utils.GetDirectAddress, addr => _fldHeadUpdate = _context._utils.MakeHooker<FFieldHeadPanel_PartyPanelHeadUpdate>(FFieldHeadPanel_PartyPanelHeadUpdateImpl, addr));
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        private unsafe void FBattleHeadPanel_PartyPanelHeadUpdateImpl(FBattleHeadPanel* self, float deltaTime, float x, float y, int count)
        {
            _btlHeadUpdate.OriginalFunction(self, deltaTime, x, y, count);
            ConfigColor.SetColor(ref self->cardBlueBgTrans.color, _context._config.PartyPanelBgColor);
            ConfigColor.SetColor(ref self->lineShadowBgTrans.color, _context._config.PartyPanelBgColor);
        }
        private unsafe void FFieldHeadPanel_PartyPanelHeadUpdateImpl(FFieldHeadPanel* self, float deltaTime, float x, float y, int count)
        {
            _fldHeadUpdate.OriginalFunction(self, deltaTime, x, y, count);
            ConfigColor.SetColor(ref self->cardBlueBgTrans.color, _context._config.PartyPanelBgColor);
        }
        private unsafe delegate void FBattleHeadPanel_PartyPanelHeadUpdate(FBattleHeadPanel* self, float deltaTime, float x, float y, int count);
        private unsafe delegate void FFieldHeadPanel_PartyPanelHeadUpdate(FFieldHeadPanel* self, float deltaTime, float x, float y, int count);
    }
}
