## Benchmark Try Catch Throw overhead

.net9.0

processor = Qualcomm Snapdragon X Elite - X1E-78-100

## Conclusion

TryCatch block does not add noticeable overhead, but the exception throwing that incurs overhead.

The overhead from throwing and catching an exception resulted with ~0.002ms in .net9, which is unoticeable in real world application.

## Results

```
// * Summary *

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2605)
Unknown processor
.NET SDK 9.0.101
  [Host]   : .NET 9.0.0 (9.0.24.52809), Arm64 RyuJIT AdvSIMD
  .NET 8.0 : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  .NET 9.0 : .NET 9.0.0 (9.0.24.52809), Arm64 RyuJIT AdvSIMD


| Method                   | Job      | Runtime  | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------- |--------- |--------- |-----------:|---------:|---------:|-------:|----------:|
| TryCatch_NoError         | .NET 8.0 | .NET 8.0 |   443.8 ns |  1.72 ns |  1.53 ns | 0.0095 |      40 B |
| NoTryCatch_NoError       | .NET 8.0 | .NET 8.0 |   442.4 ns |  0.89 ns |  0.83 ns | 0.0095 |      40 B |
| TryCatch_WithErrorOption | .NET 8.0 | .NET 8.0 |   438.0 ns |  0.96 ns |  0.80 ns | 0.0095 |      40 B |
| TryCatch_WithThrow       | .NET 8.0 | .NET 8.0 | 5,672.0 ns | 11.63 ns | 10.31 ns | 0.0610 |     264 B |
| TryCatch_NoError         | .NET 9.0 | .NET 9.0 |   443.8 ns |  1.16 ns |  1.08 ns | 0.0095 |      40 B |
| NoTryCatch_NoError       | .NET 9.0 | .NET 9.0 |   444.3 ns |  0.77 ns |  0.72 ns | 0.0095 |      40 B |
| TryCatch_WithErrorOption | .NET 9.0 | .NET 9.0 |   440.0 ns |  0.75 ns |  0.70 ns | 0.0095 |      40 B |
| TryCatch_WithThrow       | .NET 9.0 | .NET 9.0 | 2,296.0 ns |  3.01 ns |  2.51 ns | 0.0839 |     360 B |

// * Hints *
Outliers
  TryCatchOverHead.TryCatch_NoError: .NET 8.0         -> 1 outlier  was  removed, 2 outliers were detected (442.53 ns, 449.45 ns)
  TryCatchOverHead.TryCatch_WithErrorOption: .NET 8.0 -> 2 outliers were removed (469.89 ns, 484.67 ns)
  TryCatchOverHead.TryCatch_WithThrow: .NET 8.0       -> 1 outlier  was  removed (5.72 us)
  TryCatchOverHead.TryCatch_WithThrow: .NET 9.0       -> 2 outliers were removed (2.31 us, 2.31 us)

// * Legends *
  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Gen0      : GC Generation 0 collects per 1000 operations
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  1 ns      : 1 Nanosecond (0.000000001 sec)

// * Diagnostic Output - MemoryDiagnoser *


// ***** BenchmarkRunner: End *****
Run time: 00:03:07 (187.91 sec), executed benchmarks: 8

Global total time: 00:03:16 (196.05 sec), executed benchmarks: 8


```
