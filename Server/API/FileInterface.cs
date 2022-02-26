using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Client.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileInterface : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        private readonly ICosmosDbService _cosmosDbService;
        public FileInterface(IWebHostEnvironment env, ICosmosDbService cosmosDbService)
        {
            this.env = env;
            _cosmosDbService = cosmosDbService;
        }
        // POST api/FileInterface
        // takes in a post request and looks for files. If there are files, stores them in database.
        [HttpPost]
        [Route("Upload")]
        public async Task Post()
        {
            List<EncFile> files = new List<EncFile>();
            files = await HttpContext.Request.ReadFromJsonAsync<List<EncFile>>() ?? new List<EncFile>();
            if (files.Count > 0)
            {
                foreach (EncFile file in files)
                {
                    await _cosmosDbService.AddItemAsync(file);
                }
            }
        }
    }
}