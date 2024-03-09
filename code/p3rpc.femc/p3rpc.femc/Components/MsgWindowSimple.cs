using p3rpc.femc.Configuration;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using Reloaded.Hooks.Definitions.X64;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static p3rpc.femc.Components.UICommon;

namespace p3rpc.femc.Components
{
    public class MsgWindowSimple : ModuleBase
    {
        private IHook<UMsgProcWindow_Simple_DrawMessageBox> _drawMsgBoxSimple;
        private UMsgProcWindow_Simple_DrawMessageText _drawMessageText;
        private unsafe float* _messageBoxFloats1;
        private UMsgProcWindow_Simple_DrawNextPageIndicator _drawNextPage;

        private UICommon _uiCommon;

        private string UMsgProcWindow_Simple_DrawMessageBox_SIG = "40 55 57 48 8D AC 24 ?? ?? ?? ?? 48 81 EC 08 03 00 00 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 85 ?? ?? ?? ?? 48 8B 01";
        private string MessageBoxFloats1_SIG = "F2 0F 10 0D ?? ?? ?? ?? 41 0F 28 C1";
        private string UMsgProcWindow_Simple_DrawMessageText_SIG = "4C 8B DC 49 89 5B ?? 57 48 81 EC D0 00 00 00 48 8B 81 ?? ?? ?? ??";
        private string UMsgProcWindow_Simple_DrawCurrentSpeakerName_SIG = "E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ?? 48 8D 8D ?? ?? ?? ?? F3 44 0F 58 0D ?? ?? ?? ??";
        private string UMsgProcWindow_Simple_DrawNextPageIndicator_SIG = "48 89 E0 48 89 70 ?? 57 48 81 EC B0 00 00 00";
        public unsafe MsgWindowSimple(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(UMsgProcWindow_Simple_DrawMessageBox_SIG, "UMsgProcWindow_Simple::DrawMessageBox", _context._utils.GetDirectAddress, addr => _drawMsgBoxSimple = _context._utils.MakeHooker<UMsgProcWindow_Simple_DrawMessageBox>(UMsgProcWindow_Simple_DrawMessageBoxImpl, addr));
            _context._utils.SigScan(MessageBoxFloats1_SIG, "MessageBoxFloats1", _context._utils.GetIndirectAddressLong4, addr => _messageBoxFloats1 = (float*)addr);
            _context._utils.SigScan(UMsgProcWindow_Simple_DrawMessageText_SIG, "UMsgProcWindow_Simple::DrawMessageText", _context._utils.GetDirectAddress, addr => _drawMessageText = _context._utils.MakeWrapper<UMsgProcWindow_Simple_DrawMessageText>(addr));
            //_context._utils.SigScan(UMsgProcWindow_Simple_DrawCurrentSpeakerName_SIG, "UMsgProcWindow_Simple::DrawCurrentSpeakerName", _context._utils.GetIndirectAddressShort, addr => _messageBoxFloats1 = (float*)addr);
            _context._utils.SigScan(UMsgProcWindow_Simple_DrawNextPageIndicator_SIG, "UMsgProcWindow_Simple::DrawNextPageIndicator", _context._utils.GetDirectAddress, addr => _drawNextPage = _context._utils.MakeWrapper<UMsgProcWindow_Simple_DrawNextPageIndicator>(addr));
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        private static float[,] MessageBoxWidths = // 1442a7044
        {
            { 435.0f, 0.75099999f, 0.75099999f, 0.749f, 765.0f, 461.0f },
            { 503.0f, 0.87099999f, 0.87099999f, 0.749f, 890.0f, 639.0f },
            { 571.0f, 1.0f, 1.0f, 1.0f, 1025.0f, 0.0f },
        };

        private static float[,] MessageBoxHeights = // 1442a7090
        {
            { -5.0f, 0.842f, 17.0f, 6.0f, 0.842f, 22.0f, 7.0f, 0.838f, 8.0f, 0.0f, 58.0f,  },
            { -5.0f, 0.971f, 17.0f, 5.0f, 0.971f, 22.0f, 6.0f, 0.966f, 14.0f, -11.0f, 68.0f,  },
            { 0.0f, 1.0f, 17.0f, 0.0f, 1.0f, 22.0f, 0.0f, 1.0f, 14.0f, -23.0f, 78.0f,  },
        };

        private enum ProcWindowStatus : byte
        {
            AltSpeakerName = 1 << 2,
            ShowMessageBox = 1 << 3,
            GrayMessageText = 1 << 5,
        }

        private unsafe void UMsgProcWindow_Simple_DrawMessageBoxImpl(UMsgProcWindow_Simple* self) // FUN_14141c8e0
        {
            var vtable278 = _context._hooks.CreateWrapper<UMsgProcWindow_Simple_Vtable278>(*(nint*)(*(nint*)self + 0x278), out _);
            if 
            (
                (vtable278(self) && (self->MsgProcWindowStatus & 8) != 0) &&
                (((UMsgProcWindowBase*)self)->MessageBoxStatus < 3 || self->Field144 < 0.13333 || (self->MsgProcWindowStatus & 4) != 0)
            )
            {
                *_uiCommon._ActiveDrawTypeId = 0x23;
                var itemMask = _uiCommon._getSpriteItemMaskInstance() + 0x20;
                var msgBaseX = self->OffsetX + 482;
                var msgBaseY = 883;
                var drawStyleId = 0x23; // did they just copy paste this UI drawing code from GFD? lmao???
                var opacityByteAlpha = (byte)(self->Opacity * 255);
                _uiCommon._setPresetBlendState(itemMask, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_OPAQUE);

                var msgBoxBackColor = _uiCommon.ToFSprColor(_context._config.TextBoxBackFillColor);
                msgBoxBackColor.A = (byte)((1.0f - self->BgPieceTransparency) * self->Opacity * 102.0f);
                ;
                var msgBoxBackPos = new FVector(
                    Lerp(MessageBoxWidths[self->MessageBoxSubWidth, 0], MessageBoxWidths[self->MessageBoxWidth, 0], self->PositionLerp) + msgBaseX,
                    Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 0], MessageBoxHeights[self->MessageBoxHeight, 0], self->PositionLerp) + msgBaseY,
                    0
                );
                var msgBoxBackStretch = new FVector(
                    Lerp(MessageBoxWidths[self->MessageBoxSubWidth, 1], MessageBoxWidths[self->MessageBoxWidth, 1], self->PositionLerp) * self->SizeX,
                    Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 1], MessageBoxHeights[self->MessageBoxHeight, 1], self->PositionLerp),
                    1
                );
                var msgBoxBackRotation = new FVector(0, (float)(self->BgPieceRotation - 4.2), 0);
                var msgBoxBack = new PlgDefStruct1(msgBoxBackPos, msgBoxBackStretch, msgBoxBackRotation, msgBoxBackColor, 0xb);
                _uiCommon._plgFunc1(&msgBoxBack, itemMask, self->MsgPlg_, 0.0f, 0.0f);
                _uiCommon._setPresetBlendState(itemMask, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_ADDTRANS);
                msgBoxBackColor = _uiCommon.ToFSprColor(_context._config.TextBoxBackFillColor);
                msgBoxBackColor.A = (byte)((1.0f - self->BgPieceTransparency) * self->Opacity * 255);
                _uiCommon._plgFunc1(&msgBoxBack, itemMask, self->MsgPlg_, 0.0f, 0.0f);
                _uiCommon._setBlendState(itemMask, 
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One, 
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_Zero, 0xf, drawStyleId);

                _uiCommon._spriteMaskFunc2(itemMask, 0, 570, 1920, 1080, _uiCommon.ToFSprColor(_context.ColorBlack), drawStyleId);
                var msgBoxFillFrontPos = new FVector(
                    Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 2], MessageBoxHeights[self->MessageBoxHeight, 2], self->PositionLerp) + msgBaseX,
                    Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 3], MessageBoxHeights[self->MessageBoxHeight, 3], self->PositionLerp) + msgBaseY,
                    0
                );
                var msgBoxFillFrontStretch = new FVector(
                    Lerp(MessageBoxWidths[self->MessageBoxSubWidth, 2], MessageBoxWidths[self->MessageBoxWidth, 2], self->PositionLerp) * self->SizeX,
                    Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 4], MessageBoxHeights[self->MessageBoxHeight, 4], self->PositionLerp),
                    1
                );
                var msgBoxFillFrontColor = _uiCommon.ToFSprColor(_context._config.TextBoxFrontFillColor);
                msgBoxFillFrontColor.A = (byte)(self->Opacity * 229);
                var msgBoxFillFrontRot = new FVector(_messageBoxFloats1[0], _messageBoxFloats1[1], _messageBoxFloats1[2]);
                var msgBoxFillFront = new PlgDefStruct1(msgBoxFillFrontPos, msgBoxFillFrontStretch, msgBoxFillFrontRot, msgBoxFillFrontColor, 0x9);
                _uiCommon._setBlendState(itemMask, 
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_SourceAlpha, EUIBlendFactor.UI_BF_InverseSourceAlpha, 
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_One, EUIBlendFactor.UI_BF_Zero, 0xf, drawStyleId);
                _uiCommon._plgFunc1(&msgBoxFillFront, itemMask, self->MsgPlg_, 0, 0);
                
                var msgBoxLeftHazePos = new FVector2D(msgBaseX + 308, msgBaseY - 19);
                var msgBoxLeftHazeColor = _uiCommon.ToFSprColor(_context._config.TextBoxLeftHaze);
                msgBoxLeftHazeColor.A = (byte)(self->Opacity * 255 * 0.4);
                var msgBoxLeftHazeSpr = new SprDefStruct1(0, msgBoxLeftHazePos, msgBoxLeftHazeColor, 1.5f, 0, 0);
                msgBoxLeftHazeSpr.Field10 = 70;
                _uiCommon._setBlendState(itemMask, 
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One, 
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_DestAlpha, EUIBlendFactor.UI_BF_Zero, 0xf, drawStyleId);
                _uiCommon._spriteFunc1(&msgBoxLeftHazeSpr, itemMask, self->MsgSpr_, 0, 0);
                _uiCommon._setBlendState(itemMask, 
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_DestAlpha, EUIBlendFactor.UI_BF_One,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_Zero, 0xf, drawStyleId);
                _uiCommon._spriteFunc1(&msgBoxLeftHazeSpr, itemMask, self->MsgSpr_, 0, 0);
                _uiCommon._setBlendState(itemMask,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_One, EUIBlendFactor.UI_BF_Zero, 0xf, drawStyleId);
                _uiCommon._plgFunc1(&msgBoxFillFront, itemMask, self->MsgPlg_, 0, 0);
                
                var speakerNameTrianglePos = new FVector(
                    msgBaseX + 16,
                    Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 9], MessageBoxHeights[self->MessageBoxHeight, 9], self->PositionLerp) + 812 + 34,
                    0
                );
                var speakerNameTriangleStretch = new FVector(1, 1, 1);
                var speakerNameTriangleColor = _uiCommon.ToFSprColor(_context._config.TextBoxSpeakerNameTriangle);
                speakerNameTriangleColor.A = (byte)(self->Opacity * 255);
                var speakerNameTriangle = new PlgDefStruct1(speakerNameTrianglePos, speakerNameTriangleStretch, msgBoxFillFrontRot, speakerNameTriangleColor, 0x7);

                if (self->ShowSpeakerName())
                {
                    _uiCommon._setBlendState(itemMask,
                        EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One,
                        EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_One, EUIBlendFactor.UI_BF_One, 0xf, drawStyleId);
                    _uiCommon._plgFunc1(&speakerNameTriangle, itemMask, self->MsgPlg_, 0, 0);
                }
                _uiCommon._setBlendState(itemMask,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One,
                    EUIBlendOperation.UI_BO_ReverseSubtract, EUIBlendFactor.UI_BF_One, EUIBlendFactor.UI_BF_One, 0xf, drawStyleId);

                var msgBoxBorderFrontPos = new FVector(
                    Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 5], MessageBoxHeights[self->MessageBoxHeight, 5], self->PositionLerp) + msgBaseX,
                    Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 6], MessageBoxHeights[self->MessageBoxHeight, 6], self->PositionLerp) + msgBaseY,
                    0
                );
                var msgBoxBorderFrontStretch = new FVector(
                    Lerp(MessageBoxWidths[self->MessageBoxSubWidth, 3], MessageBoxWidths[self->MessageBoxWidth, 3], self->PositionLerp) * self->SizeX,
                    Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 7], MessageBoxHeights[self->MessageBoxHeight, 7], self->PositionLerp),
                    1
                );
                var msgBoxBorderFrontColor = _uiCommon.ToFSprColor(_context._config.TextBoxFrontFillColor);
                msgBoxBorderFrontColor.A = (byte)(self->Opacity * 229);
                var msgBoxBorderFront = new PlgDefStruct1(msgBoxBorderFrontPos, msgBoxBorderFrontStretch, msgBoxFillFrontRot, msgBoxBorderFrontColor, 0xa);
                _uiCommon._plgFunc1(&msgBoxBorderFront, itemMask, self->MsgPlg_, 0, 0);
                _uiCommon._setBlendState(itemMask,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_DestAlpha, EUIBlendFactor.UI_BF_InverseDestAlpha,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One, 0xf, drawStyleId);

                msgBoxFillFrontColor.A = (byte)(self->Opacity * 229);
                _uiCommon._plgFunc1(&msgBoxFillFront, itemMask, self->MsgPlg_, 0, 0);

                if (self->HasSpeakerName())
                {
                    if (self->IsMsgBoxSpeakerStatusValid()) _uiCommon._plgFunc1(&speakerNameTriangle, itemMask, self->MsgPlg_, 0, 0);
                    _uiCommon._setPresetBlendState(itemMask, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_OPAQUE);
                    var speakerNameTriangleFrontColor =
                            ((self->MsgProcWindowStatus & 0x20) != 0) ?
                            _uiCommon.ToFSprColor(_context._config.TextBoxFrontFillColor) :
                            _uiCommon.ToFSprColor(_context._config.TextBoxFrontFillColor)
                        ;
                    speakerNameTriangleFrontColor.A = (byte)(self->Opacity * 255);
                    var speakerNameTriangleFrontPos =
                        ((self->MsgProcWindowStatus & 0x4) != 0) ?
                        new FVector(
                            msgBaseX + 67 + 2,
                            Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 9], MessageBoxHeights[self->MessageBoxHeight, 9], self->PositionLerp) + 812 + 12,
                            0) :
                        new FVector(
                            msgBaseX + 67 + 67,
                            Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 9], MessageBoxHeights[self->MessageBoxHeight, 9], self->PositionLerp) + 812 + 26,
                            0)
                    ;
                    var speakerNameTriangleFrontVertexIndex = ((self->MsgProcWindowStatus & 0x4) != 0) ? 5 : 6;
                    var speakerNameTriangleFrontStretch = new FVector(1, 1, 1);
                    var speakerNameTriangleFront = new PlgDefStruct1(
                        speakerNameTriangleFrontPos, speakerNameTriangleFrontStretch, msgBoxFillFrontRot,
                        speakerNameTriangleFrontColor, speakerNameTriangleFrontVertexIndex
                    );
                    _uiCommon._plgFunc1(&speakerNameTriangleFront, itemMask, self->MsgPlg_, 0, 0);

                    var current_speaker = (nint)((UMsgProcWindowBase*)self)->pMsgWork->CurrentSpeaker;
                    var current_speaker_inner = *(nint*)(current_speaker + 0x28);
                    var current_speaker_inner2 = *(nint*)(current_speaker_inner + 0x48);
                    var current_speaker_color = _uiCommon.ToFSprColor(_context._config.TextBoxSpeakerName);
                    current_speaker_color.A = (byte)(self->Opacity * 255);
                    _uiCommon._drawSingleLineText(
                        msgBaseX + 67, 
                        Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 9], MessageBoxHeights[self->MessageBoxHeight, 9], self->PositionLerp) + 810, 
                        0,
                        current_speaker_color,
                        1,
                        current_speaker_inner2,
                        0x23, 0x3, 0, 0
                    );
                    var speakerNameTalkSpriteColor =
                        ((self->MsgProcWindowStatus & 0x20) != 0) ?
                        _uiCommon.ToFSprColor(_context._config.TextBoxSpeakerName) :
                        _uiCommon.ToFSprColor(_context._config.TextBoxSpeakerName)
                    ;
                    speakerNameTalkSpriteColor.A = (byte)(self->Opacity * 179);
                    var speakerNameTalkSpritePos = new FVector2D(msgBaseX + 67 + 57, Lerp(MessageBoxHeights[self->MessageBoxSubHeight, 9], MessageBoxHeights[self->MessageBoxHeight, 9], self->PositionLerp) + 812 + 27);
                    var speakerNameTalkSprite = new SprDefStruct1(
                        1,
                        speakerNameTalkSpritePos,
                        speakerNameTalkSpriteColor, 
                        1, 0, 0);
                    _uiCommon._spriteFunc1(&speakerNameTalkSprite, itemMask, self->MsgSpr_, 0, 0);
                }
                _drawMessageText(self, itemMask, (byte)(self->Field164 * 255), msgBaseX, msgBaseY);

                // next page indicator
                self->NextPageParams.NextPageColor = _uiCommon.ToFSprColor(_context._config.TextBoxFrontFillColor);
                _drawNextPage(&self->NextPageParams, self->MsgPlg_, msgBaseX + MessageBoxWidths[self->MessageBoxSubWidth, 4] - 2, msgBaseY + MessageBoxHeights[self->MessageBoxSubHeight, 10]);
            }
        }

        private unsafe delegate void UMsgProcWindow_Simple_DrawMessageBox(UMsgProcWindow_Simple* self);
        private unsafe delegate bool UMsgProcWindow_Simple_Vtable278(UMsgProcWindow_Simple* self);
        private unsafe delegate void UMsgProcWindow_Simple_DrawCurrentSpeakerName();
        private unsafe delegate void UMsgProcWindow_Simple_DrawNextPageIndicator(UMsgProcWindow_Simple_NextPageParams* nextPageParams, UPlgAsset* plg, float posX, float posY);
    }

    public class MsgWindowSelectSimple : ModuleBase
    {
        private string UMsgProcWindow_Select_Simple_DrawListBox_SIG = "40 55 41 56 48 8D AC 24 ?? ?? ?? ?? 48 81 EC 68 04 00 00";
        private IHook<UMsgProcWindow_Select_Simple_DrawListBox> _drawListBox;
        private UICommon _uiCommon;

        private static float[,] ListBoxFloats = // 1442a7180
        {
            { -89f, 0.7560000f, 23f, 41f, 0.7560000f, 19f, 38f, 0.7560000f, -70f},
            { -89f, 0.7800000f, 23f, 41f, 0.7560000f, 19f, 38f, 0.7560000f, -121f},
            { -116f, 0.8800000f, 23f, 35f, 0.8630000f, 19f, 32f, 0.8660000f, -170f},
            { -149f, 1.040000f, 23f, 35f, 1.023000f, 19f, 32f, 1.027000f, -223f},
            { -180f, 1.175000f, 23f, 35f, 1.206000f, 19f, 31f, 1.217000f, -275f},
            { -201f, 1.404000f, 23f, 35f, 1.398000f, 19f, 32f, 1.418000f, -334f},
            { -236f, 1.596000f, 23f, 35f, 1.567000f, 18f, 32f, 1.583000f, -399f}
        };

        // At least until I feel like rewriting the entire function like I did with the text box lol
        private string UMsgProcWindow_Select_Simple_SelBgShadow1_SIG = "4D 8B 86 ?? ?? ?? ?? 48 8D 4D ?? 41 0F 28 DB F3 44 0F 11 5C 24 ?? 49 8B D7 89 45 ?? E8 ?? ?? ?? ?? BA 02 00 00 00";
        private string UMsgProcWindow_Select_Simple_SelBgShadow2_SIG = "4D 8B 86 ?? ?? ?? ?? 48 8D 4D ?? 41 0F 28 DB F3 44 0F 11 5C 24 ?? 49 8B D7 89 45 ?? E8 ?? ?? ?? ?? 33 D2";
        private IAsmHook _selBgShadow1;
        private IAsmHook _selBgShadow2;
        private IReverseWrapper<UMsgProcWindow_Select_Simple_SetColorPassthrough> _selBgShadow1Wrapper;
        private IReverseWrapper<UMsgProcWindow_Select_Simple_SetColorPassthrough> _selBgShadow2Wrapper;

        public unsafe MsgWindowSelectSimple(Context context, Dictionary<string, ModuleBase> modules) : base(context, modules)
        {
            _context._utils.SigScan(UMsgProcWindow_Select_Simple_DrawListBox_SIG, "UMsgProcWindow_Select_Simple::DrawListBox", _context._utils.GetDirectAddress, addr => _drawListBox = _context._utils.MakeHooker<UMsgProcWindow_Select_Simple_DrawListBox>(UMsgProcWindow_Select_Simple_DrawListBoxImpl, addr));
            _context._utils.SigScan(UMsgProcWindow_Select_Simple_SelBgShadow1_SIG, "UMsgProcWindow_Select_Simple::SelBgShadow1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UMsgProcWindow_Select_Simple_SetColorPassthroughImpl, out _selBgShadow1Wrapper)}",
                };
                _selBgShadow1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UMsgProcWindow_Select_Simple_SelBgShadow2_SIG, "UMsgProcWindow_Select_Simple::SelBgShadow2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UMsgProcWindow_Select_Simple_SetColorPassthroughImpl, out _selBgShadow2Wrapper)}",
                };
                _selBgShadow2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }
        private unsafe void UMsgProcWindow_Select_Simple_DrawListBoxImpl(UMsgProcWindow_Select_Simple* self)
        {
            /*
            var vtable278 = _context._hooks.CreateWrapper<UMsgProcWindow_Select_Simple_Vtable278>(*(nint*)(*(nint*)self + 0x278), out _);
            if (vtable278(self))
            {
                *_uiCommon._ActiveDrawTypeId = 0x24;
            }
            */
            _drawListBox.OriginalFunction(self);
        }

        private unsafe FSprColor UMsgProcWindow_Select_Simple_SetColorPassthroughImpl(FSprColor source)
        {
            var oldAlpha = source.A;
            var newColor = _uiCommon.ToFSprColor(_context._config.TextBoxBackFillColor);
            newColor.A = oldAlpha;
            return newColor;
        }

        private unsafe delegate bool UMsgProcWindow_Select_Simple_Vtable278(UMsgProcWindow_Select_Simple* self);
        private unsafe delegate void UMsgProcWindow_Select_Simple_DrawListBox(UMsgProcWindow_Select_Simple* self);

        [Function(FunctionAttribute.Register.rax, FunctionAttribute.Register.rax, false)]
        private unsafe delegate FSprColor UMsgProcWindow_Select_Simple_SetColorPassthrough(FSprColor source);
    }
}
