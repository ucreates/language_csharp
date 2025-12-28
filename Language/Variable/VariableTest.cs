namespace Language;

public class VariableTest
{
    [Test]
    public void DeclarationTest()
    {
        int n;
        nint ni;
        uint ui;
        nuint nui;
        long l;
        ulong ul;
        short s;
        ushort uss;
        float f;
        double d;
        decimal dc;
        byte bByte;
        sbyte sb;
        char c;
        string str;
        bool b;
        object o;
    }

    [Test]
    public void LiteralTest()
    {
        var n = 0;
        nint ni = 1;
        var ui = 2u;
        nuint nui = 3u;
        var l = 0l;
        var ul = 0ul;
        short s = 0;
        ushort uss = 0;
        var f = 0f;
        var d = 0d;
        decimal dc = 0;
        byte bByte = 0;
        sbyte sb = 0;
        var c = 'A';
        var str = "ABC";
        var b = true;
        var o = new object();
        Console.WriteLine($"int {n}");
        Console.WriteLine($"nint {ni}");
        Console.WriteLine($"uint {ui}");
        Console.WriteLine($"nuint {nui}");
        Console.WriteLine($"long {l}");
        Console.WriteLine($"ulong {ul}");
        Console.WriteLine($"short {s}");
        Console.WriteLine($"ushort {uss}");
        Console.WriteLine($"float {f}");
        Console.WriteLine($"double {d}");
        Console.WriteLine($"decimal {dc}");
        Console.WriteLine($"byte {bByte}");
        Console.WriteLine($"sbyte {sb}");
        Console.WriteLine($"char {c}");
        Console.WriteLine($"string {str}");
        Console.WriteLine($"bool {b}");
        Console.WriteLine($"object {o}");
    }

    [Test]
    public void TypeInferenceTest()
    {
        var n = 0;
        var ni = 1;
        var ui = 2u;
        var nui = 3u;
        var l = 0l;
        var ul = 0ul;
        var s = 0;
        var uss = 0;
        var f = 0f;
        var d = 0d;
        var dc = 0;
        var bByte = 0;
        var sb = 0;
        var c = 'A';
        var str = "ABC";
        var b = true;
        var o = new object();
        Console.WriteLine($"int {n}");
        Console.WriteLine($"nint {ni}");
        Console.WriteLine($"uint {ui}");
        Console.WriteLine($"nuint {nui}");
        Console.WriteLine($"long {l}");
        Console.WriteLine($"ulong {ul}");
        Console.WriteLine($"short {s}");
        Console.WriteLine($"ushort {uss}");
        Console.WriteLine($"float {f}");
        Console.WriteLine($"double {d}");
        Console.WriteLine($"decimal {dc}");
        Console.WriteLine($"byte {bByte}");
        Console.WriteLine($"sbyte {sb}");
        Console.WriteLine($"char {c}");
        Console.WriteLine($"string {str}");
        Console.WriteLine($"bool {b}");
        Console.WriteLine($"object {o}");
    }
}

public class Variable
{
    public struct TestVariableStruct
    {
        public string Name { get; set; }
    }

    public class TestVariableObject
    {
        public string Name { get; set; } = string.Empty;

        public int Method()
        {
            Console.WriteLine($"Execute Method");
            return 0;
        }
    }
}