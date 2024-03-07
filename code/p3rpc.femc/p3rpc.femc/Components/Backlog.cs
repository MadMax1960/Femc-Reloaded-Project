using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    [StructLayout(LayoutKind.Explicit, Size = 0xA60)]
    public unsafe struct AUIBackLogDraw
    {
        //[FieldOffset(0x0000)] public AUIDrawBaseActor baseObj;
        [FieldOffset(0x02B8)] public float CursorMoveSpeed;
        [FieldOffset(0x02C0)] public TArray<float> CursorPosFix;
        [FieldOffset(0x02D0)] public float IconWaveMoveSpeed;
        [FieldOffset(0x02D8)] public TArray<int> IconWaveSmallWaitFrameList;
        [FieldOffset(0x02E8)] public TArray<int> IconWaveMediumWaitFrameList;
        [FieldOffset(0x02F8)] public TArray<int> IconWaveLargeWaitFrameList;
        [FieldOffset(0x0308)] public TArray<int> IconWaitAngleFrame;
        [FieldOffset(0x0318)] public TArray<int> IconMoveAngleFrame;
        [FieldOffset(0x0328)] public TArray<FColor> IconWaveSelColorList;
        [FieldOffset(0x0338)] public TArray<FColor> IconWaveNonSelColorList;
        [FieldOffset(0x0348)] public TArray<FColor> IconColor;
        [FieldOffset(0x0358)] public FColor BlackBoardColor;
        [FieldOffset(0x035C)] public FColor GladationBoardColor;
        [FieldOffset(0x0360)] public FColor BlueBoardColor;
        [FieldOffset(0x0364)] public FColor BlackBoardCoverColor;
        [FieldOffset(0x0368)] public TArray<int> CursorWaitMoveSlideFrame;
        [FieldOffset(0x0378)] public TArray<int> CursorMoveSlideFrame;
        [FieldOffset(0x0388)] public TArray<float> BlackBoardMoveSpeed;
        [FieldOffset(0x0398)] public TArray<float> BlueBoardMoveSpeed;
        [FieldOffset(0x03A8)] public TArray<float> BlueBoardRollSpeed;
        [FieldOffset(0x03B8)] public TArray<float> DayMoveSpeed;
        [FieldOffset(0x03C8)] public TArray<float> ScrollBarMoveSpeed;
        [FieldOffset(0x03D8)] public TArray<float> LogMoveSpeed;
        [FieldOffset(0x03E8)] public TArray<float> IconMoveSpeed;
        [FieldOffset(0x03F8)] public TArray<float> NoneMoveSpeed;
        [FieldOffset(0x0408)] public TArray<float> DecoMoveSpeed;
        [FieldOffset(0x0418)] public TArray<float> BlackBoardAlphaSpeed;
        [FieldOffset(0x0428)] public TArray<float> BlueBoardAlphaSpeed;
        [FieldOffset(0x0438)] public TArray<float> GradationAlphaSpeed;
        [FieldOffset(0x0448)] public TArray<float> DayAlphaSpeed;
        [FieldOffset(0x0458)] public TArray<float> ScrollBarAlphaSpeed;
        [FieldOffset(0x0468)] public TArray<float> LogAlphaSpeed;
        [FieldOffset(0x0478)] public TArray<float> IconAlphaSpeed;
        [FieldOffset(0x0488)] public TArray<float> NoneAlphaSpeed;
        [FieldOffset(0x0498)] public TArray<float> DecoAlphaSpeed;
        [FieldOffset(0x04A8)] public TArray<float> CursorWhiteMoveSpeed;
        [FieldOffset(0x04B8)] public TArray<float> CursorWhiteAlphaSpeed;
        [FieldOffset(0x04C8)] public TArray<float> CursorBlueMoveSpeed;
        [FieldOffset(0x04D8)] public TArray<float> CursorBlueAlphaSpeed;
        [FieldOffset(0x04E8)] public float AnimFinishTime;
        [FieldOffset(0x04EC)] public float SelMsgInterval;
        [FieldOffset(0x04F0)] public float MingMsgInterval;
        [FieldOffset(0x04F4)] public float SoundPlusPosX;
        [FieldOffset(0x04F8)] public float SoundPlusPosY;
        [FieldOffset(0x04FC)] public byte BlackboardOpacity;
        [FieldOffset(0x04FD)] public byte BlueboardOpacity;
        [FieldOffset(0x04FE)] public byte GladationOpacity;
        [FieldOffset(0x05C0)] public UTexture* tex;
        //[FieldOffset(0x05C8)] public UFrameBufferCapture* captureBackGround;
        [FieldOffset(0x0A58)] public UUILayoutDataTable* pLayoutDataTable;
    }
    public class Backlog : ModuleBase
    {
        private UICommon _uiCommon;

        private string AUIBackLogDraw_DrawBackgroundColor_SIG = "48 8B C4 53 57 48 81 EC 18 01 00 00 0F 29 70 ?? 48 8B F9";
        private string AUIBackLogDraw_DrawLogTitleColor_SIG = "F3 0F 59 05 ?? ?? ?? ?? F3 0F 2C C0 F3 0F 10 83 ?? ?? ?? ??";
        private string AUIBackLogDraw_DrawCalendarTimeOfDayColor_SIG = "48 8B 40 ?? 44 8B 84 24 ?? ?? ?? ?? 66 C7 44 24 ?? 76 FF";
        private IHook<AUIBackLogDraw_DrawBackgroundColor> _drawBgColor;

        private IAsmHook _drawLogTitleColor;
        private IAsmHook _drawCalendarTimeOfDay;

        public unsafe Backlog(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUIBackLogDraw_DrawBackgroundColor_SIG, "AUIBackLogDraw::DrawBackgroundColor", _context._utils.GetDirectAddress, addr => _drawBgColor = _context._utils.MakeHooker<AUIBackLogDraw_DrawBackgroundColor>(AUIBackLogDraw_DrawBackgroundColorImpl, addr));

            _context._utils.SigScan(AUIBackLogDraw_DrawLogTitleColor_SIG, "AUIBackLogDraw::DrawLogTitleColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp + 0x96], ${_context._config.ButtonPromptHighlightColor.R:X}",
                    $"mov byte [rsp + 0x95], ${_context._config.ButtonPromptHighlightColor.G:X}",
                    $"mov byte [rsp + 0x94], ${_context._config.ButtonPromptHighlightColor.B:X}",
                };
                _drawLogTitleColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUIBackLogDraw_DrawCalendarTimeOfDayColor_SIG, "AUIBackLogDraw::DrawCalendarTimeOfDayColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov byte [rsp + 0x82], ${_context._config.DateTimePanelBottomTextColor.R:X}",
                    $"mov byte [rsp + 0x81], ${_context._config.DateTimePanelBottomTextColor.G:X}",
                    $"mov byte [rsp + 0x80], ${_context._config.DateTimePanelBottomTextColor.B:X}",
                };
                _drawCalendarTimeOfDay = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        public unsafe void AUIBackLogDraw_DrawBackgroundColorImpl(AUIBackLogDraw* self, uint a2, uint a3, uint a4, uint a5)
        {
            _uiCommon.SetColorIgnoreAlpha(ref self->GladationBoardColor, _context._config.BackLogGladationColor);
            _uiCommon.SetColorIgnoreAlpha(ref self->BlackBoardColor, _context._config.BackLogBlackboardColor);
            _uiCommon.SetColorIgnoreAlpha(ref self->BlueBoardColor, _context._config.BackLogBlueboardColorEx);
            _drawBgColor.OriginalFunction(self, a2, a3, a4, a5);
        }
        public unsafe delegate void AUIBackLogDraw_DrawBackgroundColor(AUIBackLogDraw* self, uint a2, uint a3, uint a4, uint a5);
    }
}
