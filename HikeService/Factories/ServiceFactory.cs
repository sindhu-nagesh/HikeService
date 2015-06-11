using HikeService.HikesModule.Services.impl;
using HikeService.StorageModule.Services;
using HikeService.StorageModule.Services.impl;
using HikeService.WeatherModule.impl;

namespace HikeService.Factories
{
    static class ServiceFactory
    {
//        private static FileDataStorageService _fileStorageService;
        private static AzureDataStorageService _azureStorageService;
        private static WtaHikeDetailsService _wtaHikeDetailsService;
        private static WeatherUndergroundService _nationalWeatherDetailsService;

        static ServiceFactory()
         {
//             _fileStorageService = new FileDataStorageService();
             _azureStorageService = new AzureDataStorageService();
             _wtaHikeDetailsService = new WtaHikeDetailsService();
             _nationalWeatherDetailsService = new WeatherUndergroundService();
         }
        
        public static IDataStorageService GetStorageService()
        {
            return _azureStorageService;
        }

         public static WtaHikeDetailsService GetHikeDetailsService()
         {
             return _wtaHikeDetailsService;
         }

        public static WeatherUndergroundService GetWeatherDetailsService()
        {
            return _nationalWeatherDetailsService;
        }
    }
}