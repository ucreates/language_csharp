namespace Language;

public class IndexerTest
{
    [Test]
    public void PublicIndexerIntObjectTest1()
    {
        var indexer = new PublicIndexerIntObject(100);
        for (var i = 0; i < 100; i++) indexer[i] = i * 100;
        for (var i = 0; i < 100; i++) Console.WriteLine($@"indexer{i}::{indexer[i]}");
    }

    [Test]
    public void PublicIndexerStringObjectTest1()
    {
        var stringArray = new string[5] { "A", "B", "C", "D", "E" };
        var indexer = new PublicIndexerStringObject();
        for (var i = 0; i < stringArray.Length; i++) Console.WriteLine($@"indexer{i}::{indexer[stringArray[i]]}");
    }

    [Test]
    public void PublicIndexerOverloadObjectTest1()
    {
        var stringArray = new string[5] { "A", "B", "C", "D", "E" };
        var indexer = new PublicIndexerOverloadObject(100);
        for (var i = 0; i < 100; i++) Console.WriteLine($@"indexer{i}::{indexer[i]}");
        for (var i = 0; i < stringArray.Length; i++) Console.WriteLine($@"indexer{i}::{indexer[stringArray[i]]}");
    }

    public class PublicIndexerIntObject
    {
        private readonly int[]? _intArray;

        public PublicIndexerIntObject()
        {
            _intArray = null;
        }

        public PublicIndexerIntObject(int size)
        {
            _intArray = new int[size];
        }

        public int this[int index]
        {
            set
            {
                var intArray = _intArray;
                if (intArray != null) intArray[index] = value;
            }
            get
            {
                var intArray = _intArray;
                var result = 0;
                if (intArray != null) result = intArray[index];
                return result;
            }
        }
    }

    public class PublicIndexerStringObject
    {
        private readonly string[]? _stringArray;

        public PublicIndexerStringObject()
        {
            _stringArray = new string[5] { "A", "B", "C", "D", "E" };
        }

        public int this[string key]
        {
            get
            {
                var stringArray = _stringArray;
                var result = 0;
                if (stringArray != null) result = Array.IndexOf(stringArray, key);
                return result;
            }
        }
    }

    public class PublicIndexerOverloadObject
    {
        private readonly int[]? _intArray;
        private readonly string[]? _stringArray;

        public PublicIndexerOverloadObject()
        {
            _intArray = null;
            _stringArray = new string[5] { "A", "B", "C", "D", "E" };
        }

        public PublicIndexerOverloadObject(int size)
        {
            _intArray = new int[size];
            _stringArray = new string[5] { "A", "B", "C", "D", "E" };
        }

        public int this[int index]
        {
            set
            {
                var intArray = _intArray;
                if (intArray != null) intArray[index] = value;
            }
            get
            {
                var intArray = _intArray;
                var result = 0;
                if (intArray != null) result = intArray[index];
                return result;
            }
        }

        public int this[string key]
        {
            get
            {
                var stringArray = _stringArray;
                var result = 0;
                if (stringArray != null) result = Array.IndexOf(stringArray, key);
                return result;
            }
        }
    }
}