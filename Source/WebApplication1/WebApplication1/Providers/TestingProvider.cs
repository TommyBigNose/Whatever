namespace WebApplication1.Providers;

public interface ITestingProvider
{
    string GetSomeRandomString();
}

public class TestingProvider : ITestingProvider
{
    private Random _random;
    private List<string> _variousStrings;

    public TestingProvider()
    {
        _random = new Random();
        _variousStrings = ["one", "two", "three"];
    }
    
    public string GetSomeRandomString()
    {
        string result = _variousStrings[_random.Next(_variousStrings.Count)];
        return result;
    }
}