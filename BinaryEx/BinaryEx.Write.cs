// Copyright (c) 2019-2022 Matthew Sitton <matthewsitton@gmail.com>
// MIT License - See LICENSE in the project root for license information.
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BinaryEx
{
    public static partial class BinaryEx
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt64BE(this byte[] buff, int offset, Int64 value)
        {
            WriteUInt64BE(buff, offset, (UInt64)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt64LE(this byte[] buff, int offset, Int64 value)
        {
            WriteUInt64LE(buff, offset, (UInt64)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt32BE(this byte[] buff, int offset, Int32 value)
        {
            WriteUInt32BE(buff, offset, (UInt32)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt32LE(this byte[] buff, int offset, Int32 value)
        {
            WriteUInt32LE(buff, offset, (UInt32)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt24BE(this byte[] buff, int offset, Int32 value)
        {
            Debug.Assert(value <= 0x7FFFFF && value >= -0x7FFFFF);
            Debug.Assert(buff.Length >= offset + 3);
            WriteUInt24BE(buff, offset, (UInt32)(value & 0xFFFFFF));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt24LE(this byte[] buff, int offset, Int32 value)
        {
            Debug.Assert(value <= 0x7FFFFF && value >= -0x7FFFFF);
            Debug.Assert(buff.Length >= offset + 3);
            WriteUInt24LE(buff, offset, (UInt32)(value & 0xFFFFFF));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt16BE(this byte[] buff, int offset, Int16 value)
        {
            WriteUInt16BE(buff, offset, (UInt16)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt16LE(this byte[] buff, int offset, Int16 value)
        {
            WriteUInt16LE(buff, offset, (UInt16)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteSByte(this byte[] buff, int offset, sbyte value)
        {
            WriteByte(buff, offset, (byte)value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt64BE(this byte[] buff, int offset, UInt64 value)
        {
            Debug.Assert(buff.Length >= offset + Unsafe.SizeOf<UInt64>());
            Unsafe.WriteUnaligned<UInt64>(ref buff[offset], SwapEndianess(value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt64LE(this byte[] buff, int offset, UInt64 value)
        {
            Debug.Assert(buff.Length >= offset + Unsafe.SizeOf<UInt64>());
            Unsafe.WriteUnaligned<UInt64>(ref buff[offset], value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt32BE(this byte[] buff, int offset, UInt32 value)
        {
            Debug.Assert(buff.Length >= offset + Unsafe.SizeOf<UInt32>());
            Unsafe.WriteUnaligned<UInt32>(ref buff[offset], SwapEndianess(value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt32LE(this byte[] buff, int offset, UInt32 value)
        {
            Debug.Assert(buff.Length >= offset + Unsafe.SizeOf<UInt32>());
            Unsafe.WriteUnaligned<UInt32>(ref buff[offset], value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt24BE(this byte[] buff, int offset, UInt32 value)
        {

            Debug.Assert(value <= 0xFFFFFF);
            Debug.Assert(buff.Length >= offset + 3);

            value = SwapEndianess(value);

            unsafe
            {
                byte* src = (byte*)Unsafe.AsPointer(ref value) + 1;
                byte* destStart = (byte*)Unsafe.AsPointer(ref buff[offset]);

                Unsafe.CopyBlockUnaligned(destStart, src, 3);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt24LE(this byte[] buff, int offset, UInt32 value)
        {
            Debug.Assert(value <= 0xFFFFFF);
            Debug.Assert(buff.Length >= offset + 3);
            Unsafe.CopyBlockUnaligned(ref buff[offset], ref Unsafe.As<UInt32, byte>(ref value), 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt16BE(this byte[] buff, int offset, UInt16 value)
        {
            Debug.Assert(buff.Length >= offset + Unsafe.SizeOf<UInt16>());
            Unsafe.WriteUnaligned<UInt16>(ref buff[offset], SwapEndianess(value));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt16LE(this byte[] buff, int offset, UInt16 value)
        {
            Debug.Assert(buff.Length >= offset + Unsafe.SizeOf<UInt16>());
            Unsafe.WriteUnaligned<UInt16>(ref buff[offset], value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteByte(this byte[] buff, int offset, byte value)
        {
            Debug.Assert(buff.Length >= offset + Unsafe.SizeOf<byte>());
            Unsafe.WriteUnaligned<byte>(ref buff[offset], value);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WriteBytes(this byte[] buff, int offset, byte[] input, int count)
        {
            Debug.Assert(count > 0);
            Debug.Assert(buff.Length >= offset + count && count >= 0);
            Unsafe.CopyBlockUnaligned(ref buff[offset], ref input[0], (uint)count);
            return count;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WriteBytes(this byte[] buff, int offset, ReadOnlySpan<byte> input)
        {
            Debug.Assert(buff.Length >= offset + input.Length);
            Unsafe.CopyBlockUnaligned(ref buff[offset], ref Unsafe.AsRef(input[0]), (uint)input.Length);
            return input.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WriteCountLE<T>(this byte[] buff, int offset, T[] input, int count) where T : unmanaged
        {
            var bytes = MemoryMarshal.AsBytes(input.AsSpan(0, count));
            Debug.Assert(count > 0);
            Debug.Assert(buff.Length >= offset + bytes.Length);
            Unsafe.CopyBlockUnaligned(ref buff[offset], ref bytes[0], (uint)bytes.Length);
            return bytes.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WriteCountLE<T>(this byte[] buff, int offset, ReadOnlySpan<T> input) where T : unmanaged
        {
            var bytes = MemoryMarshal.AsBytes(input);
            Debug.Assert(buff.Length >= offset + bytes.Length);
            Unsafe.CopyBlockUnaligned(ref buff[offset], ref Unsafe.AsRef(bytes[0]), (uint)bytes.Length);
            return bytes.Length;
        }

    }
}