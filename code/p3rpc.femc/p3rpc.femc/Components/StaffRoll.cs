using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using Reloaded.Hooks.Definitions.X64;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{

    public class LocalizationStaffRoll : ModuleBase<FemcContext>
    {
        private string ALocalizeStaffRoll_SetTextColor_SIG = "E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ?? 4C 8D 4D ?? 0F 28 0D ?? ?? ?? ??";
        private IAsmHook _setTextColor;
        public unsafe LocalizationStaffRoll(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(ALocalizeStaffRoll_SetTextColor_SIG, "ALocalizeStaffRoll::SetTextColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"cmp ebx, -1",
                    $"je whiteText",
                    $"mov ebx, {_context._config.LocalStaffRollHeader.ToU32()}",
                    $"label whiteText"
                };
                _setTextColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }
        public override void Register()
        {
        }
    }
    public class StaffRoll : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string AStaffRoll_SetTextColor_SIG = "42 8B 04 ?? 89 44 24 ?? 44 89 44 24 ??"; // r9
        private string AStaffRoll_HorizontalLine_SIG = "";
        private string AStaffRoll_VerticalLine_SIG = "";
        public unsafe StaffRoll(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {

        }
        public override void Register()
        {
        }
    }
}
