using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace APInet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    ITareaService tareaService;

    private readonly ILogger<TareaController> _logger;

    public TareaController(ITareaService service, ILogger<TareaController> logger)
    {
        _logger = logger;

        tareaService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Ejecutando el get de tarea");

        return Ok(tareaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Tarea tarea)
    {
        _logger.LogInformation("Ejecutando el post de tarea");

        tareaService.SaveAsync(tarea);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Tarea tarea)
    {
        _logger.LogInformation("Ejecutando el put de tarea");

        tareaService.Update(id,tarea);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _logger.LogInformation("Ejecutando el delete de tarea");

        tareaService.Delete(id);
        return Ok();
    }
}