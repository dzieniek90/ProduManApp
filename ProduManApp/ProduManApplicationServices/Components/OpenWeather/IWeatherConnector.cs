namespace ProduManApplicationServices.Components.OpenWeather;

public interface IWeatherConnector
{
    Task<Weather> Fetch(string city);
}