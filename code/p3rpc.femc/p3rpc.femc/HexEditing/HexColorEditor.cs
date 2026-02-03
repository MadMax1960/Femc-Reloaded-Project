using p3rpc.commonmodutils;
using p3rpc.femc.Configuration;
using Reloaded.Memory.Extensions;
using Reloaded.Mod.Interfaces;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using static p3rpc.femc.HexEditing.HexColorEditor;

namespace p3rpc.femc.HexEditing
{
    public static class HexColorEditor
    {
        public enum ComponentType
        {
            BYTE,
            FLOAT,
            hFLOAT
        }
        public enum ColorOrder
        {
            RGBA,
            ARGB,
            BGRA,
            RGB,
            BGR
        }
        /// <param name="filePath">Absolute path to the file to edit.</param>
        /// <param name="offset">Offset in bytes where the color should be written.</param>
        /// <param name="color">The color value to inject.</param>
        /// <param name="order">Byte order used for the color value.</param>
        /// <param name="type">Component type in the hex file.</param>
        public static void WriteColor(string filePath, long offset, ConfigColor color, ColorOrder order = ColorOrder.RGBA, ComponentType type = ComponentType.BYTE)
        {
            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.Read);
            WriteColor(stream, offset, color, order, type);
        }
        
        /// <param name="stream">Stream of the file to edit.</param>
        /// <param name="offset">Offset in bytes where the color should be written.</param>
        /// <param name="color">The color value to inject.</param>
        /// <param name="order">Byte order used for the color value.</param>
        /// <param name="type">Component type in the hex file.</param>
        public static void WriteColor(FileStream stream, long offset, ConfigColor color, ColorOrder order = ColorOrder.RGBA, ComponentType type = ComponentType.BYTE)
        {
            var bytes = order switch
            { 
                ColorOrder.RGB => CreateColorComponents(new[] { color.R, color.G, color.B }, type),
                ColorOrder.BGR => CreateColorComponents(new[] { color.B, color.G, color.R }, type),
                ColorOrder.RGBA => CreateColorComponents(new[] { color.R, color.G, color.B, color.A }, type),
                ColorOrder.ARGB => CreateColorComponents(new[] { color.A, color.R, color.G, color.B }, type),
                ColorOrder.BGRA => CreateColorComponents(new[] { color.B, color.G, color.R, color.A }, type),
                _ => throw new ArgumentOutOfRangeException(nameof(order), order, null)
            };
            stream.Seek(offset, SeekOrigin.Begin);
            stream.Write(bytes, 0, bytes.Length);
        }

        private static byte[] CreateColorComponents(byte[] components, ComponentType type)
        {
            List<byte> bytes = new List<byte>();

            switch (type)
            {
                case ComponentType.BYTE:
                    return components;

                case ComponentType.FLOAT:
                    foreach (byte component in components)
                    {
                        float floatComponent = component / 255.0f;
                        byte[] floatComponentBytes = BitConverter.GetBytes(floatComponent);

                        bytes.AddRange(floatComponentBytes);
                    }
                    break;

                case ComponentType.hFLOAT:
                    foreach (byte component in components)
                    {
                        Half hFloatComponent = (Half) ((float) component / 255.0f);
                        ushort bits = BitConverter.ToUInt16(BitConverter.GetBytes(hFloatComponent), 0);

                        byte lo = (byte) (bits & 0xFF);
                        byte hi = (byte) ((bits >> 8) & 0xFF);

                        byte[] hFloatComponentBytes = new[] {lo, hi};

                        bytes.AddRange(hFloatComponentBytes);
                    }
                    break;
            }

            return bytes.ToArray();
        }

        /// <param name="filePath">Absolute path to the file to edit</param>
        /// <param name="offset">Offset in bytes where the color curve should be written</param>
        /// <param name="colorKeyframes">A dictionary (0s-1s time, color) that will be used to interpolate all colors of the curve</param>
        /// <param name="size">Size of the color curve, default is 64 since most of them are this long</param>
        public static void WriteColorCurve(string filePath, long offset, Dictionary<float, ConfigColor> colorKeyframes, int size = 64)
        {
            if (colorKeyframes.Count < 2)
                throw new ArgumentException("At least two keyframes are needed to create a color curve", nameof(colorKeyframes));

            // Order keyframes just in case
            var sortedKeyFrames = colorKeyframes.Keys.OrderBy(k => k).ToList();

            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.Read);
            stream.Seek(offset, SeekOrigin.Begin);

            // These color curves have "size" colors
            float totalTime = (float) size - 1.0f;
            for (int i = 0; i < size; i++)
            {
                float actTime = i / totalTime;

                for (int j = 0; j < sortedKeyFrames.Count - 1; j++)
                {
                    float t1 = sortedKeyFrames[j];
                    float t2 = sortedKeyFrames[j + 1];

                    if (actTime >= t1 && actTime <= t2)
                    {
                        ConfigColor c1 = colorKeyframes[t1];
                        ConfigColor c2 = colorKeyframes[t2];

                        float t = (actTime - t1) / (t2 - t1);

                        // Interpolate current color relative to current time frame
                        float r = (c1.R + t * (c2.R - c1.R)) / 255.0f;
                        float g = (c1.G + t * (c2.G - c1.G)) / 255.0f;
                        float b = (c1.B + t * (c2.B - c1.B)) / 255.0f;
                        float a = (c1.A + t * (c2.A - c1.A)) / 255.0f;

                        WriteHalf(stream, (Half) r);
                        WriteHalf(stream, (Half) g);
                        WriteHalf(stream, (Half) b);
                        WriteHalf(stream, (Half) a);

                        break;
                    }
                }
            }
        }

        public static void WriteHalf(Stream stream, Half value)
        {
            ushort bits = BitConverter.ToUInt16(BitConverter.GetBytes(value), 0);

            // We need lower byte and higher byte of our converted half
            byte lo = (byte) (bits & 0xFF);
            byte hi = (byte) ((bits >> 8) & 0xFF);

            stream.WriteByte(lo);
            stream.WriteByte(hi);
        }

        public static void WriteByte(string filePath, long offset, byte value)
        {
            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.Read);
            WriteByte(stream, offset, value);
        }

        public static void WriteByte(FileStream stream, long offset, byte value)
        {
            stream.Seek(offset, SeekOrigin.Begin);
            stream.WriteByte(value);
        }

        public static void WriteFloat(string filePath, long offset, float value)
        {
            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.Read);
            WriteFloat(stream, offset, value);
        }

        public static void WriteFloat(FileStream stream, long offset, float value)
        {
            byte[] floatComponentBytes = BitConverter.GetBytes(value);
            stream.Seek(offset, SeekOrigin.Begin);
            stream.Write(floatComponentBytes, 0, floatComponentBytes.Length);
        }

        /// <summary>
        /// Write into a Blueprint color stored as an FColor consisting of 4 byte properties (ByteConst = 0x24)
        /// in BGRA order.
        /// </summary>
        /// <param name="stream">Target filename</param>
        /// <param name="offset">Offset in file</param>
        /// <param name="color">Color to use</param>
        /// <param name="order">Color order</param>       
        public static void WriteBlueprintByteColor(string filePath, long offset, ConfigColor color,
            ColorOrder order = ColorOrder.BGRA)
        {
            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.Read);
            WriteBlueprintByteColor(stream, offset, color, order);
        }

        /// <summary>
        /// Write into a Blueprint color stored as an FColor consisting of 4 byte properties (ByteConst = 0x24)
        /// in BGRA order
        /// </summary>
        /// <param name="stream">Target filestream</param>
        /// <param name="offset">Offset in file</param>
        /// <param name="color">Color to use</param>
        /// <param name="order">Color order</param>
        public static void WriteBlueprintByteColor(FileStream stream, long offset, ConfigColor color,
            ColorOrder order = ColorOrder.BGRA)
        {
            // Their order is always BGR / BGRA
            /*
            if (!order.Equals(ColorOrder.BGR) && !order.Equals(ColorOrder.BGRA))
                throw new ArgumentException("Blueprint hardcoded colors must be either BGR or BGRA", nameof(order));

            var bytes = new byte[] { 0x24, color.B, 0x24, color.G, 0x24, color.R, 0x24, color.A };
            */

            if (!order.Equals(ColorOrder.BGR) && !order.Equals(ColorOrder.BGRA) && !order.Equals(ColorOrder.RGB))
                throw new ArgumentException("Blueprint hardcoded colors must be either BGR or BGRA or RGB", nameof(order));
            byte[] bytes;

            if (order == ColorOrder.BGRA)
            {
                bytes = new byte[] { 0x24, color.B, 0x24, color.G, 0x24, color.R, 0x24, color.A };
            }
            if (order == ColorOrder.BGR)
            {
                bytes = new byte[] { 0x24, color.B, 0x24, color.G, 0x24, color.R };
            }
            else
            {
                bytes = new byte[] { 0x24, color.R, 0x24, color.G, 0x24, color.B };
            }

            stream.Seek(offset, SeekOrigin.Begin);
            stream.Write(bytes, 0, bytes.Length);
        }

        /// <param name="filePath">Absolute path to the file to edit</param>
        /// <param name="offset">Offset in bytes where the BLUE component starts</param>
        /// <param name="color">New color value to be written</param>
        public static void WriteBlueprintSplitColor(string filePath, long offset, ConfigColor color, ColorOrder order = ColorOrder.BGRA)
        {
            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.Read);
            WriteBlueprintSplitColor(stream, offset, color, order);
        }
        /// <param name="stream">FileStream to make edits to</param>
        /// <param name="offset">Offset in bytes where the BLUE component starts</param>
        /// <param name="color">New color value to be written</param>
        public static void WriteBlueprintSplitColor(FileStream stream, long offset, ConfigColor color,
            ColorOrder order = ColorOrder.BGRA)
        {
            // Their order is always BGR / BGRA
            if (!order.Equals(ColorOrder.BGR) && !order.Equals(ColorOrder.BGRA))
                throw new ArgumentException("Blueprint hardcoded colors must be either BGR or BGRA", nameof(order));
            
            byte[] bytes = new[] { color.B, color.G, color.R, color.A };
            
            stream.Seek(offset, SeekOrigin.Begin);
            stream.WriteByte(color.B);

            stream.Seek(offset+0x35, SeekOrigin.Begin);
            stream.WriteByte(color.G);

            stream.Seek(offset + 0x6A, SeekOrigin.Begin);
            stream.WriteByte(color.R);

            if (order == ColorOrder.BGRA)
            {
                stream.Seek(offset + 0x9F, SeekOrigin.Begin);
                stream.WriteByte(color.A);
            }
        }
        public static void WriteBlueprintIDEKColor(string filePath, long offset, ConfigColor color, ColorOrder order = ColorOrder.BGRA)
        {
            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.Read);
            WriteBlueprintIDEKColor(stream, offset, color, order);
        }
        /// <param name="stream">FileStream to make edits to</param>
        /// <param name="offset">Offset in bytes where the BLUE component starts</param>
        /// <param name="color">New color value to be written</param>
        public static void WriteBlueprintIDEKColor(FileStream stream, long offset, ConfigColor color,
            ColorOrder order = ColorOrder.RGB)
        {
            // Their order is always BGR / BGRA
            if (!order.Equals(ColorOrder.RGB))
                throw new ArgumentException("Blueprint hardcoded colors must be either RGB or RGBA", nameof(order));

            byte[] bytes = new[] { color.R, color.G, color.B, color.A };

            stream.Seek(offset, SeekOrigin.Begin);
            stream.WriteByte(color.R);

            stream.Seek(offset + 0x22, SeekOrigin.Begin);
            stream.WriteByte(color.G);

            stream.Seek(offset + 0x44, SeekOrigin.Begin);
            stream.WriteByte(color.B);
        }
        public static void WriteBlueprintFloatColor(string filePath, long offset, ConfigColor color, ColorOrder order = ColorOrder.BGRA)
        {
            using FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Write, FileShare.Read);
            WriteBlueprintFloatColor(stream, offset, color, order);
        }

        /// <param name="filePath">Absolute path to the file to edit</param>
        /// <param name="offset">Offset in bytes where the BLUE component starts</param>
        /// <param name="color">New color value to be written</param>
        public static void WriteBlueprintFloatColor(FileStream stream, long offset, ConfigColor color, ColorOrder order = ColorOrder.BGR)
        {
            byte[] redBytes = BitConverter.GetBytes(color.R / 255f);
            byte[] greenBytes = BitConverter.GetBytes(color.G / 255f);
            byte[] blueBytes = BitConverter.GetBytes(color.B / 255f);

            byte fSeparator = 0x1E;
            byte[] bytes;

            if (order == ColorOrder.BGR) // 15 bytes
            {
                bytes = new byte[]
                {
                    fSeparator,
                    blueBytes[0], blueBytes[1], blueBytes[2], blueBytes[3],
                    fSeparator,
                    greenBytes[0], greenBytes[1], greenBytes[2], greenBytes[3],
                    fSeparator,
                    redBytes[0], redBytes[1], redBytes[2], redBytes[3]
                };
            }
            else // 15 bytes RGB
            {
                bytes = new byte[]
                {
                    fSeparator,
                    redBytes[0], redBytes[1], redBytes[2], redBytes[3],
                    fSeparator,
                    greenBytes[0], greenBytes[1], greenBytes[2], greenBytes[3],
                    fSeparator,
                    blueBytes[0], blueBytes[1], blueBytes[2], blueBytes[3],
                };
            }
            stream.Seek(offset, SeekOrigin.Begin);
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}