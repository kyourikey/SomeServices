public class Services
{
    private static WeatherService _weatherService;
    public static WeatherService WeatherService
    {
        get { return _weatherService ?? (_weatherService = new WeatherService()); }
        set { _weatherService = value; }
    }
}
