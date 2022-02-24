using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using Client.Code;

namespace Server
{
    public class CosmosDbService : ICosmosDbService
    {
        private CosmosClient _client;
        private Database _database;
        private Container _container;
        public CosmosDbService(CosmosClient dbClient)
        {
            this._client = dbClient;
            this._database = _client.GetDatabase("TransferMe");
            this._container = _database.GetContainer("EncFile");
        }

        public async Task AddItemAsync(EncFile file)
        {
            await _container.CreateItemAsync<EncFile>(file, new PartitionKey(file.FileID));
        }

        public async Task DeleteItemAsync(string id)
        {
            await _container.DeleteItemAsync<EncFile>(id, new PartitionKey(id));
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

        public async Task UpdateItemAsync(string id, EncFile file)
        {
            await _container.UpsertItemAsync<EncFile>(file, new PartitionKey(id));
        }

        public async Task AddUserAccountAsync(TransferMeUser UserObject)
        {
            var container = _database.GetContainer("Users");
            var tmp = await container.CreateItemAsync<TransferMeUser>(UserObject, new PartitionKey (UserObject.UserID));
        }

        public async Task ValidateUserSignInAttemptAsync(SignInRequest SignInReq)
        {
            object Data = await _container.ReadContainerAsync();
            //todo
        }

        public async Task UpdateUserPasswordAsync(SignInRequest SignInReq)
        {
            //todo https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.cosmos.container.patchitemasync?view=azure-dotnet
            //object p = await _container.PatchItemAsync()
        }
    }
}