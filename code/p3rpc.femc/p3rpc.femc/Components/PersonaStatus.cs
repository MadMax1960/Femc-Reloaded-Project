using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{   
    public class PersonaStatus : ModuleAsmInlineColorEdit<FemcContext>
    {
        // so many hooks....
        private string APersonaStatusDraw_GetDefaultPersonaInfoBgInner_SIG = "48 8B C4 55 53 56 57 41 56 48 8D A8 ?? ?? ?? ?? 48 81 EC B0 01 00 00";
        private string APersonaStatusDraw_DrawGradientRectangle_SIG = "48 8B C4 48 89 58 ?? 48 89 70 ?? 48 89 78 ?? 55 41 54 41 55 41 56 41 57 48 8D A8 ?? ?? ?? ?? 48 81 EC B0 03 00 00";
        private string APersonaStatusDraw_DrawDefaultStatusParameterInner_SIG = "40 55 57 48 8D AC 24 ?? ?? ?? ?? 48 81 EC 88 03 00 00";
        // in APersonaStatusDraw::DrawDefaultPersonaInfo
        private string APersonaStatusDraw_GetDefaultPersonaInfo_PlayerName_SIG = "41 81 C9 00 EA FF 00"; // or r9d, 0xffea00, + 0x785
        // in APersonaStatusDraw::DrawSkillListInner
        private string APersonaStatusDraw_GetSkillListBgColor_SIG = "C7 45 ?? 3B 02 00 FF E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ??";
        private string APersonaStatusDraw_GetSkillListCheckerboard1_SIG = "C7 45 ?? 66 2F 2B FF";
        private string APersonaStatusDraw_GetSkillListCheckerboard2_SIG = "C7 44 24 ?? 66 2F 2B FF";
        private string APersonaStatusDraw_GetSkillListNoNextSkill_SIG = "C7 45 ?? 58 20 1D FF";
        private string APersonaStatusDraw_GetSkillListNextSkill_SIG = "C7 45 ?? C6 0E 00 FF F3 44 0F 11 44 24 ??";
        private string APersonaStatusDraw_GetSkillListNextLevel_SIG = "C7 45 ?? FF D3 00 FF 48 8D 45 ??";
        private string APersonaStatusDraw_GetSkillListNextSkillInfoBg_SIG = "C7 45 ?? C6 0E 00 FF 48 89 44 24 ??";
        private string APersonaStatusDraw_GetSkillListNextSkillInfoText_SIG = "C7 44 24 ?? FF D3 00 FF 8B 5C 24 ??";
        // in APersonaStatusDraw::DrawDefaultCommentaryInner
        private string APersonaStatusDraw_GetCommentaryTitle_SIG = "";

        //private static float[] PersonaInfoBgPoints = { 0, 0, 1270.5f, 0, 1732.5f, 0, 2310, 0, 0, 224, 1270.5f, 24, 1732.5f, 224, 2310, 224 };
        private unsafe float* PersonaInfoBgPoints;
        public struct PersonaStatusGradientLine
        {
            public FColor farL;
            public FColor midL;
            public FColor midR;
            public FColor farR;
            public PersonaStatusGradientLine(FColor c0, FColor c1, FColor c2, FColor c3) { farL = c0; midL = c1; midR = c2; farR = c3; }
            public PersonaStatusGradientLine(FColor c0) { farL = c0; midL = c0; midR = c0; farR = c0; }
        }

        public static readonly PersonaStatusGradientLine WhiteGradient = new PersonaStatusGradientLine(new FColor(0xff, 0xff, 0xff, 0xff));

        //public PersonaStatusGradientLine[] PersonaInfoBgColors;
        private unsafe PersonaStatusGradientLine* PersonaInfoBgColors;
        private unsafe float* PersonaStatParamBgPoints;
        private unsafe PersonaStatusGradientLine* PersonaStatParamBgColors;

        private UICommon _uiCommon;
        private IHook<APersonaStatusDraw_DrawDefaultPersonaInfoBackgroundInner> _drawInfoBg;
        private APersonaStatusDraw_DrawGradientRectangle _drawGradRect;

        private IHook<APersonaStatusDraw_DrawDefaultStatusParameterInner> _drawStatParam;
        public unsafe PersonaStatus(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListBgColor_SIG, "APersonaStatusDraw::GetSkillListBgColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaStatusSkillListBg.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListCheckerboard1_SIG, "APersonaStatusDraw::GetSkillListCheckerboard1", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaStatusSkillListCheckboardAlt.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListCheckerboard2_SIG, "APersonaStatusDraw::GetSkillListCheckerboard2", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.PersonaStatusSkillListCheckboardAlt.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListNoNextSkill_SIG, "APersonaStatusDraw::GetSkillListNoNextSkill", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaStatusSkillListCheckboardAlt.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListNextSkill_SIG, "APersonaStatusDraw::GetSkillListNextSkill", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaSkillListNextSkillColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListNextLevel_SIG, "APersonaStatusDraw::GetSkillListNextLevel", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaSkillListNextLevelColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListNextSkillInfoBg_SIG, "APersonaStatusDraw::GetSkillListNextSkillInfoBg", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaSkillListNextSkillColor.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetSkillListNextSkillInfoText_SIG, "APersonaStatusDraw::GetSkillListNextSkillInfoText", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 4, _context._config.PersonaSkillListNextSkillInfoName.ToU32ARGB())));
            });
            _context._utils.SigScan(APersonaStatusDraw_GetDefaultPersonaInfo_PlayerName_SIG, "APersonaStatusDraw::GetDefaultPersonaInfoPlayerName", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 3, _context._config.PersonaStatusPlayerInfoColor.ToU32())));
            });

            _context._utils.SigScan(APersonaStatusDraw_GetDefaultPersonaInfoBgInner_SIG, "APersonaStatusDraw::GetDefaultPersonaInfoBgInner", _context._utils.GetDirectAddress, addr => _drawInfoBg = _context._utils.MakeHooker<APersonaStatusDraw_DrawDefaultPersonaInfoBackgroundInner>(APersonaStatusDraw_DrawDefaultPersonaInfoBackgroundInnerImpl, addr));
            _context._utils.SigScan(APersonaStatusDraw_DrawGradientRectangle_SIG, "APersonaStatusDraw::DrawGradientRectangle", _context._utils.GetDirectAddress, addr => _drawGradRect = _context._utils.MakeWrapper<APersonaStatusDraw_DrawGradientRectangle>(addr));
            _context._utils.SigScan(APersonaStatusDraw_DrawDefaultStatusParameterInner_SIG, "APersonaStatusDraw::DrawDefaultStatusParameterInner", _context._utils.GetDirectAddress, addr => _drawStatParam = _context._utils.MakeHooker<APersonaStatusDraw_DrawDefaultStatusParameterInner>(APersonaStatusDraw_DrawDefaultStatusParameterInnerImpl, addr));

            /*
            PersonaInfoBgColors = new [] {
                new PersonaStatusGradientLine(new FSprColor(0xff, 0xff, 0xff, 0xff)),
                new PersonaStatusGradientLine(new FSprColor(0xff, 0xff, 0xff, 0xff))
            };
            */
            // C# arrays are managed types, we're going to have to manually allocate memory to be able to pass it to native functions
            // APersonaStatusDraw::DrawDefaultPersonaInfoBg
            PersonaInfoBgPoints = (float*)NativeMemory.AllocZeroed(sizeof(float) * 16);
            PersonaInfoBgPoints[2] = 1270.5f;
            PersonaInfoBgPoints[4] = 1732.5f;
            PersonaInfoBgPoints[6] = 2310;
            PersonaInfoBgPoints[9] = 224;
            PersonaInfoBgPoints[10] = 1270.5f;
            PersonaInfoBgPoints[11] = 224;
            PersonaInfoBgPoints[12] = 1732.5f;
            PersonaInfoBgPoints[13] = 224;
            PersonaInfoBgPoints[14] = 2310;
            PersonaInfoBgPoints[15] = 224;

            PersonaInfoBgColors = (PersonaStatusGradientLine*)NativeMemory.AllocZeroed((nuint)(sizeof(PersonaStatusGradientLine) * 2));
            PersonaInfoBgColors[0] = WhiteGradient;
            PersonaInfoBgColors[1] = WhiteGradient;

            // APersonaStatusDraw::DrawDefaultStatusParameter
            PersonaStatParamBgPoints = (float*)NativeMemory.AllocZeroed(sizeof(float) * 16);
            PersonaStatParamBgPoints[0] = -439;
            PersonaStatParamBgPoints[1] = -68;
            PersonaStatParamBgPoints[2] = -114;
            PersonaStatParamBgPoints[3] = -130;
            PersonaStatParamBgPoints[4] = 197;
            PersonaStatParamBgPoints[5] = -188;
            PersonaStatParamBgPoints[6] = 494;
            PersonaStatParamBgPoints[7] = -245;
            PersonaStatParamBgPoints[8] = -493;
            PersonaStatParamBgPoints[9] = 246;
            PersonaStatParamBgPoints[10] = -168;
            PersonaStatParamBgPoints[11] = 184;
            PersonaStatParamBgPoints[12] = 143;
            PersonaStatParamBgPoints[13] = 125;
            PersonaStatParamBgPoints[14] = 440;
            PersonaStatParamBgPoints[15] = 69;

            PersonaStatParamBgColors = (PersonaStatusGradientLine*)NativeMemory.AllocZeroed((nuint)(sizeof(PersonaStatusGradientLine) * 2));
            /*
            PersonaStatParamBgColors[0] = new PersonaStatusGradientLine(new FColor(0x00, 0x00, 0x0b, 0xc1));
            PersonaStatParamBgColors[1] = new PersonaStatusGradientLine(new FColor(0x00, 0x00, 0x0b, 0xc1));

            PersonaStatParamBgColors[0].midL = new FColor(0xff, 0x00, 0x0b, 0xc1);
            PersonaStatParamBgColors[0].midR = new FColor(0xff, 0x00, 0x0b, 0xc1);
            PersonaStatParamBgColors[1].midL = new FColor(0xff, 0x00, 0x0b, 0xc1);
            PersonaStatParamBgColors[1].midR = new FColor(0xff, 0x00, 0x0b, 0xc1);
            */
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }
        private unsafe bool CurrentPersonaIsEquipped(APersonaStatusDraw* self)
        {
            var gWork = _uiCommon._getUGlobalWork();
            var pUnit = gWork->GetUnit(1);
            if (gWork != null && pUnit->persona.GetPersona(pUnit->persona.equip)->Id == self->pCurrentPersona->Id)
            {
                return true;
            }
            return false;
        }
        private unsafe void APersonaStatusDraw_DrawDefaultPersonaInfoBackgroundInnerImpl(APersonaStatusDraw* self, float X, float Y, float Angle)
        {
            FVector2D cPos = new FVector2D(X + 480, Y - 62);
            float cAngle = Angle - 11.2f;
            var topLeftColor = ConfigColor.ToFColorBP(_context._config.PersonaStatusSkillListBg);
            _uiCommon._drawRect(&self->baseObj.drawer, cPos.X - 550, cPos.Y - 87, 0, 810, 200, &topLeftColor, 1, 1, cAngle, 1.5f, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
            var lineColor = ConfigColor.ToFColorBP(_context._config.PersonaStatusPlayerInfoColor);
            _uiCommon._drawRect(&self->baseObj.drawer, cPos.X - 16, cPos.Y - 89, 0, 2310, 57, &lineColor, 1, 1, cAngle, 1.5f, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
            var bottomColor = ConfigColor.ToFColorBP(_context._config.PersonaStatusSkillListBg);
            var bottomModX = new FAppCalculationItem(0, -134, self->Edit_Commentary_Affinity_SlideOut_Delay, self->Edit_Commentary_Affinity_SlideOut_Frame, appCalculationType.DEC);
            var bottomModY = new FAppCalculationItem(0, -128, self->Edit_Commentary_Affinity_SlideOut_Delay, self->Edit_Commentary_Affinity_SlideOut_Frame, appCalculationType.DEC);
            var lx = _uiCommon._appCalcLerp(self->PersonaInfoBottomBarMod, &bottomModX, 1, 0);
            var ly = _uiCommon._appCalcLerp(self->PersonaInfoBottomBarMod, &bottomModY, 1, 0);
            _uiCommon._drawRect(&self->baseObj.drawer, cPos.X + lx + 24, cPos.Y + ly + 115, 0, 2310, 156, &bottomColor, 1, 1, cAngle, 1.5f, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
            
            if (self->PlayerId == 1 && CurrentPersonaIsEquipped(self))
            {
                PersonaInfoBgColors[0].midR = ConfigColor.ToFColorBP(_context._config.PersonaStatusInfoSelPersonaColor1);
                PersonaInfoBgColors[0].farR = ConfigColor.ToFColorBP(_context._config.PersonaStatusInfoSelPersonaColor2);
                PersonaInfoBgColors[1].midR = ConfigColor.ToFColorBP(_context._config.PersonaStatusInfoSelPersonaColor1);
                PersonaInfoBgColors[1].farR = ConfigColor.ToFColorBP(_context._config.PersonaStatusInfoSelPersonaColor2);
            } else
            {
                PersonaInfoBgColors[0].midR = ConfigColor.ToFColorBP(_context.ColorWhite);
                PersonaInfoBgColors[0].farR = ConfigColor.ToFColorBP(_context.ColorWhite);
                PersonaInfoBgColors[1].midR = ConfigColor.ToFColorBP(_context.ColorWhite);
                PersonaInfoBgColors[1].farR = ConfigColor.ToFColorBP(_context.ColorWhite);
            }
            var mtxPos = new FVector(0, 0, 1);
            var tgtMtx = (float*)NativeMemory.Alloc(sizeof(float) * 16);
            NativeMemory.Copy(UICommon.IdentityMatrixNative, tgtMtx, sizeof(float) * 16);
            var drawerIn = &self->baseObj.drawer;
            _uiCommon.BPDrawSpr_RotateMatrix(&self->baseObj.drawer, tgtMtx, &mtxPos, cAngle);
            mtxPos = new FVector(-1155, -112, 0);
            _uiCommon.BPDrawSpr_TransformMatrix(&self->baseObj.drawer, tgtMtx, &mtxPos);
            _drawGradRect(self, cPos.X, cPos.Y, 0, PersonaInfoBgPoints, (FSprColor*)PersonaInfoBgColors, tgtMtx);
            NativeMemory.Free(tgtMtx);
            //_drawInfoBg.OriginalFunction(self, X, Y, Angle);
        }

        private unsafe void APersonaStatusDraw_DrawDefaultStatusParameterInnerImpl(APersonaStatusDraw* self, float X, float Y, float Angle, float a5)
        {
            if (self->Field7BC > 0 && self->Field7C0 <= 0) return;
            var statBgCenter = ConfigColor.ToFColorBPWithAlpha(_context._config.PersonaStatusParamColor, 0xff);
            var statBgOuter = ConfigColor.ToFColorBPWithAlpha(_context._config.PersonaStatusParamColor, 0x0);
            PersonaStatParamBgColors[0].farL = statBgOuter;
            PersonaStatParamBgColors[0].midL = statBgCenter;
            PersonaStatParamBgColors[0].midR = statBgCenter;
            PersonaStatParamBgColors[0].farL = statBgOuter;
            PersonaStatParamBgColors[1].farL = statBgOuter;
            PersonaStatParamBgColors[1].midL = statBgCenter;
            PersonaStatParamBgColors[1].midR = statBgCenter;
            PersonaStatParamBgColors[1].farL = statBgOuter;

            var v1 = new FAppCalculationItem(0, 1, self->Edit_SkillList_SlideIn_Frame, self->Edit_PersonaInfo_SlideIn_Frame, appCalculationType.DEC);
            var f1 = _uiCommon._appCalcLerp(self->Field5C4, &v1, 1, 0);
            _drawGradRect(self, X + 124, Y + 80, 6, PersonaStatParamBgPoints, (FSprColor*)PersonaStatParamBgColors, null);
            var resrc = _uiCommon._globalWorkGetUIResources();
            var campSpr = (USprAsset*)resrc->GetAssetEntry(0x32);
            for (int i = 0; i < 5; i++)
            {
                var statIconPos = new FVector2D(X - i * 8, Y + i * 53);
                var statIconPosLayout = statIconPos;
                if (self->LayoutDataTable != null)
                {
                    var statIconLayoutParam = self->LayoutDataTable->GetLayoutDataTableEntry(7);
                    statIconPosLayout.X += statIconLayoutParam->position.X;
                    statIconPosLayout.Y += statIconLayoutParam->position.Y;
                }
                var statIconShadowCol = ConfigColor.ToFColorBP(_context._config.PersonaSkillListNextLevelColor);
                _uiCommon._drawSpr(&self->baseObj.drawer, statIconPosLayout.X, statIconPosLayout.Y, 0, &statIconShadowCol, (uint)(i + 0x1bf), 1, 1, Angle, campSpr, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
                var statIconFillCol = new FColor(0xcc, 0x0, 0x0, 0x0);
                _uiCommon._drawSpr(&self->baseObj.drawer, statIconPosLayout.X, statIconPosLayout.Y, 0, &statIconFillCol, (uint)(i + 0x1ba), 1, 1, Angle, campSpr, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
                var personaStatLevel = self->GetBasePersonaStat(i) + self->pPersonaEquipEffect->GetEquipBonusStat(i);
                var personaStatLevelColor = ConfigColor.ToFColorBP(_context.ColorWhite);
                if (personaStatLevel > 99) personaStatLevel = 99;
                string personaStatLevelStr = $"{personaStatLevel}";
                for (int j = 0; j < personaStatLevelStr.Length; j++)
                {
                    _uiCommon._drawSpr(&self->baseObj.drawer, statIconPos.X - 64 + j * 40, statIconPos.Y - 12 - 8 * j, 0, &personaStatLevelColor,
                        (uint)(personaStatLevelStr[j] + 0x13a), 0.85f, 0.85f, Angle - 11.45f, campSpr, EUI_DRAW_POINT.UI_DRAW_LEFT_TOP, self->baseObj.QueueId);
                }
                var barShadowColor = ConfigColor.ToFColorBP(_context._config.PersonaStatusSkillListBg);
                _uiCommon._drawSpr(&self->baseObj.drawer, statIconPos.X + 251, statIconPos.Y - 40, 0, &barShadowColor, 0x1c9, 1, 1, Angle - 11, campSpr, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);
                var barContentColor = ConfigColor.ToFColorBP(_context._config.PersonaStatusSkillListCheckboardAlt);
                _uiCommon._drawSpr(&self->baseObj.drawer, statIconPos.X + 234, statIconPos.Y - 45, 0, &barContentColor, 0x1c9, 1, 1, Angle - 11, campSpr, EUI_DRAW_POINT.UI_DRAW_CENTER_CENTER, self->baseObj.QueueId);

                // draw next level stat increase
                // draw equip item stat increase
                if (self->pPersonaEquipEffect->GetEquipBonusStat(i) > 0)
                {

                }
                // draw base stat
            }
            //_drawStatParam.OriginalFunction(self, X, Y, Angle, a5);
        }
        private unsafe delegate void APersonaStatusDraw_DrawDefaultPersonaInfoBackgroundInner(APersonaStatusDraw* self, float X, float Y, float Angle);
        private unsafe delegate void APersonaStatusDraw_DrawGradientRectangle(APersonaStatusDraw* self, float X, float Y, int a4, float* points, FSprColor* colors, float* rotMtx);
        private unsafe delegate void APersonaStatusDraw_DrawDefaultStatusParameterInner(APersonaStatusDraw* self, float X, float Y, float Angle, float a5);
    }
}
