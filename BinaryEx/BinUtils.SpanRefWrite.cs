// Copyright (c) 2019-2022 Matthew Sitton <matthewsitton@gmail.com>
// MIT License - See LICENSE in the project root for license information.
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BinaryEx
{
    public static partial class BinUtils
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt64BE(this Span<byte> buff, ref int offset, Int64 value)
        {
            WriteInt64BE(buff, offset, value);
            offset += 8;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt64LE(this Span<byte> buff, ref int offset, Int64 value)
        {
            WriteInt64LE(buff, offset, value);
            offset += 8;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt32BE(this Span<byte> buff, ref int offset, Int32 value)
        {
            WriteInt32BE(buff, offset, value);
            offset += 4;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt32LE(this Span<byte> buff, ref int offset, Int32 value)
        {
            WriteInt32LE(buff, offset, value);
            offset += 4;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt24BE(this Span<byte> buff, ref int offset, Int32 value)
        {
            WriteInt24BE(buff, offset, value);
            offset += 3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt24LE(this Span<byte> buff, ref int offset, Int32 value)
        {
            WriteInt24LE(buff, offset, value);
            offset += 3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt16BE(this Span<byte> buff, ref int offset, Int16 value)
        {
            WriteInt16BE(buff, offset, value);
            offset += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteInt16LE(this Span<byte> buff, ref int offset, Int16 value)
        {
            WriteInt16LE(buff, offset, value);
            offset += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteSByte(this Span<byte> buff, ref int offset, sbyte value)
        {
            WriteSByte(buff, offset, value);
            offset += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt64BE(this Span<byte> buff, ref int offset, UInt64 value)
        {
            WriteUInt64BE(buff, offset, value);
            offset += 8;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt64LE(this Span<byte> buff, ref int offset, UInt64 value)
        {
            WriteUInt64LE(buff, offset, value);
            offset += 8;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt32BE(this Span<byte> buff, ref int offset, UInt32 value)
        {
            WriteUInt32BE(buff, offset, value);
            offset += 4;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt32LE(this Span<byte> buff, ref int offset, UInt32 value)
        {
            WriteUInt32LE(buff, offset, value);
            offset += 4;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt24BE(this Span<byte> buff, ref int offset, UInt32 value)
        {
            WriteUInt24BE(buff, offset, value);
            offset += 3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt24LE(this Span<byte> buff, ref int offset, UInt32 value)
        {
            WriteUInt24LE(buff, offset, value);
            offset += 3;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt16BE(this Span<byte> buff, ref int offset, UInt16 value)
        {
            WriteUInt16BE(buff, offset, value);
            offset += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUInt16LE(this Span<byte> buff, ref int offset, UInt16 value)
        {
            WriteUInt16LE(buff, offset, value);
            offset += 2;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteByte(this Span<byte> buff, ref int offset, byte value)
        {
            WriteByte(buff, offset, value);
            offset += 1;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteBytes(this Span<byte> data, ref int offset, byte[] input, UInt32 count)
        {
            offset += WriteBytes(data, offset, input, count);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteBytes(this Span<byte> buff, ref int offset, ReadOnlySpan<byte> data)
        {
            offset += WriteBytes(buff, offset, data);
        }

    }
}