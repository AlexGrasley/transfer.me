using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Transfer.Me.Shared;
using Transfer.Me.Server;
using Transfer.Me.Shared.DataAccess;
using Transfer.Me.Shared.Models;

namespace Transfer.Me.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MariaDBController : ControllerBase
    {
        private readonly ILogger<EncryptedFile> _logger;
        private readonly MariaDBContext _context;

        public MariaDBController(ILogger<EncryptedFile> logger, MariaDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<EncryptedFile> Get()
        {
            return _context.EncryptedFile.ToList();
        }

    }
}
