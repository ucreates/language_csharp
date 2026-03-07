using System.Diagnostics;

namespace Language;

public class AsyncAwaitTest
{
    [Test]
    public void AsyncAwait1Test()
    {
        Console.WriteLine($"Enter::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
        var task = AsyncAwait.RunAsync();
        Console.WriteLine($"task running");
        task.Wait();
        Console.WriteLine($"Leave::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
    }

    [Test]
    public void AsyncAwait2Test()
    {
        Console.WriteLine($"Enter::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
        var task = AsyncAwait.RunAsyncTimeSpan();
        while (!task.IsCompleted)
        {
            task.Wait(200);
            Console.WriteLine($"task running");
        }

        Console.WriteLine(@$"result: {task.Result}");
        Console.WriteLine($"Leave::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
    }

    public class AsyncAwait
    {
        public static async Task RunAsync()
        {
            Console.WriteLine($"Enter::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            await Task.Run(() => Count(1));
            Console.WriteLine($"Leave::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
        }

        public static async Task<TimeSpan> RunAsyncTimeSpan()
        {
            Console.WriteLine($"Enter::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            var watch = Stopwatch.StartNew();
            await Task.Run(() =>
            {
                for (var i = 0; i < 10000000; i++) Console.WriteLine($"{i}");
            });
            watch.Stop();
            Console.WriteLine($"Leave::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
            return watch.Elapsed;
        }

        public static void Count(int id)
        {
            for (var i = 0; i < 500; i++) Console.WriteLine($"Task{id}:{i}");
        }
    }
}