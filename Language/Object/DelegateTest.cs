namespace Language;

public class DelegateTest
{
    [Test]
    public void Delegate1Test()
    {
        var obj = new BasicDelegate();
        var cb = new BasicDelegate.DelegateExecute1(obj.ExecuteNormal1);
        cb();
    }

    [Test]
    public void Delegate2Test()
    {
        var obj = new BasicDelegate();
        var cb = new BasicDelegate.DelegateExecute2(obj.ExecuteParams1);
        cb("test");
    }

    [Test]
    public void Delegate3Test()
    {
        var obj = new BasicDelegate();
        var cb = new BasicDelegate.DelegateExecute1(obj.ExecuteNormal1);
        obj.ExecuteDelegate1(cb);
    }

    [Test]
    public void MulticastDelegate1Test()
    {
        var obj = new BasicDelegate();
        BasicDelegate.DelegateExecute1 cb = obj.ExecuteNormal1;
        cb += obj.ExecuteNormal2;
        cb();
    }

    [Test]
    public void MulticastDelegate2Test()
    {
        var obj = new BasicDelegate();
        var delg = new BasicDelegate.DelegateExecute1(obj.ExecuteNormal1);
        delg += obj.ExecuteNormal2;
        delg();
    }

    [Test]
    public void MulticastDelegate3Test()
    {
        var obj = new BasicDelegate();
        BasicDelegate.DelegateExecute3 cb = obj.ExecuteReturn1;
        cb += obj.ExecuteReturn2;
        cb += obj.ExecuteReturn3;
        var result = cb();
        Console.WriteLine(result);
    }

    [Test]
    public void Anonymous1Test()
    {
        var obj = new BasicDelegate();
        obj.ExecuteAnonymous1(delegate()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            return;
        });
    }

    [Test]
    public void Anonymous2Test()
    {
        var obj = new BasicDelegate();
        obj.ExecuteAnonymous2(delegate() { return 0; });
    }

    public class BasicDelegate
    {
        public delegate void DelegateExecute1();

        public delegate void DelegateExecute2(string value);

        public delegate int DelegateExecute3();

        public void ExecuteNormal1()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()?.Name);
        }

        public void ExecuteNormal2()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()?.Name);
        }

        public void ExecuteParams1(string value)
        {
            Console.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} {value}");
        }

        public void ExecuteDelegate1(DelegateExecute1 cb)
        {
            cb();
        }

        public int ExecuteReturn1()
        {
            return 0;
        }

        public int ExecuteReturn2()
        {
            return 1;
        }

        public int ExecuteReturn3()
        {
            return 2;
        }

        public void ExecuteAnonymous1(Action cb)
        {
            cb();
        }

        public void ExecuteAnonymous2(Func<int> cb)
        {
            var result = cb();
            Console.WriteLine($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} {result}");
        }
    }
}