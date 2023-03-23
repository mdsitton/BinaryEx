# BinaryEx
Fast C# Extension functions for reading or writing binary data.

Easy to use, fast performance, no or very little allocation parsing utilities.

I have benchmarked these extensions extensively using both mono, and .net core to try and get the best performance possible from both runtimes.

I will update the readme with benchmarks between BinaryPrimatives, BitConverter, BinaryReader and BinaryEx once i put the library on nuget.

TODO: Implement support for IBufferWriter for writing, and ReadOnlySequence for reading


## Usage instructions

Here is a basic example of reading and writing to an array:
```
using BinaryEx;

byte[] array = new byte[128];

int pos = 0;
// Write into arary 32 ints
for (int i = 0; i < array.Length / sizeof(int); ++i)
{
	array.WriteInt32BE(i, ref pos);
}

// Read the arrays back from the array
for (int i = 0; i < array.Length / sizeof(int); ++i)
{
	int n = array.ReadInt32BE(ref pos);
}
```

The library adds extension functions into the following types:

byte[] arrays
Span<byte>
ReadOnlySpan<byte>
byte* pointers
Stream any stream object

Then there are 2 main types of apis:
Ref based apis which will keep tabs on the current write offset for you
Explicit position based apis that just take in a position to write to.
