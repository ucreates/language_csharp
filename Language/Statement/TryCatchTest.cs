namespace Language;

public class TryCatchTest
{
    [Test]
    public void TryCatchTest1()
    {
        try
        {
            using (var sr = new StreamReader("TryCatchTest1.txt"))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [Test]
    public void TryCatchTest2()
    {
        StreamReader sr = null;
        try
        {
            sr = new StreamReader("TryCatchTest2.txt");
            Console.WriteLine(sr.ReadToEnd());
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            sr?.Close();
        }
    }

    [Test]
    public void TryCatchTest3()
    {
        try
        {
            using (var sr = new StreamReader("TryCatchTest3.txt"))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        catch (ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [Test]
    public void TryCatchTest4()
    {
        try
        {
            using (var sr = new StreamReader("TryCatchTest4.txt"))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        catch (FileNotFoundException ex) when (ex.Message.Contains("txt"))
        {
            Console.WriteLine(ex.Message);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [Test]
    public void TryCatchTest5()
    {
        try
        {
            using (var sr = new StreamReader("TryCatchTest5.txt"))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        catch (FileNotFoundException ex) when (ex is FileNotFoundException || ex is ArgumentException)
        {
            Console.WriteLine(ex.Message);
        }
    }
}