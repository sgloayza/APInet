using Microsoft.AspNetCore.Mvc;

namespace APInet.Controllers;

[ApiController]
[Route("api/[controller]")]     //http://localhost:5202/api/helloworld
public class HelloWorldController : ControllerBase
{
    IHelloWorldService helloWorldService;

    public HelloWorldController(IHelloWorldService helloWorld)
    {
        helloWorldService = helloWorld;
    }

    public IActionResult Get()
    {
        return Ok(helloWorldService.GetHelloWorld());
    }
}