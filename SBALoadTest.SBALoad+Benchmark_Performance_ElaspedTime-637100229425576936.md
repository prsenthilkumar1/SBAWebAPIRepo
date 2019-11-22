# SBALoadTest.SBALoad+Benchmark_Performance_ElaspedTime
_11/22/2019 12:35:42 PM_
### System Info
```ini
NBench=NBench, Version=1.2.2.0, Culture=neutral, PublicKeyToken=null
OS=Microsoft Windows NT 6.2.9200.0
ProcessorCount=4
CLR=4.0.30319.42000,IsMono=False,MaxGcGeneration=2
```

### NBench Settings
```ini
RunMode=Throughput, TestMode=Test
SkipWarmups=True
NumberOfIterations=1, MaximumRunTime=00:10:00
Concurrent=True
Tracing=False
```

## Data
-------------------

### Totals
|          Metric |           Units |             Max |         Average |             Min |          StdDev |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|    Elapsed Time |              ms |            0.00 |            0.00 |            0.00 |            0.00 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|    Elapsed Time |              ms |            0.00 |            0.00 |            0.00 |            0.00 |

### Raw Data
#### Elapsed Time
|           Run # |              ms |          ms / s |         ns / ms |
|---------------- |---------------- |---------------- |---------------- |
|               1 |            0.00 |            0.00 |          100.00 |


## Benchmark Assertions

* [PASS] Expected Elapsed Time to must be less than or equal to 1,000,000.00 ms; actual value was 0.00 ms.

```
NBench.NBenchException: Error occurred during $SBALoadTest.SBALoad+Benchmark_Performance_ElaspedTime RUN. ---> System.InvalidOperationException: No connection string named 'masterEntities' could be found in the application config file.
   at System.Data.Entity.Internal.LazyInternalConnection.get_ConnectionHasModel()
   at System.Data.Entity.Internal.LazyInternalContext.InitializeContext()
   at System.Data.Entity.Internal.InternalContext.GetEntitySetAndBaseTypeForType(Type entityType)
   at System.Data.Entity.Internal.Linq.InternalSet`1.Initialize()
   at System.Data.Entity.Internal.Linq.InternalSet`1.get_InternalContext()
   at System.Data.Entity.Infrastructure.DbQuery`1.System.Linq.IQueryable.get_Provider()
   at System.Linq.Queryable.Select[TSource,TResult](IQueryable`1 source, Expression`1 selector)
   at SBAWebAPI.Controllers.UserAPIController.Get() in C:\FSE\SBA\SBAWebAPI\SBAWebAPI\SBAWebAPI\Controllers\UserAPIController.cs:line 29
   at SBALoadTest.SBALoad.Benchmark_Performance_ElaspedTime() in C:\FSE\SBA\SBAWebAPI\SBAWebAPI\SBALoadTest\SBALoad.cs:line 31
   at NBench.Sdk.ReflectionBenchmarkInvoker.<>c__DisplayClass10_0.<InvokePerfSetup>b__0(BenchmarkContext ctx)
   at NBench.Sdk.Benchmark.WarmUp()
   --- End of inner exception stack trace ---
```

