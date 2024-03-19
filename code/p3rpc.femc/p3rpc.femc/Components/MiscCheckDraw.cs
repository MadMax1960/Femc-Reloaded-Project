using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class MiscCheckDraw : ModuleBase<FemcContext>
    {
        private string AUIMiscCheckDraw_DrawInteractPrompt_SIG = "40 55 56 48 8D 6C 24 ?? 48 81 EC 18 01 00 00 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 45 ?? 48 8B F1 E8 ?? ?? ?? ??";
        private string AUIMiscCheckDraw_GetCheckDrawAssets_SIG = "40 57 48 83 EC 60 48 83 B9 ?? ?? ?? ?? 00 48 8B F9 75 ?? B0 01";
        private IHook<AUIMiscCheckDraw_DrawInteractPrompt> _drawInteractPrompt;
        private AUIMiscCheckDraw_GetCheckDrawAssets _getCheckDrawAssets;
        private UICommon _uiCommon;

        public unsafe MiscCheckDraw(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUIMiscCheckDraw_DrawInteractPrompt_SIG, "AUIMiscCheckDraw::DrawInteractPrompt", _context._utils.GetDirectAddress, addr => _drawInteractPrompt = _context._utils.MakeHooker<AUIMiscCheckDraw_DrawInteractPrompt>(AUIMiscCheckDraw_DrawInteractPromptImpl, addr));
            _context._utils.SigScan(AUIMiscCheckDraw_GetCheckDrawAssets_SIG, "AUIMiscCheckDraw::GetCheckDrawAssets", _context._utils.GetDirectAddress, addr => _getCheckDrawAssets = _context._utils.MakeWrapper<AUIMiscCheckDraw_GetCheckDrawAssets>(addr));
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        private unsafe float GetCheckDrawOpacity(CheckDrawUIStruct1* a1) => Math.Clamp(a1->Field28 / a1->Field20, 0, 1);

        // use AUIMiscCheckDraw::UpdateCheckDrawState for color reference
        private unsafe void AUIMiscCheckDraw_DrawInteractPromptImpl(AUIMiscCheckDraw* self)
        {
            if (_getCheckDrawAssets(self))
            {
                var checkBgBackColor = _context._config.CheckDrawBgColor;
                checkBgBackColor.A = (byte)(GetCheckDrawOpacity(&self->FieldAE0) * 255);
                ConfigColor.SetColor(ref self->checkBgBack.Color, checkBgBackColor);

                var checkBgFrontBorderColor = _context._config.CheckDrawFgBorderColor;
                checkBgFrontBorderColor.A = (byte)(GetCheckDrawOpacity(&self->FieldAE0) * 255);
                ConfigColor.SetColor(ref self->CheckBgFrontBorderColor, checkBgFrontBorderColor);

                var checkBgFrontColor = _context._config.CheckDrawFgColor;
                checkBgFrontColor.A = (byte)(GetCheckDrawOpacity(&self->FieldAE0) * 204);
                ConfigColor.SetColor(ref self->checkBgFront.Color, checkBgFrontColor);

                var defParamsAlpha = _context._config.CheckDrawBgColor;
                defParamsAlpha.A = (byte)(GetCheckDrawOpacity(&self->FieldAE0) * 127.5);
                ConfigColor.SetColor(ref self->sprDefParamsAlpha.color, defParamsAlpha);
            }
            _drawInteractPrompt.OriginalFunction(self);
        }

        private unsafe delegate void AUIMiscCheckDraw_DrawInteractPrompt(AUIMiscCheckDraw* self);
        private unsafe delegate bool AUIMiscCheckDraw_GetCheckDrawAssets(AUIMiscCheckDraw* self);
    }
}
