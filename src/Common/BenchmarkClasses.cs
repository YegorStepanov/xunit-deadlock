using System.Threading.Tasks;

namespace Common;

public class BenchmarkClass1
{
    public async Task<int> Foo()
    {
        await Task.Delay(1);
        return 1;
    }
}

public class BenchmarkClass2
{
    public static bool WasCalled;

    public async Task<int> GlobalSetup()
    {
        await Task.Delay(1);
        WasCalled = true;
        return 42;
    }
}