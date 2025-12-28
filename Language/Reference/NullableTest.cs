namespace Language.Reference;

public class NullableTest
{
    /// <summary>
    /// 明示型
    /// </summary>
    [Test]
    public void ExplicitlyTest()
    {
        Nullable<int> value = null;
        Console.WriteLine($"result {value}");
        value = 1;
        Console.WriteLine($"result {value}");
        var obj = new Reference();
        Console.WriteLine($"result {obj.Value2}");
        obj.Value2 = 1;
        Console.WriteLine($"result {obj.Value2}");
    }

    /// <summary>
    /// 非明示型
    /// </summary>
    [Test]
    public void NotExplicitlyTest()
    {
        int? value = null;
        Console.WriteLine($"result {value}");
        value = 1;
        Console.WriteLine($"result {value}");
        var obj = new Reference();
        Console.WriteLine($"result {obj.Value1}");
        obj.Value1 = 1;
        Console.WriteLine($"result {obj.Value1}");
    }

    /// <summary>
    /// 変換
    /// </summary>
    [Test]
    public void ConvertTest()
    {
        int? value1 = 1;
        Console.WriteLine($"result {value1}");
        var value2 = (int)value1;
        Console.WriteLine($"result {value2}");
        value1 = null;
        Console.WriteLine($"result {value1}");
        value2 = (int)(value1 ?? 2);
        Console.WriteLine($"result {value2}");
    }

    /// <summary>
    /// Value
    /// </summary>
    [Test]
    public void ValueTest()
    {
        int? value1 = 1;
        Console.WriteLine($"result {value1.Value}");
        var value = new Reference();
        value.Value1 = 1;
        Console.WriteLine($"result {value.Value1.Value}");
    }

    /// <summary>
    /// HasValue
    /// </summary>
    [Test]
    public void HasValueTest()
    {
        int? value1 = 1;
        Console.WriteLine($"result {value1.HasValue}");
        int? value2 = null;
        Console.WriteLine($"result {value2.HasValue}");
        var value3 = new Reference();
        Console.WriteLine($"result {value3.Value1.HasValue}");
    }

    public class Reference
    {
        public int? Value1 { get; set; }
        public Nullable<int> Value2 { get; set; }
    }
}