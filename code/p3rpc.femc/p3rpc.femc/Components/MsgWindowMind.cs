using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class MsgWindowMind : ModuleBase
    {
        private string UMsgProcWindow_Mind_DrawMessageBox_SIG = "40 55 57 48 8D AC 24 ?? ?? ?? ?? 48 81 EC 28 02 00 00";
        private IHook<UMsgProcWindow_Mind_DrawMessageBox> _drawMessageBox;

        private UICommon _uiCommon;

        public unsafe MsgWindowMind(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(UMsgProcWindow_Mind_DrawMessageBox_SIG, "UMsgProcWindow_Mind::DrawMessageBox", _context._utils.GetDirectAddress, addr => _drawMessageBox = _context._utils.MakeHooker<UMsgProcWindow_Mind_DrawMessageBox>(UMsgProcWindow_Mind_DrawMessageBoxImpl, addr));
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        private unsafe void UMsgProcWindow_Mind_DrawMessageBoxImpl(UMsgProcWindow_Mind* self)
        {
            _uiCommon.SetColor(ref self->OuterBorderColor, _context._config.MindWindowOuterBorder);
            _uiCommon.SetColor(ref self->InnerContentsColor, _context._config.MindWindowInnerColor);
            _uiCommon.SetColor(ref self->OutsideMistColor, _context._config.MindWindowOuterHaze);
            _drawMessageBox.OriginalFunction(self);
        }

        private unsafe delegate void UMsgProcWindow_Mind_DrawMessageBox(UMsgProcWindow_Mind* self);
    }

    public class MsgWindowSelectMind : ModuleBase
    {
        private string UMsgProcWindow_Select_Mind_DrawMessageBox_SIG = "48 8B C4 48 89 58 ?? 48 89 70 ?? 48 89 78 ?? 55 41 54 41 55 41 56 41 57 48 8D A8 ?? ?? ?? ?? 48 81 EC B0 02 00 00 0F 29 70 ?? 0F 29 78 ??";
        private IHook<UMsgProcWindow_Select_Mind_DrawMessageBox> _drawMessageBox;

        private UICommon _uiCommon;

        public unsafe MsgWindowSelectMind(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(UMsgProcWindow_Select_Mind_DrawMessageBox_SIG, "UMsgProcWindow_Select_Mind::DrawMessageBox", _context._utils.GetDirectAddress, addr => _drawMessageBox = _context._utils.MakeHooker<UMsgProcWindow_Select_Mind_DrawMessageBox>(UMsgProcWindow_Select_Mind_DrawMessageBoxImpl, addr));
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
