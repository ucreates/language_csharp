namespace Language;

public class ObjectTest
{
    [Test]
    public void ToStringTest1()
    {
        var instance = new ObjectClass1("ObjectName1", "ObjectName2");
        Console.WriteLine($"{instance}");
    }

    [Test]
    public void EqualsTest1()
    {
        var instance1 = new ObjectClass1("ObjectName1", "ObjectName2");
        var instance2 = new ObjectClass1("ObjectName1", "ObjectName2");
        Assert.That(instance1.Equals(instance2), Is.True);
    }

    [Test]
    public void EqualsTest2()
    {
        var instance1 = new ObjectClass1("ObjectName1", "ObjectName2");
        var instance2 = new ObjectClass1("ObjectName1", "ObjectName2");
        var instance3 = new ObjectClass1("ObjectName3", "ObjectName4");
        Assert.That(instance1 == instance2, Is.True);
        Assert.That(instance1 != instance3, Is.True);
    }

    [Test]
    public void IncrementTest1()
    {
        var instance1 = new ObjectClass1("ObjectName1", "ObjectName2");
        var instance2 = ++instance1;
        Assert.That(instance2.Name1, Is.EqualTo(instance1.Name1));
        Assert.That(instance2.Name2, Is.EqualTo(instance1.Name2));
        Assert.That(instance2.Value1, Is.EqualTo(instance1.Value1++));
        Assert.That(instance2.Value2, Is.EqualTo(instance1.Value2++));
    }

    [Test]
    public void DecrementTest1()
    {
        var instance1 = new ObjectClass1("ObjectName1", "ObjectName2");
        var instance2 = --instance1;
        Assert.That(instance2.Name1, Is.EqualTo(instance1.Name1));
        Assert.That(instance2.Name2, Is.EqualTo(instance1.Name2));
        Assert.That(instance2.Value1, Is.EqualTo(instance1.Value1--));
        Assert.That(instance2.Value2, Is.EqualTo(instance1.Value2--));
    }

    [Test]
    public void OperatorBoolTest1()
    {
        var instance1 = new ObjectClass1("ObjectName1", "ObjectName2");
        var instance2 = ++instance1;
        if (instance2)
            Console.WriteLine("true");
        else
            Console.WriteLine("false");
    }

    [Test]
    public void OperatorBoolTest2()
    {
        var instance1 = new ObjectClass1("ObjectName1", "ObjectName2");
        var instance2 = --instance1;
        if (instance2)
            Console.WriteLine("true");
        else
            Console.WriteLine("false");
    }
}

public class ObjectClass1
{
    public string Name1;
    public string Name2;
    public int Value1;
    public int Value2;

    public ObjectClass1()
    {
    }

    public ObjectClass1(string name1, string name2)
    {
        Name1 = name1;
        Name2 = name2;
    }

    public override string ToString()
    {
        return $"{Name1} {Name2}";
    }

    public override bool Equals(object? other)
    {
        if (ReferenceEquals(this, other)) return true;

        if (other is null) return false;

        var instance = other as ObjectClass1;
        return instance?.Name1 == Name1 && instance?.Name2 == Name2;
    }

    public override int GetHashCode()
    {
        return Name1.GetHashCode() ^ Name2.GetHashCode();
    }

    public static bool operator ==(ObjectClass1 obj1, ObjectClass1 obj2)
    {
        if (ReferenceEquals(obj1, obj2)) return true;
        return obj1.Name1.Equals(obj2.Name1) && obj1.Name2.Equals(obj2.Name2);
    }

    public static bool operator !=(ObjectClass1 obj1, ObjectClass1 obj2)
    {
        return !(obj1 == obj2);
    }

    public static ObjectClass1 operator ++(ObjectClass1 obj)
    {
        return new ObjectClass1
        {
            Name1 = obj.Name1,
            Name2 = obj.Name2,
            Value1 = obj.Value1 + 1,
            Value2 = obj.Value2 + 1
        };
    }

    public static ObjectClass1 operator --(ObjectClass1 obj)
    {
        return new ObjectClass1
        {
            Name1 = obj.Name1,
            Name2 = obj.Name2,
            Value1 = obj.Value1 - 1,
            Value2 = obj.Value2 - 1
        };
    }

    public static bool operator true(ObjectClass1 obj)
    {
        return obj.Value1 >= 0 && obj.Value2 >= 0;
    }

    public static bool operator false(ObjectClass1 obj)
    {
        return obj.Value1 < 0 || obj.Value2 < 0;
    }
}