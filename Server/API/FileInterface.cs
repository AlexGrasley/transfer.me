using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Client.Models;
using Server.Logger;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileInterface : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        private readonly ICosmosDbService _cosmosDbService;
        private readonly Server.Logger.ILogger _logger;
        public FileInterface(IWebHostEnvironment env, ICosmosDbService cosmosDbService, Server.Logger.ILogger logger)
        {
            this.env = env;
            _cosmosDbService = cosmosDbService;
            _logger = logger;
        }
        // POST api/FileInterface
        // takes in a post request and looks for files. If there are files, stores them in database.
        [HttpPost]
        [Route("Upload")]
        public async Task Post()
        {
            List<EncFile> files = new List<EncFile>();
            try
            {
                files = await HttpContext.Request.ReadFromJsonAsync<List<EncFile>>() ?? new List<EncFile>();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, MethodBase.GetCurrentMethod().Name, ex.Message);
            }
            
            if (files.Count > 0)
            {
                foreach (EncFile file in files)
                {
                    try
                    {
                        await _cosmosDbService.AddItemAsync(file);
                        _logger.Log(LogLevel.Information, MethodBase.GetCurrentMethod().Name, $"Uploading file: {file.Description}; {file.ID}");
                    }
                    catch (Exception ex)
                    {
                        _logger.Log(LogLevel.Error, MethodBase.GetCurrentMethod().Name, ex.Message);
                    }

                }
            }
        }
    }
}