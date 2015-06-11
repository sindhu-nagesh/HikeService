using HikeService.HikesModule.Models;
using HikeService.Utilities;
using HikeService.WeatherModule.Models;
using Newtonsoft.Json;

namespace HikeService.WeatherModule.impl
{
    public class WeatherUndergroundService: IWeatherDetailsService
    {
        private const string MyKey = "e4938cdd8fd24af0";
        public WeatherDetails[] GetWeatherForecastDetails(LocationDetails locationDetails)
        {
            var url = GetUrl(locationDetails);
            //scrape data from WeatherData Underground Service
            string json = WebClientUtility.GetJsonString(url);
            return Get4DaysForecast(json);
        }

        private WeatherDetails[] Get4DaysForecast(string json)
        {
            WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(json);
            return weatherData.Forecast.Simpleforecast.Forecastday;
        }

        private string GetUrl(LocationDetails locationDetails)
        {
            return "http://api.wunderground.com/api/"+MyKey+"/forecast/q/" + locationDetails.Latitude + "," +
                   locationDetails.Longitude+",json";
        }
    }
}