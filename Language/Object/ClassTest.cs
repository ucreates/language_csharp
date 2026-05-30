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

    [Test]
    public void InheritClassObjectTest2()
    {
        var instance = new InheritClassObject();
        instance.Show();
    }

    [Test]
    public void InheritClassObjectTest3()
    {
        var instance = new InheritClassObject();
        Console.WriteLine(instance.Value);
    }

    [Test]
    public void InheritClassObjectTest4()
    {
        var instance = new InheritClassObject();
        instance.OverrideMethod();
    }

    [Test]
    public void InheritClassObjectTest5()
    {
        var instance = new InheritClassObject();
        GC.Collect();
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
        public BaseClassObject()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(BaseClassObject)}");
        }

        public double Value { get; set; } = 0;

        ~BaseClassObject()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(BaseClassObject)}");
        }

        public void Execute()
        {
            Console.WriteLine(MethodBase.GetCurrentMethod()?.Name);
        }

        public void Show()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(BaseClassObject)}");
        }

        public virtual void OverrideMethod()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(BaseClassObject)}");
        }
    }

    public class InheritClassObject : BaseClassObject
    {
        public InheritClassObject()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(InheritClassObject)}");
        }

        public new double Value { get; set; } = 2;

        ~InheritClassObject()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(InheritClassObject)}");
        }

        public new void Show()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(InheritClassObject)}");
        }

        public override void OverrideMethod()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(InheritClassObject)}");
        }
    }
}