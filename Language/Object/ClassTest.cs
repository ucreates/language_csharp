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

    [Test]
    public void PartialClassObject1Test1()
    {
        var instance = new PartialClassObject1();
        instance.Show1();
        instance.Show2();
    }

    [Test]
    public void GenericClassObject1Test1()
    {
        var instance = new GenericClassObject1<int>();
        instance.Value = default;
        instance.SetPER(0);
        instance.CompareTo(1, 0);
    }

    [Test]
    public void NestClassObject1Test1()
    {
        var instance = new NestClassObject1();
        instance.Execute();
    }

    [Test]
    public void NestClassObject1Test2()
    {
        var instance = new NestClassObject1.NestClassObject2();
        instance.Execute();
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

    public partial class PartialClassObject1
    {
        private partial void Show3();

        public void Show1()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(InheritClassObject2)}");
        }
    }

    public partial class PartialClassObject1
    {
        public void Show2()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(InheritClassObject2)}");
            Show3();
        }

        private partial void Show3()
        {
            Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(InheritClassObject2)}");
        }
    }

    public class GenericClassObject1<T> where T : IComparable<T>
    {
        public T Value { get; set; }

        public void SetPER(T value)
        {
            Console.WriteLine($"faild {value} and set default ");
        }

        public T CompareTo(T previousSeason, T thisSeason)
        {
            if (0 > thisSeason.CompareTo(previousSeason)) Console.WriteLine("faild and set default ");

            return default;
        }
    }

    public class NestClassObject1
    {
        public void Execute()
        {
            var nest = new NestClassObject2();
            nest.Execute();
        }

        public class NestClassObject2
        {
            public void Execute()
            {
                Console.WriteLine($"{MethodBase.GetCurrentMethod()?.Name} from {nameof(InheritClassObject2)}");
            }
        }
    }
}