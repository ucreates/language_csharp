namespace Language;

using System.Threading;

public class ThreadTest
{
    [Test]
    public void Thread1Test()
    {
        Console.WriteLine($"Enter::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
        var thread1 = new Thread(ThreadProcess.Count);
        var thread2 = new Thread(ThreadProcess.Count);
        // スレッド終了まで待機しない
        thread1.Start(1);
        thread2.Start(2);
        Console.WriteLine($"Leave::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
    }

    [Test]
    public void Thread2Test()
    {
        Console.WriteLine($"Enter::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
        var thread1 = new Thread(ThreadProcess.Count);
        var thread2 = new Thread(ThreadProcess.Count);
        thread1.Start(1);
        thread2.Start(2);
        // スレッド終了まで待機
        thread1.Join();
        thread2.Join();
        Console.WriteLine($"Leave::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
    }

    [Test]
    public void Task1Test()
    {
        Console.WriteLine($"Enter::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
        Task.Run(() => ThreadProcess.Count(1));
        Task.Run(() => ThreadProcess.Count(2));
        Console.WriteLine($"Leave::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
    }

    [Test]
    public void Task2Test()
    {
        Console.WriteLine($"Enter::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
        var task1 = Task.Run(() => ThreadProcess.Count(1));
        var task2 = Task.Run(() => ThreadProcess.Count(2));
        task1.Wait();
        task2.Wait();
        Console.WriteLine($"Leave::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
    }

    [Test]
    public void Task3Test()
    {
        Console.WriteLine($"Enter::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
        var task1 = Task.Run(() => ThreadProcess.Count(1));
        var task2 = Task.Run(() => ThreadProcess.Count(2));
        // 指定時間だけ待機する
        task1.Wait(1);
        task2.Wait(1);
        Console.WriteLine($"Leave::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
    }

    [Test]
    public void Task4Test()
    {
        Console.WriteLine($"Enter::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
        var task1 = Task.Run(() => ThreadProcess.Count(1));
        var task2 = Task.Run(() => ThreadProcess.Count(2));
        var task3 = Task.Run(() => ThreadProcess.Count(3));
        // いずれかのタスクが終了するまで待機する
        Task.WaitAny(task1, task2, task3);
        Console.WriteLine($"Leave::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
    }

    [Test]
    public void Task5Test()
    {
        Console.WriteLine($"Enter::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
        var task1 = Task.Run(() => ThreadProcess.Count(1));
        var task2 = Task.Run(() => ThreadProcess.Count(2));
        var task3 = Task.Run(() => ThreadProcess.Count(3));
        // 全てのタスクが終了するまで待機する
        Task.WaitAll(task1, task2, task3);
        Console.WriteLine($"Leave::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
    }

    [Test]
    public void Task6Test()
    {
        Console.WriteLine($"Enter::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
        var tasks = new Task[500000];
        for (var i = 0; i < tasks.Length; i++)
        {
            //排他制御なし
            tasks[i] = Task.Run(() => ThreadProcess.NotExclusiveIncrement());
        }
        for (var i = 0; i < tasks.Length; i++)
        {
            tasks[i].Wait();
        }
        Console.WriteLine($"IncrementCount::{ThreadProcess.IncrementCount}");
        Console.WriteLine($"Leave::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
    }

    [Test]
    public void Task7Test()
    {
        Console.WriteLine($"Enter::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
        var tasks = new Task[500000];
        for (var i = 0; i < tasks.Length; i++)
        {
            //排他制御なし
            tasks[i] = Task.Run(() => ThreadProcess.ExclusiveIncrement());
        }
        for (var i = 0; i < tasks.Length; i++)
        {
            tasks[i].Wait();
        }
        Console.WriteLine($"IncrementCount::{ThreadProcess.IncrementCount}");
        Console.WriteLine($"Leave::{System.Reflection.MethodBase.GetCurrentMethod()?.Name}");
    }
    
    private class ThreadProcess
    {
        public static int IncrementCount = 0;
        public static object lockObj = new object();
        public static void Count(object obj)
        {
            for (var i = 0; i < 50; i++) Console.WriteLine($"Thread{obj}::{i}");
        }

        public static void ExclusiveIncrement()
        {
            lock (lockObj)
            {
                IncrementCount++;
            }
        }
        public static void NotExclusiveIncrement()
        {
            IncrementCount++;
        }
    }
}