namespace Language;

public class SwitchTest
{
    /// <summary>
    /// スイッチ(整数)
    /// </summary>
    [Test]
    public void Switch1Test()
    {
        var callback = new Action<int>(delegate(int value)
        {
            switch (value)
            {
                case 1:
                    Console.WriteLine(1);
                    break;
                case 2:
                    Console.WriteLine(2);
                    break;
                case 3:
                    Console.WriteLine(3);
                    break;
                default:
                    Console.WriteLine("other");
                    break;
            }
        });
        callback(1);
        callback(2);
        callback(3);
    }

    /// <summary>
    /// スイッチ(文字列)
    /// </summary>
    [Test]
    public void Switch2Test()
    {
        var callback = new Action<string>(delegate(string value)
        {
            switch (value)
            {
                case "a":
                    Console.WriteLine("a");
                    break;
                case "b":
                    Console.WriteLine("b");
                    break;
                case "c":
                    Console.WriteLine("c");
                    break;
                default:
                    Console.WriteLine("other");
                    break;
            }
        });
        callback("a");
        callback("b");
        callback("c");
    }

    /// <summary>
    /// スイッチ(型)
    /// </summary>
    [Test]
    public void Switch3Test()
    {
        var callback = new Action<object>(delegate(object value)
        {
            switch (value)
            {
                case int nValue:
                    Console.WriteLine($"{nValue} is int");
                    break;
                case string strValue:
                    Console.WriteLine($"{strValue} is string");
                    break;
                case bool bValue:
                    Console.WriteLine($"{bValue} is boolean");
                    break;
                default:
                    Console.WriteLine("other");
                    break;
            }
        });
        callback(1);
        callback("b");
        callback(false);
    }

    /// <summary>
    /// スイッチ(条件)
    /// </summary>
    [Test]
    public void Switch4Test()
    {
        var callback = new Action<int>(delegate(int value)
        {
            switch (value)
            {
                case 1:
                    Console.WriteLine("1");
                    break;
                case int n when 0 < n && n < 10:
                    Console.WriteLine($"{n}=Plus");
                    break;
                case int n when -10 < n && n < 0:
                    Console.WriteLine($"{n}=Minus");
                    break;
                case int n:
                    Console.WriteLine($"{n}=Integer");
                    break;
                default:
                    Console.WriteLine("other");
                    break;
            }
        });
        callback(1);
        callback(2);
        callback(-2);
        callback(99);
        callback(-99);
    }
}