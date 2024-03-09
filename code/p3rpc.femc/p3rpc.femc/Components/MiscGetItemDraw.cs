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
    [StructLayout(LayoutKind.Explicit, Size = 0xE38)]
    public unsafe struct AUIMiscGetItemDraw
    {
        //[FieldOffset(0x0000)] public AUIBaseActor baseObj;
        [FieldOffset(0x0308)] public USprAsset* m_pGetItemSpr;
        [FieldOffset(0x0310)] public UPlgAsset* m_pGetPlg;
        [FieldOffset(0x0318)] public UDataTable* m_pItemGetDT;
        [FieldOffset(0x0320)] public USprAsset* m_pSpecialKeyHelpSpr;
        [FieldOffset(0x0328)] public USprAsset* m_pSpecialKeyHelpTextSpr;
        [FieldOffset(0x0330)] public UDataTable* m_pLayoutTextColDT;
        [FieldOffset(0x0338)] public UDataTable* m_pLayoutOkNextDT;
        [FieldOffset(0x0340)] public UDataTable* m_pLayoutOkNextMaskDT;
        [FieldOffset(0x0348)] public UUILayoutDataTable* m_pLayoutTextCol;
        [FieldOffset(0x0350)] public UUILayoutDataTable* m_pLayoutOkNext;
        [FieldOffset(0x0358)] public UUILayoutDataTable* m_pLayoutOkNextMask;
        [FieldOffset(0x440)] public SprDefStruct1 ItemCountBg;
        [FieldOffset(0x7e8)] public LocationSelectParams1 FirstArrowBg;
        [FieldOffset(0x85c)] public LocationSelectParams1 SecondArrowBg;
        [FieldOffset(0xaa0)] public PlgDefStruct1 GotGraphicLeftOutline;
        [FieldOffset(0xae0)] public PlgDefStruct1 GotGraphicRightFill;
    }
    public class MiscGetItemDraw : ModuleBase
    {
        private string AUIMiscGetItemDraw_DrawGetItem_SIG = "48 89 5C 24 ?? 48 89 74 24 ?? 55 57 41 54 41 56 41 57 48 8B EC 48 81 EC 80 00 00 00 8B 81 ?? ?? ?? ??";
        private UICommon _uiCommon;
        private IHook<AUIMiscGetItemDraw_DrawGetItem> _drawGetItem;
        public unsafe MiscGetItemDraw(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUIMiscGetItemDraw_DrawGetItem_SIG, "AUIMiscGetItemDraw::DrawGetItem", _context._utils.GetDirectAddress, addr => _drawGetItem = _context._utils.MakeHooker<AUIMiscGetItemDraw_DrawGetItem>(AUIMiscGetItemDraw_DrawGetItemImpl, addr));
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        public unsafe void AUIMiscGetItemDraw_DrawGetItemImpl(AUIMiscGetItemDraw* self)
        {
            _uiCommon.SetColor(ref self->FirstArrowBg.Color, _context._config.GetItemBgMaskColor);
            _uiCommon.SetColor(ref self->SecondArrowBg.Color, _context._config.GetItemBgColor);
            _uiCommon.SetColor(ref self->GotGraphicRightFill.Color, _context._config.GetItemGotTextColor);
            _uiCommon.SetColor(ref self->ItemCountBg.color, _context._config.GetItemCountBgColor);
            _drawGetItem.OriginalFunction(self);
        }
        public unsafe delegate void AUIMiscGetItemDraw_DrawGetItem(AUIMiscGetItemDraw* self);
    }
}
