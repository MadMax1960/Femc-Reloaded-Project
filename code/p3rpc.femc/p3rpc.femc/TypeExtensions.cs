using UE.Toolkit.Core.Types.Unreal.UE5_4_4;

namespace p3rpc.femc;

public static class TypeExtensions
{
    public static FName FromNT(this p3rpc.nativetypes.Interfaces.FName name)
        => new()
        {
            ComparisonIndex = new FNameEntryId { Value = name.pool_location },
            Number = new FNameEntryId { Value = name.field04 }
        };

    public static p3rpc.nativetypes.Interfaces.FName ToNT(this FName name)
        => new()
        {
            pool_location = name.ComparisonIndex.Value,
            field04 = name.Number.Value
        };
}