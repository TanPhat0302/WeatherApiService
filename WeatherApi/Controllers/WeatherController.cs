using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApi.Models;

namespace WeatherApi.Controllers
{
    [Route("")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpGet("/weather/nightly/today/{city}")]
        public async Task<double> GetWeatherAsync(string city)
        {
            var client = new HttpClient();
            var url = $"http://localhost:8080/weather/forecast?city={city}";
            List<Weather> data = await client.GetFromJsonAsync<List<Weather>>(url);
            double nightTempToday = data[0].nightly;
            return nightTempToday;
        }

    }
}
