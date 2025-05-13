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
    public class MissingPerson : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string UUIMissingPerson_DrawPageBackground_SIG = "48 8D 8F ?? ?? ?? ?? 89 45 ?? E8 ?? ?? ?? ?? F3 0F 59 05 ?? ?? ?? ??";
        // UUIMissingPerson::DrawMissingPersonRows
        private string UUIMissingPerson_SelectedPersonLastSighted_SIG = "4C 8B 7D ?? 48 8D 4D ?? 4D 8B C7";
        // UUIMissingPerson::DrawLabelRow
        private string UUIMissingPerson_DrawLabelRow_SIG = "E8 ?? ?? ?? ?? 49 8B D6 48 8D 4E ?? E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 49 8B D6";
        // UUIMissingPerson::DrawMissingPersonDetails
        private string UUIMissingPerson_DrawPersonEntry_SIG = "4C 8B DC 55 49 8D AB ?? ?? ?? ?? 48 81 EC 80 03 00 00";
        private string UUIMissingPerson_DrawMissingPersonDetails_SIG = "4C 8B DC 55 57 41 56 49 8D AB ?? ?? ?? ?? 48 81 EC 60 08 00 00";

        private string UGlobalWork_CheckDisappearEntryValid_SIG = "40 53 48 83 EC 20 E8 ?? ?? ?? ?? 48 8B D8 48 85 C0 74 ?? 83 78 ?? 00";
        private string UUIMissingPerson_DrawDetailsText_SIG = "40 55 53 57 48 8D AC 24 ?? ?? ?? ?? 48 81 EC C0 01 00 00 8B 9D ?? ?? ?? ??";
        private string UUIMissingPerson_DrawPersonName_SIG = "48 8B C4 55 48 8D 68 ?? 48 81 EC 60 01 00 00 0F 29 70 ??";
        private string USprAsset_FUN_1413283d0_SIG = "48 89 5C 24 ?? 48 89 6C 24 ?? 57 48 83 EC 40 8B 42 ?? 48 8B E9";
        private string USprAsset_FUN_14c0a15d0_SIG = "48 89 5C 24 ?? 48 89 6C 24 ?? 57 48 83 EC 40 8B 42 ?? 48 89 CD";
        private string UUIMissingPerson_FUN_14142bb30_SIG = "E8 ?? ?? ?? ?? 48 8B D6 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ??";

        private string UUIMissingPerson_DrawCompleteText_SIG = "0F 57 DB F3 44 0F 11 44 24 ?? 4D 8B C6 89 45 ?? 48 8B D6 44 89 6D ?? 48 8D 4D ?? C7 45 ?? 00 00 38 C1 44 89 6D ?? E8 ?? ?? ?? ?? 41 0F 28 C4";
        private string UUIMissingPerson_DrawCompleteBg_SIG = "0F 57 DB F3 44 0F 11 44 24 ?? 4D 8B C6 89 45 ?? 48 8B D6 44 89 6D ?? 48 8D 4D ?? C7 45 ?? 00 00 38 C1 44 89 6D ?? E8 ?? ?? ?? ?? 44 38 AF ?? ?? ?? ??";

        private string UUIMissingPerson_CursorColor_SIG = "E8 ?? ?? ?? ?? F3 0F 10 5B ?? 48 8D 4B ??";
        private string UUIMissingPerson_DetailCursorColor_SIG = "E8 ?? ?? ?? ?? F3 0F 10 9E ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ?? F3 0F 59 35 ?? ?? ?? ??";
        private string UUIMissingPerson_BackCampMenuChairAndKotone_SIG = "E8 ?? ?? ?? ?? 44 88 6C 24 ?? 0F 28 DE";
        private string UUIMissingPerson_DetailBackCampMenuChairAndKotone1_SIG = "E8 ?? ?? ?? ?? F3 0F 10 5D ?? BA 7D 00 00 00 F3 0F 10 55 00 49 8B CE 44 88 6C 24 ?? C6 44 24 ?? 01 F3 44 0F 11 5C 24 ?? F3 44 0F 11 5C 24 ?? F3 44 0F 11 44 24 ?? C7 44 24 ?? 16 00 00 00 48 89 5C 24 ?? 89 44 24 ?? F3 44 0F 11 44 24 ?? E8 ?? ?? ?? ?? 33 D2";
        private string UUIMissingPerson_DetailBackCampMenuChairAndKotone2_SIG = "E8 ?? ?? ?? ?? F3 0F 10 5D ?? BA 7D 00 00 00 F3 0F 10 55 00 49 8B CE 44 88 6C 24 ?? C6 44 24 ?? 01 F3 44 0F 11 5C 24 ?? F3 44 0F 11 5C 24 ?? F3 44 0F 11 44 24 ?? C7 44 24 ?? 16 00 00 00 48 89 5C 24 ?? 89 44 24 ?? F3 44 0F 11 44 24 ?? E8 ?? ?? ?? ?? BA 06 00 00 00";
        private string UUIMissingPerson_QuestToggler_SIG = "E8 ?? ?? ?? ?? 89 85 ?? ?? ?? ?? 4D 8B 46 ??";

        private IAsmHook _lastSight;
        private IReverseWrapper<UUIMissingPerson_InjectColorAfterCtorCall> _lastSightWrapper;
        private IAsmHook _pageBg;
        private IReverseWrapper<UUIMissingPerson_InjectColorAfterCtorCall> _pageBgWrapper;
        private IAsmHook _completeText;
        private IReverseWrapper<UUIMissingPerson_InjectColorAfterCtorCall> _completeTextWrapper;
        private IAsmHook _completeBg;
        private IReverseWrapper<UUIMissingPerson_InjectColorAfterCtorCall> _completeBgWrapper;
        private IHook<UUIMissingPerson_DrawLabelRow> _drawLabelRow;
        private IHook<UUIMissingPerson_DrawLabelRow> _drawMissingPersonDetails;
        private UUIMissingPerson_DrawPersonEntry _drawPersonEntry;
        private UGlobalWork_CheckDisappearEntryValid _checkDisappearValid;
        private UUIMissingPerson_DrawPersonName _drawPersonName;
        private UUIMissingPerson_DrawDetailsText _drawDetailsText;
        private USprAsset_FUN_1413283d0 _fun1413283d0;
        private USprAsset_FUN_1413283d0 _fun14c0a15d0;
        private UUIMissingPerson_FUN_14142bb30 _fun14142bb30;
        private IAsmHook _CursorColor;
        private IAsmHook _DetailCursorColor;
        private IAsmHook _BackCampMenuChairAndKotone;
        private IAsmHook _DetailBackCampMenuChairAndKotone;
        private IAsmHook _QuestToggler;

        private UICommon _uiCommon;
        public unsafe MissingPerson(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(UUIMissingPerson_SelectedPersonLastSighted_SIG, "UUIMissingPerson::SelectedPersonLastSighted", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UUIMissingPerson_SelectedPersonLastSighted, out _lastSightWrapper)}",
                };
                _lastSight = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUIMissingPerson_DrawPageBackground_SIG, "UUIMissingPerson::DrawPageBackground", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UUIMissingPerson_PageBackground, out _pageBgWrapper)}",
                };
                _pageBg = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUIMissingPerson_DrawCompleteText_SIG, "UUIMissingPerson::DrawCompleteText", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UUIMissingPerson_DrawCompleteText, out _completeTextWrapper)}",
                };
                _completeText = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUIMissingPerson_DrawCompleteBg_SIG, "UUIMissingPerson::DrawCompleteBg", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(UUIMissingPerson_DrawCompleteBg, out _completeBgWrapper)}",
                };
                _completeBg = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(UUIMissingPerson_DrawPersonEntry_SIG, "UUIMissingPerson::DrawPersonEntry", _context._utils.GetDirectAddress, addr => _drawPersonEntry = _context._utils.MakeWrapper<UUIMissingPerson_DrawPersonEntry>(addr));
            _context._utils.SigScan(UUIMissingPerson_DrawLabelRow_SIG, "UUIMissingPerson::DrawLabelRow", _context._utils.GetIndirectAddressShort, addr => _drawLabelRow = _context._utils.MakeHooker<UUIMissingPerson_DrawLabelRow>(UUIMissingPerson_DrawLabelRowImpl, addr));
            _context._utils.SigScan(UUIMissingPerson_DrawMissingPersonDetails_SIG, "UUIMissingPerson::DrawMissingPersonDetails", _context._utils.GetDirectAddress, addr => _drawMissingPersonDetails = _context._utils.MakeHooker<UUIMissingPerson_DrawLabelRow>(UUIMissingPerson_DrawMissingPersonDetailsimpl, addr));
            _context._utils.SigScan(UGlobalWork_CheckDisappearEntryValid_SIG, "UGlobalWork::CheckDisappearEntryValid", _context._utils.GetDirectAddress, addr => _checkDisappearValid = _context._utils.MakeWrapper<UGlobalWork_CheckDisappearEntryValid>(addr));
            _context._utils.SigScan(UUIMissingPerson_DrawPersonName_SIG, "UUIMissingPerson::DrawPersonName", _context._utils.GetDirectAddress, addr => _drawPersonName = _context._utils.MakeWrapper<UUIMissingPerson_DrawPersonName>(addr));
            _context._utils.SigScan(UUIMissingPerson_DrawDetailsText_SIG, "UUIMissingPerson::DrawDetailsText", _context._utils.GetDirectAddress, addr => _drawDetailsText = _context._utils.MakeWrapper<UUIMissingPerson_DrawDetailsText>(addr));
            _context._utils.SigScan(USprAsset_FUN_1413283d0_SIG, "USprAsset::FUN_1413283d0", _context._utils.GetDirectAddress, addr => _fun1413283d0 = _context._utils.MakeWrapper<USprAsset_FUN_1413283d0>(addr));
            _context._utils.SigScan(USprAsset_FUN_14c0a15d0_SIG, "USprAsset::FUN_14c0a15d0", _context._utils.GetDirectAddress, addr => _fun14c0a15d0 = _context._utils.MakeWrapper<USprAsset_FUN_1413283d0>(addr));
            _context._utils.SigScan(UUIMissingPerson_FUN_14142bb30_SIG, "UUIMissingPerson::FUN_1412bb30", _context._utils.GetIndirectAddressShort, addr => _fun14142bb30 = _context._utils.MakeWrapper<UUIMissingPerson_FUN_14142bb30>(addr));

            _context._utils.SigScan(UUIMissingPerson_CursorColor_SIG, "UUIMissingPerson::CursorColor", _context._utils.GetDirectAddress, addr =>
            {
                ConfigColor reducedHighlightColor = applyColorReduction(_context._config.CampHighlightedColor, (float)0xee / (float)0xff);

                string[] function =
                {
                    "use64",
                    $"mov r8b, ${reducedHighlightColor.B:X}",
                    $"mov dl, ${reducedHighlightColor.G:X}",
                    $"mov cl, ${reducedHighlightColor.R:X}"
                };
                _CursorColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(UUIMissingPerson_DetailCursorColor_SIG, "UUIMissingPerson::DetailCursorColor", _context._utils.GetDirectAddress, addr =>
            {
                ConfigColor reducedHighlightColor = applyColorReduction(_context._config.CampHighlightedColor, (float)0xee / (float)0xff);

                string[] function =
                {
                    "use64",
                    $"mov r8b, ${reducedHighlightColor.B:X}",
                    $"mov dl, ${reducedHighlightColor.G:X}",
                    $"mov cl, ${reducedHighlightColor.R:X}"
                };
                _DetailCursorColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(UUIMissingPerson_BackCampMenuChairAndKotone_SIG, "UUIMissingPerson::BackCampMenuChairAndKotone", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.QuestFemcChairsShadow.B:X}",
                    $"mov dl, ${_context._config.QuestFemcChairsShadow.G:X}",
                    $"mov cl, ${_context._config.QuestFemcChairsShadow.R:X}"
                };
                _BackCampMenuChairAndKotone = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(UUIMissingPerson_DetailBackCampMenuChairAndKotone1_SIG, "UUIMissingPerson::DetailBackCampMenuChairAndKotone1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.MissingDetailFemcChairsShadow.B:X}",
                    $"mov dl, ${_context._config.MissingDetailFemcChairsShadow.G:X}",
                    $"mov cl, ${_context._config.MissingDetailFemcChairsShadow.R:X}"
                };
                _DetailBackCampMenuChairAndKotone = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(UUIMissingPerson_DetailBackCampMenuChairAndKotone2_SIG, "UUIMissingPerson::DetailBackCampMenuChairAndKotone2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.MissingDetailFemcChairsShadow.B:X}",
                    $"mov dl, ${_context._config.MissingDetailFemcChairsShadow.G:X}",
                    $"mov cl, ${_context._config.MissingDetailFemcChairsShadow.R:X}"
                };
                _DetailBackCampMenuChairAndKotone = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(UUIMissingPerson_QuestToggler_SIG, "UUIMissingPerson::QuestToggler", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.QuestToggler.B:X}",
                    $"mov dl, ${_context._config.QuestToggler.G:X}",
                    $"mov cl, ${_context._config.QuestToggler.R:X}"
                };
                _QuestToggler = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
    }

        private ConfigColor applyColorReduction(ConfigColor color, float reductionRatio)
        {
            byte r = (byte)(color.R * reductionRatio);
            byte g = (byte)(color.G * reductionRatio);
            byte b = (byte)(color.B * reductionRatio);

            return new ConfigColor(r, g, b, color.A);
        }

        private unsafe float DrawLabelRowGetOffset(UUIMissingPerson* self)
        {
            if (self->State == 4)
            {
                return 0;
            } else
            {
                if (self->bInCampMenu == 0) return 0;
                else if (self->Field532 == 0) return (1 - UICommon.GetCheckDrawOpacity(&self->LabelRowOpacity)) * -20;
                else return (1 - UICommon.GetCheckDrawOpacity(&self->LabelRowOpacity)) * 20;
            }
        }

        public unsafe void UUIMissingPerson_DrawLabelRowImpl(UUIMissingPerson* self, nint masker)
        {
            // row entries
            var campSprite = (USprAsset*)_uiCommon._globalWorkGetUIResources()->GetAssetEntry(0x32);
            var labelRowAlpha = UICommon.GetCheckDrawOpacity(&self->LabelRowOpacity) * 255;
            var offsetX = DrawLabelRowGetOffset(self) + 166;
            var numRowLabel = new SprDefStruct1(0x362, new FVector(offsetX, 199, 0), new FVector(1, 1, 0), new FSprColor(0x72, 0x72, 0x99, (byte)labelRowAlpha),
                1, 0, 0, 0, 1, 1, 0);
            var nameRowLabel = new SprDefStruct1(0x364, new FVector(offsetX + 386, 199, 0), new FVector(1, 1, 0), new FSprColor(0x72, 0x72, 0x99, (byte)labelRowAlpha),
                1, 0, 0, 0, 1, 1, 0);
            var dateRowLabel = new SprDefStruct1(0x365, new FVector(offsetX + 844, 199, 0), new FVector(1, 1, 0), new FSprColor(0x72, 0x72, 0x99, (byte)labelRowAlpha),
                1, 0, 0, 0, 1, 1, 0);
            var statRowLabel = new SprDefStruct1(0x366, new FVector(offsetX + 1034, 199, 0), new FVector(1, 1, 0), new FSprColor(0x72, 0x72, 0x99, (byte)labelRowAlpha),
                1, 0, 0, 0, 1, 1, 0);

            var sortBy = (self->bHideSortedRow == 1 && self->Field2B0.Field14 != 0) ? self->SortByStatus : self->SortByNumber;
            if (sortBy == 0) statRowLabel.color = ConfigColor.ToFSprColorWithAlpha(_context._config.MissingTextLight, (byte)labelRowAlpha); 
            else numRowLabel.color = ConfigColor.ToFSprColorWithAlpha(_context._config.MissingTextLight, (byte)labelRowAlpha);

            _uiCommon._setPresetBlendState(masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_OPAQUE);
            _uiCommon._spriteFunc1(&numRowLabel, masker, campSprite, 0, 0);
            _uiCommon._spriteFunc1(&nameRowLabel, masker, campSprite, 0, 0);
            _uiCommon._spriteFunc1(&dateRowLabel, masker, campSprite, 0, 0);
            _uiCommon._spriteFunc1(&statRowLabel, masker, campSprite, 0, 0);

            // highlighted sort by
            float f1 = 0;
            float f2 = offsetX;
            float f3 = offsetX;
            if (self->bHideSortedRow == 1)
            {
                if (self->Field2B0.Field14 == 0)
                {
                    f2 = UICommon.GetCheckDrawOpacity(&self->Field2E0);
                    f1 = (1 - f2) * -20;
                } else
                {
                    f2 = 1 - UICommon.GetCheckDrawOpacity(&self->Field2E0);
                }
                f2 *= offsetX;
                f3 *= UICommon.GetCheckDrawOpacity(&self->Field310);
            }

            var selTrianglePos = sortBy == 0 ? new FVector(offsetX + 1036, f1 + 208, 0) : new FVector(offsetX + 2, f1 + 208, 0);
            var sortTextPos = sortBy == 0 ? new FVector(offsetX + 983, f1 + 184, 0) : new FVector(offsetX - 51, f1 + 184, 0);

            var selTriangle = new SprDefStruct1(0x369, selTrianglePos, new FVector(1, 1, 0), ConfigColor.ToFSprColorWithAlpha(_context._config.MissingSortTriangle, (byte)labelRowAlpha),
                1, 0, 0, 0, 1, 1, 0);
            var sortText = new SprDefStruct1(0x36a, sortTextPos, new FVector(1, 1, 0), ConfigColor.ToFSprColorWithAlpha(_context._config.MissingSortTriangle, (byte)labelRowAlpha),
                1, 0, 0, 0, 1, 1, 0);
            _uiCommon._setPresetBlendState(masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_OPAQUE);
            _uiCommon._spriteFunc1(&sortText, masker, campSprite, 0, 0);
            _uiCommon._setPresetBlendState(masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_ADDTRANS);
            _uiCommon._spriteFunc1(&selTriangle, masker, campSprite, 0, 0);
            _uiCommon._setPresetBlendState(masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_OPAQUE);
        }

        public unsafe void UUIMissingPerson_DrawMissingPersonDetailsimpl(UUIMissingPerson* self, nint masker)
        {
            /*
            if (_context._config.DebugDrawMissingPerson)
            {
                _drawMissingPersonDetails.OriginalFunction(self, masker);
                return;
            }
            */
            if (self->MissingPersons.arr_num == 0) return;
            var campSprite = (USprAsset*)_uiCommon._globalWorkGetUIResources()->GetAssetEntry(0x32);
            var yposBase = (1 - UICommon.GetCheckDrawOpacity(&self->Field118)) * 20;

            var missingIdx = UICommon.FUN_14108cca0(self->Field538);
            var missingEntry = self->MissingPersons.GetRef(missingIdx);
            var missingId = self->bOverrideMissing != 0 ? self->currentMissing : missingEntry->Field02;
            FVector selPersonFromListPos = new FVector(self->missingNamesPos.X, (1 - UICommon.GetCheckDrawOpacity(&self->Field178)) * self->Field1A8 + self->missingNamesPos.Y, 0);
            var detailsAlpha = UICommon.GetCheckDrawOpacity(&self->LabelRowOpacity) * 255;
            _drawPersonEntry(self, masker, &selPersonFromListPos, missingEntry, 0x1, detailsAlpha);
            _uiCommon._setPresetBlendState(masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_OPAQUE);
            var textLightColor = ConfigColor.ToFSprColorWithAlpha(_context._config.MissingTextLight, (byte)detailsAlpha);
            var textDarkColor = ConfigColor.ToFSprColorWithAlpha(_context._config.MissingTextDark, (byte)detailsAlpha);
            var whiteColor = ConfigColor.ToFSprColorWithAlpha(_context.ColorWhite, (byte)detailsAlpha);
            var statRowLabel = new SprDefStruct1(0x3da, new FVector(174, yposBase + 355, 0), new FVector(1, 1, 0), textLightColor,
                1, 0, 0, 0, 1, 1, 0);
            var nameBg = new SprDefStruct1(0x3db, new FVector(265, yposBase + 355 + 83, 0), new FVector(1, 1, 0), textLightColor,
                1, 0, 0, 0, 1, 1, 0);
            var nameText = new SprDefStruct1(0x3dc, new FVector(265, yposBase + 355 + 83, 0), new FVector(1, 1, 0), textDarkColor,
                1, 0, 0, 0, 1, 1, 0);
            var sexBg = new SprDefStruct1(0x3db, new FVector(265, yposBase + 355 + 133, 0), new FVector(1, 1, 0), textLightColor,
                1, 0, 0, 0, 1, 1, 0);
            var sexText = new SprDefStruct1(0x3de, new FVector(265, yposBase + 355 + 133, 0), new FVector(1, 1, 0), textDarkColor,
                1, 0, 0, 0, 1, 1, 0);
            var ageBg = new SprDefStruct1(0x3db, new FVector(265, yposBase + 355 + 183, 0), new FVector(1, 1, 0), textLightColor,
                1, 0, 0, 0, 1, 1, 0);
            var ageText = new SprDefStruct1(0x3e0, new FVector(265, yposBase + 355 + 183, 0), new FVector(1, 1, 0), textDarkColor,
                1, 0, 0, 0, 1, 1, 0);
            var occupyBg = new SprDefStruct1(0x3db, new FVector(265, yposBase + 355 + 233, 0), new FVector(1, 1, 0), textLightColor,
                1, 0, 0, 0, 1, 1, 0);
            var occupyText = new SprDefStruct1(0x3e2, new FVector(265, yposBase + 355 + 233, 0), new FVector(1, 1, 0), textDarkColor,
                1, 0, 0, 0, 1, 1, 0);
            var lastSight = new SprDefStruct1(0x3e4, new FVector(171, yposBase + 677, 0), new FVector(1, 1, 0), textLightColor,
                1, 0, 0, 0, 1, 1, 0);
            var lastSightDot = new SprDefStruct1(0x3a3, new FVector(203, yposBase + 677 + 68, 0), new FVector(1, 1, 0), whiteColor,
                1, 0, 0, 0, 1, 1, 0);

            _uiCommon._spriteFunc2(&statRowLabel, masker, campSprite, 0, 0);
            _uiCommon._spriteFunc1(&nameBg, masker, campSprite, 0, 0);
            _uiCommon._spriteFunc1(&nameText, masker, campSprite, 0, 0);
            _uiCommon._spriteFunc1(&sexBg, masker, campSprite, 0, 0);
            _uiCommon._spriteFunc1(&sexText, masker, campSprite, 0, 0);
            _uiCommon._spriteFunc1(&ageBg, masker, campSprite, 0, 0);
            _uiCommon._spriteFunc1(&ageText, masker, campSprite, 0, 0);
            _uiCommon._spriteFunc1(&occupyBg, masker, campSprite, 0, 0);
            _uiCommon._spriteFunc1(&occupyText, masker, campSprite, 0, 0);
            _uiCommon._spriteFunc2(&lastSight, masker, campSprite, 0, 0);
            _uiCommon._spriteFunc2(&lastSightDot, masker, campSprite, 0, 0);

            if (self->MissingPersons.arr_num > 0)
            {
                // draw scroll arrows
                var scrollF1 = UICommon.GetCheckDrawOpacity(&self->Field8D0);
                var scrollF2 = UICommon.GetCheckDrawOpacity(&self->Field900);
                var scrollF3 = scrollF1 * (1 - scrollF2);
                var scrollF4 = ((scrollF2 * 20 - 20) - self->Field938) - self->Field970;
                var scrollF5 = (1 - scrollF2) * 20 + self->Field938 + self->Field9A8;
                self->arrowUpA.Field1C = scrollF3;
                self->arrowDownA.Field1C = scrollF3;
                var scrollColor = new FSprColor((byte)(scrollF3 * 234), 0, (byte)(scrollF3 * 41), 0xff);
                self->arrowUpB.color = scrollColor;
                self->arrowDownB.color = scrollColor;

                _uiCommon._setPresetBlendState(masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_OPAQUE);
                _uiCommon._spriteFunc1(&self->arrowUpA, masker, campSprite, 678, scrollF4 + 171);
                _uiCommon._setPresetBlendState(masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_ADDTRANS);
                _uiCommon._spriteFunc1(&self->arrowUpB, masker, campSprite, 678, scrollF4 + 164);
                _uiCommon._setPresetBlendState(masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_OPAQUE);
                _uiCommon._spriteFunc1(&self->arrowDownA, masker, campSprite, 678, scrollF5 + 1016);
                _uiCommon._setPresetBlendState(masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_ADDTRANS);
                _uiCommon._spriteFunc1(&self->arrowDownB, masker, campSprite, 678, scrollF5 + 1026);
                _uiCommon._setPresetBlendState(masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_OPAQUE);

                _fun1413283d0(&self->arrowUpA, campSprite);
                _fun14c0a15d0(&self->arrowUpA, campSprite);
                _fun14142bb30(self, 2, 678, 164, scrollF1, scrollF2 + 15, 0x37);
                _fun1413283d0(&self->arrowDownA, campSprite);
                _fun14c0a15d0(&self->arrowDownA, campSprite);
                _fun14142bb30(self, 2, 678, 1026, scrollF1, scrollF2 + 20, 0x37);
            }

            var detailOpacity = UICommon.GetCheckDrawOpacity(&self->Field218) * detailsAlpha;
            var detailXpos = 0f;
            if (self->Field248.Field14 != 0)
            {
                var f3 = UICommon.GetCheckDrawOpacity(&self->Field248);
                detailOpacity *= f3;
                detailXpos = (1 - f3) * -20;
            }
            if (_checkDisappearValid(missingId) == 1)
            {
                // currently misaligned...
                var textPos = new FVector2D(89, -17);
                if (self->TextPosLayoutData != null && self->TextPosLayoutData->GetLayoutDataTableEntry(9) != null)
                {
                    var textPosLayout = self->TextPosLayoutData->GetLayoutDataTableEntry(9);
                    textPos.X = textPosLayout->position.X;
                    textPos.Y = textPosLayout->position.Y;
                }
                var textCol = new FVector2D(0, 0);
                if (self->TextColLayoutData != null && self->TextColLayoutData->GetLayoutDataTableEntry(9) != null)
                {
                    var texColLayout = self->TextColLayoutData->GetLayoutDataTableEntry(9);
                    textCol.X = texColLayout->position.X;
                    textCol.Y = texColLayout->position.Y;
                }
                var detailsX = textPos.X + detailXpos + 265;
                var detailsWhite = ConfigColor.ToFSprColorWithAlpha(_context.ColorWhite, (byte)detailOpacity);
                _drawPersonName(detailsX, textPos.Y + yposBase + 355 + 83, 0, textCol.X, textCol.Y, detailsWhite, missingId, *_uiCommon._ActiveDrawTypeId, 0, null);
                _drawDetailsText(detailsX, textPos.Y + yposBase + 355 + 133, 0, textCol.X, textCol.Y, detailsWhite, missingId, 1, *_uiCommon._ActiveDrawTypeId, 0, null, 1, 0);
                _drawDetailsText(detailsX, textPos.Y + yposBase + 355 + 183, 0, textCol.X, textCol.Y, detailsWhite, missingId, 0, *_uiCommon._ActiveDrawTypeId, 0, null, 1, 0);
                _drawDetailsText(detailsX, textPos.Y + yposBase + 355 + 233, 0, textCol.X, textCol.Y, detailsWhite, missingId, 2, *_uiCommon._ActiveDrawTypeId, 0, null, 1, 0);
                _drawDetailsText(textPos.X + detailXpos + 171, yposBase + 677 + 65, 0, textCol.X, textCol.Y, detailsWhite, missingId, 3, *_uiCommon._ActiveDrawTypeId, 0, null, 1, 0);
            } else
            {
                var nameIdk = new SprDefStruct1(0x3dd, new FVector(detailXpos + 357, yposBase + 355 + 83 - 21, 0), new FVector(1, 1, 0), textLightColor,
                1, 0, 0, 0, 1, 1, 0);
                var sexIdk = new SprDefStruct1(0x3df, new FVector(detailXpos + 357, yposBase + 355 + 133 - 21, 0), new FVector(1, 1, 0), textLightColor,
                    1, 0, 0, 0, 1, 1, 0);
                var ageIdk = new SprDefStruct1(0x3e1, new FVector(detailXpos + 357, yposBase + 355 + 183 - 21, 0), new FVector(1, 1, 0), textLightColor,
                    1, 0, 0, 0, 1, 1, 0);
                var occupyIdk = new SprDefStruct1(0x3e3, new FVector(detailXpos + 357, yposBase + 355 + 233 - 21, 0), new FVector(1, 1, 0), textLightColor,
                    1, 0, 0, 0, 1, 1, 0);
                var lastSightIdk = new SprDefStruct1(0x3e5, new FVector(detailXpos + 245, yposBase + 677 + 65, 0), new FVector(1, 1, 0), whiteColor,
                    1, 0, 0, 0, 1, 1, 0);
                _uiCommon._spriteFunc2(&nameIdk, masker, campSprite, 0, 0);
                _uiCommon._spriteFunc2(&sexIdk, masker, campSprite, 0, 0);
                _uiCommon._spriteFunc2(&ageIdk, masker, campSprite, 0, 0);
                _uiCommon._spriteFunc2(&occupyIdk, masker, campSprite, 0, 0);
                _uiCommon._spriteFunc2(&lastSightIdk, masker, campSprite, 0, 0);
            }
        }
        public unsafe FSprColor UUIMissingPerson_SelectedPersonLastSighted(FSprColor source) => ConfigColor.ToFSprColorWithAlpha(_context._config.MissingLastSighted, source.A);
        public unsafe FSprColor UUIMissingPerson_PageBackground(FSprColor source) => ConfigColor.ToFSprColorWithAlpha(_context._config.MissingPageBg, source.A);
        public unsafe FSprColor UUIMissingPerson_DrawCompleteText(FSprColor source) => new FSprColor(0x76, 0x17, 0x37, source.A);
        public unsafe FSprColor UUIMissingPerson_DrawCompleteBg(FSprColor source) => new FSprColor(0x33, 0x0, 0x15, source.A);

        [Function(FunctionAttribute.Register.rax, FunctionAttribute.Register.rax, false)]
        public unsafe delegate FSprColor UUIMissingPerson_InjectColorAfterCtorCall(FSprColor source);
        public unsafe delegate void UUIMissingPerson_DrawLabelRow(UUIMissingPerson* self, nint masker);
        public unsafe delegate void UUIMissingPerson_DrawPersonEntry(UUIMissingPerson* self, nint masker, FVector* pos, FMissingEntry* entry, byte a5, float a6);
        public unsafe delegate byte UGlobalWork_CheckDisappearEntryValid(ushort id);
        public unsafe delegate void UUIMissingPerson_DrawPersonName(float X, float Y, float Z, float x2, float y2, FSprColor color, ushort id, uint queueId, uint a9, float* mtx);
        public unsafe delegate void UUIMissingPerson_DrawDetailsText(float X, float Y, float Z, float x2, float y2, FSprColor color, ushort id, byte category, uint queueId, uint a9, float* mtx, byte a11, int a12);
        public unsafe delegate float USprAsset_FUN_1413283d0(SprDefStruct1* spr, USprAsset* asset);
        public unsafe delegate void UUIMissingPerson_FUN_14142bb30(UUIMissingPerson* self, ushort id, float a3, float a4, float a5, float a6, int a7);
        public override void Register() 
        {
            _uiCommon = GetModule<UICommon>();
        }
    }
}
