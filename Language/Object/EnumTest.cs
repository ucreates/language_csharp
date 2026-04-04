namespace Language;

public class EnumTest
{
    [Test]
    public void PublicClassObjectTest1()
    {
        Console.WriteLine($"{PublicEnumObject.Test}");
    }

    [Test]
    public void ProtectedClassObjectTest1()
    {
        Console.WriteLine($"{ProtectedEnumObject.Test}");
    }

    [Test]
    public void ProtectedInternalClassObjectTest1()
    {
        Console.WriteLine($"{ProtectedInternalEnumObject.Test}");
    }

    [Test]
    public void InternalClassObjectTest1()
    {
        Console.WriteLine($"{InternalEnumObject.Test}");
    }

    [Test]
    public void PrivateClassObjectTest1()
    {
        Console.WriteLine($"{PrivateEnumObject.Test}");
    }

    public enum PublicEnumObject
    {
        Test
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