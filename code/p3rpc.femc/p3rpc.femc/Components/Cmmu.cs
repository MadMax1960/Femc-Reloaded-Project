using p3rpc.commonmodutils;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;

namespace p3rpc.femc.Components
{
    class Cmmu : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string AUICmmu_RankUpCardColorDark1_SIG = "C7 84 24 ?? ?? ?? ?? 30 07 05 FF 8B 9C 24";
        private string AUICmmu_RankUpCardColorDark2_SIG = "C7 84 24 ?? ?? ?? ?? 30 07 05 FF 8B BC 24";

        private string AUICmmu_RankUpCardColorLightInitialBlue_SIG = "E8 ?? ?? ?? ?? BA 07 00 00 00 88 84 24 ?? ?? ?? ?? 8D 4A ?? E8 ?? ?? ?? ?? BA 6D 00 00 00";
        private string AUICmmu_RankUpCardColorLightInitialGreen_SIG = "E8 ?? ?? ?? ?? BA 6D 00 00 00 88 84 24 ?? ?? ?? ??";
        private string AUICmmu_RankUpCardColorLightInitialRed_SIG = "66 C7 84 24 ?? ?? ?? ?? 00 FF 48 8D 99 ?? ?? ?? ??";
        private string AUICmmu_RankUpCardColorLightBlue_SIG = "E8 ?? ?? ?? ?? BA 07 00 00 00 88 84 24 ?? ?? ?? ?? 8D 4A ?? E8 ?? ?? ?? ?? 88 84 24 ?? ?? ?? ??";
        private string AUICmmu_RankUpCardColorLightGreen_SIG = "E8 ?? ?? ?? ?? 88 84 24 ?? ?? ?? ?? BA 6D 00 00 00";
        private string AUICmmu_RankUpCardColorLightRed_SIG = "66 C7 84 24 ?? ?? ?? ?? 00 FF 8B 84 24 ?? ?? ?? ??";

        // Fade animation so separated r,g,b for every color interpolation function call
        private string AUICmmu_RankUpStripColorUpRed_SIG = "E8 ?? ?? ?? ?? F3 0F 10 0D ?? ?? ?? ?? 0F 57 DB 40 88 7C 24 ??";
        private string AUICmmu_RankUpStripColorUpGreen_SIG = "E8 ?? ?? ?? ?? F3 0F 2C C0 88 45 ?? 49 8B 86 ?? ?? ?? ??";
        private string AUICmmu_RankUpStripColorUpBlue_SIG = "E8 ?? ?? ?? ?? F3 0F 2C C0 F3 0F 10 05 ?? ?? ?? ??";

        private string AUICmmu_RankUpStripColorMiddle_SIG = "E8 ?? ?? ?? ?? 41 B1 FF 41 B0 A6";
        private string AUICmmu_RankUpStripColorDown_SIG = "E8 ?? ?? ?? ?? 41 B1 FF 45 33 C0 33 D2 33 C9 8B F0";

        private string AUICmmu_RankUpMaxColor_SIG = "81 C9 00 90 4A 17";

        private string AUICmmu_CheckSocialLinkStrip1_SIG = "C7 44 24 ?? FF FF 1E 00 E8 ?? ?? ?? ??";
        private string AUICmmu_CheckSocialLinkStrip2_SIG = "C7 44 24 ?? FF FF 1E 00 0F 11 44 24 ??";

        private IAsmHook _RankUpCardColorLightInitialBlue;
        private IAsmHook _RankUpCardColorLightInitialGreen;
        private IAsmHook _RankUpCardColorLightBlue;
        private IAsmHook _RankUpCardColorLightGreen;

        private IAsmHook _RankUpStripColorUpRed;
        private IAsmHook _RankUpStripColorUpGreen;
        private IAsmHook _RankUpStripColorUpBlue;
        private IAsmHook _RankUpStripColorMiddle;
        private IAsmHook _RankUpStripColorDown;


        public unsafe Cmmu(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUICmmu_RankUpCardColorDark1_SIG, "AUICmmu::RankUpCardColorDark1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 7, _context._config.CmmuRankUpDarkCardColor.ToU32ARGB())));
            });
            _context._utils.SigScan(AUICmmu_RankUpCardColorDark2_SIG, "AUICmmu::RankUpCardColorDark2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 7, _context._config.CmmuRankUpDarkCardColor.ToU32ARGB())));
            });

            _context._utils.SigScan(AUICmmu_RankUpCardColorLightInitialBlue_SIG, "AUICmmu::RankUpCardColorLightInitialBlue", _context._utils.GetDirectAddress, addr =>
            {
                // 0x88 to 0xF6 before, we'll lower the color offset to not make the cards so red
                byte offset = 0x25;
                byte maxColor = _context._config.CmmuRankUpLightCardColor.B;
                byte minColor;

                if (maxColor - offset < 0)
                {
                    maxColor = (byte)(maxColor + offset);
                }

                minColor = (byte)(maxColor - offset);

                string[] function =
                {
                    "use64",
                    $"mov cl, {minColor}",
                    $"mov dl, {maxColor}"
                };
                _RankUpCardColorLightInitialBlue = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUICmmu_RankUpCardColorLightInitialGreen_SIG, "AUICmmu::RankUpCardColorLightInitialGreen", _context._utils.GetDirectAddress, addr =>
            {
                // 0x4 to 0x7 before
                byte offset = 0x3;
                byte maxColor = _context._config.CmmuRankUpLightCardColor.G;
                byte minColor;

                if (maxColor - offset < 0)
                {
                    maxColor = (byte)(maxColor + offset);
                }

                minColor = (byte)(maxColor - offset);

                string[] function =
                {
                    "use64",
                    $"mov cl, {minColor}",
                    $"mov dl, {maxColor}"
                };
                _RankUpCardColorLightInitialGreen = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUICmmu_RankUpCardColorLightInitialRed_SIG, "AUICmmu::RankUpCardColorLightInitialRed", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 8, _context._config.CmmuRankUpLightCardColor.R)));
            });
            

            _context._utils.SigScan(AUICmmu_RankUpCardColorLightBlue_SIG, "AUICmmu::RankUpCardColorLightBlue", _context._utils.GetDirectAddress, addr =>
            {
                // 0x88 to 0xF6 before, we'll lower the color offset to not make the cards so red
                byte offset = 0x25;
                byte maxColor = _context._config.CmmuRankUpLightCardColor.B;
                byte minColor;

                if (maxColor - offset < 0)
                {
                    maxColor = (byte) (maxColor + offset);
                }

                minColor = (byte) (maxColor - offset);

                string[] function =
                {
                    "use64",
                    $"mov cl, {minColor}",
                    $"mov dl, {maxColor}"
                };
                _RankUpCardColorLightBlue = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUICmmu_RankUpCardColorLightGreen_SIG, "AUICmmu::RankUpCardColorLightGreen", _context._utils.GetDirectAddress, addr =>
            {
                // 0x4 to 0x7 before
                byte offset = 0x3;
                byte maxColor = _context._config.CmmuRankUpLightCardColor.G;
                byte minColor;

                if (maxColor - offset < 0)
                {
                    maxColor = (byte) (maxColor + offset);
                }

                minColor = (byte) (maxColor - offset);

                string[] function =
                {
                    "use64",
                    $"mov cl, {minColor}",
                    $"mov dl, {maxColor}"
                };
                _RankUpCardColorLightGreen = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUICmmu_RankUpCardColorLightRed_SIG, "AUICmmu::RankUpCardColorLightRed", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 8, _context._config.CmmuRankUpLightCardColor.R)));
            });

            _context._utils.SigScan(AUICmmu_RankUpStripColorUpRed_SIG, "AUICmmu::RankUpStripColorUpRed", _context._utils.GetDirectAddress, addr =>
            {
                float fValue = _context._config.CmmuRankUpStripColorUp.R;
                uint hexRed = BitConverter.ToUInt32(BitConverter.GetBytes(fValue), 0);

                string[] function =
                {
                    "use64",
                    "sub rsp, 8",
                    $"mov dword [rsp], {hexRed}",
                    "movss xmm0, dword [rsp]",
                    "add rsp, 8",
                };
                _RankUpStripColorUpRed = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUICmmu_RankUpStripColorUpGreen_SIG, "AUICmmu::RankUpStripColorUpGreen", _context._utils.GetDirectAddress, addr =>
            {
                float fValue = _context._config.CmmuRankUpStripColorUp.G;
                uint hexGreen = BitConverter.ToUInt32(BitConverter.GetBytes(fValue), 0);

                string[] function =
                {
                    "use64",
                    "sub rsp, 8",
                    $"mov dword [rsp], {hexGreen}",
                    "movss xmm0, dword [rsp]",
                    "add rsp, 8",
                };
                _RankUpStripColorUpGreen = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUICmmu_RankUpStripColorUpBlue_SIG, "AUICmmu::RankUpStripColorUpBlue", _context._utils.GetDirectAddress, addr =>
            {
                float fValue = _context._config.CmmuRankUpStripColorUp.B;
                uint hexBlue = BitConverter.ToUInt32(BitConverter.GetBytes(fValue), 0);

                string[] function =
                {
                    "use64",
                    "sub rsp, 8",
                    $"mov dword [rsp], {hexBlue}",
                    "movss xmm0, dword [rsp]",
                    "add rsp, 8",
                };
                _RankUpStripColorUpBlue = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUICmmu_RankUpStripColorMiddle_SIG, "AUICmmu::RankUpStripColorMiddle", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.CmmuRankUpStripColorUp.B:X}",
                    $"mov dl, ${_context._config.CmmuRankUpStripColorUp.G:X}",
                    $"mov cl, ${_context._config.CmmuRankUpStripColorUp.R:X}"
                };
                _RankUpStripColorMiddle = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUICmmu_RankUpStripColorDown_SIG, "AUICmmu::RankUpStripColorDown", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.CmmuRankUpStripColorDown.B:X}",
                    $"mov dl, ${_context._config.CmmuRankUpStripColorDown.G:X}",
                    $"mov cl, ${_context._config.CmmuRankUpStripColorDown.R:X}"
                };
                _RankUpStripColorDown = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUICmmu_RankUpMaxColor_SIG, "AUICmmu::RankUpMaxColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.CmmuRankUpMaxColor.ToU32IgnoreAlpha())));
            });

            _context._utils.SigScan(AUICmmu_CheckSocialLinkStrip1_SIG, "AUICmmu::CheckSocialLinkStrip1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CmmuStatusStrip.ToU32())));
            });
            _context._utils.SigScan(AUICmmu_CheckSocialLinkStrip2_SIG, "AUICmmu::CheckSocialLinkStrip2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.CmmuStatusStrip.ToU32())));
            });
        }

        public override void Register() { }
    }
}
