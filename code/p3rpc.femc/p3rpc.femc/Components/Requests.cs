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
    class Requests : ModuleBase<FemcContext>
    {
        private string AUIRequest_BackCardColor_SIG = "E8 ?? ?? ?? ?? 4C 8B 86 ?? ?? ?? ?? 48 8D 4D ?? 0F 57 DB F3 0F 11 7C 24 ?? 49 8B D6 89 45 ?? E8 ?? ?? ?? ?? BA 01 00 00 00";
        private string AUIRequest_BackSquaresColor_SIG = "E8 ?? ?? ?? ?? 4C 8B 86 ?? ?? ?? ?? 48 8D 4C 24 ?? 0F 57 DB F3 0F 11 7C 24 ?? 49 8B D6 89 45 ?? E8 ?? ?? ?? ?? 0F 28 45 ??";
        private string AUIRequest_InfoBackColor_SIG = "E8 ?? ?? ?? ?? BA 04 00 00 00 89 45 ??";
        private string AUIRequest_InfoCampMenuChairColor_SIG = "E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 41 0F 28 D8 C6 44 24 ?? 00 41 0F 28 D3 C6 44 24 ?? 01 BA 71 00 00 00 F3 44 0F 11 4C 24 ?? F3 44 0F 11 4C 24 ?? F3 44 0F 11 64 24 ?? 89 7C 24 ?? 48 89 5C 24 ?? 89 44 24 ?? F3 0F 11 7C 24 ?? E8 ?? ?? ?? ?? F3 0F 10 05 ?? ?? ?? ??";
        private string AUIRequest_InfoCampMenuChairAndKotone_SIG = "E8 ?? ?? ?? ?? C6 44 24 ?? 00 F3 0F 10 5D ??";
        private string AUIRequest_BackCampMenuChairAndKotone_SIG = "E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 41 0F 28 D8 C6 44 24 ?? 00 41 0F 28 D3 C6 44 24 ?? 01 BA 71 00 00 00 F3 44 0F 11 4C 24 ?? F3 44 0F 11 4C 24 ?? F3 44 0F 11 64 24 ?? 89 7C 24 ?? 48 89 5C 24 ?? 89 44 24 ?? F3 0F 11 7C 24 ?? E8 ?? ?? ?? ?? 48 8B BC 24 ?? ?? ?? ??";
        private string AUIRequest_InfoCompletedBack_SIG = "E8 ?? ?? ?? ?? 4C 8B 86 ?? ?? ?? ?? 48 8D 4C 24 ?? 0F 57 DB F3 0F 11 7C 24 ?? 49 8B D6 89 45 ?? E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ??";
        private string AUIRequest_InfoCompleted_SIG = "E8 ?? ?? ?? ?? 4C 8B 86 ?? ?? ?? ?? 48 8D 4D ?? 0F 57 DB F3 0F 11 7C 24 ?? 49 8B D6 89 45 ?? E8 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ??";
        private string AUIRequest_InfoRightDownCorner_SIG = "E8 ?? ?? ?? ?? F3 0F 10 05 ?? ?? ?? ?? BA 03 00 00 00 F3 0F 59 35 ?? ?? ?? ??";
        private string AUIRequest_InfoUnknownReward_SIG = "E8 ?? ?? ?? ?? F3 44 0F 58 0D ?? ?? ?? ?? F3 44 0F 58 05 ?? ?? ?? ??";
        private string AUIRequest_InfoEarnedTag_SIG = "E8 ?? ?? ?? ?? 4C 8B 86 ?? ?? ?? ?? F3 44 0F 58 CE";
        private string AUIRequest_TaskTitle_SIG = "E8 ?? ?? ?? ?? 4C 8B 87 ?? ?? ?? ?? 48 8D 4C 24 ?? 0F 57 DB F3 44 0F 11 4C 24 ?? 48 8B D6 89 44 24 ?? E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ??";
        private string AUIRequest_UnknownTaskDescription_SIG = "E8 ?? ?? ?? ?? 4C 8B 87 ?? ?? ?? ?? 48 8D 4C 24 ?? 0F 57 DB F3 44 0F 11 4C 24 ?? 48 8B D6 89 44 24 ?? E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? 4C 89 B4 24 ?? ?? ?? ?? 44 0F 29 94 24 ?? ?? ?? ??";
        private string AUIRequest_InfoRequestDetails_SIG = "E8 ?? ?? ?? ?? 4C 8B 87 ?? ?? ?? ?? 48 8D 4C 24 ?? 0F 57 DB F3 0F 11 7C 24 ?? 48 8B D6 F3 44 0F 11 44 24 ??";
        private string AUIRequest_InfoUnknownTask_SIG = "E8 ?? ?? ?? ?? 4C 8B 87 ?? ?? ?? ?? 48 8D 4C 24 ?? 0F 57 DB F3 44 0F 11 4C 24 ?? 48 8B D6 89 44 24 ?? E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? 4C 89 B4 24 ?? ?? ?? ?? 44 0F 29 9C 24 ?? ?? ?? ??";

        private IAsmHook _BackCardColor;
        private IAsmHook _BackSquaresColor;
        private IAsmHook _InfoBackColor;
        private IAsmHook _InfoCampMenuChairColor;
        private IAsmHook _InfoCampMenuChairAndKotone;
        private IAsmHook _BackCampMenuChairAndKotone;
        private IAsmHook _InfoCompletedBack;
        private IAsmHook _InfoCompleted;
        private IAsmHook _InfoRightDownCorner;
        private IAsmHook _InfoUnknownReward;
        private IAsmHook _InfoEarnedTag;
        private IAsmHook _TaskTitle;
        private IAsmHook _UnknownTaskDescription;
        private IAsmHook _InfoRequestDetails;
        private IAsmHook _InfoUnknownTask;

        /*
        private string AUIRequest_InfoColor_SIG = "E8 ?? ?? ?? ?? BA 04 00 00 00 89 45 ??";
        
        private IAsmHook _InfoColor;
        */

        public unsafe Requests(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUIRequest_BackCardColor_SIG, "AUIRequest::BackCardColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackCard.B:X}",
                    $"mov dl, ${_context._config.RequestBackCard.G:X}",
                    $"mov cl, ${_context._config.RequestBackCard.R:X}"
                };
                _BackCardColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_BackSquaresColor_SIG, "AUIRequest::BackSquaresColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackSquares.B:X}",
                    $"mov dl, ${_context._config.RequestBackSquares.G:X}",
                    $"mov cl, ${_context._config.RequestBackSquares.R:X}"
                };
                _BackSquaresColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_InfoBackColor_SIG, "AUIRequest::InfoBackColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackSquares.B:X}",
                    $"mov dl, ${_context._config.RequestBackSquares.G:X}",
                    $"mov cl, ${_context._config.RequestBackSquares.R:X}"
                };
                _InfoBackColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_InfoCampMenuChairColor_SIG, "AUIRequest::InfoCampMenuChairColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackCard.B:X}",
                    $"mov dl, ${_context._config.RequestBackCard.G:X}",
                    $"mov cl, ${_context._config.RequestBackCard.R:X}"
                };
                _InfoCampMenuChairColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_InfoCampMenuChairAndKotone_SIG, "AUIRequest::InfoCampMenuChairAndKotone", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackCard.B:X}",
                    $"mov dl, ${_context._config.RequestBackCard.G:X}",
                    $"mov cl, ${_context._config.RequestBackCard.R:X}"
                };
                _InfoCampMenuChairAndKotone = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_BackCampMenuChairAndKotone_SIG, "AUIRequest::BackCampMenuChairAndKotone", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackSquares.B:X}",
                    $"mov dl, ${_context._config.RequestBackSquares.G:X}",
                    $"mov cl, ${_context._config.RequestBackSquares.R:X}"
                };
                _BackCampMenuChairAndKotone = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_InfoCompletedBack_SIG, "AUIRequest::InfoCompletedBack", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackCard.B:X}",
                    $"mov dl, ${_context._config.RequestBackCard.G:X}",
                    $"mov cl, ${_context._config.RequestBackCard.R:X}"
                };
                _InfoCompletedBack = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_InfoCompleted_SIG, "AUIRequest::InfoCompleted", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackSquares.B:X}",
                    $"mov dl, ${_context._config.RequestBackSquares.G:X}",
                    $"mov cl, ${_context._config.RequestBackSquares.R:X}"
                };
                _InfoCompleted = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_InfoRightDownCorner_SIG, "AUIRequest::InfoRightDownCorner", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackSquares.B:X}",
                    $"mov dl, ${_context._config.RequestBackSquares.G:X}",
                    $"mov cl, ${_context._config.RequestBackSquares.R:X}"
                };
                _InfoRightDownCorner = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_InfoUnknownReward_SIG, "AUIRequest::InfoUnknownReward", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackCard.B:X}",
                    $"mov dl, ${_context._config.RequestBackCard.G:X}",
                    $"mov cl, ${_context._config.RequestBackCard.R:X}"
                };
                _InfoUnknownReward = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_InfoEarnedTag_SIG, "AUIRequest::InfoEarnedTag", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackSquares.B:X}",
                    $"mov dl, ${_context._config.RequestBackSquares.G:X}",
                    $"mov cl, ${_context._config.RequestBackSquares.R:X}"
                };
                _InfoEarnedTag = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_TaskTitle_SIG, "AUIRequest::TaskTitle", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackCard.B:X}",
                    $"mov dl, ${_context._config.RequestBackCard.G:X}",
                    $"mov cl, ${_context._config.RequestBackCard.R:X}"
                };
                _TaskTitle = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_UnknownTaskDescription_SIG, "AUIRequest::UnknownTaskDescription", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackCard.B:X}",
                    $"mov dl, ${_context._config.RequestBackCard.G:X}",
                    $"mov cl, ${_context._config.RequestBackCard.R:X}"
                };
                _UnknownTaskDescription = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_InfoRequestDetails_SIG, "AUIRequest::InfoRequestDetails", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackCard.B:X}",
                    $"mov dl, ${_context._config.RequestBackCard.G:X}",
                    $"mov cl, ${_context._config.RequestBackCard.R:X}"
                };
                _InfoRequestDetails = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_InfoUnknownTask_SIG, "AUIRequest::InfoUnknownTask", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackCard.B:X}",
                    $"mov dl, ${_context._config.RequestBackCard.G:X}",
                    $"mov cl, ${_context._config.RequestBackCard.R:X}"
                };
                _InfoUnknownTask = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            /*
            _context._utils.SigScan(AUIRequest_InfoColor_SIG, "AUIRequest::InfoColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackCard.B:X}",
                    $"mov dl, ${_context._config.RequestBackCard.G:X}",
                    $"mov cl, ${_context._config.RequestBackCard.R:X}"
                };
                _InfoColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            */
        }

        public override void Register() { }
    }
}
