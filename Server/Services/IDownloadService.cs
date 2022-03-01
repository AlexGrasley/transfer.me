using Client.Models;

namespace Server
{


    public interface IDownloadService
    {
        Task<IEnumerable<EncFile>> GetItemsAsync(string query);
        Task<EncFile> GetItemAsync(string id);
        Task<EncFile> GetEncFileAsync(string id);
    }

}