namespace Language;

using System.Diagnostics;

[TestFixture]
public class ListTest
{
    [Test]
    public void Query1Test()
    {
        // 要素が値版
        var list = new List<int> { 1, 2, 3 };
        var result = from element in list where element == 2 select list;
        foreach (var i in result) Console.WriteLine($"{i}");
    }

    [Test]
    public void Foreach1Test()
    {
        // 要素が値版
        var result = 0;
        var list = new List<int>();
        for (var i = 0; i < 1000000000; i++) list.Add(i);
        var stopwatch = Stopwatch.StartNew();
        stopwatch!.Start();
        list.ForEach(i => { result += i; });
        Console.WriteLine($"ling:{stopwatch.ElapsedMilliseconds}ms, result:{result}");
        stopwatch.Restart();
        for (var i = 0; i < list.Count; i++) result += i;
        Console.WriteLine($"for:{stopwatch.ElapsedMilliseconds}ms, result:{result}");
        stopwatch.Restart();
        foreach (var i in list) result += i;
        Console.WriteLine($"foreach:{stopwatch.ElapsedMilliseconds}ms, result:{result}");
    }

    [Test]
    public void Aggregate1Test()
    {
        // 要素が文字列版
        var test = new List<string> { "value1", "value2", "value3" };
        var result = test.Aggregate((a, b) => a + b + "\n");
        Console.WriteLine($"データ:{result}");
    }
}