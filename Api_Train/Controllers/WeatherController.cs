using Api_Train.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Train.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WeatherController : ControllerBase
{
    private readonly WeatherService _service;

    public WeatherController(WeatherService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetWeather(string name)
    {
        var response = await _service.GetContentAsync(name);
        return Ok(response);
    }
}
