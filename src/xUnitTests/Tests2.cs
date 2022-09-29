using System.Threading.Tasks;
using Common;
using Xunit;

public class Tests2
{
    [Fact]
    public void Method2()
    {
        Task<int> task = new BenchmarkClass2().Method();
        bool isAsyncMethod = TaskHelper.TryAwaitTask(task, out object result);

        Assert.True(isAsyncMethod);
        Assert.Equal(42, result);
    }
}