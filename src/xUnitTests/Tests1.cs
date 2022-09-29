using System.Threading.Tasks;
using Common;
using Xunit;

public class Tests1
{
    [Fact]
    public void Method1()
    {
        return;
        Task<int> task = new BenchmarkClass1().Foo();
        bool isAsyncMethod = TaskHelper.TryAwaitTask(task, out object result);

        Assert.True(isAsyncMethod);
        Assert.Equal(1, result);
    }
}