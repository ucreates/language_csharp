namespace Language;

using System.Diagnostics;

public class ParameterTest
{
    [Test]
    public void InTest()
    {
        new Parameter().In(1);
    }

    [Test]
    public void Out1Test()
    {
        var result = new Parameter().OutNormal("1");
        Assert.That(result, Is.EqualTo(1));
        result = new Parameter().OutNormal("2");
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Out2Test()
    {
        var result = new Parameter().OutTypeInference("1");
        Assert.That(result, Is.EqualTo(1));
        result = new Parameter().OutTypeInference("2");
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Default1Test()
    {
        new Parameter().Default();
        new Parameter().Default("1");
        new Parameter().Default("1", "2");
    }

    [Test]
    public void WithName1Test()
    {
        new Parameter().WithName("value1", "value2");
        new Parameter().WithName("value2", "value1");
    }

    [Test]
    public void Params1Test()
    {
        new Parameter().ParamsSingle(1, 2, 3);
    }

    [Test]
    public void Params2Test()
    {
        new Parameter().ParamsMulti("params", 1, 2, 3);
    }
}

public class Parameter
{
    public void In(in int number)
    {
        Console.Write(number);
    }

    public int OutNormal(string strNumber)
    {
        int result;
        int.TryParse(strNumber, out result);
        return result;
    }

    public int OutTypeInference(string strNumber)
    {
        return int.TryParse(strNumber, out var n) ? n : default;
    }

    public void Default(string value1 = "value1", string value2 = "value2")
    {
        Console.WriteLine($"{value1}.{value2}");
    }

    public void WithName(string value1, string value2)
    {
        Console.WriteLine($"{value1}.{value2}");
    }

    public void ParamsSingle(params int[] numbers)
    {
        foreach (var number in numbers) Console.WriteLine($"params {number}");
    }

    public void ParamsMulti(string value, params int[] numbers)
    {
        Console.WriteLine(value);
        foreach (var number in numbers) Console.WriteLine($"params {number}");
    }
}