namespace WeatherApi.Models
{
    public class Weather
    {
        public string date { get; set; }
        public double daily { get; set; }

        public double nightly { get; set; }
        public double pressure { get; set; }
    }
}
