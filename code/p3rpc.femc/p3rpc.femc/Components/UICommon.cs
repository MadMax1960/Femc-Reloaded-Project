using p3rpc.femc.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class UICommon : ModuleBase
    {

        public GetSpriteItemMaskInstance _getSpriteItemMaskInstance;
        public DrawComponentMask_FUN_1412f29f0 _setSpriteDrawMaskMode;
        public USprAsset_FUN_141323540 _spriteFunc1;
        public UPlgAsset_FUN_14131f0d0 _plgFunc1;
        public DrawComponentMask_FUN_140cc8170 _spriteMaskFunc1;
        public DrawComponentMask_FUN_140cb27f0 _spriteMaskFunc2;
        public DrawComponentMask_FUN_14bffbdd0 _spriteMaskFunc3;


        private string GetSpriteItemMaskInstance_SIG = "E8 ?? ?? ?? ?? 33 D2 48 8D 58 ?? 48 8B CB";
        private string DrawComponentMask_FUN_1412f29f0_SIG = "48 83 EC 58 83 FA 0C";
        private string USprAsset_FUN_141323540_SIG = "E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ?? 0F 57 C9 8B 87 ?? ?? ?? ??";
        private string UPlgAsset_FUN_14131f0d0_SIG = "48 8B C4 48 89 58 ?? 4C 89 40 ?? 48 89 50 ?? 55 56 57 41 54 41 55 41 56 41 57 48 81 EC 00 01 00 00";
        private string DrawComponentMask_FUN_140cc8170_SIG = "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 56 41 57 48 83 EC 20 48 8D 99 ?? ?? ?? ?? 4C 8B F9 48 8B CB 41 8B E9";
        private string DrawComponentMask_FUN_140cb27f0_SIG = "E8 ?? ?? ?? ?? 48 63 87 ?? ?? ?? ?? 45 0F 28 D0";
        private string DrawComponentMask_FUN_14bffbdd0_SIG = "48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 50 31 F6";
        public unsafe UICommon(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            // Common drawing primitives
            _context._utils.SigScan(GetSpriteItemMaskInstance_SIG, "GetSpriteItemMaskInstance", _context._utils.GetIndirectAddressShort, addr => _getSpriteItemMaskInstance = _context._utils.MakeWrapper<GetSpriteItemMaskInstance>(addr));
            _context._utils.SigScan(DrawComponentMask_FUN_1412f29f0_SIG, "DrawComponentMask::FUN_1412f29f0", _context._utils.GetDirectAddress, addr => _setSpriteDrawMaskMode = _context._utils.MakeWrapper<DrawComponentMask_FUN_1412f29f0>(addr));
            _context._utils.SigScan(USprAsset_FUN_141323540_SIG, "USprAsset::FUN_141323540", _context._utils.GetIndirectAddressShort, addr => _spriteFunc1 = _context._utils.MakeWrapper<USprAsset_FUN_141323540>(addr));
            _context._utils.SigScan(UPlgAsset_FUN_14131f0d0_SIG, "UPlgAsset::FUN_14131f0d0", _context._utils.GetDirectAddress, addr => _plgFunc1 = _context._utils.MakeWrapper<UPlgAsset_FUN_14131f0d0>(addr));
            _context._utils.SigScan(DrawComponentMask_FUN_140cc8170_SIG, "DrawComponentMask::FUN_140cc8170", _context._utils.GetDirectAddress, addr => _spriteMaskFunc1 = _context._utils.MakeWrapper<DrawComponentMask_FUN_140cc8170>(addr));
            _context._utils.SigScan(DrawComponentMask_FUN_140cb27f0_SIG, "DrawComponentMask::FUN_140cb27f0", _context._utils.GetIndirectAddressShort, addr => _spriteMaskFunc2 = _context._utils.MakeWrapper<DrawComponentMask_FUN_140cb27f0>(addr));
            _context._utils.SigScan(DrawComponentMask_FUN_14bffbdd0_SIG, "DrawComponentMask::FUN_14bffbdd0", _context._utils.GetDirectAddress, addr => _spriteMaskFunc3 = _context._utils.MakeWrapper<DrawComponentMask_FUN_14bffbdd0>(addr));
        }

        public override void Register() {}

        public unsafe delegate nint GetSpriteItemMaskInstance();
        public unsafe delegate void DrawComponentMask_FUN_1412f29f0(nint worldOuter, uint idx);
        public unsafe delegate void USprAsset_FUN_141323540(SprDefStruct1* fields, nint masker, USprAsset* sprite, float a4, float a5);
        public unsafe delegate void UPlgAsset_FUN_14131f0d0(PlgDefStruct1* fields, nint masker, UPlgAsset* vector, float a4, float a5);
        public unsafe delegate void DrawComponentMask_FUN_140cc8170(nint masker, int a2, int a3, int a4, int a5, int a6, int a7, int a8, int a9);
        public unsafe delegate void DrawComponentMask_FUN_140cb27f0(nint masker, int a2, float a3, float a4, float a5, FSprColor a6, int a7);
        public unsafe delegate void UMsgProcWindow_Simple_DrawMessageText(UMsgProcWindow_Simple* self, nint masker, byte a3, float posX, float posY);
        public unsafe delegate void DrawComponentMask_FUN_14bffbdd0(nint masker, int a2, int a3);
    }
}
