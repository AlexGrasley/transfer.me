using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Shared.Models;

namespace Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuth : ControllerBase
    {
        public CosmosClient _client;
        private readonly ILogger _logger;

        //Constructor
        public UserAuth(ILogger<UserAuth> logger, CosmosClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpPost]
        [Route("createuser")]
        public async Task CreateUser()
        {
            List<String> UserAccountData = await HttpContext.Request.ReadFromJsonAsync<List<String>>();
            Database db = await _client.CreateDatabaseIfNotExistsAsync("TransferMe");
            Container container = db.GetContainer("Users");
        }

    }
}
