using HikeService.HikesModule.Models;
using HikeService.WeatherModule.Models;

namespace HikeService.WeatherModule
{
    public interface IWeatherDetailsService
    {
        WeatherDetails[] GetWeatherForecastDetails(LocationDetails locationDetails);
    }
}