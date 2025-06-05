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
        private string AUIRequest_DetailBackColor_SIG = "E8 ?? ?? ?? ?? BA 04 00 00 00 89 45 ??";
        private string AUIRequest_DetailCampMenuChairColor_SIG = "E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 41 0F 28 D8 C6 44 24 ?? 00 41 0F 28 D3 C6 44 24 ?? 01 BA 71 00 00 00 F3 44 0F 11 4C 24 ?? F3 44 0F 11 4C 24 ?? F3 44 0F 11 64 24 ?? 89 7C 24 ?? 48 89 5C 24 ?? 89 44 24 ?? F3 0F 11 7C 24 ?? E8 ?? ?? ?? ?? F3 0F 10 05 ?? ?? ?? ??";
        private string AUIRequest_DetailCampMenuChairAndKotone_SIG = "E8 ?? ?? ?? ?? C6 44 24 ?? 00 F3 0F 10 5D ??";
        private string AUIRequest_BackCampMenuChairAndKotone_SIG = "E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 41 0F 28 D8 C6 44 24 ?? 00 41 0F 28 D3 C6 44 24 ?? 01 BA 71 00 00 00 F3 44 0F 11 4C 24 ?? F3 44 0F 11 4C 24 ?? F3 44 0F 11 64 24 ?? 89 7C 24 ?? 48 89 5C 24 ?? 89 44 24 ?? F3 0F 11 7C 24 ?? E8 ?? ?? ?? ?? 48 8B BC 24 ?? ?? ?? ??";
        private string AUIRequest_DetailCompletedBack_SIG = "E8 ?? ?? ?? ?? 4C 8B 86 ?? ?? ?? ?? 48 8D 4C 24 ?? 0F 57 DB F3 0F 11 7C 24 ?? 49 8B D6 89 45 ?? E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ??";
        private string AUIRequest_DetailCompleted_SIG = "E8 ?? ?? ?? ?? 4C 8B 86 ?? ?? ?? ?? 48 8D 4D ?? 0F 57 DB F3 0F 11 7C 24 ?? 49 8B D6 89 45 ?? E8 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ??";
        private string AUIRequest_DetailRightDownCorner_SIG = "E8 ?? ?? ?? ?? F3 0F 10 05 ?? ?? ?? ?? BA 03 00 00 00 F3 0F 59 35 ?? ?? ?? ??";
        private string AUIRequest_DetailUnknownReward_SIG = "E8 ?? ?? ?? ?? F3 44 0F 58 0D ?? ?? ?? ?? F3 44 0F 58 05 ?? ?? ?? ??";
        private string AUIRequest_DetailEarnedTag_SIG = "E8 ?? ?? ?? ?? 4C 8B 86 ?? ?? ?? ?? F3 44 0F 58 CE";
        private string AUIRequest_TaskTitle_SIG = "E8 ?? ?? ?? ?? 4C 8B 87 ?? ?? ?? ?? 48 8D 4C 24 ?? 0F 57 DB F3 44 0F 11 4C 24 ?? 48 8B D6 89 44 24 ?? E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ??";
        private string AUIRequest_UnknownTaskDescription_SIG = "E8 ?? ?? ?? ?? 4C 8B 87 ?? ?? ?? ?? 48 8D 4C 24 ?? 0F 57 DB F3 44 0F 11 4C 24 ?? 48 8B D6 89 44 24 ?? E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? 4C 89 B4 24 ?? ?? ?? ?? 44 0F 29 94 24 ?? ?? ?? ??";
        private string AUIRequest_DetailRequestDetails_SIG = "E8 ?? ?? ?? ?? 4C 8B 87 ?? ?? ?? ?? 48 8D 4C 24 ?? 0F 57 DB F3 0F 11 7C 24 ?? 48 8B D6 F3 44 0F 11 44 24 ??";
        private string AUIRequest_DetailUnknownTask_SIG = "E8 ?? ?? ?? ?? 4C 8B 87 ?? ?? ?? ?? 48 8D 4C 24 ?? 0F 57 DB F3 44 0F 11 4C 24 ?? 48 8B D6 89 44 24 ?? E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? 4C 89 B4 24 ?? ?? ?? ?? 44 0F 29 9C 24 ?? ?? ?? ??";
        private string AUIRequest_RequestsCursorColor_SIG = "E8 ?? ?? ?? ?? F3 0F 10 5E ?? 48 8D 4E ??";
        private string AUIRequest_RequestsDetailCursorColor_SIG = "E8 ?? ?? ?? ?? F3 0F 10 9F ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? F3 44 0F 59 35 ?? ?? ?? ??";

        private string AUIRequest_DifficultyRankUp_SIG = "E8 ?? ?? ?? ?? 4C 8B 83 ?? ?? ?? ?? 48 8D 4D ?? 0F 57 DB F3 44 0F 11 55 ?? 49 8B D6";
        private string AUIRequest_DifficultyRankDown_SIG = "E8 ?? ?? ?? ?? F3 0F 10 05 ?? ?? ?? ?? 49 8B CE F3 0F 10 1D ?? ?? ?? ??";
        private string AUIRequest_DifficultyIndicatorButterfly1_SIG = "E8 ?? ?? ?? ?? 41 B1 FF 89 06";
        private string AUIRequest_DifficultyIndicatorButterfly2_SIG = "E8 ?? ?? ?? ?? 41 B1 FF 89 83 ?? ?? ?? ?? 41 B0 7F";
        private string AUIRequest_DifficultyIndicatorButterfly34_SIG = "E8 ?? ?? ?? ?? 41 B1 FF 89 83 ?? ?? ?? ?? 41 B0 73 B2 2D B1 0E E8 ?? ?? ?? ??";
        private string AUIRequest_DifficultyIndicatorButterfly5_SIG = "E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ?? 0F 57 C9 F3 0F 10 B5 ?? ?? ?? ??";
        private string AUIRequest_DifficultyFont_SIG = "E8 ?? ?? ?? ?? F3 44 0F 58 15 ?? ?? ?? ?? F3 44 0F 58 1D ?? ?? ?? ?? 4C 8B 83 ?? ?? ?? ??";

        private string AUIRequest_FontAndStatusTagBackground_SIG = "E8 ?? ?? ?? ?? 41 B0 FC 44 0F B6 CF 41 0F B6 D0 B1 67 44 8B F8";
        private string AUIRequest_FontStatusTag_SIG = "E8 ?? ?? ?? ?? 41 B0 FC 89 44 24 ??";
        private string AUIRequest_StatusTagUnderlay_SIG = "E8 ?? ?? ?? ?? 33 D2 89 85 ?? ?? ?? ?? 48 8B 83 ?? ?? ?? ??";

        private string AUIRequest_NumberColumn_SIG = "C7 45 ?? 62 03 00 00 E8 ?? ?? ?? ??";
        private string AUIRequest_QuestColumn_SIG = "E8 ?? ?? ?? ?? 4C 8B 87 ?? ?? ?? ?? 48 8D 4C 24 ?? 0F 57 DB F3 0F 11 7C 24 ?? 48 8B D6 89 44 24 ?? E8 ?? ?? ?? ?? 0F 28 B4 24 ?? ?? ?? ??";
        private string AUIRequest_DateColumn_SIG = "E8 ?? ?? ?? ?? 4C 8B 87 ?? ?? ?? ?? 48 8D 4C 24 ?? 0F 57 DB F3 0F 11 7C 24 ?? 48 8B D6 89 44 24 ?? E8 ?? ?? ?? ?? 83 BF ?? ?? ?? ?? 01";
        private string AUIRequest_StatusColumn_SIG = "E8 ?? ?? ?? ?? 89 44 24 ?? 48 8D 4C 24 ?? 4C 8B 87 ?? ?? ?? ??";

        private string AUIRequest_SortCurrentText_SIG = "E8 ?? ?? ?? ?? 89 44 24 ?? E8 ?? ?? ?? ?? 8B 97 ?? ?? ?? ??";
        private string AUIRequest_NumberTriangle_SIG = "E8 ?? ?? ?? ?? 4C 8B 87 ?? ?? ?? ?? 48 8D 4D ?? 0F 57 DB F3 0F 11 7C 24 ?? 48 8B D6 89 45 ?? E8 ?? ?? ?? ?? 33 D2 48 8B CE E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ?? 0F 57 C9 0F 29 44 24 ??";
        private string AUIRequest_NumberSortFont_SIG = "E8 ?? ?? ?? ?? 4C 8B 87 ?? ?? ?? ?? 48 8D 4D ?? 0F 57 DB F3 0F 11 7C 24 ?? 48 8B D6 89 45 ?? E8 ?? ?? ?? ?? 8D 53 ??";
        private string AUIRequest_StatusTriangle_SIG = "E8 ?? ?? ?? ?? 4C 8B 87 ?? ?? ?? ?? 48 8D 4D ?? 0F 57 DB F3 0F 11 7C 24 ?? 48 8B D6 89 45 ?? E8 ?? ?? ?? ?? 33 D2 48 8B CE E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ?? 0F 57 C9 8B 44 24 ??";
        private string AUIRequest_StatusSortFont_SIG = "E8 ?? ?? ?? ?? 4C 8B 87 ?? ?? ?? ?? 48 8D 4C 24 ?? 0F 57 DB F3 0F 11 7C 24 ?? 48 8B D6 89 44 24 ?? E8 ?? ?? ?? ?? BA 02 00 00 00";

        private IAsmHook _BackCardColor;
        private IAsmHook _BackSquaresColor;
        private IAsmHook _DetailBackColor;
        private IAsmHook _DetailCampMenuChairColor;
        private IAsmHook _DetailCampMenuChairAndKotone;
        private IAsmHook _BackCampMenuChairAndKotone;
        private IAsmHook _DetailCompletedBack;
        private IAsmHook _DetailCompleted;
        private IAsmHook _DetailRightDownCorner;
        private IAsmHook _DetailUnknownReward;
        private IAsmHook _DetailEarnedTag;
        private IAsmHook _TaskTitle;
        private IAsmHook _UnknownTaskDescription;
        private IAsmHook _DetailRequestDetails;
        private IAsmHook _DetailUnknownTask;
        private IAsmHook _RequestsCursorColor;
        private IAsmHook _RequestsDetailCursorColor;
        private IAsmHook _DifficultyRankUp;
        private IAsmHook _DifficultyRankDown;
        private IAsmHook _DifficultyIndicatorButterfly;
        private IAsmHook _DifficultyFont;
        private IAsmHook _FontAndStatusTagBackground;
        private IAsmHook _FontStatusTag;
        private IAsmHook _StatusTagUnderlay;
        private IAsmHook _NumberColumn;
        private IAsmHook _QuestColumn;
        private IAsmHook _DateColumn;
        private IAsmHook _StatusColumn;
        private IAsmHook _SortCurrentText;
        private IAsmHook _NumberTriangle;
        private IAsmHook _NumberSortFont;
        private IAsmHook _StatusTriangle;
        private IAsmHook _StatusSortFont;

        /*
        private string AUIRequest_DetailColor_SIG = "E8 ?? ?? ?? ?? BA 04 00 00 00 89 45 ??";
        
        private IAsmHook _DetailColor;
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
            _context._utils.SigScan(AUIRequest_DetailBackColor_SIG, "AUIRequest::DetailBackColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackCardDetail.B:X}",
                    $"mov dl, ${_context._config.RequestBackCardDetail.G:X}",
                    $"mov cl, ${_context._config.RequestBackCardDetail.R:X}"
                };
                _DetailBackColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_BackCampMenuChairAndKotone_SIG, "AUIRequest::BackCampMenuChairAndKotone", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.QuestFemcChairsShadow.B:X}",
                    $"mov dl, ${_context._config.QuestFemcChairsShadow.G:X}",
                    $"mov cl, ${_context._config.QuestFemcChairsShadow.R:X}"
                };
                _BackCampMenuChairAndKotone = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_DetailCampMenuChairColor_SIG, "AUIRequest::DetailCampMenuChairColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.QuestFemcChairsShadow.B:X}",
                    $"mov dl, ${_context._config.QuestFemcChairsShadow.G:X}",
                    $"mov cl, ${_context._config.QuestFemcChairsShadow.R:X}"
                };
                _DetailCampMenuChairColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_DetailCampMenuChairAndKotone_SIG, "AUIRequest::DetailCampMenuChairAndKotone", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestDetailFemcChairsShadow.B:X}",
                    $"mov dl, ${_context._config.RequestDetailFemcChairsShadow.G:X}",
                    $"mov cl, ${_context._config.RequestDetailFemcChairsShadow.R:X}"
                };
                _DetailCampMenuChairAndKotone = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            
            _context._utils.SigScan(AUIRequest_DetailCompletedBack_SIG, "AUIRequest::DetailCompletedBack", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestDetailBackgroundCompleted.B:X}",
                    $"mov dl, ${_context._config.RequestDetailBackgroundCompleted.G:X}",
                    $"mov cl, ${_context._config.RequestDetailBackgroundCompleted.R:X}"
                };
                _DetailCompletedBack = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_DetailCompleted_SIG, "AUIRequest::DetailCompleted", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestDetailCompleted.B:X}",
                    $"mov dl, ${_context._config.RequestDetailCompleted.G:X}",
                    $"mov cl, ${_context._config.RequestDetailCompleted.R:X}"
                };
                _DetailCompleted = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_DetailRightDownCorner_SIG, "AUIRequest::DetailRightDownCorner", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackCardRightDownDetail.B:X}",
                    $"mov dl, ${_context._config.RequestBackCardRightDownDetail.G:X}",
                    $"mov cl, ${_context._config.RequestBackCardRightDownDetail.R:X}"
                };
                _DetailRightDownCorner = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_DetailUnknownReward_SIG, "AUIRequest::DetailUnknownReward", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackCard.B:X}",
                    $"mov dl, ${_context._config.RequestBackCard.G:X}",
                    $"mov cl, ${_context._config.RequestBackCard.R:X}"
                };
                _DetailUnknownReward = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_DetailEarnedTag_SIG, "AUIRequest::DetailEarnedTag", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestDetailEarned.B:X}",
                    $"mov dl, ${_context._config.RequestDetailEarned.G:X}",
                    $"mov cl, ${_context._config.RequestDetailEarned.R:X}"
                };
                _DetailEarnedTag = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_TaskTitle_SIG, "AUIRequest::TaskTitle", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestTaskFont.B:X}",
                    $"mov dl, ${_context._config.RequestTaskFont.G:X}",
                    $"mov cl, ${_context._config.RequestTaskFont.R:X}"
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
            _context._utils.SigScan(AUIRequest_DetailRequestDetails_SIG, "AUIRequest::DetailRequestDetails", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestDetailsFont.B:X}",
                    $"mov dl, ${_context._config.RequestDetailsFont.G:X}",
                    $"mov cl, ${_context._config.RequestDetailsFont.R:X}"
                };
                _DetailRequestDetails = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIRequest_DetailUnknownTask_SIG, "AUIRequest::DetailUnknownTask", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestBackCard.B:X}",
                    $"mov dl, ${_context._config.RequestBackCard.G:X}",
                    $"mov cl, ${_context._config.RequestBackCard.R:X}"
                };
                _DetailUnknownTask = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            
            
            _context._utils.SigScan(AUIRequest_RequestsCursorColor_SIG, "AUIRequest::RequestsCursorColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.CampHighlightedLowerColor.B:X}",
                    $"mov dl, ${_context._config.CampHighlightedLowerColor.G:X}",
                    $"mov cl, ${_context._config.CampHighlightedLowerColor.R:X}"
                };
                _RequestsCursorColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_RequestsDetailCursorColor_SIG, "AUIRequest::RequestsDetailCursorColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.CampHighlightedLowerColor.B:X}",
                    $"mov dl, ${_context._config.CampHighlightedLowerColor.G:X}",
                    $"mov cl, ${_context._config.CampHighlightedLowerColor.R:X}"
                };
                _RequestsDetailCursorColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_DifficultyRankUp_SIG, "AUIRequest::DifficultyRankUp", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestDifficultyRankUp.B:X}",
                    $"mov dl, ${_context._config.RequestDifficultyRankUp.G:X}",
                    $"mov cl, ${_context._config.RequestDifficultyRankUp.R:X}"
                };
                _DifficultyRankUp = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_DifficultyRankDown_SIG, "AUIRequest::DifficultyRankDown", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestDifficultyRankDown.B:X}",
                    $"mov dl, ${_context._config.RequestDifficultyRankDown.G:X}",
                    $"mov cl, ${_context._config.RequestDifficultyRankDown.R:X}"
                };
                _DifficultyRankDown = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_DifficultyIndicatorButterfly1_SIG, "AUIRequest::DifficultyIndicatorButterfly1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestDifficultyIndicator.B:X}",
                    $"mov dl, ${_context._config.RequestDifficultyIndicator.G:X}",
                    $"mov cl, ${_context._config.RequestDifficultyIndicator.R:X}"
                };
                _DifficultyIndicatorButterfly = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_DifficultyIndicatorButterfly2_SIG, "AUIRequest::DifficultyIndicatorButterfly2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestDifficultyIndicator.B:X}",
                    $"mov dl, ${_context._config.RequestDifficultyIndicator.G:X}",
                    $"mov cl, ${_context._config.RequestDifficultyIndicator.R:X}"
                };
                _DifficultyIndicatorButterfly = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_DifficultyIndicatorButterfly34_SIG, "AUIRequest::DifficultyIndicatorButterfly34", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestDifficultyIndicator.B:X}",
                    $"mov dl, ${_context._config.RequestDifficultyIndicator.G:X}",
                    $"mov cl, ${_context._config.RequestDifficultyIndicator.R:X}"
                };
                _DifficultyIndicatorButterfly = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
                _DifficultyIndicatorButterfly = _context._hooks.CreateAsmHook(function, addr + 21, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_DifficultyIndicatorButterfly5_SIG, "AUIRequest::DifficultyIndicatorButterfly5", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestDifficultyIndicator.B:X}",
                    $"mov dl, ${_context._config.RequestDifficultyIndicator.G:X}",
                    $"mov cl, ${_context._config.RequestDifficultyIndicator.R:X}"
                };
                _DifficultyIndicatorButterfly = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_DifficultyFont_SIG, "AUIRequest::DifficultyFont", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestDifficultyFont.B:X}",
                    $"mov dl, ${_context._config.RequestDifficultyFont.G:X}",
                    $"mov cl, ${_context._config.RequestDifficultyFont.R:X}"
                };
                _DifficultyFont = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_FontStatusTag_SIG, "AUIRequest::FontStatusTag", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestStatusTagFont.B:X}",
                    $"mov dl, ${_context._config.RequestStatusTagFont.G:X}",
                    $"mov cl, ${_context._config.RequestStatusTagFont.R:X}"
                };
                _FontStatusTag = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_FontAndStatusTagBackground_SIG, "AUIRequest::FontAndStatusTagBackground", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    "cmp cl, 0x67",
                    "jne not_pink",
                    $"mov r8b, ${_context._config.RequestStatusFontTagBack.B:X}",
                    $"mov dl, ${_context._config.RequestStatusFontTagBack.G:X}",
                    $"mov cl, ${_context._config.RequestStatusFontTagBack.R:X}",
                    "not_pink:"
                };
                _FontAndStatusTagBackground = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_FontStatusTag_SIG, "AUIRequest::FontStatusTag", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestStatusTagFont.B:X}",
                    $"mov dl, ${_context._config.RequestStatusTagFont.G:X}",
                    $"mov cl, ${_context._config.RequestStatusTagFont.R:X}"
                };
                _FontStatusTag = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_StatusTagUnderlay_SIG, "AUIRequest::StatusTagUnderlay", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.RequestStatusTagUnderlay.B:X}",
                    $"mov dl, ${_context._config.RequestStatusTagUnderlay.G:X}",
                    $"mov cl, ${_context._config.RequestStatusTagUnderlay.R:X}"
                };
                _StatusTagUnderlay = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_NumberColumn_SIG, "AUIRequest::NumberColumn", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.DataColumnColor.B:X}",
                    $"mov dl, ${_context._config.DataColumnColor.G:X}",
                    $"mov cl, ${_context._config.DataColumnColor.R:X}"
                };
                _NumberColumn = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_QuestColumn_SIG, "AUIRequest::QuestColumn", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.DataColumnColor.B:X}",
                    $"mov dl, ${_context._config.DataColumnColor.G:X}",
                    $"mov cl, ${_context._config.DataColumnColor.R:X}"
                };
                _QuestColumn = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_DateColumn_SIG, "AUIRequest::DateColumn", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.DataColumnColor.B:X}",
                    $"mov dl, ${_context._config.DataColumnColor.G:X}",
                    $"mov cl, ${_context._config.DataColumnColor.R:X}"
                };
                _DateColumn = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_StatusColumn_SIG, "AUIRequest::StatusColumn", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.DataColumnColor.B:X}",
                    $"mov dl, ${_context._config.DataColumnColor.G:X}",
                    $"mov cl, ${_context._config.DataColumnColor.R:X}"
                };
                _StatusColumn = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_SortCurrentText_SIG, "AUIRequest::SortCurrentText", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.SelectedSortColumnTitle.B:X}",
                    $"mov dl, ${_context._config.SelectedSortColumnTitle.G:X}",
                    $"mov cl, ${_context._config.SelectedSortColumnTitle.R:X}"
                };
                _SortCurrentText = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_NumberTriangle_SIG, "AUIRequest::NumberTriangle", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.MissingSortTriangle.B:X}",
                    $"mov dl, ${_context._config.MissingSortTriangle.G:X}",
                    $"mov cl, ${_context._config.MissingSortTriangle.R:X}"
                };
                _NumberTriangle = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_NumberSortFont_SIG, "AUIRequest::NumberSortFont", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.MissingSortTriangle.B:X}",
                    $"mov dl, ${_context._config.MissingSortTriangle.G:X}",
                    $"mov cl, ${_context._config.MissingSortTriangle.R:X}"
                };
                _NumberSortFont = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_StatusTriangle_SIG, "AUIRequest::StatusTriangle", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.MissingSortTriangle.B:X}",
                    $"mov dl, ${_context._config.MissingSortTriangle.G:X}",
                    $"mov cl, ${_context._config.MissingSortTriangle.R:X}"
                };
                _StatusTriangle = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUIRequest_StatusSortFont_SIG, "AUIRequest::StatusSortFont", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.MissingSortTriangle.B:X}",
                    $"mov dl, ${_context._config.MissingSortTriangle.G:X}",
                    $"mov cl, ${_context._config.MissingSortTriangle.R:X}"
                };
                _StatusSortFont = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }

        public override void Register() { }
    }
}
