using System.Reflection;
using NST = NameSpaceTest1;
using static System.Math;

namespace Language
{
    public class NameSpaceTest
    {
        [Test]
        public void NameSpaceTest1()
        {
            var instance1 = new NST.NameSpaceTest();
            instance1.Execute();
            var instance2 = new NameSpaceTest2.NameSpaceTest();
            instance2.Execute();
        }

        [Test]
        public void NameSpaceTest2()
        {
            var instance1 = new NST.NameSpaceTest();
            instance1.Execute();
        }

        [Test]
        public void NameSpaceAliasTest1()
        {
            var instance1 = new NST.NameSpaceTest();
            instance1.Execute();
        }

        [Test]
        public void NameSpaceAliasTest2()
        {
            var instance1 = new NameSpaceTest2.Alias2.NameSpaceTest();
            instance1.Execute();
        }

        [Test]
        public void NameSpaceStaticTest1()
        {
            Console.WriteLine(Round(1.6));
        }
    }
}

namespace NameSpaceTest1
{
    public class NameSpaceTest
    {
        public void Execute()
        {
            Console.WriteLine($"{GetType().FullName}.{MethodBase.GetCurrentMethod()?.Name}");
        }
    }
}

namespace NameSpaceTest2
{
    public class NameSpaceTest
    {
        public void Execute()
        {
            Console.WriteLine($"{GetType().FullName}.{MethodBase.GetCurrentMethod()?.Name}");
        }
    }

    namespace Alias2
    {
        public class NameSpaceTest
        {
            public void Execute()
            {
                var instance1 = new global::Alias2();
                instance1.Execute();
            }
        }
    }
}

public class Alias1
{
    public void Execute()
    {
        Console.WriteLine($"{GetType().FullName}.{MethodBase.GetCurrentMethod()?.Name}");
    }
}

public class Alias2
{
    public void Execute()
    {
        Console.WriteLine($"{GetType().FullName}.{MethodBase.GetCurrentMethod()?.Name}");
    }
}