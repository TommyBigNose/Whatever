namespace WebApplication1.Controllers;

public class TestController : Controller
{
    private readonly ILogger<TestController> _logger;
    private readonly ITestingProvider  _provider;

    public TestController(ILogger<TestController> logger, ITestingProvider provider)
    {
        _logger = logger;
        _provider = provider;
    }

    public IActionResult Index()
    {
        RandomStringModel result = new RandomStringModel()
        {
            RandomString = _provider.GetSomeRandomString()
        };
        return View(result);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}