using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class SocialStats : ModuleBase
    {
        private string ACmpMainActor_GetParamRankUpTable_SIG = "E8 ?? ?? ?? ?? 4C 8B E8 48 89 45 ?? E8 ?? ?? ?? ??";
        private IHook<ACmpMainActor_GetParamRankUpTable> _getParamRankUpTable;
        private UICommon _uiCommon;
        public unsafe SocialStats(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(ACmpMainActor_GetParamRankUpTable_SIG, "ACmpMainActor::GetParamRankUpTable", _context._utils.GetIndirectAddressShort, addr => _getParamRankUpTable = _context._utils.MakeHooker<ACmpMainActor_GetParamRankUpTable>(ACmpMainActor_GetParamRankUpTableImpl, addr));
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }
        private unsafe FCampParamTableRankUpRow* ACmpMainActor_GetParamRankUpTableImpl(ACmpMainActor* self)
        {
            var returned_table = _getParamRankUpTable.OriginalFunction(self);
            _uiCommon.SetColor(ref returned_table->HumanBrainBlue, _context._config.SocialStatsCircleAcademicsColor);
            _uiCommon.SetColor(ref returned_table->CampHumanBrainBlue, _context._config.SocialStatsCircleAcademicsColor);
            _uiCommon.SetColor(ref returned_table->HumanCharmBlue, _context._config.SocialStatsCircleCharmColor);
            _uiCommon.SetColor(ref returned_table->CampHumanCharmBlue, _context._config.SocialStatsCircleCharmColor);
            _uiCommon.SetColor(ref returned_table->HumanCourageBlue, _context._config.SocialStatsCircleCourageColor);
            _uiCommon.SetColor(ref returned_table->CampHumanCourageBlue, _context._config.SocialStatsCircleCourageColor);
            return returned_table;
        }

        private unsafe delegate FCampParamTableRankUpRow* ACmpMainActor_GetParamRankUpTable(ACmpMainActor* self);
    }
}
