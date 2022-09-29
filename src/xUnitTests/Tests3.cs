using System.Threading.Tasks;
using Common;
using Xunit;

public class Tests3
{
    [Fact]
    public void Method3()
    {
        Task<int> task = new BenchmarkClass3().Method();
        bool isAsyncMethod = TaskHelper.TryAwaitTask(task, out object result);

        Assert.True(isAsyncMethod);
        Assert.Equal(1, result);
    }
}