using System.Text.Json.Serialization;

namespace WeatherApp
{
    public class WeatherData
    {
        public string City { get; init; } = string.Empty;
        public double Temperature { get; init; }
        public double WindSpeed { get; init; }
        public int WeatherCode { get; init; }
    }
}