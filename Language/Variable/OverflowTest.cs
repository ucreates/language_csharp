namespace Language;

public class OverflowTest
{
    [Test]
    public void OverflowTest1()
    {
        try
        {
            checked
            {
                var i = int.MaxValue;
                Console.WriteLine(++i);
            }
        }
        catch (OverflowException oe)
        {
            Console.WriteLine(oe.Message);
        }
    }

    [Test]
    public void OverflowTest2()
    {
        try
        {
            var i = int.MaxValue;
            Console.WriteLine(checked(++i));
        }
        catch (OverflowException oe)
        {
            Console.WriteLine(oe.Message);
        }
    }

    [Test]
    public void OverflowTest3()
    {
        try
        {
            var i = int.MaxValue;
            Console.WriteLine(unchecked(++i));
        }
        catch (OverflowException oe)
        {
            Console.WriteLine(oe.Message);
        }
    }

    [Test]
    public void OverflowTest4()
    {
        try
        {
            var a = double.MaxValue;
            var b = double.Epsilon;
            Console.WriteLine(a * a);
            Console.WriteLine(b * b);
        }
        catch (OverflowException oe)
        {
            Console.WriteLine(oe.Message);
        }
    }
}