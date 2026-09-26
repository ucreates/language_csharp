namespace Language;

public class EnumTest
{
    public enum PublicEnumIntObject
    {
        Test1 = 1,
        Test2 = 2,
        Test3 = 3,
        SumAll = Test1 + Test2 + Test3
    }

    public enum PublicEnumObject
    {
        Test1,
        Test2,
        Test3
    }

    [Test]
    public void PublicEnumTest1()
    {
        Console.WriteLine($"{PublicEnumObject.Test1},{PublicEnumObject.Test2},{PublicEnumObject.Test3}");
    }

    [Test]
    public void PublicEnumTest2()
    {
        Console.WriteLine(
            $"{PublicEnumIntObject.Test1},{PublicEnumIntObject.Test2},{PublicEnumIntObject.Test3},{PublicEnumIntObject.SumAll}");
        Console.WriteLine(
            $"{PublicEnumIntObject.Test1.ToString("d")},{PublicEnumIntObject.Test2.ToString("d")},{PublicEnumIntObject.Test3.ToString("d")},{PublicEnumIntObject.SumAll.ToString("d")}");
        Console.WriteLine(
            $"{PublicEnumIntObject.Test1.ToString("x")},{PublicEnumIntObject.Test2.ToString("x")},{PublicEnumIntObject.Test3.ToString("x")},{PublicEnumIntObject.SumAll.ToString("x")}");
    }

    [Test]
    public void PublicEnumTest3()
    {
        Console.WriteLine($"{(PublicEnumIntObject)Enum.Parse(typeof(PublicEnumIntObject), "Test1")}");
        Console.WriteLine($"{(PublicEnumIntObject)Enum.Parse(typeof(PublicEnumIntObject), "1")}");
    }

    [Test]
    public void PublicEnumTest4()
    {
        var result = Enum.TryParse("Test1", out PublicEnumIntObject e);
        Console.WriteLine($"{result}/{e}");
    }

    [Test]
    public void PublicEnumTest5()
    {
        foreach (var value in Enum.GetValues(typeof(PublicEnumObject))) Console.WriteLine($"{(int)value}/{value}");
    }

    [Test]
    public void PublicEnumTest6()
    {
        foreach (var name in Enum.GetNames(typeof(PublicEnumObject))) Console.WriteLine($"{name}");
    }

    [Test]
    public void PublicEnumTest7()
    {
        var flags = PublicEnumObject.Test1 | PublicEnumObject.Test2;
        Assert.That(flags.HasFlag(PublicEnumObject.Test1), Is.True);
        Assert.That(flags.HasFlag(PublicEnumObject.Test2), Is.True);
        Assert.That(flags.HasFlag(PublicEnumObject.Test3), Is.False);
    }

    [Test]
    public void ProtectedEnumTest1()
    {
        Console.WriteLine($"{ProtectedEnumObject.Test}");
    }

    [Test]
    public void ProtectedInternalEnumTest1()
    {
        Console.WriteLine($"{ProtectedInternalEnumObject.Test}");
    }

    [Test]
    public void InternalEnumTest1()
    {
        Console.WriteLine($"{InternalEnumObject.Test}");
    }

    [Test]
    public void PrivateEnumTest1()
    {
        Console.WriteLine($"{PrivateEnumObject.Test}");
    }

    protected enum ProtectedEnumObject
    {
        Test
    }

    protected internal enum ProtectedInternalEnumObject
    {
        Test
    }

    internal enum InternalEnumObject
    {
        Test
    }

    private enum PrivateEnumObject
    {
        Test
    }
}