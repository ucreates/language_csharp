namespace Language;

public class ForTest
{
    /// <summary>
    /// 基本
    /// </summary>
    [Test]
    public void For1Test()
    {
        for (var i = 0; i < 10; i++) Console.WriteLine(i);
    }

    /// <summary>
    /// 無限ループ
    /// </summary>
    [Test]
    public void For2Test()
    {
        var i = 0;
        for (;;)
        {
            Console.WriteLine(i);
            if (10 == i) break;
            i++;
        }
    }

    /// <summary>
    /// 反復子にて複数構文を実行
    /// </summary>
    [Test]
    public void For3Test()
    {
        for (var i = 0; i < 10; Console.WriteLine(i), i++) ;
    }

    /// <summary>
    /// Continue
    /// </summary>
    [Test]
    public void For4Test()
    {
        for (var i = 0; i < 10; i++)
        {
            if (0 == i % 2) continue;

            Console.WriteLine(i);
        }
    }

    /// <summary>
    /// ネスト構造
    /// </summary>
    [Test]
    public void For5Test()
    {
        for (var i = 0; i < 10; i++)
        {
            for (var j = 0; j < 10; j++) Console.WriteLine($"j::{j}");

            Console.WriteLine($"i::{i}");
        }
    }
}