using System.Reflection;

namespace Language;

using System.Linq;
using System.Collections.Generic;

public class ReflectionTest
{
    [Test]
    public void Activator1Test()
    {
        var reflectionTest = Activator.CreateInstance(typeof(ReflectionClass));
        Console.WriteLine($"{reflectionTest.ToString()}");
    }

    [Test]
    public void GetConstructor1Test()
    {
        var reflectionTest = typeof(ReflectionClass);
        Console.WriteLine("## 【default】");
        reflectionTest.GetConstructors().ToList().ForEach(method => Console.WriteLine($"{method.ToString()}"));
        Console.WriteLine("## 【public】");
        reflectionTest.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).ToList()
            .ForEach(method => Console.WriteLine($"{method.ToString()}"));
        Console.WriteLine("## 【non public】");
        reflectionTest.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .ToList()
            .ForEach(method => Console.WriteLine($"{method.ToString()}"));
    }

    [Test]
    public void GetMethod1Test()
    {
        var reflectionTest = typeof(ReflectionClass);
        Console.WriteLine("## 【default】");
        reflectionTest.GetMethods().ToList().ForEach(method => Console.WriteLine($"{method.ToString()}"));
        Console.WriteLine("## 【public】");
        reflectionTest.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).ToList()
            .ForEach(method => Console.WriteLine($"{method.ToString()}"));
        Console.WriteLine("## 【non public】");
        reflectionTest.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly).ToList()
            .ForEach(method => Console.WriteLine($"{method.ToString()}"));
    }

    [Test]
    public void GetMethod2Test()
    {
        var reflectionTest = typeof(ReflectionClass);
        Console.WriteLine("## 【public】");
        reflectionTest.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly).ToList()
            .ForEach(method => Console.WriteLine($"{method.ToString()}"));
        Console.WriteLine("## 【non public】");
        reflectionTest.GetMethods(BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.DeclaredOnly).ToList()
            .ForEach(method => Console.WriteLine($"{method.ToString()}"));
    }

    [Test]
    public void GetProperty1Test()
    {
        var reflectionTest = typeof(ReflectionClass);
        Console.WriteLine("## 【default】");
        reflectionTest.GetProperties().ToList().ForEach(method => Console.WriteLine($"{method.ToString()}"));
        Console.WriteLine("## 【public】");
        reflectionTest.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly).ToList()
            .ForEach(method => Console.WriteLine($"{method.ToString()}"));
        Console.WriteLine("## 【non public】");
        reflectionTest.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly)
            .ToList().ForEach(method => Console.WriteLine($"{method.ToString()}"));
    }

    [Test]
    public void GetFields1Test()
    {
        var reflectionTest = typeof(ReflectionClass);
        Console.WriteLine("## 【default】");
        foreach (var eventInfo in reflectionTest.GetFields()) Console.WriteLine($"{eventInfo.ToString()}");
        Console.WriteLine("## 【public】");
        foreach (var eventInfo in reflectionTest.GetFields(BindingFlags.Public | BindingFlags.Instance |
                                                           BindingFlags.DeclaredOnly))
            Console.WriteLine($"{eventInfo.ToString()}");
        Console.WriteLine("## 【non public】");
        foreach (var eventInfo in reflectionTest.GetFields(BindingFlags.NonPublic | BindingFlags.Instance |
                                                           BindingFlags.DeclaredOnly))
            Console.WriteLine($"{eventInfo.ToString()}");
    }

    [Test]
    public void GetMembers1Test()
    {
        var reflectionTest = typeof(ReflectionClass);
        Console.WriteLine("## 【default】");
        foreach (var memberInfo in reflectionTest.GetMembers()) Console.WriteLine($"{memberInfo.ToString()}");
        Console.WriteLine("## 【public】");
        foreach (var memberInfo in reflectionTest.GetMembers(BindingFlags.Public | BindingFlags.Instance |
                                                             BindingFlags.DeclaredOnly))
            Console.WriteLine($"{memberInfo.ToString()}");
        Console.WriteLine("## 【non public】");
        foreach (var memberInfo in reflectionTest.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance |
                                                             BindingFlags.DeclaredOnly))
            Console.WriteLine($"{memberInfo.ToString()}");
    }

    [Test]
    public void GetEnumeNames1Test()
    {
        var reflectionEnum = typeof(ReflectionEnum);
        reflectionEnum.GetEnumNames().ToList().ForEach(enumName => Console.WriteLine($"{enumName.ToString()}"));
    }

    [Test]
    public void GetEnumeValues1Test()
    {
        var reflectionEnum = typeof(ReflectionEnum);
        foreach (int enumValue in reflectionEnum.GetEnumValues()) Console.WriteLine($"{enumValue}");
    }

    [Test]
    public void GetEvents1Test()
    {
        var reflectionTest = typeof(ReflectionClass);
        Console.WriteLine("## 【default】");
        foreach (var eventInfo in reflectionTest.GetEvents()) Console.WriteLine($"{eventInfo.ToString()}");
        Console.WriteLine("## 【public】");
        foreach (var eventInfo in reflectionTest.GetEvents(BindingFlags.Public | BindingFlags.Instance |
                                                           BindingFlags.DeclaredOnly))
            Console.WriteLine($"{eventInfo.ToString()}");
        Console.WriteLine("## 【non public】");
        foreach (var eventInfo in reflectionTest.GetEvents(BindingFlags.NonPublic | BindingFlags.Instance |
                                                           BindingFlags.DeclaredOnly))
            Console.WriteLine($"{eventInfo.ToString()}");
    }

    [Test]
    public void GetInterfaces1Test()
    {
        var reflectionTest = typeof(ReflectionClass);
        Console.WriteLine("## 【default】");
        foreach (var interfaceInfo in reflectionTest.GetInterfaces()) Console.WriteLine($"{interfaceInfo.ToString()}");
    }

    private class ReflectionClass : ReflectionInterface
    {
        public delegate void TestEventHandler(object sender, EventArgs e);

        public event TestEventHandler TestEventPublic;
        protected event TestEventHandler TestEventProtected;
        private event TestEventHandler TestEventPrivate;

        public string strPublic = "strPublic";
        protected string strProtected = "strProtected";
        protected string strPrivate = "strPrivate";
        public int IdPublic { get; set; } = 0;

        protected int IdProtected { get; set; } = 1;

        private int IdPrivate { get; set; } = 2;

        public ReflectionClass()
        {
        }

        public ReflectionClass(int id)
        {
        }

        protected ReflectionClass(string str)
        {
        }

        private ReflectionClass(float value)
        {
        }

        public void ExecuteInstancePublic()
        {
        }

        protected void ExecuteInstanceProtected()
        {
        }

        private void ExecuteInstancePrivate()
        {
        }

        public static void ExecuteStaticPublic()
        {
        }

        protected static void ExecuteStaticProtected()
        {
        }

        private static void ExecuteStaticPrivate()
        {
        }
    }

    private enum ReflectionEnum : int
    {
        Red = 0,
        Green = 1,
        Blue = 2
    }

    private interface ReflectionInterface
    {
    }
}