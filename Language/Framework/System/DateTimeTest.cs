using System.Globalization;

namespace Language;

public class DateTimeTest
{
    [Test]
    public void Now1Test()
    {
        Console.WriteLine($"Now:{DateTime.Now}");
    }

    [Test]
    public void Today1Test()
    {
        Console.WriteLine($"Today:{DateTime.Today}");
    }

    [Test]
    public void DateTime1Test()
    {
        Console.WriteLine($"DateTime:{new DateTime(2026, 1, 13, 13, 13, 13)}");
    }

    [Test]
    public void Parse1Test()
    {
        Console.WriteLine($"DateTime:{DateTime.Parse("2026/01/13 13:13:13")}");
    }

    [Test]
    public void Parse2Test()
    {
        Console.WriteLine($"DateTime:{DateTime.Parse("令和8年 1月13日13時13分13秒")}");
    }

    [Test]
    public void TryParse1Test()
    {
        DateTime.TryParse("2026/01/13 13:13:13", out var dateTime);
        Console.WriteLine($"DateTime:{dateTime}");
    }

    [Test]
    public void TryParseExtract1Test()
    {
        var dateTime = DateTime.ParseExact("20260113131313", "yyyyMMddHHmmss", new CultureInfo("ja-JP"));
        Console.WriteLine($"DateTime:{dateTime}");
    }

    [Test]
    public void Property1Test()
    {
        var dateTime = new DateTime(2026, 1, 13, 13, 13, 13);
        Console.WriteLine(
            $"DateTime:{dateTime.Year}, {dateTime.Month}, {dateTime.Day}, {dateTime.Hour}, {dateTime.Minute}, {dateTime.Second}, {dateTime.Millisecond}");
    }

    [Test]
    public void ToString1Test()
    {
        var dateTime = new DateTime(2026, 1, 13, 13, 13, 13);
        Console.WriteLine($"DateTime:{dateTime.ToString("yy/MM/dd (ddd) tt hh:mm:ss")}");
    }

    [Test]
    public void JapaneseCalendar1Test()
    {
        var dateTime = new DateTime(2026, 1, 13, 13, 13, 13);
        var calender = new CultureInfo("ja-JP");
        calender.DateTimeFormat.Calendar = new JapaneseCalendar();
        Console.WriteLine($"DateTime:{dateTime.ToString("ggyy年MM月dd日 (ddd) tt hh:mm:ss", calender)}");
    }

    [Test]
    public void AddYears1Test()
    {
        var dateTime = new DateTime(2026, 1, 13, 13, 13, 13);
        Console.WriteLine($"DateTime:{dateTime.AddYears(10).ToString("yy/MM/dd (ddd) tt hh:mm:ss")}");
    }

    [Test]
    public void AddMonth1Test()
    {
        var dateTime = new DateTime(2026, 1, 13, 13, 13, 13);
        Console.WriteLine($"DateTime:{dateTime.AddMonths(3).ToString("yy/MM/dd (ddd) tt hh:mm:ss")}");
    }

    [Test]
    public void AddDays1Test()
    {
        var dateTime = new DateTime(2026, 1, 13, 13, 13, 13);
        Console.WriteLine($"DateTime:{dateTime.AddDays(18).ToString("yy/MM/dd (ddd) tt hh:mm:ss")}");
    }

    [Test]
    public void AddHour1Test()
    {
        var dateTime = new DateTime(2026, 1, 13, 13, 13, 13);
        Console.WriteLine($"DateTime:{dateTime.AddHours(5).ToString("yy/MM/dd (ddd) tt hh:mm:ss")}");
    }

    [Test]
    public void AddMinutes1Test()
    {
        var dateTime = new DateTime(2026, 1, 13, 13, 13, 13);
        Console.WriteLine($"DateTime:{dateTime.AddMinutes(12).ToString("yy/MM/dd (ddd) tt hh:mm:ss")}");
    }

    [Test]
    public void AddSeconds1Test()
    {
        var dateTime = new DateTime(2026, 1, 13, 13, 13, 13);
        Console.WriteLine($"DateTime:{dateTime.AddSeconds(12).ToString("yy/MM/dd (ddd) tt hh:mm:ss")}");
    }

    [Test]
    public void Add1Test()
    {
        var dateTime = new DateTime(2026, 1, 13, 13, 13, 13);
        var timeSpan = new TimeSpan(1, 2, 3, 4);
        Console.WriteLine($"DateTime:{dateTime.Add(timeSpan).ToString("yy/MM/dd (ddd) tt hh:mm:ss")}");
    }

    [Test]
    public void Subtract1Test()
    {
        var dateTime = new DateTime(2026, 1, 13, 13, 13, 13);
        var timeSpan = new TimeSpan(1, 2, 3, 4);
        Console.WriteLine($"DateTime:{dateTime.Subtract(timeSpan).ToString("yy/MM/dd (ddd) tt hh:mm:ss")}");
    }

    [Test]
    public void Operator1Test()
    {
        var dateTime1 = new DateTime(2026, 1, 13, 13, 13, 13);
        var dateTime2 = new DateTime(2026, 1, 13, 13, 13, 13);
        Assert.That(dateTime1, Is.EqualTo(dateTime2));
    }

    [Test]
    public void Operator2Test()
    {
        var dateTime1 = new DateTime(2026, 1, 13, 13, 13, 13);
        var dateTime2 = new DateTime(2027, 1, 13, 13, 13, 13);
        Assert.That(dateTime1, Is.LessThan(dateTime2));
    }
}