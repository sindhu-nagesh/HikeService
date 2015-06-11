using HikeService.StorageModule.Utilities;
using Microsoft.WindowsAzure.Storage.Table;

namespace HikeService.StorageModule.Models
{
    public class MyDataEntity: TableEntity, ITableEntity
    {
        public string User { get; set; }    
        public string Url { get; set; }    
        public MyDataEntity(string user, string fullUrl)
        {
            Url = fullUrl;
            PartitionKey = user;
            RowKey = StorageUtility.ParseRowKey(fullUrl);
        }

        public MyDataEntity()
        {
        }
    }
}