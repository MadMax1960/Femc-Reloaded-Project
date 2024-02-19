using p3rpc.femc.Native;
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
        public unsafe SocialStats(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(ACmpMainActor_GetParamRankUpTable_SIG, "ACmpMainActor::GetParamRankUpTable", _context._utils.GetIndirectAddressShort, addr => _getParamRankUpTable = _context._utils.MakeHooker<ACmpMainActor_GetParamRankUpTable>(ACmpMainActor_GetParamRankUpTableImpl, addr));
        }

        public override void Register()
        {

        }
        private unsafe FCampParamTableRankUpRow* ACmpMainActor_GetParamRankUpTableImpl(ACmpMainActor* self)
        {
            var returned_table = _getParamRankUpTable.OriginalFunction(self);
            returned_table->HumanBrainBlue.SetColor(_context._config.SocialStatsCircleAcademicsColor);
            returned_table->CampHumanBrainBlue.SetColor(_context._config.SocialStatsCircleAcademicsColor);
            returned_table->HumanCharmBlue.SetColor(_context._config.SocialStatsCircleCharmColor);
            returned_table->CampHumanCharmBlue.SetColor(_context._config.SocialStatsCircleCharmColor);
            returned_table->HumanCourageBlue.SetColor(_context._config.SocialStatsCircleCourageColor);
            returned_table->CampHumanCourageBlue.SetColor(_context._config.SocialStatsCircleCourageColor);
            return returned_table;
        }

        private unsafe delegate FCampParamTableRankUpRow* ACmpMainActor_GetParamRankUpTable(ACmpMainActor* self);
    }
}
