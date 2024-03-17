using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class GenericSelect : ModuleAsmInlineColorEdit<FemcContext>
    {
        private UICommon _uiCommon;
        private string AUIGenericSelectDraw_UpdateTimes_SIG = "48 8B C4 56 48 81 EC B0 00 00 00 48 8B F1";
        private string AUIGenericSelectDraw_DrawTitleColor_SIG = "C7 44 24 ?? FF 04 00 FF";
        private string AUIGenericSelectDraw_DrawCharacterShadowColor_SIG = "44 88 64 24 ?? E8 ?? ?? ?? ?? F3 0F 10 74 24 ??";
        private IHook<AUIGenericSelectDraw_UpdateTimes> _updateTimes;
        private IAsmHook _characterShadowColor;

        public unsafe GenericSelect(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUIGenericSelectDraw_UpdateTimes_SIG, "AUIGenericSelectDraw::UpdateTimes", _context._utils.GetDirectAddress, addr => _updateTimes = _context._utils.MakeHooker<AUIGenericSelectDraw_UpdateTimes>(AUIGenericSelectDraw_UpdateTimesImpl, addr));
            _context._utils.SigScan(AUIGenericSelectDraw_DrawTitleColor_SIG, "AUIGenericSelectDraw::DrawTitleColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.GenericSelectTitle.ToU32ARGB())));
            });
            _context._utils.SigScan(AUIGenericSelectDraw_DrawCharacterShadowColor_SIG, "AUIGenericSelectDraw::DrawCharacterShadowColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rsp + 0x70], {_context._config.GenericSelectCharacterShadow.ToU32ARGB()}"
                };
                _characterShadowColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        public unsafe void AUIGenericSelectDraw_UpdateTimesImpl(AUIGenericSelectDraw* self, float deltaTime)
        {
            _updateTimes.OriginalFunction(self, deltaTime);
            ConfigColor.SetColor(ref self->Edit_CharacterBackPlate_MorninColor, _context._config.GenericSelectCharacterBackplate);
            ConfigColor.SetColor(ref self->Edit_CharacterBackPlate_AfterschoolColor, _context._config.GenericSelectCharacterBackplate);
            ConfigColor.SetColor(ref self->Edit_CharacterBackPlate_NightColor, _context._config.GenericSelectCharacterBackplate);
            ConfigColor.SetColor(ref self->Edit_ListAndCharacter_MorninColor, _context._config.GenericSelectListColorMorning);
            ConfigColor.SetColor(ref self->Edit_ListAndCharacter_AfterschoolColor, _context._config.GenericSelectListColorAfterSchool);
            ConfigColor.SetColor(ref self->Edit_ListAndCharacter_NightColor, _context._config.GenericSelectListColorNight);
            ConfigColor.SetColor(ref self->Edit_TitleLogo_MorninColor, _context._config.GenericSelectListColorMorning);
            ConfigColor.SetColor(ref self->Edit_TitleLogo_AfterschoolColor, _context._config.GenericSelectListColorAfterSchool);
            ConfigColor.SetColor(ref self->Edit_TitleLogo_NightColor, _context._config.GenericSelectListColorNight);
        }

        public unsafe delegate void AUIGenericSelectDraw_UpdateTimes(AUIGenericSelectDraw* self, float deltaTime);
    }
}
