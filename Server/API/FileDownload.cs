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
    public class FileDownload : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        private readonly IDownloadService _DownloadService;
        private readonly Server.Logger.ILogger _logger;
        public FileDownload(IWebHostEnvironment env, IDownloadService DownloadService,Server.Logger.ILogger logger)
        {
            this.env = env;
            _DownloadService = DownloadService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<EncFile> Get(string id)
        {
            try
            {
                EncFile file = await _DownloadService.GetEncFileAsync(id);
                _logger.Log(LogLevel.Information, MethodBase.GetCurrentMethod().Name, $"Downloading file: {file.Description}; {id}");
                return file;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, MethodBase.GetCurrentMethod().Name, ex.Message);
                return new EncFile() {Description="Download Failed"};
            }
            
        }
    }
}