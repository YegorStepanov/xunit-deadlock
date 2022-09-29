using Xunit.Abstractions;

namespace xunit_deadlock;

public class MyTests2
{
    private readonly ITestOutputHelper _testOutputHelper;
    public MyTests2(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Method2()
    {
        _testOutputHelper.WriteLine("MyMethod2");
        var task = new TestClass2().GlobalSetup();
        var isAsyncMethod = MyTests1.TryAwaitTask(task, out var result);

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
        _testOutputHelper.WriteLine("MyMethod3");
        var task = new TestClass3().GlobalCleanup();
        var isAsyncMethod = MyTests1.TryAwaitTask(task, out var result);

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