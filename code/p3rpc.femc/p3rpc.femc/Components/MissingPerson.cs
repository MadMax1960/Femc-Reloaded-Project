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

        private string UGlobalWorkk_CheckDisappearEntryValid_SIG = "E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? 48 8B 8F ?? ?? ?? ?? F3 0F 10 3D ?? ?? ?? ??";

        private IAsmHook _lastSight;
        private IReverseWrapper<UUIMissingPerson_InjectColorAfterCtorCall> _lastSightWrapper;
        private IAsmHook _pageBg;
        private IReverseWrapper<UUIMissingPerson_InjectColorAfterCtorCall> _pageBgWrapper;
        private IHook<UUIMissingPerson_DrawLabelRow> _drawLabelRow;
        private IHook<UUIMissingPerson_DrawLabelRow> _drawMissingPersonDetails;
        private UUIMissingPerson_DrawPersonEntry _drawPersonEntry;
        private UGlobalWork_CheckDisappearEntryValid _checkDisappearValid;

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
            _context._utils.SigScan(UUIMissingPerson_DrawPersonEntry_SIG, "UUIMissingPerson::DrawPersonEntry", _context._utils.GetDirectAddress, addr => _drawPersonEntry = _context._utils.MakeWrapper<UUIMissingPerson_DrawPersonEntry>(addr));
            _context._utils.SigScan(UUIMissingPerson_DrawLabelRow_SIG, "UUIMissingPerson::DrawLabelRow", _context._utils.GetIndirectAddressShort, addr => _drawLabelRow = _context._utils.MakeHooker<UUIMissingPerson_DrawLabelRow>(UUIMissingPerson_DrawLabelRowImpl, addr));
            _context._utils.SigScan(UUIMissingPerson_DrawMissingPersonDetails_SIG, "UUIMissingPerson::DrawMissingPersonDetails", _context._utils.GetDirectAddress, addr => _drawMissingPersonDetails = _context._utils.MakeHooker<UUIMissingPerson_DrawLabelRow>(UUIMissingPerson_DrawMissingPersonDetailsimpl, addr));
            _context._utils.SigScan(UGlobalWorkk_CheckDisappearEntryValid_SIG, "UGlobalWork::CheckDisappearEntryValid", _context._utils.GetIndirectAddressShort, addr => _checkDisappearValid = _context._utils.MakeWrapper<UGlobalWork_CheckDisappearEntryValid>(addr));
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
            if (sortBy == 0) statRowLabel.color = new FSprColor(0x67, 0xfc, 0xfc, (byte)labelRowAlpha);
            else numRowLabel.color = new FSprColor(0x67, 0xfc, 0xfc, (byte)labelRowAlpha);

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

            var selTriangle = new SprDefStruct1(0x369, selTrianglePos, new FVector(1, 1, 0), new FSprColor(0x0, 0x59, 0xfc, (byte)labelRowAlpha),
                1, 0, 0, 0, 1, 1, 0);
            var sortText = new SprDefStruct1(0x36a, sortTextPos, new FVector(1, 1, 0), new FSprColor(0x0, 0x59, 0xfc, (byte)labelRowAlpha),
                1, 0, 0, 0, 1, 1, 0);
            _uiCommon._setPresetBlendState(masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_OPAQUE);
            _uiCommon._spriteFunc1(&sortText, masker, campSprite, 0, 0);
            _uiCommon._setPresetBlendState(masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_ADDTRANS);
            _uiCommon._spriteFunc1(&selTriangle, masker, campSprite, 0, 0);
            _uiCommon._setPresetBlendState(masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_OPAQUE);
        }

        public unsafe void UUIMissingPerson_DrawMissingPersonDetailsimpl(UUIMissingPerson* self, nint masker)
        {
            if (_context._config.DebugDrawMissingPerson)
            {
                _drawMissingPersonDetails.OriginalFunction(self, masker);
                return;
            }
            if (self->MissingPersons.arr_num == 0) return;
            var campSprite = (USprAsset*)_uiCommon._globalWorkGetUIResources()->GetAssetEntry(0x32);
            var yposBase = (1 - UICommon.GetCheckDrawOpacity(&self->Field118)) * 20;

            var missingIdx = UICommon.FUN_14108cca0(self->Field538);
            var missingEntry = self->MissingPersons.GetRef(missingIdx);
            var missingField02 = self->bOverrideMissing != 0 ? self->currentMissing : missingEntry->Field02;
            FVector v1 = new FVector(self->missingNamesPos.X, 1 - UICommon.GetCheckDrawOpacity(&self->Field178) * self->Field1A8 + self->missingNamesPos.Y, 0);
            var detailsAlpha = UICommon.GetCheckDrawOpacity(&self->LabelRowOpacity) * 255;
            _drawPersonEntry(self, masker, &v1, missingEntry, 0x1, detailsAlpha);

            _uiCommon._setPresetBlendState(masker, EUIOTPRESET_BLEND_TYPE.UI_OT_PRESET_BLEND_OPAQUE);
            var statRowLabel = new SprDefStruct1(0x3da, new FVector(174, yposBase + 355, 0), new FVector(1, 1, 0), new FSprColor(0xe, 0xe2, 0xf8, (byte)detailsAlpha),
                1, 0, 0, 0, 1, 1, 0);
            var nameBg = new SprDefStruct1(0x3db, new FVector(265, yposBase + 355 + 83, 0), new FVector(1, 1, 0), new FSprColor(0xe, 0xe2, 0xf8, (byte)detailsAlpha),
                1, 0, 0, 0, 1, 1, 0);
            var nameText = new SprDefStruct1(0x3dc, new FVector(265, yposBase + 355 + 83, 0), new FVector(1, 1, 0), new FSprColor(0x9, 0xf, 0x2e, (byte)detailsAlpha),
                1, 0, 0, 0, 1, 1, 0);
            var sexBg = new SprDefStruct1(0x3db, new FVector(265, yposBase + 355 + 133, 0), new FVector(1, 1, 0), new FSprColor(0xe, 0xe2, 0xf8, (byte)detailsAlpha),
                1, 0, 0, 0, 1, 1, 0);
            var sexText = new SprDefStruct1(0x3de, new FVector(265, yposBase + 355 + 133, 0), new FVector(1, 1, 0), new FSprColor(0x9, 0xf, 0x2e, (byte)detailsAlpha),
                1, 0, 0, 0, 1, 1, 0);
            var ageBg = new SprDefStruct1(0x3db, new FVector(265, yposBase + 355 + 183, 0), new FVector(1, 1, 0), new FSprColor(0xe, 0xe2, 0xf8, (byte)detailsAlpha),
                1, 0, 0, 0, 1, 1, 0);
            var ageText = new SprDefStruct1(0x3e0, new FVector(265, yposBase + 355 + 183, 0), new FVector(1, 1, 0), new FSprColor(0x9, 0xf, 0x2e, (byte)detailsAlpha),
                1, 0, 0, 0, 1, 1, 0);
            var occupyBg = new SprDefStruct1(0x3db, new FVector(265, yposBase + 355 + 233, 0), new FVector(1, 1, 0), new FSprColor(0xe, 0xe2, 0xf8, (byte)detailsAlpha),
                1, 0, 0, 0, 1, 1, 0);
            var occupyText = new SprDefStruct1(0x3e2, new FVector(265, yposBase + 355 + 233, 0), new FVector(1, 1, 0), new FSprColor(0x9, 0xf, 0x2e, (byte)detailsAlpha),
                1, 0, 0, 0, 1, 1, 0);
            var lastSight = new SprDefStruct1(0x3e4, new FVector(171, yposBase + 677, 0), new FVector(1, 1, 0), new FSprColor(0xe, 0xe2, 0xf8, (byte)detailsAlpha),
                1, 0, 0, 0, 1, 1, 0);
            var lastSightDot = new SprDefStruct1(0x3a3, new FVector(203, yposBase + 677 + 68, 0), new FVector(1, 1, 0), new FSprColor(0xff, 0xff, 0xff, (byte)detailsAlpha),
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

        }
        public unsafe FSprColor UUIMissingPerson_SelectedPersonLastSighted(FSprColor source) => ConfigColor.ToFSprColorWithAlpha(_context._config.MissingLastSighted, source.A);
        public unsafe FSprColor UUIMissingPerson_PageBackground(FSprColor source) => ConfigColor.ToFSprColorWithAlpha(_context._config.MissingPageBg, source.A);

        [Function(FunctionAttribute.Register.rax, FunctionAttribute.Register.rax, false)]
        public unsafe delegate FSprColor UUIMissingPerson_InjectColorAfterCtorCall(FSprColor source);
        public unsafe delegate void UUIMissingPerson_DrawLabelRow(UUIMissingPerson* self, nint masker);
        public unsafe delegate void UUIMissingPerson_DrawPersonEntry(UUIMissingPerson* self, nint masker, FVector* pos, FMissingEntry* entry, byte a5, float a6);
        public unsafe delegate byte UGlobalWork_CheckDisappearEntryValid(ushort id);
        public override void Register() 
        {
            _uiCommon = GetModule<UICommon>();
        }
    }
}
