using p3rpc.femc.Native;
using Reloaded.Hooks.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class MiscCheckDraw : ModuleBase
    {
        private string AUIMiscCheckDraw_DrawInteractPrompt_SIG = "40 55 56 48 8D 6C 24 ?? 48 81 EC 18 01 00 00 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 45 ?? 48 8B F1 E8 ?? ?? ?? ??";
        private IHook<AUIMiscCheckDraw_DrawInteractPrompt> _drawInteractPrompt;
        private UICommon _uiCommon;

        public unsafe MiscCheckDraw(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUIMiscCheckDraw_DrawInteractPrompt_SIG, "AUIMiscCheckDraw::DrawInteractPrompt", _context._utils.GetDirectAddress, addr => _drawInteractPrompt = _context._utils.MakeHooker<AUIMiscCheckDraw_DrawInteractPrompt>(AUIMiscCheckDraw_DrawInteractPromptImpl, addr));
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }
        private unsafe void AUIMiscCheckDraw_DrawInteractPromptImpl(AUIMiscCheckDraw* self)
        {
            _drawInteractPrompt.OriginalFunction(self);
        }

        private unsafe delegate void AUIMiscCheckDraw_DrawInteractPrompt(AUIMiscCheckDraw* self);
    }
}
