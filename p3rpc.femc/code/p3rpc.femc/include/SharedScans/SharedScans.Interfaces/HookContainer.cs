using Reloaded.Hooks.Definitions;

namespace SharedScans.Interfaces;

public class HookContainer<TFunction>
{
    public string Id { get; init; }

    public string Owner { get; init; }

    public TFunction HookFunction { get; init; }

    public IHook<TFunction>? Hook { get; set; }
}
