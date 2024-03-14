using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class PersonaStatus : ModuleAsmInlineColorEdit
    {
        // in APersonaStatusDraw::DrawSkillListInner
        private string APersonaStatusDraw_GetSkillListBgColor_SIG = "C7 45 ?? 3B 02 00 FF E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ??";
        private string APersonaStatusDraw_GetSkillListCheckerboard1_SIG = "C7 45 ?? 66 2F 2B FF";
        private string APersonaStatusDraw_GetSkillListNoNextSkill_SIG = "C7 45 ?? 58 20 1D FF";
        private string APersonaStatusDraw_GetSkillListNextSkill_SIG = "C7 45 ?? C6 0E 00 FF F3 44 0F 11 44 24 ??";
        private string APersonaStatusDraw_GetSkillListNextLevel_SIG = "C7 45 ?? FF D3 00 FF 48 8D 45 ??";
        private UICommon _uiCommon;
        public unsafe PersonaStatus(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListBgColor_SIG, "APersonaStatusDraw::GetSkillListBgColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampSocialLinkDetailDescName.ToU32())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListCheckerboard1_SIG, "APersonaStatusDraw::GetSkillListCheckerboard1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampSocialLinkDetailDescName.ToU32())));
            });
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }
    }
}
