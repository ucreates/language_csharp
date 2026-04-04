namespace Language;

public class StructTest
{
    [Test]
    public void PublicStructObjectTest1()
    {
        var instance = new PublicStructObject();
        Console.WriteLine($"{instance.ToString()}");
    }

    [Test]
    public void ProtectedStructObjectTest1()
    {
        var instance = new ProtectedStructObject();
        Console.WriteLine($"{instance.ToString()}");
    }

    [Test]
    public void ProtectedInternalStructObjectTest1()
    {
        var instance = new ProtectedInternalStructObject();
        Console.WriteLine($"{instance.ToString()}");
    }

    [Test]
    public void InternalStructObjectTest1()
    {
        var instance = new InternalStructObject();
        Console.WriteLine($"{instance.ToString()}");
    }

    [Test]
    public void PrivateStructObjectTest1()
    {
        var instance = new PrivateStructObject();
        Console.WriteLine($"{instance.ToString()}");
    }

    public struct PublicStructObject
    {
    }

    protected struct ProtectedStructObject
    {
    }

    protected internal struct ProtectedInternalStructObject
    {
    }

    internal struct InternalStructObject
    {
    }

    private struct PrivateStructObject
    {
    }
}