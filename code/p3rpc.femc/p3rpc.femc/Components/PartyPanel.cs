using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class PartyPanel : ModuleAsmInlineColorEdit<FemcContext>
    {

        private string FBattleHeadPanel_PartyPanelHeadUpdate_SIG = "4C 8B DC 49 89 4B ?? 55 53 49 8D 6B ??";
        private string FFieldHeadPanel_PartyPanelHeadUpdate_SIG = "48 8B C4 48 89 58 ?? 55 48 8D 68 ?? 48 81 EC C0 00 00 00 0F 29 70 ??";
        private string FBattleHeadPanel_PartyPanelFemcBackgroundUpdate_SIG = "C7 87 ?? ?? ?? ?? 5C 00 00 00";

        private IHook<FBattleHeadPanel_PartyPanelHeadUpdate> _btlHeadUpdate;
        private IHook<FFieldHeadPanel_PartyPanelHeadUpdate> _fldHeadUpdate;
        private IAsmHook _PartyPanelFemcBackgroundUpdate;

        private UICommon _uiCommon;
        public unsafe PartyPanel(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(FBattleHeadPanel_PartyPanelHeadUpdate_SIG, "FBattleHeadPanel::PartyPanelHeadUpdate", _context._utils.GetDirectAddress, addr => _btlHeadUpdate = _context._utils.MakeHooker<FBattleHeadPanel_PartyPanelHeadUpdate>(FBattleHeadPanel_PartyPanelHeadUpdateImpl, addr));
            _context._utils.SigScan(FFieldHeadPanel_PartyPanelHeadUpdate_SIG, "FFieldHeadPanel::PartyPanelHeadUpdate", _context._utils.GetDirectAddress, addr => _fldHeadUpdate = _context._utils.MakeHooker<FFieldHeadPanel_PartyPanelHeadUpdate>(FFieldHeadPanel_PartyPanelHeadUpdateImpl, addr));

            _context._utils.SigScan(FBattleHeadPanel_PartyPanelFemcBackgroundUpdate_SIG, "FBattleHeadPanel::PartyPanelFemcBackgroundUpdate", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.CampMiddleColor.B:X}",
                    $"mov dl, ${_context._config.CampMiddleColor.G:X}",
                    $"mov cl, ${_context._config.CampMiddleColor.R:X}"
                };
                _PartyPanelFemcBackgroundUpdate = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteAfter).Activate();
            });
            // Nop further instructions except jump since they overwrite the color
            _context._utils.SigScan(FBattleHeadPanel_PartyPanelFemcBackgroundUpdate_SIG, "FBattleHeadPanel::PartyPanelFemcBackgroundUpdateNopAfter", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 10, 0x90909090)));
            });
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
