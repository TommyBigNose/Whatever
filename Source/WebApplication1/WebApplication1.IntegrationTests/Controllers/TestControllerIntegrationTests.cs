using WebApplication1.Providers;

namespace WebApplication1.IntegrationTests.Controllers;

public class TestControllerIntegrationTests
{
    private HttpClient _httpClient;
    
    [OneTimeSetUp]
    public void SetUp()
    {
        _httpClient = WebHelper.GetHttpClient();
    }
    
    [OneTimeTearDown]
    public void TearDown()
    {
        _httpClient.Dispose();
    }

    [Test]
    public async Task Should_ReturnSomeNumberString_When_HittingIndex()
    {
        // Arrange
        // Act
        var result = await _httpClient.GetAsync("/Test").Result.Content.ReadAsStringAsync();
        Console.WriteLine(result);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(_httpClient, Is.Not.Null, "HttpClient failed to initialize");
            Assert.That(result, Contains.Substring("Test: "));
        });
    }
}