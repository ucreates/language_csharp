namespace Language;

public class WhileTest
{
    /// <summary>
    /// 基本
    /// </summary>
    [Test]
    public void While1Test()
    {
        var i = 1;
        while (i < 6)
        {
            Console.WriteLine($"loop::{i}");
            i++;
        }
    }

    /// <summary>
    /// 前置判定
    /// </summary>
    [Test]
    public void While2Test()
    {
        var i = 6;
        while (i < 6)
        {
            // 出力されない
            Console.WriteLine($"loop::{i}");
            i++;
        }
    }

    /// <summary>
    /// 基本
    /// </summary>
    [Test]
    public void DoWhile1Test()
    {
        var i = 1;
        do
        {
            Console.WriteLine($"loop::{i}");
            i++;
        } while (i < 6);
    }

    /// <summary>
    /// 後置判定
    /// </summary>
    [Test]
    public void DoWhile2Test()
    {
        var i = 6;
        do
        {
            // 必ず1回は出力される
            Console.WriteLine($"loop::{i}");
            i++;
        } while (i < 6);
    }
}