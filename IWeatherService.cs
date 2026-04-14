using System.Threading.Tasks;

namespace WeatherApp
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeatherAsync(string city);
    }
}