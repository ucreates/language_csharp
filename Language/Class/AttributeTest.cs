using System.Diagnostics;

namespace Language;

public class AttributeTest
{
    [Test]
    public void ObsoleteTest1()
    {
        var attribute = new Attribute();
        attribute.Method1();
    }

    [Test]
    public void CustomTest1()
    {
        var attribute = new Attribute();
        attribute.Method2();
    }

    [Test]
    public void CustomTest2()
    {
        var attribute = new Attribute();
        var result = attribute.Method3();
        Console.WriteLine(result);
    }

    [Test]
    public void ConditionalTest2()
    {
        var attribute = new Attribute();
        attribute.Method4();
    }

    private class Attribute
    {
        [Obsolete("not supported", false)]
        public void Method1()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()?.Name);
        }

        [UserDefinedAttribute]
        public int Method2()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            return 0;
        }

        [return: UserDefinedAttribute]
        public int Method3()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()?.Name);
            return 0;
        }

        [Conditional("TEST")]
        public void Method4()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()?.Name);
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    private class UserDefinedAttribute : System.Attribute
    {
        private string Name;
        public string Version;

        public UserDefinedAttribute()
        {
            Name = "UserDefinedAttribute";
            Version = "1.0";
        }
    }
}