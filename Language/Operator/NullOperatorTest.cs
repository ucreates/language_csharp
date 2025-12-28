namespace Language;

public class NullOperatorTest
{
    /// <summary>
    /// null合体演算子
    /// </summary>
    [Test]
    public void NullUnionTest()
    {
        // null判定の場合
        string? value1 = null;
        var result = value1 ?? "value1";
        Console.WriteLine($"result {result}");
        //　代入の場合
        string? value2 = null;
        value2 ??= "value2";
        Console.WriteLine($"result {value2}");
    }

    /// <summary>
    /// null条件演算子
    /// </summary>
    [Test]
    public void NullConditionTest()
    {
        Variable.TestVariableObject value = null;
        Console.WriteLine($"result {value?.Name}");
    }

    /// <summary>
    /// null条件Indexer
    /// </summary>
    [Test]
    public void NullConditionIndexerTest()
    {
        Dictionary<string, string> value = null;
        Console.WriteLine($"result {value?["key"]}");
    }

    /// <summary>
    /// null抑制演算子
    /// </summary>
    [Test]
    public void NullRestraintTest()
    {
        var value = new Dictionary<string, string>();
        Console.WriteLine($"result {value!.ContainsKey("key")}");
    }
}