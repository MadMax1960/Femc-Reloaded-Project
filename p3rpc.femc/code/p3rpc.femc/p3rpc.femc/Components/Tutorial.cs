using p3rpc.commonmodutils;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class Tutorial : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string AUITutorialDraw_ListEntryDotColor_SIG = "F3 41 0F 58 D1 44 88 A5 ?? ?? ?? ??";
        private string AUITutorialDraw_ListEntryTextColor_SIG = "0D 00 FC FC 67";
        private string AUITutorialDraw_BackgroundDrawBackSquare_SIG = "C7 44 24 ?? 43 1B 11 E5";

        private IAsmHook _listEntryDotColor;
        private unsafe uint BgBackSquareColor(ConfigColor color) => (uint)(0xe5 << 0x18 | color.R << 0x10 | color.G << 8 | color.B);
        public unsafe Tutorial(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUITutorialDraw_ListEntryDotColor_SIG, "AUITutorialDraw::ListEntryDotColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rbp + 0xb8], {_context._config.TutorialListEntryColor.ToU32ARGB()}"
                };
                _listEntryDotColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITutorialDraw_ListEntryTextColor_SIG, "AUITutorialDraw::ListEntryTextColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, _context._config.TutorialListEntryColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(AUITutorialDraw_BackgroundDrawBackSquare_SIG, "AUITutorialDraw::BackgroundDrawBackSquare", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, BgBackSquareColor(_context._config.TutorialBgColor))));
            });
        }
        public override void Register() { }
    }
}
