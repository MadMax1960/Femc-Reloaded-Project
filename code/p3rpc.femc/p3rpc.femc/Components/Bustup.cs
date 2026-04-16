using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;

namespace p3rpc.femc.Components
{
    public class Bustup : ModuleBase<FemcContext>
    {
        private MultiSignature UBustupObject_SetBustupShadowColor_MS;
        private string[] UBustupObject_SetBustupShadowColor_SIG = [
            "40 53 48 83 EC 30 F3 0F 10 05 ?? ?? ?? ?? 48 89 CB",
            "40 53 48 83 EC 30 F3 0F 10 05 ?? ?? ?? ?? 48 8B D9 F3 0F 10 1D ?? ?? ?? ??"
        ];
        private MultiSignature UBustupObject_DrawBustupShadow_MS;
        private string[] UBustupObject_DrawBustupShadow_SIG = [
            "48 89 E0 53 48 81 EC C0 00 00 00",
            "48 8B C4 53 48 81 EC C0 00 00 00 F6 81 ?? ?? ?? ?? 01"
        ];
        private string UBustupDraw_DrawBustupBottomLeftTriangle_SIG = "48 8B C4 48 81 EC C8 00 00 00 0F 29 78 ??";
        private MultiSignature UBustupObject_DrawBustupMain_MS;
        private string[] UBustupObject_DrawBustupMain_SIG = [
            "48 89 E0 57 48 81 EC C0 00 00 00",
            "48 8B C4 57 48 81 EC C0 00 00 00 F6 81 ?? ?? ?? ?? 01"
        ];

        private UBustupObject_SetBustupShadowColor _setBustupShadowColor;
        public IHook<UBustupObject_DrawBustupShadow> _drawBustupShadow;
        public IHook<UBustupDraw_DrawBustupBottomLeftTriangle> _drawBustupBottomLeft;
        public UBustupObject_DrawBustupMain _drawBustupMain;

        private UICommon _uiCommon;
        public unsafe Bustup(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            UBustupObject_SetBustupShadowColor_MS = new ();
            _context._utils.MultiSigScan(UBustupObject_SetBustupShadowColor_SIG,
                "UBustupObject::SetBustupShadowColor", _context._utils.GetDirectAddress,
                addr => _setBustupShadowColor = _context._utils.MakeWrapper<UBustupObject_SetBustupShadowColor>(addr),
                UBustupObject_SetBustupShadowColor_MS
            );
            UBustupObject_DrawBustupShadow_MS = new ();
            _context._utils.MultiSigScan(UBustupObject_DrawBustupShadow_SIG,
                "UBustupObject::DrawBustupShadow", _context._utils.GetDirectAddress,
                addr => _drawBustupShadow = _context._utils.MakeHooker<UBustupObject_DrawBustupShadow>(UBustupObject_DrawBustupShadowImpl, addr),
                UBustupObject_DrawBustupShadow_MS
            );
            _context._utils.SigScan(UBustupDraw_DrawBustupBottomLeftTriangle_SIG, "UBustupDraw::DrawBustupBottomLeftTriangle", _context._utils.GetDirectAddress, 
                addr => _drawBustupBottomLeft = _context._utils.MakeHooker<UBustupDraw_DrawBustupBottomLeftTriangle>(UBustupDraw_DrawBustupBottomLeftTriangleImpl, addr));
            UBustupObject_DrawBustupMain_MS = new ();
            _context._utils.MultiSigScan(UBustupObject_DrawBustupMain_SIG,
                "UBustupObject::DrawBustupMain", _context._utils.GetDirectAddress,
                addr => _drawBustupMain = _context._utils.MakeWrapper<UBustupObject_DrawBustupMain>(addr),
                UBustupObject_DrawBustupMain_MS
            );
        }

        public override void Register() => _uiCommon = GetModule<UICommon>();
        
        public unsafe void UBustupObject_DrawBustupShadowImpl(UBustupObject* self, float x, float y, float a4, uint a5, float a6)
        {
            if ((self->FieldB0 & 1) != 0 && a4 > 0)
            {
                var target = _context._config.BustupShadowColor;
                _setBustupShadowColor(self, target.R, target.G, target.B);
            }
            _drawBustupShadow.OriginalFunction(self, x, y, a4, a5, a6);
        }

        public unsafe void UBustupDraw_DrawBustupBottomLeftTriangleImpl(UBustupDraw* self, float offsetX, float offsetY, float rotY, float alpha, uint queueId)
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
                    var blTriPlgColor = ConfigColor.ToFSprColor(_context._config.BustupShadowColor);
                    blTriPlgColor.A = (byte)(alpha * 255);
                    var blTriPlg = new PlgDefStruct1(blTriPlgPos, blTriPlgStretch, blTriPlgRot, blTriPlgColor, 0);
                    *_uiCommon._ActiveDrawTypeId = queueId;
                    _uiCommon._plgFunc1(&blTriPlg, masker, bottomLeftTrianglePlg, 0.0f, 0.0f);
                }
            }
        }

        private unsafe delegate void UBustupObject_SetBustupShadowColor(UBustupObject* self, byte R, byte G, byte B);
        public unsafe delegate void UBustupObject_DrawBustupShadow(UBustupObject* self, float x, float y, float a4, uint a5, float a6);
        public unsafe delegate void UBustupDraw_DrawBustupBottomLeftTriangle(UBustupDraw* self, float offsetX, float offsetY, float rotY, float alpha, uint queueId);
        public unsafe delegate void UBustupObject_DrawBustupMain(UBustupObject* self, float x, float y, float a4, uint a5, float a6);
    }
}
