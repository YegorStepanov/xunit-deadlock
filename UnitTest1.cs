using System.Reflection;
using Xunit.Abstractions;

namespace xunit_deadlock;

public class MyTests1
{
    private readonly ITestOutputHelper _testOutputHelper;
    public MyTests1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Method1()
    {
        _testOutputHelper.WriteLine("MyMethod1");
        var task = new TestClass1().Foo();
        var isAsyncMethod = TryAwaitTask(task, out var result);

        Assert.True(isAsyncMethod);
        Assert.Equal(1, result);
    }

    public class TestClass1
    {
        public async Task<int> Foo()
        {
            await Task.Delay(1);
            return 1;
        }
    }

    public static bool TryAwaitTask(object task, out object result)
    {
        result = null;

        if (task is null)
        {
            return false;
        }

        // ValueTask<T>
        var returnType = task.GetType();
        if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(ValueTask<>))
        {
            var asTaskMethod = task.GetType().GetMethod("AsTask");
            task = asTaskMethod.Invoke(task, null);
        }

        if (task is ValueTask valueTask)
            task = valueTask.AsTask();

        // Task or Task<T>
        if (task is Task t)
        {
            if (TryGetTaskResult(t, out var taskResult))
                result = taskResult;

            return true;
        }

        return false;
    }

    // https://stackoverflow.com/a/52500763
    private static bool TryGetTaskResult(Task task, out object result)
    {
        result = null;

        var voidTaskType = typeof(Task<>).MakeGenericType(Type.GetType("System.Threading.Tasks.VoidTaskResult"));
        if (voidTaskType.IsInstanceOfType(task))
        {
            task.GetAwaiter().GetResult();
            return false; //true
        }

        var property = task.GetType().GetProperty("Result", BindingFlags.Public | BindingFlags.Instance);
        if (property is null)
        {
            return false;
        }

        result = property.GetValue(task);
        return true;
    }
}