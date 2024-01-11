# BinaryEx
[![BinaryEx on NuGet](https://img.shields.io/nuget/v/BinaryEx)](https://www.nuget.org/packages/BinaryEx)

Fast C# Extension functions for reading and writing binary data. Easy to use, high performance, with no allocation!

Combines the ease of use of streams with the performance of BinaryPrimatives, this library was originally built for high performance under unity but is very versitile in many other environments.

Features:
 - Extention method based apis makes it very easy to read or write data anywhere.
 - Direct position indexing, or ref offset based apis to automatically keep track of the buffer offset!
 - Directly write values to the following buffer types:
   - byte[], Span<byte>, byte*, Stream
- Directly read values from the following buffer types:
   - byte[], Span<byte>, ReadOnlySpan<byte>, byte*, Stream
- Serialize data using the following types:
   - byte, sbyte, short, ushort, int, uint, long, ulong, float, double
- Operate on data as either Big Endian, or Little Endian

Benchmarks between BinaryPrimatives, BitConverter, BinaryReader and BinaryEx coming soon.

Planned Features:
 - Support for IBufferWriter for writing, and ReadOnlySequence for reading
 - Support for Memory
 - Writing APIs for strings, UUID

I have extensively benchmarked this library to try and get the best performance possible from all runtimes.

## Usage instructions

Here is a basic example of reading and writing to an array:
```cs
using BinaryEx;
int numberCount = 32;
byte[] array = new byte[numberCount * sizeof(int)];

int pos = 0;
// Write 32 ints into the array in big endian byte order
for (int i = 0; i < numberCount; ++i)
{
    array.WriteInt32BE(i, ref pos);
}

pos = 0;
// Read the arrays back from the array
for (int i = 0; i < numberCount; ++i)
{
    int n = array.ReadInt32BE(ref pos);
}
```
