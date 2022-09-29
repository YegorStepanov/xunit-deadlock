using System.Threading.Tasks;
using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class Tests3
{
    [TestMethod]
    public void Method3()
    {
        Task<int> task = new BenchmarkClass3().Method();
        bool isAsyncMethod = TaskHelper.TryAwaitTask(task, out object result);

        Assert.IsTrue(isAsyncMethod);
        Assert.AreEqual(1, result);
    }
}