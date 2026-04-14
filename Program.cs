// See https://aka.ms/new-console-template for more information

using System;
using System.Net.Http;
using WeatherApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        Console.Write("Enter city name: ");
        var city = Console.ReadLine();

        try
        {
            using var client = new HttpClient();
            var weatherService = new WeatherService(client);
            var weather = await weatherService.GetWeatherAsync(city ?? string.Empty);

            Console.WriteLine($"Weather in {weather.City}:");
            Console.WriteLine($"Temperature: {weather.Temperature}°C");
            Console.WriteLine($"Wind Speed: {weather.WindSpeed} km/h");
            Console.WriteLine($"Weather Code: {weather.WeatherCode}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
