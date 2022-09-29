using System.Threading.Tasks;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Tests2
{
    [TestMethod]
    public void Method2()
    {
        return;

        // Task.Delay(6_000).GetAwaiter();
        // return;

        Task<int> task = new BenchmarkClass2().GlobalSetup();
        bool isAsyncMethod = TaskHelper.TryAwaitTask(task, out var result);

        Assert.IsTrue(isAsyncMethod);
        Assert.AreEqual(42, result);
        Assert.IsTrue(BenchmarkClass2.WasCalled);
    }

    [TestMethod]
    public void Method3()
    {
        // Task.Delay(6_000).GetAwaiter();
        // Assert.AreEqual(1, 1);
        // return;

        ValueTask task = new BenchmarkClass3().GlobalCleanup();
        bool isAsyncMethod = TaskHelper.TryAwaitTask(task, out _);

        Assert.IsTrue(isAsyncMethod);
        Assert.IsTrue(BenchmarkClass3.WasCalled);
    }
}