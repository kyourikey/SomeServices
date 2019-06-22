using UnityEngine;
using UnityEngine.UI;

public class WeatherServiceDemoMain : MonoBehaviour
{
    [SerializeField] private Text _text;
    void Start()
    {
        GetWeather("Tokyo,jp");
    }

    private async void GetWeather(string cityName)
    {
        var result = await Services.WeatherService.GetWeather(cityName);

        _text.text = result.weather[0].main;
    }
}
