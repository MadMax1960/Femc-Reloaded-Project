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
        // TODO: See if there's a better way to do this lol (each corner of the fade rectangle has it's own decl of the fade color value even though it's all the same color)
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
        // ...
        // In UFadePgSlideVertical::DrawFade
        // a2->Field34 == 2
        private string UFadePgSlideVertical_WipeInColor1_SIG = "C7 44 24 ?? BF 51 18 05 BA 06 00 00 00 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? F3 0F 10 5F ??";
        private string UFadePgSlideVertical_WipeInColor2_SIG = "C7 44 24 ?? BF 51 18 05 41 8B D6 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? F3 0F 10 47 ?? 0F 28 D8";
        private string UFadePgSlideVertical_WipeInColor3_SIG = "C7 44 24 ?? BF 51 18 05 BA 07 00 00 00 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? F3 0F 10 47 ??";
        private string UFadePgSlideVertical_WipeInColor4_SIG = "C7 44 24 ?? BF 51 18 05 41 8B D7 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? F3 0F 10 47 ?? 0F 28 D8";
        private string UFadePgSlideVertical_WipeInColor5_SIG = "C7 44 24 ?? BF 51 18 05 BA 08 00 00 00 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? F3 0F 10 5F ??";
        private string UFadePgSlideVertical_WipeInColor6_SIG = "C7 44 24 ?? BF 51 18 05 BA 05 00 00 00 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? F3 0F 10 5F ??";
        // a2->Field34 == 1
        private string UFadePgSlideVertical_WipeOutColor1_SIG = "C7 44 24 ?? BF 51 18 05 BA 06 00 00 00 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? 0F B6 47 ??";
        private string UFadePgSlideVertical_WipeOutColor2_SIG = "C7 44 24 ?? BF 51 18 05 41 8B D6 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? 0F B6 47 ?? F3 0F 10 47 ??";
        private string UFadePgSlideVertical_WipeOutColor3_SIG = "C7 44 24 ?? BF 51 18 05 BA 07 00 00 00 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? 0F B6 47 ??";
        private string UFadePgSlideVertical_WipeOutColor4_SIG = "C7 44 24 ?? BF 51 18 05 41 8B D7 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? 0F B6 47 ?? F3 0F 10 47 ??";
        private string UFadePgSlideVertical_WipeOutColor5_SIG = "C7 44 24 ?? BF 51 18 05 BA 08 00 00 00 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? 0F B6 47 ??";
        private string UFadePgSlideVertical_WipeOutColor6_SIG = "C7 44 24 ?? BF 51 18 05 BA 05 00 00 00 F3 0F 11 74 24 ?? E8 ?? ?? ?? ?? 0F B6 4F ?? F3 0F 10 5F ?? F3 0F 10 57 ??";
        public unsafe Wipe(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            // Fade Slide
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
            // Fade Vertical Slide
            _context._utils.SigScan(UFadePgSlideVertical_WipeInColor1_SIG, "UFadePgSlideVertical::WipeInColor1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlideVertical_WipeInColor2_SIG, "UFadePgSlideVertical::WipeInColor2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlideVertical_WipeInColor3_SIG, "UFadePgSlideVertical::WipeInColor3", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlideVertical_WipeInColor4_SIG, "UFadePgSlideVertical::WipeInColor4", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlideVertical_WipeInColor5_SIG, "UFadePgSlideVertical::WipeInColor5", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlideVertical_WipeInColor6_SIG, "UFadePgSlideVertical::WipeInColor6", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlideVertical_WipeOutColor1_SIG, "UFadePgSlideVertical::WipeOutColor1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlideVertical_WipeOutColor2_SIG, "UFadePgSlideVertical::WipeOutColor2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlideVertical_WipeOutColor3_SIG, "UFadePgSlideVertical::WipeOutColor3", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlideVertical_WipeOutColor4_SIG, "UFadePgSlideVertical::WipeOutColor4", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlideVertical_WipeOutColor5_SIG, "UFadePgSlideVertical::WipeOutColor5", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
            _context._utils.SigScan(UFadePgSlideVertical_WipeOutColor6_SIG, "UFadePgSlideVertical::WipeOutColor6", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.WipeBgColor.ToU32())));
            });
        }
        public override void Register()
        {

        }
    }
}
