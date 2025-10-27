using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Components
{
    public class FemcEquipment : ModuleAsmInlineColorEdit<FemcContext>
    {
        private string UCmpEquip_FemaleEquipmentForFemc_SIG = "0F A3 C8 73 ?? B0 01 48 8B 5C 24 ??";
        private string UCmpEquip_FemcArmorFemaleSymbolDraw_SIG = "48 8B 5C 24 ?? 48 83 C4 20 5F C3 81 F9 7E 05 00 00";
        private string UCmpEquip_SafeEquippmentLoad_SIG = "E8 ?? ?? ?? ?? 84 C0 74 ?? 0F B7 CE E8 ?? ?? ?? ?? 0F B6 F8";

        private IAsmHook _FemaleEquipmentForFemc;
        private IAsmHook _FemcArmorFemaleSymbolDraw;
        private IAsmHook _SafeEquippmentLoad;

        public unsafe FemcEquipment(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
        {
            _context._utils.SigScan(UCmpEquip_FemaleEquipmentForFemc_SIG, "UCmpEquip::FemaleEquipmentForFemc", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    "cmp eax, 0x64", // Check Female equipment bitmask
                    "je .check_ecx",
                    "cmp eax, 0x51A", // Check Male equipment bitmask
                    "jne .original",

                    ".check_ecx:", // Check specific outfits for Femc id
                    "cmp ecx, 1",
                    "jne .original",
                    "mov ecx, 2", // Set Femc id to Yukari's id for this equipment

                    ".original:"
                };
                _FemaleEquipmentForFemc = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(UCmpEquip_FemcArmorFemaleSymbolDraw_SIG, "UCmpEquip::FemcArmorFemaleSymbolDraw", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    "cmp edi, 0x107d", // Check Jack Jumper equipment
                    "jne .original",

                    "mov eax, 0x21", // If we are drawing Jack Jumper draw it with female symbol

                    ".original:",
                };
                _FemcArmorFemaleSymbolDraw = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteFirst).Activate();
            });

            _context._utils.SigScan(UCmpEquip_SafeEquippmentLoad_SIG, "UCmpEquip::SafeEquippmentLoad", _context._utils.GetDirectAddress, addr =>
            {
                string[] function =
                {
                    "use64",
                    "jnz .itemEquippable",

                    "cmp esi, [r13]", // Check current item against current equipped item
                    "setne al",
                    "xor al, 1", // If the current item is equipped this will set the zero flag for the itemEquippable path & will push it to the list

                    ".itemEquippable:",
                };
                _SafeEquippmentLoad = _context._hooks.CreateAsmHook(function, addr, AsmHookBehaviour.ExecuteAfter).Activate();
            });
        }

        public override void Register() {}
    }
}
