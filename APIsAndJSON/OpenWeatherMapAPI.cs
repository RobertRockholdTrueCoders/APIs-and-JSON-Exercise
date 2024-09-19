using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public static class OpenWeatherMapAPI
    {
        public static void GetWeatherData()
        {
        var jsonText = File.ReadAllText("appsettings.json");
        var apiKey = JObject.Parse(jsonText).GetValue("key").ToString();
        Console.WriteLine("Enter ZIP: ");

        var zip = Console.ReadLine();
        var url = $"https://api.openweathermap.org/data/2.5/weather?zip={zip},us&appid={apiKey}&units=imperial";

        var client = new HttpClient();
        var jsonResponse = client.GetStringAsync(url).Result;
        var weatherObj = JObject.Parse(jsonResponse);
        Console.WriteLine($"Temp: {weatherObj["main"]["temp"]}\nFeels like: {weatherObj["main"]["feels_like"]}");
        }
    }
}