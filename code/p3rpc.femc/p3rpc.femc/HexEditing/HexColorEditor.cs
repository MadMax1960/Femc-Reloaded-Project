using p3rpc.commonmodutils;
using p3rpc.femc.Configuration;
using System;
using System.IO;

namespace p3rpc.femc.HexEditing
{
    public static class HexColorEditor
    {
        public enum ColorOrder
        {
            RGBA,
            ARGB,
            BGRA,
            RGB
        }
        /// <param name="filePath">Absolute path to the file to edit.</param>
        /// <param name="offset">Offset in bytes where the colour should be written.</param>
        /// <param name="color">The colour value to inject.</param>
        /// <param name="order">Byte order used for the colour value.</param>
        public static void WriteColor(string filePath, long offset, ConfigColor color, ColorOrder order = ColorOrder.RGBA)
        {
            byte[] bytes;

            if (order == ColorOrder.RGB)
            {
                bytes = new[] { color.R, color.G, color.B };
            }
            else
            {
                bytes = order switch
                {
                    ColorOrder.RGBA => new[] { color.R, color.G, color.B, color.A },
                    ColorOrder.ARGB => new[] { color.A, color.R, color.G, color.B },
                    ColorOrder.BGRA => new[] { color.B, color.G, color.R, color.A },
                    _ => throw new ArgumentOutOfRangeException(nameof(order), order, null)
                };
            }

            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.Read);
            stream.Seek(offset, SeekOrigin.Begin);
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}