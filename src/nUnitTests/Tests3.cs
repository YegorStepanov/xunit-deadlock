using System.Threading.Tasks;
using Common;
using NUnit.Framework;

[Parallelizable(ParallelScope.Self)]
public class Tests3
{
    [Test]
    public void Method3()
    {
        Task<int> task = new BenchmarkClass3().Method();
        bool isAsyncMethod = TaskHelper.TryAwaitTask(task, out object result);

        Assert.True(isAsyncMethod);
        Assert.AreEqual(1, result);
    }
}