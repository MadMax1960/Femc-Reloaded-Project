using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using Reloaded.Hooks.Definitions.X64;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Reloaded.Hooks.Definitions.X64.FunctionAttribute;

namespace p3rpc.femc.Components
{
    public class MessageScript : ModuleBase
    {
        private string MsgToken_GetTextColor_SIG = "40 55 48 8D 6C 24 ?? 48 81 EC D0 00 00 00 48 8B 05 ?? ?? ?? ?? 48 31 E0";

        // Colors used from GetTextColor MessageScript tag [uf 0 1 2] -> 0x3838ffff
        private uint[] MsgToken_Colors = // stored as locals in FUN_14ba86780
        {
            0xffffffff,
            0x7afdffff,
            0x3838ffff,
            0xfffe86ff,
            0x6ef00ff,
            0x50321eff,
            0xdc6e00ff,
            0xffffffff,
            0x50321eff,
            0xff1800ff,
            0xba0000ff,
            0x1200ffff,
            0x1f00baff,
            0x0ac000ff,
            0x078600ff,
            0x9D00EFFF,
            0x78008eff,
            0xbf9d02ff,
            0xff0391ff,
            0xff00fcff,
            0xbd0054ff,
            0x00aeffff,
            0x90401aff,
            0x161616FF,
            0x404040ff,
            0x656565ff,
            0xe6b625ff,
            0xffffffff,
            0xf0f3fcff,
            0xe4d4c7ff,
            0x505050ff,
            0xffffffff,
            0xffffffff,
            0x06ef00ff,
            0x7afdffff,
            0x45feffff,
            0x45feffff,
            0xff690aff,
            0xff690aff,
            0xff690aff,
            0xff690aff,
            0xff690aff,
            0xff690aff,
            0x45feffff,
            0xffea35ff,
        };

        private IHook<MsgToken_GetTextColor> _getTextColor;

        public unsafe MessageScript(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(MsgToken_GetTextColor_SIG, "MsgToken::GetTextColor", _context._utils.GetDirectAddress, addr => _getTextColor = _context._utils.MakeHooker<MsgToken_GetTextColor>(MsgToken_GetTextColorImpl, addr));
        }

        public override void Register()
        {
        }
        private unsafe FSprColor MsgToken_GetTextColorImpl(uint index) => new FSprColor(MsgToken_Colors[index]);

        // Microsoft calling convention doesn't preserve RDX
        [Function(FunctionAttribute.Register.rcx, FunctionAttribute.Register.rax, true, new Register[] { FunctionAttribute.Register.rdx })]
        private unsafe delegate FSprColor MsgToken_GetTextColor(uint index);
    }
}
