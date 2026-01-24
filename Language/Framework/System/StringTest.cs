namespace Language;

public class StringTest
{
    [Test]
    public void Length1Test()
    {
        var str = "string";
        Assert.That(str.Length, Is.EqualTo(6));
    }

    [Test]
    public void Length2Test()
    {
        var str = "激しい";
        Assert.That(str.Length, Is.EqualTo(3));
    }

    [Test]
    public void Equals1Test()
    {
        var str1 = "wings";
        var str2 = "WINGS";
        Assert.That(str1.Equals(str2), Is.False);
        Assert.That(str1.Equals(str2, StringComparison.OrdinalIgnoreCase), Is.True);
    }

    [Test]
    public void Compare1Test()
    {
        var str1 = "wings";
        var str2 = "WINGS";
        Assert.That(string.Compare(str1, str2), !Is.EqualTo(0));
        Assert.That(string.Compare(str1, str2, StringComparison.OrdinalIgnoreCase), Is.EqualTo(0));
    }

    [Test]
    public void IsNullOrEmpty1Test()
    {
        var str1 = "";
        Assert.That(string.IsNullOrEmpty(str1), Is.True);
    }

    [Test]
    public void IsNullOrEmpty2Test()
    {
        string? str1 = null;
        Assert.That(string.IsNullOrEmpty(str1), Is.True);
    }

    [Test]
    public void IsNullOrWhiteSpace1Test()
    {
        var str1 = " ";
        Assert.That(string.IsNullOrWhiteSpace(str1), Is.True);
        var str2 = "　";
        Assert.That(string.IsNullOrWhiteSpace(str2), Is.True);
    }

    [Test]
    public void IndexOf1Test()
    {
        var str1 = "abcdefgabcdefgabcdefg";
        //1番最初から前方検索
        Assert.That(str1.IndexOf("a"), Is.EqualTo(0));
    }

    [Test]
    public void IndexOf2Test()
    {
        var str1 = "abcdefgabcdefgabcdefg";
        //指定した位置から前方検索
        Assert.That(str1.IndexOf("a", 13), Is.EqualTo(14));
    }

    [Test]
    public void IndexOf3Test()
    {
        var str1 = "abcdefgabcdefgabcdefg";
        //指定した位置から指定したカウント分だけ前方検索
        Assert.That(str1.IndexOf("a", 13, 8), Is.EqualTo(14));
    }

    [Test]
    public void IndexOf4Test()
    {
        var str1 = "abcdefgabcdefgabcdefg";
        //1番最初から前方検索し、最初の文字のインデックスを返す
        Assert.That(str1.IndexOf("ab"), Is.EqualTo(0));
    }

    [Test]
    public void LastIndexOf1Test()
    {
        var str1 = "abcdefgabcdefgabcdefg";
        //1番最後から後方検索
        Assert.That(str1.LastIndexOf("a"), Is.EqualTo(14));
    }

    [Test]
    public void LastIndexOf2Test()
    {
        var str1 = "abcdefgabcdefgabcdefg";
        // 指定した位置から後方検索
        Assert.That(str1.LastIndexOf("a", 13), Is.EqualTo(7));
    }

    [Test]
    public void LastIndexOf3Test()
    {
        var str1 = "abcdefgabcdefgabcdefg";
        // 指定した位置から指定したカウント分だけ後方検索
        Assert.That(str1.LastIndexOf("a", 13, 8), Is.EqualTo(7));
    }

    [Test]
    public void LastIndexOf4Test()
    {
        var str1 = "abcdefgabcdefgabcdefg";
        //1番最後から後方検索し、最初の文字のインデックスを返す
        Assert.That(str1.LastIndexOf("ab"), Is.EqualTo(14));
    }
}