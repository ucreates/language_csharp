namespace Language;

using System.Diagnostics;

[TestFixture]
public class ListTest
{
    /// <summary>
    /// LINQ/クエリ構文
    /// </summary>
    [Test]
    public void Query1Test()
    {
        // 要素が値版
        var list = new List<int> { 1, 2, 3 };
        var result = from element in list where element == 2 select element;
        foreach (var i in result) Console.WriteLine($"{i}");
    }

    /// <summary>
    /// LINQ/クエリ構文/Where句テスト(数値)
    /// </summary>
    [Test]
    public void QueryWhereStatement1Test()
    {
        var list = TestProductList.CreateInstanceList();
        var result = from element in list where element.Price < 150 select element;
        foreach (var i in result) Console.WriteLine($"{i.Name}");
    }

    /// <summary>
    /// LINQ/クエリ構文/Where句テスト(文字列)
    /// </summary>
    [Test]
    public void QueryWhereStatement2Test()
    {
        var list = TestProductList.CreateInstanceList();
        // 指定した値を含む
        var result = from element in list where element.Name.Contains('3') select element;
        foreach (var i in result) Console.WriteLine($"{i.Name}");
        // 指定した値を含まない
        result = from element in list where !element.Name.Contains('3') select element;
        foreach (var i in result) Console.WriteLine($"{i.Name}");
    }

    /// <summary>
    /// LINQ/クエリ構文/Where句テスト(範囲)
    /// </summary>
    [Test]
    public void QueryWhereStatement3Test()
    {
        var list = TestProductList.CreateInstanceList();
        var result = from element in list where 10 < element.Price && element.Price < 200 select element;
        foreach (var i in result) Console.WriteLine($"{i.Name}");
    }

    /// <summary>
    /// LINQ/クエリ構文/遅延実行
    /// </summary>
    [Test]
    public void QueryDelayedExecute1Test()
    {
        // データ取得
        var list = TestProductList.CreateInstanceList();
        // クエリ発行
        var resultList = from element in list select element.Name;
        // データを直接変更
        list[0].Name = "Product100";
        // クエリ結果出力:データ直接変更後の値が出力される。
        foreach (var result in resultList) Console.WriteLine(result);
    }

    /// <summary>
    /// LINQ/クエリ構文/即時実行
    /// </summary>
    [Test]
    public void QueryImmediateExecute1Test()
    {
        // データ取得
        var list = TestProductList.CreateInstanceList();
        // クエリ発行
        var resultList = (from element in list select element.Name).ToArray();
        // データを直接変更
        list[0].Name = "Product100";
        // クエリ結果出力:オリジナルの値が出力される。
        foreach (var result in resultList) Console.WriteLine(result);
    }

    /// <summary>
    /// LINQ/要素走査
    /// </summary>
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

    /// <summary>
    /// LINQ/重複を除外する
    /// </summary>
    [Test]
    public void Distinct1Test()
    {
        var list = new List<int>();
        list.AddRange(TestValueList.CreateInstanceList());
        list.AddRange(TestValueList.CreateInstanceList());
        var distinct = list.Distinct();
        Console.WriteLine($"result:{distinct.Count()}");
        foreach (var element in distinct)
            Console.WriteLine($"result:{element}");
    }

    /// <summary>
    /// LINQ/指定したインデックスから指定した件数のデータを取得する
    /// </summary>
    [Test]
    public void SkipTake1Test()
    {
        var list = TestValueList.CreateInstanceList();
        var result = list.Skip(10).Take(20);
        foreach (var element in result)
            Console.WriteLine($"result:{element}");
    }

    /// <summary>
    /// LINQ/先頭データ取得
    /// </summary>
    [Test]
    public void First1Test()
    {
        var list = TestValueList.CreateInstanceList();
        var result = list.First();
        Console.WriteLine($"result:{result}");
    }

    /// <summary>
    /// LINQ/先頭データ(デフォルト値含む)取得
    /// </summary>
    [Test]
    public void FirstOrDefault1Test()
    {
        var list1 = TestValueList.CreateInstanceList();
        var result1 = list1.FirstOrDefault();
        Console.WriteLine($"result:{result1}");
        var list2 = new List<int>();
        var result2 = list2.FirstOrDefault();
        Console.WriteLine($"result:{result2}");
    }

    /// <summary>
    /// LINQ/集計
    /// </summary>
    [Test]
    public void GroupBy1Test()
    {
        var list = TestProductList.CreateInstanceList();
        var result = list.GroupBy(element => element.Name);
        foreach (var element in result)
        {
            Console.WriteLine($"key::{element.Key}");
            foreach (var child in element) Console.WriteLine($"child::{child.Name}");
        }
    }

    /// <summary>
    /// LINQ/集計(文字列連結)
    /// </summary>
    [Test]
    public void Aggregate1Test()
    {
        // 要素が文字列版
        var test = new List<string> { "value1", "value2", "value3" };
        var result = test.Aggregate((a, b) => a + b + "\n");
        Console.WriteLine($"データ:{result}");
    }

    public class TestValueList
    {
        public static List<int> CreateInstanceList()
        {
            var result = new List<int>();
            for (var i = 0; i < 100; i++) result.Add(i);
            return result;
        }
    }

    public class TestProductList
    {
        public static List<TestProduct> CreateInstanceList()
        {
            var result = new List<TestProduct>
            {
                new()
                {
                    Name = "Product1",
                    Price = 100,
                    PurchaseData = DateTime.Now - TimeSpan.FromDays(60)
                },
                new()
                {
                    Name = "Product2",
                    Price = 200,
                    PurchaseData = DateTime.Now - TimeSpan.FromDays(30)
                },
                new()
                {
                    Name = "Product3",
                    Price = 300,
                    PurchaseData = DateTime.Now
                }
            };
            return result;
        }
    }

    public class TestProduct
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime PurchaseData { get; set; }
    }
}