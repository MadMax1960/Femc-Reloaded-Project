using System.ComponentModel;
using Unreal.ObjectsEmitter.Reloaded.Template.Configuration;

namespace Unreal.ObjectsEmitter.Reloaded.Configuration;

public class Config : Configurable<Config>
{
    [DisplayName("Log Level")]
    [DefaultValue(LogLevel.Information)]
    public LogLevel LogLevel { get; set; } = LogLevel.Information;

    [DisplayName("Log DataTables")]
    [DefaultValue(false)]
    public bool LogTables { get; set; } = false;

    [DisplayName("Log UObjects")]
    [DefaultValue(false)]
    public bool LogObjects { get; set; } = false;
}

/// <summary>
/// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
/// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
/// </summary>
public class ConfiguratorMixin : ConfiguratorMixinBase
{
    // 
}