using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Shared.Models;


namespace Server
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuth : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICosmosDbService _cosmosDbService;

        //Constructor
        public UserAuth(ILogger<UserAuth> logger, ICosmosDbService client)
        {
            _cosmosDbService = client;
            _logger = logger;
        }

        [HttpPost]
        [Route("createuser")]
        public async Task Post()
        {
            TransferMeUser UserObj = await HttpContext.Request.ReadFromJsonAsync<TransferMeUser>() ?? new TransferMeUser();
            if (UserObj != null)
            {
                await _cosmosDbService.AddUserAccountAsync(UserObj);
            }
            return;
        }

    }
}
