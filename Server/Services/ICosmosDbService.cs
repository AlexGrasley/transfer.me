using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Shared.Models;

namespace Server
{


    public interface ICosmosDbService
    {
        Task<IEnumerable<EncFile>> GetItemsAsync(string query, Container container);
        Task<EncFile> GetItemAsync(string id, Container container);
        Task AddItemAsync(EncFile file, Container container);
        Task UpdateItemAsync(string id, EncFile file, Container container);
        Task DeleteItemAsync(string id, Container container);
    }
}