using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Timezone : ControllerBase
    {
        static async Task Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:8000/");
                response.EnsureSuccessStatusCode(); // Throw an exception if the response is not successful

                var content = await response.Content.ReadAsStringAsync();

                var xmlDoc = XDocument.Parse(content);
                var utcOffset = xmlDoc.Descendants("tns:country_to_timezoneResult").FirstOrDefault()?.Value;

                Console.WriteLine(utcOffset);
            }
        }
    }
}
