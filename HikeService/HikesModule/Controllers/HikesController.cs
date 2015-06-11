using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HikeService.Factories;
using HikeService.HikesModule.Builders;
using HikeService.HikesModule.Models;
using HikeService.StorageModule.Services;

namespace HikeService.HikesModule.Controllers
{
	public class HikesController : ApiController
	{
		public List<HikeSummary> Get (string type, string user)
		{
            HikeSummaryBuilder summaryBuilder = BuilderFactory.GetHikeSummaryBuilder();
		    IDataStorageService dataStorageService = ServiceFactory.GetStorageService();

		    List<string> urls = dataStorageService.GetUrls(type, user);
		    return urls.Select(url => summaryBuilder.Build(url)).ToList();
		}

		public bool Post (string type, string user, [FromBody] UserData data)
		{
		    IDataStorageService dataStorageService = ServiceFactory.GetStorageService();
		    return dataStorageService.WriteUrl(user, type, data.Value);
		}
	}

	public class UserData
	{
		public string Value;
	}
}