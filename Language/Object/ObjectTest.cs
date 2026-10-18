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
}

public class ObjectClass1
{
    public string Name1;
    public string Name2;

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
}