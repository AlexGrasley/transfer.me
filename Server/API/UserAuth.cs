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
    }
}
