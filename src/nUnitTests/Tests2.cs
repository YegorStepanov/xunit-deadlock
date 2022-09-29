using System.Threading.Tasks;
using Common;
using NUnit.Framework;

[Parallelizable(ParallelScope.Self)]
public class Tests2
{
    [Test]
    public void Method2()
    {
        Task<int> task = new BenchmarkClass2().Method();
        bool isAsyncMethod = TaskHelper.TryAwaitTask(task, out var result);

        Assert.True(isAsyncMethod);
        Assert.AreEqual(42, result);
    }
}