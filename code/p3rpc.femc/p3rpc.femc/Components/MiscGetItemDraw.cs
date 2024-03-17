using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class MiscGetItemDraw : ModuleBase<FemcContext>
    {
        private string AUIMiscGetItemDraw_DrawGetItem_SIG = "48 89 5C 24 ?? 48 89 74 24 ?? 55 57 41 54 41 56 41 57 48 8B EC 48 81 EC 80 00 00 00 8B 81 ?? ?? ?? ??";
        private UICommon _uiCommon;
        private IHook<AUIMiscGetItemDraw_DrawGetItem> _drawGetItem;
        public unsafe MiscGetItemDraw(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUIMiscGetItemDraw_DrawGetItem_SIG, "AUIMiscGetItemDraw::DrawGetItem", _context._utils.GetDirectAddress, addr => _drawGetItem = _context._utils.MakeHooker<AUIMiscGetItemDraw_DrawGetItem>(AUIMiscGetItemDraw_DrawGetItemImpl, addr));
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        public unsafe void AUIMiscGetItemDraw_DrawGetItemImpl(AUIMiscGetItemDraw* self)
        {
            ConfigColor.SetColor(ref self->FirstArrowBg.Color, _context._config.GetItemBgMaskColor);
            ConfigColor.SetColor(ref self->SecondArrowBg.Color, _context._config.GetItemBgColor);
            ConfigColor.SetColor(ref self->GotGraphicRightFill.Color, _context._config.GetItemGotTextColor);
            ConfigColor.SetColor(ref self->ItemCountBg.color, _context._config.GetItemCountBgColor);
            _drawGetItem.OriginalFunction(self);
        }
        public unsafe delegate void AUIMiscGetItemDraw_DrawGetItem(AUIMiscGetItemDraw* self);
    }
}
