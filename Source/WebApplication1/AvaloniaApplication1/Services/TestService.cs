using System;

namespace AvaloniaApplication1.Services;

public interface ITestService
{
    void Test();
}

public class TestService : ITestService
{
    public void Test()
    {
        Console.WriteLine("Test");
    }
}