
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace BinaryEx.Tests
{
    public class BinaryExStreamTests
    {

        [Test]
        public void SByteTest()
        {
            sbyte[] values = { 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, -0x11, -0x12, -0x13, -0x14, -0x15, -0x16 };

            using (var ms = new MemoryStream())
            {

                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteSByte(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadSByte(), Is.EqualTo(values[i]));
                }
            }
        }

        [Test]
        public void Int16LETest()
        {
            short[] values = { 0x1111, 0x1222, 0x1333, 0x1444, 0x1555, 0x1666, -0x1111, -0x1222, -0x1333, -0x1444, -0x1555, -0x1666, };

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteInt16LE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadInt16LE(), Is.EqualTo(values[i]));
                }
            }
        }

        [Test]
        public void UInt16LETest()
        {
            ushort[] values = { 0x1111, 0x1222, 0x1333, 0x1444, 0x1555, 0x1666, 0x1777, 0x1888, 0x1999, 0x2999, 0xF000, 0xFFFF };

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteUInt16LE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadUInt16LE(), Is.EqualTo(values[i]));
                }
            }
        }

        [Test]
        public void Int16BETest()
        {
            short[] values = { 0x1111, 0x1222, 0x1333, 0x1444, 0x1555, 0x1666, -0x1111, -0x1222, -0x1333, -0x1444, -0x1555, -0x1666, };

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteInt16BE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadInt16BE(), Is.EqualTo(values[i]));
                }
            }
        }

        [Test]
        public void UInt16BETest()
        {
            ushort[] values = { 0x1111, 0x1222, 0x1333, 0x1444, 0x1555, 0x1666, 0x1777, 0x1888, 0x1999, 0x2999, 0xF000, 0xFFFF };

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteUInt16BE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadUInt16BE(), Is.EqualTo(values[i]));
                }
            }
        }

        [Test]
        public void Int24LETest()
        {
            int[] values = {
                0x12d687, 0x122212, 0x133313, 0x144414,
                0x155515, 0x166616, -0x111111, -0x122212,
                -0x133313, -0x144414, -0x155515, -0x166616};

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteInt24LE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadInt24LE(), Is.EqualTo(values[i]));
                }
            }
        }

        [Test]
        public void UInt24LETest()
        {
            uint[] values = {
                0x12d687, 0x122212, 0x133313, 0x144414,};

            using (var ms = new MemoryStream())
            {

                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteUInt24LE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadUInt24LE(), Is.EqualTo(values[i]));
                }
            }
        }


        [Test]
        public void Int24BETest()
        {
            int[] values = {
                0x12d687, 0x122212, 0x133313, 0x144414,
                0x155515, 0x166616, -0x111111, -0x122212,
                -0x133313, -0x144414, -0x155515, -0x166616};

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteInt24BE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadInt24BE(), Is.EqualTo(values[i]));
                }
            }
        }

        [Test]
        public void UInt24BETest()
        {
            uint[] values = {
                0x12d687, 0x122212, 0x133313, 0x144414};

            using (var ms = new MemoryStream())
            {

                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteUInt24BE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadUInt24BE(), Is.EqualTo(values[i]));
                }
            }
        }

        [Test]
        public void Int32LETest()
        {
            int[] values = {
                0x11111111, 0x12221222, 0x13331333, 0x14441444,
                0x15551555, 0x16661666, -0x11111111, -0x12221222,
                -0x13331333, -0x14441444, -0x15551555, -0x16661666};

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteInt32LE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadInt32LE(), Is.EqualTo(values[i]));
                }
            }
        }

        [Test]
        public void UInt32LETest()
        {
            uint[] values = {
                0x11111111, 0x12221222, 0x13331333, 0x14441444,
                0x15551555, 0x16661666, 0x17771777, 0x18881888,
                0x19991999, 0x29992999, 0xF000F000, 0xFFFFFFFF };

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteUInt32LE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadUInt32LE(), Is.EqualTo(values[i]));
                }
            }
        }

        [Test]
        public void Int32BETest()
        {
            int[] values = {
                0x11111111, 0x12221222, 0x13331333, 0x14441444,
                0x15551555, 0x16661666, -0x11111111, -0x12221222,
                -0x13331333, -0x14441444, -0x15551555, -0x16661666};

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteInt32BE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadInt32BE(), Is.EqualTo(values[i]));
                }
            }
        }

        [Test]
        public void UInt32BETest()
        {
            uint[] values = {
                0x11111111, 0x12221222, 0x13331333, 0x14441444,
                0x15551555, 0x16661666, 0x17771777, 0x18881888,
                0x19991999, 0x29992999, 0xF000F000, 0xFFFFFFFF };

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteUInt32BE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadUInt32BE(), Is.EqualTo(values[i]));
                }
            }
        }

        [Test]
        public void Int64LETest()
        {
            long[] values = {
                0x1111111111111111, 0x1222122212221222, 0x1333133313331333, 0x1444144414441444,
                0x1555155515551555, 0x1666166616661666, -0x1111111111111111, -0x1222122212221222,
                -0x1333133313331333, -0x1444144414441444, -0x1555155515551555, -0x1666166616661666};

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteInt64LE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadInt64LE(), Is.EqualTo(values[i]));
                }
            }
        }

        [Test]
        public void UInt64LETest()
        {
            ulong[] values = {
                0x1111111111111111, 0x1222122212221222, 0x1333133313331333, 0x1444144414441444,
                0x1555155515551555, 0x1666166616661666, 0x1777177717771777, 0x1888188818881888,
                0x1999199919991999, 0x2999299929992999, 0xF000F000F000F000, 0xFFFFFFFFFFFFFFFF };

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteUInt64LE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadUInt64LE(), Is.EqualTo(values[i]));
                }
            }
        }

        [Test]
        public void Int64BETest()
        {
            long[] values = {
                0x1111111111111111, 0x1222122212221222, 0x1333133313331333, 0x1444144414441444,
                0x1555155515551555, 0x1666166616661666, -0x1111111111111111, -0x1222122212221222,
                -0x1333133313331333, -0x1444144414441444, -0x1555155515551555, -0x1666166616661666};

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteInt64BE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadInt64BE(), Is.EqualTo(values[i]));
                }
            }
        }

        [Test]
        public void UInt64BETest()
        {
            ulong[] values = {
                0x1111111111111111, 0x1222122212221222, 0x1333133313331333, 0x1444144414441444,
                0x1555155515551555, 0x1666166616661666, 0x1777177717771777, 0x1888188818881888,
                0x1999199919991999, 0x2999299929992999, 0xF000F000F000F000, 0xFFFFFFFFFFFFFFFF };

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteUInt64BE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadUInt64BE(), Is.EqualTo(values[i]));
                }
            }
        }

        [Test]
        public void FloatLETest()
        {
            float[] values = {
                1.0f, 2.0f, 0.5f, 0.25f,
                0.125f, 0.0625f, -1.0f, -2.0f,
                -0.5f, -0.25f, -0.125f, -0.0625f };

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteFloatLE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadFloatLE(), Is.EqualTo(values[i]));
                }
            }
        }


        [Test]
        public void FloatBETest()
        {
            float[] values = {
                1.0f, 2.0f, 0.5f, 0.25f,
                0.125f, 0.0625f, -1.0f, -2.0f,
                -0.5f, -0.25f, -0.125f, -0.0625f };

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteFloatBE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadFloatBE(), Is.EqualTo(values[i]));
                }
            }
        }


        [Test]
        public void DoubleLETest()
        {
            double[] values = {
                1.0, 2.0, 0.5, 0.25,
                0.125, 0.0625, -1.0, -2.0,
                -0.5, -0.25, -0.125, -0.0625 };

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteDoubleLE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadDoubleLE(), Is.EqualTo(values[i]));
                }
            }
        }


        [Test]
        public void DoubleBETest()
        {
            double[] values = {
                1.0, 2.0, 0.5, 0.25,
                0.125, 0.0625, -1.0, -2.0,
                -0.5, -0.25, -0.125, -0.0625 };

            using (var ms = new MemoryStream())
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ms.WriteDoubleBE(values[i]);
                }
                ms.Position = 0;
                for (int i = 0; i < values.Length; i++)
                {
                    Assert.That(ms.ReadDoubleBE(), Is.EqualTo(values[i]));
                }
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

            using (var ms = new MemoryStream())
            {
                ms.WriteCountLE<TestData>(values, values.Length);
                TestData[] readValues = new TestData[20];

                ms.Position = 0;

                ms.ReadCountLE(readValues, readValues.Length);

                Assert.That(values, Is.EqualTo(readValues));
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

            using (var ms = new MemoryStream())
            {
                ms.WriteCountLE<TestData>(values.AsSpan());
                TestData[] readValues = new TestData[20];

                ms.Position = 0;

                ms.ReadCountLE(readValues.AsSpan());

                Assert.That(values, Is.EqualTo(readValues));
            }
        }
    }
}
