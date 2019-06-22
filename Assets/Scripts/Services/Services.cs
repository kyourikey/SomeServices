public class Services
{
    private static WeatherService _weatherService;
    public static WeatherService WeatherService
    {
        get { return _weatherService ?? (_weatherService = new WeatherService()); }
        set { _weatherService = value; }
    }

    private static MTGService _mtgService;
    public static MTGService MTGService
    {
        get { return _mtgService ?? (_mtgService = new MTGService()); }
        set { _mtgService = value; }
    }
}
