using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;


BenchmarkRunner.Run<TryCatchOverHead>();

[SimpleJob(RuntimeMoniker.Net80)]
[SimpleJob(RuntimeMoniker.Net90)]
[MemoryDiagnoser(true)]
public class TryCatchOverHead()
{

    [Benchmark]
    public int? TryCatch_NoError()
    {

        try
        {
            var result =  ComputeWithOption(1);
            return result.num;
        }
        catch (Exception)
        {

            throw;
        }

    }
    
    [Benchmark]
    public int? NoTryCatch_NoError()
    {
        var result =  ComputeWithOption(1);
        return result.num;
    }
    
    [Benchmark]
    public int? TryCatch_WithErrorOption()
    {

        try
        {
            var result =ComputeWithOption(0);
            return result.num;
        }
        catch (Exception e)
        {

            return null;
        }
    }
    
    [Benchmark]
    public int? TryCatch_WithThrow()
    {
        try
        {
            var result = ComputeWithThrow(0);
            return result.num;
        }
        catch (Exception e)
        {
            return null;
        }
    }
    
    (int? num, string? err) ComputeWithOption(int divideBy)
    {
        int? num = null;

        num = Compute();
        if (divideBy == 0)
            return (num, "Cannot divide by 0");
        
        num = num / divideBy;
  
        return (num, null);
    }
    
    (int? num, string? err) ComputeWithThrow(int divideBy)
    {
        int? num = null;
        num = Compute();
        
        num = num / divideBy;
  
        return (num, null);
    }
    
    
    int Compute()
    {
        var num = 0;
        foreach (var item in Enumerable.Range(0, 200))
        {
            num = item;
        }
        
        return num;
    }
}