using Reloaded.Hooks.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p3rpc.femc.Native
{
    // Copied from Hi-Fi RUSH Research project

    // ====================
    // IO STORE STRUCTS
    // ====================

    [StructLayout(LayoutKind.Sequential, Size = 0xc)]
    public unsafe struct FIoChunkId
    {
        public byte GetByte(int idx) { fixed (FIoChunkId* self = &this) return *(byte*)((IntPtr)self + idx); }
        public string GetId()
        {
            string key_out = "0x";
            for (int i = 0; i < 0xc; i++) key_out += $"{GetByte(i):X2}";
            return key_out;
        }
    }

    // ====================
    // OBJECT DUMPER STRUCTS
    // ====================

    [StructLayout(LayoutKind.Sequential, Size = 0x10)]
    public unsafe struct TArray<T>
    {
        public T* allocator_instance;
        public int arr_num;
        public int arr_max;
    }
    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public unsafe struct TMap // : TSortableMapBase
    {
        // TSparseArray fields (0x0 - 0x38)
        [FieldOffset(0x0)] public TArray<IntPtr> valueOffsets;
        // TBitArray<Allocator::BitArrayAllocator> allocationFlags @ 0x10
        [FieldOffset(0x30)] public int first_free_index;
        [FieldOffset(0x34)] public int num_free_indices;
        // TSet fields (0x38 - 0x50)
    }
    public enum EObjectFlags : uint
    {
        Public = 1 << 0x0,
        Standalone = 1 << 0x1,
        MarkAsNative = 1 << 0x2,
        Transactional = 1 << 0x3,
        ClassDefaultObject = 1 << 0x4,
        ArchetypeObject = 1 << 0x5,
        Transient = 1 << 0x6,
        MarkAsRootSet = 1 << 0x7,
        TagGarbageTemp = 1 << 0x8,
        NeedInitialization = 1 << 0x9,
        NeedLoad = 1 << 0xa,
        KeepForCooker = 1 << 0xb,
        NeedPostLoad = 1 << 0xc,
        NeedPostLoadSubobjects = 1 << 0xd,
        NewerVersionExists = 1 << 0xe,
        BeginDestroyed = 1 << 0xf,
        FinishDestroyed = 1 << 0x10,
        BeingRegenerated = 1 << 0x11,
        DefaultSubObject = 1 << 0x12,
        WasLoaded = 1 << 0x13,
        TextExportTransient = 1 << 0x14,
        LoadCompleted = 1 << 0x15,
        InheritableComponentTemplate = 1 << 0x16,
        DuplicateTransient = 1 << 0x17,
        StrongRefOnFrame = 1 << 0x18,
        NonPIEDuplicateTransient = 1 << 0x19,
        Dynamic = 1 << 0x1a,
        WillBeLoaded = 1 << 0x1b,
        HasExternalPackage = 1 << 0x1c,
        PendingKill = 1 << 0x1d,
        Garbage = 1 << 0x1e,
        AllocatedInSharedPage = (uint)1 << 0x1f
    }
    public enum EInternalObjectFlags : uint
    {
        None = 0,
        LoaderImport = 1 << 20, ///< Object is ready to be imported by another package during loading
	    Garbage = 1 << 21, ///< Garbage from logical point of view and should not be referenced. This flag is mirrored in EObjectFlags as RF_Garbage for performance
	    PersistentGarbage = 1 << 22, ///< Same as above but referenced through a persistent reference so it can't be GC'd
	    ReachableInCluster = 1 << 23, ///< External reference to object in cluster exists
	    ClusterRoot = 1 << 24, ///< Root of a cluster
	    Native = 1 << 25, ///< Native (UClass only). 
	    Async = 1 << 26, ///< Object exists only on a different thread than the game thread.
	    AsyncLoading = 1 << 27, ///< Object is being asynchronously loaded.
	    Unreachable = 1 << 28, ///< Object is not reachable on the object graph.
	    PendingKill = 1 << 29, ///< Objects that are pending destruction (invalid for gameplay but valid objects). This flag is mirrored in EObjectFlags as RF_PendingKill for performance
	    RootSet = 1 << 30, ///< Object will not be garbage collected, even if unreferenced.
	    PendingConstruction = (uint)1 << 31, ///< Object didn't have its class constructor called yet (only the UObjectBase one to initialize its most basic member
    };
    [StructLayout(LayoutKind.Sequential, Size = 0x28)]
    public unsafe struct UObjectBase
    {
        public IntPtr _vtable; // @ 0x0
        public EObjectFlags ObjectFlags; // @ 0x8
        public uint InternalIndex; // @ 0xc
        public UClass* ClassPrivate; // @ 0x10 Type of this object. Used for reflection
        public FName NamePrivate; // @ 0x18
        public UObjectBase* OuterPrivate; // @ 0x20 Object that is containing this object
    }
    // Class data
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public unsafe struct UField
    {
        [FieldOffset(0x0)] public UObjectBase _super;
        [FieldOffset(0x28)] public UField* next;
    }
    [StructLayout(LayoutKind.Explicit, Size = 0xb0)]
    public unsafe struct UStruct
    {
        [FieldOffset(0x0)] public UField _super;
        [FieldOffset(0x40)] public UStruct* super_struct;
        [FieldOffset(0x48)] public UField* children; // anything not a type field (e.g a class method) - beginning of linked list
        [FieldOffset(0x50)] public FField* child_properties; // the data model - beginning of linked list
        [FieldOffset(0x58)] public int properties_size;
        [FieldOffset(0x5c)] public int min_alignment;
        [FieldOffset(0x60)] public TArray<byte> Script;
        [FieldOffset(0x70)] public FProperty* prop_link;
        [FieldOffset(0x78)] public FProperty* ref_link;
        [FieldOffset(0x80)] public FProperty* dtor_link;
        [FieldOffset(0x88)] public FProperty* post_ct_link;
    }
    [StructLayout(LayoutKind.Explicit, Size = 0xc0)]
    public unsafe struct UScriptStruct
    {
        [FieldOffset(0x0)] public UStruct _super;
        [FieldOffset(0xb0)] public uint flags;
        [FieldOffset(0xb4)] public bool b_prepare_cpp_struct_ops_completed;
        [FieldOffset(0xb8)] public IntPtr cpp_struct_ops;
    }

    /*
    public struct FNativeFuncPtr
    {
        public IntPtr NameUTF8;
        public IntPtr Pointer;
    }
    */

    public enum EFunctionFlags : uint
    {
        // Function flags.
        FUNC_None = 0x00000000,

        FUNC_Final = 0x00000001,    // Function is final (prebindable, non-overridable function).
        FUNC_RequiredAPI = 0x00000002,  // Indicates this function is DLL exported/imported.
        FUNC_BlueprintAuthorityOnly = 0x00000004,   // Function will only run if the object has network authority
        FUNC_BlueprintCosmetic = 0x00000008,   // Function is cosmetic in nature and should not be invoked on dedicated servers
                                               // FUNC_				= 0x00000010,   // unused.
                                               // FUNC_				= 0x00000020,   // unused.
        FUNC_Net = 0x00000040,   // Function is network-replicated.
        FUNC_NetReliable = 0x00000080,   // Function should be sent reliably on the network.
        FUNC_NetRequest = 0x00000100,   // Function is sent to a net service
        FUNC_Exec = 0x00000200, // Executable from command line.
        FUNC_Native = 0x00000400,   // Native function.
        FUNC_Event = 0x00000800,   // Event function.
        FUNC_NetResponse = 0x00001000,   // Function response from a net service
        FUNC_Static = 0x00002000,   // Static function.
        FUNC_NetMulticast = 0x00004000, // Function is networked multicast Server -> All Clients
        FUNC_UbergraphFunction = 0x00008000,   // Function is used as the merge 'ubergraph' for a blueprint, only assigned when using the persistent 'ubergraph' frame
        FUNC_MulticastDelegate = 0x00010000,    // Function is a multi-cast delegate signature (also requires FUNC_Delegate to be set!)
        FUNC_Public = 0x00020000,   // Function is accessible in all classes (if overridden, parameters must remain unchanged).
        FUNC_Private = 0x00040000,  // Function is accessible only in the class it is defined in (cannot be overridden, but function name may be reused in subclasses.  IOW: if overridden, parameters don't need to match, and Super.Func() cannot be accessed since it's private.)
        FUNC_Protected = 0x00080000,    // Function is accessible only in the class it is defined in and subclasses (if overridden, parameters much remain unchanged).
        FUNC_Delegate = 0x00100000, // Function is delegate signature (either single-cast or multi-cast, depending on whether FUNC_MulticastDelegate is set.)
        FUNC_NetServer = 0x00200000,    // Function is executed on servers (set by replication code if passes check)
        FUNC_HasOutParms = 0x00400000,  // function has out (pass by reference) parameters
        FUNC_HasDefaults = 0x00800000,  // function has structs that contain defaults
        FUNC_NetClient = 0x01000000,    // function is executed on clients
        FUNC_DLLImport = 0x02000000,    // function is imported from a DLL
        FUNC_BlueprintCallable = 0x04000000,    // function can be called from blueprint code
        FUNC_BlueprintEvent = 0x08000000,   // function can be overridden/implemented from a blueprint
        FUNC_BlueprintPure = 0x10000000,    // function can be called from blueprint code, and is also pure (produces no side effects). If you set this, you should set FUNC_BlueprintCallable as well.
        FUNC_EditorOnly = 0x20000000,   // function can only be called from an editor scrippt.
        FUNC_Const = 0x40000000,    // function can be called from blueprint code, and only reads state (never writes state)
        FUNC_NetValidate = 0x80000000,  // function must supply a _Validate implementation
    };

    [StructLayout(LayoutKind.Explicit, Size = 0xe0)]
    public unsafe struct UFunction
    {
        [FieldOffset(0x0)] public UStruct _super;
        [FieldOffset(0xb0)] public EFunctionFlags func_flags;
        [FieldOffset(0xb4)] public byte num_params;
        [FieldOffset(0xb6)] public ushort params_size;
        [FieldOffset(0xc0)] public FProperty* first_prop_to_init;
        [FieldOffset(0xc8)] public UFunction* event_graph_func;
        [FieldOffset(0xd8)] public IntPtr exec_func_ptr;
    }

    public enum EClassFlags : uint
    {
        /** No Flags */
        CLASS_None = 0x00000000u,
        /** Class is abstract and can't be instantiated directly. */
        CLASS_Abstract = 0x00000001u,
        /** Save object configuration only to Default INIs, never to local INIs. Must be combined with CLASS_Config */
        CLASS_DefaultConfig = 0x00000002u,
        /** Load object configuration at construction time. */
        CLASS_Config = 0x00000004u,
        /** This object type can't be saved; null it out at save time. */
        CLASS_Transient = 0x00000008u,
        /** This object type may not be available in certain context. (i.e. game runtime or in certain configuration). Optional class data is saved separately to other object types. (i.e. might use sidecar files) */
        CLASS_Optional = 0x00000010u,
        /** */
        CLASS_MatchedSerializers = 0x00000020u,
        /** Indicates that the config settings for this class will be saved to Project/User*.ini (similar to CLASS_GlobalUserConfig) */
        CLASS_ProjectUserConfig = 0x00000040u,
        /** Class is a native class - native interfaces will have CLASS_Native set, but not RF_MarkAsNative */
        CLASS_Native = 0x00000080u,
        /** Don't export to C++ header. */
        CLASS_NoExport = 0x00000100u,
        /** Do not allow users to create in the editor. */
        CLASS_NotPlaceable = 0x00000200u,
        /** Handle object configuration on a per-object basis, rather than per-class. */
        CLASS_PerObjectConfig = 0x00000400u,

        /** Whether SetUpRuntimeReplicationData still needs to be called for this class */
        CLASS_ReplicationDataIsSetUp = 0x00000800u,

        /** Class can be constructed from editinline New button. */
        CLASS_EditInlineNew = 0x00001000u,
        /** Display properties in the editor without using categories. */
        CLASS_CollapseCategories = 0x00002000u,
        /** Class is an interface **/
        CLASS_Interface = 0x00004000u,
        /**  Do not export a constructor for this class, assuming it is in the cpptext **/
        CLASS_CustomConstructor = 0x00008000u,
        /** all properties and functions in this class are const and should be exported as const */
        CLASS_Const = 0x00010000u,

        /** Class flag indicating objects of this class need deferred dependency loading */
        CLASS_NeedsDeferredDependencyLoading = 0x00020000u,

        /** Indicates that the class was created from blueprint source material */
        CLASS_CompiledFromBlueprint = 0x00040000u,

        /** Indicates that only the bare minimum bits of this class should be DLL exported/imported */
        CLASS_MinimalAPI = 0x00080000u,

        /** Indicates this class must be DLL exported/imported (along with all of it's members) */
        CLASS_RequiredAPI = 0x00100000u,

        /** Indicates that references to this class default to instanced. Used to be subclasses of UComponent, but now can be any UObject */
        CLASS_DefaultToInstanced = 0x00200000u,

        /** Indicates that the parent token stream has been merged with ours. */
        CLASS_TokenStreamAssembled = 0x00400000u,
        /** Class has component properties. */
        CLASS_HasInstancedReference = 0x00800000u,
        /** Don't show this class in the editor class browser or edit inline new menus. */
        CLASS_Hidden = 0x01000000u,
        /** Don't save objects of this class when serializing */
        CLASS_Deprecated = 0x02000000u,
        /** Class not shown in editor drop down for class selection */
        CLASS_HideDropDown = 0x04000000u,
        /** Class settings are saved to <AppData>/..../Blah.ini (as opposed to CLASS_DefaultConfig) */
        CLASS_GlobalUserConfig = 0x08000000u,
        /** Class was declared directly in C++ and has no boilerplate generated by UnrealHeaderTool */
        CLASS_Intrinsic = 0x10000000u,
        /** Class has already been constructed (maybe in a previous DLL version before hot-reload). */
        CLASS_Constructed = 0x20000000u,
        /** Indicates that object configuration will not check against ini base/defaults when serialized */
        CLASS_ConfigDoNotCheckDefaults = 0x40000000u,
        /** Class has been consigned to oblivion as part of a blueprint recompile, and a newer version currently exists. */
        CLASS_NewerVersionExists = 0x80000000u,
    };
    public enum EClassCastFlags : ulong
    {
        CASTCLASS_None = 0x0000000000000000,

        CASTCLASS_UField = 0x0000000000000001,
        CASTCLASS_FInt8Property = 0x0000000000000002,
        CASTCLASS_UEnum = 0x0000000000000004,
        CASTCLASS_UStruct = 0x0000000000000008,
        CASTCLASS_UScriptStruct = 0x0000000000000010,
        CASTCLASS_UClass = 0x0000000000000020,
        CASTCLASS_FByteProperty = 0x0000000000000040,
        CASTCLASS_FIntProperty = 0x0000000000000080,
        CASTCLASS_FFloatProperty = 0x0000000000000100,
        CASTCLASS_FUInt64Property = 0x0000000000000200,
        CASTCLASS_FClassProperty = 0x0000000000000400,
        CASTCLASS_FUInt32Property = 0x0000000000000800,
        CASTCLASS_FInterfaceProperty = 0x0000000000001000,
        CASTCLASS_FNameProperty = 0x0000000000002000,
        CASTCLASS_FStrProperty = 0x0000000000004000,
        CASTCLASS_FProperty = 0x0000000000008000,
        CASTCLASS_FObjectProperty = 0x0000000000010000,
        CASTCLASS_FBoolProperty = 0x0000000000020000,
        CASTCLASS_FUInt16Property = 0x0000000000040000,
        CASTCLASS_UFunction = 0x0000000000080000,
        CASTCLASS_FStructProperty = 0x0000000000100000,
        CASTCLASS_FArrayProperty = 0x0000000000200000,
        CASTCLASS_FInt64Property = 0x0000000000400000,
        CASTCLASS_FDelegateProperty = 0x0000000000800000,
        CASTCLASS_FNumericProperty = 0x0000000001000000,
        CASTCLASS_FMulticastDelegateProperty = 0x0000000002000000,
        CASTCLASS_FObjectPropertyBase = 0x0000000004000000,
        CASTCLASS_FWeakObjectProperty = 0x0000000008000000,
        CASTCLASS_FLazyObjectProperty = 0x0000000010000000,
        CASTCLASS_FSoftObjectProperty = 0x0000000020000000,
        CASTCLASS_FTextProperty = 0x0000000040000000,
        CASTCLASS_FInt16Property = 0x0000000080000000,
        CASTCLASS_FDoubleProperty = 0x0000000100000000,
        CASTCLASS_FSoftClassProperty = 0x0000000200000000,
        CASTCLASS_UPackage = 0x0000000400000000,
        CASTCLASS_ULevel = 0x0000000800000000,
        CASTCLASS_AActor = 0x0000001000000000,
        CASTCLASS_APlayerController = 0x0000002000000000,
        CASTCLASS_APawn = 0x0000004000000000,
        CASTCLASS_USceneComponent = 0x0000008000000000,
        CASTCLASS_UPrimitiveComponent = 0x0000010000000000,
        CASTCLASS_USkinnedMeshComponent = 0x0000020000000000,
        CASTCLASS_USkeletalMeshComponent = 0x0000040000000000,
        CASTCLASS_UBlueprint = 0x0000080000000000,
        CASTCLASS_UDelegateFunction = 0x0000100000000000,
        CASTCLASS_UStaticMeshComponent = 0x0000200000000000,
        CASTCLASS_FMapProperty = 0x0000400000000000,
        CASTCLASS_FSetProperty = 0x0000800000000000,
        CASTCLASS_FEnumProperty = 0x0001000000000000,
        CASTCLASS_USparseDelegateFunction = 0x0002000000000000,
        CASTCLASS_FMulticastInlineDelegateProperty = 0x0004000000000000,
        CASTCLASS_FMulticastSparseDelegateProperty = 0x0008000000000000,
        CASTCLASS_FFieldPathProperty = 0x0010000000000000,
    };
    [StructLayout(LayoutKind.Explicit, Size = 0x230)]
    public unsafe struct UClass
    {
        [FieldOffset(0x0)] public UStruct _super;
        [FieldOffset(0xb0)] public IntPtr class_ctor; // InternalConstructor<class_UClassName> => UClassName::UClassName
        [FieldOffset(0xb8)] public IntPtr class_vtable_helper_ctor_caller;
        [FieldOffset(0xc0)] public IntPtr class_add_ref_objects;
        [FieldOffset(0xc8)] public uint class_status; // ClassUnique : 31, bCooked : 1
        [FieldOffset(0xcc)] public EClassFlags class_flags;
        [FieldOffset(0xd0)] public EClassCastFlags class_cast_flags;
        [FieldOffset(0xd8)] public UClass* class_within; // type of object containing the current object
        [FieldOffset(0xe0)] public UObjectBase* class_gen_by;
        [FieldOffset(0xe8)] public FName class_conf_name;
        [FieldOffset(0x100)] public TArray<UField> net_fields;
        [FieldOffset(0x118)] public UObjectBase* class_default_obj; // Default object of type described in UClass instance
        [FieldOffset(0x130)] public TMap func_map;
        [FieldOffset(0x180)] public TMap super_func_map;
        [FieldOffset(0x1d8)] public TArray<IntPtr> interfaces;
        [FieldOffset(0x220)] public TArray<FNativeFunctionLookup> native_func_lookup;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct FNativeFunctionLookup
    {
        [FieldOffset(0x0)] FName name;
        [FieldOffset(0x8)] /*FNativeFuncPtr*/ nint Pointer;
    }

    public unsafe delegate void FNativeFuncPtr(UObjectBase* context, nuint stack, nuint returnValue);

    public unsafe struct UEnumEntry // TTuple<FName, long>
    {
        public FName name;
        public long value; // Size : 0x10
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x60)]
    public unsafe struct UEnum
    {
        [FieldOffset(0x0)] public UField _super;
        [FieldOffset(0x30)] public FString cpp_type;
        [FieldOffset(0x40)] public TArray<UEnumEntry> entries;
        [FieldOffset(0x58)] public IntPtr enum_disp_name_fn;
    }
    // Properties
    [StructLayout(LayoutKind.Sequential, Size = 0x10)]
    public unsafe struct FFieldObjectUnion
    {
        public IntPtr field_or_obj;
        public bool b_is_uobj;
    }
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public unsafe struct FFieldClass
    {
        [FieldOffset(0x0)] public FName name;
        [FieldOffset(0x20)] public FFieldClass* super;
        [FieldOffset(0x28)] public FField* default_obj;
        [FieldOffset(0x30)] public IntPtr ctor; // [PropertyName]::Construct (e.g for ArrayProperty, this would be FArrayProperty::Construct)
    }

    [StructLayout(LayoutKind.Sequential, Size = 0x38)]
    public unsafe struct FField
    {
        public IntPtr _vtable; // @ 0x0
        public FFieldClass* class_private; // @ 0x8
        public FFieldObjectUnion owner; // @ 0x10
        public FField* next; // @ 0x20
        public FName name_private; // @ 0x28
        public EObjectFlags flags_private; // @ 0x30

    }
    public enum EPropertyFlags : ulong
    {
        CPF_None = 0,

        CPF_Edit = 0x0000000000000001,  ///< Property is user-settable in the editor.
        CPF_ConstParm = 0x0000000000000002, ///< This is a constant function parameter
        CPF_BlueprintVisible = 0x0000000000000004,  ///< This property can be read by blueprint code
        CPF_ExportObject = 0x0000000000000008,  ///< Object can be exported with actor.
        CPF_BlueprintReadOnly = 0x0000000000000010, ///< This property cannot be modified by blueprint code
        CPF_Net = 0x0000000000000020,   ///< Property is relevant to network replication.
        CPF_EditFixedSize = 0x0000000000000040, ///< Indicates that elements of an array can be modified, but its size cannot be changed.
        CPF_Parm = 0x0000000000000080,  ///< Function/When call parameter.
        CPF_OutParm = 0x0000000000000100,   ///< Value is copied out after function call.
        CPF_ZeroConstructor = 0x0000000000000200,   ///< memset is fine for construction
        CPF_ReturnParm = 0x0000000000000400,    ///< Return value.
        CPF_DisableEditOnTemplate = 0x0000000000000800, ///< Disable editing of this property on an archetype/sub-blueprint
        CPF_NonNullable = 0x0000000000001000,   ///< Object property can never be null
        CPF_Transient = 0x0000000000002000, ///< Property is transient: shouldn't be saved or loaded, except for Blueprint CDOs.
        CPF_Config = 0x0000000000004000,    ///< Property should be loaded/saved as permanent profile.
        //CPF_								= 0x0000000000008000,	///< 
        CPF_DisableEditOnInstance = 0x0000000000010000, ///< Disable editing on an instance of this class
        CPF_EditConst = 0x0000000000020000, ///< Property is uneditable in the editor.
        CPF_GlobalConfig = 0x0000000000040000,  ///< Load config from base class, not subclass.
        CPF_InstancedReference = 0x0000000000080000,    ///< Property is a component references.
        //CPF_								= 0x0000000000100000,	///<
        CPF_DuplicateTransient = 0x0000000000200000,    ///< Property should always be reset to the default value during any type of duplication (copy/paste, binary duplication, etc.)
        //CPF_								= 0x0000000000400000,	///< 
        //CPF_    							= 0x0000000000800000,	///< 
        CPF_SaveGame = 0x0000000001000000,  ///< Property should be serialized for save games, this is only checked for game-specific archives with ArIsSaveGame
        CPF_NoClear = 0x0000000002000000,   ///< Hide clear (and browse) button.
        //CPF_  							= 0x0000000004000000,	///<
        CPF_ReferenceParm = 0x0000000008000000, ///< Value is passed by reference; CPF_OutParam and CPF_Param should also be set.
        CPF_BlueprintAssignable = 0x0000000010000000,   ///< MC Delegates only.  Property should be exposed for assigning in blueprint code
        CPF_Deprecated = 0x0000000020000000,    ///< Property is deprecated.  Read it from an archive, but don't save it.
        CPF_IsPlainOldData = 0x0000000040000000,    ///< If this is set, then the property can be memcopied instead of CopyCompleteValue / CopySingleValue
        CPF_RepSkip = 0x0000000080000000,   ///< Not replicated. For non replicated properties in replicated structs 
        CPF_RepNotify = 0x0000000100000000, ///< Notify actors when a property is replicated
        CPF_Interp = 0x0000000200000000,    ///< interpolatable property for use with cinematics
        CPF_NonTransactional = 0x0000000400000000,  ///< Property isn't transacted
        CPF_EditorOnly = 0x0000000800000000,    ///< Property should only be loaded in the editor
        CPF_NoDestructor = 0x0000001000000000,  ///< No destructor
        //CPF_								= 0x0000002000000000,	///<
        CPF_AutoWeak = 0x0000004000000000,  ///< Only used for weak pointers, means the export type is autoweak
        CPF_ContainsInstancedReference = 0x0000008000000000,    ///< Property contains component references.
        CPF_AssetRegistrySearchable = 0x0000010000000000,   ///< asset instances will add properties with this flag to the asset registry automatically
        CPF_SimpleDisplay = 0x0000020000000000, ///< The property is visible by default in the editor details view
        CPF_AdvancedDisplay = 0x0000040000000000,   ///< The property is advanced and not visible by default in the editor details view
        CPF_Protected = 0x0000080000000000, ///< property is protected from the perspective of script
        CPF_BlueprintCallable = 0x0000100000000000, ///< MC Delegates only.  Property should be exposed for calling in blueprint code
        CPF_BlueprintAuthorityOnly = 0x0000200000000000,    ///< MC Delegates only.  This delegate accepts (only in blueprint) only events with BlueprintAuthorityOnly.
        CPF_TextExportTransient = 0x0000400000000000,   ///< Property shouldn't be exported to text format (e.g. copy/paste)
        CPF_NonPIEDuplicateTransient = 0x0000800000000000,  ///< Property should only be copied in PIE
        CPF_ExposeOnSpawn = 0x0001000000000000, ///< Property is exposed on spawn
        CPF_PersistentInstance = 0x0002000000000000,    ///< A object referenced by the property is duplicated like a component. (Each actor should have an own instance.)
        CPF_UObjectWrapper = 0x0004000000000000,    ///< Property was parsed as a wrapper class like TSubclassOf<T>, FScriptInterface etc., rather than a USomething*
        CPF_HasGetValueTypeHash = 0x0008000000000000,   ///< This property can generate a meaningful hash value.
        CPF_NativeAccessSpecifierPublic = 0x0010000000000000,   ///< Public native access specifier
        CPF_NativeAccessSpecifierProtected = 0x0020000000000000,    ///< Protected native access specifier
        CPF_NativeAccessSpecifierPrivate = 0x0040000000000000,  ///< Private native access specifier
        CPF_SkipSerialization = 0x0080000000000000, ///< Property shouldn't be serialized, can still be exported to text
    };

    [StructLayout(LayoutKind.Sequential, Size = 0x78)]
    public unsafe struct FProperty
    // FInt8Property, FInt16Property, FIntProperty, FInt64Property
    // FUint8Property, FUint16Property, FUintProperty, FUint64Property
    // FFloatProperty, FDoubleProperty, FNameProperty, FStrProperty
    {
        public FField _super; // @ 0x0
        public int array_dim; // @ 0x38
        public int element_size; // @ 0x3c
        public EPropertyFlags property_flags; // @ 0x40
        public ushort rep_index; // @ 0x48
        public byte blueprint_rep_cond; // @ 0x4a
        public byte Field4B; // @ 0x4b
        public int offset_internal; // @ 0x4c
        public FName rep_notify_func; // @ 0x50
        public FProperty* prop_link_next; // @ 0x58
        public FProperty* next_ref; // @ 0x60
        public FProperty* dtor_link_next; // @ 0x68
        public FProperty* post_ct_link_next; // @ 0x70
    }
    [StructLayout(LayoutKind.Sequential, Size = 0x80)]
    public unsafe struct FByteProperty
    {
        public FProperty _super; // @ 0x0
        public UEnum* enum_data; // @ 0x78 // TEnumAsByte<EEnum>
    }
    [StructLayout(LayoutKind.Sequential, Size = 0x80)]
    public unsafe struct FBoolProperty
    {
        public FProperty _super; // @ 0x0
        public byte field_size; // @ 0x78
        public byte byte_offset; // @ 0x79
        public byte byte_mask; // @ 0x7a
        public byte field_mask; // @ 0x7b
    }
    [StructLayout(LayoutKind.Sequential, Size = 0x80)]
    public unsafe struct FObjectProperty
    // FObjectPtrProperty, FWeakObjectProperty, FLazyObjectProperty, FSoftObjectProperty, FInterfaceProperty
    {
        // Defines a reference variable to another object
        public FProperty _super; // @ 0x0
        public UClass* prop_class; // @ 0x78
    }
    [StructLayout(LayoutKind.Sequential, Size = 0x88)]
    public unsafe struct FClassProperty
    // FClassPtrProperty, FSoftClassProperty
    {
        public FObjectProperty _super; // @ 0x0
        public UClass* meta; // @ 0x80
    }
    [StructLayout(LayoutKind.Sequential, Size = 0x88)]
    public unsafe struct FArrayProperty
    {
        public FProperty _super; // @ 0x0
        public FProperty* inner; // @ 0x78
        public uint flags; // @ 0x80
    }
    [StructLayout(LayoutKind.Sequential, Size = 0xa8)]
    public unsafe struct FMapProperty
    {
        public FProperty _super; // @ 0x0
        public FProperty* key_prop; // @ 0x78
        public FProperty* value_prop; // @ 0x80
    }
    [StructLayout(LayoutKind.Sequential, Size = 0x98)]
    public unsafe struct FSetProperty
    {
        public FProperty _super; // @ 0x0
        public FProperty* elem_prop; // @ 0x78
    }
    [StructLayout(LayoutKind.Sequential, Size = 0x80)]
    public unsafe struct FStructProperty
    {
        // Structure embedded inside an object
        public FProperty _super; // @ 0x0
        public UScriptStruct* struct_data; // @ 0x78
    }
    [StructLayout(LayoutKind.Sequential, Size = 0x80)]
    public unsafe struct FDelegateProperty
    // FMulticastDelegateProperty, FMulticastInlineDelegateProperty, FMulticastSparseDelegateProperty
    {
        public FProperty _super;
        public UFunction* func;
    }
    [StructLayout(LayoutKind.Sequential, Size = 0x88)]
    public unsafe struct FEnumProperty
    {
        public FProperty _super; // @ 0x0
        public FProperty* underlying_type; // @ 0x78
        public UEnum* enum_data; // @ 0x80
    }
    // For g_namePool
    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public unsafe struct FName
    {
        [FieldOffset(0x0)] public uint pool_location;
    }
    [StructLayout(LayoutKind.Explicit, Size = 0x2)]
    public unsafe struct FString
    {
        // Flags:
        // bIsWide : 1;
        // probeHashBits : 5;
        // Length : 10;
        // Get Length: flags >> 6
        [FieldOffset(0x0)] public short flags;
        public string GetString() { fixed (FString* self = &this) return Marshal.PtrToStringAnsi((IntPtr)(self + 1), flags >> 6); }
    }
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct FNamePool
    {
        [FieldOffset(0x8)] public uint pool_count;
        [FieldOffset(0xc)] public uint name_count;
        public IntPtr GetPool(uint pool_idx) { fixed (FNamePool* self = &this) return *((IntPtr*)(self + 1) + pool_idx); }
        public string GetString(FName name) => GetString(name.pool_location);
        public string GetString(uint pool_loc)
        {
            fixed (FNamePool* self = &this)
            {
                // Get appropriate pool
                IntPtr ptr = GetPool(pool_loc >> 0x10); // 0xABB2B - pool 0xA
                // Go to name entry in pool
                ptr += (nint)((pool_loc & 0xFFFF) * 2);
                return ((FString*)ptr)->GetString();
            }
        }

    }
    // For g_objectArray
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public unsafe struct FUObjectArray
    {
        [FieldOffset(0x0)] public int ObjFirstGCIndex;
        [FieldOffset(0x4)] public int ObjLastNonGCIndex;
        [FieldOffset(0x10)] public FUObjectItem** Objects;
        [FieldOffset(0x24)] public int NumElements;
        // Max number of elements is 0x210000 (2162688)
        // Each chunk can hold 0x10000 elements
        // Max number of chunks is 0x21 (33)
        [FieldOffset(0x2c)] public int NumChunks;
        // 0x30: Critical Section
    }
    [StructLayout(LayoutKind.Sequential, Size = 0x18)]
    public unsafe struct FUObjectItem
    {
        public UObjectBase* Object;
    }
    // For StaticConstructObject_Internal
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public unsafe struct FStaticConstructObjectParameters
    {
        [FieldOffset(0x0)] public UClass* Class; // Type Info
        [FieldOffset(0x8)] public UObjectBase* Outer; // The created object will be a child of this object
        [FieldOffset(0x10)] public FName Name;
        [FieldOffset(0x18)] public EObjectFlags SetFlags;
        [FieldOffset(0x1c)] public EInternalObjectFlags InternalSetFlags;
        [FieldOffset(0x20)] public byte bCopyTransientsFromClassDefaults;
        [FieldOffset(0x21)] public byte bAssumeTemplateIsArchetype;
        [FieldOffset(0x28)] public UObjectBase* Template;
        [FieldOffset(0x30)] public IntPtr InstanceGraph;
        [FieldOffset(0x38)] public IntPtr ExternalPackage;
    }

    // ===================================
    // GENERATED FROM UE4SS CXX HEADER DUMP
    // ===================================
    // CoreUObject.hpp

    [StructLayout(LayoutKind.Sequential, Size = 0xc)]
    public struct FVector
    {
        public float X;                                                                          // 0x0000 (size: 0x4)
        public float Y;                                                                          // 0x0004 (size: 0x4)
        public float Z;                                                                          // 0x0008 (size: 0x4)

        public FVector(float x, float y, float z) { X = x; Y = y; Z = z; }
    }; // Size: 0xC

    [StructLayout(LayoutKind.Sequential, Size = 0x8)]
    public struct FVector2D
    {
        public float X;                                                                          // 0x0000 (size: 0x4)
        public float Y;                                                                          // 0x0004 (size: 0x4)

        public FVector2D(float x, float y) { X = x; Y = y; }
    }; // Size: 0x8

    [StructLayout(LayoutKind.Sequential, Size = 0x10)]
    public struct FVector4
    {
        public float X;                                                                          // 0x0000 (size: 0x4)
        public float Y;                                                                          // 0x0004 (size: 0x4)
        public float Z;                                                                          // 0x0008 (size: 0x4)
        public float W;                                                                          // 0x000C (size: 0x4)

        public FVector4(float x, float y, float z, float w) { X = x; Y = y; Z = z; W = w; }

    }; // Size: 0x10

    [StructLayout(LayoutKind.Sequential, Size = 0x4)]
    public struct FColor
    {
        byte B; // 0x0000 (size: 0x1)
        byte G; // 0x0001 (size: 0x1)
        byte R; // 0x0002 (size: 0x1)
        byte A; // 0x0003 (size: 0x1)

        public override string ToString() => $"#{R:X2}{G:X2}{B:X2}{A:X2}";

        public FColor(byte r, byte g, byte b, byte a)
        {
            B = a;
            G = b;
            R = g;
            A = r;
        }

        public FColor(Configuration.ConfigColor configColor)
        {
            R = configColor.R;
            G = configColor.G;
            B = configColor.B;
            A = configColor.A;
        }

        public FColor(uint color)
        {
            R = (byte)((color >> 0x18) & 0xff);
            G = (byte)((color >> 0x10) & 0xff);
            B = (byte)((color >> 0x8) & 0xff);
            A = (byte)(color & 0xff);
        }

        public void SetColor(uint color)
        {
            R = (byte)((color >> 0x18) & 0xff);
            G = (byte)((color >> 0x10) & 0xff);
            B = (byte)((color >> 0x8) & 0xff);
            A = (byte)(color & 0xff);
        }

        public void SetColor(Configuration.ConfigColor configColor)
        {
            R = configColor.R;
            G = configColor.G;
            B = configColor.B;
            A = configColor.A;
        }

    }; // Size: 0x4
    public struct FSprColor
    {
        // Different color component order
        public byte A;
        public byte B;
        public byte G;
        public byte R;

        public override string ToString() => $"#{R:X2}{G:X2}{B:X2}{A:X2}";
        public FSprColor(byte r, byte g, byte b, byte a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
        public FSprColor(Configuration.ConfigColor configColor)
        {
            R = configColor.R;
            G = configColor.G;
            B = configColor.B;
            A = configColor.A;
        }
        public FSprColor(uint color)
        {
            R = (byte)((color >> 0x18) & 0xff);
            G = (byte)((color >> 0x10) & 0xff);
            B = (byte)((color >> 0x8) & 0xff);
            A = (byte)(color & 0xff);
        }
        public void SetColor(uint color)
        {
            R = (byte)((color >> 0x18) & 0xff);
            G = (byte)((color >> 0x10) & 0xff);
            B = (byte)((color >> 0x8) & 0xff);
            A = (byte)(color & 0xff);
        }

        public void SetColor(Configuration.ConfigColor configColor)
        {
            R = configColor.R;
            G = configColor.G;
            B = configColor.B;
            A = configColor.A;
        }
    }
    [StructLayout(LayoutKind.Sequential, Size = 0x10)]
    public struct FLinearColor
    {
        float R;
        float G;
        float B;
        float A;

        public override string ToString() => $"#{(uint)(R * 255):X2}{(uint)(G * 255):X2}{(uint)(B * 255):X2}{(uint)(A * 255):X2}";

        public void SetColor(uint color)
        {
            R = (float)(byte)((color >> 0x18) & 0xff) / 256;
            G = (float)(byte)((color >> 0x10) & 0xff) / 256;
            B = (float)(byte)((color >> 0x8) & 0xff) / 256;
            A = (float)(byte)(color & 0xff) / 256;
        }

        public void SetColor(Configuration.ConfigColor configColor)
        {
            R = (float)configColor.R / 256;
            G = (float)configColor.G / 256;
            B = (float)configColor.B / 256;
            A = (float)configColor.A / 256;
        }

    }; // Size: 0x10
    [StructLayout(LayoutKind.Sequential, Size = 0xc)]
    public struct FRotator
    {
        float Pitch;                                                                      // 0x0000 (size: 0x4)
        float Yaw;                                                                        // 0x0004 (size: 0x4)
        float Roll;                                                                       // 0x0008 (size: 0x4)

    }; // Size: 0xC

    [StructLayout(LayoutKind.Explicit, Size = 0x1A0)]
    public unsafe struct UTexture2D // : UTexture
    {

    }

    [StructLayout(LayoutKind.Explicit, Size = 0x180)]
    public unsafe struct UTexture // : UStreamableRenderAsset
    {

    }

    [StructLayout(LayoutKind.Explicit, Size = 0xB0)]
    public unsafe struct UDataTable //: public UObject
    {
        [FieldOffset(0x0028)] public UScriptStruct* RowStruct;
        [FieldOffset(0x30)] public TMap RowMap;
        [FieldOffset(0x0080)] public byte bStripFromClientBuilds;
        [FieldOffset(0x0080)] public byte bIgnoreExtraFields;
        [FieldOffset(0x0080)] public byte bIgnoreMissingFields;
        [FieldOffset(0x0088)] public FString ImportKeyField;
    };

    public enum EActorUpdateOverlapsMethod : byte
    {
        UseConfigDefault = 0,
        AlwaysUpdate = 1,
        OnlyUpdateMovable = 2,
        NeverUpdate = 3,
        EActorUpdateOverlapsMethod_MAX = 4,
    };

    public enum ENetRole : byte
    {
        ROLE_None = 0,
        ROLE_SimulatedProxy = 1,
        ROLE_AutonomousProxy = 2,
        ROLE_Authority = 3,
        ROLE_MAX = 4,
    };

    public enum EVectorQuantization : byte
    {
        RoundWholeNumber = 0,
        RoundOneDecimal = 1,
        RoundTwoDecimals = 2,
        EVectorQuantization_MAX = 3,
    };

    public enum ERotatorQuantization : byte
    {
        ByteComponents = 0,
        ShortComponents = 1,
        ERotatorQuantization_MAX = 2,
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x34)]
    public unsafe struct FRepMovement
    {
        [FieldOffset(0x0000)] public FVector LinearVelocity;
        [FieldOffset(0x000C)] public FVector AngularVelocity;
        [FieldOffset(0x0018)] public FVector Location;
        [FieldOffset(0x0024)] public FRotator Rotation;
        [FieldOffset(0x0030)] public byte bSimulatedPhysicSleep;
        [FieldOffset(0x0030)] public byte bRepPhysics;
        [FieldOffset(0x0031)] public EVectorQuantization LocationQuantizationLevel;
        [FieldOffset(0x0032)] public EVectorQuantization VelocityQuantizationLevel;
        [FieldOffset(0x0033)] public ERotatorQuantization RotationQuantizationLevel;

    }; // Size: 0x34
    [StructLayout(LayoutKind.Explicit, Size = 0x40)]
    public unsafe struct FRepAttachment
    {
        [FieldOffset(0x0000)] public AActor* AttachParent;
        [FieldOffset(0x0008)] public FVector LocationOffset;
        [FieldOffset(0x0014)] public FVector RelativeScale3D;
        [FieldOffset(0x0020)] public FRotator RotationOffset;
        [FieldOffset(0x002C)] public FName AttachSocket;
        //[FieldOffset(0x0038)] public USceneComponent* AttachComponent;
        [FieldOffset(0x0038)] public nint AttachComponent;
    };

    public enum ENetDormancy : byte
    {
        DORM_Never = 0,
        DORM_Awake = 1,
        DORM_DormantAll = 2,
        DORM_DormantPartial = 3,
        DORM_Initial = 4,
        DORM_MAX = 5,
    };

    public enum ESpawnActorCollisionHandlingMethod : byte
    {
        Undefined = 0,
        AlwaysSpawn = 1,
        AdjustIfPossibleButAlwaysSpawn = 2,
        AdjustIfPossibleButDontSpawnIfColliding = 3,
        DontSpawnIfColliding = 4,
        ESpawnActorCollisionHandlingMethod_MAX = 5,
    };

    public enum EAutoReceiveInputType : byte
    {
        Disabled = 0,
        Player0 = 1,
        Player1 = 2,
        Player2 = 3,
        Player3 = 4,
        Player4 = 5,
        Player5 = 6,
        Player6 = 7,
        Player7 = 8,
        EAutoReceiveInput_MAX = 9,
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x220)]
    public unsafe struct AActor // : UObject
    {
        [FieldOffset(0x005D)] public EActorUpdateOverlapsMethod UpdateOverlapsMethodDuringLevelStreaming;
        [FieldOffset(0x005E)] public EActorUpdateOverlapsMethod DefaultUpdateOverlapsMethodDuringLevelStreaming;
        [FieldOffset(0x005F)] public ENetRole RemoteRole;
        [FieldOffset(0x0060)] public FRepMovement ReplicatedMovement;
        [FieldOffset(0x0094)] public float InitialLifeSpan;
        [FieldOffset(0x0098)] public float CustomTimeDilation;
        [FieldOffset(0x00A0)] public FRepAttachment AttachmentReplication;
        [FieldOffset(0x00E0)] public AActor* Owner;
        [FieldOffset(0x00E8)] public FName NetDriverName;
        [FieldOffset(0x00F0)] public ENetRole Role;
        [FieldOffset(0x00F1)] public ENetDormancy NetDormancy;
        [FieldOffset(0x00F2)] public ESpawnActorCollisionHandlingMethod SpawnCollisionHandlingMethod;
        [FieldOffset(0x00F3)] public EAutoReceiveInputType AutoReceiveInput;
        [FieldOffset(0x00F4)] public int InputPriority;
        //[FieldOffset(0x00F8)] public UInputComponent* InputComponent;
        [FieldOffset(0x00F8)] public nint InputComponent;
        [FieldOffset(0x0100)] public float NetCullDistanceSquared;
        [FieldOffset(0x0104)] public int NetTag;
        [FieldOffset(0x0108)] public float NetUpdateFrequency;
        [FieldOffset(0x010C)] public float MinNetUpdateFrequency;
        [FieldOffset(0x0110)] public float NetPriority;
        //[FieldOffset(0x0118)] public APawn* Instigator;
        [FieldOffset(0x0118)] public nint Instigator;
        [FieldOffset(0x0120)] public TArray<nint> Children;
        //[FieldOffset(0x0130)] public USceneComponent* RootComponent;
        [FieldOffset(0x0130)] public nint RootComponent;
        [FieldOffset(0x0138)] public TArray<nint> ControllingMatineeActors;
        [FieldOffset(0x0150)] public TArray<FName> Layers;
        //[FieldOffset(0x0160)] public UChildActorComponent* ParentComponent;
        [FieldOffset(0x0160)] public nint ParentComponent;
        [FieldOffset(0x0170)] public TArray<FName> Tags;
    }
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct FGuid
    {

    }

    [StructLayout(LayoutKind.Explicit, Size = 0x440)]
    public unsafe struct UMaterial //: public UMaterialInterface
    {
    };

    [StructLayout(LayoutKind.Explicit, Size = 0xb8)]
    public unsafe struct USubsurfaceProfile //: public UObject
    {
        [FieldOffset(0x0028)] FSubsurfaceProfileStruct Settings;

    };
    [StructLayout(LayoutKind.Explicit, Size = 0x8c)]
    public unsafe struct FSubsurfaceProfileStruct
    {
        [FieldOffset(0x0000)] public FColor SurfaceAlbedo;
        [FieldOffset(0x0010)] public FColor MeanFreePathColor;
        [FieldOffset(0x0020)] public float MeanFreePathDistance;
        [FieldOffset(0x0024)] public float WorldUnitScale;
        [FieldOffset(0x0028)] public bool bEnableBurley;
        [FieldOffset(0x002C)] public float ScatterRadius;
        [FieldOffset(0x0030)] public FColor SubsurfaceColor;
        [FieldOffset(0x0040)] public FColor FalloffColor;
        [FieldOffset(0x0050)] public FColor BoundaryColorBleed;
        [FieldOffset(0x0060)] public float ExtinctionScale;
        [FieldOffset(0x0064)] public float NormalScale;
        [FieldOffset(0x0068)] public float ScatteringDistribution;
        [FieldOffset(0x006C)] public float IOR;
        [FieldOffset(0x0070)] public float Roughness0;
        [FieldOffset(0x0074)] public float Roughness1;
        [FieldOffset(0x0078)] public float LobeMix;
        [FieldOffset(0x007C)] public FColor TransmissionTintColor;

    };

    public unsafe struct FLightmassMaterialInterfaceSettings
    {
        float EmissiveBoost;                                                              // 0x0000 (size: 0x4)
        float DiffuseBoost;                                                               // 0x0004 (size: 0x4)
        float ExportResolutionScale;                                                      // 0x0008 (size: 0x4)
        //byte bCastShadowAsMasked;                                                        // 0x000C (size: 0x1)
        //byte bOverrideCastShadowAsMasked;                                                // 0x000C (size: 0x1)
        //byte bOverrideEmissiveBoost;                                                     // 0x000C (size: 0x1)
        //byte bOverrideDiffuseBoost;                                                      // 0x000C (size: 0x1)
        //byte bOverrideExportResolutionScale;                                             // 0x000C (size: 0x1)

    }; // Size: 0x10

    public unsafe struct FMaterialTextureInfo
    {
        float SamplingScale;                                                              // 0x0000 (size: 0x4)
        int UVChannelIndex;                                                                 // 0x0004 (size: 0x4)
        FName TextureName;                                                                // 0x0008 (size: 0x8)

    }; // Size: 0x10

    [StructLayout(LayoutKind.Explicit, Size = 0x88)]
    public unsafe struct UMaterialInterface //: public UObject
    {
        [FieldOffset(0x0038)] public USubsurfaceProfile* SubsurfaceProfile;
        [FieldOffset(0x0050)] public FLightmassMaterialInterfaceSettings LightmassSettings;
        [FieldOffset(0x0060)] public TArray<FMaterialTextureInfo> TextureStreamingData;
        [FieldOffset(0x0070)] public TArray<nint> AssetUserData;

        public unsafe UMaterial* GetBaseMaterial(IReloadedHooks hooks)
        {
            fixed (UMaterialInterface* self = &this)
            {
                var getBaseMaterialVtablePtr = *(nint*)(*(nint*)self + 0x278); // Call UMaterialInterface::GetBaseMaterial
                var getBaseMaterialFunc = hooks.CreateWrapper<UMaterialInterface_GetBaseMaterial>(getBaseMaterialVtablePtr, out _);
                return getBaseMaterialFunc.Invoke(self);
            }
        }

        private unsafe delegate UMaterial* UMaterialInterface_GetBaseMaterial(UMaterialInterface* self);
    };

    public enum EFrictionCombineModeType : byte
    {
        Average = 0,
        Min = 1,
        Multiply = 2,
        Max = 3,
    };

    public enum EPhysicalSurface : byte
    {
        SurfaceType_Default = 0,
        SurfaceType1 = 1,
        SurfaceType2 = 2,
        SurfaceType3 = 3,
        SurfaceType4 = 4,
        SurfaceType5 = 5,
        SurfaceType6 = 6,
        SurfaceType7 = 7,
        SurfaceType8 = 8,
        SurfaceType9 = 9,
        SurfaceType10 = 10,
        SurfaceType11 = 11,
        SurfaceType12 = 12,
        SurfaceType13 = 13,
        SurfaceType14 = 14,
        SurfaceType15 = 15,
        SurfaceType16 = 16,
        SurfaceType17 = 17,
        SurfaceType18 = 18,
        SurfaceType19 = 19,
        SurfaceType20 = 20,
        SurfaceType21 = 21,
        SurfaceType22 = 22,
        SurfaceType23 = 23,
        SurfaceType24 = 24,
        SurfaceType25 = 25,
        SurfaceType26 = 26,
        SurfaceType27 = 27,
        SurfaceType28 = 28,
        SurfaceType29 = 29,
        SurfaceType30 = 30,
        SurfaceType31 = 31,
        SurfaceType32 = 32,
        SurfaceType33 = 33,
        SurfaceType34 = 34,
        SurfaceType35 = 35,
        SurfaceType36 = 36,
        SurfaceType37 = 37,
        SurfaceType38 = 38,
        SurfaceType39 = 39,
        SurfaceType40 = 40,
        SurfaceType41 = 41,
        SurfaceType42 = 42,
        SurfaceType43 = 43,
        SurfaceType44 = 44,
        SurfaceType45 = 45,
        SurfaceType46 = 46,
        SurfaceType47 = 47,
        SurfaceType48 = 48,
        SurfaceType49 = 49,
        SurfaceType50 = 50,
        SurfaceType51 = 51,
        SurfaceType52 = 52,
        SurfaceType53 = 53,
        SurfaceType54 = 54,
        SurfaceType55 = 55,
        SurfaceType56 = 56,
        SurfaceType57 = 57,
        SurfaceType58 = 58,
        SurfaceType59 = 59,
        SurfaceType60 = 60,
        SurfaceType61 = 61,
        SurfaceType62 = 62,
        SurfaceType_Max = 63,
        EPhysicalSurface_MAX = 64,
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x80)]
    public unsafe struct UPhysicalMaterial //: public UObject
    {
        [FieldOffset(0x0028)] public float Friction;
        [FieldOffset(0x002C)] public float StaticFriction;
        [FieldOffset(0x0030)] public EFrictionCombineModeType FrictionCombineMode;
        [FieldOffset(0x0031)] public bool bOverrideFrictionCombineMode;
        [FieldOffset(0x0034)] public float Restitution;
        [FieldOffset(0x0038)] public EFrictionCombineModeType RestitutionCombineMode;
        [FieldOffset(0x0039)] public bool bOverrideRestitutionCombineMode;
        [FieldOffset(0x003C)] public float Density;
        [FieldOffset(0x0040)] public float SleepLinearVelocityThreshold;
        [FieldOffset(0x0044)] public float SleepAngularVelocityThreshold;
        [FieldOffset(0x0048)] public int SleepCounterThreshold;
        [FieldOffset(0x004C)] public float RaiseMassToPower;
        [FieldOffset(0x0050)] public float DestructibleDamageThresholdScale;
        [FieldOffset(0x0060)] public EPhysicalSurface SurfaceType;
    };

    public enum EMaterialParameterAssociation : byte
    {
        LayerParameter = 0,
        BlendParameter = 1,
        GlobalParameter = 2,
        EMaterialParameterAssociation_MAX = 3,
    };
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public unsafe struct FMaterialParameterInfo
    {
        [FieldOffset(0x0000)] public FName Name;
        [FieldOffset(0x0008)] public EMaterialParameterAssociation Association;
        [FieldOffset(0x000C)] public int Index;

        public string FormatString(FNamePool* namePool) => $"{namePool->GetString(Name.pool_location)}, {Association}, {Index}";
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x24)]
    public unsafe struct FScalarParameterValue
    {
        [FieldOffset(0x0000)] public FMaterialParameterInfo ParameterInfo;
        [FieldOffset(0x0010)] public float ParameterValue;
        [FieldOffset(0x0014)] public FGuid ExpressionGUID;

    };
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public unsafe struct FVectorParameterValue
    {
        [FieldOffset(0x0000)] public FMaterialParameterInfo ParameterInfo;
        [FieldOffset(0x0010)] public FColor ParameterValue;
        [FieldOffset(0x0020)] public FGuid ExpressionGUID;

    }; // Size: 0x30
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe struct FTextureParameterValue
    {
        [FieldOffset(0x0000)] public FMaterialParameterInfo ParameterInfo;
        [FieldOffset(0x0010)] public UTexture* ParameterValue;
        [FieldOffset(0x0018)] public FGuid ExpressionGUID;

    }; // Size: 0x28
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public unsafe struct FRuntimeVirtualTextureParameterValue
    {
        [FieldOffset(0x0000)] public FMaterialParameterInfo ParameterInfo;
        //[FieldOffset(0x0010)] public URuntimeVirtualTexture* ParameterValue;
        [FieldOffset(0x0018)] public FGuid ExpressionGUID;

    }; // Size: 0x28
    [StructLayout(LayoutKind.Explicit, Size = 0x30)]
    public unsafe struct FFontParameterValue
    {
        [FieldOffset(0x0000)] public FMaterialParameterInfo ParameterInfo;
        //[FieldOffset(0x0010)] public class UFont* FontValue;
        [FieldOffset(0x0018)] public int FontPage;
        [FieldOffset(0x001C)] public FGuid ExpressionGUID;

    }; // Size: 0x30

    [StructLayout(LayoutKind.Explicit, Size = 0x310)]
    public unsafe struct UMaterialInstance //: public UMaterialInterface
    {
        [FieldOffset(0x0088)] public UPhysicalMaterial* PhysMaterial;
        [FieldOffset(0x0090)] public UPhysicalMaterial* PhysicalMaterialMap;
        [FieldOffset(0x00D0)] public UMaterialInterface* Parent;
        //[FieldOffset(0x00D8)] public //uint8 bHasStaticPermutationResource;
        //[FieldOffset(0x00D8)] public //uint8 bOverrideSubsurfaceProfile;
        [FieldOffset(0x00E0)] public TArray<FScalarParameterValue> ScalarParameterValues;
        [FieldOffset(0x00F0)] public TArray<FVectorParameterValue> VectorParameterValues;
        [FieldOffset(0x0100)] public TArray<FTextureParameterValue> TextureParameterValues;
        [FieldOffset(0x0110)] public TArray<FRuntimeVirtualTextureParameterValue> RuntimeVirtualTextureParameterValues;
        [FieldOffset(0x0120)] public TArray<FFontParameterValue> FontParameterValues;
        //[FieldOffset(0x0130)] public //FMaterialInstanceBasePropertyOverrides BasePropertyOverrides;
        //[FieldOffset(0x0148)] public //FStaticParameterSet StaticParameters;
        //[FieldOffset(0x0188)] public //FMaterialCachedParameters CachedLayerParameters;
        //[FieldOffset(0x02D8)] public //TArray<class UObject*> CachedReferencedTextures;
    };
    [StructLayout(LayoutKind.Explicit, Size = 0x360)]
    public unsafe struct UMaterialInstanceDynamic // : public UMaterialInstance
    {

    }

    // FOR BLUEPRINTS

    [StructLayout(LayoutKind.Explicit, Size = 0x98)]
    public unsafe struct FFrame
    {
        [FieldOffset(0x10)] public UFunction* Node;
        [FieldOffset(0x18)] public UFunction* Object;
        [FieldOffset(0x20)] public byte* Code;
        [FieldOffset(0x28)] public byte* Locals;
        [FieldOffset(0x30)] public FProperty* MostRecentProperty;
        [FieldOffset(0x38)] public byte* MostRecentPropertyAddress;
        [FieldOffset(0x70)] public FFrame* PreviousFrame;
        [FieldOffset(0x80)] public FField* PropertyChainForCompiledIn;
        [FieldOffset(0x88)] public UFunction* CurrentNativeFunction;
        [FieldOffset(0x90)] public bool bArrayContextFailed;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x798)]
    public unsafe struct UWorld //: public UObject
    {
        //[FieldOffset(0x0030)] public ULevel* PersistentLevel;
        //[FieldOffset(0x0038)] public UNetDriver* NetDriver;
        //[FieldOffset(0x0040)] public ULineBatchComponent* LineBatcher;
        //[FieldOffset(0x0048)] public ULineBatchComponent* PersistentLineBatcher;
        //[FieldOffset(0x0050)] public ULineBatchComponent* ForegroundLineBatcher;
        //[FieldOffset(0x0058)] public AGameNetworkManager* NetworkManager;
        //[FieldOffset(0x0060)] public UPhysicsCollisionHandler* PhysicsCollisionHandler;
        //[FieldOffset(0x0068)] public TArray<nint> ExtraReferencedObjects;
        //[FieldOffset(0x0078)] public TArray<nint> PerModuleDataObjects;
        //[FieldOffset(0x0088)] public TArray<nint> StreamingLevels;
        //[FieldOffset(0x0098)] public FStreamingLevelsToConsider StreamingLevelsToConsider;
        //[FieldOffset(0x00C0)] public FString StreamingLevelsPrefix;
        //[FieldOffset(0x00D0)] public ULevel* CurrentLevelPendingVisibility;
        //[FieldOffset(0x00D8)] public ULevel* CurrentLevelPendingInvisibility;
        //[FieldOffset(0x00E0)] public UDemoNetDriver* DemoNetDriver;
        //[FieldOffset(0x00E8)] public AParticleEventManager* MyParticleEventManager;
        //[FieldOffset(0x00F0)] public APhysicsVolume* DefaultPhysicsVolume;
        //[FieldOffset(0x010E)] public byte bAreConstraintsDirty;
        //[FieldOffset(0x0110)] public UNavigationSystemBase* NavigationSystem;
        //[FieldOffset(0x0118)] public AGameModeBase* AuthorityGameMode;
        //[FieldOffset(0x0120)] public AGameStateBase* GameState;
        //[FieldOffset(0x0128)] public UAISystemBase* AISystem;
        //[FieldOffset(0x0130)] public UAvoidanceManager* AvoidanceManager;
        //[FieldOffset(0x0138)] public TArray<nint> Levels;
        //[FieldOffset(0x0148)] public TArray<FLevelCollection> LevelCollections;
        //[FieldOffset(0x0180)] public UGameInstance* OwningGameInstance;
        //[FieldOffset(0x0188)] public TArray<nint> ParameterCollectionInstances;
        //[FieldOffset(0x0198)] public UCanvas* CanvasForRenderingToTarget;
        //[FieldOffset(0x01A0)] public UCanvas* CanvasForDrawMaterialToRenderTarget;
        //[FieldOffset(0x01F8)] public UPhysicsFieldComponent* PhysicsField;
        //[FieldOffset(0x0200)] public TSet<UActorComponent*> ComponentsThatNeedPreEndOfFrameSync;
        //[FieldOffset(0x0250)] public TArray<nint> ComponentsThatNeedEndOfFrameUpdate;
        //[FieldOffset(0x0260)] public TArray<nint> ComponentsThatNeedEndOfFrameUpdate_OnGameThread;
        //[FieldOffset(0x05E0)] public UWorldComposition* WorldComposition;
        //[FieldOffset(0x0678)] public FWorldPSCPool PSCPool;
    };

    public enum ERichCurveExtrapolation : byte
    {
        RCCE_Cycle = 0,
        RCCE_CycleWithOffset = 1,
        RCCE_Oscillate = 2,
        RCCE_Linear = 3,
        RCCE_Constant = 4,
        RCCE_None = 5,
    };

    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public unsafe struct FRealCurve //: public FIndexedCurve
    {
        [FieldOffset(0x0068)] public float DefaultValue;                                                               //  (size: 0x4)
        [FieldOffset(0x006C)] public ERichCurveExtrapolation PreInfinityExtrap;                           //  (size: 0x1)
        [FieldOffset(0x006D)] public ERichCurveExtrapolation PostInfinityExtrap;                          //  (size: 0x1)

    }; // Size: 0x70

    public enum ERichCurveInterpMode : byte
    {
        RCIM_Linear = 0,
        RCIM_Constant = 1,
        RCIM_Cubic = 2,
        RCIM_None = 3,
    };

    public enum ERichCurveTangentMode : byte
    {
        RCTM_Auto = 0,
        RCTM_User = 1,
        RCTM_Break = 2,
        RCTM_None = 3,
    };

    public enum ERichCurveTangentWeightMode : byte
    {
        RCTWM_WeightedNone = 0,
        RCTWM_WeightedArrive = 1,
        RCTWM_WeightedLeave = 2,
        RCTWM_WeightedBoth = 3,
    };

    public unsafe struct FRichCurveKey
    {
        ERichCurveInterpMode InterpMode;                                     // 0x0000 (size: 0x1)
        ERichCurveTangentMode TangentMode;                                   // 0x0001 (size: 0x1)
        ERichCurveTangentWeightMode TangentWeightMode;                       // 0x0002 (size: 0x1)
        float Time;                                                                       // 0x0004 (size: 0x4)
        float Value;                                                                      // 0x0008 (size: 0x4)
        float ArriveTangent;                                                              // 0x000C (size: 0x4)
        float ArriveTangentWeight;                                                        // 0x0010 (size: 0x4)
        float LeaveTangent;                                                               // 0x0014 (size: 0x4)
        float LeaveTangentWeight;                                                         // 0x0018 (size: 0x4)

    }; // Size: 0x1C

    [StructLayout(LayoutKind.Explicit, Size = 0x80)]
    public struct FRichCurve //: public FRealCurve
    {
        [FieldOffset(0x0070)] TArray <FRichCurveKey> Keys;                                                       // 0x0070 (size: 0x10)
    }; // Size: 0x80

    [StructLayout(LayoutKind.Explicit, Size = 0x250)]
    public unsafe struct UCurveLinearColor //: public UCurveBase
    {
        [FieldOffset(0x0030)] public FRichCurve FloatCurves;
        [FieldOffset(0x0230)] public float AdjustHue;
        [FieldOffset(0x0234)] public float AdjustSaturation;
        [FieldOffset(0x0238)] public float AdjustBrightness;
        [FieldOffset(0x023C)] public float AdjustBrightnessCurve;
        [FieldOffset(0x0240)] public float AdjustVibrance;
        [FieldOffset(0x0244)] public float AdjustMinAlpha;
        [FieldOffset(0x0248)] public float AdjustMaxAlpha;
    }; // Size: 0x250
}
