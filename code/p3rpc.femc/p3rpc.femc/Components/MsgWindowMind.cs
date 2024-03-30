using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using Reloaded.Hooks.Definitions.X64;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Reloaded.Hooks.Definitions.X64.FunctionAttribute;

namespace p3rpc.femc.Components
{
    public class MsgWindowMind : ModuleBase<FemcContext>
    {
        private string UMsgProcWindow_Mind_DrawMessageBox_SIG = "40 55 57 48 8D AC 24 ?? ?? ?? ?? 48 81 EC 28 02 00 00";
        private string UMsgProcWindow_Mind_DrawMessageBoxLeftSpotBg1_SIG = "4C 8B 87 ?? ?? ?? ?? 48 8D 4D ?? 45 0F 57 C9";
        private string UMsgProcWindow_Mind_DrawMessageBoxLeftSpotBg2_SIG = "4C 8B 87 ?? ?? ?? ?? 48 8D 4D ?? 0F 57 DB F3 44 0F 11 4C 24 ?? 49 8B D6";
        private IHook<UMsgProcWindow_Mind_DrawMessageBox> _drawMessageBox;

        private IAsmHook _drawMessageBoxLeftSpotBg1;
        private IAsmHook _drawMessageBoxLeftSpotBg2;

        private IReverseWrapper<UMsgProcWindow_Mind_DrawMessageBoxLeftSpotBg> _drawMessageBoxLeftSpotBgWrapper1;
        private IReverseWrapper<UMsgProcWindow_Mind_DrawMessageBoxLeftSpotBg> _drawMessageBoxLeftSpotBgWrapper2;

        private UICommon _uiCommon;

        public unsafe MsgWindowMind(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(UMsgProcWindow_Mind_DrawMessageBox_SIG, "UMsgProcWindow_Mind::DrawMessageBox", _context._utils.GetDirectAddress, addr => _drawMessageBox = _context._utils.MakeHooker<UMsgProcWindow_Mind_DrawMessageBox>(UMsgProcWindow_Mind_DrawMessageBoxImpl, addr));
            _context._utils.SigScan(UMsgProcWindow_Mind_DrawMessageBoxLeftSpotBg1_SIG, "UMsgProcWindow_Mind::DrawMessageBoxLeftSpotBg1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UMsgProcWindow_Mind_DrawMessageBoxLeftSpotBgImpl, out _drawMessageBoxLeftSpotBgWrapper1)}",
                };
                _drawMessageBoxLeftSpotBg1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UMsgProcWindow_Mind_DrawMessageBoxLeftSpotBg2_SIG, "UMsgProcWindow_Mind::DrawMessageBoxLeftSpotBg2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UMsgProcWindow_Mind_DrawMessageBoxLeftSpotBgImpl, out _drawMessageBoxLeftSpotBgWrapper2)}",
                };
                _drawMessageBoxLeftSpotBg2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        private unsafe void UMsgProcWindow_Mind_DrawMessageBoxImpl(UMsgProcWindow_Mind* self)
        {
            ConfigColor.SetColor(ref self->OuterBorderColor, _context._config.MindWindowOuterBorder);
            ConfigColor.SetColor(ref self->InnerContentsColor, _context._config.MindWindowInnerColor);
            var MindWindowOuterHaze = new ConfigColor(0xff, 0x89, 0xa6, 0x80);
            ConfigColor.SetColor(ref self->OutsideMistColor, MindWindowOuterHaze);
            ConfigColor.SetColor(ref self->NextPage.NextPageColor, _context._config.TextBoxFrontFillColor); // see MsgWindowSimple
            _drawMessageBox.OriginalFunction(self);
        }

        private unsafe FSprColor UMsgProcWindow_Mind_DrawMessageBoxLeftSpotBgImpl(UMsgProcWindow_Mind* self)
        {
            var configColorRaw = ConfigColor.ToFSprColor(_context._config.MindWindowBgDots);
            configColorRaw.A = (byte)((1.0 - self->leftSpotBgOpacity2) * 102 * self->leftSpotBgOpacity1);
            return configColorRaw;
        }

        private unsafe delegate void UMsgProcWindow_Mind_DrawMessageBox(UMsgProcWindow_Mind* self);
        [Function(new Register[] { FunctionAttribute.Register.rdi }, FunctionAttribute.Register.rax, false)]
        private unsafe delegate FSprColor UMsgProcWindow_Mind_DrawMessageBoxLeftSpotBg(UMsgProcWindow_Mind* self);
    }

    public class MsgWindowSelectMind : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string UMsgProcWindow_Select_Mind_DrawMessageBox_SIG = "48 8B C4 48 89 58 ?? 48 89 70 ?? 48 89 78 ?? 55 41 54 41 55 41 56 41 57 48 8D A8 ?? ?? ?? ?? 48 81 EC B0 02 00 00 0F 29 70 ?? 0F 29 78 ??";
        private string UMsgProcWindow_Select_Mind_MessageBoxBgDotSel_SIG = "F3 41 0F 59 C0 F3 0F 2C C0 88 44 24 ?? 48 8B 83 ?? ?? ?? ??";
        private string UMsgProcWindow_Select_Mind_SelectedTextColor_SIG = "81 C9 00 FF 00 18 89 4D ??";
        private string UMsgProcWindow_Select_Mind_MindWindowBorderColor_SIG = "F3 0F 2C C0 F3 0F 10 05 ?? ?? ?? ?? 88 44 24 ?? 48 8D 44 24 ?? 48 89 44 24 ?? F3 0F 11 44 24 ?? F3 0F 10 05 ?? ?? ?? ??";
        private string UMsgProcWindow_Select_Mind_MindWindowInnerColor_SIG = "F3 0F 2C C0 F3 0F 10 05 ?? ?? ?? ?? 88 44 24 ?? 48 8D 44 24 ?? 48 89 44 24 ?? F3 44 0F 11 6C 24 ??";

        private IHook<UMsgProcWindow_Select_Mind_DrawMessageBox> _drawMessageBox;
        private IAsmHook _msgBoxBgDotSel;
        private UICommon _uiCommon;

        public unsafe MsgWindowSelectMind(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            //_context._utils.SigScan(UMsgProcWindow_Select_Mind_DrawMessageBox_SIG, "UMsgProcWindow_Select_Mind::DrawMessageBox", _context._utils.GetDirectAddress, addr => _drawMessageBox = _context._utils.MakeHooker<UMsgProcWindow_Select_Mind_DrawMessageBox>(UMsgProcWindow_Select_Mind_DrawMessageBoxImpl, addr));
            _context._utils.SigScan(UMsgProcWindow_Select_Mind_MessageBoxBgDotSel_SIG, "UMsgProcWindow_Select_Mind::MessageBoxBgDotSel", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rsp + 0x60], {_context._config.MindSelectDotColor.ToU32ARGB()}",
                };
                _msgBoxBgDotSel = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UMsgProcWindow_Select_Mind_SelectedTextColor_SIG, "UMsgProcWindow_Select_Mind::SelectedTextColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 2, _context._config.MindSelActiveTextColor.ToU32IgnoreAlpha())));
            });
            _context._utils.SigScan(UMsgProcWindow_Select_Mind_MindWindowBorderColor_SIG, "UMsgProcWindow_Select_Mind::MindWindowBorderColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rsp + 0x60], {_context._config.MindSelWindowBorder.ToU32ARGB()}",
                };
                _msgBoxBgDotSel = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UMsgProcWindow_Select_Mind_MindWindowInnerColor_SIG, "UMsgProcWindow_Select_Mind::MindWindowInnerColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov dword [rsp + 0x60], {_context._config.MindSelWindowFill.ToU32ARGB()}",
                };
                _msgBoxBgDotSel = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        private unsafe void UMsgProcWindow_Select_Mind_DrawMessageBoxImpl(UMsgProcWindow_Select_Mind* self)
        {
            _drawMessageBox.OriginalFunction(self);
        }

        private unsafe delegate void UMsgProcWindow_Select_Mind_DrawMessageBox(UMsgProcWindow_Select_Mind* self);
    }
}
