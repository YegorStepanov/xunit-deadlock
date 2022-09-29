using System.Threading.Tasks;
using Common;
using NUnit.Framework;

[Parallelizable(ParallelScope.Self)]
public class Tests2
{
    [Test]
    public void Method2()
    {
        // Task.Delay(6_000).GetAwaiter();
        return;

        Task<int> task = new BenchmarkClass2().GlobalSetup();
        bool isAsyncMethod = TaskHelper.TryAwaitTask(task, out var result);

        Assert.True(isAsyncMethod);
        Assert.AreEqual(42, result);
        Assert.True(BenchmarkClass2.WasCalled);
    }

    [Test]
    public void Method3()
    {
        //Task.Delay(6_000).GetAwaiter();
        return;

        ValueTask task = new BenchmarkClass3().GlobalCleanup();
        bool isAsyncMethod = TaskHelper.TryAwaitTask(task, out _);

        Assert.True(isAsyncMethod);
        Assert.True(BenchmarkClass3.WasCalled);
    }
}