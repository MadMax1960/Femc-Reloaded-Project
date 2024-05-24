#define CRI_FS_API
#undef CRI_FS_API // Remove to enable.

#if CRI_FS_API
using CriFs.V2.Hook.Interfaces;

namespace Project.Utils;

public static class ICriFsRedirectorApiExtensions
{
    public static void AddBind(
        this ICriFsRedirectorApi api,
        string file,
        string bindPath,
        string modId)
    {
        api.AddBindCallback(context =>
        {
            context.RelativePathToFileMap[$@"R2\{bindPath}"] = new()
            {
                new()
                {
                    FullPath = file,
                    LastWriteTime = DateTime.UtcNow,
                    ModId = modId,
                },
            };

            Log.Verbose($"Bind: {bindPath}\nFile: {file}");
        });
    }
}
#endif