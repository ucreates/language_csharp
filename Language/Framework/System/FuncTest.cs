namespace Language;

public class FuncTest
{
    [Test]
    public void DelegateTest()
    {
        // delegate版
        Func<int, (int timebarDuration, int endFrameThumbDuration)> func = delegate(int index) { return (1, 1); };
        var result = func(1);
        Console.WriteLine($"result1:{result.timebarDuration},result2:{result.endFrameThumbDuration}");
    }

    [Test]
    public void LambdaTest()
    {
        // ラムダ式 版
        Func<int, (int timebarDuration, int endFrameThumbDuration)> func = (int index) => { return (1, 1); };
        var result = func(1);
        Console.WriteLine($"result1:{result.timebarDuration},result2:{result.endFrameThumbDuration}");
    }

    [Test]
    public void Var1Test()
    {
        // var(パターン1) 版
        var func = new Func<int, (int timebarDuration, int endFrameThumbDuration)>(delegate(int index)
        {
            Console.WriteLine($"params:{index}");
            return (1, 1);
        });
        var result = func(1);
        Console.WriteLine($"result1:{result.timebarDuration},result2:{result.endFrameThumbDuration}");
    }

    [Test]
    public void Var2Test()
    {
        // var(パターン2) 版
        var func = new Func<int, (int timebarDuration, int endFrameThumbDuration)>((int index) =>
        {
            Console.WriteLine($"params:{index}");
            return (1, 1);
        });
        var result = func(1);
        Console.WriteLine($"result1:{result.timebarDuration},result2:{result.endFrameThumbDuration}");
    }
}