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
using static Reloaded.Hooks.Definitions.X64.FunctionAttribute;

namespace p3rpc.femc.Components
{
    public class TownMap : ModuleAsmInlineColorEdit<FemcContext>
    {
        // In AUITownMapActor::DrawTownMapUIInner
        private string AUITownMapActor_TownMapTextColor_SIG = "48 8D 54 24 ?? 89 44 24 ?? 48 8D 8F ?? ?? ?? ?? E8 ?? ?? ?? ??";
        private string AUITownMapActor_TownMapBorderColor_SIG = "48 8D 54 24 ?? 89 44 24 ?? 48 8D 8F ?? ?? ?? ?? 89 45 ??";
        private string FTownMapMarker2_UpdateState_SIG = "48 89 5C 24 ?? 57 48 83 EC 50 48 8D B9 ?? ?? ?? ??";

        private string AUITownMapActor_LocationDetailsTintColor_SIG = "41 B1 FF 89 85 ?? ?? ?? ?? 45 0F B6 C1 41 0F B6 D1";
        private string AUITownMapActor_LocationDetailsTopLeft_SIG = "41 B1 FF 89 85 ?? ?? ?? ?? 41 B0 EC";
        private string AUITownMapActor_LocationDetailsLowerBand_SIG = "F3 0F 10 1D ?? ?? ?? ?? 48 8D 8D ?? ?? ?? ?? F3 0F 10 15 ?? ?? ?? ?? 49 8B D6 89 85 ?? ?? ?? ??";
        private string AUITownMapActor_LocationDetailsText_SIG = "48 8D 54 24 ?? 89 85 ?? ?? ?? ?? 48 8D 8E ?? ?? ?? ??";

        private string AUITownMap_LocationSubtleShadow_SIG = "E8 ?? ?? ?? ?? 41 B1 FF 89 83 ?? ?? ?? ?? 41 B0 FE";
        private string AUITownMap_LocationRoundedOutline_SIG = "E8 ?? ?? ?? ?? B2 96 89 83 ?? ?? ?? ??";
        private string AUITownMap_LocationPreviewTaint_SIG = "E8 ?? ?? ?? ?? 89 83 ?? ?? ?? ?? 83 FF 05";
        private string AUITownMap_LocationMiniIndicator_SIG = "E8 ?? ?? ?? ?? 45 33 C9 89 87 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ??";
        private string AUITownMap_LocationMiniIndicatorSubtleShadow_SIG = "E8 ?? ?? ?? ?? 41 B1 4C";

        private string AUITownMap_LocationDetailsArrows_SIG = "E8 ?? ?? ?? ?? 48 8D 4E ?? 89 44 24 ?? E8";
        private string AUITownMap_LocationDetailsGenericIconColor_SIG = "B1 60 E8 ?? ?? ?? ?? 89 85";

        private string AUITownMap_SocialLinksTitle_SIG = "E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 0F 57 F6 89 85";
        private string AUITownMap_SocialLinkName_SIG = "E8 ?? ?? ?? ?? F2 0F 10 44 24 ?? 41 B0 FF";
        private string AUITownMap_SocialLinkCard_SIG = "E8 ?? ?? ?? ?? F2 0F 10 44 24 ?? 33 C9";
        private string AUITownMap_SocialLinkRankUpCard1_SIG = "E8 ?? ?? ?? ?? C7 85 ?? ?? ?? ?? 0A D7 63 3F";
        private string AUITownMap_SocialLinkRankUpCard2_SIG = "E8 ?? ?? ?? ?? BA 02 00 00 00 89 85";
        private string AUITownMap_SocialLinkRankUpGlow_SIG = "E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 45 0F 28 CB F3 44 0F 10 05 ?? ?? ?? ?? 89 45";
        private string AUITownMap_SocialLinkEpisodeLogo_SIG = "E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ?? 48 8D 4D ?? 0F 28 0D ?? ?? ?? ?? BA 05 00 00 00 0F 29 45 ?? 0F 28 05 ?? ?? ?? ?? 0F 29 4D ?? 0F 28 0D ?? ?? ?? ?? 89 45 ?? 8B 44 24 ?? 0F 29 45 ?? 0F 29 4D 00 4C 89 65 ?? 48 C7 45 ?? 00 00 00 00 F2 44 0F 11 5D ?? 89 45 ?? 48 C7 45 ?? 00 00 80 3F 44 89 65 ?? 48 C7 44 24 ?? 00 00 00 00 C7 44 24 ?? 00 00 00 00 C7 44 24 ?? FF FF FF FF C7 45 ?? 00 00 80 3F 48 C7 45 ?? 00 00 00 00 C7 45 ?? 00 00 00 00 E8 ?? ?? ?? ?? 8B 55 ?? 8D 42 ?? 89 45 ?? 3B 45 ?? 7E ?? 48 8D 4D ?? E8 ?? ?? ?? ?? 48 8B 4D ?? F2 0F 10 05 ?? ?? ?? ?? F2 0F 11 01 0F B7 05 ?? ?? ?? ?? 66 89 41 ?? 48 8B 8E ?? ?? ?? ?? 44 89 65 ?? C6 45 ?? 01 8B 44 ?? ?? 85 C0 44 8D 70 ?? 45 0F 44 F4 45 85 F6 75 ?? 44 89 65 ?? 44 39 75 ?? 0F 84 ?? ?? ?? ?? 33 D2 48 8D 4D ?? E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 4C ?? ?? 44 8B 7D ?? 48 89 4D ?? 45 85 FF 74 ?? 41 FF CF EB ?? 45 8B FC 45 8D 66 ?? 45 3B F7 0F 8F ?? ?? ?? ?? 48 8B 7D ?? 48 8B D1 49 63 C6 48 8B CF 48 8D 1C ?? 4C 8B C3 E8 ?? ?? ?? ?? 33 C9 66 89 0C ?? 45 2B FE 74 ?? 8B 45 ?? 8B C8 41 2B CC 41 2B CF 74 ?? 4C 8B 4D ?? 43 8D 04 ?? 4C 63 C1 48 63 C8 4D 03 C0 49 63 C4 49 8D 14 ?? 49 8D 0C ?? E8 ?? ?? ?? ?? 8B 45 ?? 41 2B C7 48 8D 4D ?? 89 45 ?? E8 ?? ?? ?? ?? 45 33 E4 48 8B 5C 24 ?? 8B 7C 24 ?? 4C 8B 7C 24 ?? 44 8B 75 ?? 41 B0 FF 41 0F B6 D0 45 0F B6 CE B1 11 E8 ?? ?? ?? ?? 4C 8B 86 ?? ?? ?? ?? 48 8D 4D ?? 0F 28 DF F3 0F 11 74 24 ?? 49 8B D7 89 44 24 ?? E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 45 0F 57 C0 45 0F 57 C9 48 85 C9 74 ?? BA 04 00 00 00 E8 ?? ?? ?? ?? 48 85 C0 74 ?? F3 44 0F 10 40 ?? F3 44 0F 10 48 ?? C7 44 24 ?? FF FF FF FF 48 8D 4C 24 ?? 41 0F 28 CC C6 44 24 ?? 01 0F 28 C7 F3 0F 58 CE F3 41 0F 58 C5 41 0F 28 D9 41 0F 28 D0 49 8B D7 F3 0F 11 4C 24 ?? F3 0F 11 44 24 ?? E8 ?? ?? ?? ?? 41 8D 45 ?? 83 F8 04 7C ?? 41 0F 28 F6 F3 41 0F 58 FF EB ?? 33 C9 8B D1 89 4D ?? 8B 4D ?? 41 3B CC 74 ?? 41 8B D4 48 8D 4D ?? E8 ?? ?? ?? ?? 8B 4D ?? 8B 55 ?? 41 8D 46 ?? 03 C2 89 45 ?? 3B C1 7E ?? 48 8D 4D ?? E8 ?? ?? ?? ?? 48 8B 7D ?? 48 8B 55 ?? 48 8B CF 49 63 C6 48 8D 1C ?? 4C 8B C3 E8 ?? ?? ?? ?? 45 33 E4 66 44 89 24 ?? E9 ?? ?? ?? ?? F3 0F 58 35 ?? ?? ?? ?? 48 8B 4D ?? 45 8B EC 44 0F 4C E8 48 85 C9 74 ?? E8 ?? ?? ?? ?? FF C7 48 83 C3 18 89 7C 24 ?? 48 89 5C 24 ?? 3B BE ?? ?? ?? ?? 0F 8C ?? ?? ?? ?? 83 BE ?? ?? ?? ?? 00 41 8B FC 44 89 64 24 ?? 0F 8E ?? ?? ?? ?? 49 8B DC C7 44 24 ?? 00 00 70 44 48 C7 44 24 ?? 00 00 07 44 F2 44 0F 10 54 24 ?? C7 44 24 ?? 00 00 70 44 48 C7 44 24 ?? 00 00 07 44 F2 44 0F 10 5C 24 ?? 48 89 5C 24 ?? 66 90 8B 44 24 ?? 41 B0 FF 0F 57 C0 F2 44 0F 11 95 ?? ?? ?? ?? 41 0F B6 D0 89 85 ?? ?? ?? ?? 45 0F B6 CE 48 C7 85 ?? ?? ?? ?? 00 00 80 3F B1 11 66 0F 7F 85 ?? ?? ?? ?? 48 C7 45 ?? 00 00 00 00 C7 45 ?? 00 00 00 00 C7 45 ?? 00 00 80 3F C7 45 ?? 00 00 80 3F C7 45 ?? 00 00 00 00 C7 45 ?? FF FF FF FF 48 C7 85 ?? ?? ?? ?? 00 00 80 3F 48 C7 85 ?? ?? ?? ?? 00 00 00 00 C7 85 ?? ?? ?? ?? 00 00 80 3F 44 89 A5 ?? ?? ?? ?? C7 45 ?? 00 00 80 3F 44 89 A5 ?? ?? ?? ?? C7 85 ?? ?? ?? ?? 4F 00 00 00";
        private string AUITownMap_SocialLinkEpisodeName_SIG = "E8 ?? ?? ?? ?? 4C 8B 86 ?? ?? ?? ?? 48 8D 4D ?? 0F 28 DF F3 0F 11 74 24 ?? 49 8B D7 89 44 24 ?? E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 45 0F 57 C0 45 0F 57 C9 48 85 C9 74 ?? BA 04 00 00 00 E8 ?? ?? ?? ?? 48 85 C0 74 ?? F3 44 0F 10 40 ?? F3 44 0F 10 48 ?? C7 44 24 ?? FF FF FF FF 48 8D 4C 24 ?? 41 0F 28 CC C6 44 24 ?? 01 0F 28 C7 F3 0F 58 CE F3 41 0F 58 C5 41 0F 28 D9 41 0F 28 D0 49 8B D7 F3 0F 11 4C 24 ?? F3 0F 11 44 24 ?? E8 ?? ?? ?? ?? 41 8D 45 ?? 83 F8 04 7C ?? 41 0F 28 F6 F3 41 0F 58 FF EB ?? 33 C9 8B D1 89 4D ?? 8B 4D ?? 41 3B CC 74 ?? 41 8B D4 48 8D 4D ?? E8 ?? ?? ?? ?? 8B 4D ?? 8B 55 ?? 41 8D 46 ?? 03 C2 89 45 ?? 3B C1 7E ?? 48 8D 4D ?? E8 ?? ?? ?? ?? 48 8B 7D ?? 48 8B 55 ?? 48 8B CF 49 63 C6 48 8D 1C ?? 4C 8B C3 E8 ?? ?? ?? ?? 45 33 E4 66 44 89 24 ?? E9 ?? ?? ?? ?? F3 0F 58 35 ?? ?? ?? ?? 48 8B 4D ?? 45 8B EC 44 0F 4C E8 48 85 C9 74 ?? E8 ?? ?? ?? ?? FF C7 48 83 C3 18 89 7C 24 ?? 48 89 5C 24 ?? 3B BE ?? ?? ?? ?? 0F 8C ?? ?? ?? ?? 83 BE ?? ?? ?? ?? 00 41 8B FC 44 89 64 24 ?? 0F 8E ?? ?? ?? ?? 49 8B DC C7 44 24 ?? 00 00 70 44 48 C7 44 24 ?? 00 00 07 44 F2 44 0F 10 54 24 ?? C7 44 24 ?? 00 00 70 44 48 C7 44 24 ?? 00 00 07 44 F2 44 0F 10 5C 24 ?? 48 89 5C 24 ?? 66 90 8B 44 24 ?? 41 B0 FF 0F 57 C0 F2 44 0F 11 95 ?? ?? ?? ?? 41 0F B6 D0 89 85 ?? ?? ?? ?? 45 0F B6 CE 48 C7 85 ?? ?? ?? ?? 00 00 80 3F B1 11 66 0F 7F 85 ?? ?? ?? ?? 48 C7 45 ?? 00 00 00 00 C7 45 ?? 00 00 00 00 C7 45 ?? 00 00 80 3F C7 45 ?? 00 00 80 3F C7 45 ?? 00 00 00 00 C7 45 ?? FF FF FF FF 48 C7 85 ?? ?? ?? ?? 00 00 80 3F 48 C7 85 ?? ?? ?? ?? 00 00 00 00 C7 85 ?? ?? ?? ?? 00 00 80 3F 44 89 A5 ?? ?? ?? ?? C7 45 ?? 00 00 80 3F 44 89 A5 ?? ?? ?? ?? C7 85 ?? ?? ?? ?? 4F 00 00 00";
        private string AUITownMap_SocialLinkHangoutLogo_SIG = "E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ?? 48 8D 4D ?? 0F 28 0D ?? ?? ?? ?? BA 05 00 00 00 0F 29 45 ?? 0F 28 05 ?? ?? ?? ?? 0F 29 4D ?? 0F 28 0D ?? ?? ?? ?? 89 45 ?? 8B 44 24 ?? 0F 29 45 ?? 0F 29 4D 00 4C 89 65 ?? 48 C7 45 ?? 00 00 00 00 F2 44 0F 11 5D ?? 89 45 ?? 48 C7 45 ?? 00 00 80 3F 44 89 65 ?? 48 C7 44 24 ?? 00 00 00 00 C7 44 24 ?? 00 00 00 00 C7 44 24 ?? FF FF FF FF C7 45 ?? 00 00 80 3F 48 C7 45 ?? 00 00 00 00 C7 45 ?? 00 00 00 00 E8 ?? ?? ?? ?? 8B 55 ?? 8D 42 ?? 89 45 ?? 3B 45 ?? 7E ?? 48 8D 4D ?? E8 ?? ?? ?? ?? 48 8B 4D ?? F2 0F 10 05 ?? ?? ?? ?? F2 0F 11 01 0F B7 05 ?? ?? ?? ?? 66 89 41 ?? 48 8B 8E ?? ?? ?? ?? 44 89 65 ?? C6 45 ?? 01 8B 44 ?? ?? 85 C0 44 8D 70 ?? 45 0F 44 F4 45 85 F6 75 ?? 44 89 65 ?? 44 39 75 ?? 0F 84 ?? ?? ?? ?? 33 D2 48 8D 4D ?? E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 4C ?? ?? 44 8B 7D ?? 48 89 4D ?? 45 85 FF 74 ?? 41 FF CF EB ?? 45 8B FC 45 8D 66 ?? 45 3B F7 0F 8F ?? ?? ?? ?? 48 8B 7D ?? 48 8B D1 49 63 C6 48 8B CF 48 8D 1C ?? 4C 8B C3 E8 ?? ?? ?? ?? 33 C9 66 89 0C ?? 45 2B FE 74 ?? 8B 45 ?? 8B C8 41 2B CC 41 2B CF 74 ?? 4C 8B 4D ?? 43 8D 04 ?? 4C 63 C1 48 63 C8 4D 03 C0 49 63 C4 49 8D 14 ?? 49 8D 0C ?? E8 ?? ?? ?? ?? 8B 45 ?? 41 2B C7 48 8D 4D ?? 89 45 ?? E8 ?? ?? ?? ?? 45 33 E4 48 8B 5C 24 ?? 8B 7C 24 ?? 4C 8B 7C 24 ?? 44 8B 75 ?? 41 B0 FF 41 0F B6 D0 45 0F B6 CE B1 11 E8 ?? ?? ?? ?? 4C 8B 86 ?? ?? ?? ?? 48 8D 4D ?? 0F 28 DF F3 0F 11 74 24 ?? 49 8B D7 89 44 24 ?? E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 45 0F 57 C0 45 0F 57 C9 48 85 C9 74 ?? BA 04 00 00 00 E8 ?? ?? ?? ?? 48 85 C0 74 ?? F3 44 0F 10 40 ?? F3 44 0F 10 48 ?? C7 44 24 ?? FF FF FF FF 48 8D 4C 24 ?? 41 0F 28 CC C6 44 24 ?? 01 0F 28 C7 F3 0F 58 CE F3 41 0F 58 C5 41 0F 28 D9 41 0F 28 D0 49 8B D7 F3 0F 11 4C 24 ?? F3 0F 11 44 24 ?? E8 ?? ?? ?? ?? 41 8D 45 ?? 83 F8 04 7C ?? 41 0F 28 F6 F3 41 0F 58 FF EB ?? 33 C9 8B D1 89 4D ?? 8B 4D ?? 41 3B CC 74 ?? 41 8B D4 48 8D 4D ?? E8 ?? ?? ?? ?? 8B 4D ?? 8B 55 ?? 41 8D 46 ?? 03 C2 89 45 ?? 3B C1 7E ?? 48 8D 4D ?? E8 ?? ?? ?? ?? 48 8B 7D ?? 48 8B 55 ?? 48 8B CF 49 63 C6 48 8D 1C ?? 4C 8B C3 E8 ?? ?? ?? ?? 45 33 E4 66 44 89 24 ?? E9 ?? ?? ?? ?? F3 0F 58 35 ?? ?? ?? ?? 48 8B 4D ?? 45 8B EC 44 0F 4C E8 48 85 C9 74 ?? E8 ?? ?? ?? ?? FF C7 48 83 C3 18 89 7C 24 ?? 48 89 5C 24 ?? 3B BE ?? ?? ?? ?? 0F 8C ?? ?? ?? ?? 83 BE ?? ?? ?? ?? 00 41 8B FC 44 89 64 24 ?? 0F 8E ?? ?? ?? ?? 49 8B DC C7 44 24 ?? 00 00 70 44 48 C7 44 24 ?? 00 00 07 44 F2 44 0F 10 54 24 ?? C7 44 24 ?? 00 00 70 44 48 C7 44 24 ?? 00 00 07 44 F2 44 0F 10 5C 24 ?? 48 89 5C 24 ?? 66 90 8B 44 24 ?? 41 B0 FF 0F 57 C0 F2 44 0F 11 95 ?? ?? ?? ?? 41 0F B6 D0 89 85 ?? ?? ?? ?? 45 0F B6 CE 48 C7 85 ?? ?? ?? ?? 00 00 80 3F B1 11 66 0F 7F 85 ?? ?? ?? ?? 48 C7 45 ?? 00 00 00 00 C7 45 ?? 00 00 00 00 C7 45 ?? 00 00 80 3F C7 45 ?? 00 00 80 3F C7 45 ?? 00 00 00 00 C7 45 ?? FF FF FF FF 48 C7 85 ?? ?? ?? ?? 00 00 80 3F 48 C7 85 ?? ?? ?? ?? 00 00 00 00 C7 85 ?? ?? ?? ?? 00 00 80 3F 44 89 A5 ?? ?? ?? ?? C7 45 ?? 00 00 80 3F 44 89 A5 ?? ?? ?? ?? C7 85 ?? ?? ?? ?? 50 00 00 00";
        private string AUITownMap_SocialLinkHangoutName_SIG = "E8 ?? ?? ?? ?? 4C 8B 86 ?? ?? ?? ?? 48 8D 4D ?? 0F 28 DF F3 0F 11 74 24 ?? 49 8B D7 89 44 24 ?? E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 45 0F 57 C0 45 0F 57 C9 48 85 C9 74 ?? BA 04 00 00 00 E8 ?? ?? ?? ?? 48 85 C0 74 ?? F3 44 0F 10 40 ?? F3 44 0F 10 48 ?? C7 44 24 ?? FF FF FF FF 48 8D 4C 24 ?? 41 0F 28 CC C6 44 24 ?? 01 0F 28 C7 F3 0F 58 CE F3 41 0F 58 C5 41 0F 28 D9 41 0F 28 D0 49 8B D7 F3 0F 11 4C 24 ?? F3 0F 11 44 24 ?? E8 ?? ?? ?? ?? 41 8D 45 ?? 83 F8 04 7C ?? 41 0F 28 F6 F3 41 0F 58 FF EB ?? 33 C9 8B D1 89 4D ?? 8B 4D ?? 41 3B CC 74 ?? 41 8B D4 48 8D 4D ?? E8 ?? ?? ?? ?? 8B 4D ?? 8B 55 ?? 41 8D 46 ?? 03 C2 89 45 ?? 3B C1 7E ?? 48 8D 4D ?? E8 ?? ?? ?? ?? 48 8B 7D ?? 48 8B 55 ?? 48 8B CF 49 63 C6 48 8D 1C ?? 4C 8B C3 E8 ?? ?? ?? ?? 45 33 E4 66 44 89 24 ?? E9 ?? ?? ?? ?? F3 0F 58 35 ?? ?? ?? ?? 48 8B 4D ?? 45 8B EC 44 0F 4C E8 48 85 C9 74 ?? E8 ?? ?? ?? ?? FF C7 48 83 C3 18 89 7C 24 ?? 48 89 5C 24 ?? 3B BE ?? ?? ?? ?? 0F 8C ?? ?? ?? ?? 83 BE ?? ?? ?? ?? 00 41 8B FC 44 89 64 24 ?? 0F 8E ?? ?? ?? ?? 49 8B DC C7 44 24 ?? 00 00 70 44 48 C7 44 24 ?? 00 00 07 44 F2 44 0F 10 54 24 ?? C7 44 24 ?? 00 00 70 44 48 C7 44 24 ?? 00 00 07 44 F2 44 0F 10 5C 24 ?? 48 89 5C 24 ?? 66 90 8B 44 24 ?? 41 B0 FF 0F 57 C0 F2 44 0F 11 95 ?? ?? ?? ?? 41 0F B6 D0 89 85 ?? ?? ?? ?? 45 0F B6 CE 48 C7 85 ?? ?? ?? ?? 00 00 80 3F B1 11 66 0F 7F 85 ?? ?? ?? ?? 48 C7 45 ?? 00 00 00 00 C7 45 ?? 00 00 00 00 C7 45 ?? 00 00 80 3F C7 45 ?? 00 00 80 3F C7 45 ?? 00 00 00 00 C7 45 ?? FF FF FF FF 48 C7 85 ?? ?? ?? ?? 00 00 80 3F 48 C7 85 ?? ?? ?? ?? 00 00 00 00 C7 85 ?? ?? ?? ?? 00 00 80 3F 44 89 A5 ?? ?? ?? ?? C7 45 ?? 00 00 80 3F 44 89 A5 ?? ?? ?? ?? C7 85 ?? ?? ?? ?? 50 00 00 00";
        private string AUITownMap_SocialLinkKoroLogo_SIG = "E8 ?? ?? ?? ?? 0F 28 05 ?? ?? ?? ?? 48 8D 4D ?? 0F 28 0D ?? ?? ?? ?? BA 05 00 00 00 0F 29 45 ?? 0F 28 05 ?? ?? ?? ?? 0F 29 4D ?? 0F 28 0D ?? ?? ?? ?? 89 45 ?? 8B 44 24 ?? 0F 29 45 ?? 0F 29 4D 00 4C 89 65 ?? 48 C7 45 ?? 00 00 00 00 F2 44 0F 11 5D ?? 89 45 ?? 48 C7 45 ?? 00 00 80 3F 44 89 65 ?? 48 C7 44 24 ?? 00 00 00 00 C7 44 24 ?? 00 00 00 00 C7 44 24 ?? FF FF FF FF C7 45 ?? 00 00 80 3F 48 C7 45 ?? 00 00 00 00 C7 45 ?? 00 00 00 00 E8 ?? ?? ?? ?? 8B 55 ?? 8D 42 ?? 89 45 ?? 3B 45 ?? 7E ?? 48 8D 4D ?? E8 ?? ?? ?? ?? 48 8B 4D ?? F2 0F 10 05 ?? ?? ?? ?? F2 0F 11 01 0F B7 05 ?? ?? ?? ?? 66 89 41 ?? 48 8B 8E ?? ?? ?? ?? 44 89 65 ?? C6 45 ?? 01 8B 44 ?? ?? 85 C0 44 8D 70 ?? 45 0F 44 F4 45 85 F6 75 ?? 44 89 65 ?? 44 39 75 ?? 0F 84 ?? ?? ?? ?? 33 D2 48 8D 4D ?? E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 4C ?? ?? 44 8B 7D ?? 48 89 4D ?? 45 85 FF 74 ?? 41 FF CF EB ?? 45 8B FC 45 8D 66 ?? 45 3B F7 0F 8F ?? ?? ?? ?? 48 8B 7D ?? 48 8B D1 49 63 C6 48 8B CF 48 8D 1C ?? 4C 8B C3 E8 ?? ?? ?? ?? 33 C9 66 89 0C ?? 45 2B FE 74 ?? 8B 45 ?? 8B C8 41 2B CC 41 2B CF 74 ?? 4C 8B 4D ?? 43 8D 04 ?? 4C 63 C1 48 63 C8 4D 03 C0 49 63 C4 49 8D 14 ?? 49 8D 0C ?? E8 ?? ?? ?? ?? 8B 45 ?? 41 2B C7 48 8D 4D ?? 89 45 ?? E8 ?? ?? ?? ?? 45 33 E4 48 8B 5C 24 ?? 8B 7C 24 ?? 4C 8B 7C 24 ?? 44 8B 75 ?? 41 B0 FF 41 0F B6 D0 45 0F B6 CE B1 11 E8 ?? ?? ?? ?? 4C 8B 86 ?? ?? ?? ?? 48 8D 4D ?? 0F 28 DF F3 0F 11 74 24 ?? 49 8B D7 89 44 24 ?? E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 45 0F 57 C0 45 0F 57 C9 48 85 C9 74 ?? BA 04 00 00 00 E8 ?? ?? ?? ?? 48 85 C0 74 ?? F3 44 0F 10 40 ?? F3 44 0F 10 48 ?? C7 44 24 ?? FF FF FF FF 48 8D 4C 24 ?? 41 0F 28 CC C6 44 24 ?? 01 0F 28 C7 F3 0F 58 CE F3 41 0F 58 C5 41 0F 28 D9 41 0F 28 D0 49 8B D7 F3 0F 11 4C 24 ?? F3 0F 11 44 24 ?? E8 ?? ?? ?? ?? 41 8D 45 ?? 83 F8 04 7C ?? 41 0F 28 F6 F3 41 0F 58 FF EB ?? 33 C9 8B D1 89 4D ?? 8B 4D ?? 41 3B CC 74 ?? 41 8B D4 48 8D 4D ?? E8 ?? ?? ?? ?? 8B 4D ?? 8B 55 ?? 8D 42";
        private string AUITownMap_SocialLinkKoroName_SIG = "E8 ?? ?? ?? ?? 4C 8B 86 ?? ?? ?? ?? 48 8D 4D ?? 0F 28 DF F3 0F 11 74 24 ?? 49 8B D7 89 44 24 ?? E8 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 45 0F 57 C0 45 0F 57 C9 48 85 C9 74 ?? BA 04 00 00 00 E8 ?? ?? ?? ?? 48 85 C0 74 ?? F3 44 0F 10 40 ?? F3 44 0F 10 48 ?? C7 44 24 ?? FF FF FF FF 48 8D 4C 24 ?? 41 0F 28 CC C6 44 24 ?? 01 0F 28 C7 F3 0F 58 CE F3 41 0F 58 C5 41 0F 28 D9 41 0F 28 D0 49 8B D7 F3 0F 11 4C 24 ?? F3 0F 11 44 24 ?? E8 ?? ?? ?? ?? 41 8D 45 ?? 83 F8 04 7C ?? 41 0F 28 F6 F3 41 0F 58 FF EB ?? 33 C9 8B D1 89 4D ?? 8B 4D ?? 41 3B CC 74 ?? 41 8B D4 48 8D 4D ?? E8 ?? ?? ?? ?? 8B 4D ?? 8B 55 ?? 8D 42";
        private UICommon _uiCommon;

        private IAsmHook _townMapTextColor;
        private IAsmHook _townMapBorderColor;

        private IAsmHook _bgTintColor;
        private IAsmHook _topLeftColor;
        private IAsmHook _lowerBand;
        private IAsmHook _detailsText;
        private IAsmHook _locationSubtleShadow;
        private IAsmHook _locationRoundedOutline;
        private IAsmHook _locationPreviewTaint;
        private IAsmHook _locationMiniIndicator;
        private IAsmHook _locationMiniIndicatorSubtleShadow;
        private IAsmHook _locationDetailsArrows;
        private IAsmHook _socialLinksTitle;
        private IAsmHook _socialLinkName;
        private IAsmHook _socialLinkCard;
        private IAsmHook _socialLinkRankUpCard1;
        private IAsmHook _socialLinkRankUpCard2;
        private IAsmHook _socialLinkRankUpGlow;
        private IAsmHook _socialLinkEpisodeLogo;
        private IAsmHook _socialLinkEpisodeName;
        private IAsmHook _socialLinkHangoutLogo;
        private IAsmHook _socialLinkHangoutName;
        private IAsmHook _socialLinkKoroLogo;
        private IAsmHook _socialLinkKoroName;

        private IReverseWrapper<AUITownMapActor_TownMapSetUICompColor> _townMapTextColorWrapper;
        private IReverseWrapper<AUITownMapActor_TownMapSetUICompColor> _townMapBorderColorWrapper;

        private IReverseWrapper<AUITownMapActor_InjectColorAfterCtor> _bgTintColorWrapper;
        private IReverseWrapper<AUITownMapActor_InjectColorAfterCtor> _topLeftColorWrapper;
        private IReverseWrapper<AUITownMapActor_InjectColorAfterCtor> _lowerBandWrapper;
        private IReverseWrapper<AUITownMapActor_InjectColorAfterCtor> _detailsTextWrapper;

        private IHook<FTownMapMarker2_UpdateState> _townMapMarkerUpdateState;

        public unsafe TownMap(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(AUITownMapActor_TownMapTextColor_SIG, "AUITownMapActor::TownMapTextColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUITownMapActor_TownMapTextColorImpl, out _townMapTextColorWrapper)}",
                };
                _townMapTextColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMapActor_TownMapBorderColor_SIG, "AUITownMapActor::TownMapTextColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUITownMapActor_TownMapBorderColorImpl, out _townMapBorderColorWrapper)}",
                };
                _townMapBorderColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(FTownMapMarker2_UpdateState_SIG, "FTownMapMarker2::UpdateState", _context._utils.GetDirectAddress, addr => _townMapMarkerUpdateState = _context._utils.MakeHooker<FTownMapMarker2_UpdateState>(FTownMapMarker2_UpdateStateImpl, addr));
            _context._utils.SigScan(AUITownMapActor_LocationDetailsTintColor_SIG, "AUITownMapActor::LocationDetailsTintColor", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUITownMapActor_LocationDetailsTintColorImpl, out _bgTintColorWrapper)}",
                };
                _bgTintColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMapActor_LocationDetailsTopLeft_SIG, "AUITownMapActor::LocationDetailsTopLeft", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUITownmapActor_LocationDetailsTopLeftTextImpl, out _topLeftColorWrapper)}",
                };
                _topLeftColor = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMapActor_LocationDetailsLowerBand_SIG, "AUITownMapActor::LocationDetailsLowerBand", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUITownmapActor_LocationDetailsTopLeftBgImpl, out _lowerBandWrapper)}",
                };
                _lowerBand = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMapActor_LocationDetailsText_SIG, "AUITownMapActor::LocationDetailsText", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"{_context._hooks.Utilities.GetAbsoluteCallMnemonics(AUITownmapActor_LocationDetailsTopLeftTextImpl, out _detailsTextWrapper)}",
                };
                _detailsText = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUITownMap_LocationSubtleShadow_SIG, "AUITownMap::LocationSubtleShadow", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.LocationSubtleShadowColor.B:X}",
                    $"mov dl, ${_context._config.LocationSubtleShadowColor.G:X}",
                    $"mov cl, ${_context._config.LocationSubtleShadowColor.R:X}"
                };
                _locationSubtleShadow = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMap_LocationRoundedOutline_SIG, "AUITownMap::LocationRoundedOutline", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.PreviewRoundedOutline.B:X}",
                    $"mov dl, ${_context._config.PreviewRoundedOutline.G:X}",
                    $"mov cl, ${_context._config.PreviewRoundedOutline.R:X}"
                };
                _locationRoundedOutline = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMap_LocationPreviewTaint_SIG, "AUITownMap::LocationPreviewTaint", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.PreviewTaintColor.B:X}",
                    $"mov dl, ${_context._config.PreviewTaintColor.G:X}",
                    $"mov cl, ${_context._config.PreviewTaintColor.R:X}"
                };
                _locationPreviewTaint = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMap_LocationMiniIndicator_SIG, "AUITownMap::LocationMiniIndicator", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.MiniLocationCircleColor.B:X}",
                    $"mov dl, ${_context._config.MiniLocationCircleColor.G:X}",
                    $"mov cl, ${_context._config.MiniLocationCircleColor.R:X}"
                };
                _locationMiniIndicator = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMap_LocationMiniIndicatorSubtleShadow_SIG, "AUITownMap::LocationMiniIndicatorSubtleShadow", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.LocationSubtleShadowColor.B:X}",
                    $"mov dl, ${_context._config.LocationSubtleShadowColor.G:X}",
                    $"mov cl, ${_context._config.LocationSubtleShadowColor.R:X}"
                };
                _locationMiniIndicatorSubtleShadow = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
            _context._utils.SigScan(AUITownMap_LocationDetailsArrows_SIG, "AUITownMap::LocationDetailsArrows", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.TownMapHighlightedArrows.B:X}",
                    $"mov dl, ${_context._config.TownMapHighlightedArrows.G:X}",
                    $"mov cl, ${_context._config.TownMapHighlightedArrows.R:X}"
                };
                _locationDetailsArrows = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            // Unharcodes blue component being 0x60, this makes the icon render with the full sprite, unaltered colors
            _context._utils.SigScan(AUITownMap_LocationDetailsGenericIconColor_SIG, "AUITownMap::LocationDetailsGenericIconColor", _context._utils.GetDirectAddress, addr =>
            {
                _asmMemWrites.Add(new AddressToMemoryWrite(_context._memory, (nuint)addr, addr => _context._memory.Write(addr + 1, (byte) 0xff)));
            });

            _context._utils.SigScan(AUITownMap_SocialLinksTitle_SIG, "AUITownMap::SocialLinksTitle", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.TownMapNamesColor.B:X}",
                    $"mov dl, ${_context._config.TownMapNamesColor.G:X}",
                    $"mov cl, ${_context._config.TownMapNamesColor.R:X}"
                };
                _socialLinksTitle = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUITownMap_SocialLinkName_SIG, "AUITownMap::SocialLinkName", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.TownMapNamesColor.B:X}",
                    $"mov dl, ${_context._config.TownMapNamesColor.G:X}",
                    $"mov cl, ${_context._config.TownMapNamesColor.R:X}"
                };
                _socialLinkName = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUITownMap_SocialLinkCard_SIG, "AUITownMap::SocialLinkCard", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.TownMapLogosColor.B:X}",
                    $"mov dl, ${_context._config.TownMapLogosColor.G:X}",
                    $"mov cl, ${_context._config.TownMapLogosColor.R:X}"
                };
                _socialLinkCard = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUITownMap_SocialLinkRankUpCard1_SIG, "AUITownMap::SocialLinkRankUpCard1", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.TownMapSLRankUpCard1.B:X}",
                    $"mov dl, ${_context._config.TownMapSLRankUpCard1.G:X}",
                    $"mov cl, ${_context._config.TownMapSLRankUpCard1.R:X}"
                };
                _socialLinkRankUpCard1 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUITownMap_SocialLinkRankUpCard2_SIG, "AUITownMap::SocialLinkRankUpCard2", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.TownMapSLRankUpCard2.B:X}",
                    $"mov dl, ${_context._config.TownMapSLRankUpCard2.G:X}",
                    $"mov cl, ${_context._config.TownMapSLRankUpCard2.R:X}"
                };
                _socialLinkRankUpCard2 = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUITownMap_SocialLinkRankUpGlow_SIG, "AUITownMap::SocialLinkRankUpGlow", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.TownMapSLRankUpGlow.B:X}",
                    $"mov dl, ${_context._config.TownMapSLRankUpGlow.G:X}",
                    $"mov cl, ${_context._config.TownMapSLRankUpGlow.R:X}"
                };
                _socialLinkRankUpGlow = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUITownMap_SocialLinkEpisodeLogo_SIG, "AUITownMap::SocialLinkEpisodeLogo", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.TownMapLogosColor.B:X}",
                    $"mov dl, ${_context._config.TownMapLogosColor.G:X}",
                    $"mov cl, ${_context._config.TownMapLogosColor.R:X}"
                };
                _socialLinkEpisodeLogo = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUITownMap_SocialLinkEpisodeName_SIG, "AUITownMap::SocialLinkEpisodeName", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.TownMapNamesColor.B:X}",
                    $"mov dl, ${_context._config.TownMapNamesColor.G:X}",
                    $"mov cl, ${_context._config.TownMapNamesColor.R:X}"
                };
                _socialLinkEpisodeName = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUITownMap_SocialLinkHangoutLogo_SIG, "AUITownMap::SocialLinkHangoutLogo", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.TownMapLogosColor.B:X}",
                    $"mov dl, ${_context._config.TownMapLogosColor.G:X}",
                    $"mov cl, ${_context._config.TownMapLogosColor.R:X}"
                };
                _socialLinkHangoutLogo = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUITownMap_SocialLinkHangoutName_SIG, "AUITownMap::SocialLinkHangoutName", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.TownMapNamesColor.B:X}",
                    $"mov dl, ${_context._config.TownMapNamesColor.G:X}",
                    $"mov cl, ${_context._config.TownMapNamesColor.R:X}"
                };
                _socialLinkHangoutName = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUITownMap_SocialLinkKoroLogo_SIG, "AUITownMap::SocialLinkKoroLogo", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.TownMapLogosColor.B:X}",
                    $"mov dl, ${_context._config.TownMapLogosColor.G:X}",
                    $"mov cl, ${_context._config.TownMapLogosColor.R:X}"
                };
                _socialLinkKoroLogo = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(AUITownMap_SocialLinkKoroName_SIG, "AUITownMap::SocialLinkKoroName", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    $"mov r8b, ${_context._config.TownMapNamesColor.B:X}",
                    $"mov dl, ${_context._config.TownMapNamesColor.G:X}",
                    $"mov cl, ${_context._config.TownMapNamesColor.R:X}"
                };
                _socialLinkKoroName = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });
        }
        public override void Register()
        {
            _uiCommon = GetModule<UICommon>();
        }

        private unsafe FSprColor AUITownmapActor_LocationDetailsTopLeftBgImpl(FSprColor source) => ConfigColor.ToFSprColorWithAlpha(_context._config.TownMapLocationDetailsTopLeftBg, source.A);
        private unsafe FSprColor AUITownmapActor_LocationDetailsTopLeftTextImpl(FSprColor source) => ConfigColor.ToFSprColorWithAlpha(_context._config.TownMapLocationDetailsTopLeftText, source.A);
        private unsafe FSprColor AUITownMapActor_LocationDetailsTintColorImpl(FSprColor source) => ConfigColor.ToFSprColorWithAlpha(_context._config.TownMapLocationDetailsBgTint, source.A);

        private unsafe FSprColor AUITownMapActor_TownMapTextColorImpl() => ConfigColor.ToFSprColor(_context._config.TownMapTextColor);
        private unsafe FSprColor AUITownMapActor_TownMapBorderColorImpl() => ConfigColor.ToFSprColor(_context._config.TownMapBorderColor);

        private unsafe void FTownMapMarker2_UpdateStateImpl(FTownMapMarker2* self, float deltaTime)
        {
            _townMapMarkerUpdateState.OriginalFunction(self, deltaTime);
            ConfigColor.SetColorIgnoreAlpha(ref self->IconColor, _context.ColorWhite);
            ConfigColor.SetColorCustomAlpha(ref self->MarkerOutline.color, _context._config.TownMapSelectedMarkerOutline, 0x80);
        }

        [Function(new Register[] {}, FunctionAttribute.Register.rax, false)]
        private unsafe delegate FSprColor AUITownMapActor_TownMapSetUICompColor();

        [Function(FunctionAttribute.Register.rax, FunctionAttribute.Register.rax, false)]
        private unsafe delegate FSprColor AUITownMapActor_InjectColorAfterCtor(FSprColor source);

        private unsafe delegate void FTownMapMarker2_UpdateState(FTownMapMarker2* self, float deltaTime);
    }
}
