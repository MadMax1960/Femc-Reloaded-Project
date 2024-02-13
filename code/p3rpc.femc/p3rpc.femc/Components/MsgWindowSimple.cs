using p3rpc.femc.Native;
using Reloaded.Hooks.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static p3rpc.femc.Components.UICommon;

namespace p3rpc.femc.Components
{
    public class MsgWindowSimple : ModuleBase
    {
        private IHook<UMsgProcWindow_Simple_DrawMessageBox> _drawMsgBoxSimple;
        private UMsgProcWindow_Simple_DrawMessageText _drawMessageText;
        private unsafe float* _messageBoxFloats1;

        private UICommon _uiCommon;

        private string UMsgProcWindow_Simple_DrawMessageBox_SIG = "40 55 57 48 8D AC 24 ?? ?? ?? ?? 48 81 EC 08 03 00 00 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 85 ?? ?? ?? ?? 48 8B 01";
        private string MessageBoxFloats1_SIG = "F2 0F 10 0D ?? ?? ?? ?? 41 0F 28 C1";
        private string UMsgProcWindow_Simple_DrawMessageText_SIG = "4C 8B DC 49 89 5B ?? 57 48 81 EC D0 00 00 00 48 8B 81 ?? ?? ?? ??";
        public unsafe MsgWindowSimple(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(UMsgProcWindow_Simple_DrawMessageBox_SIG, "UMsgProcWindow_Simple::DrawMessageBox", _context._utils.GetDirectAddress, addr => _drawMsgBoxSimple = _context._utils.MakeHooker<UMsgProcWindow_Simple_DrawMessageBox>(UMsgProcWindow_Simple_DrawMessageBoxImpl, addr));
            _context._utils.SigScan(MessageBoxFloats1_SIG, "MessageBoxFloats1", _context._utils.GetIndirectAddressLong4, addr => _messageBoxFloats1 = (float*)addr);
            _context._utils.SigScan(UMsgProcWindow_Simple_DrawMessageText_SIG, "UMsgProcWindow_Simple::DrawMessageText", _context._utils.GetDirectAddress, addr => _drawMessageText = _context._utils.MakeWrapper<UMsgProcWindow_Simple_DrawMessageText>(addr));
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        private static float[,] MessageBoxWidths = // 1442a7044
        {
            { 435.0f, 0.75099999f, 0.75099999f, 0.749f, 765.0f, 461.0f },
            { 503.0f, 0.87099999f, 0.87099999f, 0.749f, 890.0f, 639.0f },
            { 571.0f, 1.0f, 1.0f, 1.0f, 1025.0f, 0.0f },
        };

        private static float[,] MessageBoxHeights = // 1442a7090
        {
            { -5.0f, 0.842f, 17.0f, 6.0f, 0.842f, 22.0f, 7.0f, 0.838f, 8.0f, 0.0f, 58.0f,  },
            { -5.0f, 0.971f, 17.0f, 5.0f, 0.971f, 22.0f, 6.0f, 0.966f, 14.0f, -11.0f, 68.0f,  },
            { 0.0f, 1.0f, 17.0f, 0.0f, 1.0f, 22.0f, 0.0f, 1.0f, 14.0f, -23.0f, 78.0f,  },
        };

        private unsafe float Lerp(float a, float b, float c) => (1 - c) * a + b * c;

        private unsafe void UMsgProcWindow_Simple_DrawMessageBoxImpl(UMsgProcWindow_Simple* self) // FUN_14141c8e0
        {
            var vtable278 = _context._hooks.CreateWrapper<UMsgProcWindow_Simple_Vtable278>(*(nint*)(*(nint*)self + 0x278), out _);
            if (vtable278(self) && (self->MsgProcWindowStatus & 8) != 0)
            {
                var itemMask = _uiCommon._getSpriteItemMaskInstance() + 0x20;
                _uiCommon._setSpriteDrawMaskMode(itemMask, 0);
                //_context._logger.WriteLineAsync($"[RESEARCH] SPR {_context.g_namePool->GetString(((UObjectBase*)self->MsgSpr_)->NamePrivate)}, PLG {_context.g_namePool->GetString(((UObjectBase*)self->MsgPlg_)->NamePrivate)}");

                var color1 = new FSprColor(_context._config.MessageWindowColor);
                color1.A = (byte)((1.0f - self->BgPieceTransparency) * self->Opacity * 102.0f);
                ;
                var pos1 = new FVector2D(
                    Lerp(MessageBoxWidths[self->MessageBoxSubWidth, 0], MessageBoxWidths[self->MessageBoxWidth, 0], self->Field170) + self->OffsetX + 482,
                    Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 0], MessageBoxHeights[self->MessageBoxHeight, 0], self->Field170) + 883
                );
                var stretch1 = new FVector2D(
                    Lerp(MessageBoxWidths[self->MessageBoxSubWidth, 1], MessageBoxWidths[self->MessageBoxWidth, 1], self->Field170) * self->SizeX,
                    Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 1], MessageBoxHeights[self->MessageBoxHeight, 1], self->Field170)
                );
                var fields1 = new PlgDefStruct1(pos1, color1, 0xb, (float)(self->BgPieceRotation - 4.2), stretch1);
                _uiCommon._plgFunc1(&fields1, itemMask, self->MsgPlg_, 0.0f, 0.0f);
                _uiCommon._setSpriteDrawMaskMode(itemMask, 2);
                _uiCommon._plgFunc1(&fields1, itemMask, self->MsgPlg_, 0.0f, 0.0f);
                _uiCommon._spriteMaskFunc1(itemMask, 0, 0, 1, 0, 0, 0, 0xf, 0x23);
                _uiCommon._spriteMaskFunc2(itemMask, 0, 570, 1920, 1080, new FSprColor(0, 0, 0, 255), 0x23);

                var pos2 = new FVector2D(
                    Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 2], MessageBoxHeights[self->MessageBoxHeight, 2], self->Field170) + self->OffsetX + 482,
                    Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 3], MessageBoxHeights[self->MessageBoxHeight, 3], self->Field170) + 883
                );
                var stretch2 = new FVector2D(
                    Lerp(MessageBoxWidths[self->MessageBoxSubHeight, 2], MessageBoxHeights[self->MessageBoxHeight, 2], self->Field170) * self->SizeX,
                    Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 4], MessageBoxHeights[self->MessageBoxHeight, 4], self->Field170)
                );
                var color2 = new FSprColor(0x12, 0x14, 0x23, (byte)(self->Opacity * 255 * 0.9));
                var fields2 = new PlgDefStruct1(pos2, color2, 0x7, _messageBoxFloats1[1], stretch2);
                fields2.Field18 = _messageBoxFloats1[0];
                fields2.Field20 = _messageBoxFloats1[2];
                _uiCommon._spriteMaskFunc1(itemMask, 0, 4, 5, 0, 1, 0, 0xf, 0x23);
                _uiCommon._plgFunc1(&fields2, itemMask, self->MsgPlg_, 0, 0);

                var pos3 = new FVector2D(
                    self->OffsetX + 482 + 308,
                    864
                );
                var color3 = new FSprColor(0xe, 0, 0xcf, (byte)(self->Opacity * 255 * 0.4));
                var sprite1 = new SprDefStruct1(0, pos3, color3, 1.5f, 0, 0);
                sprite1.Field10 = 70;
                _uiCommon._spriteMaskFunc1(itemMask, 0, 0, 1, 0, 6, 0, 0xf, 0x23);
                _uiCommon._spriteFunc1(&sprite1, itemMask, self->MsgSpr_, 0, 0);
                _uiCommon._spriteMaskFunc1(itemMask, 0, 6, 1, 0, 0, 0, 0xf, 0x23);
                _uiCommon._spriteFunc1(&sprite1, itemMask, self->MsgSpr_, 0, 0);
                _uiCommon._spriteMaskFunc1(itemMask, 0, 0, 1, 0, 1, 0, 0xf, 0x23);
                _uiCommon._spriteFunc1(&sprite1, itemMask, self->MsgSpr_, 0, 0);

                _drawMessageText(self, itemMask, self->Field164, self->OffsetX + 482, 883);
            }
        }

        private unsafe delegate void UMsgProcWindow_Simple_DrawMessageBox(UMsgProcWindow_Simple* self);
        private unsafe delegate bool UMsgProcWindow_Simple_Vtable278(UMsgProcWindow_Simple* self);
    }

    public class MsgWindowSelectSimple : ModuleBase
    {
        public unsafe MsgWindowSelectSimple(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
        }

        public override void Register()
        {

        }
    }
}
