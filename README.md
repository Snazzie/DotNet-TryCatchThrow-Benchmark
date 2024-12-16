## Benchmark Try Catch Throw overhead

.net9.0

processor = Qualcomm Snapdragon X Elite - X1E-78-100

## Conclusion

TryCatch block does not add noticeable overhead, but the exception throwing that incurs overhead.

The overhead from throwing and catching an exception resulted with ~0.002ms, which is unoticeable in real world application.

## Results
```
// * Summary *

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2605)
Unknown processor
.NET SDK 9.0.101
  [Host]     : .NET 9.0.0 (9.0.24.52809), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 9.0.0 (9.0.24.52809), Arm64 RyuJIT AdvSIMD


| Method                   | Mean       | Error    | StdDev   | Gen0   | Allocated |
|------------------------- |-----------:|---------:|---------:|-------:|----------:|
| TryCatch_NoError         |   448.1 ns |  1.50 ns |  1.33 ns | 0.0095 |      40 B |
| NoTryCatch_NoError       |   449.9 ns |  1.24 ns |  1.03 ns | 0.0095 |      40 B |
| TryCatch_WithErrorOption |   442.8 ns |  1.67 ns |  1.56 ns | 0.0095 |      40 B |
| TryCatch_WithThrow       | 2,256.7 ns | 15.10 ns | 13.38 ns | 0.0839 |     360 B |

// * Hints *
Outliers
  TryCatchOverHead.TryCatch_NoError: Default   -> 1 outlier  was  removed (456.66 ns)
  TryCatchOverHead.NoTryCatch_NoError: Default -> 2 outliers were removed (455.75 ns, 470.15 ns)
  TryCatchOverHead.TryCatch_WithThrow: Default -> 1 outlier  was  removed (2.34 us)

// * Legends *
  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Gen0      : GC Generation 0 collects per 1000 operations
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  1 ns      : 1 Nanosecond (0.000000001 sec)

// * Diagnostic Output - MemoryDiagnoser *


// ***** BenchmarkRunner: End *****
Run time: 00:01:28 (88.98 sec), executed benchmarks: 4

Global total time: 00:01:33 (93.84 sec), executed benchmarks: 4

```
