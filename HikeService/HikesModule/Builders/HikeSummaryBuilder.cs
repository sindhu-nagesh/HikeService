using HikeService.HikesModule.Models;
using HikeService.HikesModule.Services;
using HikeService.WeatherModule;

namespace HikeService.HikesModule.Builders
{
	public class HikeSummaryBuilder
	{
		public HikeDetailsService HikeDetailsService { get; set; }
		public IWeatherDetailsService WeatherDetailsService { get; set; }

		public HikeSummary Build(string url)
		{
			HikeSummary hikeSummary = new HikeSummary();
			hikeSummary.HikeDetails = this.HikeDetailsService.GetInformation(url);
		    hikeSummary.WeatherDetails = this.WeatherDetailsService.GetWeatherForecastDetails(hikeSummary.HikeDetails.Location);
			return hikeSummary;
		}
	}
}