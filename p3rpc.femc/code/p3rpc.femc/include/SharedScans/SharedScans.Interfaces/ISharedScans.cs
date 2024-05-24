namespace SharedScans.Interfaces;

public interface ISharedScans
{
    /// <summary>
    /// Add a scan with the given Scan ID.
    /// </summary>
    /// <param name="id">Scan ID.</param>
    /// <param name="pattern">Scan pattern.</param>
    void AddScan(string id, string? pattern);

    /// <summary>
    /// Add a scan for a function using <typeparamref name="TFunction"/>'s name for the Scan ID.
    /// </summary>
    /// <typeparam name="TFunction">Function scan is for.</typeparam>
    /// <param name="pattern">Scan pattern. If null then scan is skipped.</param>
    void AddScan<TFunction>(string? pattern);

    /// <summary>
    /// Create a Reloaded hook for the given function, once the given
    /// function is successfully found.
    /// </summary>
    /// <typeparam name="TFunction">Function.</typeparam>
    /// <param name="hookFunction">The hooking function.</param>
    /// <param name="owner">Hook owner.</param>
    /// <returns>Hook container. Use to call original function and keep reference to hook.</returns>
    HookContainer<TFunction> CreateHook<TFunction>(TFunction hookFunction, string owner);

    /// <summary>
    /// Create a Reloaded wrapper for the given function, once the given
    /// function is successfully found.
    /// </summary>
    /// <typeparam name="TFunction">Function.</typeparam>
    /// <param name="owner">Wrapper owner.</param>
    /// <returns>Wrapper container. Use to call original function.</returns>
    WrapperContainer<TFunction> CreateWrapper<TFunction>(string owner);

    /// <summary>
    /// Creates a listener for a scan with the given ID.
    /// Once found the callback is passed the scan result.
    /// </summary>
    /// <param name="id">Scan ID.</param>
    /// <param name="success">Success callback.</param>
    void CreateListener(string id, Action<nint> success);

    /// <summary>
    /// Creates a listener for a scan using <typeparamref name="TFunction"/>'s name for the Scan ID.
    /// </summary>
    /// <param name="success">Success callback.</param>
    void CreateListener<TFunction>(Action<nint> success);
}
