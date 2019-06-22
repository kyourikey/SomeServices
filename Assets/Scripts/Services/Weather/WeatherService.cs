using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class WeatherService
{
    public async Task<WeatherResponse> GetWeather(string cityName)
    {
        var result = await GetWeatherData(cityName);
        return result;
    }

    private Task<WeatherResponse> GetWeatherData(string cityName)
    {
        var tcs = new TaskCompletionSource<WeatherResponse>();

        var url = WeatherURLs.REQUEST_URL + "&q=" + cityName;
        var request = new UnityWebRequest(url, "GET");
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        var asyncReq = request.SendWebRequest();

        asyncReq.completed += (e) =>
        {
            if (string.IsNullOrEmpty(request.error))
            {
                tcs.SetResult(JsonUtility.FromJson<WeatherResponse>(request.downloadHandler.text));
            }
            else
            {
                tcs.SetException(new Exception(request.error));
            }
        };

        return tcs.Task;
    }
}
