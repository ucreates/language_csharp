namespace Language;

public class LocalTest
{
    /// <summary>
    /// ローカル関数定義
    /// </summary>
    [Test]
    public void Local1Test()
    {
        double LocalMethod(double a, double b)
        {
            return a + b;
        }

        Console.WriteLine(LocalMethod(1, 2));
    }
}