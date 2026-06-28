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
    public void InheritClassObject1Test1()
    {
        var instance = new InheritClassObject1();
        Console.WriteLine($"{instance}");
    }

    [Test]
    public void InheritClassObject1Test2()
    {
        var instance = new InheritClassObject1();
        instance.Show();
    }

    [Test]
    public void InheritClassObject1Test3()
    {
        var instance = new InheritClassObject1();
        Console.WriteLine(instance.Value);
    }

    [Test]
    public void InheritClassObject1Test4()
    {
        var instance = new InheritClassObject1();
        instance.OverrideMethod();
    }

    [Test]
    public void InheritClassObject1Test5()
    {
        var instance = new InheritClassObject1();
        GC.Collect();
    }

    [Test]
    public void InheritClassObject2Test1()
    {
        var instance = new InheritClassObject2();
        instance.AbstractMethod();
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

    public abstract class AbstractClassObject
    {
        public abstract void AbstractMethod();
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

    public class InheritClassObject1 : BaseClassObject
    {
        public InheritClassObject1()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(InheritClassObject1)}");
        }

        public new double Value { get; set; } = 2;

        ~InheritClassObject1()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(InheritClassObject1)}");
        }

        public new void Show()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(InheritClassObject1)}");
        }

        public override void OverrideMethod()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(InheritClassObject1)}");
        }
    }

    public class InheritClassObject2 : AbstractClassObject
    {
        public override void AbstractMethod()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(InheritClassObject2)}");
        }
    }
}