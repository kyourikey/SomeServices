using System;

[Serializable]
public class WeatherResponse
{
    public Coord coord;
    public Weather[] weather;
    public Main main;
    public int visibility;
    public Wind wind;
    public Clouds clouds;
    public int dt;
    public Sys sys;
    public int timezone;
    public int id;
    public string name;
    public int cod;
}

[Serializable]
public class Coord
{
    public float lon;
    public float lat;
}

[Serializable]
public class Main
{
    public float temp;
    public int pressure;
    public int humidity;
    public float temp_min;
    public float temp_max;
}

[Serializable]
public class Wind
{
    public float speed;
    public int deg;
}

[Serializable]
public class Clouds
{
    public int all;
}

[Serializable]
public class Sys
{
    public int type;
    public int id;
    public float message;
    public string country;
    public int sunrise;
    public int sunset;
}

[Serializable]
public class Weather
{
    public int id;
    public string main;
    public string description;
    public string icon;
}