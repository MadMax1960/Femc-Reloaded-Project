using Reloaded.Mod.Interfaces;
using System.Drawing;

namespace Project.Utils;

public static class Log
{
    private static string name = "Mod";
    private static ILogger? log;
    private static Color color = Color.White;
    private static bool alwaysAsync;

    public static void Initialize(string name, ILogger log, Color color, bool alwaysAsync = false)
    {
        Log.name = name;
        Log.log = log;
        Log.color = color;
        Log.alwaysAsync = alwaysAsync;
    }

    public static LogLevel LogLevel { get; set; } = LogLevel.Information;

    public static void Verbose(string message, bool useAsync = false)
    {
        if (LogLevel < LogLevel.Debug)
        {
            LogMessage(LogLevel.Verbose, message, useAsync);
        }
    }

    public static void Debug(string message, bool useAsync = false)
    {
        if (LogLevel < LogLevel.Information)
        {
            LogMessage(LogLevel.Debug, message, useAsync);
        }
    }

    public static void Information(string message, bool useAsync = false)
    {
        if (LogLevel < LogLevel.Warning)
        {
            LogMessage(LogLevel.Information, message, useAsync);
        }
    }

    public static void Warning(string message, bool useAsync = false)
    {
        if (LogLevel < LogLevel.Error)
        {
            LogMessage(LogLevel.Warning, message, useAsync);
        }
    }
    public static void Error(Exception ex, string message, bool useAsync = false)
    {
        LogMessage(LogLevel.Error, $"{message}\n{ex.Message}\n{ex.StackTrace}", useAsync);
    }

    public static void Error(string message, bool useAsync = false)
    {
        LogMessage(LogLevel.Error, message, useAsync);
    }

    private static void LogMessage(LogLevel level, string message, bool useAsync = false)
    {
        var color =
            level == LogLevel.Debug ? Color.LightGreen :
            level == LogLevel.Information ? Log.color :
            level == LogLevel.Error ? Color.Red :
            level == LogLevel.Warning ? Color.LightGoldenrodYellow :
            Color.White;

        if (useAsync || alwaysAsync)
        {
            log?.WriteLineAsync(FormatMessage(level, message), color);
        }
        else
        {
            log?.WriteLine(FormatMessage(level, message), color);
        }
    }

    private static string FormatMessage(LogLevel level, string message)
    {
        var levelStr =
            level == LogLevel.Verbose ? "[VRB]" :
            level == LogLevel.Debug ? "[DBG]" :
            level == LogLevel.Information ? "[INF]" :
            level == LogLevel.Warning ? "[WRN]" :
            level == LogLevel.Error ? "[ERR]" : string.Empty;

        return $"[{name}] {levelStr} {message}";
    }
}

public enum LogLevel
{
    Verbose,
    Debug,
    Information,
    Warning,
    Error,
}