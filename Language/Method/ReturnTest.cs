using System.Collections;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Language;

public class ReturnTest
{
    [Test]
    public void Iterator1Test()
    {
        var iterator = new Iterator1();
        foreach (var value in iterator.GetStrings()) Console.WriteLine($"{value}");
    }

    [Test]
    public void Iterator2Test()
    {
        var iterator = new Iterator1();
        var result = iterator.GetStrings();
        var list = result.ToList();
        Console.WriteLine($"count::{list.Count()}");
        Console.WriteLine($"index0::{list[0]}");
        Console.WriteLine($"index1::{list[1]}");
        Console.WriteLine($"index2::{list[2]}");
    }

    [Test]
    public void Iterator3Test()
    {
        var iterator = new Iterator1();
        var result = iterator.GetNumbers(10);
        foreach (var value in result) Console.WriteLine($"{value}");
    }

    [Test]
    public void Iterator4Test()
    {
        var iterator = new Iterator1();
        Task.Run(async () =>
        {
            await foreach (var value in iterator.GetNumbersAsync(10)) Console.WriteLine($"{value}");
        });
    }

    [Test]
    public void Iterator5Test()
    {
        var iterator = new Iterator2();
        foreach (var value in iterator) Console.WriteLine($"{value}");
    }

    [Test]
    public void Iterator6Test()
    {
        var iterator = new Iterator2();
        foreach (var value in iterator) Console.WriteLine($"{value}");
    }

    [Test]
    public void Iterator7Test()
    {
        var iterator = new Iterator3();
        foreach (var value in iterator) Console.WriteLine($"{value}");
    }

    public class Iterator1
    {
        public IEnumerable<string> GetStrings()
        {
            Console.WriteLine($"1");
            yield return "A";
            Console.WriteLine($"2");
            yield return "B";
            Console.WriteLine($"3");
            yield return "C";
        }

        public IEnumerable<int> GetNumbers(int max)
        {
            for (var i = 0; i < max; i++) yield return i;
        }

        public async IAsyncEnumerable<int> GetNumbersAsync(int max)
        {
            Func<int, Task<int>> cb = async (value) =>
            {
                await Task.Delay(10);
                return value;
            };
            for (var i = 0; i < max; i++) yield return await cb(i);
        }
    }

    public class Iterator2 : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            for (var i = 0; i < 100; i++) yield return i;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class Iterator3 : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            for (var i = 0; i < 100; i++)
                if (i % 2 == 0)
                {
                    Console.WriteLine($"yield break");
                    yield break;
                }
                else
                {
                    yield return i;
                }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}