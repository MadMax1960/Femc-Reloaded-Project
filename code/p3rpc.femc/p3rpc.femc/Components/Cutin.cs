using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using Reloaded.Hooks.Definitions.X64;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{   
    public class Cutin : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string ACutinDraw_DrawPortraitBustupShadowColor_SIG = "44 8B C8 41 B8 02 00 00 00";
        private string ACutinDraw_DrawOuterTriangleHiglhightColor_SIG = "0F 57 DB 89 87 ?? ?? ?? ?? 0F 57 D2 C6 87 ?? ?? ?? ?? 01";
        private string ACutinDraw_DrawEmotion_SIG = "45 85 C0 0F 84 ?? ?? ?? ?? 48 89 5C 24 ?? 48 89 7C 24 ?? 55";

        private IAsmHook _drawPortraitBustupShadowColor;
        private IReverseWrapper<ACutinDraw_InjectColorAfterCtorCall> _drawPortraitBustupWrapper;
        private IAsmHook _drawOuterTriangleHiglhightColor;
        private IReverseWrapper<ACutinDraw_InjectColorAfterCtorCall> _drawOuterTriangleWrapper;
        private IHook<ACutinDraw_CutinDrawEmotion> _drawEmotion;

        private UICommon _uiCommon;

        public unsafe Cutin(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(ACutinDraw_DrawPortraitBustupShadowColor_SIG, "ACutinDraw::DrawPortraitBustupShadowColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(ACutinDraw_DrawPortraitBustupShadowColor, out _drawPortraitBustupWrapper)}",
                };
                _drawPortraitBustupShadowColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(ACutinDraw_DrawOuterTriangleHiglhightColor_SIG, "ACutinDraw::DrawOuterTriangleHiglightColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(ACutinDraw_DrawOuterTriangleHiglightColor, out _drawOuterTriangleWrapper)}",
                };
                _drawOuterTriangleHiglhightColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(ACutinDraw_DrawEmotion_SIG, "ACutinDraw::DrawEmotion", _context._utils.GetDirectAddress, addr => _drawEmotion = _context._utils.MakeHooker<ACutinDraw_CutinDrawEmotion>(ACutinDraw_CutinDrawEmotionImpl, addr));
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }
        public unsafe FSprColor ACutinDraw_DrawPortraitBustupShadowColor(FSprColor source) => ConfigColor.ToFSprColorWithAlpha(_context._config.CutinOuterHighlight, source.A);
        public unsafe FSprColor ACutinDraw_DrawOuterTriangleHiglightColor(FSprColor source) => ConfigColor.ToFSprColorWithAlpha(_context._config.BustupShadowColor, source.A);

        public unsafe void ACutinDraw_CutinDrawEmotionImpl(ACutInDraw* self, nint masker, int emotion)
        {
            ConfigColor.SetColorIgnoreAlpha(ref self->EmotionGradientMain.ColorCornerTopLeft, _context._config.CutinEmotionGradient);
            ConfigColor.SetColorIgnoreAlpha(ref self->EmotionGradientMain.ColorCornerTopRight, _context._config.CutinEmotionGradient);
            ConfigColor.SetColorIgnoreAlpha(ref self->EmotionPlgTint.Color, _context._config.CutinEmotionTint);
            ConfigColor.SetColorIgnoreAlpha(ref self->EmotionHighlight.color, _context._config.CutinEmotionGradient);
            _drawEmotion.OriginalFunction(self, masker, emotion);
        }

        [Function(FunctionAttribute.Register.rax, FunctionAttribute.Register.rax, false)]
        public unsafe delegate FSprColor ACutinDraw_InjectColorAfterCtorCall(FSprColor source);

        public unsafe delegate void ACutinDraw_CutinDrawEmotion(ACutInDraw* self, nint masker, int emotion);
    }
}
