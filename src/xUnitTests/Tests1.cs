using System.Threading.Tasks;
using Common;
using Xunit;

public class Tests1
{
    [Fact]
    public void Method1()
    {
        Task<int> task = new BenchmarkClass1().Method();
        bool isAsyncMethod = TaskHelper.TryAwaitTask(task, out object result);

        Assert.True(isAsyncMethod);
        Assert.Equal(1, result);
    }
}