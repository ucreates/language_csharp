using System.Reflection;

namespace Language;

public class ClassTest
{
    [Test]
    public void PublicClassObjectTest1()
    {
        var instance = new PublicClassObject();
        Console.WriteLine($"{instance}");
    }

    [Test]
    public void ProtectedClassObjectTest1()
    {
        var instance = new ProtectedClassObject();
        Console.WriteLine($"{instance}");
    }

    [Test]
    public void ProtectedInternalClassObjectTest1()
    {
        var instance = new ProtectedInternalClassObject();
        Console.WriteLine($"{instance}");
    }

    [Test]
    public void InternalClassObjectTest1()
    {
        var instance = new InternalClassObject();
        Console.WriteLine($"{instance}");
    }

    [Test]
    public void PrivateClassObjectTest1()
    {
        var instance = new PrivateClassObject();
        Console.WriteLine($"{instance}");
    }

    [Test]
    public void BaseClassObjectTest1()
    {
        var instance = new BaseClassObject();
        Console.WriteLine($"{instance}");
    }

    [Test]
    public void InheritClassObjectTest1()
    {
        var instance = new InheritClassObject();
        Console.WriteLine($"{instance}");
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

    public class BaseClassObject
    {
        public void Execute()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod()?.Name);
        }
    }

    public class InheritClassObject : BaseClassObject
    {
    }
}