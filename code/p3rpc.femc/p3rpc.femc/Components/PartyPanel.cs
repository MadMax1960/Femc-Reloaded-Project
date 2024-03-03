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
    public class PartyPanel : ModuleBase
    {
        [StructLayout(LayoutKind.Explicit, Size = 0xCA0)]
        public unsafe struct FBaseHeadPanel
        {
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x4010)]
        public unsafe struct FBattleHeadPanel
        {
            [FieldOffset(0x0000)] public FBaseHeadPanel baseObj;
            [FieldOffset(0xca0)] public SprDefStruct1 cardBlueBgTrans;
            [FieldOffset(0xd08)] public SprDefStruct1 lineShadowBgTrans;
            [FieldOffset(0x12C8)] public UMaterialInstanceDynamic* materialSmokeInst;
            [FieldOffset(0x12D0)] public UMaterialInstanceDynamic* materialSmokeInstGrey;
        }

        private string FBattleHeadPanel_PartyPanelHeadUpdate_SIG = "4C 8B DC 49 89 4B ?? 55 53 49 8D 6B ??";
        private IHook<FBattleHeadPanel_PartyPanelHeadUpdate> _headUpdate;
        private UICommon _uiCommon;
        public unsafe PartyPanel(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(FBattleHeadPanel_PartyPanelHeadUpdate_SIG, "FBattleHeadPanel::PartyPanelHeadUpdate", _context._utils.GetDirectAddress, addr => _headUpdate = _context._utils.MakeHooker<FBattleHeadPanel_PartyPanelHeadUpdate>(FBattleHeadPanel_PartyPanelHeadUpdateImpl, addr));
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        private unsafe void FBattleHeadPanel_PartyPanelHeadUpdateImpl(FBattleHeadPanel* self, float deltaTime, float x, float y, int count)
        {
            _headUpdate.OriginalFunction(self, deltaTime, x, y, count);
            _uiCommon.SetColor(ref self->cardBlueBgTrans.color, _context._config.PartyPanelBgColor);
            _uiCommon.SetColor(ref self->lineShadowBgTrans.color, _context._config.PartyPanelBgColor);

        }
        private unsafe delegate void FBattleHeadPanel_PartyPanelHeadUpdate(FBattleHeadPanel* self, float deltaTime, float x, float y, int count);
    }
}
