using p3rpc.commonmodutils;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;

namespace p3rpc.femc.Components
{
    class Guidance : ModuleBase<FemcContext>
    {
        private string AUIGuidanceDraw_GuidanceLeftFadeMainColor_SIG = "E8 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? 8B E8 E8";
        private string AUIGuidanceDraw_GuidanceMainColor_SIG = "E8 ?? ?? ?? ?? 41 B8 06 00 00 00 48 8D 54 24 ?? 48 8B CE";
        private string AUIGuidanceDraw_GuidanceBGSquareColor = "E8 ?? ?? ?? ?? F3 0F 10 86 ?? ?? ?? ?? 48 8D 8E";
        private string AUIGuidanceDraw_GuidanceExclamationGlowColor = "E8 ?? ?? ?? ?? 48 8B 54 24 ?? 48 8B CB 89 86";
        private string AUIGuidanceDraw_GuidanceExclamationMainColor = "E8 ?? ?? ?? ?? 4C 8B 74 24 ?? 48 8D 8E ?? ?? ?? ?? 89 86";
        private string AUIGuidanceDraw_NewGuidanceExclamationGlowColor = "E8 ?? ?? ?? ?? F3 44 0F 10 15 ?? ?? ?? ?? 48 8B CB";
        private string AUIGuidanceDraw_NewGuidanceExclamationMainColor = "E8 ?? ?? ?? ?? 48 8B 54 24 ?? 48 8D 8E ?? ?? ?? ?? 89 86";

        private IAsmHook _guidanceLeftFadeMainColor;
        private IAsmHook _guidanceMainColor;
        private IAsmHook _guidanceBGSquareColor;
        private IAsmHook _guidanceExclamationGlowColor;
        private IAsmHook _guidanceExclamationMainColor;
        private IAsmHook _newGuidanceExclamationGlowColor;
        private IAsmHook _newGuidanceExclamationMainColor;
        public unsafe Guidance(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {

            _context._utils.SigScan(AUIGuidanceDraw_GuidanceLeftFadeMainColor_SIG, "AUIGuidanceDraw::GuidanceLeftFadeMainColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.GuidanceMainBGColor.B:X}",
                    $"mov dl, ${_context._config.GuidanceMainBGColor.G:X}",
                    $"mov cl, ${_context._config.GuidanceMainBGColor.R:X}"
                };
                _guidanceLeftFadeMainColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIGuidanceDraw_GuidanceMainColor_SIG, "AUIGuidanceDraw::GuidanceMainColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.GuidanceMainBGColor.B:X}",
                    $"mov dl, ${_context._config.GuidanceMainBGColor.G:X}",
                    $"mov cl, ${_context._config.GuidanceMainBGColor.R:X}"
                };
                _guidanceMainColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIGuidanceDraw_GuidanceBGSquareColor, "AUIGuidanceDraw::GuidanceBGSquareColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.GuidanceSquareColor.B:X}",
                    $"mov dl, ${_context._config.GuidanceSquareColor.G:X}",
                    $"mov cl, ${_context._config.GuidanceSquareColor.R:X}"
                };
                _guidanceBGSquareColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIGuidanceDraw_GuidanceExclamationGlowColor, "AUIGuidanceDraw::GuidanceExclamationGlowColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.GuidanceExclamationGlowColor.B:X}",
                    $"mov dl, ${_context._config.GuidanceExclamationGlowColor.G:X}",
                    $"mov cl, ${_context._config.GuidanceExclamationGlowColor.R:X}"
                };
                _guidanceExclamationGlowColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIGuidanceDraw_GuidanceExclamationMainColor, "AUIGuidanceDraw::GuidanceExclamationMainColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.GuidanceExclamationMainColor.B:X}",
                    $"mov dl, ${_context._config.GuidanceExclamationMainColor.G:X}",
                    $"mov cl, ${_context._config.GuidanceExclamationMainColor.R:X}"
                };
                _guidanceExclamationMainColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIGuidanceDraw_NewGuidanceExclamationGlowColor, "AUIGuidanceDraw::NewGuidanceExclamationGlowColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.GuidanceExclamationGlowColor.B:X}",
                    $"mov dl, ${_context._config.GuidanceExclamationGlowColor.G:X}",
                    $"mov cl, ${_context._config.GuidanceExclamationGlowColor.R:X}"
                };
                _newGuidanceExclamationGlowColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIGuidanceDraw_NewGuidanceExclamationMainColor, "AUIGuidanceDraw::NewGuidanceExclamationMainColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.GuidanceExclamationMainColor.B:X}",
                    $"mov dl, ${_context._config.GuidanceExclamationMainColor.G:X}",
                    $"mov cl, ${_context._config.GuidanceExclamationMainColor.R:X}"
                };
                _newGuidanceExclamationMainColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }

        public override void Register() { }
    }
}
