using System.IO;
using p3rpc.femc.Configuration;

namespace p3rpc.femc.HexEditing
{
    public static class NamiWaves
    {
        public static void Apply(Config config, string modDirectory)
        {
            // filepath
            string filePath = Path.Combine(modDirectory,
    "UnrealEssentials", "P3R", "Content", "Xrd777",
    "UI", "Camp", "Param", "DT_CampParamCommon.uasset");

            // offset(s)
            (long Offset, HexColorEditor.ColorOrder Order)[] offsets =
            {
                // I THINK THESE ARE RIGHT PUHLEASE
                (0x2883, HexColorEditor.ColorOrder.BGRA), // NamiTopAColor
                (0x2944, HexColorEditor.ColorOrder.BGRA), // NamiTopBColor
                (0x2A05, HexColorEditor.ColorOrder.BGRA), // NamiSkillAColor
                (0x2AC6, HexColorEditor.ColorOrder.BGRA), // NamiSkillBColor
                (0x2B87, HexColorEditor.ColorOrder.BGRA), // NamiItemAColor
                (0x2C48, HexColorEditor.ColorOrder.BGRA), // NamiItemBColor
                (0x2D0B, HexColorEditor.ColorOrder.BGRA), // NamiEquipAColor
                (0x2DCA, HexColorEditor.ColorOrder.BGRA), // NamiEquipBColor
                // there's a jump here for some reason
                (0x2E8E, HexColorEditor.ColorOrder.BGRA), // NamiPersonaAColor
                (0x2F4F, HexColorEditor.ColorOrder.BGRA), // NamiPersonaBColor
                (0x3010, HexColorEditor.ColorOrder.BGRA), // NamiStatusAColor
                (0x30D1, HexColorEditor.ColorOrder.BGRA), // NamiStatusBColor
                (0x318F, HexColorEditor.ColorOrder.BGRA), // NamiQuestAColor
                (0x3250, HexColorEditor.ColorOrder.BGRA), // NamiQuestBColor
                (0x3311, HexColorEditor.ColorOrder.BGRA), // NamiCommuAColor
                (0x33D2, HexColorEditor.ColorOrder.BGRA), // NamiCommuBColor
                (0x3493, HexColorEditor.ColorOrder.BGRA), // NamiCalendarAColor
                (0x3554, HexColorEditor.ColorOrder.BGRA), // NamiCalendarBColor
                (0x3615, HexColorEditor.ColorOrder.BGRA), // NamiSystemAColor
                (0x36D6, HexColorEditor.ColorOrder.BGRA), // NamiSystemBColor
                (0x3797, HexColorEditor.ColorOrder.BGRA), // NamiTutorialAColor
                (0x3858, HexColorEditor.ColorOrder.BGRA), // NamiTutorialBColor
                (0x3919, HexColorEditor.ColorOrder.BGRA), // NamiConfigAColor
                (0x39DA, HexColorEditor.ColorOrder.BGRA), // NamiConfigBColor
            };

            //for single offset you can do

            //        // Offset inside the file where the colour should be placed.
            //        long offset = 0x10;

            // inject color
            //HexColorEditor.WriteColor(filePath, offset, config.ExampleHexEditColor);

            // Inject colors
            //foreach (var entry in offsets)
                //HexColorEditor.WriteColor(filePath, entry.Offset, config.NamiWavesEditColor, entry.Order);
                
        }
    }
}