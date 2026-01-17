namespace Language;

public class ForeachTest
{
    /// <summary>
    /// 基本
    /// </summary>
    [Test]
    public void ForEach1Test()
    {
        var result = GetTestValueArrays();
        foreach (var i in result) Console.WriteLine(i);
    }

    /// <summary>
    /// テストデータ取得
    /// </summary>
    /// <returns></returns>
    public int[] GetTestValueArrays()
    {
        return new[] { 1, 2, 3, 4, 5 };
    }
}