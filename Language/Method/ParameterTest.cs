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
    public void ParamsTest()
    {
        new Parameter().Params(1, 2, 3);
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

    public void Params(params int[] numbers)
    {
        foreach (var number in numbers) Console.Write($"params {number}\n");
    }
}