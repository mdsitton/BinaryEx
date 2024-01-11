// Copyright (c) 2019-2024 Matthew Sitton <matthewsitton@gmail.com>
// MIT License - See LICENSE in the project root for license information.
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace BinaryEx.Tests
{
    public unsafe class BinaryExUnsafeTests
    {

        [Test]
        public void SByteTest()
        {
            sbyte[] values = { 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, -0x11, -0x12, -0x13, -0x14, -0x15, -0x16 };
            var scratchArray = new byte[values.Length];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteSByte(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadSByte(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }

        }

        [Test]
        public void ByteTest()
        {
            byte[] values = { 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x29, 0xF0, 0xFF };
            var scratchArray = new byte[values.Length];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteByte(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadByte(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void Int16LETest()
        {
            short[] values = { 0x1111, 0x1222, 0x1333, 0x1444, 0x1555, 0x1666, -0x1111, -0x1222, -0x1333, -0x1444, -0x1555, -0x1666, };
            var scratchArray = new byte[values.Length * sizeof(short)];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteInt16LE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadInt16LE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void UInt16LETest()
        {
            ushort[] values = { 0x1111, 0x1222, 0x1333, 0x1444, 0x1555, 0x1666, 0x1777, 0x1888, 0x1999, 0x2999, 0xF000, 0xFFFF };
            var scratchArray = new byte[values.Length * sizeof(ushort)];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteUInt16LE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadUInt16LE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void Int16BETest()
        {
            short[] values = { 0x1111, 0x1222, 0x1333, 0x1444, 0x1555, 0x1666, -0x1111, -0x1222, -0x1333, -0x1444, -0x1555, -0x1666, };
            var scratchArray = new byte[values.Length * sizeof(short)];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteInt16BE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadInt16BE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void UInt16BETest()
        {
            ushort[] values = { 0x1111, 0x1222, 0x1333, 0x1444, 0x1555, 0x1666, 0x1777, 0x1888, 0x1999, 0x2999, 0xF000, 0xFFFF };
            var scratchArray = new byte[values.Length * sizeof(ushort)];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteUInt16BE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadUInt16BE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void Int24LETest()
        {
            int[] values = {
                0x12d687, 0x122212, 0x133313, 0x144414,
                0x155515, 0x166616, -0x111111, -0x122212,
                -0x133313, -0x144414, -0x155515, -0x166616};

            var scratchArray = new byte[values.Length * 3];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteInt24LE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadInt24LE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void UInt24LETest()
        {
            uint[] values = {
                0x12d687, 0x122212, 0x133313, 0x144414,};
            var scratchArray = new byte[values.Length * 3];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteUInt24LE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadUInt24LE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }


        [Test]
        public void Int24BETest()
        {
            int[] values = {
                0x12d687, 0x122212, 0x133313, 0x144414,
                0x155515, 0x166616, -0x111111, -0x122212,
                -0x133313, -0x144414, -0x155515, -0x166616};

            var scratchArray = new byte[values.Length * 3];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteInt24BE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadInt24BE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void UInt24BETest()
        {
            uint[] values = {
                0x12d687, 0x122212, 0x133313, 0x144414};

            var scratchArray = new byte[values.Length * 3];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteUInt24BE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadUInt24BE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void Int32LETest()
        {
            int[] values = {
                0x11111111, 0x12221222, 0x13331333, 0x14441444,
                0x15551555, 0x16661666, -0x11111111, -0x12221222,
                -0x13331333, -0x14441444, -0x15551555, -0x16661666};

            var scratchArray = new byte[values.Length * sizeof(int)];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteInt32LE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadInt32LE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void UInt32LETest()
        {
            uint[] values = {
                0x11111111, 0x12221222, 0x13331333, 0x14441444,
                0x15551555, 0x16661666, 0x17771777, 0x18881888,
                0x19991999, 0x29992999, 0xF000F000, 0xFFFFFFFF };
            var scratchArray = new byte[values.Length * sizeof(uint)];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteUInt32LE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadUInt32LE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void Int32BETest()
        {
            int[] values = {
                0x11111111, 0x12221222, 0x13331333, 0x14441444,
                0x15551555, 0x16661666, -0x11111111, -0x12221222,
                -0x13331333, -0x14441444, -0x15551555, -0x16661666};

            var scratchArray = new byte[values.Length * sizeof(int)];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteInt32BE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadInt32BE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void UInt32BETest()
        {
            uint[] values = {
                0x11111111, 0x12221222, 0x13331333, 0x14441444,
                0x15551555, 0x16661666, 0x17771777, 0x18881888,
                0x19991999, 0x29992999, 0xF000F000, 0xFFFFFFFF };
            var scratchArray = new byte[values.Length * sizeof(uint)];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteUInt32BE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadUInt32BE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void Int64LETest()
        {
            long[] values = {
                0x1111111111111111, 0x1222122212221222, 0x1333133313331333, 0x1444144414441444,
                0x1555155515551555, 0x1666166616661666, -0x1111111111111111, -0x1222122212221222,
                -0x1333133313331333, -0x1444144414441444, -0x1555155515551555, -0x1666166616661666};

            var scratchArray = new byte[values.Length * sizeof(long)];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteInt64LE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadInt64LE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void UInt64LETest()
        {
            ulong[] values = {
                0x1111111111111111, 0x1222122212221222, 0x1333133313331333, 0x1444144414441444,
                0x1555155515551555, 0x1666166616661666, 0x1777177717771777, 0x1888188818881888,
                0x1999199919991999, 0x2999299929992999, 0xF000F000F000F000, 0xFFFFFFFFFFFFFFFF };
            var scratchArray = new byte[values.Length * sizeof(ulong)];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteUInt64LE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadUInt64LE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void Int64BETest()
        {
            long[] values = {
                0x1111111111111111, 0x1222122212221222, 0x1333133313331333, 0x1444144414441444,
                0x1555155515551555, 0x1666166616661666, -0x1111111111111111, -0x1222122212221222,
                -0x1333133313331333, -0x1444144414441444, -0x1555155515551555, -0x1666166616661666};

            var scratchArray = new byte[values.Length * sizeof(long)];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteInt64BE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadInt64BE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void UInt64BETest()
        {
            ulong[] values = {
                0x1111111111111111, 0x1222122212221222, 0x1333133313331333, 0x1444144414441444,
                0x1555155515551555, 0x1666166616661666, 0x1777177717771777, 0x1888188818881888,
                0x1999199919991999, 0x2999299929992999, 0xF000F000F000F000, 0xFFFFFFFFFFFFFFFF };
            var scratchArray = new byte[values.Length * sizeof(ulong)];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteUInt64BE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadUInt64BE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void FloatLETest()
        {
            float[] values = {
                1.0f, 2.0f, 0.5f, 0.25f,
                0.125f, 0.0625f, -1.0f, -2.0f,
                -0.5f, -0.25f, -0.125f, -0.0625f };
            var scratchArray = new byte[values.Length * sizeof(float)];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteFloatLE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadFloatLE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }


        [Test]
        public void FloatBETest()
        {
            float[] values = {
                1.0f, 2.0f, 0.5f, 0.25f,
                0.125f, 0.0625f, -1.0f, -2.0f,
                -0.5f, -0.25f, -0.125f, -0.0625f };
            var scratchArray = new byte[values.Length * sizeof(float)];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteFloatBE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadFloatBE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }


        [Test]
        public void DoubleLETest()
        {
            double[] values = {
                1.0, 2.0, 0.5, 0.25,
                0.125, 0.0625, -1.0, -2.0,
                -0.5, -0.25, -0.125, -0.0625 };
            var scratchArray = new byte[values.Length * sizeof(double)];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteDoubleLE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadDoubleLE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }


        [Test]
        public void DoubleBETest()
        {
            double[] values = {
                1.0, 2.0, 0.5, 0.25,
                0.125, 0.0625, -1.0, -2.0,
                -0.5, -0.25, -0.125, -0.0625 };
            var scratchArray = new byte[values.Length * sizeof(double)];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    BinaryExRef.WriteDoubleBE(scratchPtr, ref offset, values[i]);
                }

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(BinaryExRef.ReadDoubleBE(scratchPtr, ref offset), Is.EqualTo(values[i]));
                }
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        struct TestData
        {
            public float floatVal;
            public double doubleVal;
            public long longVal;
        }

        [Test]
        public void CountLETest()
        {
            TestData[] values = new TestData[20];

            for (int i = 0; i < values.Length; i++)
            {
                values[i].floatVal = float.Epsilon * i;
                values[i].doubleVal = double.Epsilon * i;
                values[i].longVal = long.MaxValue / (i + 1);
            }

            var scratchArray = new byte[values.Length * Unsafe.SizeOf<TestData>()];
            fixed (byte* scratchPtr = scratchArray)
            {

                int offset = 0;

                BinaryExRef.WriteCountLE<TestData>(scratchPtr, ref offset, values, values.Length);

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                TestData[] readValues = new TestData[20];

                BinaryExRef.ReadCountLE(scratchPtr, ref offset, readValues, readValues.Length);

                Assert.That(values, Is.EqualTo(readValues));
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void CountLESpanTest()
        {
            TestData[] values = new TestData[20];

            for (int i = 0; i < values.Length; i++)
            {
                values[i].floatVal = float.Epsilon * i;
                values[i].doubleVal = double.Epsilon * i;
                values[i].longVal = long.MaxValue / (i + 1);
            }

            var scratchArray = new byte[values.Length * Unsafe.SizeOf<TestData>()];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                BinaryExRef.WriteCountLE<TestData>(scratchPtr, ref offset, values.AsSpan());

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                TestData[] readValues = new TestData[20];

                BinaryExRef.ReadCountLE(scratchPtr, ref offset, readValues.AsSpan());

                Assert.That(values, Is.EqualTo(readValues));
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void WriteBytesArrayTest()
        {
            TestData[] values = new TestData[20];

            for (int i = 0; i < values.Length; i++)
            {
                values[i].floatVal = float.Epsilon * i;
                values[i].doubleVal = double.Epsilon * i;
                values[i].longVal = long.MaxValue / (i + 1);
            }

            byte[] testBytes = MemoryMarshal.Cast<TestData, byte>(values.AsSpan()).ToArray();

            var scratchArray = new byte[values.Length * Unsafe.SizeOf<TestData>()];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                BinaryExRef.WriteBytes(scratchPtr, ref offset, testBytes, testBytes.Length);

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                var readArray = new byte[values.Length * Unsafe.SizeOf<TestData>()];

                BinaryExRef.ReadBytes(scratchPtr, ref offset, readArray, readArray.Length);

                Assert.That(testBytes, Is.EqualTo(readArray));
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }

        [Test]
        public void WriteBytesSpanTest()
        {
            TestData[] values = new TestData[20];

            for (int i = 0; i < values.Length; i++)
            {
                values[i].floatVal = float.Epsilon * i;
                values[i].doubleVal = double.Epsilon * i;
                values[i].longVal = long.MaxValue / (i + 1);
            }

            var testBytes = MemoryMarshal.Cast<TestData, byte>(values.AsSpan()).ToArray();

            var scratchArray = new byte[values.Length * Unsafe.SizeOf<TestData>()];

            fixed (byte* scratchPtr = scratchArray)
            {
                int offset = 0;

                BinaryExRef.WriteBytes(scratchPtr, ref offset, testBytes);

                Assert.That(scratchArray.Length, Is.EqualTo(offset));

                offset = 0;

                var readArray = new byte[values.Length * Unsafe.SizeOf<TestData>()];

                BinaryExRef.ReadBytes(scratchPtr, ref offset, readArray.AsSpan());

                Assert.That(testBytes, Is.EqualTo(readArray));
                Assert.That(scratchArray.Length, Is.EqualTo(offset));
            }
        }
    }
}
