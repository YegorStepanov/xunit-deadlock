using System.Threading.Tasks;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Tests1
{
    [TestMethod]
    public void Method1()
    {
        Task<int> task = new BenchmarkClass1().Foo();
        bool isAsyncMethod = TaskHelper.TryAwaitTask(task, out object result);

        Assert.IsTrue(isAsyncMethod);
        Assert.AreEqual(1, result);
    }
}