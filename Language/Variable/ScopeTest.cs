namespace Language;

public class ScopeTest
{
    /// <summary>
    /// 基本
    /// </summary>
    [Test]
    public void Scope1Test()
    {
        var a = 1;
        {
            var b = 1;
            Console.WriteLine(b);
        }
        Console.WriteLine(a);
    }

    /// <summary>
    /// フィールドとローカル変数1
    /// </summary>
    [Test]
    public void Scope2Test()
    {
        var obj = new ScopeTestObject1();
        // フィールドとローカル変数は被らない
        Console.WriteLine(obj.GetLocalData());
        Console.WriteLine(obj.data);
    }

    /// <summary>
    /// フィールドとローカル変数2
    /// </summary>
    [Test]
    public void Scope3Test()
    {
        var obj = new ScopeTestObject2();
        // フィールドとローカル変数は被らない
        Console.WriteLine(obj.GetLocalData());
        Console.WriteLine(obj.data);
    }

    private class ScopeTestObject1
    {
        public string data = "field";

        public string GetLocalData()
        {
            var data = "local";
            return data;
        }
    }

    private class ScopeTestObject2
    {
        public string data = "field";

        public string GetLocalData()
        {
            var data = "local";
            return this.data;
        }
    }
}