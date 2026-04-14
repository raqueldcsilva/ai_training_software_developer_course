using System.Text.Json.Serialization;

namespace WeatherApp
{
    public class WeatherResponse
    {
        [JsonPropertyName("current_weather")]
        public CurrentWeather CurrentWeather { get; init; } = null!;
    }

    public class CurrentWeather
    {
        public double Temperature { get; init; }

        [JsonPropertyName("windspeed")]
        public double WindSpeed { get; init; }

        [JsonPropertyName("weathercode")]
        public int WeatherCode { get; init; }
    }
}