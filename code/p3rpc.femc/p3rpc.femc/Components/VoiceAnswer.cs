using p3rpc.commonmodutils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class VoiceAction : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string AUIVoiceActionDraw_DrawDailyActionStickyNoteColors_SIG = "C7 44 24 ?? F0 E3 CD FF";
        private string AUIVoiceActionDraw_DrawBlueBoardColor_SIG = "C7 45 ?? C9 2F 00 FF E8 ?? ?? ?? ??";
        private string AUIVoiceActionDraw_DrawBlueBoardColor2_SIG = "C7 45 ?? 2E 13 10 E5 C7 45 ?? 00 00 00 00";
        private string AUIVoiceActionDraw_DrawNetworkIconColor_SIG = "C7 45 ?? C9 2F 00 FF C7 45 ?? 00 00 00 00";
        private string AUIVoiceActionDraw_DrawNetworkIconSecondColor_SIG = "C7 45 ?? C9 2F 00 FF 74 ?? F3 0F 10 35 ?? ?? ?? ??";
        public unsafe VoiceAction(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUIVoiceActionDraw_DrawDailyActionStickyNoteColors_SIG, "AUIVoiceActionDraw::DrawDailyActionStickyNoteColors", _context._utils.GetDirectAddress, addr =>
            {
                var textAddr1 = (nuint)addr;
                var textAddr2 = (nuint)(addr + 0x8);
                var bgAddr1 = (nuint)(addr + 0x10);
                var bgAddr2 = (nuint)(addr + 0x18);
                var dotAddr1 = (nuint)(addr + 0x2f);
                var dotAddr2 = (nuint)(addr + 0x37);
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, textAddr1, addr => _context._memory.Write(addr + 4, _context._config.NetworkDailyActionStickyNoteTextColor1.ToU32ARGB())));
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, textAddr2, addr => _context._memory.Write(addr + 4, _context._config.NetworkDailyActionStickyNoteTextColor2.ToU32ARGB())));
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, bgAddr1, addr => _context._memory.Write(addr + 4, _context._config.NetworkDailyActionStickyNoteBgColor1.ToU32ARGB())));
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, bgAddr2, addr => _context._memory.Write(addr + 4, _context._config.NetworkDailyActionStickyNoteBgColor2.ToU32ARGB())));
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, dotAddr1, addr => _context._memory.Write(addr + 4, _context._config.NetworkDailyActionStickyNoteDotColor1.ToU32ARGB())));
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, dotAddr2, addr => _context._memory.Write(addr + 3, _context._config.NetworkDailyActionStickyNoteDotColor2.ToU32ARGB())));
            });
            _context._utils.SigScan(AUIVoiceActionDraw_DrawBlueBoardColor_SIG, "AUIVoiceActionDraw::DrawBlueBoardColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.NetworkDailyActionBlueBgColor.ToU32ARGB())));
            });
            _context._utils.SigScan(AUIVoiceActionDraw_DrawBlueBoardColor2_SIG, "AUIVoiceActionDraw::DrawBlueBoardColor2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.NetworkDailyActionSecondBlueBgColor.ToU32ARGB())));
            });
            _context._utils.SigScan(AUIVoiceActionDraw_DrawNetworkIconColor_SIG, "AUIVoiceActionDraw::DrawNetworkIconColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.NetworkDailyActionNetworkIcon.ToU32ARGB())));
            });
            _context._utils.SigScan(AUIVoiceActionDraw_DrawNetworkIconSecondColor_SIG, "AUIVoiceActionDraw::DrawNetworkIconSecondColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.NetworkDailyActionNetworkIcon.ToU32ARGB())));
            });
        }
        public override void Register() { }
    }

    public class VoiceAnswer : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string AUIVoiceAnswerDraw_DrawBlueBoardColor_SIG = "C7 40 ?? C9 2F 00 FF";
        private string AUIVoiceAnswerDraw_DrawNetworkIconColor_SIG = "C7 45 ?? C9 2F 00 FF 74 ?? 48 8B 81 ?? ?? ?? ??";
        private string AUIVoiceAnswerDraw_DrawNetworkIconSecondColor_SIG = "C7 45 ?? C9 2F 00 FF 74 ?? 48 8B 87 ?? ?? ?? ??";
        public unsafe VoiceAnswer(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUIVoiceAnswerDraw_DrawBlueBoardColor_SIG, "AUIVoiceAnswerDraw::DrawBlueBoardColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.NetworkDailyActionBlueBgColor.ToU32ARGB())));
            });
            _context._utils.SigScan(AUIVoiceAnswerDraw_DrawNetworkIconColor_SIG, "AUIVoiceAnswerDraw::DrawNetworkIconColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.NetworkDailyActionNetworkIcon.ToU32ARGB())));
            });
            _context._utils.SigScan(AUIVoiceAnswerDraw_DrawNetworkIconSecondColor_SIG, "AUIVoiceAnswerDraw::DrawNetworkIconSecondColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.NetworkDailyActionNetworkIcon.ToU32ARGB())));
            });
        }
        public override void Register() { }
    }
}
