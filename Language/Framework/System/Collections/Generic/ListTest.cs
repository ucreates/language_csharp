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
    /// LINQ/クエリ構文/GroupBy/単数
    /// </summary>
    [Test]
    public void QueryGroupByStatement1Test()
    {
        var list = TestProductList.CreateInstanceList();
        var result = from element in list group element by element.Price;
        foreach (var i in result)
        {
            Console.WriteLine($"{i.Key}");
            foreach (var element in i) Console.WriteLine($"{element.Price}");
        }
    }

    /// <summary>
    /// LINQ/クエリ構文/GroupBy/複数
    /// </summary>
    [Test]
    public void QueryGroupByStatement2Test()
    {
        var list = TestProductList.CreateInstanceList();
        var result = from element in list
            group element by new
            {
                Name = element.Name,
                Price = element.Price
            };
        foreach (var i in result) Console.WriteLine($"{i.Key.Name},{i.Key.Price}");
    }

    /// <summary>
    /// LINQ/クエリ構文/GroupBy/絞り込み
    /// </summary>
    [Test]
    public void QueryGroupByStatement3Test()
    {
        var list = TestProductList.CreateInstanceList();
        var result = from element in list
            group element by element.Price
            into element2
            where element2.Average(element => element.Price) == 100
            select new
            {
                Name = element2.Key,
                AveragePrice = element2.Average(element => element.Price)
            };
        foreach (var i in result) Console.WriteLine($"{i.Name}");
    }

    /// <summary>
    /// LINQ/クエリ構文/OrderBy/昇順
    /// </summary>
    [Test]
    public void QueryOrderByStatement1Test()
    {
        var list = TestProductList.CreateInstanceList();
        var result = from element in list orderby element.Price.ToString() select element;
        foreach (var i in result) Console.WriteLine($"{i.Price}");
    }

    /// <summary>
    /// LINQ/クエリ構文/OrderBy/降順
    /// </summary>
    [Test]
    public void QueryOrderByStatement2Test()
    {
        var list = TestProductList.CreateInstanceList();
        var result = from element in list orderby element.Price.ToString() descending　select element;
        foreach (var i in result) Console.WriteLine($"{i.Price}");
    }

    /// <summary>
    /// LINQ/クエリ構文/結合
    /// </summary>
    [Test]
    public void QueryJoinStatement2Test()
    {
        var productList = TestProductList.CreateInstanceList();
        var productReviewList = TestProductReviewList.CreateInstanceList();
        var result = from left in productList
            join right in productReviewList on left.Code equals right.Code
            select new
            {
                Name = left.Name,
                User = right.Name,
                Review = right.Description
            };
        foreach (var i in result) Console.WriteLine($"{i.Name},{i.User},{i.Review}");
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
    /// LINQ/末尾データ取得
    /// </summary>
    [Test]
    public void Last1Test()
    {
        var list = TestValueList.CreateInstanceList();
        var result = list.Last();
        Assert.That(result, Is.EqualTo(99));
        Console.WriteLine($"result:{result}");
    }

    /// <summary>
    /// LINQ/末尾データ取得(デフォルト値含む)
    /// </summary>
    [Test]
    public void LastOrDefault1Test()
    {
        var list1 = TestValueList.CreateInstanceList();
        var result1 = list1.LastOrDefault();
        Assert.That(result1, Is.EqualTo(99));
        Console.WriteLine($"result:{result1}");
        var list2 = new List<int>();
        var result2 = list2.LastOrDefault();
        Assert.That(result2, Is.EqualTo(0));
        Console.WriteLine($"result:{result2}");
    }

    /// <summary>
    /// LINQ/単一データ取得
    /// </summary>
    [Test]
    public void Single1Test()
    {
        var list1 = new List<int> { 1 };
        var result = list1.Single();
        Assert.That(result, Is.EqualTo(1));
        Console.WriteLine($"result:{result}");
        var list2 = TestValueList.CreateInstanceList();
        result = list2.Single(element => element == 10);
        Assert.That(result, Is.EqualTo(10));
        Console.WriteLine($"result:{result}");
        try
        {
            var list3 = TestValueList.CreateInstanceList();
            result = list3.Single();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    /// <summary>
    /// LINQ/単一データ取得(デフォルト値含む)
    /// </summary>
    [Test]
    public void Single2Test()
    {
        var list2 = TestValueList.CreateInstanceList();
        var result = list2.SingleOrDefault(element => element == 200);
        Assert.That(result, Is.EqualTo(0));
        Console.WriteLine($"result:{result}");
    }

    /// <summary>
    /// LINQ/最小値取得
    /// </summary>
    [Test]
    public void Min1Test()
    {
        var list1 = TestValueList.CreateInstanceList();
        var result1 = list1.Min();
        Assert.That(result1, Is.EqualTo(0));
        Console.WriteLine($"result:{result1}");
    }

    /// <summary>
    /// LINQ/最小値(条件)
    /// </summary>
    [Test]
    public void Min2Test()
    {
        var list1 = TestValueList.CreateInstanceList();
        var result1 = list1.Min(element => element < 100);
        Assert.That(result1, Is.True);
        Console.WriteLine($"result1:{result1}");
        var result2 = list1.Min(element => element > 100);
        Assert.That(result2, Is.False);
        Console.WriteLine($"result2:{result2}");
    }

    /// <summary>
    /// LINQ/最大値取得
    /// </summary>
    [Test]
    public void Max1Test()
    {
        var list1 = TestValueList.CreateInstanceList();
        var result1 = list1.Max();
        Assert.That(result1, Is.EqualTo(99));
        Console.WriteLine($"result:{result1}");
    }

    /// <summary>
    /// LINQ/最大値(条件)
    /// </summary>
    [Test]
    public void Max2Test()
    {
        var list1 = TestValueList.CreateInstanceList();
        var result1 = list1.Max(element => element < 100);
        Assert.That(result1, Is.True);
        Console.WriteLine($"result1:{result1}");
        var result2 = list1.Max(element => element > 100);
        Assert.That(result2, Is.False);
        Console.WriteLine($"result2:{result2}");
    }

    /// <summary>
    /// LINQ/合計
    /// </summary>
    [Test]
    public void Sum1Test()
    {
        var list = TestValueList.CreateInstanceList();
        var result = list.Sum();
        Assert.That(result, Is.EqualTo(4950));
    }

    /// <summary>
    /// LINQ/合計(条件)
    /// </summary>
    [Test]
    public void Sum2Test()
    {
        var list = TestValueList.CreateInstanceList();
        var result = list.Sum(element => element + element);
        Assert.That(result, Is.EqualTo(9900));
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
    /// LINQ/All
    /// </summary>
    [Test]
    public void All1Test()
    {
        // 要素が文字列版
        var test = new List<int> { 1, 2, 3, 4, 5 };
        var result = test.All(element => element > 0);
        Assert.That(result, Is.True);
    }

    /// <summary>
    /// LINQ/All
    /// </summary>
    [Test]
    public void All2Test()
    {
        // 要素が文字列版
        var test = new List<string> { "value1", "value2", "value3", "element1", "element2", "element3" };
        var result = test.All(element => element.Contains("value"));
        Assert.That(result, Is.False);
    }

    /// <summary>
    /// LINQ/Any
    /// </summary>
    [Test]
    public void Any1Test()
    {
        // 要素が文字列版
        var test = new List<string> { "value1", "value2", "value3", "element1", "element2", "element3" };
        var result = test.Any(element => element.Contains("value"));
        Assert.That(result, Is.True);
    }

    /// <summary>
    /// LINQ/Any
    /// </summary>
    [Test]
    public void Any2Test()
    {
        // 要素が文字列版
        var test = new List<string> { "value1", "value2", "value3", "element1", "element2", "element3" };
        var result = test.Any(element => element.Equals("no"));
        Assert.That(result, Is.False);
    }

    /// <summary>
    /// LINQ/平均
    /// </summary>
    [Test]
    public void Average1Test()
    {
        var test = new List<int> { 1, 2, 3, 4, 5, 6 };
        var result = test.Average();
        Assert.That(result, Is.EqualTo(3.5f));
    }

    /// <summary>
    /// LINQ/平均(条件)
    /// </summary>
    [Test]
    public void Average2Test()
    {
        var test = new List<int> { 1, 2, 3, 4, 5, 6 };
        var result = test.Average(element => { return element > 4 ? element : null; });
        Assert.That(result, Is.EqualTo(5.5f));
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

    /// <summary>
    /// LINQ/型判定
    /// </summary>
    [Test]
    public void OfType1Test()
    {
        var list = TestList.CreateInstanceList();
        var result1 = list.OfType<Test1>();
        Assert.That(result1.Count(), Is.EqualTo(10));
        var result2 = list.OfType<Test2>();
        Assert.That(result2.Count(), Is.EqualTo(10));
    }

    public class TestList
    {
        public static List<BaseTest> CreateInstanceList()
        {
            var result = new List<BaseTest>();
            for (var i = 0; i < 10; i++) result.Add(new Test1());
            for (var i = 0; i < 10; i++) result.Add(new Test2());
            return result;
        }
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
                    Code = 1,
                    PurchaseData = DateTime.Now - TimeSpan.FromDays(60)
                },
                new()
                {
                    Name = "Product2",
                    Price = 200,
                    Code = 2,
                    PurchaseData = DateTime.Now - TimeSpan.FromDays(30)
                },
                new()
                {
                    Name = "Product3",
                    Price = 300,
                    Code = 3,
                    PurchaseData = DateTime.Now
                }
            };
            return result;
        }
    }

    public class TestProductReviewList
    {
        public static List<TestProductReview> CreateInstanceList()
        {
            var result = new List<TestProductReview>
            {
                new()
                {
                    Name = "User1",
                    Code = 1,
                    Description = "Good"
                },
                new()
                {
                    Name = "User1",
                    Code = 2,
                    Description = "Bad"
                },
                new()
                {
                    Name = "User1",
                    Code = 3,
                    Description = "Neither"
                }
            };
            return result;
        }
    }

    public class TestProduct
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Code { get; set; }
        public DateTime PurchaseData { get; set; }
    }

    public class TestProductReview
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public abstract class BaseTest
    {
        public int Value { get; set; } = 0;
    }

    public class Test1 : BaseTest
    {
    }

    public class Test2 : BaseTest
    {
    }
}