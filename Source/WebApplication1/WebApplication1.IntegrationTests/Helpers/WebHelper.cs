namespace WebApplication1.IntegrationTests.Helpers;

public static class WebHelper
{
    public static HttpClient GetHttpClient()
    {
        WebApplicationFactory<Program> webApplicationFactory = new WebApplicationFactory<Program>();
        HttpClient client = webApplicationFactory.CreateClient();
        return client;
    }
}