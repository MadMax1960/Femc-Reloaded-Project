using Reloaded.Mod.Interfaces;
using System.Drawing;

namespace BGME.BattleThemes;

public static class Log
{
    public static ILogger? Logger { get; set; }

    public static LogLevel LogLevel { get; set; } = LogLevel.Information;

    public static void Verbose(string message)
    {
        if (LogLevel < LogLevel.Debug)
        {
            LogMessage(LogLevel.Verbose, message);
        }
    }

    public static void Debug(string message)
    {
        if (LogLevel < LogLevel.Information)
        {
            LogMessage(LogLevel.Debug, message);
        }
    }

    public static void Information(string message)
    {
        if (LogLevel < LogLevel.Warning)
        {
            LogMessage(LogLevel.Information, message);
        }
    }

    public static void Warning(string message)
    {
        if (LogLevel < LogLevel.Error)
        {
            LogMessage(LogLevel.Warning, message);
        }
    }
    public static void Error(Exception ex, string message)
    {
        LogMessage(LogLevel.Error, $"{message}\n{ex.Message}\n{ex.StackTrace}");
    }

    public static void Error(string message)
    {
        LogMessage(LogLevel.Error, message);
    }

    private static void LogMessage(LogLevel level, string message)
    {
        var color =
            level == LogLevel.Debug ? Color.LightGreen :
            level == LogLevel.Information ? Color.FromArgb(0xb3b6ff) :
            level == LogLevel.Error ? Color.Red :
            level == LogLevel.Warning ? Color.LightGoldenrodYellow :
            Color.White;

        Logger?.WriteLine(FormatMessage(level, message), color);
    }

    private static string FormatMessage(LogLevel level, string message)
    {
        var levelStr =
            level == LogLevel.Verbose ? "[VRB]" :
            level == LogLevel.Debug ? "[DBG]" :
            level == LogLevel.Information ? "[INF]" :
            level == LogLevel.Warning ? "[WRN]" :
            level == LogLevel.Error ? "[ERR]" : string.Empty;

        return $"[BGME Battle Themes] {levelStr} {message}";
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