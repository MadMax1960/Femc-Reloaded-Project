using p3rpc.commonmodutils;

namespace p3rpc.femc.Components
{
    public class TitleMenu : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string ATitleActor_DrawPressAnyRectColor_SIG = "41 B0 C6 33 D2 33 C9 F3 0F 5C F0 F3 0F 10 83 ?? ?? ?? ?? F3 0F 5C 05 ?? ?? ?? ?? F3 0F 11 75 ?? F3 0F 11 45 ?? E8 ?? ?? ?? ??";
        private string ATitleActor_DrawGameModeSelectRectColor_SIG = "41 B0 C6 F3 0F 5C C8 33 D2 33 C9 F3 0F 59 0D ?? ?? ?? ?? F3 44 0F 2C C9 E8 ?? ?? ?? ??";

        public TitleMenu(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(ATitleActor_DrawPressAnyRectColor_SIG, "ATitleActor::DrawPressAnyRectColor", _context._utils.GetDirectAddress,
                addr => PatchColorArguments(addr, 3, 5));
            _context._utils.SigScan(ATitleActor_DrawGameModeSelectRectColor_SIG, "ATitleActor::DrawGameModeSelectRectColor", _context._utils.GetDirectAddress,
                addr => PatchColorArguments(addr, 7, 9));
        }

        private void PatchColorArguments(long address, int greenOffset, int redOffset)
        {
            // Edit the native FSprColor constructor's byte arguments in place.
            // MOV R8B, imm8 supplies blue. Replace XOR EDX/ECX with equally sized
            // MOV DL/CL instructions for green/red. The constructor reads only
            // those low bytes, and R9B retains the game's original alpha.
            // No detour, relocated instructions, or managed callback is needed.
            _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)address,
                addr => _context._memory.Write(addr + 2, _context._config.TitleMenuSelRectColor.B)));
            _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)address,
                addr => _context._memory.Write(addr + (nuint)greenOffset,
                    (ushort)(0xB2 | (_context._config.TitleMenuSelRectColor.G << 8)))));
            _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)address,
                addr => _context._memory.Write(addr + (nuint)redOffset,
                    (ushort)(0xB1 | (_context._config.TitleMenuSelRectColor.R << 8)))));
        }

        public override void Register()
        {
        }
    }
}
