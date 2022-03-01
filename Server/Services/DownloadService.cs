using Microsoft.Azure.Cosmos;
using Client.Models;

namespace Server
{
    public class DownloadService : IDownloadService
    {
        private CosmosClient _client;
        private Database _database;
        private Container _container;
        public DownloadService(CosmosClient dbClient)
        {
            this._client = dbClient;
            this._database = _client.GetDatabase("TransferMe");
            this._container = _database.GetContainer("EncFile");
        }

       
        public async Task<EncFile> GetItemAsync(string id)
        {
            try
            {
                ItemResponse<EncFile> response = await _container.ReadItemAsync<EncFile>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public async Task<EncFile> GetEncFileAsync(string id)
        {
            string SQLQuery = $"SELECT * FROM c WHERE c.FileID = '{id}'";
            _container = _database.GetContainer("EncFile");
            QueryDefinition queryDefinition = new QueryDefinition(SQLQuery);
            FeedIterator<EncFile> queryResultSetIterator = _container.GetItemQueryIterator<EncFile>(queryDefinition);
            List<EncFile> Files = new List<EncFile>();
            while (queryResultSetIterator.HasMoreResults)
            {
                FeedResponse<EncFile> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                foreach (EncFile file in currentResultSet)
                {
                    Files.Add(file);
                    Console.WriteLine("\tRead {0}\n", file);
                }
            }
            return Files[0];
        }

        public async Task<IEnumerable<EncFile>> GetItemsAsync(string queryString)
        {
            var query = _container.GetItemQueryIterator<EncFile>(new QueryDefinition(queryString));
            List<EncFile> results = new List<EncFile>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        
    }
}