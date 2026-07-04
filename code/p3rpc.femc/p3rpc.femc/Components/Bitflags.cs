using System.Runtime.InteropServices;
using p3rpc.commonmodutils;
using p3rpc.nativetypes.Interfaces;
using Reloaded.Hooks.Definitions;
using Reloaded.Memory.Extensions;
using UE.Toolkit.Core.Types;
using UE.Toolkit.Core.Types.Unreal.UE5_4_4;
using FName = UE.Toolkit.Core.Types.Unreal.UE5_4_4.FName;
using FSoftObjectPtr = UE.Toolkit.Core.Types.Unreal.UE5_4_4.FSoftObjectPtr;
using GlobalWork = p3rpc.nativetypes.Interfaces.Astrea.GlobalWork;
// ReSharper disable InconsistentNaming

namespace p3rpc.femc.Components;

[StructLayout(LayoutKind.Explicit, Size = 0x3a8d0)]
public unsafe struct UGWFlagWorkFemc
{
    [FieldOffset(0x0)] public UGWFlagWork Super;
    [FieldOffset(0x368c0)] public UDataTable* pFemcDataTable;
    [FieldOffset(0x368c8)] public FGWHashBase FemcDataHashArry; // FGWHashBase[1024]
    [FieldOffset(0x3a8c8)] public int FemcDataHashNum;
}

// ReSharper disable once ClassNeverInstantiated.Global
public unsafe class Bitflags : ModuleAsmInlineColorEdit<FemcContext>
{

    private readonly string FSoftObjectPtr_LoadSynchronous_SIG =
        "48 89 5C 24 ?? 48 89 74 24 ?? 48 89 7C 24 ?? 41 56 48 83 EC 20 48 8B F9 E8 ?? ?? ?? ?? 45 33 F6";
    private FSoftObjectPtr_LoadSynchronous? _FSoftObjectPtr_LoadSynchronous;
    private delegate UObject* FSoftObjectPtr_LoadSynchronous(FSoftObjectPtr* Self);
    
    private UGWFlagWorkFemc* GFlagWork;

    private readonly string UGWFlagWork_LoadFlagNames_SIG =
        "40 55 53 56 57 41 54 41 55 41 56 41 57 48 8D 6C 24 ?? 48 81 EC 78 01 00 00 33 FF";
    private IHook<UGWFlagWork_LoadFlagNames>? _UGWFlagWork_LoadFlagNames;
    private delegate void UGWFlagWork_LoadFlagNames(UGWFlagWorkFemc* pWork);
    private void UGWFlagWork_LoadFlagNamesImpl(UGWFlagWorkFemc* pWork)
    {
        _UGWFlagWork_LoadFlagNames!.OriginalFunction(pWork);
        GFlagWork = pWork;
        _context._utils.Log($"GFlagWork set to 0x{(nint)pWork:x}");
        if (GFlagWork->pFemcDataTable != null) return;
        // Extension of UGWFlagWork::LoadFlagNames within UGlobalWork::Init
        FSoftObjectPtr PathToLoad = new(); // (TSoftObjectPtr<UDataTable>
        PathToLoad.Super.WeakPtr.ObjectIndex = -1;
        PathToLoad.Super.ObjectId.AssetPath.PackageName =
            new("/Game/Xrd777/Blueprints/Common/Flags/DT_FemFlag.DT_FemFlag");
        GFlagWork->pFemcDataTable = (UDataTable*)_FSoftObjectPtr_LoadSynchronous!(&PathToLoad);
        _context._toolkitObjects.GUObjectArray.AddToRootSet(((UObjectBase*)GFlagWork->pFemcDataTable)->InternalIndex);
        var FemcDT = new UDataTableManaged<Ptr<FGWFlagType>>((UDataTable<Ptr<FGWFlagType>>*)GFlagWork->pFemcDataTable, _context._toolkitMemory);
        _context._utils.Log($"Femc datatable: 0x{(nint)FemcDT.Self:x}");
        GFlagWork->FemcDataHashNum = UGWFlagWork_ConvertDataTableToGWHash(GFlagWork, FemcDT, &GFlagWork->FemcDataHashArry);
        for (var i = 0; i < GFlagWork->FemcDataHashNum; i++)
        {
            var Curr = &GFlagWork->FemcDataHashArry + i;
            _context._utils.Log($"{Curr->Name} || Hash 0x{Curr->hash:x} || Value 0x{Curr->Value:x}");
        }
    }
    
    // Original function: FUN_1411ff0e0 (Steam 1.0.10)
    private int UGWFlagWork_ConvertDataTableToGWHash(UGWFlagWorkFemc* _, UDataTableManaged<Ptr<FGWFlagType>> Table, FGWHashBase* Hashes)
    {
        var FlagList = Table.Select(Flag =>
        {
            var Value = Flag.Value.Value->Value;
            return new FGWHashBase
            {
                Name = Flag.Key.ToNT(),
                hash = UGWFlagWork_ConvertNameToHash(Flag.Key.ToString()),
                Value = Value->Offset + Value->Value
            };
        }).ToList();
        FlagList.Sort((a, b) => a.hash.CompareTo(b.hash));
        var FlagArr = FlagList.ToArray();
        fixed (FGWHashBase* pFlagList = FlagArr)
            NativeMemory.Copy(pFlagList, Hashes, (nuint)(FlagList.Count * sizeof(FGWHashBase)));
        return FlagList.Count;
    }
    
    // Original function: FUN_1411ff000 (Steam 1.0.10)
    private uint UGWFlagWork_ConvertNameToHash(string Name)
        => (uint)Name.ToCharArray().Select((x, i) => x * (i + 1) * 10).Sum();

    private readonly string UGlobalWork_NameToBitflag_SIG = "48 89 5C 24 ?? 48 89 74 24 ?? 48 89 4C 24 ?? 55";
    private delegate uint UGlobalWork_NameToBitflag(FName name);
    private IHook<UGlobalWork_NameToBitflag>? _UGlobalWork_NameToBitflag;
    private uint UGlobalWork_NameToBitflagImpl(FName name)
    {
        if (!name.ToString().StartsWith("FEM"))
            return _UGlobalWork_NameToBitflag!.OriginalFunction(name);
        // From UGWFlagWork::NameToBitflag
        var TargetHash = UGWFlagWork_ConvertNameToHash(name.ToString());
        var End = GFlagWork->FemcDataHashNum;
        var Hashes = &GFlagWork->FemcDataHashArry;
        if (End == 0) return uint.MaxValue;
        var Start = 0;
        var Index = GetIndex();
        // Get right set of name hashes in BST
        while (TargetHash != Hashes[Index].hash)
        {
            if (TargetHash < Hashes[Index].hash) End = Index - 1;
            else Start = Index + 1;
            if (End < Start) return uint.MaxValue;
            Index = GetIndex();
        }
        // Move back to the first name in hash collision list
        while (Index > 0 && Hashes[Index-1].hash == TargetHash)
        {
            if (Hashes[Index].Name.FromNT().Equals(name)) return Hashes[Index].Value;
            Index--;
        }
        // Move forward across names with hash collision
        while (Index < GFlagWork->FemcDataHashNum && Hashes[Index].hash == TargetHash)
        {
            if (Hashes[Index].Name.FromNT().Equals(name)) return Hashes[Index].Value;
            Index++;
        }
        return uint.MaxValue;
        int GetIndex() => (End - Start) / 2 + Start;
    }

    private readonly string UGlobalWork_GetBitflag_SIG =
        "E8 ?? ?? ?? ?? 84 C0 0F 84 ?? ?? ?? ?? E8 ?? ?? ?? ?? B2 34";
    private delegate byte UGlobalWork_GetBitflag(UGlobalWork* GWork, int Flag);
    private IHook<UGlobalWork_GetBitflag>? _UGlobalWork_GetBitflag;
    private byte UGlobalWork_GetBitflagImpl(UGlobalWork* pWork, int Flag)
    {
        if (Flag >> 0x1c != 6)
        {
            return _UGlobalWork_GetBitflag!.OriginalFunction(pWork, Flag);
        }
        // Log.Debug($"UGlobalWork::GetBitflag || Custom Flag 0x{Flag:x}");
        var GWork = new GlobalWork((p3rpc.nativetypes.Interfaces.Astrea.UGlobalWork*)pWork);
        var FemcBitflag = (int*)GWork.GetUnit(6)->persona.GetPersona(1);
        var (Int, Bit) = (Flag >> 5 & 0x7fffff, 1 << (Flag & 0x1f));
        var Value = (FemcBitflag[Int] & Bit) != 0;
        _context._utils.Log($"UGlobalWork::GetBitflag || Femc Flag 0x{Flag:x} || Value {Value}");
        return Value.ToByte();
    }

    private readonly string UGlobalWork_SetBitflag_SIG = "E8 ?? ?? ?? ?? FF C5 49 83 C7 28";
    private delegate void UGlobalWork_SetBitflag(UGlobalWork* GWork, int Flag, byte Value);
    private IHook<UGlobalWork_SetBitflag>? _UGlobalWork_SetBitflag;
    private void UGlobalWork_SetBitflagImpl(UGlobalWork* pWork, int Flag, byte Value)
    {
        if (Flag >> 0x1c != 6)
        {
            _UGlobalWork_SetBitflag!.OriginalFunction(pWork, Flag, Value) ;
            return;
        }
        _context._utils.Log($"UGlobalWork::SetBitflag || Femc Flag 0x{Flag:x} || Set to {Value > 0}");
        var GWork = new GlobalWork((p3rpc.nativetypes.Interfaces.Astrea.UGlobalWork*)pWork);
        var FemcBitflag = (int*)GWork.GetUnit(6)->persona.GetPersona(1);
        var (Int, Bit) = (Flag >> 5 & 0x7fffff, 1 << (Flag & 0x1f));
        if (Value > 0) FemcBitflag[Int] |= Bit; // On
        else FemcBitflag[Int] &= ~Bit; // Off
    }
    
    // Add 1024 extra flags for Femc Project
    private static uint GetFlagWorkExtraSize() => (uint)(sizeof(nint) * 2 + sizeof(FGWHashBase) * 1024);
    
    public Bitflags(FemcContext context, Dictionary<string, ModuleBase<FemcContext>> modules) : base(context, modules)
    {
        _context._toolkitClasses.AddExtension<UGWFlagWork>(GetFlagWorkExtraSize(),
            x => NativeMemory.Clear(x.Self + 1, GetFlagWorkExtraSize()));
        _context._utils.SigScan(FSoftObjectPtr_LoadSynchronous_SIG, "FSoftObjectPtr::LoadSynchronous",
            _context._utils.GetDirectAddress, addr => _FSoftObjectPtr_LoadSynchronous = _context._utils.MakeWrapper<FSoftObjectPtr_LoadSynchronous>(addr));
        _context._utils.SigScan(UGWFlagWork_LoadFlagNames_SIG, "UGWFlagWork::LoadFlagNames",
            _context._utils.GetDirectAddress, addr => _UGWFlagWork_LoadFlagNames = _context._utils.MakeHooker<UGWFlagWork_LoadFlagNames>(UGWFlagWork_LoadFlagNamesImpl, addr));
        _context._utils.SigScan(UGlobalWork_NameToBitflag_SIG, "UGlobalWork::NameToBitflag",
            _context._utils.GetDirectAddress, addr => _UGlobalWork_NameToBitflag = _context._utils.MakeHooker<UGlobalWork_NameToBitflag>(UGlobalWork_NameToBitflagImpl, addr));
        _context._utils.SigScan(UGlobalWork_GetBitflag_SIG, "UGlobalWork::GetBitflag",
            _context._utils.GetIndirectAddressShort, addr => _UGlobalWork_GetBitflag = _context._utils.MakeHooker<UGlobalWork_GetBitflag>(UGlobalWork_GetBitflagImpl, addr));
        _context._utils.SigScan(UGlobalWork_SetBitflag_SIG, "UGlobalWork::SetBitflag",
            x => _context._utils.GetAddressMayThunkAbsolute(_context._utils.GetIndirectAddressShort(x)), addr => _UGlobalWork_SetBitflag = _context._utils.MakeHooker<UGlobalWork_SetBitflag>(UGlobalWork_SetBitflagImpl, addr));       
    }

    public override void Register()
    {
    }
}