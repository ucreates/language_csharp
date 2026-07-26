using System.Reflection;

namespace Language
{
    public class NameSpaceTest
    {
        [Test]
        public void InheritClassObject1Test4()
        {
            var instance1 = new NameSpaceTest1.NameSpaceTest();
            instance1.Execute();
            var instance2 = new NameSpaceTest2.NameSpaceTest();
            instance2.Execute();
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
}