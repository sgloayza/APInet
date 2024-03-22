using Microsoft.AspNetCore.Mvc;

namespace APInet.Controllers;

[ApiController]
[Route("api/[controller]")]     //http://localhost:5202/api/helloworld
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;

    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger)
    {
        _logger = logger;

        helloWorldService = helloWorld;
    }

    public IActionResult Get()
    {
        _logger.LogInformation("Ejecutando el get de helloworld");

        return Ok(helloWorldService.GetHelloWorld());
    }
}