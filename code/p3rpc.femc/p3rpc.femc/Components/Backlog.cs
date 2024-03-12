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
    public class Backlog : ModuleAsmInlineColorEdit
    {
        private UICommon _uiCommon;

        private string AUIBackLogDraw_DrawBackgroundColor_SIG = "48 8B C4 53 57 48 81 EC 18 01 00 00 0F 29 70 ?? 48 8B F9";
        private string AUIBackLogDraw_DrawLogTitleColor_SIG = "F3 0F 59 05 ?? ?? ?? ?? F3 0F 2C C0 F3 0F 10 83 ?? ?? ?? ??";
        private string AUIBackLogDraw_DrawCalendarTimeOfDayColor_SIG = "48 8B 40 ?? 44 8B 84 24 ?? ?? ?? ?? 66 C7 44 24 ?? 76 FF";
        private string AUIBackLogDraw_DrawTitleColorUnselected_SIG = "41 BD 00 8F 91 03 66 66 66 0F 1F 84 ?? 00 00 00 00";
        private string AUIBackLogDraw_DrawTitleColorUnselected2_SIG = "41 BD 00 8F 91 03 8B 8D ?? ?? ?? ??";
        private string AUIBackLogDraw_DrawTitleColorSelected_SIG = "BE 00 DC DF 05";
        private string AUIBackLogDraw_DrawSpeakerHighlight_SIG = "8B 44 24 ?? F3 0F 5C 05 ?? ?? ?? ??";
        private IHook<AUIBackLogDraw_DrawBackgroundColor> _drawBgColor;

        private IAsmHook _drawLogTitleColor;
        private IAsmHook _drawCalendarTimeOfDay;

        public unsafe Backlog(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUIBackLogDraw_DrawBackgroundColor_SIG, "AUIBackLogDraw::DrawBackgroundColor", _context._utils.GetDirectAddress, addr => _drawBgColor = _context._utils.MakeHooker<AUIBackLogDraw_DrawBackgroundColor>(AUIBackLogDraw_DrawBackgroundColorImpl, addr));

            _context._utils.SigScan(AUIBackLogDraw_DrawLogTitleColor_SIG, "AUIBackLogDraw::DrawLogTitleColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp + 0x96], ${_context._config.ButtonPromptHighlightColor.R:X}",
                    $"mov byte [rsp + 0x95], ${_context._config.ButtonPromptHighlightColor.G:X}",
                    $"mov byte [rsp + 0x94], ${_context._config.ButtonPromptHighlightColor.B:X}",
                };
                _drawLogTitleColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIBackLogDraw_DrawCalendarTimeOfDayColor_SIG, "AUIBackLogDraw::DrawCalendarTimeOfDayColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp + 0x82], ${_context._config.DateTimePanelBottomTextColor.R:X}",
                    $"mov byte [rsp + 0x81], ${_context._config.DateTimePanelBottomTextColor.G:X}",
                    $"mov byte [rsp + 0x80], ${_context._config.DateTimePanelBottomTextColor.B:X}",
                };
                _drawCalendarTimeOfDay = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIBackLogDraw_DrawTitleColorUnselected_SIG, "AUIBackLogDraw::DrawTitleColorUnselected", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.BackLogTexColorUnselectedEx.ToU32())));
            });
            _context._utils.SigScan(AUIBackLogDraw_DrawTitleColorUnselected2_SIG, "AUIBackLogDraw::DrawTitleColorUnselected2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.BackLogTexColorUnselectedEx.ToU32())));
            });
            _context._utils.SigScan(AUIBackLogDraw_DrawTitleColorSelected_SIG, "AUIBackLogDraw::DrawTitleColorSelected", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.BackLogTexColorSelected.ToU32())));
            });
            _context._utils.SigScan(AUIBackLogDraw_DrawSpeakerHighlight_SIG, "AUIBackLogDraw::DrawSpeakerHighlight", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp + 0x72], ${_context._config.BackLogTexColorSelected.R:X}",
                    $"mov byte [rsp + 0x71], ${_context._config.BackLogTexColorSelected.G:X}",
                    $"mov byte [rsp + 0x70], ${_context._config.BackLogTexColorSelected.B:X}",
                };
                _drawCalendarTimeOfDay = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        public unsafe void AUIBackLogDraw_DrawBackgroundColorImpl(AUIBackLogDraw* self, uint a2, uint a3, uint a4, uint a5)
        {
            if (self->IconColor.arr_num >= 2)
                _uiCommon.SetColor(ref self->IconColor.allocator_instance[1], _context._config.BackLogTexColorSelected);
            _uiCommon.SetColorIgnoreAlpha(ref self->GladationBoardColor, _context._config.BackLogGladationColor);
            _uiCommon.SetColorIgnoreAlpha(ref self->BlackBoardColor, _context._config.BackLogBlackboardColor);
            _uiCommon.SetColorIgnoreAlpha(ref self->BlueBoardColor, _context._config.BackLogBlueboardColorEx);
            _drawBgColor.OriginalFunction(self, a2, a3, a4, a5);
        }
        public unsafe delegate void AUIBackLogDraw_DrawBackgroundColor(AUIBackLogDraw* self, uint a2, uint a3, uint a4, uint a5);
    }
}
