// Copyright (c) 2019 Matthew Sitton <matthewsitton@gmail.com>
// See LICENSE in the project root for license information.
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BinaryEx
{
    public static partial class BinUtils
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt24LE(this byte[] buff, int offset)
        {
            Debug.Assert(buff.Length >= 3);
            UInt32 val = 0;

            Unsafe.CopyBlockUnaligned(ref Unsafe.As<UInt32, byte>(ref val), ref buff[offset], 3);
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt24BE(this byte[] buff, int offset)
        {
            Debug.Assert(buff.Length >= 3);
            UInt32 val = 0;
            unsafe
            {
                byte* dst = (byte*)Unsafe.AsPointer(ref val) + 1;
                byte* start = (byte*)Unsafe.AsPointer(ref buff[offset]);

                Unsafe.CopyBlockUnaligned(dst, start, 3);
            }
            return SwapEndianess(val);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int32 ReadInt24LE(this byte[] buff, int offset)
        {
            Int32 val = (Int32)buff.ReadUInt24LE(offset);
            return val - (val >> 23 << 24);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int32 ReadInt24BE(this byte[] buff, int offset)
        {
            Int32 val = (Int32)buff.ReadUInt24BE(offset);
            return val - (val >> 23 << 24);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 ReadInt64LE(this byte[] buff, int offset)
        {
            return (Int64)buff.ReadUInt64LE(offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 ReadInt64BE(this byte[] buff, int offset)
        {
            return (Int64)buff.ReadUInt64BE(offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int32 ReadInt32LE(this byte[] buff, int offset)
        {
            return (Int32)buff.ReadUInt32LE(offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int32 ReadInt32BE(this byte[] buff, int offset)
        {
            return (Int32)buff.ReadUInt32BE(offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int16 ReadInt16LE(this byte[] buff, int offset)
        {
            return (Int16)buff.ReadUInt16LE(offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int16 ReadInt16BE(this byte[] buff, int offset)
        {
            return (Int16)buff.ReadUInt16BE(offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static sbyte ReadSByte(this byte[] buff, int offset)
        {
            Debug.Assert(buff.Length >= Unsafe.SizeOf<byte>());
            return (sbyte)buff[offset];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt64 ReadUInt64LE(this byte[] buff, int offset)
        {
            Debug.Assert(buff.Length >= Unsafe.SizeOf<UInt64>());
            return Unsafe.As<byte, UInt64>(ref buff[offset]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt64 ReadUInt64BE(this byte[] buff, int offset)
        {
            Debug.Assert(buff.Length >= Unsafe.SizeOf<UInt64>());
            return SwapEndianess(Unsafe.As<byte, UInt64>(ref buff[offset]));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt32LE(this byte[] buff, int offset)
        {
            Debug.Assert(buff.Length >= Unsafe.SizeOf<UInt32>());
            return Unsafe.As<byte, UInt32>(ref buff[offset]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt32 ReadUInt32BE(this byte[] buff, int offset)
        {
            Debug.Assert(buff.Length >= Unsafe.SizeOf<UInt32>());
            return SwapEndianess(Unsafe.As<byte, UInt32>(ref buff[offset]));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt16 ReadUInt16LE(this byte[] buff, int offset)
        {
            Debug.Assert(buff.Length >= Unsafe.SizeOf<UInt16>());
            return Unsafe.As<byte, UInt16>(ref buff[offset]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt16 ReadUInt16BE(this byte[] buff, int offset)
        {
            Debug.Assert(buff.Length >= Unsafe.SizeOf<UInt16>());
            return SwapEndianess(Unsafe.As<byte, UInt16>(ref buff[offset]));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static byte ReadByte(this byte[] buff, int offset)
        {
            Debug.Assert(buff.Length >= Unsafe.SizeOf<byte>());
            return buff[offset];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ReadBytes(this byte[] data, int offset, byte[] output, UInt32 count)
        {
            Unsafe.CopyBlockUnaligned(ref output[0], ref data[offset], count);
            return (int)count;
        }

        public static int ReadCountLE<T>(this byte[] data, int offset, T[] output, UInt32 count) where T : unmanaged
        {
            unsafe
            {
                uint outputByteSize = (uint)Unsafe.SizeOf<T>() * count;

                Debug.Assert(outputByteSize >= count);
                byte* outStart = (byte*)Unsafe.AsPointer<T>(ref output[0]);

                Unsafe.CopyBlockUnaligned(ref Unsafe.AsRef<byte>(outStart), ref data[offset], outputByteSize);
                return (int)outputByteSize;
            }
        }
    }
}