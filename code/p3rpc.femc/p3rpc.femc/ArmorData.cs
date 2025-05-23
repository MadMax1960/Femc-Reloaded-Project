using p3rpc.femc.Configuration;
using Reloaded.Mod.Interfaces;
using System.Runtime.InteropServices;
using Unreal.ObjectsEmitter.Interfaces;
using Unreal.ObjectsEmitter.Interfaces.Types;

namespace p3rpc.femc.Components {
    public class ArmorData
    {
        private IUObjects _uObjects;
        private IUnreal _unreal;
        private ILogger _logger;
        private readonly IModLoader _modLoader;
        private readonly IModConfig _modConfig;
        private readonly Config _configuration;
        private readonly FemcContext _context;

        public ArmorData(IModLoader modLoader, IModConfig modConfig, Config configuration, IUObjects uObjects, IUnreal unreal, ILogger logger, FemcContext context)
        {
            _uObjects = uObjects;
            _unreal = unreal;
            _configuration = configuration;
            _logger = logger;
            _modLoader = modLoader;
            _modConfig = modConfig;
            _context = context;

            unsafe
            {
                _uObjects.FindObject("DatItemArmorDataAsset", obj =>
                {
                    obj.Self = (UObject*)ModifyArmorData((UArmorItemListTable*)obj.Self);
                });
            }
        }

        private unsafe UArmorItemListTable* ModifyArmorData(UArmorItemListTable* armorItemListTable)
        {
            foreach(var (key, value) in armorStatData)
            {
                ApplyUpdate(ref armorItemListTable->Data.AllocatorInstance[key], value);
            }

            return armorItemListTable;
        }

        public unsafe static void ApplyUpdate(ref FArmorItemList target, FArmorItemListUpdate update)
        {
            if (update.ItemDef != null) target.ItemDef = new FString(update.ItemDef);
            if (update.SortNum.HasValue) target.SortNum = update.SortNum.Value;
            if (update.ItemType.HasValue) target.ItemType = update.ItemType.Value;
            if (update.EquipID.HasValue) target.EquipID = update.EquipID.Value;
            if (update.Rarity.HasValue) target.Rarity = update.Rarity.Value;
            if (update.Tier.HasValue) target.Tier = update.Tier.Value;
            if (update.Defence.HasValue) target.Defence = update.Defence.Value;
            if (update.Strength.HasValue) target.Strength = update.Strength.Value;
            if (update.Magic.HasValue) target.Magic = update.Magic.Value;
            if (update.Endurance.HasValue) target.Endurance = update.Endurance.Value;
            if (update.Agility.HasValue) target.Agility = update.Agility.Value;
            if (update.Luck.HasValue) target.Luck = update.Luck.Value;
            if (update.SkillId.HasValue) target.skillId = update.SkillId.Value;
            if (update.Price.HasValue) target.Price = update.Price.Value;
            if (update.SellPrice.HasValue) target.SellPrice = update.SellPrice.Value;
            if (update.GetFLG.HasValue) target.GetFLG = update.GetFLG.Value;
        }

        private Dictionary<int, FArmorItemListUpdate> armorStatData = new()
        {
            /*The dictionary will have the armor's entry index in the data asset as the key and the FArmorItemListUpdate as the value
            {0, new FArmorItemListUpdate
                {
                Only add values which you are going to use, don't assign values to anything you don't want to modify
                    ItemDef = "DUMMYDATA",
                    SortNum = 0,
                    ItemType = 0,
                    EquipID = 0,
                    Rarity = 0,
                    Tier = 0,
                    Defence = 0,
                    Strength = 0,
                    Magic = 0,
                    Endurance = 0,
                    Agility = 0,
                    Luck = 0,
                    SkillId = 0,
                    Price = 10,
                    SellPrice = 10,
                    GetFLG = 1
                }
            */
        };

        [StructLayout(LayoutKind.Explicit, Size = 0x40)]
        public unsafe struct UArmorItemListTable
        {
            [FieldOffset(0x0030)] public TArray<FArmorItemList> Data;
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x40)]
        public unsafe struct FArmorItemList
        {
            [FieldOffset(0x0000)] public FString ItemDef;
            [FieldOffset(0x0010)] public ushort SortNum;
            [FieldOffset(0x0014)] public uint ItemType;
            [FieldOffset(0x0018)] public uint EquipID;
            [FieldOffset(0x001C)] public ushort Rarity;
            [FieldOffset(0x001E)] public ushort Tier;
            [FieldOffset(0x0020)] public ushort Defence;
            [FieldOffset(0x0022)] public ushort Strength;
            [FieldOffset(0x0024)] public ushort Magic;
            [FieldOffset(0x0026)] public ushort Endurance;
            [FieldOffset(0x0028)] public ushort Agility;
            [FieldOffset(0x002A)] public ushort Luck;
            [FieldOffset(0x002C)] public ushort skillId;
            [FieldOffset(0x0030)] public uint Price;
            [FieldOffset(0x0034)] public uint SellPrice;
            [FieldOffset(0x0038)] public ushort GetFLG;
        }

        public class FArmorItemListUpdate
        {
            public string? ItemDef { get; set; }
            public ushort? SortNum { get; set; }
            public uint? ItemType { get; set; }
            public uint? EquipID { get; set; }
            public ushort? Rarity { get; set; }
            public ushort? Tier { get; set; }
            public ushort? Defence { get; set; }
            public ushort? Strength { get; set; }
            public ushort? Magic { get; set; }
            public ushort? Endurance { get; set; }
            public ushort? Agility { get; set; }
            public ushort? Luck { get; set; }
            public ushort? SkillId { get; set; }
            public uint? Price { get; set; }
            public uint? SellPrice { get; set; }
            public ushort? GetFLG { get; set; }
        }
    }
}
