using p3rpc.commonmodutils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class Wipe : ModuleAsmInlineColorEdit<FemcContext>
    {
        // In UFadePgSlide::DrawFade
        
        // a2->Field34 == 2
        private string UFadePgSlide_WipeInColor1_SIG = "C7 44 24 ?? BF 51 18 05 41 8B D7 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? F3 0F 10 47 ?? 0F 28 D0";
        private string UFadePgSlide_WipeInColor2_SIG = "C7 44 24 ?? BF 51 18 05 BA 03 00 00 00 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? F3 0F 10 47 ??";
        private string UFadePgSlide_WipeInColor3_SIG = "C7 44 24 ?? BF 51 18 05 41 8B D6 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? F3 0F 10 47 ?? 0F 28 D0";
        private string UFadePgSlide_WipeInColor4_SIG = "C7 44 24 ?? BF 51 18 05 BA 05 00 00 00 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? F3 0F 10 57 ??";
        // a2->Field34 == 1
        private string UFadePgSlide_WipeOutColor1_SIG = "C7 44 24 ?? BF 51 18 05 41 8B D7 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? 0F B6 47 ?? F3 0F 10 4F ??";
        private string UFadePgSlide_WipeOutColor2_SIG = "C7 44 24 ?? BF 51 18 05 BA 03 00 00 00 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? 0F B6 47 ??";
        private string UFadePgSlide_WipeOutColor3_SIG = "C7 44 24 ?? BF 51 18 05 41 8B D6 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? 0F B6 47 ?? F3 0F 10 4F ??";
        private string UFadePgSlide_WipeOutColor4_SIG = "C7 44 24 ?? BF 51 18 05 BA 05 00 00 00 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? 0F B6 4F ?? F3 0F 10 5F ?? 0F 28 CB";
        // a2->Field34 == 0
        public unsafe Wipe(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(UFadePgSlide_WipeInColor1_SIG, "UFadePgSlide::WipeInColor1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlide_WipeInColor2_SIG, "UFadePgSlide::WipeInColor2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlide_WipeInColor3_SIG, "UFadePgSlide::WipeInColor3", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlide_WipeInColor4_SIG, "UFadePgSlide::WipeInColor4", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlide_WipeOutColor1_SIG, "UFadePgSlide::WipeOutColor1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlide_WipeOutColor2_SIG, "UFadePgSlide::WipeOutColor2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlide_WipeOutColor3_SIG, "UFadePgSlide::WipeOutColor3", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlide_WipeOutColor4_SIG, "UFadePgSlide::WipeOutColor4", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
        }
        public override void Register()
        {

        }
    }
}
