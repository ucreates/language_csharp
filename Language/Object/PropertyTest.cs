using System.Reflection;

namespace Language;

public class PropertyTest
{
    [Test]
    public void PublicPropertyTest()
    {
        var instance = new PropertyClassObject();
        instance.PublicProperty = 1;
        Console.WriteLine($"{instance.PublicProperty}");
    }

    [Test]
    public void PublicStaticPropertyTest()
    {
        PropertyClassObject.PublicStaticProperty = 2;
        Console.WriteLine($"{PropertyClassObject.PublicStaticProperty}");
    }

    [Test]
    public void PublicNewPropertyTest()
    {
        var instance = new PropertyClassObject();
        Console.WriteLine($"{instance.NewProperty}");
    }

    [Test]
    public void VirtualPropertyTest()
    {
        var instance = new PropertyClassObject();
        Console.WriteLine($"{instance.VirtualProperty}");
    }

    [Test]
    public void SealedPropertyTest()
    {
        var instance = new PropertyClassObject();
        Console.WriteLine($"{instance.SealedProperty}");
    }

    [Test]
    public void NonPublicPropertyTest()
    {
        var propertyClassObject = typeof(PropertyClassObject);
        propertyClassObject.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .ToList().ForEach(method => Console.WriteLine($"{method}"));
    }

    public class PropertyClassObject : PropertyBaseClassObject
    {
        public int PublicProperty { get; set; }
        public static int PublicStaticProperty { get; set; }
        public new int NewProperty => 999;
        public override int VirtualProperty => 888;
        public sealed override int SealedProperty => 666;
        protected int ProtectedProperty { get; set; }
        protected internal int ProtectedInternalProperty { get; set; }
        internal int InternalProperty { get; set; }
        private int PrivateProperty { get; set; }
    }

    public class PropertyBaseClassObject : AbstractPropertyClassObject
    {
        public int NewProperty => -999;
        public virtual int VirtualProperty => -888;
        public override int AbstractProperty => -777;
        public virtual int SealedProperty => -666;
    }

    public abstract class AbstractPropertyClassObject
    {
        public abstract int AbstractProperty { get; }
    }
}