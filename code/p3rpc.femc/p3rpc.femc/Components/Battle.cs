using p3rpc.commonmodutils;

namespace p3rpc.femc.Components
{
    public class Battle : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string ABtlResult_ColoredSquaresAnimation = "C7 45 ?? D1 22 00 FF";

        private string ABtlPersonaOverstock_HighlightedColor = "BA FF 00 00 EE";
        private string ABtlPersonaOverstock_EquippedPersonaArcanaFontColor = "BB FF A9 A8 00";
        private string ABtlPersonaOverstock_SelectedPersonaArcanaFontColor = "BB FF 74 0C 00";
        private string ABtlPersonaOverstock_SelectedPersonaArcanaBGColor = "41 BD FF FF FF 00 EB";
        private string ABtlPersonaOverstock_UnselectedPersonaArcanaAndNameFontColor = "BB FF FF FF 00 41 BD FF 44 0B 00";
        private string ABtlPersonaOverstock_UnselectedPersonaArcanaBGColor = "41 BD FF 44 0B 00";

        public unsafe Battle(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(ABtlResult_ColoredSquaresAnimation, "ABtlResult::ColoredSquaresAnimation", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.BtlResultSquaresColor.ToU32ARGB())));
            });

            _context._utils.SigScan(ABtlPersonaOverstock_HighlightedColor, "ABtlPersonaOverstock::HighlightedColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.CampHighlightedLowerColor.ToU32())));
            });
            _context._utils.SigScan(ABtlPersonaOverstock_EquippedPersonaArcanaFontColor, "ABtlPersonaOverstock::EquippedPersonaArcanaFontColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.OverstockFontEquippedArcanaColor.ToU32())));
            });
            _context._utils.SigScan(ABtlPersonaOverstock_SelectedPersonaArcanaFontColor, "ABtlPersonaOverstock::SelectedPersonaArcanaFontColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.OverstockFontSelectedArcanaColor.ToU32())));
            });
            _context._utils.SigScan(ABtlPersonaOverstock_SelectedPersonaArcanaBGColor, "ABtlPersonaOverstock::SelectedPersonaArcanaBGColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.OverstockBGSelectedColor.ToU32())));
            });
            _context._utils.SigScan(ABtlPersonaOverstock_UnselectedPersonaArcanaAndNameFontColor, "ABtlPersonaOverstock::UnselectedPersonaArcanaAndNameFontColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.OverstockFontUnselectedNameArcanaColor.ToU32())));
            });
            _context._utils.SigScan(ABtlPersonaOverstock_UnselectedPersonaArcanaBGColor, "ABtlPersonaOverstock::UnselectedPersonaArcanaBGColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.OverstockBGUnselectedColor.ToU32())));
            });
        }
        public override void Register() { }
    }
}