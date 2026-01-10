namespace Language;

public class IfTest
{
    /// <summary>
    /// 単純分岐
    /// </summary>
    [Test]
    public void SingleBranchTest()
    {
        var resultLong1 = new Random().NextInt64();
        if (resultLong1 < long.MaxValue / 2)
            Console.WriteLine($"result {resultLong1}");
        else
            Console.WriteLine($"result {resultLong1}");

        var resultBool1 = 0 == resultLong1 % 2;
        if (resultBool1)
            Console.WriteLine($"true");
        else
            Console.WriteLine($"false");

        if (!resultBool1)
            Console.WriteLine($"true");
        else
            Console.WriteLine($"false");

        var resultLong2 = new Random().NextInt64();
        var resultBool2 = 0 == resultLong2 % 2;

        if (resultBool1 && resultBool2)
            Console.WriteLine($"true");
        else
            Console.WriteLine($"false");

        if (resultBool1 || resultBool2)
            Console.WriteLine($"true");
        else
            Console.WriteLine($"false");
    }

    /// <summary>
    /// 多岐分岐
    /// </summary>
    [Test]
    public void MultipleBranchTest()
    {
        var resultLong = new Random().NextInt64();
        if (resultLong < long.MaxValue / 3)
            Console.WriteLine($"result {resultLong}");
        else if (resultLong < long.MaxValue / 2)
            Console.WriteLine($"result {resultLong}");
        else
            Console.WriteLine($"result {resultLong}");
    }

    /// <summary>
    /// ネスト分岐
    /// </summary>
    [Test]
    public void NestBranchTest()
    {
        var resultLong = new Random().NextInt64();
        if (resultLong < long.MaxValue / 3)
            if (resultLong % 2 == 0)
                Console.WriteLine($"result {resultLong}");
            else
                Console.WriteLine($"result {resultLong}");
        else if (resultLong < long.MaxValue / 2)
            if (resultLong % 2 == 0)
                Console.WriteLine($"result {resultLong}");
            else
                Console.WriteLine($"result {resultLong}");
        else if (resultLong % 2 == 0)
            Console.WriteLine($"result {resultLong}");
        else
            Console.WriteLine($"result {resultLong}");
    }
}