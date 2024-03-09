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
    [StructLayout(LayoutKind.Explicit, Size = 0x858)]
    public unsafe struct AUIMiscMoneyDraw
    {
        //[FieldOffset(0x0000)] public AUIBaseActor baseObj;
        [FieldOffset(0x02D8)] public USprAsset* m_pMoneySpr;
        [FieldOffset(0x310)] public FSprColor PayMoneyMarginColor;
        [FieldOffset(0x378)] public FSprColor BuyItemAmountSubtractColor;
        [FieldOffset(0x3e0)] public FSprColor White3E0;
        [FieldOffset(0x448)] public FSprColor BuyItemBlankAmountColor;
        [FieldOffset(0x4d4)] public FSprColor BgImageTintColorFill;
        [FieldOffset(0x548)] public FSprColor BgImageTintColorBorder;
        [FieldOffset(0x5bc)] public FSprColor MoneyTiltShadowColor;
        [FieldOffset(0x630)] public FSprColor Field630;
        [FieldOffset(0x67c)] public FSprColor White67C;
        [FieldOffset(0x6cc)] public FSprColor BuyItemAmountSubtractNumberColor;
        [FieldOffset(0x708)] public int MoneyDialogType;
    }
    public class MiscMoneyDraw : ModuleBase
    {
        private UICommon _uiCommon;
        private string AUIMiscMoneyDraw_UpdateParams_SIG = "48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 40 0F 29 7C 24 ??";
        private IHook<AUIMiscMoneyDraw_UpdateParams> _updateParams;
        public unsafe MiscMoneyDraw(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUIMiscMoneyDraw_UpdateParams_SIG, "AUIMiscMoneyDraw::UpdateParams", _context._utils.GetDirectAddress, addr => _updateParams = _context._utils.MakeHooker<AUIMiscMoneyDraw_UpdateParams>(AUIMiscMoneyDraw_UpdateParamsImpl, addr));
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        public unsafe void AUIMiscMoneyDraw_UpdateParamsImpl(AUIMiscMoneyDraw* self, int moneyDialogType, float opacity)
        {
            _uiCommon.SetColorCustomAlpha(ref self->White3E0, _context.ColorWhite, (byte)(opacity * 255));
            _uiCommon.SetColorCustomAlpha(ref self->White3E0, _context.ColorWhite, (byte)(opacity * 255));
            var opInv = 1 - opacity;
            self->Field630 = new FSprColor((byte)(opInv * 255), (byte)(opInv * 246 + 9), (byte)(opInv * 202 + 53), 0x33);
            switch (self->MoneyDialogType) {
                case 1: // Aohige Pharmacy
                    self->BuyItemAmountSubtractNumberColor = new FSprColor(0, 0xea, 0xff, (byte)(opacity * 255));
                    self->BuyItemAmountSubtractColor = new FSprColor(0, 0xea, 0xff, (byte)(opacity * 255));
                    self->PayMoneyMarginColor = new FSprColor(0, 0xea, 0xff, (byte)(opacity * 255));
                    self->BgImageTintColorFill = new FSprColor(0, 0, 0, (byte)(opacity * 255));
                    self->BgImageTintColorBorder = new FSprColor(0xff, 0xff, 0xff, (byte)(opacity * opacity * 255));
                    self->MoneyTiltShadowColor = new FSprColor(0, 0x2a, 0xff, (byte)(opacity * opacity * 255));
                    self->BuyItemBlankAmountColor = new FSprColor(0, 0x2a, 0x79, (byte)(opacity * opacity * 204));
                    break;
                case 2: // Police Station
                    self->BuyItemAmountSubtractNumberColor = new FSprColor(0xff, 0xf6, 0, (byte)(opacity * 255));
                    self->BuyItemAmountSubtractColor = new FSprColor(0xff, 0xf6, 0, (byte)(opacity * 255));
                    self->PayMoneyMarginColor = new FSprColor(0xff, 0xf6, 0, (byte)(opacity * 255));
                    self->BgImageTintColorFill = new FSprColor(0, 0, 0, (byte)(opacity * 255));
                    self->BgImageTintColorBorder = new FSprColor(0xff, 0xff, 0xff, (byte)(opacity * opacity * 255));
                    self->MoneyTiltShadowColor = new FSprColor(0xff, 0xf6, 0, (byte)(opacity * 255));
                    self->BuyItemBlankAmountColor = new FSprColor(0x79, 0x75, 0, (byte)(opacity * opacity * 204));
                    break;
                case 3:
                    self->BuyItemAmountSubtractNumberColor = new FSprColor(0xaa, 0x6b, 0xff, (byte)(opacity * 255));
                    self->BuyItemAmountSubtractColor = new FSprColor(0xaa, 0x6b, 0xff, (byte)(opacity * 255));
                    self->PayMoneyMarginColor = new FSprColor(0xaa, 0x6b, 0xff, (byte)(opacity * 255));
                    self->BgImageTintColorFill = new FSprColor(0, 0, 0, (byte)(opacity * 255));
                    self->BgImageTintColorBorder = new FSprColor(0xff, 0xff, 0xff, (byte)(opacity * opacity * 255));
                    self->MoneyTiltShadowColor = new FSprColor(0xaa, 0x6b, 0xff, (byte)(opacity * 255));
                    self->BuyItemBlankAmountColor = new FSprColor(0x51, 0x33, 0x79, (byte)(opacity * opacity * 204));
                    break;
                default: // Regular shop
                    _uiCommon.SetColorCustomAlpha(ref self->BuyItemAmountSubtractNumberColor, _context._config.ShopPayColor, (byte)(opacity * 255));
                    _uiCommon.SetColorCustomAlpha(ref self->BuyItemAmountSubtractColor, _context._config.ShopPayColor, (byte)(opacity * 255));
                    _uiCommon.SetColorCustomAlpha(ref self->PayMoneyMarginColor, _context._config.ShopPayColor, (byte)(opacity * 255));
                    _uiCommon.SetColorCustomAlpha(ref self->BgImageTintColorFill, _context._config.ShopFillColor, (byte)(opacity * 255));
                    _uiCommon.SetColorCustomAlpha(ref self->BgImageTintColorBorder, _context._config.ShopFillColor, (byte)(opacity * opacity * 255));
                    _uiCommon.SetColorCustomAlpha(ref self->MoneyTiltShadowColor, _context._config.ShopShadowColor, (byte)(opacity * opacity * 204));
                    _uiCommon.SetColorCustomAlpha(ref self->BuyItemBlankAmountColor, _context._config.ShopPayUnselColor, (byte)(opacity * opacity * 204));
                    break;
            }
            //_updateParams.OriginalFunction(self, moneyDialogType, opacity);
        }
        public unsafe delegate void AUIMiscMoneyDraw_UpdateParams(AUIMiscMoneyDraw* self, int moneyDialogType, float opacity);
    }
}
