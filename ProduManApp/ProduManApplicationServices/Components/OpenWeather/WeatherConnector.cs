using Newtonsoft.Json;
using RestSharp;

namespace ProduManApplicationServices.Components.OpenWeather;

public class WeatherConnector : IWeatherConnector
{
    private readonly RestClient _restClient;
    private readonly string baseUrl = "https://api.openweathermap.org/";
    private readonly string apiKey = "<KEY>";  // do uzupełnienia z pliku settings
    
    public WeatherConnector()
    {
        _restClient = new RestClient(baseUrl);
    }
    
    public async Task<Weather> Fetch(string city)
    {
        var request = new RestRequest($"/data/2.5/weather?", Method.Get);
        request.AddParameter("appid", apiKey);
        request.AddParameter("q", city);
        var queryResult = await _restClient.ExecuteAsync(request);
        var weather = JsonConvert.DeserializeObject<Weather>(queryResult.Content);
        return weather;
        //Teraz można zrobić hendlera do pobrania danych z serwera
    }
}