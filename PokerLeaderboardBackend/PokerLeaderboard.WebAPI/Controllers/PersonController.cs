using System.Net;
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
    public class PersonController : ControllerBase
    {
        private static readonly string connectionString = "Host=balarama.db.elephantsql.com;Port=5432;Username=xukiiogf;Password=REkQDxhkxXdSd9Yj7gbj75ovitfPxr7k;Database=xukiiogf;Integrated Security=true;Pooling=true;Timeout=30";
        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> Get()
        {
            
            return await PersonData.Get(connectionString);
        }
        [HttpGet("{fullName}")]
        public async Task<IEnumerable<Person>> GetByFullName(string fullName)
        {
            return await PersonData.Get(connectionString);
        }
        [HttpPost]
        public async Task<bool> Create(Person person)
        {
            return await PersonData.AddPerson(connectionString: connectionString, fullName: "Full Name", winnings: 20M, countryAbbreviation: "USA");
        }
        [HttpDelete]
        public async Task<bool> Delete(Guid ExternalId)
        {
            return await PersonData.DeletePerson(connectionString: connectionString, externalId: ExternalId);
        }
    }
}
