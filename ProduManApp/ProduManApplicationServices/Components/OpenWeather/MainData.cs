using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace ProduManApplicationServices.Components.OpenWeather;

public class MainData
{
    [JsonProperty("temp")]
    public double Temperature { get; set; }
    
    [JsonProperty("humidity")]
    public float Humidity { get; set; }
}