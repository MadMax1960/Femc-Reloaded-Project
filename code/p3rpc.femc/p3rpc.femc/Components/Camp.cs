using p3rpc.femc.Native;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using Reloaded.Hooks.Definitions.X64;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Reloaded.Hooks.Definitions.X64.FunctionAttribute;

namespace p3rpc.femc.Components
{
    public class CampCommon : ModuleBase
    {

        public unsafe CampCommon(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {

        }

        public override void Register()
        {

        }
    }
    public class CampRoot : ModuleBase
    {
        private string ACmpMainActor_GetCampParamTableCommon_SIG = "E8 ?? ?? ?? ?? 48 8B D8 83 FF 0C"; // inside of ACmpMainActor::DrawBackgroundUpdateInner
        private string UCmpRootDraw_DrawMenuItems_SetColorsASM_SIG = "89 7D ?? 44 8B F8 89 5D ??";
        private IHook<ACmpMainActor_GetCampParamTableCommon> _getCmpMainParams;
        private IAsmHook _setMenuItemColorsHook;

        private CampCommon _campCommon;

        public unsafe CampRoot(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
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
        }

        public override void Register()
        {
            _campCommon = GetModule<CampCommon>();
        }
        private unsafe FCampParamTableCommonRow* ACmpMainActor_GetCampParamTableCommonImpl(ACmpMainActor* self)
        {
            // dynamically change color values for Xrd777/UI/Camp/Param/DT_CampParamCommon.uasset
            var return_value = _getCmpMainParams.OriginalFunction(self);
            return_value->AoItaColorHigh.SetColor(_context._config.CampHighColor);
            return_value->AoItaColorMid.SetColor(_context._config.CampMiddleColor);
            return_value->AoItaColorLow.SetColor(_context._config.CampLowColor);
            return_value->GradADownColorHigh.SetColor(_context._config.CampHighColor);
            return_value->GradADownColorMid.SetColor(_context._config.CampMiddleColor);
            return_value->GradADownColorLow.SetColor(_context._config.CampLowColor);
            return return_value;
        }

        private unsafe delegate FCampParamTableCommonRow* ACmpMainActor_GetCampParamTableCommon(ACmpMainActor* self);
    }

    public class CampSkill : ModuleBase
    {
        private string UCmpSkillDraw_DrawNoUsableSkillNoneGraphic_SIG = "41 B9 FF EF DB 00"; // UCmpSkillDraw::DrawUseSkillOptions
        private string UCmpSkillDraw_DrawNoUsableSkillDescription_SIG = "C7 45 ?? FF EF DB 00"; // UCmpSkillDraw::DrawUseSkillOptions
        // TODO: UCmpSkillDraw::DrawPartyMemberHealSkillEntries

        private IAsmHook _drawNoUsableSkillNoneGraphic;
        private IAsmHook _drawNoUsableSkillDescription;

        private IReverseWrapper<UCmpSkillDraw_DrawNoUsableSkillNoneGraphic> _drawNoUsableSkillNoneGraphicWrapper;

        private CampCommon _campCommon;
        public unsafe CampSkill(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
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
            _context._utils.SigScan(UCmpSkillDraw_DrawNoUsableSkillDescription_SIG, "UCmpSkillDraw::DrawNoUsableSkillDescription", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rbp - 0x24], {_context._config.CampSkillTextColor.ToU32()}",
                };
                _drawNoUsableSkillDescription = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteAfter).Activate();
            });
        }

        public override void Register()
        {
            _campCommon = GetModule<CampCommon>();
        }
        private FSprColor UCmpSkillDraw_DrawNoUsableSkillNoneGraphicImpl() => new FSprColor(_context._config.CampSkillTextColor);

        [Function(new Register[] { }, FunctionAttribute.Register.r9, false)]
        private delegate FSprColor UCmpSkillDraw_DrawNoUsableSkillNoneGraphic();
    }

    public class CampItem : ModuleBase
    {
        private string ACmpMainActor_SetHeroTexTintItemMenu_SIG = "0F 44 D8 41 80 BF ?? ?? ?? ?? 06"; // bottom color, then top color
        private CampCommon _campCommon;

        private IAsmHook _texTintColor;
        public unsafe CampItem(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
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
        }

        public override void Register()
        {
            _campCommon = GetModule<CampCommon>();
        }
    }

    public class CampEquip : ModuleBase
    {
        private CampCommon _campCommon;

        public unsafe CampEquip(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {

        }
        public override void Register()
        {
            _campCommon = GetModule<CampCommon>();
        }
    }

    public class CampPersona : ModuleBase
    {
        private CampCommon _campCommon;

        public unsafe CampPersona(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {

        }
        public override void Register()
        {
            _campCommon = GetModule<CampCommon>();
        }
    }

    public class CampSystem : ModuleBase 
    {
        private string UCmpSystemDraw_GetMenuColors_SIG = "43 8B 94 ?? ?? ?? ?? ?? 41 0F 28 D4";
        private string UCmpSystemDraw_DrawUnhighlightedMenuOptions_SIG = "48 8B C4 48 89 58 ?? 44 89 48 ?? 44 89 40 ?? 55 56 57 41 54 41 55 41 56 41 57 48 81 EC 40 01 00 00";
        private IHook<UCmpSystemDraw_DrawUnhighlightedMenuOptions> _drawUnhighlightOptions;

        private unsafe FSprColor* _systemOptionColors;
        private static int SystemOptionCount = 7;

        private CampCommon _campCommon;
        public unsafe CampSystem(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(UCmpSystemDraw_DrawUnhighlightedMenuOptions_SIG, "UCmpSystemDraw::DrawUnhighlightedMenuOptions", _context._utils.GetDirectAddress, addr => _drawUnhighlightOptions = _context._utils.MakeHooker<UCmpSystemDraw_DrawUnhighlightedMenuOptions>(UCmpSystemDraw_DrawUnhighlightedMenuOptionsImpl, addr));
            _context._utils.SigScan(UCmpSystemDraw_GetMenuColors_SIG, "UCmpSystemDraw_MenuOptionColors", trans => (nuint)(_context._baseAddress + *(int*)(_context._baseAddress + trans + 4)), addr => _systemOptionColors = (FSprColor*)addr);
        }

        public override void Register()
        {
            _campCommon = GetModule<CampCommon>();
        }

        private unsafe FSprColor GetMatchingColorForEntry(int entryId)
        {
            if (entryId % 3 == 0) return new FSprColor(_context._config.CampMenuItemColor1);
            else if (entryId % 3 == 1) return new FSprColor(_context._config.CampMenuItemColor2);
            else /*(entryId % 3 == 2)*/ return new FSprColor(_context._config.CampMenuItemColor3);
        }

        private unsafe void UCmpSystemDraw_DrawUnhighlightedMenuOptionsImpl(UCmpSystemDraw* self, UCmpSystemSystem* sys, uint activeId, uint queueId)
        {
            for (int i = 0; i < SystemOptionCount; i++) _systemOptionColors[i] = GetMatchingColorForEntry(i);
            _drawUnhighlightOptions.OriginalFunction(self, sys, activeId, queueId);
        }
        private unsafe delegate void UCmpSystemDraw_DrawUnhighlightedMenuOptions(UCmpSystemDraw* self, UCmpSystemSystem* sys, uint activeId, uint queueId);
    }
}
