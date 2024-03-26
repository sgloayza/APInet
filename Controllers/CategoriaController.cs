using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace APInet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController : ControllerBase
{
    ICategoriaService categoriaService;

    private readonly ILogger<CategoriaController> _logger;

    public CategoriaController(ICategoriaService service, ILogger<CategoriaController> logger)
    {
        _logger = logger;

        categoriaService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Ejecutando el get de categoria");

        return Ok(categoriaService.Get());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Categoria categoria)
    {
        _logger.LogInformation("Ejecutando el post de categoria");

        categoriaService.SaveAsync(categoria);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Categoria categoria)
    {
        _logger.LogInformation("Ejecutando el put de categoria");

        categoriaService.Update(id,categoria);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _logger.LogInformation("Ejecutando el delete de categoria");

        categoriaService.Delete(id);
        return Ok();
    }
}