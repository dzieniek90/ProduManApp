using System.Text.Json.Serialization;

namespace ProduManApplicationServices.Components.OpenWeather;

public class Weather
{
    public string Name { get; set; }
    
    [JsonPropertyName("main")]
    public MainData Main { get; set; }
}