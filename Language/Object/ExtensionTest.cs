using System.Text;

namespace Language;

public class ExtensionTest
{
    [Test]
    public void StringExtensionTest1()
    {
        Console.WriteLine($"{"Milestone achieved\n".Repeat(2)}");
    }
}

public static class StringExtension
{
    public static string Repeat(this string value, int count)
    {
        var builder = new StringBuilder();
        for (var i = 0; i < count; i++) builder.Append(value);
        return builder.ToString();
    }
}