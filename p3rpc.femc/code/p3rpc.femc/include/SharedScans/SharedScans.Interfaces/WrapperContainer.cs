namespace SharedScans.Interfaces;

public class WrapperContainer<TFunction>
{
    public string Id { get; init; }

    public string Owner { get; init; }

    public TFunction Wrapper { get; set; }
}
