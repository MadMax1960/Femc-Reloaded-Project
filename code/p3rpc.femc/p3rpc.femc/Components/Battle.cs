using p3rpc.commonmodutils;

namespace p3rpc.femc.Components
{
    public class Battle : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string ABtlResult_ColoredSquaresAnimation = "C7 45 ?? D1 22 00 FF";

        public unsafe Battle(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(ABtlResult_ColoredSquaresAnimation, "ABtlResult::ColoredSquaresAnimation", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.BtlResultSquaresColor.ToU32ARGB())));
            });
        }
        public override void Register() { }
    }
}