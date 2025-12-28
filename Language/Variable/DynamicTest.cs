namespace Language;

public class DynamicTest
{
    [Test]
    public void ValueTest()
    {
        var result = new Dynamic().VerificationValue();
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void StructTest()
    {
        var result = new Dynamic().VerificationStruct();
        Assert.That(result.Name, Is.EqualTo("test"));
    }

    [Test]
    public void ObjectTest()
    {
        var result = new Dynamic().VerificationObject();
        Assert.That(result.Name, Is.EqualTo("test"));
        Assert.That(result.Method(), Is.EqualTo(0));
    }
}

public class Dynamic
{
    public dynamic VerificationValue()
    {
        return 0;
    }

    public dynamic VerificationStruct()
    {
        dynamic sample = new Variable.TestVariableStruct();
        sample.Name = "test";
        return sample;
    }

    public dynamic VerificationObject()
    {
        dynamic sample = new Variable.TestVariableObject();
        sample.Name = "test";
        return sample;
    }
}