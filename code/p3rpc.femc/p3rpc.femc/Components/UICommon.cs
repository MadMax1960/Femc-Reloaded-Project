using p3rpc.nativetypes.Interfaces;
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
        public UIDraw_SetPresetBlendState _setPresetBlendState;
        public USprAsset_FUN_141323540 _spriteFunc1;
        public UPlgAsset_FUN_14131f0d0 _plgFunc1;
        public UIDraw_SetBlendState _setBlendState;
        public DrawComponentMask_FUN_140cb27f0 _spriteMaskFunc2;
        public DrawComponentMask_FUN_14bffbdd0 _spriteMaskFunc3;
        public DrawComponentMask_FUN_140cc8760 _spriteMaskFunc4;
        public DrawSingleLineText _drawSingleLineText;
        public FMemory_Free _fMemoryFree;
        public UGlobalWork_GetUUIResources _globalWorkGetUIResources;
        public AUIDrawBaseActor_DrawPlg _drawPlg;
        public GetUGlobalWork _getUGlobalWork;
        public AUIDrawBaseActor_DrawSpr _drawSpr;
        public AUIDrawBaseActor_SetRenderTarget _setRenderTarget;

        public unsafe uint* _ActiveDrawTypeId; // this is literally from GFD lol

        private string GetSpriteItemMaskInstance_SIG = "E8 ?? ?? ?? ?? 33 D2 48 8D 58 ?? 48 8B CB";
        private string UIDraw_SetPresetBlendState_SIG = "48 83 EC 58 83 FA 0C";
        private string USprAsset_FUN_141323540_SIG = "E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ?? 0F 57 C9 8B 87 ?? ?? ?? ??";
        private string UPlgAsset_FUN_14131f0d0_SIG = "48 8B C4 48 89 58 ?? 4C 89 40 ?? 48 89 50 ?? 55 56 57 41 54 41 55 41 56 41 57 48 81 EC 00 01 00 00";
        private string UIDraw_SetBlendState_SIG = "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 41 56 41 57 48 83 EC 20 48 8D 99 ?? ?? ?? ?? 4C 8B F9 48 8B CB 41 8B E9";
        private string DrawComponentMask_FUN_140cb27f0_SIG = "E8 ?? ?? ?? ?? 48 63 87 ?? ?? ?? ?? 45 0F 28 D0";
        private string DrawComponentMask_FUN_14bffbdd0_SIG = "48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC 50 31 F6";
        private string DrawComponentMask_FUN_140cc8760_SIG = "E8 ?? ?? ?? ?? C7 44 24 ?? 23 00 00 00 45 33 E4";
        private string SpriteMaskType_ActiveDrawTypeId_SIG = "89 0D ?? ?? ?? ?? 41 8B CF"; // 0x141118a1f
        private string DrawSingleLineText_SIG = "E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ?? 48 8D 8D ?? ?? ?? ?? F3 44 0F 58 0D ?? ?? ?? ??";
        private string FMemory_Free_SIG = "E8 ?? ?? ?? ?? 48 8B 4D ?? 4C 8B BC 24 ?? ?? ?? ?? 48 85 C9 74 ?? E8 ?? ?? ?? ?? 4C 8B A4 24 ?? ?? ?? ??";
        private string UGlobalWork_GetUUIResources_SIG = "E8 ?? ?? ?? ?? 48 85 C0 0F 84 ?? ?? ?? ?? B2 20";
        private string AUIDrawBaseActor_DrawPlg_SIG = "E8 ?? ?? ?? ?? 33 D2 48 8D 4E ?? E8 ?? ?? ?? ?? 0F B6 86 ?? ?? ?? ??";
        private string GetUGlobalWork_SIG = "48 89 5C 24 ?? 57 48 83 EC 20 48 8B 0D ?? ?? ?? ?? 33 DB";
        private string AUIDrawBaseActor_DrawSpr_SIG = "48 8B C4 48 89 58 ?? 48 89 70 ?? 48 89 78 ?? 55 48 8D 68 ?? 48 81 EC C0 00 00 00 48 8B 5D ??";
        private string AUIDrawBaseActor_SetRenderTarget_SIG = "48 89 5C 24 ?? 57 48 83 EC 20 41 8B F8 45 8B C8 45 33 C0";

        public static FVector4[] IdentityMatrix = // 0x145361ae0
        {
            new FVector4(1, 0, 0, 0),
            new FVector4(0, 1, 0, 0),
            new FVector4(0, 0, 1, 0),
            new FVector4(0, 0, 0, 1)
        };

        public FColor ToFColor(Configuration.ConfigColor cfgColor) => new FColor(cfgColor.R, cfgColor.G, cfgColor.B, cfgColor.A);
        public FSprColor ToFSprColor(Configuration.ConfigColor cfgColor) => new FSprColor(cfgColor.R, cfgColor.G, cfgColor.B, cfgColor.A);
        public FLinearColor ToFLinearColor(Configuration.ConfigColor cfgColor) => new FLinearColor((float)cfgColor.R / 256, (float)cfgColor.G / 256, (float)cfgColor.B / 256, (float)cfgColor.A / 256);
        public FColor ToFColorBP(Configuration.ConfigColor cfgColor) => new FColor(cfgColor.A, cfgColor.R, cfgColor.G, cfgColor.B);
        public void SetColor(ref FSprColor color, Configuration.ConfigColor cfgColor)
        {
            color.R = cfgColor.R;
            color.G = cfgColor.G;
            color.B = cfgColor.B;
            color.A = cfgColor.A;
        }

        public void SetColorIgnoreAlpha(ref FSprColor color, Configuration.ConfigColor cfgColor)
        {
            color.R = cfgColor.R;
            color.G = cfgColor.G;
            color.B = cfgColor.B;
        }

        public void SetColorCustomAlpha(ref FSprColor color, Configuration.ConfigColor cfgColor, byte alpha)
        {
            color.R = cfgColor.R;
            color.G = cfgColor.G;
            color.B = cfgColor.B;
            color.A = alpha;
        }

        public void SetColor(ref FColor color, Configuration.ConfigColor cfgColor)
        {
            color.R = cfgColor.R;
            color.G = cfgColor.G;
            color.B = cfgColor.B;
            color.A = cfgColor.A;
        }

        public void SetColorIgnoreAlpha(ref FColor color, Configuration.ConfigColor cfgColor)
        {
            color.R = cfgColor.R;
            color.G = cfgColor.G;
            color.B = cfgColor.B;
        }

        public void SetColorCustomAlpha(ref FColor color, Configuration.ConfigColor cfgColor, byte alpha)
        {
            color.R = cfgColor.R;
            color.G = cfgColor.G;
            color.B = cfgColor.B;
            color.A = alpha;
        }

        public void SetColor(ref FLinearColor color, Configuration.ConfigColor cfgColor)
        {
            color.R = (float)cfgColor.R / 256;
            color.G = (float)cfgColor.G / 256;
            color.B = (float)cfgColor.B / 256;
            color.A = (float)cfgColor.A / 256;
        }

        public unsafe BPDrawSpr* GetDrawer() => (BPDrawSpr*)(_getSpriteItemMaskInstance() + 0x20);

        public unsafe UICommon(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            // Common drawing primitives
            _context._utils.SigScan(GetSpriteItemMaskInstance_SIG, "GetSpriteItemMaskInstance", _context._utils.GetIndirectAddressShort, addr => _getSpriteItemMaskInstance = _context._utils.MakeWrapper<GetSpriteItemMaskInstance>(addr));
            _context._utils.SigScan(UIDraw_SetPresetBlendState_SIG, "UIDraw::SetPresetBlendState", _context._utils.GetDirectAddress, addr => _setPresetBlendState = _context._utils.MakeWrapper<UIDraw_SetPresetBlendState>(addr));
            _context._utils.SigScan(USprAsset_FUN_141323540_SIG, "USprAsset::FUN_141323540", _context._utils.GetIndirectAddressShort, addr => _spriteFunc1 = _context._utils.MakeWrapper<USprAsset_FUN_141323540>(addr));
            _context._utils.SigScan(UPlgAsset_FUN_14131f0d0_SIG, "UPlgAsset::FUN_14131f0d0", _context._utils.GetDirectAddress, addr => _plgFunc1 = _context._utils.MakeWrapper<UPlgAsset_FUN_14131f0d0>(addr));
            _context._utils.SigScan(UIDraw_SetBlendState_SIG, "UIDraw::SetBlendState", _context._utils.GetDirectAddress, addr => _setBlendState = _context._utils.MakeWrapper<UIDraw_SetBlendState>(addr));
            _context._utils.SigScan(DrawComponentMask_FUN_140cb27f0_SIG, "DrawComponentMask::FUN_140cb27f0", _context._utils.GetIndirectAddressShort, addr => _spriteMaskFunc2 = _context._utils.MakeWrapper<DrawComponentMask_FUN_140cb27f0>(addr));
            _context._utils.SigScan(DrawComponentMask_FUN_14bffbdd0_SIG, "DrawComponentMask::FUN_14bffbdd0", _context._utils.GetDirectAddress, addr => _spriteMaskFunc3 = _context._utils.MakeWrapper<DrawComponentMask_FUN_14bffbdd0>(addr));
            _context._utils.SigScan(DrawComponentMask_FUN_140cc8760_SIG, "DrawComponentMask::FUN_140cc8760", _context._utils.GetIndirectAddressShort, addr => _spriteMaskFunc4 = _context._utils.MakeWrapper<DrawComponentMask_FUN_140cc8760>(addr));
            _context._utils.SigScan(SpriteMaskType_ActiveDrawTypeId_SIG, "DrawComponentMask::ActiveDrawTypeId", _context._utils.GetIndirectAddressShort2, addr => _ActiveDrawTypeId = (uint*)addr);
            _context._utils.SigScan(DrawSingleLineText_SIG, "DrawSingleLineText", _context._utils.GetIndirectAddressShort, addr => _drawSingleLineText = _context._utils.MakeWrapper<DrawSingleLineText>(addr));
            _context._utils.SigScan(FMemory_Free_SIG, "FMemory::Free", _context._utils.GetIndirectAddressShort, addr => _fMemoryFree = _context._utils.MakeWrapper<FMemory_Free>(addr));
            _context._utils.SigScan(UGlobalWork_GetUUIResources_SIG, "UGlobalWork::GetUUIResources", _context._utils.GetIndirectAddressShort, addr => _globalWorkGetUIResources = _context._utils.MakeWrapper<UGlobalWork_GetUUIResources>(addr));
            _context._utils.SigScan(AUIDrawBaseActor_DrawPlg_SIG, "AUIDrawBaseActor::DrawPlg", _context._utils.GetIndirectAddressShort, addr => _drawPlg = _context._utils.MakeWrapper<AUIDrawBaseActor_DrawPlg>(addr));
            _context._utils.SigScan(GetUGlobalWork_SIG, "GetUGlobalWork", _context._utils.GetDirectAddress, addr => _getUGlobalWork = _context._utils.MakeWrapper<GetUGlobalWork>(addr));
            _context._utils.SigScan(AUIDrawBaseActor_DrawSpr_SIG, "AUIDrawBaseActor::DrawSpr", _context._utils.GetDirectAddress, addr => _drawSpr = _context._utils.MakeWrapper<AUIDrawBaseActor_DrawSpr>(addr));
            _context._utils.SigScan(AUIDrawBaseActor_SetRenderTarget_SIG, "AUIDrawBaseActor::SetRenderTarget", _context._utils.GetDirectAddress, addr => _setRenderTarget = _context._utils.MakeWrapper<AUIDrawBaseActor_SetRenderTarget>(addr));
        }

        public static float Lerp(float a, float b, float c) => (1 - c) * a + b * c; // FUN_14117cd40

        public static float ProgressTrackFraction(float value, float min, float max, uint mode) // FUN_1414e8310
        {
            if (value > max) return 1;
            else if (value < min) return 0;
            else
            {
                var fraction = (value - min) / (max - min);
                return mode switch
                {
                    1 => 1 - (1 - fraction) * (1 - fraction),
                    2 => fraction * fraction,
                    3 | 9 => (1 - (float)Math.Cos(fraction * 3.141593)) * 0.5f,
                    4 => 1 - (1 - fraction) * (1 - fraction) * (1 - fraction),
                    5 => fraction * fraction * fraction,
                    7 => (float)Math.Sin(fraction),
                    _ => fraction
                };
            }
        }

        public override void Register() {}

        public unsafe delegate nint GetSpriteItemMaskInstance();
        public unsafe delegate void UIDraw_SetPresetBlendState(nint worldOuter, EUIOTPRESET_BLEND_TYPE idx);
        public unsafe delegate void USprAsset_FUN_141323540(SprDefStruct1* fields, nint masker, USprAsset* sprite, float a4, float a5);
        public unsafe delegate void UPlgAsset_FUN_14131f0d0(PlgDefStruct1* fields, nint masker, UPlgAsset* vector, float a4, float a5);
        public unsafe delegate void UIDraw_SetBlendState(nint masker, EUIBlendOperation opColor, EUIBlendFactor srcColor, EUIBlendFactor dstColor, EUIBlendOperation opAlpha, EUIBlendFactor srcAlpha, EUIBlendFactor dstAlpha, int a8, int queueId);
        public unsafe delegate void DrawComponentMask_FUN_140cb27f0(nint masker, float posX, float posY, float sizeX, float sizeY, FSprColor a6, int drawTypeId);
        public unsafe delegate void UMsgProcWindow_Simple_DrawMessageText(UMsgProcWindow_Simple* self, nint masker, byte opacity, float posX, float posY);
        public unsafe delegate void DrawComponentMask_FUN_14bffbdd0(nint masker, int a2, int a3);
        public unsafe delegate void DrawSingleLineText(float posX, float posY, float posZ, FSprColor color, float a5, nint a6, int drawTypeId, int a8, long a9, byte a10);
        public unsafe delegate void FMemory_Free(nint ptr);
        public unsafe delegate void DrawComponentMask_FUN_140cc8760(nint masker, nint a2, uint queueId);
        public unsafe delegate UUIResources* UGlobalWork_GetUUIResources();
        public unsafe delegate void AUIDrawBaseActor_DrawPlg(BPDrawSpr* drawer, float X, float Y, float Z, FColor* color, uint plgId, float scaleX, float scaleY, float angle, UPlgAsset* plgHandle, int queueId);
        public unsafe delegate UGlobalWork* GetUGlobalWork();
        public unsafe delegate void AUIDrawBaseActor_DrawSpr(BPDrawSpr* drawer, float X, float Y, float Z, FColor* color, uint sprId, float scaleX, float scaleY, float angle, USprAsset* sprHandle, EUI_DRAW_POINT drawPoint, int queueId);
        public unsafe delegate void AUIDrawBaseActor_SetRenderTarget(BPDrawSpr* drawer, nint kernelCanvas, uint queueId); // FRenderTargetCanvas*
    }
}
