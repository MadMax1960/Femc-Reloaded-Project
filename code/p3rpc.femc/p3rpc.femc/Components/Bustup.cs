using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class Bustup : ModuleBase
    {
        private string UBustupObject_SetBustupShadowColor_SIG = "40 53 48 83 EC 30 F3 0F 10 05 ?? ?? ?? ?? 48 89 CB";
        private string UBustupDraw_DrawBustup_SIG = "40 57 48 83 EC 60 48 8B F9 E8 ?? ?? ?? ?? 48 8B C8";
        private string UBustupObject_DrawBustupShadow_SIG = "48 89 E0 53 48 81 EC C0 00 00 00";
        private string UBustupDraw_DrawBustupBottomLeftTriangle_SIG = "48 8B C4 48 81 EC C8 00 00 00 0F 29 78 ??";
        

        private UBustupObject_SetBustupShadowColor _setBustupShadowColor;
        private IHook<UBustupDraw_DrawBustup> _drawBustup;
        private IHook<UBustupObject_DrawBustupShadow> _drawBustupShadow;
        private IHook<UBustupDraw_DrawBustupBottomLeftTriangle> _drawBustupBottomLeft;

        private UICommon _uiCommon;
        public unsafe Bustup(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(UBustupObject_SetBustupShadowColor_SIG, "UBustupObject::SetBustupShadowColor", _context._utils.GetDirectAddress, addr => _setBustupShadowColor = _context._utils.MakeWrapper<UBustupObject_SetBustupShadowColor>(addr));
            _context._utils.SigScan(UBustupObject_DrawBustupShadow_SIG, "UBustupObject::DrawBustupShadow", _context._utils.GetDirectAddress, addr => _drawBustupShadow = _context._utils.MakeHooker<UBustupObject_DrawBustupShadow>(UBustupObject_DrawBustupShadowImpl, addr));
            _context._utils.SigScan(UBustupDraw_DrawBustupBottomLeftTriangle_SIG, "UBustupDraw::DrawBustupBottomLeftTriangle", _context._utils.GetDirectAddress, addr => _drawBustupBottomLeft = _context._utils.MakeHooker<UBustupDraw_DrawBustupBottomLeftTriangle>(UBustupDraw_DrawBustupBottomLeftTriangleImpl, addr));
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        private unsafe void UBustupDraw_DrawBustupImpl(UBustupDraw* self)
        {
            if (self->BustupObject_ != null)
            {
                _setBustupShadowColor(self->BustupObject_, 0xff, 0x0, 0x0);
            }
            _drawBustup.OriginalFunction(self);
        }
        private unsafe void UBustupObject_DrawBustupShadowImpl(UBustupObject* self, float a2, float a3, float a4, float a5, float a6)
        {
            if ((self->FieldB0 & 1) != 0 && a4 > 0)
            {
                var target = _context._config.BustupShadowColor;
                _setBustupShadowColor(self, target.R, target.G, target.B);
            }
            _drawBustupShadow.OriginalFunction(self, a2, a3, a4, a5, a6);
        }

        private unsafe void UBustupDraw_DrawBustupBottomLeftTriangleImpl(nint a1, float offsetX, float offsetY, float rotY, float alpha, uint queueId)
        {
            var uiResources = _uiCommon._globalWorkGetUIResources();
            if (uiResources != null)
            {
                var bottomLeftTrianglePlg = (UPlgAsset*)uiResources->GetAssetEntry(0x20);
                if (bottomLeftTrianglePlg != null)
                {
                    var masker = _uiCommon._getSpriteItemMaskInstance() + 0x20;
                    var blTriPlgPos = new FVector(offsetX + 267, offsetY + 1180, 0);
                    var blTriPlgStretch = new FVector(1, 1, 1);
                    var blTriPlgRot = new FVector(0, rotY + 20.6f, 0);
                    var blTriPlgColor = _uiCommon.ToFSprColor(_context._config.BustupShadowColor);
                    blTriPlgColor.A = (byte)(alpha * 255);
                    var blTriPlg = new PlgDefStruct1(blTriPlgPos, blTriPlgStretch, blTriPlgRot, blTriPlgColor, 0);
                    *_uiCommon._ActiveDrawTypeId = queueId;
                    _uiCommon._plgFunc1(&blTriPlg, masker, bottomLeftTrianglePlg, 0.0f, 0.0f);
                }
            }
        }

        private unsafe delegate void UBustupObject_SetBustupShadowColor(UBustupObject* self, byte R, byte G, byte B);
        private unsafe delegate void UBustupDraw_DrawBustup(UBustupDraw* self);
        private unsafe delegate void UBustupObject_DrawBustupShadow(UBustupObject* self, float a2, float a3, float a4, float a5, float a6);
        private unsafe delegate void UBustupDraw_DrawBustupBottomLeftTriangle(nint a1, float offsetX, float offsetY, float rotY, float alpha, uint queueId);
    }
}
