using System.Threading.Tasks;

namespace Common;

public class BenchmarkClass1
{
    public async Task<int> Method()
    {
        await Task.Delay(1);
        return 1;
    }
}

public class BenchmarkClass2
{
    public async Task<int> Method()
    {
        await Task.Delay(1);
        return 42;
    }
}