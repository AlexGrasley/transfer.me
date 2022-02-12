using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileInterface : ControllerBase
    {
        public CosmosClient _client;
        //private readonly IWebHostEnvironment env;
        private readonly ILogger _logger;
       // public ICosmosDbService _cosmosDbService;
    
        public FileInterface(ILogger<FileInterface> logger, CosmosClient client)//, ICosmosDbService cosmosDbService)
        {
            _logger = logger;
            _client = client;
            //_cosmosDbService = new CosmosDbService();
        }


        // POST api/FileInterface
        // takes in a post request and looks for files. If there are files, stores them in database.
        [HttpPost]
        [Route("Upload")]
        public async Task Post()
        {
            List<EncFile> files = new List<EncFile>();
            //files = await HttpContext.Request.ReadFromJsonAsync<List<EncFile>>() ?? new List<EncFile>();
            var File1 = new EncFile {
                Description = "TestFile1"
                
            };
            var File2 = new EncFile
            {
                Description = "TestFile2"

            };
            files.Add(File1);
            files.Add(File2);
            Database db = await _client.CreateDatabaseIfNotExistsAsync("TransferMe");
            Container container = db.GetContainer("EncFile");

            if (files.Count > 0)
            {
                foreach (EncFile file in files)
                {
                    await container.CreateItemAsync<EncFile>(file, new PartitionKey(file.FileID));
                }
            }
        }
    }
}