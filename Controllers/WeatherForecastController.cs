using Microsoft.AspNetCore.Mvc;

namespace APInet.Controllers;

[ApiController]
[Route("api/[controller]")]     //http://localhost:5202/api/weatherforecast
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if (ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }
    }

    //metodo get
    [HttpGet(Name = "GetWeatherForecast")]
    [Route("Get/weatherforecast")]      //http://localhost:5202/api/weatherforecast/get/weatherforecast
    [Route("Get/weatherforecast2")]     //http://localhost:5202/api/weatherforecast/get/weatherforecast2
    [Route("[action]")]                 //http://localhost:5202/api/weatherforecast/get
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogDebug("Retornando la lista de weatherforecast");
        return ListWeatherForecast;
    }

    //metodo post
    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);

        return Ok();
    }

    //metodo delete
    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        ListWeatherForecast.RemoveAt(index);

        return Ok();
    }

    //metodo put    
    // [HttpPut]

    //metodo patch
    // [HttpPatch]
}
