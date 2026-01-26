using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using Reloaded.Hooks.Definitions.X64;
using System.Security.Cryptography;
using static Reloaded.Hooks.Definitions.X64.FunctionAttribute;

namespace p3rpc.femc.Components
{
    public class CampCommon : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string UCmpCommonDraw_DrawFemcShadowColor1_SIG = "C7 44 24 ?? FF B7 A4 9A F3 44 0F 11 5C 24 ?? E8 ?? ?? ?? ?? 0F 28 44 24 ?? 66 0F 7F 45 ?? 66 0F 73 D8 08 66 48 0F 7E C0 48 85 C0 74 ?? F0 FF 40 ?? F3 0F 10 5D ?? 48 8D 4D ?? F3 0F 10 55 ?? 41 8B D4";
        private string UCmpCommonDraw_DrawFemcShadowColor2_SIG = "C7 44 24 ?? FF B7 A4 9A F3 44 0F 11 5C 24 ?? E8 ?? ?? ?? ?? 0F 28 44 24 ?? 66 0F 7F 45 ?? 66 0F 73 D8 08 66 48 0F 7E C0 48 85 C0 74 ?? F0 FF 40 ?? F3 0F 10 5D ?? 48 8D 4D ?? F3 0F 10 55 ?? BA 02 00 00 00";
        private string UCmpCommonDraw_DrawFemcShadowColor3_SIG = "C7 44 24 ?? FF B7 A4 9A F3 44 0F 11 5C 24 ?? E8 ?? ?? ?? ?? 0F 28 44 24 ?? 66 0F 7F 45 ?? 66 0F 73 D8 08 66 48 0F 7E C0 48 85 C0 74 ?? F0 FF 40 ?? F3 0F 10 5D ?? 48 8D 4D ?? F3 0F 10 55 ?? BA 03 00 00 00";
        private string UCmpCommonDraw_DrawFemcShadowColor4_SIG = "C7 44 24 ?? FF B7 A4 9A F3 44 0F 11 5C 24 ?? E8 ?? ?? ?? ?? 41 B8 04 00 00 00";

        private string UCmpCommonDraw_DrawOutterEquipTriangleRed_SIG = "41 C7 44 ?? ?? A2 A1 21 3F";
        private string UCmpCommonDraw_DrawOutterEquipTriangleGreen_SIG = "41 C7 44 ?? ?? C9 C7 47 3F";
        private string UCmpCommonDraw_DrawOutterEquipTriangleBlue_SIG = "41 C7 44 ?? ?? 00 00 80 3F 49 C7 44 ?? ?? B3 B2 B2 3E";
        private string UCmpCommonDraw_DrawInnerEquipTriangleRed_SIG = "C7 41 ?? A2 A1 21 3F";
        private string UCmpCommonDraw_DrawInnerEquipTriangleGreen_SIG = "C7 41 ?? C9 C7 47 3F";
        private string UCmpCommonDraw_DrawInnerEquipTriangleBlue_SIG = "C7 41 ?? 00 00 80 3F 48 C7 41 ?? B3 B2 B2 3E";

        public unsafe CampCommon(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(UCmpCommonDraw_DrawFemcShadowColor1_SIG, "UCmpCommonDraw::DrawFemcShadowColor1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CampFemcShadow.ToU32())));
            });
            _context._utils.SigScan(UCmpCommonDraw_DrawFemcShadowColor2_SIG, "UCmpCommonDraw::DrawFemcShadowColor2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CampFemcShadow.ToU32())));
            });
            _context._utils.SigScan(UCmpCommonDraw_DrawFemcShadowColor3_SIG, "UCmpCommonDraw::DrawFemcShadowColor3", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CampFemcShadow.ToU32())));
            });
            _context._utils.SigScan(UCmpCommonDraw_DrawFemcShadowColor4_SIG, "UCmpCommonDraw::DrawFemcShadowColor4", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CampFemcShadow.ToU32())));
            });

            _context._utils.SigScan(UCmpCommonDraw_DrawOutterEquipTriangleRed_SIG, "UCmpCommonDraw::DrawOutterEquipTriangleRed", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 5, _context._config.EquipTriangleColor.R / 255.0f)));
            });
            _context._utils.SigScan(UCmpCommonDraw_DrawOutterEquipTriangleGreen_SIG, "UCmpCommonDraw::DrawOutterEquipTriangleGreen", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 5, _context._config.EquipTriangleColor.G / 255.0f)));
            });
            _context._utils.SigScan(UCmpCommonDraw_DrawOutterEquipTriangleBlue_SIG, "UCmpCommonDraw::DrawOutterEquipTriangleBlue", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 5, _context._config.EquipTriangleColor.B / 255.0f)));
            });
            _context._utils.SigScan(UCmpCommonDraw_DrawInnerEquipTriangleRed_SIG, "UCmpCommonDraw::DrawInnerEquipTriangleRed", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.EquipTriangleColor.R / 255.0f)));
            });
            _context._utils.SigScan(UCmpCommonDraw_DrawInnerEquipTriangleGreen_SIG, "UCmpCommonDraw::DrawInnerEquipTriangleGreen", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.EquipTriangleColor.G / 255.0f)));
            });
            _context._utils.SigScan(UCmpCommonDraw_DrawInnerEquipTriangleBlue_SIG, "UCmpCommonDraw::DrawInnerEquipTriangleBlue", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.EquipTriangleColor.B / 255.0f)));
            });
        }

        public override void Register()
        {

        }
    }
    public class CampRoot : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string ACmpMainActor_GetCampParamTableCommon_SIG = "E8 ?? ?? ?? ?? 48 8B D8 83 FF 0C"; // inside of ACmpMainActor::DrawBackgroundUpdateInner
        private string UCmpRootDraw_DrawMenuItems_SetColorsASM_SIG = "89 7D ?? 44 8B F8 89 5D ??";
        //private string UCmpRootDraw_DrawMenuItems_SetColorsNoSel_SIG = "0F 10 45 00 41 B8 01 00 00 00";
        private string UCmpRootDraw_DrawMenuItems_SetColorsNoSel_SIG = "E8 ?? ?? ?? ?? 0F 10 45 00 41 B8 01 00 00 00";
        private string UCmpRootDraw_MenuTransitionColor_SIG = "C7 84 24 ?? ?? ?? ?? FF 2A 00 FF";
        private string UCmpRootDraw_DrawHighlightedColor1_SIG = "E8 ?? ?? ?? ?? 4C 8D 6E ?? 84 C0";
        private string UCmpRootDraw_DrawHighlightedColor2_SIG = "C7 45 ?? ?? ?? ?? ?? 8B 45 ?? 89 44 24 ?? 44 89 7D ??";
        private string UCmpRootDraw_DrawPartyPanelMissingHealthColor_SIG = "E8 ?? ?? ?? ?? 41 B1 FF 89 83 ?? ?? ?? ?? 41 B0 B5";
        private string UCmpRootDraw_DrawPartyPanelMissingSpColor_SIG = "E8 ?? ?? ?? ?? 41 B1 FF 89 83 ?? ?? ?? ?? 45 0F B6 C1 89 BB ?? ?? ?? ??";

        private IHook<ACmpMainActor_GetCampParamTableCommon> _getCmpMainParams;
        private IAsmHook _setMenuItemColorsHook;
        private IAsmHook _setMenuItemColorNoSel;
        private IAsmHook _DrawHighlightedColor1;
        private IAsmHook _DrawPartyPanelMissingHealthColor;
        private IAsmHook _DrawPartyPanelMissingSpColor;
        private IReverseWrapper<UCmpRootDraw_DrawMenuItems_SetColorsNoSel> _setMenuItemColorNoSelWrapper;

        private UICommon _uiCommon;
        private CampCommon _campCommon;

        public unsafe CampRoot(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(ACmpMainActor_GetCampParamTableCommon_SIG, "ACmpMainActor::GetCmpMainParams", _context._utils.GetIndirectAddressShort, addr => _getCmpMainParams = _context._utils.MakeHooker<ACmpMainActor_GetCampParamTableCommon>(ACmpMainActor_GetCampParamTableCommonImpl, addr));
            _context._utils.SigScan(UCmpRootDraw_DrawMenuItems_SetColorsASM_SIG, "UCmpRootDraw::SetMenuItemColors", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov edi, {_context._config.CampMenuItemColor1.ToU32()}",
                    $"mov ebx, {_context._config.CampMenuItemColor2.ToU32()}",
                    $"mov eax, {_context._config.CampMenuItemColor3.ToU32()}",
                };
                _setMenuItemColorsHook = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpRootDraw_DrawMenuItems_SetColorsNoSel_SIG, "UCmpRootDraw::SetMenuItemColorNoSel", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UCmpRootDraw_DrawMenuItems_SetColorsNoSelImpl, out _setMenuItemColorNoSelWrapper)}",
                    $"movups xmm0, dqword [rbp]"
                    // hook takes up from 0x1412d1e6f to 0x1412d1e78 (jmp dest, so we're pretty squashed in)
                };
                _setMenuItemColorNoSel = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.DoNotExecuteOriginal).Activate();
            });
            _context._utils.SigScan(UCmpRootDraw_MenuTransitionColor_SIG, "UCmpRootDraw::MenuTransitionColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 7, _context._config.CampColorTransition.ToU32ARGB())));
            });
            _context._utils.SigScan(UCmpRootDraw_DrawHighlightedColor1_SIG, "UCmpRootDraw::DrawHighlightedColor1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    "test al, al",
                    "jnz .grayHighlight",
                    $"mov byte [rbp-0x7E], ${_context._config.CampRootHighlightedColor1.R:X}",
                    $"mov byte [rbp-0x7F], ${_context._config.CampRootHighlightedColor1.G:X}",
                    $"mov byte [rbp-0x80], ${_context._config.CampRootHighlightedColor1.B:X}",
                    ".grayHighlight:"
                };
                _DrawHighlightedColor1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpRootDraw_DrawHighlightedColor2_SIG, "UCmpRootDraw::DrawHighlightedColor2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampRootHighlightedColor2.ToU32ARGB())));
            });

            _context._utils.SigScan(UCmpRootDraw_DrawPartyPanelMissingHealthColor_SIG, "UCmpRootDraw::DrawPartyPanelMissingHealthColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.PartyPanelMissingHealthSp.B:X}",
                    $"mov dl, ${_context._config.PartyPanelMissingHealthSp.G:X}",
                    $"mov cl, ${_context._config.PartyPanelMissingHealthSp.R:X}"
                };
                _DrawPartyPanelMissingHealthColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpRootDraw_DrawPartyPanelMissingSpColor_SIG, "UCmpRootDraw::DrawPartyPanelMissingSpColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.PartyPanelMissingHealthSp.B:X}",
                    $"mov dl, ${_context._config.PartyPanelMissingHealthSp.G:X}",
                    $"mov cl, ${_context._config.PartyPanelMissingHealthSp.R:X}"
                };
                _DrawPartyPanelMissingSpColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
    }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
            _campCommon = GetModule<CampCommon>();
        }
        private unsafe FCampParamTableCommonRow* ACmpMainActor_GetCampParamTableCommonImpl(ACmpMainActor* self)
        {
            // dynamically change color values for Xrd777/UI/Camp/Param/DT_CampParamCommon.uasset
            var return_value = _getCmpMainParams.OriginalFunction(self);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->AoItaColorHigh, _context._config.CampHighColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->AoItaColorMid, _context._config.CampMiddleColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->AoItaColorLow, _context._config.CampLowColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->GradADownColorHigh, _context._config.CampHighColorGradation);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->GradADownColorMid, _context._config.CampMiddleColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->GradADownColorLow, _context._config.CampLowColor);

            // why tf weren't these here before
            ConfigColor.SetColorIgnoreAlpha(ref return_value->GradAUpColorHigh, _context._config.GradAUpColorHigh);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->GradBUpColorHigh, _context._config.GradBUpColorHigh);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->GradBDownColorHigh, _context._config.GradBDownColorHigh);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->GradAUpColorMid, _context._config.GradAUpColorMid);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->GradBUpColorMid, _context._config.GradBUpColorMid);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->GradBDownColorMid, _context._config.GradBDownColorMid);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->GradAUpColorLow, _context._config.GradAUpColorLow);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->GradBUpColorLow, _context._config.GradBUpColorLow);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->GradBDownColorLow, _context._config.GradBDownColorLow);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->HeroCaptureBgColor, _context._config.HeroCaptureBgColor);

            // scrotum

            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiTopAColor, _context._config.NamiTopAColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiTopBColor, _context._config.NamiTopBColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiSkillAColor, _context._config.NamiSkillAColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiSkillBColor, _context._config.NamiSkillBColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiItemAColor, _context._config.NamiItemAColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiItemBColor, _context._config.NamiItemBColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiEquipAColor, _context._config.NamiEquipAColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiEquipBColor, _context._config.NamiEquipBColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiPersonaAColor, _context._config.NamiPersonaAColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiPersonaBColor, _context._config.NamiPersonaBColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiStatusAColor, _context._config.NamiStatusAColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiStatusBColor, _context._config.NamiStatusBColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiQuestAColor, _context._config.NamiQuestAColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiQuestBColor, _context._config.NamiQuestBColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiCommuAColor, _context._config.NamiCommuAColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiCommuBColor, _context._config.NamiCommuBColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiCalendarAColor, _context._config.NamiCalendarAColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiCalendarBColor, _context._config.NamiCalendarBColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiSystemAColor, _context._config.NamiSystemAColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiSystemBColor, _context._config.NamiSystemBColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiTutorialAColor, _context._config.NamiTutorialAColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiTutorialBColor, _context._config.NamiTutorialBColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiConfigAColor, _context._config.NamiConfigAColor);
            ConfigColor.SetColorIgnoreAlpha(ref return_value->NamiConfigBColor, _context._config.NamiConfigBColor);

            return return_value;
        }
        private unsafe FLinearColor* UCmpRootDraw_DrawMenuItems_SetColorsNoSelImpl(byte opacity, FLinearColor* colorOut)
        {
            colorOut->SetColor(_context._config.CampMenuItemColorNoSel.ToU32());
            colorOut->A = (float)opacity / 255;
            return colorOut;
            
        }

        private unsafe delegate FCampParamTableCommonRow* ACmpMainActor_GetCampParamTableCommon(ACmpMainActor* self);
        // Cursed calling convention
        [Function(new Register[] { FunctionAttribute.Register.rax, FunctionAttribute.Register.rcx }, FunctionAttribute.Register.rax, false)]
        private unsafe delegate FLinearColor* UCmpRootDraw_DrawMenuItems_SetColorsNoSel(byte opacity, FLinearColor* colorOut);
    }

    public class CampSkill : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string UCmpSkillDraw_DrawNoUsableSkillNoneGraphic_SIG = "41 B9 FF EF DB 00"; // UCmpSkillDraw::DrawUseSkillOptions
        private string UCmpSkillDraw_DrawNoUsableSkillDescription_SIG = "C7 45 ?? FF EF DB 00"; // UCmpSkillDraw::DrawUseSkillOptions
        private string UCmpSkillDraw_DrawPartyMemberHealSkillEntries_SIG = "BF FF FF FF 00 C7 44 24 ?? FF FF FF FF"; // UCmpSkillDraw::DrawPartyMemberHealSkillEntries
        private string UCmpSkillDraw_DrawPartyMemberHealSkillDesc_SIG = "81 CF 00 FF FF 00 44 8B CF"; // UCmpSkillDraw::DrawUseSkillOptions
        private string UCmpSkillDraw_DrawPartyMemberSkillHighlightedColor_SIG = "C6 45 ?? EE 0F 10 80 ?? ?? ?? ??";

        private IAsmHook _drawNoUsableSkillNoneGraphic;
        private IAsmHook _drawNoUsableSkillDescription;
        private IAsmHook _drawPartyMemberSkillHighlightedColor;

        private IReverseWrapper<UCmpSkillDraw_DrawNoUsableSkillNoneGraphic> _drawNoUsableSkillNoneGraphicWrapper;

        private UICommon _uiCommon;
        private CampCommon _campCommon;
        public unsafe CampSkill(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(UCmpSkillDraw_DrawNoUsableSkillNoneGraphic_SIG, "UCmpSkillDraw::DrawNoUsableSkillNoneGraphic", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UCmpSkillDraw_DrawNoUsableSkillNoneGraphicImpl, out _drawNoUsableSkillNoneGraphicWrapper)}",
                };
                _drawNoUsableSkillNoneGraphic = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteAfter).Activate();
            });
            /*
            _context._utils.SigScan(UCmpSkillDraw_DrawNoUsableSkillDescription_SIG, "UCmpSkillDraw::DrawNoUsableSkillDescription", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rbp - 0x24], {_context._config.CampSkillTextColor.ToU32()}",
                };
                _drawNoUsableSkillDescription = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteAfter).Activate();
            });
            */
            _context._utils.SigScan(UCmpSkillDraw_DrawNoUsableSkillDescription_SIG, "UCmpSkillDraw::DrawNoUsableSkillDescription", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampSkillTextColor.ToU32())));
            });
            _context._utils.SigScan(UCmpSkillDraw_DrawPartyMemberHealSkillEntries_SIG, "UCmpSkillDraw::DrawPartyMemberHealSkillEntries", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampSkillTextColor.ToU32())));
            });
            _context._utils.SigScan(UCmpSkillDraw_DrawPartyMemberHealSkillDesc_SIG, "UCmpSkillDraw::DrawUseSkillOptions", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampSkillTextColor.ToU32())));
            });
            _context._utils.SigScan(UCmpSkillDraw_DrawPartyMemberSkillHighlightedColor_SIG, "UCmpSkillDraw::DrawPartyMemberSkillHighlightedColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp - 0x7a], ${_context._config.CampHighlightedLowerColor.R:X}",
                    $"mov byte [rbp - 0x7b], ${_context._config.CampHighlightedLowerColor.G:X}",
                    $"mov byte [rbp - 0x7c], ${_context._config.CampHighlightedLowerColor.B:X}"
                };
                _drawPartyMemberSkillHighlightedColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteAfter).Activate();
            });
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
            _campCommon = GetModule<CampCommon>();
        }
        private FSprColor UCmpSkillDraw_DrawNoUsableSkillNoneGraphicImpl() => ConfigColor.ToFSprColor(_context._config.CampSkillTextColor);

        [Function(new Register[] { }, FunctionAttribute.Register.r9, false)]
        private delegate FSprColor UCmpSkillDraw_DrawNoUsableSkillNoneGraphic();
    }

    public class CampItem : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string ACmpMainActor_SetHeroTexTintItemMenuTop_SIG = "BA FF A2 6B 17"; 
        private string ACmpMainActor_SetHeroTexTintItemMenuBottom_SIG = "BA FF 5F 16 01";
        private string UCmpItemDraw_SetNoItemColor_SIG = "41 81 CC 00 EF DB 00";
        private string UCmpItemDraw_ListTextNoSelect_SIG = "81 CB 00 EA C2 08 F3 0F 10 35 ?? ?? ?? ??";
        private string UCmpItemDraw_ListTextCanSelect_SIG = "81 CB 00 FF FF 00";
        private string UCmpItemDraw_ListTextCurrNoSel_SIG = "81 CB 00 53 53 53";
        private string UCmpItemDraw_ItemDescriptionColor_SIG = "41 81 CF 00 FF FF 00 89 5C 24 ??";
        private string UCmpItemDraw_ItemDescriptionColor_SIG_EpAigis = "41 81 CD 00 FF FF 00 89 7C 24 ??";
        private string UCmpItemDraw_DrawHighlightedItem1_SIG = "C7 44 24 ?? 00 00 EE FF 0F 11 48 ??";
        private string UCmpItemDraw_DrawHighlightedItem2_SIG = "C7 44 24 ?? 00 00 EE FF 41 0F 10 4D ??";
        private string UCmpItemDraw_DrawHighlightedArrows_SIG = "41 BC FF 00 00 FF E8 ?? ?? ?? ??";
        private string UCmpItemDraw_DrawHighlightedPartyMember1_SIG = "81 C9 00 00 00 6A";
        private string UCmpItemDraw_DrawHighlightedPartyMember2_SIG = "0D 00 00 00 EE 41 0F 28 C1";
        private string UCmpItemDraw_DrawSkillCardFemcShadow_SIG = "41 81 C9 00 21 0D 08";
        private string UCmpItemDraw_DrawSkillCardBackground_SIG = "0D 00 78 6C 68";
        private string UCmpItemDraw_DrawSkillCardFrame_SIG = "0D 00 65 42 35";

        private string UCmpItemDraw_EquipmentEffectBGColor_SIG = "41 81 C9 00 FF FC 00";
        private string UCmpItemDraw_EquipmentEffectFontColor_SIG = "41 81 C9 00 4E 2B 01";
        private string UCmpItemDraw_EquipmentDescriptionFont_SIG = "41 81 CD 00 FF FF 00 66 89 44 24 ??";
        private string UCmpItemDraw_EquipmentNoEffectBGAndFontColor_SIG = "0D 00 FF FC 00 F3 44 0F 11 54 24 ??";

        private UICommon _uiCommon;
        private CampCommon _campCommon;
        public unsafe CampItem(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            if (_context.bIsAigis)
            {              
                _context._utils.SigScan(UCmpItemDraw_ItemDescriptionColor_SIG_EpAigis, "UCmpItemDraw::ItemDescriptionColor", _context._utils.GetDirectAddress, addr =>
                {
                    _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampSkillTextColor.ToU32())));
                });
            } else
            {
                _context._utils.SigScan(UCmpItemDraw_ItemDescriptionColor_SIG, "UCmpItemDraw::ItemDescriptionColor", _context._utils.GetDirectAddress, addr =>
                {
                    _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampSkillTextColor.ToU32())));
                });
            }
            _context._utils.SigScan(ACmpMainActor_SetHeroTexTintItemMenuTop_SIG, "ACmpMainActor::SetHeroTexTintItemMenuTop", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampItemMenuCharacterTopColor.ToU32())));
            });
            _context._utils.SigScan(ACmpMainActor_SetHeroTexTintItemMenuBottom_SIG, "ACmpMainActor::SetHeroTexTintItemMenuBottom", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampItemMenuCharacterBottomColor.ToU32())));
            });
            _context._utils.SigScan(UCmpItemDraw_SetNoItemColor_SIG, "UCmpItemDraw::SetNoItemColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampSkillTextColor.ToU32())));
            });
            _context._utils.SigScan(UCmpItemDraw_ListTextCanSelect_SIG, "UCmpSkillDraw::ListTextCanSelect", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampSkillTextColor.ToU32())));
            });
            _context._utils.SigScan(UCmpItemDraw_ListTextNoSelect_SIG, "UCmpItemDraw::ListTextNoSelect", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampSkillTextColorNoSel.ToU32())));
            });
            _context._utils.SigScan(UCmpItemDraw_ListTextCurrNoSel_SIG, "UCmpItemDraw::ListTextCurrSelected", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampSkillTextColorCurrSel.ToU32())));
            });
            _context._utils.SigScan(UCmpItemDraw_DrawHighlightedItem1_SIG, "UCmpItemDraw::DrawHighlightedItem1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CampHighlightedLowerColor.ToU32ARGB())));
            });
            _context._utils.SigScan(UCmpItemDraw_DrawHighlightedItem2_SIG, "UCmpItemDraw::DrawHighlightedItem2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CampHighlightedLowerColor.ToU32ARGB())));
            });
            _context._utils.SigScan(UCmpItemDraw_DrawHighlightedArrows_SIG, "UCmpItemDraw::DrawHighlightedArrows", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampHighlightedColor.ToU32())));
            });
            _context._utils.SigScan(UCmpItemDraw_DrawHighlightedPartyMember1_SIG, "UCmpItemDraw::DrawHighlightedPartyMember1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampHighlightedMidColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpItemDraw_DrawHighlightedPartyMember2_SIG, "UCmpItemDraw::DrawHighlightedPartyMember2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampHighlightedLowerColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpItemDraw_DrawSkillCardFemcShadow_SIG, "UCmpItemDraw::DrawSkillCardFemcShadow", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampSkillCardFemc.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpItemDraw_DrawSkillCardBackground_SIG, "UCmpItemDraw::DrawSkillCardBackground", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampSkillCardBackground.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpItemDraw_DrawSkillCardFrame_SIG, "UCmpItemDraw::DrawSkillCardFrame", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampSkillCardFrame.ToU32IgnoreAlpha())));
            });

            _context._utils.SigScan(UCmpItemDraw_EquipmentEffectBGColor_SIG, "UCmpItemDraw::EquipmentEffectBGColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampItemEffectBG.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpItemDraw_EquipmentEffectFontColor_SIG, "UCmpItemDraw::EquipmentEffectFontColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampItemEffectFont.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpItemDraw_EquipmentDescriptionFont_SIG, "UCmpItemDraw::EquipmentDescriptionFont", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampSkillTextColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpItemDraw_EquipmentNoEffectBGAndFontColor_SIG, "UCmpItemDraw::EquipmentNoEffectBGAndFontColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampSkillTextColor.ToU32IgnoreAlpha())));
            });
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
            _campCommon = GetModule<CampCommon>();
        }
    }

    public class CampEquip : ModuleAsmInlineColorEdit<FemcContext>
    {
        private UICommon _uiCommon;
        private CampCommon _campCommon;

        private string UCmpEquipDraw_DrawOverviewListTypeBg_SIG = "0D 00 5C 20 0C";
        private string UCmpEquipDraw_DrawOverviewListTypeText_SIG = "0D 00 F5 C9 79 F3 44 0F 11 5C 24 ??";
        private string UCmpEquipDraw_DrawOverviewListTypeText_SIG_EpAigis = "0D 00 F5 C9 79 F3 44 0F 11 64 24 ??";
        private MultiSignature _drawOverviewListTypeTextMS;
        private string UCmpEquipDraw_DrawEquipText_Unsel_SIG = "81 CB 00 FF FC 00 E8 ?? ?? ?? ??";
        private string UCmpEquipDraw_DrawEquipItemStat_Unsel_SIG = "41 81 CA 00 FF FC 00";
        private string UCmpEquipDraw_DrawEqupItemStatNum_Light1_SIG = "0D 00 FF FC 00 BF 00 80 80 80";
        private string UCmpEquipDraw_DrawEquipItemStatsNum_SIG = "48 8B C4 57 41 54 41 56 41 57 48 81 EC C8 00 00 00";
        private string UCmpEquipDraw_DrawItemsDescText_SIG = "81 CF 00 FF FC 00";
        private string UCmpEquipDraw_DrawItemListEntryName_SIG = "0D 00 FF FC 00 80 BC 24 ?? ?? ?? ?? 00";
        private string UCmpEquipDraw_DrawDetailsTypeBg_SIG = "81 CF 00 5C 20 0C";
        private string UCmpEquipDraw_DrawDetailsTypeBg_SIG_EpAigis = "81 CD 00 5C 20 0C";
        private MultiSignature _drawDetailsTypeBgMS;
        private string UCmpEquipDraw_DrawDetailsTypeText_SIG = "81 CB 00 F5 C9 79 E8 ?? ?? ?? ?? 49 8B 8D ?? ?? ?? ?? BA 16 00 00 00 E8 ?? ?? ?? ?? 48 8B 4D ?? F3 41 0F 58 FF C6 44 24 ?? 01 F3 41 0F 5C F4 44 89 64 24 ?? 45 8B C7";
        private string UCmpEquipDraw_DrawDetailsTypeText_SIG_EpAigis = "81 CB 00 F5 C9 79 E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? BA 16 00 00 00 E8 ?? ?? ?? ?? 48 8B 4D ?? F3 41 0F 58 FF C6 44 24 ?? 01 F3 41 0F 5C F3 89 7C 24 ?? 45 8B C5";
        private MultiSignature _drawDetailsTypeTextMS;
        private string UCmpEquipDraw_DrawSquareBackground_SIG = "BA FF 5C 20 0C";
        private string UCmpEquipDraw_DrawEquipTitleBackground_SIG = "C7 44 24 ?? FF 45 16 0C";
        private string UCmpEquipDraw_DrawEquipDescriptionEffectBg_SIG = "41 81 CC 00 4E 2B 01";

        private string UCmpEquipDraw_DrawHighlightedArrows_SIG = "81 CD 00 00 00 EE";
        private string UCmpEquipDraw_DrawHighlightedPartyMember1_SIG = "81 CB 00 00 00 6A EB ??";
        private string UCmpEquipDraw_DrawHighlightedPartyMember2_SIG = "81 CF 00 00 00 EE C7 44 24 ?? 15 00 00 00";
        private string UCmpEquipDraw_DrawHighlightedEquipment_SIG = "0D 00 00 00 FF 0F 28 0D ?? ?? ?? ??";
        private string UCmpEquipDraw_DrawHighlightedEquipmentElement_SIG = "0D 00 00 00 FF 0F 11 89 ?? ?? ?? ??";
        private string UCmpEquipDraw_DrawHighlightedEquipmentCompareAnim_SIG = "0D 00 00 00 FF 0F 57 C0";
        private string UCmpEquipDraw_DrawHighlightedEquipmentCompare_SIG = "0D 00 00 00 FF F3 44 0F 11 7C 24 ??";

        private string UCmpEquipCompare_DrawCircleShadow_SIG = "E8 ?? ?? ?? ?? C7 44 24 ?? 80 00 00 00 44 8B C8 89 6C 24 ?? 0F 57 D2 0F 28 CF F3 44 0F 11 4C 24 ??";
        private string UCmpEquipCompare_DrawCircle_SIG = "E8 ?? ?? ?? ?? C7 44 24 ?? 80 00 00 00 44 8B C8 89 6C 24 ?? 0F 57 D2 0F 28 CF F3 0F 11 74 24 ??";
        private string UCmpEquipCompare_DrawCircleFemcShadow_SIG = "E8 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? 8B D8 E8 ?? ?? ?? ?? 0F B6 0D ?? ?? ?? ??";
        private string UCmpEquipCompare_DrawArrowUp_SIG = "0D 00 29 00 EA 33 D2";
        private string UCmpEquipCompare_DrawArrowDown_SIG = "0D 00 29 00 EA F3 0F 11 7C 24 ??";
        private string UCmpEquip_DotStatsSeparator1_SIG = "81 CD 00 90 46 36 40 84 F6";
        private string UCmpEquip_DotStatsSeparator2_SIG = "81 CD 00 90 46 36 45 0F 57 C0";

        private string UCmpEquip_PartyMemberUnavailableParallelogram_SIG = "41 81 CC 00 79 38 1A";
        private string UCmpEquip_PartyMemberUnavailableFontSelected_SIG = "0D 00 79 38 1A 84 C9";

        private IHook<UCmpEquipDraw_DrawEquipItemStatsNum> _drawStatsNum;

        private IAsmHook _DrawCircleShadow;
        private IAsmHook _DrawCircle;
        private IAsmHook _DrawCircleFemcShadow;

        public unsafe CampEquip(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _drawOverviewListTypeTextMS = new MultiSignature();
            _context._utils.MultiSigScan(
                new string[] { UCmpEquipDraw_DrawDetailsTypeBg_SIG, UCmpEquipDraw_DrawDetailsTypeBg_SIG_EpAigis },
                "UCmpEquipDraw::DrawDetailsListTypeBg", _context._utils.GetDirectAddress,
                addr => _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampSocialLinkDark.ToU32IgnoreAlpha()))),
                _drawOverviewListTypeTextMS
            );
            _drawDetailsTypeBgMS = new MultiSignature();
            _context._utils.MultiSigScan(
                new string[] { UCmpEquipDraw_DrawOverviewListTypeText_SIG, UCmpEquipDraw_DrawOverviewListTypeText_SIG_EpAigis },
                "UCmpEquipDraw::DrawOverviewListTypeText", _context._utils.GetDirectAddress,
                addr => _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampEquipOverviewListType.ToU32IgnoreAlpha()))),
                _drawDetailsTypeBgMS
            );
            _drawDetailsTypeTextMS = new MultiSignature();
            _context._utils.MultiSigScan(
                new string[] { UCmpEquipDraw_DrawDetailsTypeText_SIG, UCmpEquipDraw_DrawDetailsTypeText_SIG_EpAigis },
                "UCmpEquipDraw::DrawOverviewListTypeText", _context._utils.GetDirectAddress,
                addr => _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampEquipOverviewListType.ToU32IgnoreAlpha()))),
                _drawDetailsTypeTextMS
            );

            // UCmpEquipDraw::DrawEqiuppedEquipment
            _context._utils.SigScan(UCmpEquipDraw_DrawOverviewListTypeBg_SIG, "UCmpEquipDraw::DrawOverviewListTypeBg", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampSocialLinkDark.ToU32IgnoreAlpha())));
            });
            // UCmpEquipDraw::DrawUnselectedEquipText
            _context._utils.SigScan(UCmpEquipDraw_DrawEquipText_Unsel_SIG, "UCmpEquipDraw::DrawEquipText", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampSkillTextColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpEquipDraw_DrawEquipItemStat_Unsel_SIG, "UCmpEquipDraw::DrawEquipItemStat", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampSkillTextColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpEquipDraw_DrawEquipItemStatsNum_SIG, "UCmpEquipDraw::DrawEquipItemStatsNum", _context._utils.GetDirectAddress, addr => _drawStatsNum = _context._utils.MakeHooker<UCmpEquipDraw_DrawEquipItemStatsNum>(UCmpEquipDraw_DrawEquipItemStatsNumImpl, addr));
            _context._utils.SigScan(UCmpEquipDraw_DrawItemsDescText_SIG, "UCmpEquipDraw::DrawItemsDescText", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampSkillTextColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpEquipDraw_DrawItemListEntryName_SIG, "UCmpEquipDraw::DrawItemListEntryName", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampItemStatValueValColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpEquipDraw_DrawSquareBackground_SIG, "UCmpEquipDraw::DrawSquareBackground", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.EquipSquareBack.ToU32())));
            });
            _context._utils.SigScan(UCmpEquipDraw_DrawEquipTitleBackground_SIG, "UCmpEquipDraw::DrawEquipTitleBackground", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.EquipTitleBackground.ToU32())));
            });
            _context._utils.SigScan(UCmpEquipDraw_DrawHighlightedArrows_SIG, "UCmpEquipDraw::DrawHighlightedArrows", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampHighlightedLowerColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpEquipDraw_DrawHighlightedPartyMember1_SIG, "UCmpEquipDraw::DrawHighlightedPartyMember1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampHighlightedMidColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpEquipDraw_DrawHighlightedPartyMember2_SIG, "UCmpEquipDraw::DrawHighlightedPartyMember2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampHighlightedLowerColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpEquipDraw_DrawHighlightedEquipment_SIG, "UCmpEquipDraw::DrawHighlightedEquipment", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampHighlightedColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpEquipDraw_DrawHighlightedEquipmentElement_SIG, "UCmpEquipDraw::DrawHighlightedEquipmentElement", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampHighlightedColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpEquipDraw_DrawHighlightedEquipmentCompareAnim_SIG, "UCmpEquipDraw::DrawHighlightedEquipmentCompareAnim", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampHighlightedColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpEquipDraw_DrawHighlightedEquipmentCompare_SIG, "UCmpEquipDraw::DrawHighlightedEquipmentCompare", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampHighlightedColor.ToU32IgnoreAlpha())));
            });

            _context._utils.SigScan(UCmpEquipDraw_DrawEquipDescriptionEffectBg_SIG, "UCmpEquipDraw::DrawEquipDescriptionEffectBg", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.EquipEffectColor.ToU32IgnoreAlpha())));
            });

            _context._utils.SigScan(UCmpEquipCompare_DrawCircleShadow_SIG, "UCmpEquipCompare::DrawCircleShadow", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r9b, ${_context._config.CampEquipCompareCircle.B:X}",
                    $"mov r8b, ${_context._config.CampEquipCompareCircle.G:X}",
                    $"mov dl, ${_context._config.CampEquipCompareCircle.R:X}"
                };
                _DrawCircleShadow = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpEquipCompare_DrawCircle_SIG, "UCmpEquipCompare::DrawCircle", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r9b, ${_context._config.CampEquipCompareCircle.B:X}",
                    $"mov r8b, ${_context._config.CampEquipCompareCircle.G:X}",
                    $"mov dl, ${_context._config.CampEquipCompareCircle.R:X}"
                };
                _DrawCircle = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpEquipCompare_DrawCircleFemcShadow_SIG, "UCmpEquipCompare::DrawCircleFemcShadow", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r9b, ${_context._config.CampEquipCompareFemcShadowCircle.B:X}",
                    $"mov r8b, ${_context._config.CampEquipCompareFemcShadowCircle.G:X}",
                    $"mov dl, ${_context._config.CampEquipCompareFemcShadowCircle.R:X}"
                };
                _DrawCircleFemcShadow = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpEquipCompare_DrawArrowUp_SIG, "UCmpEquipCompare::DrawArrowUp", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.HighlightedUpDownArrows.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpEquipCompare_DrawArrowDown_SIG, "UCmpEquipCompare::DrawArrowDown", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.HighlightedUpDownArrows.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpEquip_DotStatsSeparator1_SIG, "UCmpEquip::DotStatsSeparator1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.EquipDotsColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpEquip_DotStatsSeparator2_SIG, "UCmpEquip::DotStatsSeparator2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.EquipDotsColor.ToU32IgnoreAlpha())));
            });

            _context._utils.SigScan(UCmpEquip_PartyMemberUnavailableParallelogram_SIG, "UCmpEquipDraw::PartyMemberUnavailableParallelogram", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.EquipPMUnavailableColor.ToU32IgnoreAlpha())));
            });
            /*
            _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.EquipPMUnavailableParallelogram.ToU32IgnoreAlpha())));
             */
            _context._utils.SigScan(UCmpEquip_PartyMemberUnavailableFontSelected_SIG, "UCmpEquipDraw::PartyMemberUnavailableFontSelected", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.EquipPMUnavailableColor.ToU32IgnoreAlpha())));
            });
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
            _campCommon = GetModule<CampCommon>();
        }

        private unsafe void UCmpEquipDraw_DrawEquipItemStatsNumImpl(UCmpEquipDraw* self, int queueId, uint num, char selected, float X, float Y, int menuType, FSprColor baseColor, char a9, char a10)
        {
            var campSpr = (USprAsset*)_uiCommon._globalWorkGetUIResources()->GetAssetEntry(0x32);
            if (num > 999) num = 999;
            var midGray = new FSprColor(0x80, 0x80, 0x80, baseColor.A);
            var black = new FSprColor(0, 0, 0, baseColor.A);
            var white = new FSprColor(0xff, 0xff, 0xff, baseColor.A);
            var padColor = ConfigColor.ToFSprColorWithAlpha(_context._config.CampItemStatValuePadColor, baseColor.A);
            var valColor = ConfigColor.ToFSprColorWithAlpha(_context._config.CampItemStatValueValColor, baseColor.A);
            var size = menuType == 0 ? 1f : 0.8f;
            var valueColor = menuType switch // 0*90*
            {
                0 or 2 => a10 == 0 ? valColor : black,
                _ => white,
            };
            var paddingColor = menuType switch // *0*90
            {
                0 or 2 => a10 == 0 ? padColor : midGray,
                _ => midGray,
            };
            var pos = new FVector2D(
                X + menuType switch { 0 => 89, 1 => 100, 2 => 82, _ => 0 },
                Y + menuType switch { 0 => -24, 1 => 66, 2 => 2, _ => 0 }
            );
            var activeColor = valueColor;
            if (a10 == 0) _uiCommon._drawSprDetailedParams(campSpr, 0, num % 10 + 0x78, pos.X, pos.Y, 0, activeColor, queueId, 0, size, size, 4, 1);
            pos.X -= menuType == 0 ? 29 : 23;
            if (num < 10) activeColor = paddingColor;
            if (a10 == 0 || num < 10) _uiCommon._drawSprDetailedParams(campSpr, 0, (num / 10) % 10 + 0x78, pos.X, pos.Y, 0, activeColor, queueId, 0, size, size, 4, 1);
            pos.X -= menuType == 0 ? 29 : 23;
            if (num < 100) activeColor = paddingColor;
            if (a10 == 0 || num < 100) _uiCommon._drawSprDetailedParams(campSpr, 0, (num / 100) % 10 + 0x78, pos.X, pos.Y, 0, activeColor, queueId, 0, size, size, 4, 1);
        }

        private unsafe delegate void UCmpEquipDraw_DrawEquipItemStatsNum(UCmpEquipDraw* self, int queueId, uint num, char a4, float X, float Y, int menuType, FSprColor baseColor, char a9, char a10);
    }

    public class CampPersona : ModuleAsmInlineColorEdit<FemcContext>
    {

        private UICommon _uiCommon;
        private CampCommon _campCommon;

        // UCmpPersona::DrawPersonaStockList
        private string UCmpPersona_DrawCatchphraseColor_SIG = "E8 ?? ?? ?? ?? 4C 8D 44 24 ?? 48 8B CB 48 8B 10 E8 ?? ?? ?? ?? F3 0F 10 77 ??";

        private string UCmpPersona_SelArcanaBgColor_SIG = "E8 ?? ?? ?? ?? 48 8B 45 ?? 48 8D 8D ?? ?? ?? ?? 4C 89 7C 24 ?? 0F 28 D6 66 C7 45 ?? 74 0C";
        private string UCmpPersona_SelArcanaTextColor_SIG = "44 89 74 24 ?? 89 44 24 ?? E8 ?? ?? ?? ?? 66 89 75 ??";
        private string UCmpPersona_UnselArcanaBgColor_SIG = "E8 ?? ?? ?? ?? 48 8B 45 ?? 48 8D 8D ?? ?? ?? ?? 4C 89 7C 24 ?? 0F 28 D6 66 C7 44 24 ?? FF FF";
        private string UCmpPersona_UnselArcanaTextColor_SIG = "44 89 74 24 ?? 89 44 24 ?? E8 ?? ?? ?? ?? 41 0F 28 C9";
        private string UCmpPersona_PersonaNameColor_SIG = "48 8B 85 ?? ?? ?? ?? 48 8D 8D ?? ?? ?? ?? 48 89 44 24 ?? 0F 28 D6 48 8D 45 ?? 4C 89 7C 24 ?? 48 89 44 24 ?? 44 89 74 24 ??";
        private string UCmpPersona_BlankSlotColor_SIG = "41 81 C9 00 FF FF 00";

        private string UCmpPersona_PersonaNameColorTrans_SIG = "F3 0F 5C CE F3 41 0F 59 D2";
        private string UCmpPersona_UnselArcanaBgColorTrans_SIG = "41 81 C9 00 44 0B 00";
        private string UCmpPersona_BlankSlotColorTrans_SIG = "41 0F 28 C4 C6 44 24 ?? 01";
        private string UCmpPersona_BlankSlotColorTrans_SIG_EpAigis = "41 0F 28 C3 C6 44 24 ?? 01 F3 0F 58 C6";
        private MultiSignature _blankSlotColorTransMS;
        private string UCmpPersona_UnselArcanaBgTextTrans_SIG = "83 C3 5E C6 44 24 ?? 01 41 0F 28 C9";
        private string UCmpPersona_SelArcanaBgColorTrans_SIG = "0D 00 FF FF 00 0F 11 81 ?? ?? ?? ??";
        private string UCmpPersona_SelArcanaBgTextTrans_SIG = "0D 00 74 0C 00";
        private string UCmpPersona_HighlightedPersonaColor1_SIG = "0D 00 00 00 EE F3 44 0F 11 64 24 ??";
        private string UCmpPersona_HighlightedPersonaColor2_SIG = "0D 00 00 00 EE 89 44 24 ??";

        private IAsmHook _phraseColor;
        private IAsmHook _nameColor;
        private IAsmHook _selArcanaBgColor;
        private IAsmHook _selArcanaTextColor;
        private IAsmHook _unselArcanaBgColor;
        private IAsmHook _unselArcanaTextColor;

        private IAsmHook _nameColorTrans;
        private IAsmHook _blankSlotTrans;
        private IAsmHook _unselArcanaTextColorTrans;

        private IReverseWrapper<UCmpPersona_InjectColorR9> _nameColorWrapper;
        private IReverseWrapper<UCmpPersona_InjectColorR9> _selArcanaBgColorWrapper;
        private IReverseWrapper<UCmpPersona_InjectColorRAX> _selArcanaTextColorWrapper;
        private IReverseWrapper<UCmpPersona_InjectColorR9> _unselArcanaBgColorWrapper;
        private IReverseWrapper<UCmpPersona_InjectColorRAX> _unselArcanaTextColorWrapper;

        private IReverseWrapper<UCmpPersona_InjectColorR9> _nameColorTransWrapper;
        private IReverseWrapper<UCmpPersona_InjectColorR9> _blankSlotTransWrapper;
        private IReverseWrapper<UCmpPersona_InjectColorR9PreserveRAX> _unselArcanaTextColorTransWrapper;

        public unsafe CampPersona(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(UCmpPersona_DrawCatchphraseColor_SIG, "UCmpPersona::DrawCatchphraseColor", _context._utils.GetDirectAddress, addr =>
            {
                FLinearColor colorOut = ConfigColor.ToFLinearColor(_context._config.CampPersonaArcanaPhraseColor);
                string[] function =
                {
                    "use64",
                    $"mov dword [rsp + 0x{GetCatchphraseColorOffset(0):X}], {BitConverter.SingleToUInt32Bits(colorOut.R)}",
                    $"mov dword [rsp + 0x{GetCatchphraseColorOffset(1):X}], {BitConverter.SingleToUInt32Bits(colorOut.G)}",
                    $"mov dword [rsp + 0x{GetCatchphraseColorOffset(2):X}], {BitConverter.SingleToUInt32Bits(colorOut.B)}",
                };
                _phraseColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpPersona_PersonaNameColor_SIG, "UCmpPersona::PersonaNameColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UCmpPersona_PersonaNameColorImpl, out _nameColorWrapper)}",
                };
                _nameColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpPersona_SelArcanaBgColor_SIG, "UCmpPersona::SelArcanaBgColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UCmpPersona_SelArcanaBgColorImpl, out _selArcanaBgColorWrapper)}",
                };
                _selArcanaBgColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpPersona_SelArcanaTextColor_SIG, "UCmpPersona::SelArcanaTextColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._utils.PreserveMicrosoftRegisters()}",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UCmpPersona_SelArcanaTextColorImpl, out _selArcanaTextColorWrapper)}",
                    $"{_context._utils.RetrieveMicrosoftRegisters()}",
                };
                _selArcanaTextColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpPersona_UnselArcanaBgColor_SIG, "UCmpPersona::UnselArcanaBgColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UCmpPersona_SelArcanaTextColorImpl, out _unselArcanaBgColorWrapper)}",
                };
                _unselArcanaBgColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpPersona_UnselArcanaTextColor_SIG, "UCmpPersona::UnselArcanaTextColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._utils.PreserveMicrosoftRegisters()}",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UCmpPersona_SelArcanaBgColorImpl, out _unselArcanaTextColorWrapper)}",
                    $"{_context._utils.RetrieveMicrosoftRegisters()}",
                };
                _unselArcanaTextColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpPersona_BlankSlotColor_SIG, "UCmpPersona::BlankSlotColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampPersonaNameColor.ToU32IgnoreAlpha())));
            });

            // Transition colors
            _context._utils.SigScan(UCmpPersona_PersonaNameColorTrans_SIG, "UCmpPersona::PersonaNameColorTrans", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UCmpPersona_PersonaNameColorImpl, out _nameColorTransWrapper)}",
                };
                _nameColorTrans = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpPersona_UnselArcanaBgColorTrans_SIG, "UCmpPersona::UnselArcanaBgColorTrans", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampPersonaArcanaBgColor.ToU32IgnoreAlpha())));
            });
            _blankSlotColorTransMS = new MultiSignature();
            _context._utils.MultiSigScan(
                new string[] { UCmpPersona_BlankSlotColorTrans_SIG, UCmpPersona_BlankSlotColorTrans_SIG_EpAigis },
                "UCmpPersona::BlankSlotColorTrans", _context._utils.GetDirectAddress,
                addr =>
                {
                    string[] function =
                    {
                        "use64",
                        $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UCmpPersona_BlankSlotTransImpl, out _blankSlotTransWrapper)}",
                    };
                    _blankSlotTrans = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
                },
                _blankSlotColorTransMS
            );
            _context._utils.SigScan(UCmpPersona_UnselArcanaBgTextTrans_SIG, "UCmpPersona::UnselArcanaBgTextTrans", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UCmpPersona_BlankSlotTransImpl, out _unselArcanaTextColorTransWrapper)}",
                };
                _unselArcanaTextColorTrans = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpPersona_SelArcanaBgTextTrans_SIG, "UCmpPersona::SelArcanaBgTextTrans", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampPersonaArcanaBgColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpPersona_SelArcanaBgColorTrans_SIG, "UCmpPersona::SelArcanaBgColorTrans", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampPersonaNameColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpPersona_HighlightedPersonaColor1_SIG, "UCmpPersona::HighlightedPersonaColor1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampHighlightedLowerColor.ToU32())));
            });
            _context._utils.SigScan(UCmpPersona_HighlightedPersonaColor2_SIG, "UCmpPersona::HighlightedPersonaColor2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampHighlightedLowerColor.ToU32())));
            });
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
            _campCommon = GetModule<CampCommon>();
        }
        private unsafe FColor UCmpPersona_BlankSlotTransImpl(FColor source) => ConfigColor.ToFColor(_context._config.CampPersonaNameColor);
        private unsafe FColor UCmpPersona_SelArcanaTextColorImpl(FColor source) => ConfigColor.ToFColorBPWithAlpha(_context._config.CampPersonaArcanaBgColor, source.A);
        private unsafe FColor UCmpPersona_SelArcanaBgColorImpl(FColor source) => ConfigColor.ToFColorBPWithAlpha(_context._config.CampPersonaNameColor, source.A);
        private unsafe FColor UCmpPersona_PersonaNameColorImpl(FColor source)
        {
            if (source.B != 0) return ConfigColor.ToFColorBPWithAlpha(_context._config.CampPersonaNameColor, source.A);
            return source;
        }

        public unsafe int GetCatchphraseColorOffset(int comp) => _context.bIsAigis ? 0x60 + comp * sizeof(float) : 0x40 + comp * sizeof(float);

        [Function(FunctionAttribute.Register.r9, FunctionAttribute.Register.r9, false)]
        public unsafe delegate FColor UCmpPersona_InjectColorR9(FColor source);
        // normal r9 delegates crashes bc rax is replaced, which is used as a pointer deref later
        [Function(FunctionAttribute.Register.r9, FunctionAttribute.Register.r9, false, new Register[] { FunctionAttribute.Register.rax })] 
        public unsafe delegate FColor UCmpPersona_InjectColorR9PreserveRAX(FColor source);
        [Function(FunctionAttribute.Register.rax, FunctionAttribute.Register.rax, false)]
        public unsafe delegate FColor UCmpPersona_InjectColorRAX(FColor source);
    }

    public class CampStats : ModuleAsmInlineColorEdit<FemcContext>
    {
        private UICommon _uiCommon;
        private CampCommon _campCommon;

        private string UCmpStatus_CampDrawCharacterListColorLine_SIG = "8B 8C ?? ?? ?? ?? ?? 48 8B 45 ?? 81 E1 00 FF FF FF"; // 0x145309df8
        // FUN_14129d350, 0x145309dd0
        private string UCmpStatus_CampDrawCharacterDetailsColorLine_SIG = "48 8D 05 ?? ?? ?? ?? 8B 04 ?? 48 83 C4 28";

        // Inactive party members in tartarus
        private string UCmpStatus_CharacterDetailsInactiveBackgroundTartarus_SIG = "41 81 CC 00 79 38 1A";
        private string UCmpStatus_CharacterDetailsInactiveBackgroundTartarus_SIG_EpAigis = "41 81 C9 00 79 38 1A";

        // this includes lv, hp, sp and health bar shadows
        private string UCmpStatus_CharacterDetailsInactiveSelectedParamUsedTartarus_SIG = "0D 00 79 38 1A 45 84 D2";
        private string UCmpStatus_CharacterDetailsInactiveSelectedParamUsedTartarus_SIG_EpAigis = "0D 00 79 38 1A 44 8B C1";

        private string UCmpStatus_CharacterDetailsInactiveSelectedParamUnusedTartarus_SIG = "B8 00 B3 73 4B 41 BB 00 CD CD CD";
        private string UCmpStatus_CharacterDetailsInactiveSelectedParamUnusedTartarus_SIG_EpAigis = "B8 00 B3 73 4B";
        private string UCmpStatus_CharacterDetailsInactiveSelectedNameTartarus_SIG = "0D 00 79 38 1A 45 8B CB";
        private string UCmpStatus_CharacterDetailsInactiveSelectedNameTartarus_SIG_EpAigis = "0D 00 79 38 1A 89 5D ??";
        private string UCmpStatus_CharacterDetailsInactiveSelectedHealthBarRemainingTartarus_SIG = "C7 45 ?? 00 B3 73 4B";
        private string UCmpStatus_CharacterDetailsInactiveSelectedLineTartarus_SIG = "0D 00 79 38 1A EB ??";
        private string UCmpStatus_CharacterDetailsInactiveSelectedHPLostLineTartarus_SIG = "41 B8 00 A6 62 3A";
        private string UCmpStatus_CharacterDetailsInactiveSelectedHPLostLineTartarus_SIG_EpAigis = "41 B9 00 B3 73 4B";

        private string UCmpStatus_CharacterDetailsInactiveUnselectedParamUsedTartarus_SIG = "41 81 C8 00 EC D4 C0";
        private string UCmpStatus_CharacterDetailsInactiveUnselectedParamUsedTartarus_SIG_EpAigis = "41 81 C9 00 EC D4 C0";
        private string UCmpStatus_CharacterDetailsInactiveUnselectedPlayerNameTartarus_SIG = "0D 00 EC D4 C0 41 81 CC 00 79 38 1A";
        private string UCmpStatus_CharacterDetailsInactiveUnselectedPlayerNameTartarus_SIG_EpAigis = "0D 00 EC D4 C0 45 8B CA";
        private string UCmpStatus_CharacterDetailsInactiveUnselectedLinesTartarus_SIG = "BA 00 EC D4 C0";
        private string UCmpStatus_CharacterDetailsInactiveUnselectedHealthBarRemainingTartarus_SIG = "41 B8 00 B3 73 4B";
        private string UCmpStatus_CharacterDetailsInactiveUnselectedHealthBarRemainingTartarus_SIG_EpAigis = "BA 00 B3 73 4B";
        private string UCmpStatus_CharacterDetailsInactiveUnselectedHealthBarShadow_SIG = "81 CB 00 79 38 1A";
        private string UCmpStatus_CharacterDetailsInactiveUnselectedHealthBarShadow_SIG_EpAigis = "0D 00 79 38 1A 44 89 4D ??";

        private string UCmpStatus_CharacterDetailsHPBarAndLineRemaining_SIG_EpAigis = "B9 00 EC D4 C0";

        private string UCmpStatus_DrawChangeTacticsHighlightedColor_SIG = "8B 05 ?? ?? ?? ?? 48 8D 8D ?? ?? ?? ?? F3 44 0F 10 2D ?? ?? ?? ??";
        private string UCmpStatus_DrawStatsHighlightedArrowsColor_SIG = "0D 00 00 00 EE 89 75 ??";
        private string UCmpStatus_DrawStatsGekkoukanDark_SIG = "BB FF 9C 84 7C";
        private string UCmpStatus_DrawStatsFontColor_SIG = "41 BC FF B5 B5 B4";
        private string UCmpStatus_DrawStatsShadowsColor1_SIG = "0B D7 E8 ?? ?? ?? ?? 44 8B C5 41 8D 54 24 ??";
        private string UCmpStatus_DrawStatsShadowsColor2_SIG = "0B D7 E8 ?? ?? ?? ?? 44 8B C5 BA 01 00 00 00";

        private string UCmpStatus_DrawStatusHighlightedArrowsColor_SIG = "41 81 CF 00 00 00 EE";
        private string UCmpStatus_DrawStatusHighlightedLineColor_SIG = "0D 00 00 00 FF F3 44 0F 11 5C 24 ??";
        private string UCmpStatus_DrawStatusBGUnderlay_SIG = "41 81 C8 00 40 08 01";
        private string UCmpStatus_DrawStatusDetailTitleAndGekkoukanDark_SIG = "BB FF 2B 20 1E";
        private string UCmpStatus_DrawStatusDetailBackground_SIG = "BF FF 46 3E 3D";
        private string UCmpStatus_DrawStatusBigShardGradation_SIG = "81 CB 00 87 7E 6F";
        private string UCmpStatus_DrawStatusDetailFemcBackground_SIG = "0B D8 E8 ?? ?? ?? ?? F3 0F 10 05 ?? ?? ?? ??";
        private string UCmpStatus_DrawTheurgyBGTag_SIG = "0D 00 4D 3E 34 C7 44 24 ?? 04 00 00 00";
        private string UCmpStatus_DrawPersonaBGTag_SIG = "0D 00 4D 3E 34 F3 0F 10 74 24 ??";
        private string UCmpStatus_DrawStatusBigShardBGTheurgy1_SIG = "81 CB 00 75 59 4D";
        private string UCmpStatus_DrawStatusBigShardBGTheurgy2_SIG = "C7 44 24 ?? 00 75 59 4D 89 5C 24 ?? C7 44 24 ?? 00 75 59 4D";
        private string UCmpStatus_DrawStatusBigShardBGTheurgy3_SIG = "C7 44 24 ?? 00 75 59 4D 89 5C 24 ?? E8 ?? ?? ?? ??";
        private string UCmpStatus_DrawStatsBGTag1_SIG = "E8 ?? ?? ?? ?? 89 45 ?? E8 ?? ?? ?? ?? 2C 04";
        private string UCmpStatus_DrawStatsBGTag2_SIG = "E8 ?? ?? ?? ?? F3 44 0F 10 A5 ?? ?? ?? ?? 48 8D 4D ??";
        private string UCmpStatus_DrawTheurgyDetailBG1_SIG = "E8 ?? ?? ?? ?? 0F 57 DB F3 0F 11 7D ?? 0F 57 D2 F3 44 0F 11 45 ?? 49 8B D7 89 45 ?? 48 8D 4D ?? 89 7D ?? E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ??";
        private string UCmpStatus_DrawTheurgyDetailBG2_SIG = "E8 ?? ?? ?? ?? 0F 57 DB F3 0F 11 7D ?? 0F 57 D2 F3 44 0F 11 45 ?? 49 8B D7 89 45 ?? 48 8D 4D ?? 89 7D ?? E8 ?? ?? ?? ?? 45 33 C0";
        private string UCmpStatus_DrawTheurgyDetailTitle1_SIG = "E8 ?? ?? ?? ?? F3 0F 10 05 ?? ?? ?? ?? 48 8D 4D ?? 4C 8B 86 ?? ?? ?? ??";
        private string UCmpStatus_DrawTheurgyDetailTitle2_SIG = "E8 ?? ?? ?? ?? 4C 8B 86 ?? ?? ?? ?? 48 8D 4D ?? 41 0F 28 DB";
        private string UCmpStatus_DrawTheurgyDetailTitle3_SIG = "E8 ?? ?? ?? ?? 83 BE ?? ?? ?? ?? 00 45 0F 28 FD";
        private string UCmpStatus_DrawStatusBigShardTransitionLight1_SIG = "0D 00 D8 D2 D1"; // 1 No alpha
        private string UCmpStatus_DrawStatusBigShardTransitionLight2_SIG = "C7 44 24 ?? FF D8 D2 D1"; // 4 Alpha
        private string UCmpStatus_DrawStatusBigShardTransitionDark_SIG = "C7 44 24 ?? FF C1 B3 B0"; // 4 Alpha

        private IAsmHook _DrawStatsShadowsColor1;
        private IAsmHook _DrawStatsShadowsColor2;
        private IAsmHook _DrawStatusDetailFemcBackground;
        private IAsmHook _DrawStatsBGTag1;
        private IAsmHook _DrawStatsBGTag2;
        private IAsmHook _DrawTheurgyDetailBG1;
        private IAsmHook _DrawTheurgyDetailBG2;
        private IAsmHook _DrawTheurgyDetailTitle1;
        private IAsmHook _DrawTheurgyDetailTitle2;
        private IAsmHook _DrawTheurgyDetailTitle3;

        public unsafe CampStats(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            // TODO: Add options to dehardcode status colors per character
            _context._utils.SigScan(UCmpStatus_CampDrawCharacterListColorLine_SIG, "UCmpStatus::CampDrawCharacterListColorLine", 
                offset => (nuint)(_context._baseAddress + *(int*)(_context._baseAddress + offset + 3)), 
                addr => *(FSprColor*)addr = ConfigColor.ToFSprColor(_context._config.CampStatusKotoneLineColor));
            _context._utils.SigScan(UCmpStatus_CampDrawCharacterDetailsColorLine_SIG, "UCmpStatus::CampDrawCharacterDetailsColorLine", _context._utils.GetIndirectAddressLong, addr =>
            {
                *(FSprColor*)addr = ConfigColor.ToFSprColor(_context._config.CampStatusKotoneLineColor);
            });
            if (_context.bIsAigis)
            {
                _context._utils.SigScan(UCmpStatus_CharacterDetailsInactiveBackgroundTartarus_SIG_EpAigis, "UCmpStatus::CharacterDetailsInactiveBackgroundTartarus", _context._utils.GetDirectAddress, addr =>
                {
                    _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr =>
                    _context._memory.Write(addr + 3, _context._config.CampStatusInactiveMemberBgTartarus.ToU32IgnoreAlpha())));
                });
                _context._utils.SigScan(UCmpStatus_CharacterDetailsInactiveUnselectedParamUsedTartarus_SIG_EpAigis, "UCmpStatus::CharacterDetailsInactiveUnselectedParamUsedTartarus", _context._utils.GetDirectAddress, addr =>
                {
                    _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr =>
                    _context._memory.Write(addr + 3, _context._config.CampStatusInactiveMemberDetailsPalePinkTartarus.ToU32IgnoreAlpha())));
                });
                _context._utils.SigScan(UCmpStatus_CharacterDetailsInactiveUnselectedHealthBarShadow_SIG_EpAigis, "UCmpStatus::CharacterDetailsInactiveUnselectedHealthBarShadow", _context._utils.GetDirectAddress, addr =>
                {
                    _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr =>
                    _context._memory.Write(addr + 1, _context._config.CampStatusInactiveMemberDetailsDarkPinkTartarus.ToU32IgnoreAlpha())));
                });
                _context._utils.SigScan(UCmpStatus_CharacterDetailsInactiveUnselectedPlayerNameTartarus_SIG_EpAigis, "UCmpStatus::CharacterDetailsInactiveUnselectedPlayerNameTartarus", _context._utils.GetDirectAddress, addr =>
                {
                    _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr =>
                    _context._memory.Write(addr + 1, _context._config.CampStatusInactiveMemberDetailsPalePinkTartarus.ToU32IgnoreAlpha())));
                });
                _context._utils.SigScan(UCmpStatus_CharacterDetailsHPBarAndLineRemaining_SIG_EpAigis, "UCmpStatus::CharacterDetailsInactiveUnselectedPlayerNameTartarus", _context._utils.GetDirectAddress, addr =>
                {
                    _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr =>
                    _context._memory.Write(addr + 1, _context._config.CampStatusInactiveMemberDetailsPalePinkTartarus.ToU32IgnoreAlpha())));
                });
            } else
            {
                _context._utils.SigScan(UCmpStatus_CharacterDetailsInactiveBackgroundTartarus_SIG, "UCmpStatus::CharacterDetailsInactiveBackgroundTartarus", _context._utils.GetDirectAddress, addr =>
                {
                    _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr =>
                    _context._memory.Write(addr + 3, _context._config.CampStatusInactiveMemberBgTartarus.ToU32IgnoreAlpha())));
                });
                _context._utils.SigScan(UCmpStatus_CharacterDetailsInactiveUnselectedParamUsedTartarus_SIG, "UCmpStatus::CharacterDetailsInactiveUnselectedParamUsedTartarus", _context._utils.GetDirectAddress, addr =>
                {
                    _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr =>
                    _context._memory.Write(addr + 3, _context._config.CampStatusInactiveMemberDetailsPalePinkTartarus.ToU32IgnoreAlpha())));
                });
                _context._utils.SigScan(UCmpStatus_CharacterDetailsInactiveUnselectedHealthBarShadow_SIG, "UCmpStatus::CharacterDetailsInactiveUnselectedHealthBarShadow", _context._utils.GetDirectAddress, addr =>
                {
                    _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr =>
                    _context._memory.Write(addr + 2, _context._config.CampStatusInactiveMemberDetailsDarkPinkTartarus.ToU32IgnoreAlpha())));
                });
                _context._utils.SigScan(UCmpStatus_CharacterDetailsInactiveUnselectedPlayerNameTartarus_SIG, "UCmpStatus::CharacterDetailsInactiveUnselectedPlayerNameTartarus", _context._utils.GetDirectAddress, addr =>
                {
                    _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr =>
                    _context._memory.Write(addr + 1, _context._config.CampStatusInactiveMemberDetailsPalePinkTartarus.ToU32IgnoreAlpha())));
                });
                _context._utils.SigScan(UCmpStatus_CharacterDetailsInactiveUnselectedLinesTartarus_SIG, "UCmpStatus::CharacterDetailsInactiveUnselectedLinesTartarus", _context._utils.GetDirectAddress, addr =>
                {
                    _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr =>
                    _context._memory.Write(addr + 1, _context._config.CampStatusInactiveMemberDetailsPalePinkTartarus.ToU32IgnoreAlpha())));
                });
            }

            _context._utils.SigScan(
                _context.bIsAigis ? UCmpStatus_CharacterDetailsInactiveSelectedParamUsedTartarus_SIG_EpAigis : UCmpStatus_CharacterDetailsInactiveSelectedParamUsedTartarus_SIG, 
                "UCmpStatus::CharacterDetailsInactiveSelectedParamUsedTartarus", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr =>
                _context._memory.Write(addr + 1, _context._config.CampStatusInactiveMemberDetailsDarkPinkTartarus.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(
                _context.bIsAigis ? UCmpStatus_CharacterDetailsInactiveSelectedParamUnusedTartarus_SIG_EpAigis : UCmpStatus_CharacterDetailsInactiveSelectedParamUnusedTartarus_SIG, 
                "UCmpStatus::CharacterDetailsInactiveSelectedParamUnusedTartarus", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr =>
                _context._memory.Write(addr + 1, _context._config.CampStatusInactiveMemberHPBarTartarus.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(
                _context.bIsAigis ? UCmpStatus_CharacterDetailsInactiveSelectedNameTartarus_SIG_EpAigis : UCmpStatus_CharacterDetailsInactiveSelectedNameTartarus_SIG, 
                "UCmpStatus::CharacterDetailsInactiveSelectedNameTartarus", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr =>
                _context._memory.Write(addr + 1, _context._config.CampStatusInactiveMemberDetailsDarkPinkTartarus.ToU32IgnoreAlpha())));
            });
            
            _context._utils.SigScan(UCmpStatus_CharacterDetailsInactiveSelectedLineTartarus_SIG, "UCmpStatus::CharacterDetailsInactiveSelectedLineTartarus", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr =>
                _context._memory.Write(addr + 1, _context._config.CampStatusInactiveMemberDetailsDarkPinkTartarus.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(
                _context.bIsAigis ? UCmpStatus_CharacterDetailsInactiveSelectedHPLostLineTartarus_SIG_EpAigis : UCmpStatus_CharacterDetailsInactiveSelectedHPLostLineTartarus_SIG, 
                "UCmpStatus::CharacterDetailsInactiveSelectedHPLostLineTartarus", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr =>
                _context._memory.Write(addr + 2, _context._config.CampStatusInactiveMemberHPBarTartarus.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(
                _context.bIsAigis ? UCmpStatus_CharacterDetailsInactiveUnselectedHealthBarRemainingTartarus_SIG_EpAigis : UCmpStatus_CharacterDetailsInactiveUnselectedHealthBarRemainingTartarus_SIG, 
                "UCmpStatus::CharacterDetailsInactiveUnselectedHealthBarRemainingTartarus", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr =>
                _context._memory.Write(addr + (nuint)(_context.bIsAigis ? 1 : 2), _context._config.CampStatusInactiveMemberHPBarTartarus.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpStatus_DrawChangeTacticsHighlightedColor_SIG, "UCmpStatus::DrawChangeTacticsHighlightedColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr, (byte)0xB8))); // mov eax, color
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampHighlightedColor.ToU32ARGB())));
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 5, (byte)0x90))); // nop extra space
            });
            _context._utils.SigScan(UCmpStatus_DrawStatsHighlightedArrowsColor_SIG, "UCmpStatus::DrawStatsHighlightedArrowsColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampHighlightedLowerColor.ToU32())));
            });
            _context._utils.SigScan(UCmpStatus_DrawStatsGekkoukanDark_SIG, "UCmpStatus::DrawStatsGekkoukanDark", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.StatsGekkoukanDark.ToU32())));
            });
            _context._utils.SigScan(UCmpStatus_DrawStatsFontColor_SIG, "UCmpStatus::DrawStatsFontColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.StatsFontColor.ToU32())));
            });
            _context._utils.SigScan(UCmpStatus_DrawStatsShadowsColor1_SIG, "UCmpStatus::DrawStatsShadowsColor1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov edx, 0x{_context._config.StatsShadowsColor.ToU32IgnoreAlpha():X8}"
                };
                _DrawStatsShadowsColor1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpStatus_DrawStatsShadowsColor2_SIG, "UCmpStatus::DrawStatsShadowsColor2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov edx, 0x{_context._config.StatsShadowsColor.ToU32IgnoreAlpha():X8}"
                };
                _DrawStatsShadowsColor2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(UCmpStatus_DrawStatusHighlightedArrowsColor_SIG, "UCmpStatus::DrawStatusHighlightedArrowsColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampHighlightedLowerColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpStatus_DrawStatusHighlightedLineColor_SIG, "UCmpStatus::DrawStatusHighlightedLineColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampHighlightedColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpStatus_DrawStatusBGUnderlay_SIG, "UCmpStatus::DrawStatusBGUnderlay", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampStatsMenuUnderlay.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpStatus_DrawStatusDetailTitleAndGekkoukanDark_SIG, "UCmpStatus::DrawStatusDetailTitleAndGekkoukanDark", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.StatusDetailTitleAndGekkoukanDark.ToU32())));
            });
            _context._utils.SigScan(UCmpStatus_DrawStatusDetailBackground_SIG, "UCmpStatus::DrawStatusDetailBackground", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.StatusDetailMainBackground.ToU32())));
            });
            _context._utils.SigScan(UCmpStatus_DrawStatusBigShardGradation_SIG, "UCmpStatus::DrawStatusBigShardGradation", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.StatusDetailBigShard.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpStatus_DrawStatusDetailFemcBackground_SIG, "UCmpStatus::DrawStatusDetailFemcBackground", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov ebx, 0x{_context._config.StatusDetailMainBackground.ToU32IgnoreAlpha():X8}"
                };
                _DrawStatusDetailFemcBackground = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpStatus_DrawStatusBigShardGradation_SIG, "UCmpStatus::DrawStatusBigShardGradation", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.StatusDetailBigShard.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpStatus_DrawTheurgyBGTag_SIG, "UCmpStatus::DrawTheurgyBGTag", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.StatusDetailTagColors.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpStatus_DrawPersonaBGTag_SIG, "UCmpStatus::DrawPersonaBGTag", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.StatusDetailTagColors.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpStatus_DrawStatusBigShardBGTheurgy1_SIG, "UCmpStatus::DrawStatusBigShardBGTheurgy1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.StatusTheurgyBigShard.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpStatus_DrawStatusBigShardBGTheurgy2_SIG, "UCmpStatus::DrawStatusBigShardBGTheurgy2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.StatusTheurgyBigShard.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpStatus_DrawStatusBigShardBGTheurgy3_SIG, "UCmpStatus::DrawStatusBigShardBGTheurgy3", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.StatusTheurgyBigShard.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpStatus_DrawStatsBGTag1_SIG, "UCmpStatus::DrawStatsBGTag1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.StatusDetailTagColors.B:X}",
                    $"mov dl, ${_context._config.StatusDetailTagColors.G:X}",
                    $"mov cl, ${_context._config.StatusDetailTagColors.R:X}"
                };
                _DrawStatsBGTag1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpStatus_DrawStatsBGTag2_SIG, "UCmpStatus::DrawStatsBGTag2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.StatusDetailTagColors.B:X}",
                    $"mov dl, ${_context._config.StatusDetailTagColors.G:X}",
                    $"mov cl, ${_context._config.StatusDetailTagColors.R:X}"
                };
                _DrawStatsBGTag2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpStatus_DrawTheurgyDetailBG1_SIG, "UCmpStatus::DrawTheurgyDetailBG1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.StatusTheurgyDetailBGColor.B:X}",
                    $"mov dl, ${_context._config.StatusTheurgyDetailBGColor.G:X}",
                    $"mov cl, ${_context._config.StatusTheurgyDetailBGColor.R:X}"
                };
                _DrawTheurgyDetailBG1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpStatus_DrawTheurgyDetailBG2_SIG, "UCmpStatus::DrawTheurgyDetailBG2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.StatusTheurgyDetailBGColor.B:X}",
                    $"mov dl, ${_context._config.StatusTheurgyDetailBGColor.G:X}",
                    $"mov cl, ${_context._config.StatusTheurgyDetailBGColor.R:X}"
                };
                _DrawTheurgyDetailBG2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpStatus_DrawTheurgyDetailTitle1_SIG, "UCmpStatus::DrawTheurgyDetailTitle1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.StatusTheurgyDetailTitlesFont.B:X}",
                    $"mov dl, ${_context._config.StatusTheurgyDetailTitlesFont.G:X}",
                    $"mov cl, ${_context._config.StatusTheurgyDetailTitlesFont.R:X}"
                };
                _DrawTheurgyDetailTitle1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpStatus_DrawTheurgyDetailTitle2_SIG, "UCmpStatus::DrawTheurgyDetailTitle2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.StatusTheurgyDetailTitlesFont.B:X}",
                    $"mov dl, ${_context._config.StatusTheurgyDetailTitlesFont.G:X}",
                    $"mov cl, ${_context._config.StatusTheurgyDetailTitlesFont.R:X}"
                };
                _DrawTheurgyDetailTitle2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpStatus_DrawTheurgyDetailTitle3_SIG, "UCmpStatus::DrawTheurgyDetailTitle3", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.StatusTheurgyDetailTitlesFont.B:X}",
                    $"mov dl, ${_context._config.StatusTheurgyDetailTitlesFont.G:X}",
                    $"mov cl, ${_context._config.StatusTheurgyDetailTitlesFont.R:X}"
                };
                _DrawTheurgyDetailTitle3 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpStatus_DrawStatusBigShardTransitionLight1_SIG, "UCmpStatus::DrawStatusBigShardTransitionLight1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.StatusDetailTransitionBGLight.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpStatus_DrawStatusBigShardTransitionLight2_SIG, "UCmpStatus::DrawStatusBigShardTransitionLight2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.StatusDetailTransitionBGLight.ToU32())));
            });
            _context._utils.SigScan(UCmpStatus_DrawStatusBigShardTransitionDark_SIG, "UCmpStatus::DrawStatusBigShardTransitionDark", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.StatusDetailTransitionBGDark.ToU32())));
            });
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
            _campCommon = GetModule<CampCommon>();
        }
    }

    public class CampQuest : ModuleBase<FemcContext>
    {
        private UICommon _uiCommon;
        private CampCommon _campCommon;

        private string AUIRequest_DetailCampMenuChairColor_SIG = "E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 41 0F 28 D8 C6 44 24 ?? 00 41 0F 28 D3 C6 44 24 ?? 01 BA 71 00 00 00 F3 44 0F 11 4C 24 ?? F3 44 0F 11 4C 24 ?? F3 44 0F 11 64 24 ?? 89 7C 24 ?? 48 89 5C 24 ?? 89 44 24 ?? F3 0F 11 7C 24 ?? E8 ?? ?? ?? ?? F3 0F 10 05 ?? ?? ?? ??";
        private string AUIRequest_DetailCampMenuChairAndKotone_SIG = "E8 ?? ?? ?? ?? C6 44 24 ?? 00 F3 0F 10 5D ??";
        private string AUIRequest_BackCampMenuChairAndKotone_SIG = "E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 41 0F 28 D8 C6 44 24 ?? 00 41 0F 28 D3 C6 44 24 ?? 01 BA 71 00 00 00 F3 44 0F 11 4C 24 ?? F3 44 0F 11 4C 24 ?? F3 44 0F 11 64 24 ?? 89 7C 24 ?? 48 89 5C 24 ?? 89 44 24 ?? F3 0F 11 7C 24 ?? E8 ?? ?? ?? ?? 48 8B BC 24 ?? ?? ?? ??";

        private string UCmpQuest_DrawQuestArrows1_SIG = "E8 ?? ?? ?? ?? 41 0F 28 C2 41 B1 FF";
        private string UCmpQuest_DrawQuestArrows2_SIG = "E8 ?? ?? ?? ?? F3 45 0F 10 86 ?? ?? ?? ?? 4C 8D 44 24 ??";

        private IAsmHook _DetailCampMenuChairColor;
        private IAsmHook _DetailCampMenuChairAndKotone;
        private IAsmHook _BackCampMenuChairAndKotone;
        private IAsmHook _DrawQuestArrows1;
        private IAsmHook _DrawQuestArrows2;

        public unsafe CampQuest(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
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

            _context._utils.SigScan(UCmpQuest_DrawQuestArrows1_SIG, "UCmpQuest::DrawQuestArrows1", _context._utils.GetDirectAddress, addr =>
            {
                int rBits = BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.R); // Original in t=0 -> #6A0000
                int gBits = BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.G);
                int bBits = BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.B);

                int rBitsDiff = BitConverter.SingleToInt32Bits(64.0f - (float) _context._config.CampHighlightedMidColor.R); // Original in t=1 -> #404040
                int gBitsDiff = BitConverter.SingleToInt32Bits(64.0f - (float) _context._config.CampHighlightedMidColor.G);
                int bBitsDiff = BitConverter.SingleToInt32Bits(64.0f - (float) _context._config.CampHighlightedMidColor.B);

                // xmm14 holds the t, so we interpolate each component from that value
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{rBitsDiff:X}", // Red interpolation
                    "movd xmm1, eax",
                    "mulss xmm1, xmm14",
                    $"mov eax, 0x{rBits:X}",
                    "movd xmm2, eax",
                    "addss xmm1, xmm2",
                    "cvttss2si eax, xmm1",

                    $"mov ecx, 0x{gBitsDiff:X}", // Green interpolation
                    "movd xmm1, ecx",
                    "mulss xmm1, xmm14",
                    $"mov ecx, 0x{gBits:X}",
                    "movd xmm2, ecx",
                    "addss xmm1, xmm2",
                    "cvttss2si ecx, xmm1",

                    $"mov r8d, 0x{bBitsDiff:X}", // Blue interpolation
                    "movd xmm1, r8d",
                    "mulss xmm1, xmm14",
                    $"mov r8d, 0x{bBits:X}",
                    "movd xmm2, r8d",
                    "addss xmm1, xmm2",
                    "cvttss2si r8d, xmm1",
                };
                _DrawQuestArrows1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpQuest_DrawQuestArrows2_SIG, "UCmpQuest::DrawQuestArrows2", _context._utils.GetDirectAddress, addr =>
            {
                int rBits = BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.R); // Original in t=0 -> #EE0000
                int gBits = BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.G);
                int bBits = BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.B);

                int rBitsDiff = BitConverter.SingleToInt32Bits(0.0f - (float)_context._config.CampHighlightedLowerColor.R); // Original in t=1 -> #000000
                int gBitsDiff = BitConverter.SingleToInt32Bits(0.0f - (float)_context._config.CampHighlightedLowerColor.G);
                int bBitsDiff = BitConverter.SingleToInt32Bits(0.0f - (float)_context._config.CampHighlightedLowerColor.B);

                // Again, xmm14 holds the t, so we interpolate each component from that value
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{rBitsDiff:X}", // Red interpolation
                    "movd xmm1, eax",
                    "mulss xmm1, xmm14",
                    $"mov eax, 0x{rBits:X}",
                    "movd xmm2, eax",
                    "addss xmm1, xmm2",
                    "cvttss2si eax, xmm1",

                    $"mov ecx, 0x{gBitsDiff:X}", // Green interpolation
                    "movd xmm1, ecx",
                    "mulss xmm1, xmm14",
                    $"mov ecx, 0x{gBits:X}",
                    "movd xmm2, ecx",
                    "addss xmm1, xmm2",
                    "cvttss2si ecx, xmm1",

                    $"mov r8d, 0x{bBitsDiff:X}", // Blue interpolation
                    "movd xmm1, r8d",
                    "mulss xmm1, xmm14",
                    $"mov r8d, 0x{bBits:X}",
                    "movd xmm2, r8d",
                    "addss xmm1, xmm2",
                    "cvttss2si r8d, xmm1",
                };
                _DrawQuestArrows1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
            _campCommon = GetModule<CampCommon>();
        }
    }

    public class CampSocialLink : ModuleAsmInlineColorEdit<FemcContext>
    {
        private UICommon _uiCommon;
        private CampCommon _campCommon;

        // UCmpCommuList::DrawSocialLinkList
        private string UCmpCommuList_DrawSocialLinkList_GetSocialLinkColorsLight_SIG = "B9 00 FF FF 72";
        private string UCmpCommuList_DrawSocialLinkList_GetSocialLinkColorsDark_SIG = "41 B8 00 54 0E 0E";

        // UCmpCommu::SocialLinkDetailsCharacterDetail
        //private string UCmpCommuDetails_CharDetailsNameTriangle_SIG = "8B 44 24 ?? 0F 14 C8 F3 0F 10 05 ?? ?? ?? ??";
        //private string UCmpCommuDetails_CharDetailsBg_SIG = "48 89 44 24 ?? E8 ?? ?? ?? ?? 33 D2 48 8D 4F ??";
        //private string UCmpCommuDetails_CharDetailsTextGraphic_SIG = "F3 0F 11 7C 24 ?? F3 44 0F 11 54 24 ?? E8 ?? ?? ?? ?? 49 8B CC";
        private string UCmpCommuDetails_CharDetailsNameTriangle_SIG = "C7 44 24 ?? FD 00 06 FF";
        private string UCmpCommuDetails_CharDetailsBg_SIG = "C7 44 24 ?? 58 01 00 FF";
        private string UCmpCommuDetails_CharDetailsTextGraphic_SIG = "C7 44 24 ?? FF F8 E2 0E";

        //private string UCmpCommuDetails_CharMultiListText_SIG = "41 0F 45 C0 F3 44 0F 11 4C 24 ??";
        private string UCmpCommuDetails_CharMultiListText_SIG = "41 B8 FF FD E2 08";
        private string UCmpCommuDetails_CharMultiListBg_SIG = "B9 FF 54 0E 0E F3 44 0F 11 4C 24 ??";
        private string UCmpCommuDetails_CharMultiScrollBg_SIG = "B9 FF 54 0E 0E 44 8B 7C 24 ??";

        // Also effects shuffle time card fall
        //private string ABtlShuffleMainBase_CardFallUpdateInner_SIG = "48 8B C4 48 89 58 ?? 55 56 57 41 54 41 55 41 56 41 57 48 8D A8 ?? ?? ?? ?? 48 81 EC 90 02 00 00 0F 28 2D ?? ?? ?? ??";
        private string ABtlShuffleMainBase_CardFallUpdateInner_SIG = "48 8B C4 44 89 48 ?? 44 88 40 ?? 53";

        private string UCmpCommuDetails_BorderBottomRightColor_SIG = "48 8D 45 ?? 48 89 44 24 ?? F3 44 0F 11 54 24 ?? F3 44 0F 11 4C 24 ??";
        private string UCmpCommuList_DrawSocialLinkList_ScrollbarThumb_SIG = "41 BE 00 54 0E 0E 49 8B 84 24 ?? ?? ?? ??";

        private string UCmpCommuList_DrawHighlightedOptionMainScreen_SIG = "81 C9 00 00 00 FF F3 44 0F 11 54 24 ??";
        private string UCmpCommuList_DrawHighlightedOptionDetailScreen_SIG = "C7 44 24 ?? FF 00 00 FF 0F 28 C4";
        private string UCmpCommuList_DrawHighlightedArcanaDetailScreen_SIG = "C7 44 24 ?? 7F 6D 04 03";

        private string UCmpCommuList_DrawHighlightedArrows_SIG = "41 81 CE 00 00 00 EE";

        private IAsmHook _getSocialLinkColors;
        private IReverseWrapper<UCmpCommuList_GetSocialLinkLightColor> _getSocialLinkLightColor;
        private IReverseWrapper<UCmpCommuList_GetSocialLinkDarkColor> _getSocialLinkDarkColor;

        //private IAsmHook _getCharDetailNameTriangle;
        //private IAsmHook _getCharDetailBg;
        //private IAsmHook _getCharDetailTextGraphic;

        //private IAsmHook _getMultiCharListTextColor;
        //private IReverseWrapper<UCmpCommuDetails_GetMultiCharacterListTextColor> _getMultiCharListTextColorWrapper;

        private IHook<ABtlShuffleMainBase_CardFallUpdateInner> _arcanaCardFall;

        private IAsmHook _borderBottomRightColor;

        public unsafe CampSocialLink(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(UCmpCommuList_DrawSocialLinkList_GetSocialLinkColorsLight_SIG, "UCmpCommuDetails::GetSocialLinkColorsLight", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampSocialLinkLight.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpCommuList_DrawSocialLinkList_GetSocialLinkColorsDark_SIG, "UCmpCommuDetails::GetSocialLinkColorsDark", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampSocialLinkDark.ToU32IgnoreAlpha())));
            });

            // UCmpCommu::SocialLinkDetailsCharacterDetail
            _context._utils.SigScan(UCmpCommuDetails_CharDetailsNameTriangle_SIG, "UCmpCommuDetails::CharDetailsNameTriangle", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CampSocialLinkDetailDescTriangle.ToU32ARGB())));
            });
            _context._utils.SigScan(UCmpCommuDetails_CharDetailsBg_SIG, "UCmpCommuDetails::CharDetailBgColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CampSocialLinkDetailDescBg.ToU32ARGB())));
            });
            _context._utils.SigScan(UCmpCommuDetails_CharDetailsTextGraphic_SIG, "UCmpCommuDetails::CharDetailnameColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CampSocialLinkDetailDescName.ToU32())));
            });
            /*
            _context._utils.SigScan(UCmpCommuDetails_CharDetailsNameTriangle_SIG, "UCmpCommuDetails::CharDetailsNameTriangle", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rsp + 0x70], {_context._config.CampSocialLinkDetailDescTriangle.ToU32ARGB()}"
                };
                _getCharDetailNameTriangle = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpCommuDetails_CharDetailsBg_SIG, "UCmpCommuDetails::CharDetailBgColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rsp + 0x70], {_context._config.CampSocialLinkDetailDescBg.ToU32ARGB()}"
                };
                _getCharDetailBg = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpCommuDetails_CharDetailsTextGraphic_SIG, "UCmpCommuDetails::CharDetailnameColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rsp + 0x30], {_context._config.CampSocialLinkDetailDescName.ToU32()}"
                };
                _getCharDetailTextGraphic = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            */

            // UCmpCommu::SociaLLinkDetailsMultipleCharacterList
            /* ASM Hooking is too large for this (messes up a conditional move)
            _context._utils.SigScan(UCmpCommuDetails_CharMultiListText_SIG, "UCmpCommuDetails::CharMultiListTextColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UCmpCommuDetails_GetMultiCharacterListTextColorImpl, out _getMultiCharListTextColorWrapper)}",
                };
                _getMultiCharListTextColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteAfter).Activate();
            });
            */
            _context._utils.SigScan(UCmpCommuDetails_CharMultiListText_SIG, "UCmpCommuDetails::CharMultiListTextColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampSocialLinkDetailDescName.ToU32())));
            });
            _context._utils.SigScan(UCmpCommuDetails_CharMultiListBg_SIG, "UCmpCommuDetails::CharMultiListTextColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampSocialLinkDetailDescBg.ToU32())));
            });
            _context._utils.SigScan(UCmpCommuDetails_CharMultiScrollBg_SIG, "UCmpCommuDetails::CharMultiListTextColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampSocialLinkDetailDescBg.ToU32())));
            });

            _context._utils.SigScan(ABtlShuffleMainBase_CardFallUpdateInner_SIG, "ABtlShuffleMainBase::CardFallUpdateInner", _context._utils.GetDirectAddress, addr => _arcanaCardFall = _context._utils.MakeHooker<ABtlShuffleMainBase_CardFallUpdateInner>(ABtlShuffleMainBase_CardFallUpdateInnerImpl, addr));

            _context._utils.SigScan(UCmpCommuDetails_BorderBottomRightColor_SIG, "UCmpCommuDetails::BorderBottomRightColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rbp - 0x80], {_context._config.CampSocialLinkDetailDescBg.ToU32ARGB()}"
                };
                _borderBottomRightColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpCommuList_DrawSocialLinkList_ScrollbarThumb_SIG, "UCmpCommuList::GetScrollbarThumbColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampSocialLinkDetailDescBg.ToU32())));
            });
            _context._utils.SigScan(UCmpCommuList_DrawHighlightedOptionMainScreen_SIG, "UCmpCommuList::DrawHighlightedOptionMainScreen", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CampHighlightedColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpCommuList_DrawHighlightedOptionDetailScreen_SIG, "UCmpCommuList::DrawHighlightedOptionDetailScreen", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CampHighlightedColor.ToU32())));
            });
            _context._utils.SigScan(UCmpCommuList_DrawHighlightedArcanaDetailScreen_SIG, "UCmpCommuList::DrawHighlightedArcanaDetailScreen", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CampSocialLinkArcanaHighlightedColor.ToU32())));
            });
            _context._utils.SigScan(UCmpCommuList_DrawHighlightedArrows_SIG, "UCmpCommuList::DrawHighlightedArrows", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampHighlightedLowerColor.ToU32IgnoreAlpha())));
            });
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
            _campCommon = GetModule<CampCommon>();
        }
        private unsafe FSprColor UCmpCommuList_GetSocialLinkLightColorImpl() => ConfigColor.ToFSprColor(_context._config.CampSocialLinkLight);
        private unsafe FSprColor UCmpCommuList_GetSocialLinkDarkColorImpl() => ConfigColor.ToFSprColor(_context._config.CampSocialLinkDark);

        private unsafe FSprColor UCmpCommuDetails_GetMultiCharacterListTextColorImpl() => ConfigColor.ToFSprColor(_context._config.CampSocialLinkDetailDescName);

        [Function(new Register[] { }, FunctionAttribute.Register.rcx, false)]
        private unsafe delegate FSprColor UCmpCommuList_GetSocialLinkLightColor();
        [Function(new Register[] { }, FunctionAttribute.Register.r8, false, new Register[] { FunctionAttribute.Register.rcx })]
        private unsafe delegate FSprColor UCmpCommuList_GetSocialLinkDarkColor();

        [Function(new Register[] { }, FunctionAttribute.Register.r8, false)]
        private unsafe delegate FSprColor UCmpCommuDetails_GetMultiCharacterListTextColor();

        private FSprColor GetTargetArcanaCardColor(int i)
        {
            if (i % 3 == 0) return ConfigColor.ToFSprColor(_context._config.ArcanaCardFallColor1);
            else if (i % 3 == 1) return ConfigColor.ToFSprColor(_context._config.ArcanaCardFallColor2);
            else return ConfigColor.ToFSprColor(_context._config.ArcanaCardFallColor3);
        }

        private unsafe void ABtlShuffleMainBase_CardFallUpdateInnerImpl(nint a1, float deltaTime, byte a3, int a4, int a5, int a6, int a7, float a8, float a9, float a10, float a11, float a12, float a13, float a14, float a15)
        {
            // a1 + 9a0 : TArray<FSprColor>
            TArray<FSprColor>* colorArr = (TArray<FSprColor>*)(a1 + 0x9a0);
            for (int i = 0; i < colorArr->arr_num; i++)
                colorArr->allocator_instance[i] = GetTargetArcanaCardColor(i);
            _arcanaCardFall.OriginalFunction(a1, deltaTime, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15);
        }
        private unsafe delegate void ABtlShuffleMainBase_CardFallUpdateInner(nint a1, float deltaTime, byte a3, int a4, int a5, int a6, int a7, float a8, float a9, float a10, float a11, float a12, float a13, float a14, float a15);
    }

    public class CampCalendar : ModuleAsmInlineColorEdit<FemcContext>
    {
        private UICommon _uiCommon;
        private CampCommon _campCommon;

        // Inside UUICmpCalendarDraw::DrawCalendarGrid
        private string UUICmpCalendarDraw_DrawCalendarGrid_SundayHeader_SIG = "F3 0F 2C FE 66 C7 85 ?? ?? ?? ?? FF FF";
        private string UUICmpCalendarDraw_DrawCalendarGrid_SundayDay_SIG = "44 88 BD ?? ?? ?? ?? 89 5D ??";
        // Inside UUICmpCalendarDraw::DrawMonthDisplay
        private string UUICmpCalendarDraw_DrawMonthDisplay_PrevMonthColor_SIG = "40 88 BD ?? ?? ?? ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 41 8B 86 ?? ?? ?? ??";
        private string UUICmpCalendarDraw_DrawMonthDisplay_CurrMonthColor_SIG = "40 88 BD ?? ?? ?? ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 40 84 F6";
        private string UUICmpCalendarDraw_DrawMonthDisplay_NextMonthColor_SIG = "40 88 BD ?? ?? ?? ?? 48 89 44 24 ?? E8 ?? ?? ?? ?? 41 0F B6 86 ?? ?? ?? ??";
        // Inside UUICmpCalendarDraw::DrawDayEvents
        private string UUICmpCalendar_DrawDayEvents_DateBg_SIG = "66 0F 6E C8 8B 87 ?? ?? ?? ?? 03 87 ?? ?? ?? ??";
        private string UUICmpCalendar_DrawDayEvents_DrawTextColor_SIG = "";
        // UUICmpCalendarDraw::DrawPartTimeJobDescBg
        private string UUICmpCalendarDraw_PartTimeJobDescBgColor_SIG = "C7 84 24 ?? ?? ?? ?? 62 15 00 FF";
        private string UUICmpCalendarDraw_PartTimeJobDescBg_SIG = "48 8B C4 48 89 70 ?? 57 48 81 EC D0 00 00 00 44 0F 29 40 ??";
        // UUICmpCalendarDraw::DrawPartTimeJobDescHeader
        private string UUICmpCalendarDraw_PartTimeJobTextColor_SIG = "C7 84 24 ?? ?? ?? ?? 43 04 08 FF";
        private string UUICmpCalendarDraw_PartTimeJobHeader_SIG = "48 8B C4 48 89 58 ?? 48 89 68 ?? 48 89 70 ?? 57 48 81 EC B0 00 00 00 0F 29 70 ?? 48 8B F9";

        private string UUICmpCalendarDraw_LeftArrowRed1_SIG = "E8 ?? ?? ?? ?? F3 0F 2C F0 0F 57 C0 0F 28 D7 41 0F 28 C9 E8 ?? ?? ?? ?? F3 0F 2C F8 0F 57 C0 0F 28 D7 41 0F 28 C9 E8 ?? ?? ?? ?? F3 0F 2C D8 41 0F 28 C3 0F 28 D7 0F 57 C9 E8 ?? ?? ?? ?? F3 0F 59 85 ?? ?? ?? ?? 49 8D 4E ?? 88 9D ?? ?? ?? ?? F3 0F 10 15 ?? ?? ?? ?? 0F 57 DB F3 0F 10 4C 24 ?? F3 0F 2C C0 40 88 BD ?? ?? ?? ?? 40 88 B5 ?? ?? ?? ?? 88 85 ?? ?? ?? ?? 41 0F B6 86 ?? ?? ?? ?? 88 44 24 ?? 48 8D 85 ?? ?? ?? ?? C6 44 24 ?? 04 4C 89 6C 24 ?? F3 44 0F 11 6C 24 ??";
        private string UUICmpCalendarDraw_LeftArrowGreen1_SIG = "E8 ?? ?? ?? ?? F3 0F 2C F8 0F 57 C0 0F 28 D7 41 0F 28 C9 E8 ?? ?? ?? ?? F3 0F 2C D8 41 0F 28 C3 0F 28 D7 0F 57 C9 E8 ?? ?? ?? ?? F3 0F 59 85 ?? ?? ?? ?? 49 8D 4E ?? 88 9D ?? ?? ?? ?? F3 0F 10 15 ?? ?? ?? ?? 0F 57 DB F3 0F 10 4C 24 ?? F3 0F 2C C0 40 88 BD ?? ?? ?? ?? 40 88 B5 ?? ?? ?? ?? 88 85 ?? ?? ?? ?? 41 0F B6 86 ?? ?? ?? ?? 88 44 24 ?? 48 8D 85 ?? ?? ?? ?? C6 44 24 ?? 04 4C 89 6C 24 ?? F3 44 0F 11 6C 24 ??";
        private string UUICmpCalendarDraw_LeftArrowBlue1_SIG = "E8 ?? ?? ?? ?? F3 0F 2C D8 41 0F 28 C3 0F 28 D7 0F 57 C9 E8 ?? ?? ?? ?? F3 0F 59 85 ?? ?? ?? ?? 49 8D 4E ?? 88 9D ?? ?? ?? ?? F3 0F 10 15 ?? ?? ?? ?? 0F 57 DB F3 0F 10 4C 24 ?? F3 0F 2C C0 40 88 BD ?? ?? ?? ?? 40 88 B5 ?? ?? ?? ?? 88 85 ?? ?? ?? ?? 41 0F B6 86 ?? ?? ?? ?? 88 44 24 ?? 48 8D 85 ?? ?? ?? ?? C6 44 24 ?? 04 4C 89 6C 24 ?? F3 44 0F 11 6C 24 ??";
        private string UUICmpCalendarDraw_LeftArrowRed2_SIG = "E8 ?? ?? ?? ?? F3 0F 2C F8 0F 57 C0 0F 28 D7 0F 57 C9 E8 ?? ?? ?? ?? F3 0F 2C D8 0F 57 C0 0F 28 D7 0F 57 C9 E8 ?? ?? ?? ?? F3 0F 2C C0";
        private string UUICmpCalendarDraw_LeftArrowGreen2_SIG = "E8 ?? ?? ?? ?? F3 0F 2C D8 0F 57 C0 0F 28 D7 0F 57 C9 E8 ?? ?? ?? ?? F3 0F 2C C0";
        private string UUICmpCalendarDraw_LeftArrowBlue2_SIG = "E8 ?? ?? ?? ?? F3 0F 2C C0 88 9D ?? ?? ?? ?? 40 88 BD ?? ?? ?? ??";
        private string UUICmpCalendarDraw_RightArrowRed1_SIG = "E8 ?? ?? ?? ?? F3 0F 2C F0 0F 57 C0 0F 28 D7 41 0F 28 C9 E8 ?? ?? ?? ?? F3 0F 2C F8 0F 57 C0 0F 28 D7 41 0F 28 C9 E8 ?? ?? ?? ?? F3 0F 2C D8 41 0F 28 C3 0F 28 D7 0F 57 C9 E8 ?? ?? ?? ?? F3 0F 59 85 ?? ?? ?? ?? 49 8D 4E ?? 88 9D ?? ?? ?? ?? F3 0F 10 15 ?? ?? ?? ?? 0F 57 DB F3 0F 10 4C 24 ?? F3 0F 2C C0 40 88 BD ?? ?? ?? ?? 40 88 B5 ?? ?? ?? ?? 88 85 ?? ?? ?? ?? 41 0F B6 86 ?? ?? ?? ?? 88 44 24 ?? 48 8D 85 ?? ?? ?? ?? C6 44 24 ?? 04 4C 89 6C 24 ?? F3 0F 11 74 24 ??";
        private string UUICmpCalendarDraw_RightArrowGreen1_SIG = "E8 ?? ?? ?? ?? F3 0F 2C F8 0F 57 C0 0F 28 D7 41 0F 28 C9 E8 ?? ?? ?? ?? F3 0F 2C D8 41 0F 28 C3 0F 28 D7 0F 57 C9 E8 ?? ?? ?? ?? F3 0F 59 85 ?? ?? ?? ?? 49 8D 4E ?? 88 9D ?? ?? ?? ?? F3 0F 10 15 ?? ?? ?? ?? 0F 57 DB F3 0F 10 4C 24 ?? F3 0F 2C C0 40 88 BD ?? ?? ?? ?? 40 88 B5 ?? ?? ?? ?? 88 85 ?? ?? ?? ?? 41 0F B6 86 ?? ?? ?? ?? 88 44 24 ?? 48 8D 85 ?? ?? ?? ?? C6 44 24 ?? 04 4C 89 6C 24 ?? F3 0F 11 74 24 ??";
        private string UUICmpCalendarDraw_RightArrowBlue1_SIG = "E8 ?? ?? ?? ?? F3 0F 2C D8 41 0F 28 C3 0F 28 D7 0F 57 C9 E8 ?? ?? ?? ?? F3 0F 59 85 ?? ?? ?? ?? 49 8D 4E ?? 88 9D ?? ?? ?? ?? F3 0F 10 15 ?? ?? ?? ?? 0F 57 DB F3 0F 10 4C 24 ?? F3 0F 2C C0 40 88 BD ?? ?? ?? ?? 40 88 B5 ?? ?? ?? ?? 88 85 ?? ?? ?? ?? 41 0F B6 86 ?? ?? ?? ?? 88 44 24 ?? 48 8D 85 ?? ?? ?? ?? C6 44 24 ?? 04 4C 89 6C 24 ?? F3 0F 11 74 24 ??";
        private string UUICmpCalendarDraw_RightArrowRed2_SIG = "E8 ?? ?? ?? ?? F3 0F 2C F8 0F 57 C0 0F 28 D7 0F 57 C9 E8 ?? ?? ?? ?? F3 0F 2C D8 0F 57 C0 0F 28 D7 0F 57 C9 E8 ?? ?? ?? ?? F3 44 0F 10 05 ?? ?? ?? ??";
        private string UUICmpCalendarDraw_RightArrowGreen2_SIG = "E8 ?? ?? ?? ?? F3 0F 2C D8 0F 57 C0 0F 28 D7 0F 57 C9 E8 ?? ?? ?? ?? F3 44 0F 10 05 ?? ?? ?? ??";
        private string UUICmpCalendarDraw_RightArrowBlue2_SIG = "E8 ?? ?? ?? ?? F3 44 0F 10 05 ?? ?? ?? ?? 49 8D 4E ??";

        private string UUICmpCalendarDraw_DayOfWeekFontColor_SIG = "41 81 C9 00 43 04 08";
        private string UUICmpCalendarDraw_JobDescriptionFontColor_SIG = "8B 44 24 ?? 41 0F 28 DA 0F 28 F0";
        private string UUICmpCalendarDraw_PastDayColor_SIG = "44 88 7D ?? 66 C7 45 ?? FF FF";
        private string UUICmpCalendarDraw_HighlightedDayColor_SIG = "41 0F 28 DA 41 0F 28 D0 66 0F 6E F0";
        private string UUICmpCalendarDraw_HighlightedJobColor_SIG = "E8 ?? ?? ?? ?? B1 01 E8 ?? ?? ?? ?? 48 8B C8 48 89 45 ??";
        private string UUICmpCalendarDraw_CalendarJobDetailFontColor_SIG = "4C 8B B5 ?? ?? ?? ?? 8B 85 ?? ?? ?? ?? F3 0F 10 35 ?? ?? ?? ??";

        private IAsmHook _calendarSundayColor;
        private IAsmHook _calendarSundayDay;
        private IAsmHook _monthsPrevMonth;
        private IAsmHook _monthsCurrMonth;
        private IAsmHook _monthsNextMonth;
        private IAsmHook _dateBg;

        private IAsmHook _LeftArrowRed1;
        private IAsmHook _LeftArrowGreen1;
        private IAsmHook _LeftArrowBlue1;
        private IAsmHook _LeftArrowRed2;
        private IAsmHook _LeftArrowGreen2;
        private IAsmHook _LeftArrowBlue2;
        private IAsmHook _RightArrowRed1;
        private IAsmHook _RightArrowGreen1;
        private IAsmHook _RightArrowBlue1;
        private IAsmHook _RightArrowRed2;
        private IAsmHook _RightArrowGreen2;
        private IAsmHook _RightArrowBlue2;

        private IAsmHook _JobDescriptionFontColor;
        private IAsmHook _PastDayColor;
        private IAsmHook _HighlightedDayColor;
        private IAsmHook _HighlightedJobColor;
        private IAsmHook _CalendarJobDetailFontColor;

        private IHook<UUICmpCalendarDraw_DrawUIComponent> _drawPartTimeJobBg;
        private IHook<UUICmpCalendarDraw_DrawUIComponent> _drawPartTimeHeader;

        public unsafe CampCalendar(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(UUICmpCalendarDraw_DrawCalendarGrid_SundayHeader_SIG, "UUICmpCalendarDraw::DrawCalendarGrid_SundayHeader", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rbp + 0x88], {_context._config.CampCalendarSundayColor.ToU32ARGB()}"
                };
                _calendarSundayColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(UUICmpCalendarDraw_DrawCalendarGrid_SundayDay_SIG, "UUICmpCalendarDraw::DrawCalendarGrid_SundayDay", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rbp + 0x80], {_context._config.CampCalendarSundayColor.ToU32ARGB()}",
                    $"mov byte [rbp + 0x83], r15b", // opacity
                    $"mov dword [rbp + 0x84], {_context._config.CampCalendarSundayColor2.ToU32ARGB()}"
                };
                _calendarSundayDay = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(UUICmpCalendarDraw_DrawMonthDisplay_PrevMonthColor_SIG, "UUICmpCalendarDraw::DrawMonthDisplay_PrevMonth", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rbp + 0xe8], {_context._config.CampCalendarTextColor.ToU32ARGB()}"
                };
                _monthsPrevMonth = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_DrawMonthDisplay_CurrMonthColor_SIG, "UUICmpCalendarDraw::DrawMonthDisplay_CurrMonth", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rbp + 0xe8], {_context._config.CampCalendarTextColor.ToU32ARGB()}"
                };
                _monthsCurrMonth = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_DrawMonthDisplay_NextMonthColor_SIG, "UUICmpCalendarDraw::DrawMonthDisplay_NextMonth", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rbp + 0xe8], {_context._config.CampCalendarTextColor.ToU32ARGB()}"
                };
                _monthsNextMonth = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendar_DrawDayEvents_DateBg_SIG, "UUICmpCalendarDraw::DrawDayEvents_DateBg", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rbp + 0x6f], {_context._config.CampCalendarHighlightColor.ToU32ARGB()}"
                };
                _dateBg = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(UUICmpCalendarDraw_PartTimeJobDescBg_SIG, "UUICmpCalendarDraw::PartTimeJobDescBg", _context._utils.GetDirectAddress, addr => _drawPartTimeJobBg = _context._utils.MakeHooker<UUICmpCalendarDraw_DrawUIComponent>(UUICmpCalendarDraw_PartTimeJobDescBg, addr));
            _context._utils.SigScan(UUICmpCalendarDraw_PartTimeJobHeader_SIG, "UUICmpCalendarDraw::PartTimeJobHeader", _context._utils.GetDirectAddress, addr => _drawPartTimeHeader = _context._utils.MakeHooker<UUICmpCalendarDraw_DrawUIComponent>(UUICmpCalendarDraw_PartTimeJobHeader, addr));

            _context._utils.SigScan(UUICmpCalendarDraw_LeftArrowRed1_SIG, "UUICmpCalendarDraw::LeftArrowRed1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov ebx, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.R):X}",
                    "movd xmm0, ebx",
                };
                _LeftArrowRed1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_LeftArrowGreen1_SIG, "UUICmpCalendarDraw::LeftArrowGreen1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov ebx, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.G):X}",
                    "movd xmm0, ebx",
                };
                _LeftArrowGreen1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_LeftArrowBlue1_SIG, "UUICmpCalendarDraw::LeftArrowBlue1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov ebx, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.B):X}",
                    "movd xmm0, ebx",
                };
                _LeftArrowBlue1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_LeftArrowRed2_SIG, "UUICmpCalendarDraw::LeftArrowRed2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.R):X}",
                    "movd xmm0, eax",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedDark.R):X}",
                    "movd xmm1, eax",
                };
                _LeftArrowRed2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_LeftArrowGreen2_SIG, "UUICmpCalendarDraw::LeftArrowGreen2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.G):X}",
                    "movd xmm0, eax",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedDark.G):X}",
                    "movd xmm1, eax",
                };
                _LeftArrowGreen2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_LeftArrowBlue2_SIG, "UUICmpCalendarDraw::LeftArrowBlue2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.B):X}",
                    "movd xmm0, eax",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedDark.B):X}",
                    "movd xmm1, eax",
                };
                _LeftArrowBlue2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_RightArrowRed1_SIG, "UUICmpCalendarDraw::RightArrowRed1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov ebx, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.R):X}",
                    "movd xmm0, ebx",
                };
                _RightArrowRed1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_RightArrowGreen1_SIG, "UUICmpCalendarDraw::RightArrowGreen1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov ebx, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.G):X}",
                    "movd xmm0, ebx",
                };
                _RightArrowGreen1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_RightArrowBlue1_SIG, "UUICmpCalendarDraw::RightArrowBlue1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov ebx, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.B):X}",
                    "movd xmm0, ebx",
                };
                _RightArrowBlue1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_RightArrowRed2_SIG, "UUICmpCalendarDraw::RightArrowRed2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.R):X}",
                    "movd xmm0, eax",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedDark.R):X}",
                    "movd xmm1, eax",
                };
                _RightArrowRed2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_RightArrowGreen2_SIG, "UUICmpCalendarDraw::RightArrowGreen2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.G):X}",
                    "movd xmm0, eax",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedDark.G):X}",
                    "movd xmm1, eax",
                };
                _RightArrowGreen2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_RightArrowBlue2_SIG, "UUICmpCalendarDraw::RightArrowBlue2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.B):X}",
                    "movd xmm0, eax",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedDark.B):X}",
                    "movd xmm1, eax",
                };
                _RightArrowBlue2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(UUICmpCalendarDraw_DayOfWeekFontColor_SIG, "UCmpCommuList::DayOfWeekFontColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.CampCalendarTextColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UUICmpCalendarDraw_JobDescriptionFontColor_SIG, "UUICmpCalendarDraw::JobDescriptionFontColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp + 0x60], 0x{_context._config.CampCalendarTextColor.B:X}",
                    $"mov byte [rsp + 0x61], 0x{_context._config.CampCalendarTextColor.G:X}",
                    $"mov byte [rsp + 0x62], 0x{_context._config.CampCalendarTextColor.R:X}",
                };
                _JobDescriptionFontColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_PastDayColor_SIG, "UUICmpCalendarDraw::PastDayColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp + 0x74], 0x{_context._config.CalendarPastDay.B:X}",
                    $"mov byte [rbp + 0x75], 0x{_context._config.CalendarPastDay.G:X}",
                    $"mov byte [rbp + 0x76], 0x{_context._config.CalendarPastDay.R:X}",
                };
                _PastDayColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_HighlightedDayColor_SIG, "UUICmpCalendarDraw::HighlightedDayColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp + 0x74], 0x{_context._config.CalendarHighlightedDay.B:X}",
                    $"mov byte [rsp + 0x75], 0x{_context._config.CalendarHighlightedDay.G:X}",
                    $"mov byte [rsp + 0x76], 0x{_context._config.CalendarHighlightedDay.R:X}",
                };
                _HighlightedDayColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_HighlightedJobColor_SIG, "UUICmpCalendarDraw::HighlightedJobColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp - 0x80], 0x{_context._config.CalendarHighlightedJob.B:X}",
                    $"mov byte [rbp - 0x7f], 0x{_context._config.CalendarHighlightedJob.G:X}",
                    $"mov byte [rbp - 0x7e], 0x{_context._config.CalendarHighlightedJob.R:X}",
                };
                _HighlightedJobColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUICmpCalendarDraw_CalendarJobDetailFontColor_SIG, "UUICmpCalendarDraw::CalendarJobDetailFontColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    "jz gray_font",
                    $"mov byte [rbp + 0xd8], 0x{_context._config.CalendarJobDetailFont.B:X}",
                    $"mov byte [rbp + 0xd9], 0x{_context._config.CalendarJobDetailFont.G:X}",
                    $"mov byte [rbp + 0xda], 0x{_context._config.CalendarJobDetailFont.R:X}",
                    "label gray_font"
                };
                _CalendarJobDetailFontColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
            _campCommon = GetModule<CampCommon>();
        }

        private unsafe void UUICmpCalendarDraw_PartTimeJobDescBg(UUICmpCalendarDraw* self, float x, float y, float angle)
        {
            var uiResrc = _uiCommon._globalWorkGetUIResources();
            var plgEntry = (UPlgAsset*)uiResrc->GetAssetEntry(0x33);
            if (plgEntry != null && self->PartTimeJobs.arr_num > 0)
            {
                var v1 = new FAppCalculationItem(-400, 0, self->PartJobBgInAnimDelay, self->Field70, appCalculationType.DEC);
                var f1 = _uiCommon._appCalcLerp(self->Field248, &v1, 1, 0);
                var v2 = new FAppCalculationItem(0, 1, 0, self->PartJobBgInAnimDstFrame, appCalculationType.DEC);
                var f2 = _uiCommon._appCalcLerp(self->TimePartTimeJobOpen, &v2, 1, 0);
                var v3 = new FAppCalculationItem(1, 0, self->PartJobBgOutAnimDelay, self->PartJobBgOutAnimDstFrame, appCalculationType.DEC);
                f2 *= _uiCommon._appCalcLerp(self->TimePartTimeJobClosed, &v3, 1, 0);
                var f4 = UICommon.Lerp(502, 0, f2);
                var f5 = UICommon.Lerp(-720, 0, f2);
                var f6 = UICommon.Lerp(23, 0, f2);
                var masker = _uiCommon._getSpriteItemMaskInstance() + 0x20;
                _uiCommon._setBlendState(masker, 
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_SourceColor, 
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_Zero, 0xf, self->CalendarDrawQueue);
                self->DrawSpr.Flag2Set_141301af0(1);
                var bgColor = ConfigColor.ToFColorBP(_context._config.CampCalendarPartTimeJobBackground);
                _uiCommon._drawPlg(&self->DrawSpr, x + f4, y + f1 + f5, 0, &bgColor, 0xa4, 1, 1, angle + f6, plgEntry, self->CalendarDrawQueue);
                self->DrawSpr.Flag2Set_141301af0(0);
                _uiCommon._setBlendState(masker, // setup for PartTimeJobHeader
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_SourceAlpha, EUIBlendFactor.UI_BF_InverseSourceAlpha,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_Zero, 0xf, self->CalendarDrawQueue);
            }
        }

        private unsafe void UUICmpCalendarDraw_PartTimeJobHeader(UUICmpCalendarDraw* self, float x, float y, float angle)
        {
            var uiResrc = _uiCommon._globalWorkGetUIResources();
            var campSpr = (USprAsset*)uiResrc->GetAssetEntry(0x32);
            var campPlg = (UPlgAsset*)uiResrc->GetAssetEntry(0x33);
            if (campSpr != null && campPlg != null && self->PartTimeJobs.arr_num > 0)
            {
                var v1 = new FAppCalculationItem(-400, 0, self->PartJobBgInAnimDelay, self->Field70, appCalculationType.DEC);
                var f1 = _uiCommon._appCalcLerp(self->Field248, &v1, 1, 0);
                var fy = y + f1;
                var gWork = _uiCommon.GetUGlobalWorkEx();
                var bgColor = gWork.GetCalendar()->TimeOfDay switch
                {
                    ECldTimeZone.Night or ECldTimeZone.Shadow or ECldTimeZone.Midnight 
                    => ConfigColor.ToFColorBP(_context._config.CampCalendarHighlightColor),
                    _ => new FColor(0xFF, 0xFF, 0xF0, 0x46),
                };
                _uiCommon._drawPlg(&self->DrawSpr, x - 4, fy - 4, 0, &bgColor, 0xa3, 1, 1, 0, campPlg, self->CalendarDrawQueue);
                var textPos = new FVector2D(x, fy);
                var textColor = ConfigColor.ToFColorBP(_context._config.CampCalendarTextColor);
                if (self->pMainActor != null)
                {
                    var layoutTable2 = _context.bIsAigis 
                        ? ((nativetypes.Interfaces.Astrea.ACmpMainActor*)self->pMainActor)->OthersLayoutDataTable->GetLayoutDataTableEntry(2)
                        : self->pMainActor->OthersLayoutDataTable->GetLayoutDataTableEntry(2);
                    textPos.X += layoutTable2->position.X;
                    textPos.Y += layoutTable2->position.Y;
                }
                _uiCommon._drawSpr(&self->DrawSpr, textPos.X, textPos.Y, 0, &textColor, 0x4fc, 1, 1, 0, campSpr, EUI_DRAW_POINT.UI_DRAW_RIGHT_TOP, self->CalendarDrawQueue);
            }
        }

        private unsafe delegate void UUICmpCalendarDraw_DrawUIComponent(UUICmpCalendarDraw* self, float x, float y, float angle); // angle, degrees
    }

    public class CampSystem : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string UCmpSystemDraw_GetMenuColors_SIG = "43 8B 94 ?? ?? ?? ?? ?? 41 0F 28 D4";
        private string UCmpSystemDraw_DrawUnhighlightedMenuOptions_SIG = "48 8B C4 48 89 58 ?? 44 89 48 ?? 44 89 40 ?? 55 56 57 41 54 41 55 41 56 41 57 48 81 EC 40 01 00 00";
        private string UCmpSystemDraw_GetMenuColorNoSelect_SIG = "4D 8B 24 ?? 83 FB 06"; // or edi, 0x13389500
        //private string UCmpSystemDraw_GetMenuColorNoSelect_SIG = "81 CF 00 95 38 13"; // or edi, 0x13389500
        private string UCmpSystemDraw_DrawCurveColor_SIG = "C7 84 24 ?? ?? ?? ?? C1 29 0B FF";
        private string UCmpSystemDraw_DrawFemcShadowColor1_SIG = "C7 44 24 ?? FF B7 A4 9A 41 0F 28 DA";
        private string UCmpSystemDraw_DrawFemcShadowColor2_SIG = "C7 44 24 ?? FF B7 A4 9A 41 8B D7";
        private string UCmpSystemDraw_DrawFemcShadowColor3_SIG = "C7 44 24 ?? FF B7 A4 9A 41 8B D4";
        private string UCmpSystemDraw_DrawFemcShadowColor4_SIG = "C7 44 24 ?? FF B7 A4 9A 41 8B D5";
        private string UCmpSystemDraw_DrawHighlightedColor1_SIG = "8B 05 ?? ?? ?? ?? 4C 8D 4D ?? 44 88 7C 24 ?? 4C 8D 45 ?? 0F 28 C6";
        private string UCmpSystemDraw_DrawHighlightedColor2_SIG = "8B 05 ?? ?? ?? ?? 44 88 7C 24 ??";
        private string UCmpSystemDraw_DrawFallingWordsColor_SIG = "BA FF 2B 0B 00";

        private string UCmpSystemTutoDictDraw_DrawHighlightedColor_SIG = "40 88 7C 24 ?? 44 88 7C 24 ??";

        private string UCmpSystemTutoDraw_DrawNoTutoBigNone_SIG = "44 88 B5 ?? ?? ?? ?? 0F 28 D7";
        private string UCmpSystemTutoDraw_DrawNoTutoFont_SIG = "0D 00 EF DB 00";
        private string UCmpSystemTutoDraw_DrawTutoTopTogglerBG_SIG = "E8 ?? ?? ?? ?? F3 41 0F 10 86 ?? ?? ?? ?? 48 8D 54 24 ?? 66 41 0F 6E 8E ?? ?? ?? ??";
        private string UCmpSystemTutoDraw_LeftArrowRed1_SIG = "E8 ?? ?? ?? ?? F3 0F 10 0D ?? ?? ?? ?? 0F 28 D7 F3 0F 2C F8 41 0F 28 C3";
        private string UCmpSystemTutoDraw_LeftArrowGreen1_SIG = "E8 ?? ?? ?? ?? F3 0F 10 0D ?? ?? ?? ?? 0F 28 D7 F3 0F 2C D8 41 0F 28 C3";
        private string UCmpSystemTutoDraw_LeftArrowBlue1_SIG = "E8 ?? ?? ?? ?? F3 0F 2C C0 88 9D ?? ?? ?? ?? 49 8B CC 40 88 BD ?? ?? ?? ?? 44 88 AD ?? ?? ?? ?? 41 0F 28 DB 41 0F 28 D0 88 85 ?? ?? ?? ?? 0F 28 CE";
        private string UCmpSystemTutoDraw_LeftArrowRed2_SIG = "E8 ?? ?? ?? ?? F3 0F 2C F8 41 0F 28 C3 0F 28 D7 41 0F 28 C8";
        private string UCmpSystemTutoDraw_LeftArrowGreen2_SIG = "E8 ?? ?? ?? ?? F3 0F 2C D8 41 0F 28 C3 0F 28 D7 41 0F 28 C8";
        private string UCmpSystemTutoDraw_LeftArrowBlue2_SIG = "E8 ?? ?? ?? ?? F3 44 0F 10 85 ?? ?? ?? ?? 41 0F 28 DB";
        private string UCmpSystemTutoDraw_RightArrowRed1_SIG = "E8 ?? ?? ?? ?? F3 0F 2C F8 41 0F 28 C3 0F 28 D7 0F 28 CE";
        private string UCmpSystemTutoDraw_RightArrowGreen1_SIG = "E8 ?? ?? ?? ?? F3 0F 2C D8 41 0F 28 C3 0F 28 D7 0F 28 CE";
        private string UCmpSystemTutoDraw_RightArrowBlue1_SIG = "E8 ?? ?? ?? ?? F3 0F 2C C0 88 9D ?? ?? ?? ?? 49 8B CC 40 88 BD ?? ?? ?? ?? 44 88 AD ?? ?? ?? ?? 41 0F 28 DB 41 0F 28 D0 88 85 ?? ?? ?? ?? 41 0F 28 CF";
        private string UCmpSystemTutoDraw_RightArrowRed2_SIG = "E8 ?? ?? ?? ?? F3 0F 2C F8 41 0F 28 C3 0F 28 D7 41 0F 28 CA";
        private string UCmpSystemTutoDraw_RightArrowGreen2_SIG = "E8 ?? ?? ?? ?? F3 0F 2C D8 41 0F 28 C3 0F 28 D7 41 0F 28 CA";
        private string UCmpSystemTutoDraw_RightArrowBlue2_SIG = "E8 ?? ?? ?? ?? F3 44 0F 58 2D ?? ?? ?? ?? F3 0F 2C C0";

        private string UCmpSystemConfigDraw_DrawConfigTopMainTogglerBG_SIG = "E8 ?? ?? ?? ?? 49 8B 0E 41 B1 05 44 88 7C 24 ?? 48 81 C1 78 02 00 00 C6 44 24 ?? 00 41 B0 04 C6 44 24 ?? 01";
        private string UCmpSystemConfigDraw_DrawConfigTopSecondaryTogglerBG_SIG = "E8 ?? ?? ?? ?? 33 DB 4C 8D 45 ?? B2 21";
        private string UCmpSystemConfigDraw_ArrowRed1_SIG = "E8 ?? ?? ?? ?? F3 0F 2C F8 41 0F 28 C1 41 0F 28 D1 0F 28 CE";
        private string UCmpSystemConfigDraw_ArrowGreen1_SIG = "E8 ?? ?? ?? ?? F3 0F 2C D8 41 0F 28 C1 41 0F 28 D1 0F 28 CE";
        private string UCmpSystemConfigDraw_ArrowBlue1_SIG = "E8 ?? ?? ?? ?? 49 8B 0E 41 0F 28 D9";
        private string UCmpSystemConfigDraw_ArrowRed2_SIG = "E8 ?? ?? ?? ?? F3 0F 2C F8 41 0F 28 C1 41 0F 28 D1 41 0F 28 CF";
        private string UCmpSystemConfigDraw_ArrowGreen2_SIG = "E8 ?? ?? ?? ?? F3 0F 2C D8 41 0F 28 C1 41 0F 28 D1 41 0F 28 CF";
        private string UCmpSystemConfigDraw_ArrowBlue2_SIG = "E8 ?? ?? ?? ?? 49 8B 0E 41 0F 28 FC";

        private IHook<UCmpSystemDraw_DrawUnhighlightedMenuOptions> _drawUnhighlightOptions;
        private IAsmHook _getMenuColorNoSel;
        private IReverseWrapper<UCmpSystemDraw_GetMenuColorNoSelect> _getMenuColorNoSelWrapper;

        private IAsmHook _drawNoTutoBigNone;
        private IAsmHook _drawTutoDictHighlightedColor;

        private IAsmHook _DrawTutoTopTogglerBG;
        private IAsmHook _LeftArrowRed1;
        private IAsmHook _LeftArrowGreen1;
        private IAsmHook _LeftArrowBlue1;
        private IAsmHook _LeftArrowRed2;
        private IAsmHook _LeftArrowGreen2;
        private IAsmHook _LeftArrowBlue2;
        private IAsmHook _RightArrowRed1;
        private IAsmHook _RightArrowGreen1;
        private IAsmHook _RightArrowBlue1;
        private IAsmHook _RightArrowRed2;
        private IAsmHook _RightArrowGreen2;
        private IAsmHook _RightArrowBlue2;

        private IAsmHook _DrawConfigTopMainTogglerBG;
        private IAsmHook _DrawConfigTopSecondaryTogglerBG;
        private IAsmHook _ArrowRed1;
        private IAsmHook _ArrowGreen1;
        private IAsmHook _ArrowBlue1;
        private IAsmHook _ArrowRed2;
        private IAsmHook _ArrowGreen2;
        private IAsmHook _ArrowBlue2;

        private unsafe FSprColor* _systemOptionColors;
        private static int SystemOptionCount = 7;

        private UICommon _uiCommon;
        private CampCommon _campCommon;
        public unsafe CampSystem(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(UCmpSystemDraw_DrawUnhighlightedMenuOptions_SIG, "UCmpSystemDraw::DrawUnhighlightedMenuOptions", _context._utils.GetDirectAddress, addr => _drawUnhighlightOptions = _context._utils.MakeHooker<UCmpSystemDraw_DrawUnhighlightedMenuOptions>(UCmpSystemDraw_DrawUnhighlightedMenuOptionsImpl, addr));
            _context._utils.SigScan(UCmpSystemDraw_GetMenuColors_SIG, "UCmpSystemDraw_MenuOptionColors", trans => (nuint)(_context._baseAddress + *(int*)(_context._baseAddress + trans + 4)), addr => _systemOptionColors = (FSprColor*)addr);
            _context._utils.SigScan(UCmpSystemDraw_GetMenuColorNoSelect_SIG, "UCmpSystemDraw::GetMenuColorNoSelect", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    //$"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UCmpSystemDraw_GetMenuColorNoSelectImpl, out _getMenuColorNoSelWrapper)}",
                    $"mov edi, {_context._config.CampMenuItemColorNoSel.ToU32()}"
                };
                _getMenuColorNoSel = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemDraw_DrawCurveColor_SIG, "UCmpSystemDraw::DrawCurveColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 7, _context._config.TextBoxSpeakerNameTriangle.ToU32ARGB())));
            });
            _context._utils.SigScan(UCmpSystemDraw_DrawFemcShadowColor1_SIG, "UCmpSystemDraw::DrawFemcShadowColor1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CampFemcShadow.ToU32())));
            });
            _context._utils.SigScan(UCmpSystemDraw_DrawFemcShadowColor2_SIG, "UCmpSystemDraw::DrawFemcShadowColor2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CampFemcShadow.ToU32())));
            });
            _context._utils.SigScan(UCmpSystemDraw_DrawFemcShadowColor3_SIG, "UCmpSystemDraw::DrawFemcShadowColor3", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CampFemcShadow.ToU32())));
            });
            _context._utils.SigScan(UCmpSystemDraw_DrawFemcShadowColor4_SIG, "UCmpSystemDraw::DrawFemcShadowColor4", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CampFemcShadow.ToU32())));
            });
            _context._utils.SigScan(UCmpSystemDraw_DrawHighlightedColor1_SIG, "UCmpSystemDraw::DrawHighlightedColor1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr, (byte) 0xB8))); // mov eax, color
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampHighlightedColor.ToU32ARGB())));
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 5, (byte) 0x90))); // nop extra space
            });
            _context._utils.SigScan(UCmpSystemDraw_DrawHighlightedColor2_SIG, "UCmpSystemDraw::DrawHighlightedColor2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr, (byte) 0xB8))); // mov eax, color
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampHighlightedColor.ToU32ARGB())));
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 5, (byte) 0x90))); // nop extra space
            });
            _context._utils.SigScan(UCmpSystemTutoDictDraw_DrawHighlightedColor_SIG, "UCmpSystemTutoDictDraw::DrawHighlightedColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp + 0x60], ${_context._config.CampHighlightedLowerColor.B:X}",
                    $"mov byte [rsp + 0x61], ${_context._config.CampHighlightedLowerColor.G:X}",
                    $"mov byte [rsp + 0x62], ${_context._config.CampHighlightedLowerColor.R:X}"
                };
                _drawTutoDictHighlightedColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteAfter).Activate();
            });
            _context._utils.SigScan(UCmpSystemDraw_DrawFallingWordsColor_SIG, "UCmpSystemDraw::DrawFallingWordsColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampSystemStartFallingWordsColor.ToU32())));
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 6, _context._config.CampSystemEndFallingWordsColor.ToU32())));
            });

            _context._utils.SigScan(UCmpSystemTutoDraw_DrawNoTutoBigNone_SIG, "UCmpSystemTutoDraw::DrawNoTutoBigNone", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp + 0xb8], ${_context._config.CampSystemNoTutorialColor.B:X}",
                    $"mov byte [rbp + 0xb9], ${_context._config.CampSystemNoTutorialColor.G:X}",
                    $"mov byte [rbp + 0xba], ${_context._config.CampSystemNoTutorialColor.R:X}"
                };
                _drawNoTutoBigNone = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemTutoDraw_DrawNoTutoFont_SIG, "UCmpSystemTutoDraw::DrawNoTutoFont", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampSystemNoTutorialColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpSystemTutoDraw_DrawTutoTopTogglerBG_SIG, "UCmpSystemTutoDraw::DrawTutoTopTogglerBG", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp + 0x90], ${_context._config.MainToggler.B:X}",
                    $"mov byte [rbp + 0x91], ${_context._config.MainToggler.G:X}",
                    $"mov byte [rbp + 0x92], ${_context._config.MainToggler.R:X}"
                };
                _DrawTutoTopTogglerBG = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(UCmpSystemTutoDraw_LeftArrowRed1_SIG, "UCmpSystemTutoDraw::LeftArrowRed1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.R):X}",
                    "movd xmm0, eax",
                };
                _LeftArrowRed1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemTutoDraw_LeftArrowGreen1_SIG, "UCmpSystemTutoDraw::LeftArrowGreen1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.G):X}",
                    "movd xmm0, eax",
                };
                _LeftArrowGreen1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemTutoDraw_LeftArrowBlue1_SIG, "UCmpSystemTutoDraw::LeftArrowBlue1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.B):X}",
                    "movd xmm0, eax",
                };
                _LeftArrowBlue1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemTutoDraw_LeftArrowRed2_SIG, "UCmpSystemTutoDraw::LeftArrowRed2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.R):X}",
                    "movd xmm0, eax",
                };
                _LeftArrowRed2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemTutoDraw_LeftArrowGreen2_SIG, "UCmpSystemTutoDraw::LeftArrowGreen2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.G):X}",
                    "movd xmm0, eax",
                };
                _LeftArrowGreen2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemTutoDraw_LeftArrowBlue2_SIG, "UCmpSystemTutoDraw::LeftArrowBlue2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.B):X}",
                    "movd xmm0, eax",
                };
                _LeftArrowBlue2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemTutoDraw_RightArrowRed1_SIG, "UCmpSystemTutoDraw::RightArrowRed1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.R):X}",
                    "movd xmm0, eax",
                };
                _RightArrowRed1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemTutoDraw_RightArrowGreen1_SIG, "UCmpSystemTutoDraw::RightArrowGreen1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.G):X}",
                    "movd xmm0, eax",
                };
                _RightArrowGreen1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemTutoDraw_RightArrowBlue1_SIG, "UCmpSystemTutoDraw::RightArrowBlue1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.B):X}",
                    "movd xmm0, eax",
                };
                _RightArrowBlue1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemTutoDraw_RightArrowRed2_SIG, "UCmpSystemTutoDraw::RightArrowRed2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.R):X}",
                    "movd xmm0, eax",
                };
                _RightArrowRed2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemTutoDraw_RightArrowGreen2_SIG, "UCmpSystemTutoDraw::RightArrowGreen2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.G):X}",
                    "movd xmm0, eax",
                };
                _RightArrowGreen2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemTutoDraw_RightArrowBlue2_SIG, "UCmpSystemTutoDraw::RightArrowBlue2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.B):X}",
                    "movd xmm0, eax",
                };
                _RightArrowBlue2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(UCmpSystemConfigDraw_DrawConfigTopMainTogglerBG_SIG, "UCmpSystemConfigDraw::DrawConfigTopMainTogglerBG", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp + 0x80], ${_context._config.MainToggler.B:X}",
                    $"mov byte [rbp + 0x81], ${_context._config.MainToggler.G:X}",
                    $"mov byte [rbp + 0x82], ${_context._config.MainToggler.R:X}"
                };
                _DrawConfigTopMainTogglerBG = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemConfigDraw_DrawConfigTopSecondaryTogglerBG_SIG, "UCmpSystemConfigDraw::DrawConfigTopSecondaryTogglerBG", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp + 0x6F], ${_context._config.SecondaryToggler.B:X}",
                    $"mov byte [rbp + 0x70], ${_context._config.SecondaryToggler.G:X}",
                    $"mov byte [rbp + 0x71], ${_context._config.SecondaryToggler.R:X}"
                };
                _DrawConfigTopSecondaryTogglerBG = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(UCmpSystemConfigDraw_ArrowRed1_SIG, "UCmpSystemConfigDraw::ArrowRed1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.R):X}",
                    "movd xmm0, eax",
                };
                _ArrowRed1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemConfigDraw_ArrowGreen1_SIG, "UCmpSystemConfigDraw::ArrowGreen1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.G):X}",
                    "movd xmm0, eax",
                };
                _ArrowGreen1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemConfigDraw_ArrowBlue1_SIG, "UCmpSystemConfigDraw::ArrowBlue1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedLowerColor.B):X}",
                    "movd xmm0, eax",
                };
                _ArrowBlue1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemConfigDraw_ArrowRed2_SIG, "UCmpSystemConfigDraw::ArrowRed2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.R):X}",
                    "movd xmm0, eax",
                };
                _ArrowRed2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemConfigDraw_ArrowGreen2_SIG, "UCmpSystemConfigDraw::ArrowGreen2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.G):X}",
                    "movd xmm0, eax",
                };
                _ArrowGreen2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpSystemConfigDraw_ArrowBlue2_SIG, "UCmpSystemConfigDraw::ArrowBlue2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov eax, 0x{BitConverter.SingleToInt32Bits((float)_context._config.CampHighlightedMidColor.B):X}",
                    "movd xmm0, eax",
                };
                _ArrowBlue2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
            _campCommon = GetModule<CampCommon>();
        }

        private unsafe FSprColor GetMatchingColorForEntry(int entryId)
        {
            if (entryId % 3 == 0) return ConfigColor.ToFSprColor(_context._config.CampMenuSystemItemColor1);
            else if (entryId % 3 == 1) return ConfigColor.ToFSprColor(_context._config.CampMenuSystemItemColor2);
            else /*(entryId % 3 == 2)*/ return ConfigColor.ToFSprColor(_context._config.CampMenuSystemItemColor3);
        }

        private unsafe FSprColor UCmpSystemDraw_GetMenuColorNoSelectImpl() => ConfigColor.ToFSprColor(_context._config.CampMenuSystemItemColorNoSel);

        private unsafe void UCmpSystemDraw_DrawUnhighlightedMenuOptionsImpl(UCmpSystemDraw* self, UCmpSystemSystem* sys, uint activeId, uint queueId)
        {
            for (int i = 0; i < SystemOptionCount; i++) _systemOptionColors[i] = GetMatchingColorForEntry(i);
            _drawUnhighlightOptions.OriginalFunction(self, sys, activeId, queueId);
        }
        private unsafe delegate void UCmpSystemDraw_DrawUnhighlightedMenuOptions(UCmpSystemDraw* self, UCmpSystemSystem* sys, uint activeId, uint queueId);
        [Function(new Register[] {}, FunctionAttribute.Register.rdi, false)]
        private unsafe delegate FSprColor UCmpSystemDraw_GetMenuColorNoSelect();
    }
}
