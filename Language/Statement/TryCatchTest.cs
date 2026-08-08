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
}