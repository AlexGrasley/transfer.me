using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Client.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileDownload : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        private readonly IDownloadService _DownloadService;
        public FileDownload(IWebHostEnvironment env, IDownloadService DownloadService)
        {
            this.env = env;
            _DownloadService = DownloadService;
        }

        [HttpGet("id")]
        public async Task<EncFile> Get(string id)
        {
            //string id = await HttpContext.Request.ReadFromJsonAsync<string>() ?? new string("");
            EncFile file = await _DownloadService.GetEncFileAsync(id);
            return file;
        }
    }
}