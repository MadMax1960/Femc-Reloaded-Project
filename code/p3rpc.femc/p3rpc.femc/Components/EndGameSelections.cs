using p3rpc.commonmodutils;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;

namespace p3rpc.femc.Components
{
    class EndGameSelections : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string AUIEndGameSelectionDraw_EndFirstSelectionGlowColor_SIG = "0F B6 C3 66 44 0F 6E F0";
        private string AUIEndGameSelectionDraw_EndFirstSelectionFontColor_SIG = "41 81 C9 00 FF 00 18";
        private string AUIEndGameSelectionDraw_EndFirstSelectionBackgroundColor_SIG = "41 81 C9 00 FC F3 F0";

        private string AUIEndGameSelectionDraw_EndPreSecondSelectionSubsTint1_SIG = "C7 85 ?? ?? ?? ?? 97 15 01 FF F3 0F 58 35";
        private string AUIEndGameSelectionDraw_EndPreSecondSelectionSubsTint2_SIG = "C7 85 ?? ?? ?? ?? 97 15 01 FF E8";
        private string AUIEndGameSelectionDraw_EndPreSecondSelectionSubsTint3_SIG = "C7 85 ?? ?? ?? ?? B7 44 01 FF";
        private string AUIEndGameSelectionDraw_EndSecondSelectionGlowColor1_SIG = "E8 ?? ?? ?? ?? C6 44 24 ?? 24 0F 57 DB C6 44 24 ?? 04 41 0F 28 D0 F3 0F 59 C6 0F 28 CF 48 8B CE F3 0F 2C C0 F3 0F 10 05 ?? ?? ?? ?? 88 45 ?? 48 8B 87 ?? ?? ?? ?? 48 89 44 24 ?? 48 8D 45 ?? F3 44 0F 11 4C 24 ?? F3 0F 11 44 24 ?? F3 44 0F 11 54 24";
        private string AUIEndGameSelectionDraw_EndSecondSelectionGlowColor2_SIG = "E8 ?? ?? ?? ?? C6 44 24 ?? 24 0F 57 DB C6 44 24 ?? 04 41 0F 28 D0 F3 0F 59 C6 0F 28 CF 48 8B CE F3 0F 2C C0 F3 0F 10 05 ?? ?? ?? ?? 88 45 ?? 48 8B 87 ?? ?? ?? ?? 48 89 44 24 ?? 48 8D 45 ?? F3 44 0F 11 4C 24 ?? F3 0F 11 44 24 ?? F3 0F 10 05";
        private string AUIEndGameSelectionDraw_EndSecondSelectionFirstOptionFontGlowColor1_SIG = "66 0F 6E C0 0F 5B C0 F3 0F 11 45 ?? F3 0F 59 05";
        private string AUIEndGameSelectionDraw_EndSecondSelectionFirstOptionFontGlowColor2_SIG = "F3 0F 11 44 24 ?? F3 0F 2C C1 0F 28 CF";
        private string AUIEndGameSelectionDraw_EndSecondSelectionFirstOptionFontGlowColor3_SIG = "0F 28 CE 88 45 ?? 48 8B 87 ?? ?? ?? ?? 48 89 44 24 ?? 48 8D 45 ?? F3 44 0F 11 4C 24 ?? F3 44 0F 11 54 24 ?? F3 44 0F 11 54 24 ?? C7 44 24 ?? 06 00 00 00";
        private string AUIEndGameSelectionDraw_EndSecondSelectionSecondOptionFontGlowColor1_SIG = "0F 28 D7 0F 28 CE 41 0F 28 C0";
        private string AUIEndGameSelectionDraw_EndSecondSelectionSecondOptionFontGlowColor2_SIG = "0F 28 D7 F3 41 0F 59 C0 0F 28 CE";
        private string AUIEndGameSelectionDraw_EndSecondSelectionSecondOptionFontGlowColor3_SIG = "0F 28 D7 F3 41 0F 2C C4";

        private IAsmHook _endFirstSelectionGlowColor;
        private IAsmHook _endSecondSelectionGlowColor1;
        private IAsmHook _endSecondSelectionGlowColor2;
        private IAsmHook _endSecondSelectionFirstOptionFontGlowColor1;
        private IAsmHook _endSecondSelectionFirstOptionFontGlowColor2;
        private IAsmHook _endSecondSelectionFirstOptionFontGlowColor3;
        private IAsmHook _endSecondSelectionSecondOptionFontGlowColor1;
        private IAsmHook _endSecondSelectionSecondOptionFontGlowColor2;
        private IAsmHook _endSecondSelectionSecondOptionFontGlowColor3;
        public unsafe EndGameSelections(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {

            _context._utils.SigScan(AUIEndGameSelectionDraw_EndFirstSelectionGlowColor_SIG, "AUIEndGameSelectionDraw::EndFirstSelectionGlowColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp + 0xd0], ${_context._config.EndGameFirstGlowColor.B:X}",
                    $"mov byte [rbp + 0xd1], ${_context._config.EndGameFirstGlowColor.G:X}",
                    $"mov byte [rbp + 0xd2], ${_context._config.EndGameFirstGlowColor.R:X}"
                };
                _endFirstSelectionGlowColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIEndGameSelectionDraw_EndFirstSelectionFontColor_SIG, "AUIEndGameSelectionDraw::EndFirstSelectionFontColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.EndGameFirstFontColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(AUIEndGameSelectionDraw_EndFirstSelectionBackgroundColor_SIG, "AUIEndGameSelectionDraw::EndFirstSelectionBackgroundColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.EndGameFirstBGColor.ToU32IgnoreAlpha())));
            });

            _context._utils.SigScan(AUIEndGameSelectionDraw_EndPreSecondSelectionSubsTint1_SIG, "AUIEndGameSelectionDraw::EndPreSecondSelectionSubsTint1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 6, _context._config.EndGamePreSecondFontTint1.ToU32ARGB())));
            });
            _context._utils.SigScan(AUIEndGameSelectionDraw_EndPreSecondSelectionSubsTint2_SIG, "AUIEndGameSelectionDraw::EndPreSecondSelectionSubsTint2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 6, _context._config.EndGamePreSecondFontTint1.ToU32ARGB())));
            });
            _context._utils.SigScan(AUIEndGameSelectionDraw_EndPreSecondSelectionSubsTint3_SIG, "AUIEndGameSelectionDraw::EndPreSecondSelectionSubsTint3", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 6, _context._config.EndGamePreSecondFontTint2.ToU32ARGB())));
            });
            _context._utils.SigScan(AUIEndGameSelectionDraw_EndSecondSelectionGlowColor1_SIG, "AUIEndGameSelectionDraw::EndSecondSelectionGlowColor1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp - 0x78], ${_context._config.EndGameSecondGlowColor1.B:X}",
                    $"mov byte [rbp - 0x77], ${_context._config.EndGameSecondGlowColor1.G:X}",
                    $"mov byte [rbp - 0x76], ${_context._config.EndGameSecondGlowColor1.R:X}"
                };
                _endSecondSelectionGlowColor1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIEndGameSelectionDraw_EndSecondSelectionGlowColor2_SIG, "AUIEndGameSelectionDraw::EndSecondSelectionGlowColor2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp - 0x74], ${_context._config.EndGameSecondGlowColor2.B:X}",
                    $"mov byte [rbp - 0x73], ${_context._config.EndGameSecondGlowColor2.G:X}",
                    $"mov byte [rbp - 0x72], ${_context._config.EndGameSecondGlowColor2.R:X}"
                };
                _endSecondSelectionGlowColor2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIEndGameSelectionDraw_EndSecondSelectionFirstOptionFontGlowColor1_SIG, "AUIEndGameSelectionDraw::EndSecondSelectionFirstOptionFontGlowColor1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp + 0x74], ${_context._config.EndGameSecondFontGlowColor1.B:X}",
                    $"mov byte [rsp + 0x75], ${_context._config.EndGameSecondFontGlowColor1.G:X}",
                    $"mov byte [rsp + 0x76], ${_context._config.EndGameSecondFontGlowColor1.R:X}"
                };
                _endSecondSelectionFirstOptionFontGlowColor1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIEndGameSelectionDraw_EndSecondSelectionFirstOptionFontGlowColor2_SIG, "AUIEndGameSelectionDraw::EndSecondSelectionFirstOptionFontGlowColor2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp - 0x68], ${_context._config.EndGameSecondFontGlowColor2.B:X}",
                    $"mov byte [rbp - 0x67], ${_context._config.EndGameSecondFontGlowColor2.G:X}",
                    $"mov byte [rbp - 0x66], ${_context._config.EndGameSecondFontGlowColor2.R:X}"
                };
                _endSecondSelectionFirstOptionFontGlowColor2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIEndGameSelectionDraw_EndSecondSelectionFirstOptionFontGlowColor3_SIG, "AUIEndGameSelectionDraw::EndSecondSelectionFirstOptionFontGlowColor3", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp - 0x70], ${_context._config.EndGameSecondFontGlowColor3.B:X}",
                    $"mov byte [rbp - 0x6f], ${_context._config.EndGameSecondFontGlowColor3.G:X}",
                    $"mov byte [rbp - 0x6e], ${_context._config.EndGameSecondFontGlowColor3.R:X}"
                };
                _endSecondSelectionFirstOptionFontGlowColor3 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIEndGameSelectionDraw_EndSecondSelectionSecondOptionFontGlowColor1_SIG, "AUIEndGameSelectionDraw::EndSecondSelectionSecondOptionFontGlowColor1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp - 0x80], ${_context._config.EndGameSecondFontGlowColor1.B:X}",
                    $"mov byte [rbp - 0x7f], ${_context._config.EndGameSecondFontGlowColor1.G:X}",
                    $"mov byte [rbp - 0x7e], ${_context._config.EndGameSecondFontGlowColor1.R:X}"
                };
                _endSecondSelectionSecondOptionFontGlowColor1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIEndGameSelectionDraw_EndSecondSelectionSecondOptionFontGlowColor2_SIG, "AUIEndGameSelectionDraw::EndSecondSelectionSecondOptionFontGlowColor2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp - 0x64], ${_context._config.EndGameSecondFontGlowColor2.B:X}",
                    $"mov byte [rbp - 0x63], ${_context._config.EndGameSecondFontGlowColor2.G:X}",
                    $"mov byte [rbp - 0x62], ${_context._config.EndGameSecondFontGlowColor2.R:X}"
                };
                _endSecondSelectionSecondOptionFontGlowColor2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIEndGameSelectionDraw_EndSecondSelectionSecondOptionFontGlowColor3_SIG, "AUIEndGameSelectionDraw::EndSecondSelectionSecondOptionFontGlowColor3", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rbp - 0x60], ${_context._config.EndGameSecondFontGlowColor3.B:X}",
                    $"mov byte [rbp - 0x5f], ${_context._config.EndGameSecondFontGlowColor3.G:X}",
                    $"mov byte [rbp - 0x5e], ${_context._config.EndGameSecondFontGlowColor3.R:X}"
                };
                _endSecondSelectionSecondOptionFontGlowColor3 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }

        public override void Register() { }
    }
}