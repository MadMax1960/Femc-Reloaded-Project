using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using Reloaded.Hooks.Definitions.X64;
using Reloaded.Memory.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Reloaded.Hooks.Definitions.X64.FunctionAttribute;

namespace p3rpc.femc.Components
{
    public class CampCommon : ModuleBase<FemcContext>
    {

        public unsafe CampCommon(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {

        }

        public override void Register()
        {

        }
    }
    public class CampRoot : ModuleBase<FemcContext>
    {
        private string ACmpMainActor_GetCampParamTableCommon_SIG = "E8 ?? ?? ?? ?? 48 8B D8 83 FF 0C"; // inside of ACmpMainActor::DrawBackgroundUpdateInner
        private string UCmpRootDraw_DrawMenuItems_SetColorsASM_SIG = "89 7D ?? 44 8B F8 89 5D ??";
        //private string UCmpRootDraw_DrawMenuItems_SetColorsNoSel_SIG = "0F 10 45 00 41 B8 01 00 00 00";
        private string UCmpRootDraw_DrawMenuItems_SetColorsNoSel_SIG = "E8 ?? ?? ?? ?? 0F 10 45 00 41 B8 01 00 00 00";
        private IHook<ACmpMainActor_GetCampParamTableCommon> _getCmpMainParams;
        private IAsmHook _setMenuItemColorsHook;
        private IAsmHook _setMenuItemColorNoSel;
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

        private IAsmHook _drawNoUsableSkillNoneGraphic;
        private IAsmHook _drawNoUsableSkillDescription;

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
        private string ACmpMainActor_SetHeroTexTintItemMenu_SIG = "0F 44 D8 41 80 BF ?? ?? ?? ?? 06"; // bottom color, then top color
        private string UCmpItemDraw_SetNoItemColor_SIG = "41 81 CC 00 EF DB 00";
        private string UCmpItemDraw_ListTextNoSelect_SIG = "81 CB 00 EA C2 08 F3 0F 10 35 ?? ?? ?? ??";
        private string UCmpItemDraw_ListTextCanSelect_SIG = "81 CB 00 FF FF 00";
        private string UCmpItemDraw_ListTextCurrNoSel_SIG = "81 CB 00 53 53 53";

        private IAsmHook _texTintColor;

        private UICommon _uiCommon;
        private CampCommon _campCommon;
        public unsafe CampItem(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(ACmpMainActor_SetHeroTexTintItemMenu_SIG, "ACmpMainActor::SetHeroTexTintItemMenu", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov ecx, {_context._config.CampItemMenuCharacterTopColor.ToU32()}",
                    $"mov eax, {_context._config.CampItemMenuCharacterBottomColor.ToU32()}",
                };
                _texTintColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
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
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
            _campCommon = GetModule<CampCommon>();
        }
    }

    public class CampEquip : ModuleBase<FemcContext>
    {
        private UICommon _uiCommon;
        private CampCommon _campCommon;

        public unsafe CampEquip(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {

        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
            _campCommon = GetModule<CampCommon>();
        }
    }

    public class CampPersona : ModuleBase<FemcContext>
    {
        private UICommon _uiCommon;
        private CampCommon _campCommon;

        public unsafe CampPersona(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {

        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
            _campCommon = GetModule<CampCommon>();
        }
    }

    public class CampStats : ModuleBase<FemcContext>
    {
        private UICommon _uiCommon;
        private CampCommon _campCommon;

        public unsafe CampStats(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {

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

        public unsafe CampQuest(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {

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
        private string UCmpCommuList_DrawSocialLinkList_GetSocialLinkColors_SIG = "41 BF 00 FF FF FF 44 0F 44 F9";

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
            // UCmpCommuList::DrawSocialLinkList
            _context._utils.SigScan(UCmpCommuList_DrawSocialLinkList_GetSocialLinkColors_SIG, "UCmpCommuList::GetSocialLinkColors", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UCmpCommuList_GetSocialLinkLightColorImpl, out _getSocialLinkLightColor)}",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UCmpCommuList_GetSocialLinkDarkColorImpl, out _getSocialLinkDarkColor)}",
                };
                _getSocialLinkColors = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
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

        private IAsmHook _calendarSundayColor;
        private IAsmHook _calendarSundayDay;
        private IAsmHook _monthsPrevMonth;
        private IAsmHook _monthsCurrMonth;
        private IAsmHook _monthsNextMonth;
        private IAsmHook _dateBg;

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
                var gWork = _uiCommon._getUGlobalWork();
                var bgColor = gWork->Calendar.TimeOfDay switch
                {
                    ECldTimeZone.Night | ECldTimeZone.Shadow | ECldTimeZone.Midnight 
                    => ConfigColor.ToFColorBP(_context._config.CampCalendarHighlightColor),
                    _ => ConfigColor.ToFColorBP(_context._config.CampCalendarHighlightColor),
                };
                _uiCommon._drawPlg(&self->DrawSpr, x - 4, fy - 4, 0, &bgColor, 0xa3, 1, 1, 0, campPlg, self->CalendarDrawQueue);
                var textPos = new FVector2D(x, fy);
                var textColor = ConfigColor.ToFColorBP(_context._config.CampCalendarTextColor);
                if (self->pMainActor != null)
                {
                    var layoutTable2 = self->pMainActor->OthersLayoutDataTable->GetLayoutDataTableEntry(2);
                    textPos.X += layoutTable2->position.X;
                    textPos.Y += layoutTable2->position.Y;
                }
                _uiCommon._drawSpr(&self->DrawSpr, textPos.X, textPos.Y, 0, &textColor, 0x4fc, 1, 1, 0, campSpr, EUI_DRAW_POINT.UI_DRAW_RIGHT_TOP, self->CalendarDrawQueue);
            }
        }

        private unsafe delegate void UUICmpCalendarDraw_DrawUIComponent(UUICmpCalendarDraw* self, float x, float y, float angle); // angle, degrees
    }

    public class CampSystem : ModuleBase<FemcContext>
    {
        private string UCmpSystemDraw_GetMenuColors_SIG = "43 8B 94 ?? ?? ?? ?? ?? 41 0F 28 D4";
        private string UCmpSystemDraw_DrawUnhighlightedMenuOptions_SIG = "48 8B C4 48 89 58 ?? 44 89 48 ?? 44 89 40 ?? 55 56 57 41 54 41 55 41 56 41 57 48 81 EC 40 01 00 00";
        private string UCmpSystemDraw_GetMenuColorNoSelect_SIG = "4D 8B 24 ?? 83 FB 06"; // or edi, 0x13389500
        //private string UCmpSystemDraw_GetMenuColorNoSelect_SIG = "81 CF 00 95 38 13"; // or edi, 0x13389500

        private IHook<UCmpSystemDraw_DrawUnhighlightedMenuOptions> _drawUnhighlightOptions;
        private IAsmHook _getMenuColorNoSel;
        private IReverseWrapper<UCmpSystemDraw_GetMenuColorNoSelect> _getMenuColorNoSelWrapper;

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
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
            _campCommon = GetModule<CampCommon>();
        }

        private unsafe FSprColor GetMatchingColorForEntry(int entryId)
        {
            if (entryId % 3 == 0) return ConfigColor.ToFSprColor(_context._config.CampMenuItemColor1);
            else if (entryId % 3 == 1) return ConfigColor.ToFSprColor(_context._config.CampMenuItemColor2);
            else /*(entryId % 3 == 2)*/ return ConfigColor.ToFSprColor(_context._config.CampMenuItemColor3);
        }

        private unsafe FSprColor UCmpSystemDraw_GetMenuColorNoSelectImpl() => ConfigColor.ToFSprColor(_context._config.CampMenuItemColorNoSel);

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
