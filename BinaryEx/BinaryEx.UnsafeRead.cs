// Copyright (c) 2019-2022 Matthew Sitton <matthewsitton@gmail.com>
// MIT License - See LICENSE in the project root for license information.
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BinaryEx
{
    public static partial class BinaryEx
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UInt32 ReadUInt24LE(byte* buff, int offset)
        {
            UInt32 val = 0;
            Unsafe.CopyBlockUnaligned(ref Unsafe.As<UInt32, byte>(ref val), ref buff[offset], 3);
            return val;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UInt32 ReadUInt24BE(byte* buff, int offset)
        {
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
        public unsafe static Int32 ReadInt24LE(byte* buff, int offset)
        {
            Int32 val = (Int32)ReadUInt24LE(buff, offset);
            return val - (val >> 23 << 24);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static Int32 ReadInt24BE(byte* buff, int offset)
        {
            Int32 val = (Int32)ReadUInt24BE(buff, offset);
            return val - (val >> 23 << 24);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static Int64 ReadInt64LE(byte* buff, int offset)
        {
            return (Int64)ReadUInt64LE(buff, offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static Int64 ReadInt64BE(byte* buff, int offset)
        {
            return (Int64)ReadUInt64BE(buff, offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static Int32 ReadInt32LE(byte* buff, int offset)
        {
            return (Int32)ReadUInt32LE(buff, offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static Int32 ReadInt32BE(byte* buff, int offset)
        {
            return (Int32)ReadUInt32BE(buff, offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static Int16 ReadInt16LE(byte* buff, int offset)
        {
            return (Int16)ReadUInt16LE(buff, offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static Int16 ReadInt16BE(byte* buff, int offset)
        {
            return (Int16)ReadUInt16BE(buff, offset);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static sbyte ReadSByte(byte* buff, int offset)
        {
            return (sbyte)buff[offset];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UInt64 ReadUInt64LE(byte* buff, int offset)
        {
            return Unsafe.As<byte, UInt64>(ref buff[offset]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UInt64 ReadUInt64BE(byte* buff, int offset)
        {
            return SwapEndianess(Unsafe.As<byte, UInt64>(ref buff[offset]));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UInt32 ReadUInt32LE(byte* buff, int offset)
        {
            return Unsafe.As<byte, UInt32>(ref buff[offset]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UInt32 ReadUInt32BE(byte* buff, int offset)
        {
            return SwapEndianess(Unsafe.As<byte, UInt32>(ref buff[offset]));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UInt16 ReadUInt16LE(byte* buff, int offset)
        {
            return Unsafe.As<byte, UInt16>(ref buff[offset]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UInt16 ReadUInt16BE(byte* buff, int offset)
        {
            return SwapEndianess(Unsafe.As<byte, UInt16>(ref buff[offset]));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static byte ReadByte(byte* buff, int offset)
        {
            return buff[offset];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static int ReadBytes(byte* buff, int offset, byte[] output, int count)
        {
            Debug.Assert(count > 0);
            Unsafe.CopyBlockUnaligned(ref output[0], ref buff[offset], (uint)count);
            return count;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static int ReadBytes(byte* buff, int offset, Span<byte> output)
        {
            Unsafe.CopyBlockUnaligned(ref output[0], ref buff[offset], (uint)output.Length);
            return output.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static int ReadCountLE<T>(byte* buff, int offset, T[] output, int count) where T : unmanaged
        {
            var bytes = MemoryMarshal.AsBytes(output.AsSpan(0, count));
            Debug.Assert(count > 0);
            Unsafe.CopyBlockUnaligned(ref bytes[0], ref buff[offset], (uint)bytes.Length);
            return bytes.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static int ReadCountLE<T>(byte* buff, int offset, Span<T> output) where T : unmanaged
        {
            var bytes = MemoryMarshal.AsBytes(output);
            Unsafe.CopyBlockUnaligned(ref bytes[0], ref buff[offset], (uint)bytes.Length);
            return bytes.Length;
        }
    }
}