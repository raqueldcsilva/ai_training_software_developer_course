namespace WeatherApp
{
    public class GeoResponse
    {
        public GeoResult[] Results { get; init; } = Array.Empty<GeoResult>();
    }

    public class GeoResult
    {
        public string Name { get; init; } = string.Empty;
        public double Latitude { get; init; }
        public double Longitude { get; init; }
    }
}