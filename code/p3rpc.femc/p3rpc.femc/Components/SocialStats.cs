using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class SocialStats : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string ACmpMainActor_GetParamRankUpTable_SIG = "E8 ?? ?? ?? ?? 4C 8B E8 48 89 45 ?? E8 ?? ?? ?? ??";
        private string UCmpHeroHumanStatusDraw_GetStatUp_SIG = "0D 00 FF FF 00 89 44 24 ?? F3 44 0F 11 4C 24 ?? E8 ?? ?? ?? ?? 80 BF ?? ?? ?? ?? 00";
        private string UCmpHeroHumanStatusDraw_GetRankUp_SIG = "0D 00 FF FF 00 89 44 24 ?? F3 44 0F 11 4C 24 ?? E8 ?? ?? ?? ?? 83 7F ?? 02";
        private string UCmpHeroHumanStatusDraw_DrawSocialStatUpCircle_SIG = "4C 8B DC 53 56 41 57 48 81 EC B0 00 00 00";
        private string UCmpHeroHumanStatusDraw_DrawStatUpRings_SIG = "44 88 64 24 ?? 0F 1F 84 ?? 00 00 00 00";
        private string UCmpHeroHumanStatusDraw_DrawStatUpMusicNote1_SIG = "E8 ?? ?? ?? ?? 41 B1 FF 89 45 ?? 45 0F B6 C1 89 45 ?? B2 F6";
        private string UCmpHeroHumanStatusDraw_DrawStatUpMusicNote2_SIG = "E8 ?? ?? ?? ?? 41 B1 FF 89 85 ?? ?? ?? ?? 45 0F B6 C1 89 85 ?? ?? ?? ?? 41 0F B6 D1 41 0F B6 C9 E8 ?? ?? ?? ?? 41 B1 FF B2 F6";
        private IHook<ACmpMainActor_GetParamRankUpTable> _getParamRankUpTable;
        private IHook<UCmpHeroHumanStatusDraw_DrawSocialStatUpCircle> _drawSocialStatUpCircle;
        private IAsmHook _drawStatUpRings;
        private IAsmHook _drawStatUpMusicNote1;
        private IAsmHook _drawStatUpMusicNote2;
        private UICommon _uiCommon;
        public unsafe SocialStats(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(ACmpMainActor_GetParamRankUpTable_SIG, "ACmpMainActor::GetParamRankUpTable", _context._utils.GetIndirectAddressShort, addr => _getParamRankUpTable = _context._utils.MakeHooker<ACmpMainActor_GetParamRankUpTable>(ACmpMainActor_GetParamRankUpTableImpl, addr));
            _context._utils.SigScan(UCmpHeroHumanStatusDraw_GetStatUp_SIG, "UCmpHeroHumanStatusDraw::GetStatUp", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.SocialStatsUpText.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpHeroHumanStatusDraw_GetRankUp_SIG, "UCmpHeroHumanStatusDraw::GetRankUp", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.SocialStatsUpText.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UCmpHeroHumanStatusDraw_DrawSocialStatUpCircle_SIG, "UCmpHeroHumanStatusDraw::DrawSocialStatUpCircle", _context._utils.GetDirectAddress, addr => _drawSocialStatUpCircle = _context._utils.MakeHooker<UCmpHeroHumanStatusDraw_DrawSocialStatUpCircle>(UCmpHeroHumanStatusDraw_DrawSocialStatUpCircleImpl, addr));
            _context._utils.SigScan(UCmpHeroHumanStatusDraw_DrawStatUpRings_SIG, "UCmpHeroHumanStatusDraw::DrawStatUpRings", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rsp + 0x74], {_context._config.SocialStatsPulseCircleColorMain.ToU32ARGB()}",
                };
                _drawStatUpRings = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpHeroHumanStatusDraw_DrawStatUpMusicNote1_SIG, "UCmpHeroHumanStatusDraw::DrawStatUpMusicNote1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.MusicNotesColor.B:X}",
                    $"mov dl, ${_context._config.MusicNotesColor.G:X}",
                    $"mov cl, ${_context._config.MusicNotesColor.R:X}"
                };
                _drawStatUpMusicNote1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UCmpHeroHumanStatusDraw_DrawStatUpMusicNote2_SIG, "UCmpHeroHumanStatusDraw::DrawStatUpMusicNote1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.MusicNotesColor.B:X}",
                    $"mov dl, ${_context._config.MusicNotesColor.G:X}",
                    $"mov cl, ${_context._config.MusicNotesColor.R:X}"
                };
                _drawStatUpMusicNote2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }
        private unsafe FCampParamTableRankUpRow* ACmpMainActor_GetParamRankUpTableImpl(ACmpMainActor* self)
        {
            var returned_table = _getParamRankUpTable.OriginalFunction(self);
            ConfigColor.SetColor(ref returned_table->HumanBrainBlue, _context._config.SocialStatsCircleAcademicsColor);
            ConfigColor.SetColor(ref returned_table->CampHumanBrainBlue, _context._config.SocialStatsCircleAcademicsColor);
            ConfigColor.SetColor(ref returned_table->HumanCharmBlue, _context._config.SocialStatsCircleCharmColor);
            ConfigColor.SetColor(ref returned_table->CampHumanCharmBlue, _context._config.SocialStatsCircleCharmColor);
            ConfigColor.SetColor(ref returned_table->HumanCourageBlue, _context._config.SocialStatsCircleCourageColor);
            ConfigColor.SetColor(ref returned_table->CampHumanCourageBlue, _context._config.SocialStatsCircleCourageColor);
            //ConfigColor.SetColor(ref returned_table->HumanPointUpLightblue, _context._config.SocialStatsPulseCircleColorFade);
            return returned_table;
        }
        private unsafe void UCmpHeroHumanStatusDraw_DrawSocialStatUpCircleImpl(UCmpHeroHumanStatusDraw* self, byte a2, nint a3, nint a4, float a5, float a6, float a7, int a8, float a9, float a10, float a11)
        {
            self->statUpPulseFadeColor = new FColor(self->statUpPulseFadeColor.A, _context._config.SocialStatsPulseCircleColorFade.B, _context._config.SocialStatsPulseCircleColorFade.G, _context._config.SocialStatsPulseCircleColorFade.R);
            self->statUpPulseMainColor = new FColor(self->statUpPulseMainColor.A, _context._config.SocialStatsPulseCircleColorMain.B, _context._config.SocialStatsPulseCircleColorMain.G, _context._config.SocialStatsPulseCircleColorMain.R);
            _drawSocialStatUpCircle.OriginalFunction(self, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11);
        }

        private unsafe delegate FCampParamTableRankUpRow* ACmpMainActor_GetParamRankUpTable(ACmpMainActor* self);
        private unsafe delegate void UCmpHeroHumanStatusDraw_DrawSocialStatUpCircle(UCmpHeroHumanStatusDraw* self, byte a2, nint a3, nint a4, float a5, float a6, float a7, int a8, float a9, float a10, float a11);
    }
}
