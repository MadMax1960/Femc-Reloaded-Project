using p3rpc.commonmodutils;
using p3rpc.femc.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static p3rpc.femc.HexEditing.HexColorEditor;

namespace p3rpc.femc.HexEditing
{
    public static class Mail
    {
        private static void ApplyBPMailDraw(Config config, string modDirectory)
        {
            string filePath = Path.Combine(modDirectory,
                "UnrealEssentials", "P3R", "Content", "Xrd777",
                "Blueprints", "UI", "Mail", "BP_MailDraw.uasset");

            // MAIL FIRST ANIMATION //
            (long Offset, HexColorEditor.ColorOrder Order)[] offsets =
            {
                (0x24076, HexColorEditor.ColorOrder.BGRA),
                (0x23DD9, HexColorEditor.ColorOrder.BGRA),
                (0x23B3C, HexColorEditor.ColorOrder.BGRA),
                (0x238F4, HexColorEditor.ColorOrder.BGRA),
                (0x236C9, HexColorEditor.ColorOrder.BGRA),
                (0x2349E, HexColorEditor.ColorOrder.BGRA),
                (0x232EF, HexColorEditor.ColorOrder.BGRA),
                (0x2323E, HexColorEditor.ColorOrder.BGRA),
                (0x21EA1, HexColorEditor.ColorOrder.BGRA)
            };

            
            foreach (var entry in offsets)
                HexColorEditor.WriteColor(filePath, entry.Offset, config.MailStartAnimationColor, entry.Order); // Original color #001CC2

            // MAIL INITIAL SCREEN //
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1297D, config.MailSelectedSubjectColor, HexColorEditor.ColorOrder.BGR); // Original color #1B33FF
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x12E17, config.MailSelectedSubjectColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x1318E, config.MailSelectedSubjectColor, HexColorEditor.ColorOrder.BGR);

            // Special pattern since color components were directly used in the function params without prior declaration, byte pattern is 24 RR 24 GG 24 BB
            HexColorEditor.WriteByte(filePath, 0xA8A4, config.HighlightedSelectionColor.R); // Original color #0018FF
            HexColorEditor.WriteByte(filePath, 0xA8A6, config.HighlightedSelectionColor.G);
            HexColorEditor.WriteByte(filePath, 0xA8A8, config.HighlightedSelectionColor.B);


            // MAIL DETAIL //
            HexColorEditor.WriteColor(filePath, 0x25880, config.MailDetailTitleHighlightedColor, ColorOrder.BGRA); // Original color #1029FF
            HexColorEditor.WriteColor(filePath, 0x25966, config.MailDetailTitleHighlightedColor, ColorOrder.BGRA);
            HexColorEditor.WriteColor(filePath, 0x2630b, config.MailDetailTitleHighlightedColor, ColorOrder.BGRA);
            HexColorEditor.WriteColor(filePath, 0x26c8f, config.MailDetailTitleHighlightedColor, ColorOrder.BGRA);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xE8CF, config.MailDetailTitleHighlightedColor, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteColor(filePath, 0x258b5, config.MailDetailDarkTitleHighlightedColor, ColorOrder.BGRA); // Original color #081480
            HexColorEditor.WriteColor(filePath, 0x26340, config.MailDetailDarkTitleHighlightedColor, ColorOrder.BGRA);
            HexColorEditor.WriteColor(filePath, 0x26c5a, config.MailDetailDarkTitleHighlightedColor, ColorOrder.BGRA);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xC89A, config.MailRunningFigureColor, HexColorEditor.ColorOrder.BGR); // Original color #0011EA
            HexColorEditor.WriteColor(filePath, 0x26796, config.MailRunningFigureColor, ColorOrder.BGRA);
            HexColorEditor.WriteColor(filePath, 0x2687C, config.MailRunningFigureColor, ColorOrder.BGRA);
            HexColorEditor.WriteColor(filePath, 0x270E5, config.MailRunningFigureColor, ColorOrder.BGRA);
            HexColorEditor.WriteColor(filePath, 0x267CB, config.MailDarkRunningFigureColor, ColorOrder.BGRA); // Original color #00003F
            HexColorEditor.WriteColor(filePath, 0x270B0, config.MailDarkRunningFigureColor, ColorOrder.BGRA);

            HexColorEditor.WriteColor(filePath, 0x21EA1, config.MailDrawMainColor, ColorOrder.BGR);
            HexColorEditor.WriteColor(filePath, 0x2323E, config.MailDrawMainColor, ColorOrder.BGR);
            HexColorEditor.WriteColor(filePath, 0x232EF, config.MailDrawMainColor, ColorOrder.BGR);
            HexColorEditor.WriteColor(filePath, 0x2349E, config.MailDrawMainColor, ColorOrder.BGR);
            HexColorEditor.WriteColor(filePath, 0x236C9, config.MailDrawMainColor, ColorOrder.BGR);
            HexColorEditor.WriteColor(filePath, 0x238F4, config.MailDrawMainColor, ColorOrder.BGR);
            HexColorEditor.WriteColor(filePath, 0x23B3C, config.MailDrawMainColor, ColorOrder.BGR);
            HexColorEditor.WriteColor(filePath, 0x23DD9, config.MailDrawMainColor, ColorOrder.BGR);
            HexColorEditor.WriteColor(filePath, 0x24076, config.MailDrawMainColor, ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0xD003, config.MailDrawColor1, HexColorEditor.ColorOrder.BGR);

            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x13957, config.MailDrawColor2, HexColorEditor.ColorOrder.BGR);
            HexColorEditor.WriteBlueprintSplitColor(filePath, 0x13BA6, config.MailDrawColor2, HexColorEditor.ColorOrder.BGR);
        }

        public static void Apply(Config config, string modDirectory)
        {
            ApplyBPMailDraw(config, modDirectory);
        }
    }
}
