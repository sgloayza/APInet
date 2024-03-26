using Microsoft.AspNetCore.Mvc;
using webapi;

namespace APInet.Controllers;

[ApiController]
[Route("api/[controller]")]     //http://localhost:5202/api/helloworld
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;

    TareasContext dbcontext;

    private readonly ILogger<HelloWorldController> _logger;

    public HelloWorldController(IHelloWorldService helloWorld, ILogger<HelloWorldController> logger,TareasContext db)
    {
        _logger = logger;

        helloWorldService = helloWorld;
        dbcontext = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Ejecutando el get de helloworld");

        return Ok(helloWorldService.GetHelloWorld());
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDataBase()
    {
        dbcontext.Database.EnsureCreated();

        return Ok(helloWorldService.GetHelloWorld());
    }
}