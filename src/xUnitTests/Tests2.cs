using System.Threading.Tasks;
using Common;
using Xunit;

public class Tests2
{
    [Fact]
    public void Method2()
    {
        Task<int> task = new BenchmarkClass2().GlobalSetup();
        bool isAsyncMethod = TaskHelper.TryAwaitTask(task, out var result);

        Assert.True(isAsyncMethod);
        Assert.Equal(42, result);
        Assert.True(BenchmarkClass2.WasCalled);
    }

    [Fact]
    public void Method3()
    {
        ValueTask task = new BenchmarkClass3().GlobalCleanup();
        bool isAsyncMethod = TaskHelper.TryAwaitTask(task, out _);

        Assert.True(isAsyncMethod);
        Assert.True(BenchmarkClass3.WasCalled);
    }
}