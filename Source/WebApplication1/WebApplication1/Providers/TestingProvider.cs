namespace WebApplication1.Providers;

public interface ITestingProvider
{
    string GetSomeRandomString();
}

public class TestingProvider : ITestingProvider
{
    private Random _random;
    private List<string> VariousStrings => ["one", "two", "three"];

    public TestingProvider()
    {
        _random = new Random();
    }
    
    public string GetSomeRandomString()
    {
        string result = VariousStrings[_random.Next(VariousStrings.Count)];
        return result;
    }
}