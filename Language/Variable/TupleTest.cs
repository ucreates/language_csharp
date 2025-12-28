namespace Language;

public class TupleTest
{
    [Test]
    public void NormalTest()
    {
        var result = new Tuple().VerificationNormal();
        Assert.That(result.Item1, Is.EqualTo(1));
        Assert.That(result.Item2, Is.EqualTo("test"));
        Assert.That(result.Item3.Name, Is.EqualTo("TestObject"));
    }

    [Test]
    public void WithNameTest()
    {
        var result = new Tuple().VerificationWithName();
        Assert.That(result.index, Is.EqualTo(1));
        Assert.That(result.value, Is.EqualTo("test"));
        Assert.That(result.testObject.Name, Is.EqualTo("TestObject"));
    }

    [Test]
    public void ArrayTest()
    {
        var results = new Tuple().VerificationArray();
        for (var i = 0; i < results.Length; i++)
        {
            var result = results[i];
            Assert.That(result.Item1, Is.EqualTo(i + 1));
            Assert.That(result.Item2, Is.EqualTo($"test{i + 1}"));
            Assert.That(result.Item3.Name, Is.EqualTo($"TestObject{i + 1}"));
        }
    }
}

public class Tuple
{
    public (int, string, Variable.TestVariableObject) VerificationNormal()
    {
        (int, string, Variable.TestVariableObject) tuple = new(1, "test",
            new Variable.TestVariableObject { Name = "TestObject" });
        return tuple;
    }

    public (int index, string value, Variable.TestVariableObject testObject) VerificationWithName()
    {
        (int index, string value, Variable.TestVariableObject testObject) tuple = new(1, "test",
            new Variable.TestVariableObject { Name = "TestObject" });
        return tuple;
    }

    public (int, string, Variable.TestVariableObject)[] VerificationArray()
    {
        var tuples = new (int, string, Variable.TestVariableObject)[]
        {
            (1, "test1", new Variable.TestVariableObject { Name = "TestObject1" }),
            (2, "test2", new Variable.TestVariableObject { Name = "TestObject2" })
        };
        return tuples;
    }
}