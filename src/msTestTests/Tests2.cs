using System.Threading.Tasks;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Tests2
{
    [TestMethod]
    public void Method2()
    {
        Task<int> task = new BenchmarkClass2().Method();
        bool isAsyncMethod = TaskHelper.TryAwaitTask(task, out var result);

        Assert.IsTrue(isAsyncMethod);
        Assert.AreEqual(42, result);
    }
}