using p3rpc.commonmodutils;
using p3rpc.femc.Configuration;
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
using static p3rpc.femc.Components.UICommon;

namespace p3rpc.femc.Components
{
    public class MsgWindowSimpleCommon : ModuleBase<FemcContext>
    {
        private string MessageBoxFloats1_SIG = "F2 0F 10 0D ?? ?? ?? ?? 41 0F 28 C1";
        public unsafe MsgWindowSimpleCommon(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(MessageBoxFloats1_SIG, "MessageBoxFloats1", _context._utils.GetIndirectAddressLong4, addr => _messageBoxFloats1 = (float*)addr);
        }
        public unsafe float* _messageBoxFloats1; // 0x145668c68
        public override void Register()
        {

        }
    }
    public class MsgWindowSimple : ModuleBase<FemcContext>
    {
        private IHook<UMsgProcWindow_Simple_DrawMessageBox> _drawMsgBoxSimple;
        private IUIMethods.UMsgProcWindow_Simple_DrawMessageText _drawMessageText;
        private UMsgProcWindow_Simple_DrawNextPageIndicator _drawNextPage;

        private UICommon _uiCommon;
        private MsgWindowSimpleCommon _msgWindowCommon;

        private string UMsgProcWindow_Simple_DrawMessageBox_SIG = "40 55 57 48 8D AC 24 ?? ?? ?? ?? 48 81 EC 08 03 00 00 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 85 ?? ?? ?? ?? 48 8B 01";
        private string UMsgProcWindow_Simple_DrawMessageText_SIG = "4C 8B DC 49 89 5B ?? 57 48 81 EC D0 00 00 00 48 8B 81 ?? ?? ?? ??";
        private string UMsgProcWindow_Simple_DrawCurrentSpeakerName_SIG = "E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ?? 48 8D 8D ?? ?? ?? ?? F3 44 0F 58 0D ?? ?? ?? ??";

        private MultiSignature _DrawNextPageIndicatorMS;
        private string UMsgProcWindow_Simple_DrawNextPageIndicator_SIG = "48 89 E0 48 89 70 ?? 57 48 81 EC B0 00 00 00";
        private string UMsgProcWindow_Simple_DrawNextPageIndicator_EpAigis_SIG = "48 89 E0 48 89 58 ?? 56 48 81 EC B0 00 00 00 0F 29 70 ?? 48 89 D6";
        public unsafe MsgWindowSimple(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(UMsgProcWindow_Simple_DrawMessageBox_SIG, "UMsgProcWindow_Simple::DrawMessageBox", _context._utils.GetDirectAddress, addr => _drawMsgBoxSimple = _context._utils.MakeHooker<UMsgProcWindow_Simple_DrawMessageBox>(UMsgProcWindow_Simple_DrawMessageBoxImpl, addr));
            _context._utils.SigScan(UMsgProcWindow_Simple_DrawMessageText_SIG, "UMsgProcWindow_Simple::DrawMessageText", _context._utils.GetDirectAddress, addr => _drawMessageText = _context._utils.MakeWrapper<IUIMethods.UMsgProcWindow_Simple_DrawMessageText>(addr));
            //_context._sharedScans.CreateListener<IUIMethods.UMsgProcWindow_Simple_DrawMessageText>(addr => _context._utils.AfterSigScan(addr, _context._utils.GetDirectAddress, addr => _context._utils.MakeWrapper<IUIMethods.UMsgProcWindow_Simple_DrawMessageText>(addr)));
            //_context._utils.SigScan(UMsgProcWindow_Simple_DrawCurrentSpeakerName_SIG, "UMsgProcWindow_Simple::DrawCurrentSpeakerName", _context._utils.GetIndirectAddressShort, addr => _messageBoxFloats1 = (float*)addr);
            _DrawNextPageIndicatorMS = new MultiSignature();
            _context._utils.MultiSigScan(
                new string[] { UMsgProcWindow_Simple_DrawNextPageIndicator_SIG, UMsgProcWindow_Simple_DrawNextPageIndicator_EpAigis_SIG },
                "UMsgProcWindow_Simple::DrawNextPageIndicator", _context._utils.GetDirectAddress,
                addr => _drawNextPage = _context._utils.MakeWrapper<UMsgProcWindow_Simple_DrawNextPageIndicator>(addr),
                _DrawNextPageIndicatorMS
            );
        }

        // 48 89 E0 48 89 58 ?? 56 48 81 EC B0 00 00 00 0F 29 70 ?? 48 89 D6

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
            _msgWindowCommon = GetModule<MsgWindowSimpleCommon>();
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

                var msgBoxBackColor = ConfigColor.ToFSprColor(_context._config.TextBoxBackFillColor);
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
                msgBoxBackColor = ConfigColor.ToFSprColor(_context._config.TextBoxBackFillColor);
                msgBoxBackColor.A = (byte)((1.0f - self->BgPieceTransparency) * self->Opacity * 255);
                _uiCommon._plgFunc1(&msgBoxBack, itemMask, self->MsgPlg_, 0.0f, 0.0f);
                _uiCommon._setBlendState(itemMask, 
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One, 
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_Zero, 0xf, drawStyleId);

                _uiCommon._spriteMaskFunc2(itemMask, 0, 570, 1920, 1080, ConfigColor.ToFSprColor(_context.ColorBlack), drawStyleId);
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
                var msgBoxFillFrontColor = ConfigColor.ToFSprColor(_context._config.TextBoxFrontFillColor);
                msgBoxFillFrontColor.A = (byte)(self->Opacity * 229);
                var msgBoxFillFrontRot = new FVector(_msgWindowCommon._messageBoxFloats1[0], _msgWindowCommon._messageBoxFloats1[1], _msgWindowCommon._messageBoxFloats1[2]);
                var msgBoxFillFront = new PlgDefStruct1(msgBoxFillFrontPos, msgBoxFillFrontStretch, msgBoxFillFrontRot, msgBoxFillFrontColor, 0x9);
                _uiCommon._setBlendState(itemMask, 
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_SourceAlpha, EUIBlendFactor.UI_BF_InverseSourceAlpha, 
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_One, EUIBlendFactor.UI_BF_Zero, 0xf, drawStyleId);
                _uiCommon._plgFunc1(&msgBoxFillFront, itemMask, self->MsgPlg_, 0, 0);
                
                var msgBoxLeftHazePos = new FVector2D(msgBaseX + 308, msgBaseY - 19);
                var msgBoxLeftHazeColor = ConfigColor.ToFSprColor(_context._config.TextBoxLeftHaze);
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
                var speakerNameTriangleColor = ConfigColor.ToFSprColor(_context._config.TextBoxSpeakerNameTriangle);
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
                var msgBoxBorderFrontColor = ConfigColor.ToFSprColor(_context._config.TextBoxFrontFillColor);
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
                            /*
                            ConfigColor.ToFSprColor(_context._config.TextBoxFrontFillColor) :
                            ConfigColor.ToFSprColor(_context._config.TextBoxFrontFillColor)
                            ;
                             */
                            ConfigColor.ToFSprColor(_context._config.TextBoxSpeakerNameTriangleFront) :
                            ConfigColor.ToFSprColor(_context._config.TextBoxSpeakerNameTriangleFront)
                        ;//wtf
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
                    var current_speaker_color = ConfigColor.ToFSprColor(_context._config.TextBoxSpeakerName);
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
                        ConfigColor.ToFSprColor(_context._config.TextBoxSpeakerName) :
                        ConfigColor.ToFSprColor(_context._config.TextBoxSpeakerName)
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
                self->NextPageParams.NextPageColor = ConfigColor.ToFSprColor(_context._config.TextBoxFrontFillColor);
                _drawNextPage(&self->NextPageParams, self->MsgPlg_, msgBaseX + MessageBoxWidths[self->MessageBoxSubWidth, 4] - 2, msgBaseY + MessageBoxHeights[self->MessageBoxSubHeight, 10]);
            }
        }

        private unsafe delegate void UMsgProcWindow_Simple_DrawMessageBox(UMsgProcWindow_Simple* self);
        private unsafe delegate bool UMsgProcWindow_Simple_Vtable278(UMsgProcWindow_Simple* self);
        private unsafe delegate void UMsgProcWindow_Simple_DrawCurrentSpeakerName();
        private unsafe delegate void UMsgProcWindow_Simple_DrawNextPageIndicator(UMsgProcWindow_Simple_NextPageParams* nextPageParams, UPlgAsset* plg, float posX, float posY);
    }

    public class MsgWindowSelectSimple : ModuleBase<FemcContext>
    {
        private string UMsgProcWindow_Select_Simple_DrawListBox_SIG = "40 55 41 56 48 8D AC 24 ?? ?? ?? ?? 48 81 EC 68 04 00 00";
        private string USelItem_CopySelEntries_SIG = "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 8B 41 ?? 48 89 D3";
        private string SelBoxStruct2_14105cd80_SIG = "4C 8B DC 56 41 56 48 81 EC 88 00 00 00 33 C0";
        private string LocationSelectParam1_DrawSelectMapBg_SIG = "E8 ?? ?? ?? ?? 33 C0 C7 44 24 ?? 24 00 00 00 C7 44 24 ?? 0F 00 00 00 45 33 C0";
        private string UMsgProcWindow_Select_Simple_DrawSelectText_SIG = "48 8B C4 48 89 58 ?? 48 89 70 ?? 55 57 41 54 41 56 41 57 48 8D A8 ?? ?? ?? ?? 48 81 EC 30 02 00 00";
        private string DrawRoundRectangle_1414e8450_SIG = "48 8B C4 F3 0F 11 48 ?? F3 0F 11 40 ??";

        private IHook<UMsgProcWindow_Select_Simple_DrawListBox> _drawListBox;
        private UselItem_CopySelEntries _copySelEntries;
        private SelBoxStruct2_14105cd80 _selBoxFunc1;
        private LocationSelectParam1_DrawSelectMapBg _drawSelectMapBg;
        private UMsgProcWindow_Select_Simple_DrawSelectText _drawSelectText;
        private DrawRoundRectangle_1414e8450 _drawRoundRect;

        private UICommon _uiCommon;
        private Bustup _bustup;
        private MsgWindowSimpleCommon _msgWindowCommon;

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

        public unsafe MsgWindowSelectSimple(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(UMsgProcWindow_Select_Simple_DrawListBox_SIG, "UMsgProcWindow_Select_Simple::DrawListBox", _context._utils.GetDirectAddress, addr => _drawListBox = _context._utils.MakeHooker<UMsgProcWindow_Select_Simple_DrawListBox>(UMsgProcWindow_Select_Simple_DrawListBoxImpl, addr));
            _context._utils.SigScan(USelItem_CopySelEntries_SIG, "USelItem::CopySelEntries", _context._utils.GetDirectAddress, addr => _copySelEntries = _context._utils.MakeWrapper<UselItem_CopySelEntries>(addr));
            _context._utils.SigScan(SelBoxStruct2_14105cd80_SIG, "SelBoxStruct2::FUN_14105cd80", _context._utils.GetDirectAddress, addr => _selBoxFunc1 = _context._utils.MakeWrapper<SelBoxStruct2_14105cd80>(addr));
            _context._utils.SigScan(LocationSelectParam1_DrawSelectMapBg_SIG, "LocationSelectParams1::DrawSelectMapBg", _context._utils.GetIndirectAddressShort, addr => _drawSelectMapBg = _context._utils.MakeWrapper<LocationSelectParam1_DrawSelectMapBg>(addr));
            _context._utils.SigScan(UMsgProcWindow_Select_Simple_DrawSelectText_SIG, "UMsgProcWindow_Select_Simple_::DrawSelectText", _context._utils.GetDirectAddress, addr => _drawSelectText = _context._utils.MakeWrapper<UMsgProcWindow_Select_Simple_DrawSelectText>(addr));
            _context._utils.SigScan(DrawRoundRectangle_1414e8450_SIG, "DrawRoundRectangle_1414e8450", _context._utils.GetDirectAddress, addr => _drawRoundRect = _context._utils.MakeWrapper<DrawRoundRectangle_1414e8450>(addr));
        }

        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
            _bustup = GetModule<Bustup>();
            _msgWindowCommon = GetModule<MsgWindowSimpleCommon>();
        }
        private unsafe TArray<FVector2D> MakeArrayFromExistingAlloc(FVector2D* alloc, int count)
        {
            var arrOut = new TArray<FVector2D>();
            arrOut.allocator_instance = alloc;
            arrOut.arr_num = count;
            arrOut.arr_max = count;
            return arrOut;
        }
        private unsafe void UMsgProcWindow_Select_Simple_DrawListBoxImpl(UMsgProcWindow_Select_Simple* self)
        {
            /*
            if (_context._config.DebugDrawOgSelBox)
            {
                _drawListBox.OriginalFunction(self);
                return;
            }
            */
            var vtable278 = _context._hooks.CreateWrapper<UMsgProcWindow_Select_Simple_Vtable278>(*(nint*)(*(nint*)self + 0x278), out _);
            if (vtable278(self))
            {
                var selEntries = (SelBoxStruct1*)NativeMemory.Alloc((nuint)sizeof(SelBoxStruct1));
                *_uiCommon._ActiveDrawTypeId = 0x24;
                _copySelEntries(((UMsgProcWindow_Select*)self)->pSelWork, selEntries);
                var visibleEntries = (selEntries->selCount - 1 > 6) ? 6 : selEntries->selCount - 1;
                var masker = _uiCommon.GetDrawer();

                var entryAllocTL = (FVector2D*)NativeMemory.Alloc((nuint)(sizeof(FVector2D) * selEntries->selCount));
                var entryAllocBR = (FVector2D*)NativeMemory.Alloc((nuint)(sizeof(FVector2D) * selEntries->selCount));
                var entryTL = MakeArrayFromExistingAlloc(entryAllocTL, selEntries->selCount);
                var entryBR = MakeArrayFromExistingAlloc(entryAllocBR, selEntries->selCount);
                var maxLenX = 0f;
                for (int i = 0; i < selEntries->selCount; i++)
                {
                    _selBoxFunc1((SelBoxStruct2*)selEntries->selEntries.allocator_instance[i], &entryAllocTL[i].X, &entryAllocTL[i].Y, 0, null);
                    _selBoxFunc1((SelBoxStruct2*)selEntries->selEntries.allocator_instance[i], &entryAllocBR[i].X, &entryAllocBR[i].Y, 1, null);
                    if (entryAllocBR[i].X > maxLenX) maxLenX = entryAllocBR[i].X;
                    //_context._logger.WriteLine($"{i} : top left ({entryAllocTL[i].X}, {entryAllocTL[i].Y}), bottom right ({entryAllocBR[i].X}, {entryAllocBR[i].Y})");
                }
                var posYTrack = UICommon.ProgressTrackFraction(maxLenX, 314, 532, 0);
                // draw bustup
                _uiCommon._setRenderTarget(masker, 0, *_uiCommon._ActiveDrawTypeId);
                _bustup.UBustupObject_DrawBustupShadowImpl(self->BustupObject_, self->bustupShadowX + 1106, -151, 1, *_uiCommon._ActiveDrawTypeId, 1);
                _bustup._drawBustupMain(self->BustupObject_, self->bustupMainX + 1122, -136, 1, *_uiCommon._ActiveDrawTypeId, 1);
                // draw speech box shadow
                _uiCommon._setPresetBlendState((nint)masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_OPAQUE);
                var speechShadowX = self->speechShadowOffsetX + 1554;
                var speechShadow = new PlgDefStruct1(
                    new FVector(
                        UICommon.Lerp(-290, -363, posYTrack) * self->speechShadowMod.X + speechShadowX,
                        ListBoxFloats[visibleEntries, 0] * self->speechShadowMod.Y + 811, 0), 
                    new FVector(
                        UICommon.Lerp(0.777f, 1, posYTrack) * self->speechShadowMod.X,
                        ListBoxFloats[visibleEntries, 1] * self->speechShadowMod.Y, 1), 
                    new FVector(0, self->speechShadowRotation + 4.6f, 0),
                    ConfigColor.ToFSprColorWithAlpha(_context._config.MsgSimpleSelectShadowEx, (byte)(self->speechShadowOpacity * 102)),
                    0x17);
                _uiCommon._plgFunc1(&speechShadow, (nint)masker, self->MsgPlg_, 0, 0);
                _uiCommon._setPresetBlendState((nint)masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_ADDTRANS);
                speechShadow.Color = ConfigColor.ToFSprColorWithAlpha(_context._config.MsgSimpleSelectShadowEx, (byte)(self->speechShadowOpacity * 255));
                _uiCommon._plgFunc1(&speechShadow, (nint)masker, self->MsgPlg_, 0, 0);
                // yeah idk what LocationSelectParams1 really does
                var speechBgData = (LocationSelectParams1*)NativeMemory.AllocZeroed((nuint)sizeof(LocationSelectParams1));
                speechBgData->Field48 = 540;
                speechBgData->Field18 = 1127.7f;
                speechBgData->Field00 = speechShadowX - 819;
                speechBgData->Field30 = 1127.7f;
                speechBgData->Field44 = 960;
                speechBgData->Field04 = 256.6f;
                speechBgData->Field28 = 656.25f;
                speechBgData->Field34 = 656.25f;
                speechBgData->Field50 = 1;
                speechBgData->Field40 = 1.5f;
                speechBgData->Field64 = ulong.MaxValue;
                speechBgData->Field5C = ulong.MaxValue;
                speechBgData->Field70 = uint.MaxValue;
                /*
                speechBgData->Color = new FSprColor(0x12, 0x14, 0x23, (byte)(self->speechShadowOpacity * 255 * 0.9));
                 */
                speechBgData->Color = ConfigColor.ToFSprColorWithAlpha(_context._config.MsgSimpleBgColor, (byte)(self->speechShadowOpacity * 255 * 0.9));
                // draw main speech box
                var speechBgMain = new PlgDefStruct1(
                    new FVector(
                        ListBoxFloats[visibleEntries, 2] * self->speechShadowMod.X + speechShadowX,
                        ListBoxFloats[visibleEntries, 3] * self->speechShadowMod.Y + 811, 0),
                    new FVector(UICommon.Lerp(0.777f, 1, posYTrack), ListBoxFloats[visibleEntries, 4] * self->speechShadowMod.Y, 1),
                    new FVector(_msgWindowCommon._messageBoxFloats1[0], _msgWindowCommon._messageBoxFloats1[1], _msgWindowCommon._messageBoxFloats1[2]),
                    /*
                    new FSprColor(0x12, 0x14, 0x23, (byte)(self->speechShadowOpacity * 255 * 0.9)),
                     */
                    ConfigColor.ToFSprColorWithAlpha(_context._config.MsgSimpleBgColor, (byte)(self->speechShadowOpacity * 255 * 0.9)),
                    0x16);

                var speechBgTip = new PlgDefStruct1(
                    new FVector(self->speechShadowMod.X * 68 + speechShadowX, self->speechShadowMod.Y + 811, 0),
                    new FVector(self->speechShadowMod.X, self->speechShadowMod.Y, 1),
                    new FVector(_msgWindowCommon._messageBoxFloats1[0], _msgWindowCommon._messageBoxFloats1[1], _msgWindowCommon._messageBoxFloats1[2]),
                    /*
                    new FSprColor(0x12, 0x14, 0x23, (byte)(self->speechShadowOpacity * 255 * 0.9)),
                     */
                    ConfigColor.ToFSprColorWithAlpha(_context._config.MsgSimpleBgColor, (byte)(self->speechShadowOpacity * 255 * 0.9)),
                    0x14);
                _uiCommon._setBlendState((nint)masker, EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_Zero, 0xf, *(int*)_uiCommon._ActiveDrawTypeId);
                _drawSelectMapBg(speechBgData, (nint)masker, 0, 0);
                /*
                _uiCommon._setBlendState((nint)masker, EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_One, EUIBlendFactor.UI_BF_Zero, 0xf, *(int*)_uiCommon._ActiveDrawTypeId);
                _uiCommon._plgFunc1(&speechBgMain, (nint)masker, self->MsgPlg_, 0, 0);
                _uiCommon._setBlendState((nint)masker, EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One,
                    EUIBlendOperation.UI_BO_Max, EUIBlendFactor.UI_BF_One, EUIBlendFactor.UI_BF_One, 0xf, *(int*)_uiCommon._ActiveDrawTypeId);
                _uiCommon._plgFunc1(&speechBgTip, (nint)masker, self->MsgPlg_, 0, 0);
                _uiCommon._setBlendState((nint)masker, EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_DestAlpha, EUIBlendFactor.UI_BF_InverseDestAlpha,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One, 0xf, *(int*)_uiCommon._ActiveDrawTypeId);
                _drawSelectMapBg(speechBgData, (nint)masker, 0, 0);
                 */
                var bgFillColor = ConfigColor.ToFSprColorWithAlpha(_context._config.MsgSimpleSelectBgFill, (byte)(self->speechShadowOpacity * 255 * 0.4f));
                var bgFillTexSprite = new SprDefStruct1(
                    /*
                    new FSprColor(0xd4, 0x15, 0x5f, (byte)(self->speechShadowOpacity * 255 * 0.4)),
                     */
                    new FVector2D(speechShadowX - 243, 594), 0, 1.5f, 86.15f, 0,
                    bgFillColor,
                    1, new FVector4(960, 540, 0, 1), 0, 0, 0, 1, 1, 0, 0);
                _uiCommon._setBlendState((nint)masker, EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_DestAlpha, EUIBlendFactor.UI_BF_Zero, 0xf, *(int*)_uiCommon._ActiveDrawTypeId);
                _uiCommon._spriteFunc1(&bgFillTexSprite, (nint)masker, self->MsgSpr_, 0, 0);
                _uiCommon._setBlendState((nint)masker, EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_DestAlpha, EUIBlendFactor.UI_BF_One,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_Zero, 0xf, *(int*)_uiCommon._ActiveDrawTypeId);
                _uiCommon._spriteFunc1(&bgFillTexSprite, (nint)masker, self->MsgSpr_, 0, 0);
                _uiCommon._setBlendState((nint)masker, EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_One, EUIBlendFactor.UI_BF_Zero, 0xf, *(int*)_uiCommon._ActiveDrawTypeId);
                _uiCommon._plgFunc1(&speechBgMain, (nint)masker, self->MsgPlg_, 0, 0);
                _uiCommon._setBlendState((nint)masker, EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One,
                    EUIBlendOperation.UI_BO_Max, EUIBlendFactor.UI_BF_One, EUIBlendFactor.UI_BF_One, 0xf, *(int*)_uiCommon._ActiveDrawTypeId);
                _uiCommon._plgFunc1(&speechBgTip, (nint)masker, self->MsgPlg_, 0, 0);
                _uiCommon._setBlendState((nint)masker, EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One,
                    EUIBlendOperation.UI_BO_ReverseSubtract, EUIBlendFactor.UI_BF_One, EUIBlendFactor.UI_BF_One, 0xf, *(int*)_uiCommon._ActiveDrawTypeId);
                
                var bgFillPlg2 = new PlgDefStruct1(
                    new FVector(
                        ListBoxFloats[visibleEntries, 5] * self->speechShadowMod.X + speechShadowX,
                        ListBoxFloats[visibleEntries, 6] * self->speechShadowMod.Y + 811, 0),
                    new FVector(UICommon.Lerp(0.777f, 1, posYTrack), ListBoxFloats[visibleEntries, 7] * self->speechShadowMod.Y, 1),
                    new FVector(_msgWindowCommon._messageBoxFloats1[0], _msgWindowCommon._messageBoxFloats1[1], _msgWindowCommon._messageBoxFloats1[2]),
                    new FSprColor(0x12, 0x14, 0x23, (byte)(self->speechShadowOpacity * 255 * 0.9)),
                    0x15);
                _uiCommon._plgFunc1(&bgFillPlg2, (nint)masker, self->MsgPlg_, 0, 0);

                var bgFillPlg3 = new PlgDefStruct1(
                    new FVector(speechShadowX + 49, 817, 0), new FVector(1, 1, 1),
                    new FVector(_msgWindowCommon._messageBoxFloats1[0], _msgWindowCommon._messageBoxFloats1[1], _msgWindowCommon._messageBoxFloats1[2]),
                    new FSprColor(0x12, 0x14, 0x23, (byte)(self->speechShadowOpacity * 255 * 0.9)),
                    0x13);
                _uiCommon._plgFunc1(&bgFillPlg3, (nint)masker, self->MsgPlg_, 0, 0);
                _uiCommon._setBlendState((nint)masker, EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_DestAlpha, EUIBlendFactor.UI_BF_InverseDestAlpha,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One, 0xf, *(int*)_uiCommon._ActiveDrawTypeId);

                speechBgMain.SetColor(ConfigColor.ToFSprColorWithAlpha(_context._config.MsgSimpleSelectBorderColorEx, (byte)(self->speechShadowOpacity * 255 * 0.9)));
                speechBgTip.SetColor (ConfigColor.ToFSprColorWithAlpha(_context._config.MsgSimpleSelectBorderColorEx, (byte)(self->speechShadowOpacity * 255 * 0.9)));
                _uiCommon._plgFunc1(&speechBgMain, (nint)masker, self->MsgPlg_, 0, 0);
                _uiCommon._plgFunc1(&speechBgTip, (nint)masker, self->MsgPlg_, 0, 0);
                _uiCommon._setPresetBlendState((nint)masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_OPAQUE);
                
                // get params from DT_UILayout_MsgProcWindowSELECT.uasset
                var selTextCol = self->LayoutDataTable != null ? self->LayoutDataTable->GetLayoutDataTableEntry(0)->position : new FVector2D(0, 0);
                var nonSelTextCol = self->LayoutDataTable != null ? self->LayoutDataTable->GetLayoutDataTableEntry(1)->position : new FVector2D(0, 0);
                var selTexOffset = self->LayoutDataTable != null ? self->LayoutDataTable->GetLayoutDataTableEntry(2)->position : new FVector2D(0, 0);
                var nonSelTexOffset = self->LayoutDataTable != null ? self->LayoutDataTable->GetLayoutDataTableEntry(3)->position : new FVector2D(0, 0);
                var textEntries = selEntries->selCount < 8 ? selEntries->selCount : 7;

                if (selEntries->selCount - 1 > 6) // Draw scrollbar
                {
                    if (selEntries->field04 != 0)
                    {
                        var scrollSpr1 = new SprDefStruct1(2, 
                            new FVector2D(self->scrollbarOffset1.X - posYTrack - 11, self->scrollbarOffset1.Y + ListBoxFloats[visibleEntries, 8] + 751),
                            new FSprColor(0xff, 0xff, 0xff, (byte)(self->speechShadowOpacity * 255 * 0.9)), 1, 0, 0);
                        _uiCommon._spriteFunc1(&scrollSpr1, (nint)masker, self->MsgSpr_, 0, 0);
                    }
                    if (selEntries->field04 != selEntries->selCount - textEntries)
                    {
                        var scrollSpr2 = new SprDefStruct1(2,
                            new FVector2D(self->scrollbarOffset2.X - posYTrack - 40, self->scrollbarOffset1.Y + ListBoxFloats[visibleEntries, 8] + 1228),
                            new FSprColor(0xff, 0xff, 0xff, (byte)(self->speechShadowOpacity * 255 * 0.9)), 1, 0, 180);
                        _uiCommon._spriteFunc1(&scrollSpr2, (nint)masker, self->MsgSpr_, 0, 0);
                    }
                }

                // Draw selection entry text + selection rectangle
                var textPosXLerp = UICommon.Lerp(-252, -318, posYTrack);
                var textPos = new FVector2D(speechShadowX + textPosXLerp, ListBoxFloats[visibleEntries, 8] + 811);
                var selBoxLength = entryAllocBR[self->BRIndex1 + self->BRIndex2].X > 314 ? entryAllocBR[self->BRIndex1 + self->BRIndex2].X + 120 : 434;
                if (selBoxLength > 620) selBoxLength = 620;
                _uiCommon._setBlendState((nint)masker, EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_SourceAlpha, EUIBlendFactor.UI_BF_InverseSourceAlpha,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_Zero, 0xf, *(int*)_uiCommon._ActiveDrawTypeId);
                _drawSelectText(self, selEntries, textEntries, &entryTL, &entryBR, textPos.X, textPos.Y, 
                    new FSprColor(0xf0, 0xf3, 0xfc, (byte)(self->speechShadowOpacity * 255 * 0.9)), selTextCol, nonSelTextCol, selTexOffset, nonSelTexOffset);

                var selBoxShadow = ConfigColor.ToFSprColorWithAlpha(_context._config.MsgSimpleSelectTextColor, (byte)(self->speechShadowOpacity * 255 * 0.9));
                _uiCommon._setBlendState((nint)masker, EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_SourceAlpha, EUIBlendFactor.UI_BF_One,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One, 0xf, *(int*)_uiCommon._ActiveDrawTypeId);
                _drawRoundRect(textPos.X + self->selBoxShadow.X - selBoxLength / 2, textPos.Y + self->selBoxShadow.Y - 34, 0, 
                    selBoxLength, 54, 6, selBoxShadow, 0, 0, 0, *(int*)_uiCommon._ActiveDrawTypeId, 1);

                _uiCommon._setBlendState((nint)masker, EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_SourceAlpha, EUIBlendFactor.UI_BF_InverseSourceAlpha,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_One, EUIBlendFactor.UI_BF_One, 0xf, *(int*)_uiCommon._ActiveDrawTypeId);
                _drawRoundRect(textPos.X + self->selBoxShadow.X - selBoxLength / 2, textPos.Y + self->selBoxShadow.Y - 27, 0,
                    selBoxLength, 54, 6, new FSprColor(0xff, 0xff, 0xff, (byte)(self->speechShadowOpacity * 255 * 0.9)), 0, 0, 0, *(int*)_uiCommon._ActiveDrawTypeId, 1);

                var selTextColor = ConfigColor.ToFSprColorWithAlpha(_context._config.MsgSimpleSelectTextColor, (byte)(self->speechShadowOpacity * 255 * 0.9));
                _uiCommon._setBlendState((nint)masker, EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_One,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_DestAlpha, EUIBlendFactor.UI_BF_Zero, 0xf, *(int*)_uiCommon._ActiveDrawTypeId);
                _drawSelectText(self, selEntries, textEntries, &entryTL, &entryBR, textPos.X, textPos.Y, selTextColor, selTextCol, nonSelTextCol, selTexOffset, nonSelTexOffset);

                _uiCommon._setBlendState((nint)masker, EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_DestAlpha, EUIBlendFactor.UI_BF_InverseDestAlpha,
                    EUIBlendOperation.UI_BO_Add, EUIBlendFactor.UI_BF_Zero, EUIBlendFactor.UI_BF_Zero, 0xf, *(int*)_uiCommon._ActiveDrawTypeId);
                _drawSelectText(self, selEntries, textEntries, &entryTL, &entryBR, textPos.X, textPos.Y, selTextColor, selTextCol, nonSelTextCol, selTexOffset, nonSelTexOffset);

                NativeMemory.Free(speechBgData);
                NativeMemory.Free(entryAllocTL);
                NativeMemory.Free(entryAllocBR);
                NativeMemory.Free(selEntries);
            }
        }

        private unsafe FSprColor UMsgProcWindow_Select_Simple_SetColorPassthroughImpl(FSprColor source)
        {
            var oldAlpha = source.A;
            var newColor = ConfigColor.ToFSprColor(_context._config.TextBoxBackFillColor);
            newColor.A = oldAlpha;
            return newColor;
        }

        private unsafe delegate bool UMsgProcWindow_Select_Simple_Vtable278(UMsgProcWindow_Select_Simple* self);
        private unsafe delegate void UMsgProcWindow_Select_Simple_DrawListBox(UMsgProcWindow_Select_Simple* self);
        private unsafe delegate USelItem* UselItem_CopySelEntries(USelItem* self, SelBoxStruct1* selEntries);
        private unsafe delegate void SelBoxStruct2_14105cd80(SelBoxStruct2* entry, float* a2, float* a3, int a4, float* a5);
        private unsafe delegate void LocationSelectParam1_DrawSelectMapBg(LocationSelectParams1* self, nint masker, float a3, float a4);
        private unsafe delegate void UMsgProcWindow_Select_Simple_DrawSelectText(
            UMsgProcWindow_Select_Simple* self, SelBoxStruct1* entries, int count, TArray<FVector2D>* topLeft, TArray<FVector2D>* bottomRight, float posX, 
            float posY, FSprColor color, FVector2D selTexCol, FVector2D unSelTexCol, FVector2D selTexOffset, FVector2D nonSelTexOffset);
        private unsafe delegate void DrawRoundRectangle_1414e8450(float x, float y, float z, float sX, float sY, int a6,
            FSprColor color, float a8, float a9, float a10, int queueId, int a12);
    }
}
