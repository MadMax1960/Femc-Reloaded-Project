using P3R.CostumeFramework.Costumes;
using P3R.CostumeFramework.Costumes.Models;
using P3R.CostumeFramework.Hooks.Models;
using P3R.CostumeFramework.Hooks.Services;
using P3R.CostumeFramework.Types;
using Reloaded.Hooks.Definitions;
using Reloaded.Hooks.Definitions.X64;
using Unreal.ObjectsEmitter.Interfaces;
using Unreal.ObjectsEmitter.Interfaces.Types;
using static Reloaded.Hooks.Definitions.X64.FunctionAttribute;

namespace P3R.CostumeFramework.Hooks;

internal unsafe class CostumeHooks
{
    [Function(CallingConventions.Microsoft)]
    private delegate void UAppCharacterComp_Update(UAppCharacterComp* comp);
    private UAppCharacterComp_Update? characterCompUpdate;

    [Function(Register.rcx, Register.rax, true)]
    private delegate void SetCostumeId(UAppCharacterComp* comp);
    private IReverseWrapper<SetCostumeId>? setCostumeWrapper;
    private IAsmHook? setCostumeHook;

    private readonly IUnreal unreal;
    private readonly IUObjects uobjects;
    private readonly CostumeRegistry registry;
    private readonly CostumeOverridesRegistry overrides;
    private readonly CostumeDescService costumeDesc;
    private readonly CostumeShellService costumeShells;
    private readonly CostumeMusicService costumeMusic;
    private readonly CostumeRyoService costumeRyo;
    private readonly ItemEquip itemEquip;

    private bool isCostumesRandom;
    private bool useOverworldCostumes;

    public CostumeHooks(
        IUObjects uobjects,
        IUnreal unreal,
        CostumeRegistry registry,
        CostumeOverridesRegistry overrides,
        CostumeDescService costumeDesc,
        CostumeMusicService costumeMusic,
        CostumeRyoService costumeAudio,
        CostumeShellService costumeShell,
        ItemEquip itemEquip)
    {
        this.uobjects = uobjects;
        this.unreal = unreal;
        this.registry = registry;
        this.overrides = overrides;
        this.costumeDesc = costumeDesc;
        this.costumeMusic = costumeMusic;
        this.costumeRyo = costumeAudio;
        this.costumeShells = costumeShell;
        this.itemEquip = itemEquip;

        this.uobjects.FindObject("DatItemCostumeDataAsset", this.SetCostumeData);

        ScanHooks.Add(
            nameof(UAppCharacterComp_Update),
            "48 8B C4 48 89 48 ?? 55 41 54 48 8D 68 ?? 48 81 EC 48 01 00 00",
            (hooks, result) =>
            {
                this.characterCompUpdate = hooks.CreateWrapper<UAppCharacterComp_Update>(result, out _);

                // UAppCharacterComp::Update + 0x254 is FF in release (call to vtable), but 75 in episode aigis (jump)
                var setCostumeAddress = result + (*(byte*)(result + 0x254) == 0x75 ? 0x183 : 0x255);
                var setCostumePatch = new string[]
                {
                    "use64",
                    Utilities.PushCallerRegisters,
                    hooks.Utilities.GetAbsoluteCallMnemonics(this.SetCostumeIdImpl, out this.setCostumeWrapper),
                    Utilities.PopCallerRegisters,
                    "mov rax, qword [rcx]",
                };

                this.setCostumeHook = hooks.CreateAsmHook(setCostumePatch, setCostumeAddress).Activate();
            });
    }

    public Action<Costume>? OnCostumeChanged { get; set; }

    public void SetRandomizeCostumes(bool isCostumesRandom) => this.isCostumesRandom = isCostumesRandom;

    public void SetOverworldCostumes(bool useOverworldCostumes) => this.useOverworldCostumes = useOverworldCostumes;

    private void SetCostumeIdImpl(UAppCharacterComp* comp)
    {
        var character = comp->baseObj.Character;
        var costumeId = comp->mSetCostumeID;

        if (character == Character.AigisReal)
        {
            character = Character.Aigis;
        }

        // Ignore non-player characters.
        if (Characters.PC.Contains(character) == false)
        {
            return;
        }

        // Set costume ID 911 to 51. Acts like a kind of fallback...
        // Maybe it's used to allow for setting costumes through another method?
        // Used during some scripted sections, notably the night of the first battle.
        if (costumeId == 911)
        {
            costumeId = 51;
            Log.Debug($"{nameof(SetCostumeId)} || {character} || Set fallback costume ID 911 to 51.");
        }

        // Handle logic for equipped costumes, such as overworld costumes.
        // Use source character to get correct Aigis.
        var equipCostumeItemId = this.itemEquip.GetEquip(comp->baseObj.Character, Equip.Outfit);
        if (this.registry.TryGetCostumeByItemId(equipCostumeItemId, out var costume))
        {
            Log.Debug($"Equipped Costume: {character} || {costume.Name}");
            if (this.useOverworldCostumes && costumeId != costume.CostumeId)
            {
                costumeId = costume.CostumeId;
                Log.Debug("(Overworld Costumes) Set Costume ID to Equipped");
            }
        }

        // Apply any costume overrides.
        if (this.overrides.TryGetCostumeOverride(character, costumeId, out var overrideCostume))
        {
            costumeId = overrideCostume.CostumeId;
            Log.Debug($"{nameof(SetCostumeId)} || {character} || Costume ID: {costumeId} || Override: {overrideCostume.Name}");
        }

        // Apply randomized costumes.
        if ((isCostumesRandom || costumeId == GameCostumes.RANDOMIZED_COSTUME_ID)
            && this.registry.GetRandomCostume(character) is Costume randomCostume)
        {
            costumeId = randomCostume.CostumeId;
            Log.Debug($"{nameof(SetCostumeId)} || {character} || Costume ID: {costumeId} || Randomized: {randomCostume.Name}");
        }

        // Update before costume ID is set to shell costume.
        if (this.registry.TryGetCostume(character, costumeId, out var finalCostume))
        {
            this.OnCostumeChanged?.Invoke(finalCostume);
        }

        // Use source character to get correct Aigis.
        comp->mSetCostumeID = this.costumeShells.UpdateCostume(comp->baseObj.Character, costumeId);
        Log.Debug($"{nameof(SetCostumeId)} || {character} || Costume ID: {costumeId}");
    }

    private void SetCostumeData(UnrealObject obj)
    {
        var costumeItemList = (UCostumeItemListTable*)obj.Self;

        Log.Debug("Setting costume item data.");
        var activeCostumes = this.registry.GetActiveCostumes();

        for (int i = 0; i < costumeItemList->Count; i++)
        {
            var costumeItem = (*costumeItemList)[i];
            var existingCostume = activeCostumes.FirstOrDefault(x => x.CostumeId == costumeItem.CostumeID && x.Character == AssetUtils.GetCharFromEquip(costumeItem.EquipID));
            if (existingCostume != null)
            {
                existingCostume.SetCostumeItemId(i);
                continue;
            }
        }

        var newItemIndex = 357;
        foreach (var costume in this.registry.GetActiveCostumes())
        {
            // Skip costumes with existing items.
            if (costume.CostumeItemId != default && costume.CostumeItemId < 357)
            {
                continue;
            }

            var newItem = &costumeItemList->Data.AllocatorInstance[newItemIndex];
            newItem->CostumeID = (ushort)costume.CostumeId;
            newItem->EquipID = AssetUtils.GetEquipFromChar(costume.Character);
            costume.SetCostumeItemId(newItemIndex);
            this.costumeDesc.SetCostumeDesc(newItemIndex, costume.Description);

            Log.Debug($"Added costume item ID: {newItemIndex}");
            newItemIndex++;
        }

        this.costumeDesc.Init();
    }
}
