using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using HikeService.StorageModule.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace HikeService.StorageModule.Services.impl
{
    public class AzureDataStorageService: IDataStorageService
    {
        private const string HikesTableName = "HikesTable";
        public CloudTableClient Client { get; set; }
        public CloudTable HikesTable { get; set; }
        public AzureDataStorageService()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["hikeservicestorage"].ConnectionString;
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            Client = storageAccount.CreateCloudTableClient();
            InitializeTables();
        }

        private void InitializeTables()
        {
            CloudTable htable = Client.GetTableReference(HikesTableName);
            htable.CreateIfNotExists();
            HikesTable = htable;
        }

        public bool WriteUrl(string user, string type, string url)
        {   
            MyDataEntity e = new MyDataEntity(user, url);
            bool result = false;
            if (!HasEntity(HikesTable, e))
            {
                result = InsertEntity(HikesTable, e);
            }

            return result;      
        }

        public List<string> GetUrls(string type, string user)
        {
            List<string> urls = new List<string>();
            if (HikesTable.Exists())
            {
                var query = new TableQuery<MyDataEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, user));
                var entities = HikesTable.ExecuteQuery(query).ToList();
                urls.AddRange(entities.Select(entity => entity.Url));
            }
            
            return urls;
        }       

        private bool HasEntity(CloudTable table, MyDataEntity e)
        {
            TableOperation op = TableOperation.Retrieve<MyDataEntity>(e.PartitionKey, e.RowKey);
            TableResult entity = table.Execute(op);
            return (entity.Result != null);
        }

        private bool InsertEntity(CloudTable table, MyDataEntity e)
        {
            TableOperation op = TableOperation.Insert(e);
            TableResult entity = table.Execute(op);
            return (entity.Result != null);
        }
    }    
}