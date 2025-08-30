using System.Runtime.InteropServices;

namespace p3rpc.femc.Components
{
    internal class Native
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
        public static extern nint GetModuleHandleA(string lpModuleName);
    }
}
