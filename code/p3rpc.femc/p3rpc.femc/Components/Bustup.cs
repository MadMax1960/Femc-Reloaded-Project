using p3rpc.femc.Native;
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
        private UBustupObject_SetBustupShadowColor _setBustupShadowColor;
        private IHook<UBustupDraw_DrawBustup> _drawBustup;
        private IHook<UBustupObject_DrawBustupShadow> _drawBustupShadow;
        public unsafe Bustup(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(UBustupObject_SetBustupShadowColor_SIG, "UBustupObject::SetBustupShadowColor", _context._utils.GetDirectAddress, addr => _setBustupShadowColor = _context._utils.MakeWrapper<UBustupObject_SetBustupShadowColor>(addr));
            //_context._utils.SigScan(UBustupDraw_DrawBustup_SIG, "UBustupDraw::DrawBustup", _context._utils.GetDirectAddress, addr => _drawBustup = _context._utils.MakeHooker<UBustupDraw_DrawBustup>(UBustupDraw_DrawBustupImpl, addr));
            _context._utils.SigScan(UBustupObject_DrawBustupShadow_SIG, "UBustupObject::DrawBustupShadow", _context._utils.GetDirectAddress, addr => _drawBustupShadow = _context._utils.MakeHooker<UBustupObject_DrawBustupShadow>(UBustupObject_DrawBustupShadowImpl, addr));
        }

        public override void Register()
        {

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
        private unsafe delegate void UBustupObject_SetBustupShadowColor(UBustupObject* self, byte R, byte G, byte B);
        private unsafe delegate void UBustupDraw_DrawBustup(UBustupDraw* self);
        private unsafe delegate void UBustupObject_DrawBustupShadow(UBustupObject* self, float a2, float a3, float a4, float a5, float a6);
    }
}
