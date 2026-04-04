namespace Language;

public class ClassTest
{
    [Test]
    public void PublicClassObjectTest1()
    {
        var instance = new PublicClassObject();
        Console.WriteLine($"{instance.ToString()}");
    }

    [Test]
    public void ProtectedClassObjectTest1()
    {
        var instance = new ProtectedClassObject();
        Console.WriteLine($"{instance.ToString()}");
    }

    [Test]
    public void ProtectedInternalClassObjectTest1()
    {
        var instance = new ProtectedInternalClassObject();
        Console.WriteLine($"{instance.ToString()}");
    }

    [Test]
    public void InternalClassObjectTest1()
    {
        var instance = new InternalClassObject();
        Console.WriteLine($"{instance.ToString()}");
    }

    [Test]
    public void PrivateClassObjectTest1()
    {
        var instance = new PrivateClassObject();
        Console.WriteLine($"{instance.ToString()}");
    }

    public class PublicClassObject
    {
    }

    protected class ProtectedClassObject
    {
    }

    protected internal class ProtectedInternalClassObject
    {
    }

    internal class InternalClassObject
    {
    }

    private class PrivateClassObject
    {
    }
}