using System.Threading.Tasks;
using Common;
using NUnit.Framework;

[Parallelizable(ParallelScope.Self)]
public class Tests1
{
    [Test]
    public void Method1()
    {
        Task<int> task = new BenchmarkClass1().Foo();
        bool isAsyncMethod = TaskHelper.TryAwaitTask(task, out object result);

        Assert.True(isAsyncMethod);
        Assert.AreEqual(1, result);
    }
}