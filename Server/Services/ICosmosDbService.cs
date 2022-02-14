using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Shared.Models;

namespace Server
{


    public interface ICosmosDbService
    {
        Task<IEnumerable<EncFile>> GetItemsAsync(string query);
        Task<EncFile> GetItemAsync(string id);
        Task AddItemAsync(EncFile file);
        Task UpdateItemAsync(string id, EncFile file);
        Task DeleteItemAsync(string id);
    }

}