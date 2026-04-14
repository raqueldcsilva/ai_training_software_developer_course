using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<WeatherData> GetWeatherAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("City name cannot be null or empty.", nameof(city));
            }

            var location = await GetLocationAsync(city.Trim());
            var weather = await GetCurrentWeatherAsync(location.Latitude, location.Longitude);

            return new WeatherData
            {
                City = location.Name,
                Temperature = weather.Temperature,
                WindSpeed = weather.WindSpeed,
                WeatherCode = weather.WeatherCode
            };
        }

        private async Task<GeoResult> GetLocationAsync(string city)
        {
            var geoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(city)}";
            using var response = await _httpClient.GetAsync(geoUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var geoData = JsonSerializer.Deserialize<GeoResponse>(content, JsonOptions);

            if (geoData?.Results == null || geoData.Results.Length == 0)
            {
                throw new InvalidOperationException($"City '{city}' not found.");
            }

            return geoData.Results[0];
        }

        private async Task<CurrentWeather> GetCurrentWeatherAsync(double latitude, double longitude)
        {
            var weatherUrl = $"https://api.open-meteo.com/v1/forecast?latitude={latitude}&longitude={longitude}&current_weather=true";
            using var response = await _httpClient.GetAsync(weatherUrl);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var weatherData = JsonSerializer.Deserialize<WeatherResponse>(content, JsonOptions);

            if (weatherData?.CurrentWeather == null)
            {
                throw new InvalidOperationException("Weather data not available for the specified location.");
            }

            return weatherData.CurrentWeather;
        }
    }
}