using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{   
    public class PersonaStatus : ModuleAsmInlineColorEdit<FemcContext>
    {
        // so many hooks....
        private string APersonaStatusDraw_GetDefaultPersonaInfoBgInner_SIG = "48 8B C4 55 53 56 57 41 56 48 8D A8 ?? ?? ?? ?? 48 81 EC B0 01 00 00";
        private string APersonaStatusDraw_GetDefaultPersonaInfoBgInner_SIG_EpAigis = "4C 8B DC 55 56 41 56 49 8D AB ?? ?? ?? ?? 48 81 EC C0 01 00 00";
        private MultiSignature GetDefaultPersonaInfoBgInnerMS;
        private string APersonaStatusDraw_DrawGradientRectangle_SIG = "48 8B C4 48 89 58 ?? 48 89 70 ?? 48 89 78 ?? 55 41 54 41 55 41 56 41 57 48 8D A8 ?? ?? ?? ?? 48 81 EC B0 03 00 00";
        private string APersonaStatusDraw_DrawDefaultStatusParameterInner_SIG = "40 55 57 48 8D AC 24 ?? ?? ?? ?? 48 81 EC 88 03 00 00";
        // in APersonaStatusDraw::DrawDefaultPersonaInfo
        private string APersonaStatusDraw_GetDefaultPersonaInfo_PlayerName_SIG = "41 81 C9 00 EA FF 00"; // or r9d, 0xffea00, + 0x785
        // in APersonaStatusDraw::DrawSkillListInner
        private string APersonaStatusDraw_GetSkillListBgColor_SIG = "C7 45 ?? 3B 02 00 FF E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ??";
        private string APersonaStatusDraw_GetSkillListCheckerboard1_SIG = "C7 45 ?? 66 2F 2B FF";
        private string APersonaStatusDraw_GetSkillListCheckerboard2_SIG = "C7 44 24 ?? 66 2F 2B FF";
        private string APersonaStatusDraw_GetSkillListNoNextSkill_SIG = "C7 45 ?? 58 20 1D FF";
        private string APersonaStatusDraw_GetSkillListNextSkill_SIG = "C7 45 ?? C6 0E 00 FF F3 44 0F 11 44 24 ??";
        private string APersonaStatusDraw_GetSkillListNextLevel_SIG = "C7 45 ?? FF D3 00 FF 48 8D 45 ??";
        private string APersonaStatusDraw_GetSkillListNextSkillInfoBg_SIG = "C7 45 ?? C6 0E 00 FF 48 89 44 24 ??";
        private string APersonaStatusDraw_GetSkillListNextSkillInfoText_SIG = "C7 44 24 ?? FF D3 00 FF 8B 5C 24 ??"; 
        // in APersonaStatusDraw::DrawAttribute (Affinities)
        private string APersonaStatusDraw_DrawAttributeOutlineColor_SIG = "44 88 6C 24 ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? F3 0F 10 3D ?? ?? ?? ??";
        private string APersonaStatusDraw_DrawDefaultCommentary_SIG = "48 8B C4 48 89 58 ?? 48 89 70 ?? 55 57 41 56 48 8D 68 ?? 48 81 EC F0 00 00 00 44 0F 29 40 ??";
        private string APersonaStatusDraw_DrawCommentaryText_SIG = "E8 ?? ?? ?? ?? 0F B6 87 ?? ?? ?? ?? 81 CB 00 FF FF FF";
        private string APersonaStatusDraw_GetTextPosRowLayoutDatatable_SIG = "E8 ?? ?? ?? ?? 48 85 C0 74 ?? F3 0F 2C 70 ?? 0F B6 87 ?? ?? ?? ??";

        private string APersonaStatusDraw_DrawNone_SIG = "C7 45 ?? 9F 83 83 FF";
        private string APersonaStatusDraw_SelectedSkillFont_SIG = "C7 45 ?? 3B 02 00 FF E8 ?? ?? ?? ?? 49 8B 97 ?? ?? ?? ??";
        private string APersonaStatusDraw_SwapSelectedSkillFontBg_SIG = "C7 45 ?? FE BA 8D FF";
        private string APersonaStatusDraw_SwapUnselectedSkillFont_SIG = "C7 45 ?? 9E 52 3C FF 48 89 85 ?? ?? ?? ?? 48 85 C0 74 ?? F0 FF 40 ?? 8B 85 ?? ?? ?? ?? 48 8D 4D ?? 89 85 ?? ?? ?? ?? 41 0F 28 D2 41 0F B6 87 ?? ?? ?? ?? 41 0F 28 CC F3 0F 58 15 ?? ?? ?? ?? F3 0F 58 0D ?? ?? ?? ?? 88 44 24 ?? 41 0F 28 D9 8B 45 ?? 89 44 24 ?? 48 8D 85 ?? ?? ?? ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 41 0F B6 87 ?? ?? ?? ?? 41 B1 05 88 44 24 ?? 41 B0 04 44 88 6C 24 ?? 33 D2 C6 44 24 ?? 01 49 8B CC 44 88 6C 24 ?? E8 ?? ?? ?? ?? 48 8B 45 ??";
        private string APersonaStatusDraw_SwapUnselectedSkillBg_SIG = "C7 45 ?? D1 7A 62 FF";

        private string APersonaStatusDraw_InheritableSkillTick_SIG = "C7 45 ?? B2 8C 31 FF";
        private string APersonaStatusDraw_InheritableSkillTickBg_SIG = "C7 45 ?? 71 3A 36 FF";

        private string APersonaStatusDraw_GetSkillListNextSkillZero_SIG = "C7 44 24 ?? AE 6A 0A FF";
        private string APersonaStatusDraw_GetSkillListNextSkillZeroNumber_SIG = "C7 44 24 ?? FF D3 00 FF 8B 44 24 ??";

        private string APersonaStatusDraw_NextSkillsQuestionMarkOutterOutline_SIG = "C7 45 ?? C6 0E 00 FF E8 ?? ?? ?? ?? F3 41 0F 58 F2";
        private string APersonaStatusDraw_NextSkillsQuestionMarkInnerOutline_SIG = "C7 45 ?? FF D3 00 FF 4C 8D 75 ?? 48 63 FB";

        private string APersonaStatusDraw_HighlightedSkillCursor_SIG = "88 5C 24 ?? F3 41 0F 58 87 ?? ?? ?? ??";
        private string APersonaStatusDraw_HighlightedSkillCursorNextSkill_SIG = "C7 45 ?? 29 00 EA FF";
        private string APersonaStatusDraw_HighlightedSkillCursorSkillCardBlendState_SIG = "B2 02 E8 ?? ?? ?? ?? 0F B6 87 ?? ?? ?? ??";
        private string APersonaStatusDraw_HighlightedSkillCursorSkillCard_SIG = "40 88 B5 ?? ?? ?? ?? E8 ?? ?? ?? ?? EB ??";

        private string APersonaStatusDraw_SkillCardBgColor_SIG = "40 88 74 24 ?? E8 ?? ?? ?? ?? 40 88 74 24 ??";
        private string APersonaStatusDraw_SkillCardSkillBgColor_SIG = "8B 44 24 ?? 41 0F 28 D7 F3 0F 58 15 ?? ?? ?? ??";
        private string APersonaStatusDraw_SkillCardSelectedSkillAnimation_SIG = "F3 0F 59 05 ?? ?? ?? ?? F3 0F 2C C0 F3 41 0F 10 87 ?? ?? ?? ??";
        private string APersonaStatusDraw_SkillCardSelectedSkillAnimationFontColor_SIG = "C7 45 ?? 9E 52 3C FF 48 89 85 ?? ?? ?? ?? 48 85 C0 74 ?? F0 FF 40 ?? 8B 85 ?? ?? ?? ?? 48 8D 4D ?? 89 85 ?? ?? ?? ?? 41 0F 28 D2 41 0F B6 87 ?? ?? ?? ?? 41 0F 28 CC F3 0F 58 15 ?? ?? ?? ?? F3 0F 58 0D ?? ?? ?? ?? 88 44 24 ?? 41 0F 28 D9 8B 45 ?? 89 44 24 ?? 48 8D 85 ?? ?? ?? ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 41 0F B6 87 ?? ?? ?? ?? 41 B1 05 88 44 24 ?? 41 B0 04 44 88 6C 24 ?? 33 D2 C6 44 24 ?? 01 49 8B CC 44 88 6C 24 ?? E8 ?? ?? ?? ?? 48 8B 85 ?? ?? ?? ??";

        private string APersonaStatusDraw_SkillDescriptionBg_SIG = "E8 ?? ?? ?? ?? 0F B6 87 ?? ?? ?? ?? 41 0F 28 D0 F3 0F 5C 15 ?? ?? ?? ??";
        private string APersonaStatusDraw_SkillDescriptionCornerBg_SIG = "E8 ?? ?? ?? ?? F3 44 0F 10 15 ?? ?? ?? ?? BA 15 00 00 00";
        private string APersonaStatusDraw_SkillDescriptionCornerSkillFontBg_SIG = "F3 0F 11 44 24 ?? F3 41 0F 58 CA F3 44 0F 11 4C 24 ??";

        private string APersonaStatusDraw_PersonaFusionShadow_SIG = "C7 45 ?? 57 20 1D FF";
        private string APersonaStatusDraw_PersonaInheritanceCursor_SIG = "66 44 89 7D ?? C6 45 ?? EE";

        // Fade animation so separated r,g,b for every color interpolation function call
        private string APersonaStatusDraw_PersonaInheritanceSocialLinkBonusRed_SIG = "66 0F 6E C0 0F 5B C0 E8 ?? ?? ?? ?? F3 0F 2C C0 41 0F 28 D3 41 0F 28 CC";
        private string APersonaStatusDraw_PersonaInheritanceSocialLinkBonusGreen_SIG = "88 85 ?? ?? ?? ?? 0F B6 85 ?? ?? ?? ?? 66 0F 6E C0 0F 5B C0 E8 ?? ?? ?? ?? F3 0F 2C C0 41 0F 28 D3";
        private string APersonaStatusDraw_PersonaInheritanceSocialLinkBonusBlue_SIG = "88 85 ?? ?? ?? ?? 0F B6 85 ?? ?? ?? ?? 66 0F 6E C0 0F 5B C0 E8 ?? ?? ?? ?? F3 0F 2C C0 88 85 ?? ?? ?? ??";
        private string APersonaStatusDraw_PersonaSkillSelectSocialLinkBonusRed_SIG = "E8 ?? ?? ?? ?? F3 44 0F 10 25 ?? ?? ?? ?? 41 0F 28 D5";
        private string APersonaStatusDraw_PersonaSkillSelectSocialLinkBonusGreen_SIG = "88 85 ?? ?? ?? ?? 0F B6 85 ?? ?? ?? ?? 66 0F 6E C0 0F 5B C0 E8 ?? ?? ?? ?? F3 0F 2C C0 41 0F 28 D5";
        private string APersonaStatusDraw_PersonaSkillSelectSocialLinkBonusBlue_SIG = "88 85 ?? ?? ?? ?? 0F B6 85 ?? ?? ?? ?? 66 0F 6E C0 0F 5B C0 E8 ?? ?? ?? ?? 0F B6 8D ?? ?? ?? ??";

        private string APersonaStatusDraw_PersonaMutationUp_SIG = "C7 45 ?? C6 0E 00 FF E8 ?? ?? ?? ?? 45 33 C9 C7 85 ?? ?? ?? ?? 00 80 84 C3";
        private string APersonaStatusDraw_PersonaMutationMiddle_SIG = "C7 45 ?? C6 0E 00 FF E8 ?? ?? ?? ?? 45 33 C9 C7 85 ?? ?? ?? ?? 00 00 7F C3";
        private string APersonaStatusDraw_PersonaMutationDown_SIG = "C7 45 ?? C6 0E 00 FF E8 ?? ?? ?? ?? 41 8B 87 ?? ?? ?? ??";

        // Fusion mini animation after fusing persona which learns a new skill
        private string APersonaStatusDraw_GetFusionSkillListNextSkill_SIG = "C7 45 ?? C6 0E 00 FF E8 ?? ?? ?? ?? 49 8B 87 ?? ?? ?? ??";
        private string APersonaStatusDraw_NextSkillsFusionQuestionMarkOutterOutline_SIG = "C7 45 ?? C6 0E 00 FF E8 ?? ?? ?? ?? F3 41 0F 58 F3";
        private string APersonaStatusDraw_NextSkillsFusionQuestionMarkInnerOutline_SIG = "C7 45 ?? FF D3 00 FF 4C 8D 75 ?? 48 63 F3";
        private string APersonaStatusDraw_NextSkillLastSkillFontColor_SIG = "44 88 6C 24 ?? 88 5C 24 ??";
        // Fade animation so separated r,g,b for every color interpolation function call
        private string APersonaStatusDraw_PersonaFusionNextSkillBgRed_SIG = "E8 ?? ?? ?? ?? F3 0F 10 0D ?? ?? ?? ?? 0F 28 D6 F3 0F 2C F8 F3 0F 10 05 ?? ?? ?? ?? E8 ?? ?? ?? ?? F3 0F 10 0D ?? ?? ?? ?? 0F 28 D6 F3 0F 2C D8 F3 0F 10 05 ?? ?? ?? ?? E8 ?? ?? ?? ?? F3 0F 2C C0";
        private string APersonaStatusDraw_PersonaFusionNextSkillBgGreen_SIG = "E8 ?? ?? ?? ?? F3 0F 10 0D ?? ?? ?? ?? 0F 28 D6 F3 0F 2C D8 F3 0F 10 05 ?? ?? ?? ?? E8 ?? ?? ?? ?? F3 0F 2C C0";
        private string APersonaStatusDraw_PersonaFusionNextSkillBgBlue_SIG = "E8 ?? ?? ?? ?? F3 0F 2C C0 88 5D ?? 49 8B CC";

        private string APersonaStatusDraw_NumbersTopLeftCornerDraw_SIG = "C6 85 ?? ?? ?? ?? 00 88 9D ?? ?? ?? ?? 8B 85 ?? ?? ?? ??";
        private string APersonaStatusDraw_ResultTopLeftCornerDraw_SIG = "C6 85 ?? ?? ?? ?? 00 8B 85 ?? ?? ?? ?? 48 8D 9F ?? ?? ?? ??";
        private string APersonaStatusDraw_DotsTopLeftCornerDraw_SIG = "C6 85 ?? ?? ?? ?? 00 88 9D ?? ?? ?? ?? E8 ?? ?? ?? ?? 44 8B 65 ??";

        private string APersonaStatusDraw_LeftArrow_SIG = "C7 45 ?? 00 00 EE FF 48 8D 4D ??";
        private string APersonaStatusDraw_RightArrow_SIG = "C7 44 24 ?? 00 00 EE FF 48 8D 4C 24 ??";


        //private static float[] PersonaInfoBgPoints = { 0, 0, 1270.5f, 0, 1732.5f, 0, 2310, 0, 0, 224, 1270.5f, 24, 1732.5f, 224, 2310, 224 };
        private unsafe float* PersonaInfoBgPoints;
        public struct PersonaStatusGradientLine
        {
            public FColor farL;
            public FColor midL;
            public FColor midR;
            public FColor farR;
            public PersonaStatusGradientLine(FColor c0, FColor c1, FColor c2, FColor c3) { farL = c0; midL = c1; midR = c2; farR = c3; }
            public PersonaStatusGradientLine(FColor c0) { farL = c0; midL = c0; midR = c0; farR = c0; }
        }

        public static readonly PersonaStatusGradientLine WhiteGradient = new PersonaStatusGradientLine(new FColor(0xff, 0xff, 0xff, 0xff));

        //public PersonaStatusGradientLine[] PersonaInfoBgColors;
        private unsafe PersonaStatusGradientLine* PersonaInfoBgColors;
        private unsafe float* PersonaStatParamBgPoints;
        private unsafe PersonaStatusGradientLine* PersonaStatParamBgColors;

        private UICommon _uiCommon;
        private IHook<APersonaStatusDraw_DrawDefaultPersonaInfoBackgroundInner> _drawInfoBg;
        private APersonaStatusDraw_DrawGradientRectangle _drawGradRect;

        private IAsmHook _drawAttributeOutlineColor;
        private IAsmHook _HighlightedSkillCursor;
        private IAsmHook _HighlightedSkillCursorSkillCard;
        private IAsmHook _SkillCardBgColor;
        private IAsmHook _SkillCardSkillBgColor;
        private IAsmHook _SkillCardSelectedSkillAnimation;
        private IAsmHook _SkillDescriptionBg;
        private IAsmHook _SkillDescriptionCornerBg;
        private IAsmHook _SkillDescriptionCornerSkillFontBg;
        private IAsmHook _PersonaInheritanceCursor;
        private IAsmHook _PersonaInheritanceSocialLinkBonusRed;
        private IAsmHook _PersonaInheritanceSocialLinkBonusGreen;
        private IAsmHook _PersonaInheritanceSocialLinkBonusBlue;
        private IAsmHook _PersonaSkillSelectSocialLinkBonusRed;
        private IAsmHook _PersonaSkillSelectSocialLinkBonusGreen;
        private IAsmHook _PersonaSkillSelectSocialLinkBonusBlue;
        private IAsmHook _PersonaFusionNextSkillBgRed;
        private IAsmHook _PersonaFusionNextSkillBgGreen;
        private IAsmHook _PersonaFusionNextSkillBgBlue;
        private IAsmHook _NextSkillLastSkillFontColor;
        private IAsmHook _NumbersTopLeftCornerDraw;
        private IAsmHook _ResultTopLeftCornerDraw;
        private IAsmHook _DotsTopLeftCornerDraw;

        private IHook<APersonaStatusDraw_DrawDefaultStatusParameterInner> _drawStatParam;
        private IHook<APersonaStatusDraw_DrawDefaultCommentary> _drawDefaultLore;
        private APersonaStatusDraw_DrawCommentaryDescription _drawLoreDescription;
        private APersonaStatusDraw_GetTextPosRowLayoutDataTable _getTextPosRow;

        private static int MaximumLevel = 99;
        public unsafe PersonaStatus(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(APersonaStatusDraw_DrawNone_SIG, "APersonaStatusDraw::DrawNone", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.NoneSkillColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_SelectedSkillFont_SIG, "APersonaStatusDraw::SelectedSkillFont", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.SelectedSkillFontColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_SwapSelectedSkillFontBg_SIG, "APersonaStatusDraw::SwapSelectedSkillFontBg", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.SwapSkillShadowSelectedFontColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_SwapUnselectedSkillFont_SIG, "APersonaStatusDraw::SwapUnselectedSkillFont", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.SwapSkillUnselectedFontColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_SwapUnselectedSkillBg_SIG, "APersonaStatusDraw::SwapUnselectedSkillBg", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.SwapSkillUnselectedBgColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_InheritableSkillTick_SIG, "APersonaStatusDraw::InheritableSkillTick", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.InheritableSkillTick.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_InheritableSkillTickBg_SIG, "APersonaStatusDraw::InheritableSkillTickBg", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.InheritableSkillTickBg.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListNextSkillZero_SIG, "APersonaStatusDraw::GetSkillListNextSkillZero", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.NextSkillZero.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListNextSkillZeroNumber_SIG, "APersonaStatusDraw::GetSkillListNextSkillZeroNumber", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.PersonaSkillListNextLevelColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_NextSkillsQuestionMarkOutterOutline_SIG, "APersonaStatusDraw::NextSkillsQuestionMarkOutterOutline", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.NextSkillOutterOutlineColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_NextSkillsQuestionMarkInnerOutline_SIG, "APersonaStatusDraw::NextSkillsQuestionMarkInnerOutline", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.NextSkillInnerOutlineColor.ToU32ARGB())));
            });


            _context._utils.SigScan(APersonaStatusDraw_HighlightedSkillCursor_SIG, "APersonaStatusDraw::HighlightedSkillCursor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp + 0x76], {_context._config.PersonaStatusHighlightedColor.R}",
                    $"mov byte [rsp + 0x75], {_context._config.PersonaStatusHighlightedColor.G}",
                    $"mov byte [rsp + 0x74], {_context._config.PersonaStatusHighlightedColor.B}"
                };
                _HighlightedSkillCursor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_HighlightedSkillCursorNextSkill_SIG, "APersonaStatusDraw::HighlightedSkillCursorNextSkill", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaStatusHighlightedColor.ToU32ARGB())));
            });

            _context._utils.SigScan(APersonaStatusDraw_HighlightedSkillCursorSkillCardBlendState_SIG, "APersonaStatusDraw::HighlightedSkillCursorSkillCardBlendState", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, (byte) 0x01)));
            });

            _context._utils.SigScan(APersonaStatusDraw_HighlightedSkillCursorSkillCard_SIG, "APersonaStatusDraw::HighlightedSkillCursorSkillCard", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    "push rax",
                    "push rcx",
                    "push rdx",

                    "movzx eax, sil",
                    $"imul eax, {_context._config.PersonaStatusHighlightedColor.A}",
                    "xor edx, edx",
                    "mov ecx, 255",
                    "div ecx",
                    "mov [rbp + 0x1a3], al", // Custom fade transition

                    "pop rdx",
                    "pop rcx",
                    "pop rax",

                    $"mov byte [rbp + 0x1a2], {_context._config.PersonaStatusHighlightedColor.R}",
                    $"mov byte [rbp + 0x1a1], {_context._config.PersonaStatusHighlightedColor.G}",
                    $"mov byte [rbp + 0x1a0], {_context._config.PersonaStatusHighlightedColor.B}"
                };
                _HighlightedSkillCursorSkillCard = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteAfter).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_SkillCardBgColor_SIG, "APersonaStatusDraw::SkillCardBgColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp + 0x7a], {_context._config.PersonaStatusSkillListBg.R}",
                    $"mov byte [rsp + 0x79], {_context._config.PersonaStatusSkillListBg.G}",
                    $"mov byte [rsp + 0x78], {_context._config.PersonaStatusSkillListBg.B}"
                };
                _SkillCardBgColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_SkillCardSkillBgColor_SIG, "APersonaStatusDraw::SkillCardSkillBgColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    "jnz white_bg",
                    $"mov byte [rsp + 0x76], {_context._config.SkillCardSkillBg.R}",
                    $"mov byte [rsp + 0x75], {_context._config.SkillCardSkillBg.G}",
                    $"mov byte [rsp + 0x74], {_context._config.SkillCardSkillBg.B}",
                    "white_bg:"
                };
                _SkillCardSkillBgColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_SkillCardSelectedSkillAnimation_SIG, "APersonaStatusDraw::SkillCardSelectedSkillAnimation", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp - 0x62], {_context._config.SkillCardSelectedSkillAnimation.R}",
                    $"mov byte [rbp - 0x63], {_context._config.SkillCardSelectedSkillAnimation.G}",
                    $"mov byte [rbp - 0x64], {_context._config.SkillCardSelectedSkillAnimation.B}"
                };
                _SkillCardSelectedSkillAnimation = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_SkillCardSelectedSkillAnimationFontColor_SIG, "APersonaStatusDraw::SkillCardSelectedSkillAnimationFontColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.SwapSkillUnselectedFontColor.ToU32ARGB())));
            });

            _context._utils.SigScan(APersonaStatusDraw_SkillDescriptionBg_SIG, "APersonaStatusDraw::SkillDescriptionBg", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp - 0x80], {_context._config.SkillDescriptionMainBg.B}",
                    $"mov byte [rbp - 0x7F], {_context._config.SkillDescriptionMainBg.G}",
                    $"mov byte [rbp - 0x7E], {_context._config.SkillDescriptionMainBg.R}"
                };
                _SkillDescriptionBg = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_SkillDescriptionCornerBg_SIG, "APersonaStatusDraw::SkillDescriptionCornerBg", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp - 0x74], {_context._config.SkillDescriptionCornerBg.B}",
                    $"mov byte [rbp - 0x73], {_context._config.SkillDescriptionCornerBg.G}",
                    $"mov byte [rbp - 0x72], {_context._config.SkillDescriptionCornerBg.R}"
                };
                _SkillDescriptionCornerBg = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_SkillDescriptionCornerSkillFontBg_SIG, "APersonaStatusDraw::SkillDescriptionCornerSkillFontBg", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp - 0x70], {_context._config.SkillDescriptionCornerBg.B}",
                    $"mov byte [rbp - 0x6F], {_context._config.SkillDescriptionCornerBg.G}",
                    $"mov byte [rbp - 0x6E], {_context._config.SkillDescriptionCornerBg.R}"
                };
                _SkillDescriptionCornerSkillFontBg = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_PersonaFusionShadow_SIG, "APersonaStatusDraw::PersonaFusionShadow", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaFusionShadow.ToU32ARGB())));
            });

            _context._utils.SigScan(APersonaStatusDraw_PersonaInheritanceCursor_SIG, "APersonaStatusDraw::PersonaInheritanceCursor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp - 0x80], {_context._config.CampHighlightedLowerColor.B}",
                    $"mov byte [rbp - 0x7F], {_context._config.CampHighlightedLowerColor.G}",
                    $"mov byte [rbp - 0x7E], {_context._config.CampHighlightedLowerColor.R}"
                };
                _PersonaInheritanceCursor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.DoNotExecuteOriginal).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_PersonaInheritanceSocialLinkBonusRed_SIG, "APersonaStatusDraw::PersonaInheritanceSocialLinkBonusRed", _context._utils.GetDirectAddress, addr =>
            {
                float fValue = _context._config.PersonaSocialLinkInheritance.R;
                uint hexRed = BitConverter.ToUInt32(BitConverter.GetBytes(fValue), 0);

                string[] function =
                {
                    "use64",
                    "sub rsp, 8",
                    $"mov dword [rsp], {hexRed}",
                    "movss xmm1, dword [rsp]",
                    "add rsp, 8",
                };
                _PersonaInheritanceSocialLinkBonusRed = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_PersonaInheritanceSocialLinkBonusGreen_SIG, "APersonaStatusDraw::PersonaInheritanceSocialLinkBonusGreen", _context._utils.GetDirectAddress, addr =>
            {
                float fValue = _context._config.PersonaSocialLinkInheritance.G;
                uint hexGreen = BitConverter.ToUInt32(BitConverter.GetBytes(fValue), 0);

                string[] function =
                {
                    "use64",
                    "sub rsp, 8",
                    $"mov dword [rsp], {hexGreen}",
                    "movss xmm1, dword [rsp]",
                    "add rsp, 8",
                };
                _PersonaInheritanceSocialLinkBonusGreen = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_PersonaInheritanceSocialLinkBonusBlue_SIG, "APersonaStatusDraw::PersonaInheritanceSocialLinkBonusBlue", _context._utils.GetDirectAddress, addr =>
            {
                float fValue = _context._config.PersonaSocialLinkInheritance.B;
                uint hexBlue = BitConverter.ToUInt32(BitConverter.GetBytes(fValue), 0);

                string[] function =
                {
                    "use64",
                    "sub rsp, 8",
                    $"mov dword [rsp], {hexBlue}",
                    "movss xmm1, dword [rsp]",
                    "add rsp, 8",
                };
                _PersonaInheritanceSocialLinkBonusBlue = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_PersonaSkillSelectSocialLinkBonusRed_SIG, "APersonaStatusDraw::PersonaSkillSelectSocialLinkBonusRed", _context._utils.GetDirectAddress, addr =>
            {
                float fValue = _context._config.PersonaSocialLinkInheritance.R;
                uint hexRed = BitConverter.ToUInt32(BitConverter.GetBytes(fValue), 0);

                string[] function =
                {
                    "use64",
                    "sub rsp, 8",
                    $"mov dword [rsp], {hexRed}",
                    "movss xmm1, dword [rsp]",
                    "add rsp, 8",
                };
                _PersonaSkillSelectSocialLinkBonusRed = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_PersonaSkillSelectSocialLinkBonusGreen_SIG, "APersonaStatusDraw::PersonaSkillSelectSocialLinkBonusGreen", _context._utils.GetDirectAddress, addr =>
            {
                float fValue = _context._config.PersonaSocialLinkInheritance.G;
                uint hexGreen = BitConverter.ToUInt32(BitConverter.GetBytes(fValue), 0);

                string[] function =
                {
                    "use64",
                    "sub rsp, 8",
                    $"mov dword [rsp], {hexGreen}",
                    "movss xmm1, dword [rsp]",
                    "add rsp, 8",
                };
                _PersonaSkillSelectSocialLinkBonusGreen = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_PersonaSkillSelectSocialLinkBonusBlue_SIG, "APersonaStatusDraw::PersonaSkillSelectSocialLinkBonusBlue", _context._utils.GetDirectAddress, addr =>
            {
                float fValue = _context._config.PersonaSocialLinkInheritance.B;
                uint hexBlue = BitConverter.ToUInt32(BitConverter.GetBytes(fValue), 0);

                string[] function =
                {
                    "use64",
                    "sub rsp, 8",
                    $"mov dword [rsp], {hexBlue}",
                    "movss xmm1, dword [rsp]",
                    "add rsp, 8",
                };
                _PersonaSkillSelectSocialLinkBonusBlue = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_PersonaMutationUp_SIG, "APersonaStatusDraw::PersonaMutationUp", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.MutationStripColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_PersonaMutationMiddle_SIG, "APersonaStatusDraw::PersonaMutationMiddle", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.MutationStripColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_PersonaMutationDown_SIG, "APersonaStatusDraw::PersonaMutationDown", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.MutationStripColor.ToU32ARGB())));
            });

            _context._utils.SigScan(APersonaStatusDraw_GetFusionSkillListNextSkill_SIG, "APersonaStatusDraw::GetFusionSkillListNextSkill", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaSkillListNextSkillColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_NextSkillsFusionQuestionMarkOutterOutline_SIG, "APersonaStatusDraw::NextSkillsFusionQuestionMarkOutterOutline", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.NextSkillOutterOutlineColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_NextSkillsFusionQuestionMarkInnerOutline_SIG, "APersonaStatusDraw::NextSkillsFusionQuestionMarkInnerOutline", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.NextSkillInnerOutlineColor.ToU32ARGB())));
            });

            _context._utils.SigScan(APersonaStatusDraw_NextSkillLastSkillFontColor_SIG, "APersonaStatusDraw::NextSkillLastSkillFontColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp + 0x78], {_context._config.PersonaSkillListNextSkillInfoName.B}",
                    $"mov byte [rsp + 0x79], {_context._config.PersonaSkillListNextSkillInfoName.G}",
                    $"mov byte [rsp + 0x7A], {_context._config.PersonaSkillListNextSkillInfoName.R}"
                };
                _NextSkillLastSkillFontColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteAfter).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_PersonaFusionNextSkillBgRed_SIG, "APersonaStatusDraw::PersonaFusionNextSkillBgRed", _context._utils.GetDirectAddress, addr =>
            {
                float fOriginalValue = _context._config.PersonaSkillListNextSkillColor.R;
                float fDestinyValue = _context._config.PersonaLvlUpSkillListNextSkillColor.R;

                uint hexOriginalColor = BitConverter.ToUInt32(BitConverter.GetBytes(fOriginalValue), 0);
                uint hexDestinyColor = BitConverter.ToUInt32(BitConverter.GetBytes(fDestinyValue), 0);

                string[] function =
                {
                    "use64",
                    "sub rsp, 16",
                    $"mov dword [rsp], {hexOriginalColor}",
                    $"mov dword [rsp+8], {hexDestinyColor}",
                    "movss xmm0, dword [rsp]",
                    "movss xmm1, dword [rsp+8]",
                    "add rsp, 16",
                };
                _PersonaFusionNextSkillBgRed = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_PersonaFusionNextSkillBgGreen_SIG, "APersonaStatusDraw::PersonaFusionNextSkillBgGreen", _context._utils.GetDirectAddress, addr =>
            {
                float fOriginalValue = _context._config.PersonaSkillListNextSkillColor.G;
                float fDestinyValue = _context._config.PersonaLvlUpSkillListNextSkillColor.G;

                uint hexOriginalColor = BitConverter.ToUInt32(BitConverter.GetBytes(fOriginalValue), 0);
                uint hexDestinyColor = BitConverter.ToUInt32(BitConverter.GetBytes(fDestinyValue), 0);

                string[] function =
                {
                    "use64",
                    "sub rsp, 16",
                    $"mov dword [rsp], {hexOriginalColor}",
                    $"mov dword [rsp+8], {hexDestinyColor}",
                    "movss xmm0, dword [rsp]",
                    "movss xmm1, dword [rsp+8]",
                    "add rsp, 16",
                };
                _PersonaFusionNextSkillBgGreen = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_PersonaFusionNextSkillBgBlue_SIG, "APersonaStatusDraw::PersonaFusionNextSkillBgBlue", _context._utils.GetDirectAddress, addr =>
            {
                float fOriginalValue = _context._config.PersonaSkillListNextSkillColor.B;
                float fDestinyValue = _context._config.PersonaLvlUpSkillListNextSkillColor.B;

                uint hexOriginalColor = BitConverter.ToUInt32(BitConverter.GetBytes(fOriginalValue), 0);
                uint hexDestinyColor = BitConverter.ToUInt32(BitConverter.GetBytes(fDestinyValue), 0);

                string[] function =
                {
                    "use64",
                    "sub rsp, 16",
                    $"mov dword [rsp], {hexOriginalColor}",
                    $"mov dword [rsp+8], {hexDestinyColor}",
                    "movss xmm0, dword [rsp]",
                    "movss xmm1, dword [rsp+8]",
                    "add rsp, 16",
                };
                _PersonaFusionNextSkillBgBlue = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_NumbersTopLeftCornerDraw_SIG, "APersonaStatusDraw::NumbersTopLeftCornerDraw", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp + 0x140], {_context._config.FusionTopRightIndicatorColors.B}",
                    $"mov byte [rbp + 0x141], {_context._config.FusionTopRightIndicatorColors.G}",
                    $"mov byte [rbp + 0x142], {_context._config.FusionTopRightIndicatorColors.R}"
                };
                _NumbersTopLeftCornerDraw = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteAfter).Activate();
            });
            _context._utils.SigScan(APersonaStatusDraw_ResultTopLeftCornerDraw_SIG, "APersonaStatusDraw::ResultTopLeftCornerDraw", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp + 0x138], {_context._config.FusionTopRightIndicatorColors.B}",
                    $"mov byte [rbp + 0x139], {_context._config.FusionTopRightIndicatorColors.G}",
                    $"mov byte [rbp + 0x13A], {_context._config.FusionTopRightIndicatorColors.R}"
                };
                _ResultTopLeftCornerDraw = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteAfter).Activate();
            });
            _context._utils.SigScan(APersonaStatusDraw_DotsTopLeftCornerDraw_SIG, "APersonaStatusDraw::DotsTopLeftCornerDraw", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp + 0x130], {_context._config.FusionTopRightIndicatorColors.B}",
                    $"mov byte [rbp + 0x131], {_context._config.FusionTopRightIndicatorColors.G}",
                    $"mov byte [rbp + 0x132], {_context._config.FusionTopRightIndicatorColors.R}"
                };
                _DotsTopLeftCornerDraw = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteAfter).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_LeftArrow_SIG, "APersonaStatusDraw::LeftArrow", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampHighlightedLowerColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_RightArrow_SIG, "APersonaStatusDraw::RightArrow", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CampHighlightedLowerColor.ToU32ARGB())));
            });

            _context._utils.SigScan(APersonaStatusDraw_GetSkillListBgColor_SIG, "APersonaStatusDraw::GetSkillListBgColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaStatusSkillListBg.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListCheckerboard1_SIG, "APersonaStatusDraw::GetSkillListCheckerboard1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaStatusSkillListCheckboardAlt.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListCheckerboard2_SIG, "APersonaStatusDraw::GetSkillListCheckerboard2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.PersonaStatusSkillListCheckboardAlt.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListNoNextSkill_SIG, "APersonaStatusDraw::GetSkillListNoNextSkill", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaStatusSkillListCheckboardAlt.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListNextSkill_SIG, "APersonaStatusDraw::GetSkillListNextSkill", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaSkillListNextSkillColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListNextLevel_SIG, "APersonaStatusDraw::GetSkillListNextLevel", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaSkillListNextLevelColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListNextSkillInfoBg_SIG, "APersonaStatusDraw::GetSkillListNextSkillInfoBg", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaSkillListNextSkillColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListNextSkillInfoText_SIG, "APersonaStatusDraw::GetSkillListNextSkillInfoText", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.PersonaSkillListNextSkillInfoName.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetDefaultPersonaInfo_PlayerName_SIG, "APersonaStatusDraw::GetDefaultPersonaInfoPlayerName", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaStatusPlayerInfoColor.ToU32())));
            });
            GetDefaultPersonaInfoBgInnerMS = new MultiSignature();
            _context._utils.MultiSigScan(
                new string[] { APersonaStatusDraw_GetDefaultPersonaInfoBgInner_SIG, APersonaStatusDraw_GetDefaultPersonaInfoBgInner_SIG_EpAigis },
                "APersonaStatusDraw::GetDefaultPersonaInfoBgInner", _context._utils.GetDirectAddress,
                addr => _drawInfoBg = _context._utils.MakeHooker<APersonaStatusDraw_DrawDefaultPersonaInfoBackgroundInner>(APersonaStatusDraw_DrawDefaultPersonaInfoBackgroundInnerImpl, addr),
                GetDefaultPersonaInfoBgInnerMS
            );
            //_context._utils.SigScan(APersonaStatusDraw_GetDefaultPersonaInfoBgInner_SIG, "APersonaStatusDraw::GetDefaultPersonaInfoBgInner", _context._utils.GetDirectAddress, addr => _drawInfoBg = _context._utils.MakeHooker<APersonaStatusDraw_DrawDefaultPersonaInfoBackgroundInner>(APersonaStatusDraw_DrawDefaultPersonaInfoBackgroundInnerImpl, addr));
            _context._utils.SigScan(APersonaStatusDraw_DrawGradientRectangle_SIG, "APersonaStatusDraw::DrawGradientRectangle", _context._utils.GetDirectAddress, addr => _drawGradRect = _context._utils.MakeWrapper<APersonaStatusDraw_DrawGradientRectangle>(addr));
            _context._utils.SigScan(APersonaStatusDraw_DrawDefaultStatusParameterInner_SIG, "APersonaStatusDraw::DrawDefaultStatusParameterInner", _context._utils.GetDirectAddress, addr => _drawStatParam = _context._utils.MakeHooker<APersonaStatusDraw_DrawDefaultStatusParameterInner>(APersonaStatusDraw_DrawDefaultStatusParameterInnerImpl, addr));

            _context._utils.SigScan(APersonaStatusDraw_DrawAttributeOutlineColor_SIG, "APersonaStatusDraw::DrawAttributeOutlineColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rsp + 0x64], {_context._config.PersonaStatusAttributeOutline.ToU32ARGB()}"
                };
                _drawAttributeOutlineColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(APersonaStatusDraw_DrawDefaultCommentary_SIG, "APersonaStatusDraw::DrawDefaultCommentary", _context._utils.GetDirectAddress, addr => _drawDefaultLore = _context._utils.MakeHooker<APersonaStatusDraw_DrawDefaultCommentary>(APersonaStatusDraw_DrawDefaultCommentaryImpl, addr));
            _context._utils.SigScan(APersonaStatusDraw_DrawCommentaryText_SIG, "APersonaStatusDraw::DrawCommentaryText", _context._utils.GetIndirectAddressShort, addr => _drawLoreDescription = _context._utils.MakeWrapper<APersonaStatusDraw_DrawCommentaryDescription>(addr));
            _context._utils.SigScan(APersonaStatusDraw_GetTextPosRowLayoutDatatable_SIG, "APersonaStatusDraw::GetTextPosRowLayoutDataTable", _context._utils.GetIndirectAddressShort, addr => _getTextPosRow = _context._utils.MakeWrapper<APersonaStatusDraw_GetTextPosRowLayoutDataTable>(addr));
            /*
            PersonaInfoBgColors = new [] {
                new PersonaStatusGradientLine(new FSprColor(0xff, 0xff, 0xff, 0xff)),
                new PersonaStatusGradientLine(new FSprColor(0xff, 0xff, 0xff, 0xff))
            };
            */
            // C# arrays are managed types, we're going to have to manually allocate memory to be able to pass it to native functions
            // APersonaStatusDraw::DrawDefaultPersonaInfoBg
            PersonaInfoBgPoints = (float*)NativeMemory.AllocZeroed(sizeof(float) * 16);
            PersonaInfoBgPoints[2] = 1270.5f;
            PersonaInfoBgPoints[4] = 1732.5f;
            PersonaInfoBgPoints[6] = 2310;
            PersonaInfoBgPoints[9] = 224;
            PersonaInfoBgPoints[10] = 1270.5f;
            PersonaInfoBgPoints[11] = 224;
            PersonaInfoBgPoints[12] = 1732.5f;
            PersonaInfoBgPoints[13] = 224;
            PersonaInfoBgPoints[14] = 2310;
            PersonaInfoBgPoints[15] = 224;

            PersonaInfoBgColors = (PersonaStatusGradientLine*)NativeMemory.AllocZeroed((nuint)(sizeof(PersonaStatusGradientLine) * 2));
            PersonaInfoBgColors[0] = WhiteGradient;
            PersonaInfoBgColors[1] = WhiteGradient;

            // APersonaStatusDraw::DrawDefaultStatusParameter
            PersonaStatParamBgPoints = (float*)NativeMemory.AllocZeroed(sizeof(float) * 16);
            PersonaStatParamBgPoints[0] = -439;
            PersonaStatParamBgPoints[1] = -68;
            PersonaStatParamBgPoints[2] = -114;
            PersonaStatParamBgPoints[3] = -130;
            PersonaStatParamBgPoints[4] = 197;
            PersonaStatParamBgPoints[5] = -188;
            PersonaStatParamBgPoints[6] = 494;
            PersonaStatParamBgPoints[7] = -245;
            PersonaStatParamBgPoints[8] = -493;
            PersonaStatParamBgPoints[9] = 246;
            PersonaStatParamBgPoints[10] = -168;
            PersonaStatParamBgPoints[11] = 184;
            PersonaStatParamBgPoints[12] = 143;
            PersonaStatParamBgPoints[13] = 125;
            PersonaStatParamBgPoints[14] = 440;
            PersonaStatParamBgPoints[15] = 69;

            PersonaStatParamBgColors = (PersonaStatusGradientLine*)NativeMemory.AllocZeroed((nuint)(sizeof(PersonaStatusGradientLine) * 2));
            /*
            PersonaStatParamBgColors[0] = new PersonaStatusGradientLine(new FColor(0x00, 0x00, 0x0b, 0xc1));
            PersonaStatParamBgColors[1] = new PersonaStatusGradientLine(new FColor(0x00, 0x00, 0x0b, 0xc1));

            PersonaStatParamBgColors[0].midL = new FColor(0xff, 0x00, 0x0b, 0xc1);
            PersonaStatParamBgColors[0].midR = new FColor(0xff, 0x00, 0x0b, 0xc1);
            PersonaStatParamBgColors[1].midL = new FColor(0xff, 0x00, 0x0b, 0xc1);
            PersonaStatParamBgColors[1].midR = new FColor(0xff, 0x00, 0x0b, 0xc1);
            */
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }
        private unsafe bool CurrentPersonaIsEquipped(APersonaStatusDraw* self)
        {
            var gWork = _uiCommon.GetUGlobalWorkEx();
            var pUnit = gWork.GetUnit(1);
            if (gWork != null && pUnit->persona.GetPersona(pUnit->persona.equip)->Id == self->pCurrentPersona->Id)
            {
                return true;
            }
            return false;
        }
        private unsafe void APersonaStatusDraw_DrawDefaultPersonaInfoBackgroundInnerImpl(APersonaStatusDraw* self, float X, float Y, float Angle)
        {
            FVector2D cPos = new FVector2D(X + 480, Y - 62);
            float cAngle = Angle - 11.2f;
            var topLeftColor = ConfigColor.ToFColorBP(_context._config.PersonaStatusSkillListBg);
            _uiCommon._drawRect(&self->baseObj.drawer, cPos.X - 550, cPos.Y - 87, 0, 810, 200, &topLeftColor, 1, 1, cAngle, 1.5f, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
            var lineColor = ConfigColor.ToFColorBP(_context._config.PersonaStatusHighlightedLine);
            _uiCommon._drawRect(&self->baseObj.drawer, cPos.X - 16, cPos.Y - 89, 0, 2310, 57, &lineColor, 1, 1, cAngle, 1.5f, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
            var bottomColor = ConfigColor.ToFColorBP(_context._config.PersonaStatusSkillListBg2);
            var bottomModX = new FAppCalculationItem(0, -134, self->Edit_Commentary_Affinity_SlideOut_Delay, self->Edit_Commentary_Affinity_SlideOut_Frame, appCalculationType.DEC);
            var bottomModY = new FAppCalculationItem(0, -128, self->Edit_Commentary_Affinity_SlideOut_Delay, self->Edit_Commentary_Affinity_SlideOut_Frame, appCalculationType.DEC);
            var lx = _uiCommon._appCalcLerp(self->PersonaInfoBottomBarMod, &bottomModX, 1, 0);
            var ly = _uiCommon._appCalcLerp(self->PersonaInfoBottomBarMod, &bottomModY, 1, 0);
            _uiCommon._drawRect(&self->baseObj.drawer, cPos.X + lx + 24, cPos.Y + ly + 115, 0, 2310, 156, &bottomColor, 1, 1, cAngle, 1.5f, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
            
            if (self->PlayerId == 1 && CurrentPersonaIsEquipped(self))
            {
                PersonaInfoBgColors[0].midR = ConfigColor.ToFColorBP(_context._config.PersonaStatusInfoSelPersonaColor1);
                PersonaInfoBgColors[0].farR = ConfigColor.ToFColorBP(_context._config.PersonaStatusInfoSelPersonaColor2);
                PersonaInfoBgColors[1].midR = ConfigColor.ToFColorBP(_context._config.PersonaStatusInfoSelPersonaColor1);
                PersonaInfoBgColors[1].farR = ConfigColor.ToFColorBP(_context._config.PersonaStatusInfoSelPersonaColor2);
            } else
            {
                PersonaInfoBgColors[0].midR = ConfigColor.ToFColorBP(_context.ColorWhite);
                PersonaInfoBgColors[0].farR = ConfigColor.ToFColorBP(_context.ColorWhite);
                PersonaInfoBgColors[1].midR = ConfigColor.ToFColorBP(_context.ColorWhite);
                PersonaInfoBgColors[1].farR = ConfigColor.ToFColorBP(_context.ColorWhite);
            }
            var mtxPos = new FVector(0, 0, 1);
            var tgtMtx = (float*)NativeMemory.Alloc(sizeof(float) * 16);
            NativeMemory.Copy(UICommon.IdentityMatrixNative, tgtMtx, sizeof(float) * 16);
            var drawerIn = &self->baseObj.drawer;
            _uiCommon.BPDrawSpr_RotateMatrix(&self->baseObj.drawer, tgtMtx, &mtxPos, cAngle);
            mtxPos = new FVector(-1155, -112, 0);
            _uiCommon.BPDrawSpr_TransformMatrix(&self->baseObj.drawer, tgtMtx, &mtxPos);
            _drawGradRect(self, cPos.X, cPos.Y, 0, PersonaInfoBgPoints, (FSprColor*)PersonaInfoBgColors, tgtMtx);
            NativeMemory.Free(tgtMtx);
            //_drawInfoBg.OriginalFunction(self, X, Y, Angle);
        }

        private unsafe FColor APersonaStatusDraw_GetNextLevelColor(APersonaStatusDraw* self, byte opacity)
        {
            var flickerParams = (FAppCalculationItem*)NativeMemory.Alloc((nuint)(sizeof(FAppCalculationItem) * 2));
            flickerParams[0] = new FAppCalculationItem(0, 1, 0, (int)(self->Edit_Flickering_Loop_Frame * 0.5), appCalculationType.DEC);
            flickerParams[1] = new FAppCalculationItem(1, 0, 0, (int)(self->Edit_Flickering_Loop_Frame * 0.5), appCalculationType.DEC);
            var flickerValue = _uiCommon._appCalcLerp(self->NextLevelColorFlicker, flickerParams, 2, 1);
            NativeMemory.Free(flickerParams);
            var colorRed = (byte)UICommon.Lerp(241, 152, flickerValue);
            var colorGreen = (byte)UICommon.Lerp(251, 144, flickerValue);
            var colorBlue = (byte)UICommon.Lerp(1, 13, flickerValue);
            return new FColor(opacity, colorRed, colorGreen, colorBlue);
        }

        private unsafe void APersonaStatusDraw_DrawStatParamBar(APersonaStatusDraw* self, FVector2D pos, float angle, FColor color, float p0, float p1, float p2, float p3)
        {
            var statBarPos = new FVector(pos.X + 234, pos.Y - 45, 0);
            var statBarMtx = (float*)NativeMemory.Alloc(sizeof(float) * 16);
            NativeMemory.Copy(UICommon.IdentityMatrixNative, statBarMtx, sizeof(float) * 16);
            _uiCommon.BPDrawSpr_TransformMatrix(&self->baseObj.drawer, statBarMtx, &statBarPos);
            var statBarRotCenter = new FVector(0, 0, 1);
            _uiCommon.BPDrawSpr_RotateMatrix(&self->baseObj.drawer, statBarMtx, &statBarRotCenter, angle - 11);
            var equipStatBarColor = new FColor(0xff, 0xff, 0x6, 0x0);
            var v0 = new FVector(p0, 9, 0);
            var v1 = new FVector(p1, 9, 0);
            var v2 = new FVector(p2, -8, 0);
            var v3 = new FVector(p3, -8, 0);
            _uiCommon._drawRectV4Inner(&self->baseObj.drawer, 0, 0, 0, &v3, &v2, &v1, &v0, &color, statBarMtx, 0.75f, self->baseObj.QueueId);
            NativeMemory.Free(statBarMtx);
        }
        
        private unsafe void APersonaStatusDraw_DrawDefaultStatusParameterInnerImpl(APersonaStatusDraw* self, float X, float Y, float Angle, float paramStatSize)
        {
            if (self->Field7BC > 0 && self->Field7C0 <= 0) return;
            var statBgCenter = ConfigColor.ToFColorBPWithAlpha(_context._config.PersonaStatusParamColor, 0xff);
            var statBgOuter = ConfigColor.ToFColorBPWithAlpha(_context._config.PersonaStatusParamColor, 0x0);

            PersonaStatParamBgColors[0].farL = statBgOuter;
            PersonaStatParamBgColors[0].midL = statBgCenter;
            PersonaStatParamBgColors[0].midR = statBgCenter;
            PersonaStatParamBgColors[0].farL = statBgOuter;
            PersonaStatParamBgColors[1].farL = statBgOuter;
            PersonaStatParamBgColors[1].midL = statBgCenter;
            PersonaStatParamBgColors[1].midR = statBgCenter;
            PersonaStatParamBgColors[1].farL = statBgOuter;

            var nextLevelColor = APersonaStatusDraw_GetNextLevelColor(self, 0xff);

            var resrc = _uiCommon._globalWorkGetUIResources();
            var campSpr = (USprAsset*)resrc->GetAssetEntry(0x32);

            var v1 = new FAppCalculationItem(0, 1, self->Edit_SkillList_SlideIn_Frame, self->Edit_PersonaInfo_SlideIn_Frame, appCalculationType.DEC);
            var switchPersonaStatParamTrans = _uiCommon._appCalcLerp(self->TimeSinceSwitchedPersona, &v1, 1, 0) * paramStatSize;
            var f2 = self->Field48E != 0 ? self->Edit_Parameter_Incense_Value_FadeIn_Frame / 3 : 0;
            var v2 = new FAppCalculationItem(0, 1, self->Edit_PersonaInfo_SlideIn_Frame, self->Edit_Parameter_UpGage_Animation_Frame, appCalculationType.DEC); // fVar19
            var f3 = _uiCommon._appCalcLerp(self->Field5C4, &v2, 1, 0) * UICommon.ProgressTrackFraction(self->Field440, f2, f2 + self->Edit_Parameter_UpGage_Animation_Frame / 3, 1); // fStack_2b8
            var f4 = UICommon.ProgressTrackFraction(self->Field444, 0, (float)self->Edit_Parameter_UpGage_Animation_Frame / 3, 6); // fVar20 / fStack_2f4
            _drawGradRect(self, X + 124, Y + 80, 6, PersonaStatParamBgPoints, (FSprColor*)PersonaStatParamBgColors, null); // params background (verified)
            for (int i = 0; i < 5; i++) // strength, magic, endurance, agility, luck
            {
                var nextLvlBonus = self->pPersonaEquipEffect->GetNextLevelStat(i);
                var equipBonus = self->pPersonaEquipEffect->GetEquipBonusStat(i);
                var baseLvl = self->GetBasePersonaStat(i);
                var baseAndEquipLvl = baseLvl + equipBonus > MaximumLevel ? MaximumLevel : baseLvl + equipBonus;
                var baseAndNextLvl = baseLvl + nextLvlBonus > MaximumLevel ? MaximumLevel : baseLvl + nextLvlBonus;
                var baseStatFloat = UICommon.Lerp(self->GetParamDisplayValueFrom(i), baseLvl, switchPersonaStatParamTrans);
                var baseStatDisplay = UICommon.Lerp(self->GetParamDisplayValueFrom(i), baseAndEquipLvl, switchPersonaStatParamTrans);
                self->SetParamDisplayValueTo(i, baseStatFloat);
                var statIconPos = new FVector2D(X - i * 8, Y + i * 53);
                var statIconPosLayout = statIconPos;
                if (self->LayoutDataTable != null)
                {
                    var statIconLayoutParam = self->LayoutDataTable->GetLayoutDataTableEntry(7);
                    statIconPosLayout.X += statIconLayoutParam->position.X;
                    statIconPosLayout.Y += statIconLayoutParam->position.Y;
                }
                
                var statIconShadowCol = ConfigColor.ToFColorBP(_context._config.PersonaSkillListNextLevelColor);
                _uiCommon._drawSpr(&self->baseObj.drawer, statIconPosLayout.X, statIconPosLayout.Y, 0, &statIconShadowCol, (uint)(i + 0x1bf), 1, 1, Angle, campSpr, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
                var statIconFillCol = new FColor(0xcc, 0x0, 0x0, 0x0);
                _uiCommon._drawSpr(&self->baseObj.drawer, statIconPosLayout.X, statIconPosLayout.Y, 0, &statIconFillCol, (uint)(i + 0x1ba), 1, 1, Angle, campSpr, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
                var personaCombineStatGrowth = self->GetCombinePersonaStatGrowth(i);
                var personaStatLevelColor = (baseLvl < baseAndNextLvl || personaCombineStatGrowth != 0) ? nextLevelColor : ConfigColor.ToFColorBP(_context.ColorWhite);
                string personaStatLevelStr = $"{(int)baseStatDisplay}";
                for (int j = 0; j < personaStatLevelStr.Length; j++)
                {
                    _uiCommon._drawSpr(&self->baseObj.drawer, statIconPos.X - 64 + j * 40, statIconPos.Y - 12 - 8 * j, 0, &personaStatLevelColor,
                        (uint)(personaStatLevelStr[j] + 0x13a), 0.85f, 0.85f, Angle - 11.45f, campSpr, EUI_DRAW_POINT.UI_DRAW_LEFT_TOP, self->baseObj.QueueId);
                }
                var barShadowColor = ConfigColor.ToFColorBP(_context._config.PersonaStatusSkillListBg);
                _uiCommon._drawSpr(&self->baseObj.drawer, statIconPos.X + 251, statIconPos.Y - 40, 0, &barShadowColor, 0x1c9, 1, 1, Angle - 11, campSpr, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
                var barContentColor = ConfigColor.ToFColorBP(_context._config.PersonaStatusSkillListCheckboardAlt);
                _uiCommon._drawSpr(&self->baseObj.drawer, statIconPos.X + 234, statIconPos.Y - 45, 0, &barContentColor, 0x1c9, 1, 1, Angle - 11, campSpr, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
                if (baseLvl < baseAndNextLvl) // draw next level stat increase
                {
                    var nf1 = UICommon.Lerp(baseAndEquipLvl * switchPersonaStatParamTrans, (baseAndEquipLvl + nextLvlBonus) * switchPersonaStatParamTrans, f4);
                    var nf2 = UICommon.ProgressTrackFraction(nf1, 0, 99, 0);
                    var nf3 = UICommon.Lerp(-206, 213, nf2);
                    var nf4 = UICommon.Lerp(-211, 208, nf2);
                    var nf5 = UICommon.ProgressTrackFraction((baseAndEquipLvl + nextLvlBonus) * switchPersonaStatParamTrans, 0, 99, 0);
                    var nf6 = UICommon.Lerp(-206, 213, nf5);
                    var nf7 = UICommon.Lerp(-211, 208, nf5);
                    APersonaStatusDraw_DrawStatParamBar(self, statIconPos, Angle, nextLevelColor, nf7, nf4, nf6, nf3);
                }
                // draw equip item stat increase
                if (equipBonus > 0)
                {
                    var ef1 = UICommon.Lerp(0, nextLvlBonus, f4);
                    var ef2 = UICommon.ProgressTrackFraction(ef1 + baseStatFloat, 0, 99, 0);
                    var ef3 = UICommon.Lerp(-206, 213, ef2);
                    var ef4 = UICommon.Lerp(-211, 208, ef2);
                    var ef5 = UICommon.ProgressTrackFraction((equipBonus * paramStatSize + baseStatFloat) + ef1, 0, 99, 0);
                    var ef6 = UICommon.Lerp(-206, 213, ef5);
                    var ef7 = UICommon.Lerp(-211, 208, ef5);
                    var equipStatBarColor = ConfigColor.ToFColorBP(_context._config.PersonaStatusEquipBonusColor);
                    APersonaStatusDraw_DrawStatParamBar(self, statIconPos, Angle, equipStatBarColor, ef7, ef4, ef6, ef3);
                }
                // draw base stat
                var f5 = UICommon.Lerp(0, nextLvlBonus, f4);
                var f6 = UICommon.ProgressTrackFraction(f5 + baseStatFloat, 0, 99, 0);
                var f7 = UICommon.Lerp(-206, 213, f6);
                var f8 = UICommon.Lerp(-211, 208, f6);
                var baseStatBarColor = ConfigColor.ToFColorBP(_context._config.PersonaStatusBaseStat);
                APersonaStatusDraw_DrawStatParamBar(self, statIconPos, Angle, baseStatBarColor, f8, -211, f7, -206);
                // draw next level sprite stuff
                /*
                var lvlUpCount = (int)UICommon.Lerp(nextLvlBonus * f3, 0, f4);
                if (lvlUpCount > 0)
                {
                }
                var nextLvlPos = new FVector2D(statIconPos.X + 45, statIconPos.Y - 23);
                var sprColor1 = new FColor(0xff, 0x07, 0xc, 0x62);
                _uiCommon._drawSpr(&self->baseObj.drawer, nextLvlPos.X - 26, nextLvlPos.Y, 0, &sprColor1, 0x1e7, 0.72f, 0.72f, Angle, campSpr, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
                //var testColor = new FColor(0xff, 0x00, 0xff, 0x00);
                //_uiCommon._drawSpr(&self->baseObj.drawer, 550, 500, 0, &testColor, 0x1e6, 1, 1, Angle, campSpr, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
                //_uiCommon._drawSpr(&self->baseObj.drawer, 600, 500, 0, &testColor, 0x1e8, 1, 1, Angle, campSpr, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
                //_uiCommon._drawSpr(&self->baseObj.drawer, 650, 500, 0, &testColor, 0x16a, 1, 1, Angle, campSpr, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
                */
            }
        }
        private unsafe void APersonaStatusDraw_DrawDefaultCommentaryImpl(APersonaStatusDraw* self, float X, float Y, float Angle, char hasDescription)
        {
            var resrc = _uiCommon._globalWorkGetUIResources();
            var campSpr = (USprAsset*)resrc->GetAssetEntry(0x32);
            var loreTitleParams = new FAppCalculationItem(0, 1, self->Edit_Commentary_SkillList_Move_Delay + self->Edit_Commentary_SkillList_Move_Frame,
                self->Edit_Commentary_FadeIn_Frame, appCalculationType.DEC);
            var loreTitleOpacity = (byte)(_uiCommon._appCalcLerp(self->PersonaInfoBottomBarMod, &loreTitleParams, 1, 0) * 255);
            if (loreTitleOpacity != 0)
            {
                var loreSlideParams = new FAppCalculationItem(100, 0, 
                    self->Edit_Commentary_SkillList_Move_Delay + self->Edit_Commentary_SkillList_Move_Frame,
                    self->Edit_Commentary_SlideIn_Frame, appCalculationType.DEC);
                var loreSlide = _uiCommon._appCalcLerp(self->PersonaInfoBottomBarMod, &loreSlideParams, 1, 0);
                float v1srcval;
                float v2srcval;
                if (self->Field309 == 0)
                {
                    if (self->Field30A == 0) { v1srcval = 0; v2srcval = 0; } 
                    else { v1srcval = -20; v2srcval = 5; }
                } else { v1srcval = 20; v2srcval = -5; }
                var v1 = new FAppCalculationItem(v1srcval, 0, 0, self->Edit_Commentary_Font_Change_Frame, appCalculationType.DEC);
                var f1 = _uiCommon._appCalcLerp(self->Field5C4, &v1, 1, 0);
                var v2 = new FAppCalculationItem(v2srcval, 0, 0, self->Edit_Commentary_Font_Change_Frame, appCalculationType.DEC);
                var f2 = _uiCommon._appCalcLerp(self->Field5C4, &v2, 1, 0);
                var fx = X + loreSlide + f1;
                var fy = Y + f2;
                var layoutParams = self->LayoutDataTable->GetLayoutDataTableEntry(0x1b);
                var loreTitleX = fx + (layoutParams != null ? layoutParams->position.X : -45);
                var loreTitleY = fy + (layoutParams != null ? layoutParams->position.Y : -76);
                var loreTitleColor = ConfigColor.ToFColorBPWithAlpha(_context._config.PersonaStatusCommentaryTitleColor, loreTitleOpacity);
                _uiCommon._drawSpr(&self->baseObj.drawer, loreTitleX, loreTitleY, 0, &loreTitleColor, 0x137, 1, 1, 0, campSpr, EUI_DRAW_POINT.UI_DRAW_LEFT_TOP, self->baseObj.QueueId);
                if (hasDescription != 0)
                { 
                    var personaHelpPos = self->TextLayoutDataTable->GetLayoutDataTableEntry(4); // DT_UILayout_PersonaStatusText
                    //var personaHelpRowOffset = self->TextPosRowLayoutDataTable->GetLayoutDataTableEntry(3); // crashes (nullptr) - layout table made at runtime from data table
                    var personaHelpRowOffset = _getTextPosRow(self, 3); // DT_UILayout_PersonaStatusTextPosRow 
                    var loreDescShadowColor = ConfigColor.ToFColorWithAlpha(ConfigColor.MellodiColorDark1, loreTitleOpacity);
                    _drawLoreDescription(fx + 5, fy + 2, 0, personaHelpPos->position.X, personaHelpPos->position.Y, loreDescShadowColor, self->pCurrentPersona->Id, self->baseObj.QueueId, 1, 0);
                    var loreDescFgColor = ConfigColor.ToFColorWithAlpha(_context.ColorWhite, loreTitleOpacity);
                    _drawLoreDescription(fx, fy, 0, personaHelpPos->position.X, personaHelpPos->position.Y, loreDescFgColor, self->pCurrentPersona->Id, self->baseObj.QueueId, 1, 0);
                } else
                {
                    var descMissingShadow = ConfigColor.ToFColorBPWithAlpha(ConfigColor.MellodiColorDark3, loreTitleOpacity);
                    _uiCommon._drawSpr(&self->baseObj.drawer, fx + 195, fy + 19, 0, &descMissingShadow, 0x2cc, 1, 1, 0, campSpr, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
                    var descMissingFg = ConfigColor.ToFColorBPWithAlpha(ConfigColor.MellodiColorLight3, loreTitleOpacity);
                    _uiCommon._drawSpr(&self->baseObj.drawer, fx + 190, fy + 17, 0, &descMissingFg, 0x2cc, 1, 1, 0, campSpr, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
                }
            }
            //_drawDefaultLore.OriginalFunction(self, X, Y, Angle, hasDescription);
        }

        private unsafe delegate void APersonaStatusDraw_DrawDefaultPersonaInfoBackgroundInner(APersonaStatusDraw* self, float X, float Y, float Angle);
        private unsafe delegate void APersonaStatusDraw_DrawGradientRectangle(APersonaStatusDraw* self, float X, float Y, int a4, float* points, FSprColor* colors, float* rotMtx);
        private unsafe delegate void APersonaStatusDraw_DrawDefaultStatusParameterInner(APersonaStatusDraw* self, float X, float Y, float Angle, float a5);
        private unsafe delegate void APersonaStatusDraw_DrawDefaultCommentary(APersonaStatusDraw* self, float X, float Y, float Angle, char hasDescription);
        private unsafe delegate void APersonaStatusDraw_DrawCommentaryDescription(float X, float Y, float Z, float wrapX, float wrapY, FColor color, ushort personaId, int queueId, int a9, int a10);
        private unsafe delegate UUILayoutDataTableEntry* APersonaStatusDraw_GetTextPosRowLayoutDataTable(APersonaStatusDraw* self, int entry);
    }
}
