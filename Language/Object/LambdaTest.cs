namespace Language;

public class LambdaTest
{
    [Test]
    public void LambdaTest1()
    {
        var sample = new[] { "a", "b", "c" };
        var instance = new Lambda();
        instance.Execute(sample, delegate(string s) { return $"[{s}]"; });
    }

    public class Lambda
    {
        public void Execute(string[] data, Func<string, string> output)
        {
            foreach (var value in data) Console.WriteLine(output(value));
        }
    }
}