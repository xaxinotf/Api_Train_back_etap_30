using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Api_Train.Helpers;

public class WeatherService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public WeatherService(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
    }

    public async Task<string> GetContentAsync(string name)
    {
        var apiKey = _configuration["ApiKey"];

        var url = $"https://api.openweathermap.org/data/2.5/weather?q={name}&APPID={apiKey}";

        var response = await _httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return content;
        }

        return null;
    }
}
