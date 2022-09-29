using System.Threading.Tasks;
using Xunit;

namespace xunit_deadlock;

public class MyTests2
{
    [Fact]
    public void Method2()
    {
        return;
        Task<int> task = new TestClass2().GlobalSetup();
        bool isAsyncMethod = MyTests1.TryAwaitTask(task, out var result);

        Assert.True(isAsyncMethod);
        Assert.Equal(42, result);
        Assert.True(TestClass2.WasCalled);
    }

    public class TestClass2
    {
        public static bool WasCalled;

        public async Task<int> GlobalSetup()
        {
            await Task.Delay(1);
            WasCalled = true;
            return 42;
        }
    }

    [Fact]
    public void Method3()
    {
        return;
        ValueTask task = new TestClass3().GlobalCleanup();
        bool isAsyncMethod = MyTests1.TryAwaitTask(task, out _);

        Assert.True(isAsyncMethod);
        Assert.True(TestClass3.WasCalled);
    }

    public class TestClass3
    {
        public static bool WasCalled;

        public async ValueTask GlobalCleanup()
        {
            await Task.Delay(1);
            WasCalled = true;
        }
    }
}