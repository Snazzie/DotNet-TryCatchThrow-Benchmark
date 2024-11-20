## Benchmark Try Catch Throw overhead

.net9.0

processor = Qualcomm Snapdragon X Elite - X1E-78-100

## Conclusion

TryCatch block does not add noticeable overhead, but the exception throwing that incurs overhead.

The overhead from throwing and catching an exception resulted with ~0.002ms, which is unoticeable in real world application.

## Results
```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.2314)
Unknown processor
.NET SDK 9.0.100
  [Host]     : .NET 9.0.0 (9.0.24.52809), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 9.0.0 (9.0.24.52809), Arm64 RyuJIT AdvSIMD


| Method                   | Mean       | Error    | StdDev   |
|------------------------- |-----------:|---------:|---------:|
| TryCatch_NoError         |   453.4 ns |  7.89 ns |  7.00 ns |
| NoTryCatch_NoError       |   457.1 ns |  6.45 ns |  5.72 ns |
| TryCatch_WithErrorOption |   443.3 ns |  2.29 ns |  1.91 ns |
| TryCatch_WithThrow       | 2,310.7 ns | 39.63 ns | 33.09 ns |

// * Hints *
Outliers
  TryCatchOverHead.TryCatch_NoError: Default         -> 1 outlier  was  removed (479.99 ns)
  TryCatchOverHead.NoTryCatch_NoError: Default       -> 1 outlier  was  removed (504.80 ns)
  TryCatchOverHead.TryCatch_WithErrorOption: Default -> 2 outliers were removed (454.99 ns, 456.26 ns)
  TryCatchOverHead.TryCatch_WithThrow: Default       -> 2 outliers were removed (2.45 us, 2.60 us)

// * Legends *
  Mean   : Arithmetic mean of all measurements
  Error  : Half of 99.9% confidence interval
  StdDev : Standard deviation of all measurements
  1 ns   : 1 Nanosecond (0.000000001 sec)

// ***** BenchmarkRunner: End *****
Run time: 00:01:29 (89.46 sec), executed benchmarks: 4

Global total time: 00:01:40 (100.12 sec), executed benchmarks: 4
```
