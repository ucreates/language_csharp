namespace Language;

public class GoToTest
{
    [Test]
    public void Goto1Test()
    {
        goto END;
        Console.WriteLine("repayment");
        END:
        Console.WriteLine("default");
    }

    [Test]
    public void Goto2Test()
    {
        for (var i = 0; i < 10; i++)
        for (var j = 0; j < 10; j++)
        {
            var result = i * j;
            if (result > 40)
                goto END;
            else
                Console.WriteLine($"repayment::{result}");
        }

        END:
        Console.WriteLine("default");
    }

    [Test]
    public void Goto3Test()
    {
        var financialSoundness = "good";
        switch (financialSoundness)
        {
            case "good":
                Console.Write("good");
                goto case "normal";
            case "normal":
                Console.Write("->normal");
                goto case "bad";
            case "bad":
                Console.Write("->bad");
                goto case "end";
            case "end":
                Console.Write("->end");
                break;
        }
    }
}