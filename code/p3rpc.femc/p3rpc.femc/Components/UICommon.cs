using p3rpc.commonmodutils;
using p3rpc.femc.Configuration;
using p3rpc.nativetypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class UICommon : ModuleBase<FemcContext>
    {

        public IUIMethods.GetSpriteItemMaskInstance _getSpriteItemMaskInstance;
        public IUIMethods.UIDraw_SetPresetBlendState _setPresetBlendState;
        public IUIMethods.USprAsset_FUN_141323540 _spriteFunc1;
        public IUIMethods.UPlgAsset_FUN_14131f0d0 _plgFunc1;
        public IUIMethods.UIDraw_SetBlendState _setBlendState;
        public IUIMethods.DrawComponentMask_FUN_140cb27f0 _spriteMaskFunc2;
        public IUIMethods.DrawComponentMask_FUN_14bffbdd0 _spriteMaskFunc3;
        public IUIMethods.DrawComponentMask_FUN_140cc8760 _spriteMaskFunc4;
        public IUIMethods.DrawSingleLineText _drawSingleLineText;
        public IUIMethods.AUIDrawBaseActor_DrawPlg _drawPlg;
        public IUIMethods.AUIDrawBaseActor_DrawSpr _drawSpr;
        public IUIMethods.AUIDrawBaseActor_SetRenderTarget _setRenderTarget;
        public IUIMethods.AUIDrawBaseActor_DrawRect _drawRect;
        public IUIMethods.AUIDrawBaseActor_DrawRectV4 _drawRectV4;

        private IUIMethods.BPDrawSpr_TransformMatrixDel? _transformMtx = null;
        private IUIMethods.BPDrawSpr_RotateMatrixDel? _rotateMtx = null;

        public ICommonMethods.FMemory_Free _fMemoryFree;
        public ICommonMethods.UGlobalWork_GetUUIResources _globalWorkGetUIResources;
        public ICommonMethods.GetUGlobalWork _getUGlobalWork;
        public ICommonMethods.FAppCalculationItem_Lerp _appCalcLerp;

        public unsafe uint* _ActiveDrawTypeId; // this is literally from GFD lol

        public static FVector4[] IdentityMatrix = 
        {
            new FVector4(1, 0, 0, 0),
            new FVector4(0, 1, 0, 0),
            new FVector4(0, 0, 1, 0),
            new FVector4(0, 0, 0, 1)
        };

        public static unsafe float* IdentityMatrixNative; // 0x145361ae0
        public unsafe BPDrawSpr* GetDrawer() => (BPDrawSpr*)(_getSpriteItemMaskInstance() + 0x20);

        public unsafe UICommon(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._sharedScans.CreateListener<IUIMethods.GetSpriteItemMaskInstance>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetIndirectAddressShort, addr => _getSpriteItemMaskInstance = _context._utils.MakeWrapper<IUIMethods.GetSpriteItemMaskInstance>(addr)));
            _context._sharedScans.CreateListener<IUIMethods.UIDraw_SetPresetBlendState>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetDirectAddress, addr => _setPresetBlendState = _context._utils.MakeWrapper<IUIMethods.UIDraw_SetPresetBlendState>(addr)));
            _context._sharedScans.CreateListener<IUIMethods.USprAsset_FUN_141323540>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetIndirectAddressShort, addr => _spriteFunc1 = _context._utils.MakeWrapper<IUIMethods.USprAsset_FUN_141323540>(addr)));
            _context._sharedScans.CreateListener<IUIMethods.UPlgAsset_FUN_14131f0d0>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetDirectAddress, addr => _plgFunc1 = _context._utils.MakeWrapper<IUIMethods.UPlgAsset_FUN_14131f0d0>(addr)));
            _context._sharedScans.CreateListener<IUIMethods.UIDraw_SetBlendState>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetDirectAddress, addr => _setBlendState = _context._utils.MakeWrapper<IUIMethods.UIDraw_SetBlendState>(addr)));
            _context._sharedScans.CreateListener<IUIMethods.DrawComponentMask_FUN_140cb27f0>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetIndirectAddressShort, addr => _spriteMaskFunc2 = _context._utils.MakeWrapper<IUIMethods.DrawComponentMask_FUN_140cb27f0>(addr)));
            _context._sharedScans.CreateListener<IUIMethods.DrawComponentMask_FUN_14bffbdd0>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetDirectAddress, addr => _spriteMaskFunc3 = _context._utils.MakeWrapper<IUIMethods.DrawComponentMask_FUN_14bffbdd0>(addr)));
            _context._sharedScans.CreateListener<IUIMethods.DrawComponentMask_FUN_140cc8760>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetIndirectAddressShort, addr => _spriteMaskFunc4 = _context._utils.MakeWrapper<IUIMethods.DrawComponentMask_FUN_140cc8760>(addr)));
            _context._sharedScans.CreateListener("DrawComponentMask_ActiveDrawTypeId", addr => _context._utils.AfterSigScan(addr, _context._utils.GetIndirectAddressShort2, addr => _ActiveDrawTypeId = (uint*)addr));
            _context._sharedScans.CreateListener<IUIMethods.DrawSingleLineText>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetIndirectAddressShort, addr => _drawSingleLineText = _context._utils.MakeWrapper<IUIMethods.DrawSingleLineText>(addr)));
            _context._sharedScans.CreateListener<ICommonMethods.FMemory_Free>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetIndirectAddressShort, addr => _fMemoryFree = _context._utils.MakeWrapper<ICommonMethods.FMemory_Free>(addr)));
            _context._sharedScans.CreateListener<ICommonMethods.UGlobalWork_GetUUIResources>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetIndirectAddressShort, addr => _globalWorkGetUIResources = _context._utils.MakeWrapper<ICommonMethods.UGlobalWork_GetUUIResources>(addr)));
            _context._sharedScans.CreateListener<IUIMethods.AUIDrawBaseActor_DrawPlg>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetIndirectAddressShort, addr => _drawPlg = _context._utils.MakeWrapper<IUIMethods.AUIDrawBaseActor_DrawPlg>(addr)));
            _context._sharedScans.CreateListener<ICommonMethods.GetUGlobalWork>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetDirectAddress, addr => _getUGlobalWork = _context._utils.MakeWrapper<ICommonMethods.GetUGlobalWork>(addr)));
            _context._sharedScans.CreateListener<IUIMethods.AUIDrawBaseActor_DrawSpr>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetDirectAddress, addr => _drawSpr = _context._utils.MakeWrapper<IUIMethods.AUIDrawBaseActor_DrawSpr>(addr)));
            _context._sharedScans.CreateListener<IUIMethods.AUIDrawBaseActor_SetRenderTarget>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetDirectAddress, addr => _setRenderTarget = _context._utils.MakeWrapper<IUIMethods.AUIDrawBaseActor_SetRenderTarget>(addr)));
            _context._sharedScans.CreateListener<IUIMethods.AUIDrawBaseActor_DrawRect>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetDirectAddress, addr => _drawRect = _context._utils.MakeWrapper<IUIMethods.AUIDrawBaseActor_DrawRect>(addr)));
            _context._sharedScans.CreateListener<ICommonMethods.FAppCalculationItem_Lerp>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetIndirectAddressShort, addr => _appCalcLerp = _context._utils.MakeWrapper<ICommonMethods.FAppCalculationItem_Lerp>(addr)));
            _context._sharedScans.CreateListener<IUIMethods.AUIDrawBaseActor_DrawRectV4>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetDirectAddress, addr => _drawRectV4 = _context._utils.MakeWrapper<IUIMethods.AUIDrawBaseActor_DrawRectV4>(addr)));
            
            IdentityMatrixNative = (float*)NativeMemory.Alloc(sizeof(float) * 16);
            IdentityMatrixNative[0] = 1;
            IdentityMatrixNative[5] = 1;
            IdentityMatrixNative[10] = 1;
            IdentityMatrixNative[15] = 1;
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

        public unsafe void BPDrawSpr_TransformMatrix(BPDrawSpr* self, float* mtx, FVector* pos)
        {
            if (_transformMtx == null) _transformMtx = _context._hooks.CreateWrapper<IUIMethods.BPDrawSpr_TransformMatrixDel>(**(nint**)self, out _);
            _transformMtx(self, mtx, pos);
        }

        public unsafe void BPDrawSpr_RotateMatrix(BPDrawSpr* self, float* mtx, FVector* center, float angle)
        {
            if (_rotateMtx == null) _rotateMtx = _context._hooks.CreateWrapper<IUIMethods.BPDrawSpr_RotateMatrixDel>(*(nint*)(*(nint*)self + 0x8), out _);
            _rotateMtx(self, mtx, center, angle);
        }

        public override void Register() {}
    }
}
