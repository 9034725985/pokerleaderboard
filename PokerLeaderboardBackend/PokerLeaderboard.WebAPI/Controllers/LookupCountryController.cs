using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using PokerLeaderboard.BusinessLogic;
using PokerLeaderboard.Infrastructure;

namespace PokerLeaderboard.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LookupCountryController : ControllerBase
    {
        private readonly ILogger<LookupCountryController> _logger;

        public LookupCountryController(ILogger<LookupCountryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<LookupCountry>> Get()
        {
            string connectionString = "Host=balarama.db.elephantsql.com;Port=5432;Username=xukiiogf;Password=REkQDxhkxXdSd9Yj7gbj75ovitfPxr7k;Database=xukiiogf;Integrated Security=true;Pooling=true;Timeout=30";
            return await LookupCountryData.GetAllLookupCountries(connectionString);
        }
    }
}
