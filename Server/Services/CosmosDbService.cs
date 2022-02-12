using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using Shared.Models;

namespace Server
{


    public class CosmosDbService : ICosmosDbService
    {
        //private Container _container;
        //private Database _database;
        public CosmosDbService()//CosmosClient dbClient,string databaseName,string containerName)
        {
           // this._database = dbClient.GetDatabase(databaseName);
           // this._container = dbClient.GetContainer(databaseName, containerName);
            
        }

        public async Task AddItemAsync(EncFile file, Container container)
        {
            await container.CreateItemAsync<EncFile>(file, new PartitionKey(file.FileID));
        }

        public async Task DeleteItemAsync(string id, Container container)
        {
            await container.DeleteItemAsync<EncFile>(id, new PartitionKey(id));
        }

        public async Task<EncFile> GetItemAsync(string id, Container container)
        {
            try
            {
                ItemResponse<EncFile> response = await container.ReadItemAsync<EncFile>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }

        }

        public async Task<IEnumerable<EncFile>> GetItemsAsync(string queryString, Container container)
        {
            var query = container.GetItemQueryIterator<EncFile>(new QueryDefinition(queryString));
            List<EncFile> results = new List<EncFile>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }

        public async Task UpdateItemAsync(string id, EncFile file, Container container)
        {
            await container.UpsertItemAsync<EncFile>(file, new PartitionKey(id));
        }
    }
}