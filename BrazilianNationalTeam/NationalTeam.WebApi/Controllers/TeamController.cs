using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NationalTeam.Models;

namespace NationalTeam.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly List<Team> _teams;

        private readonly ILogger<TeamController> _logger;

        public TeamController(ILogger<TeamController> logger)
        {
            _logger = logger;
            _teams = new List<Team>();
            // TODO: melhorar essa parte, criar classe repositorio etc...
            var brazilianTeam = new Team();
            brazilianTeam.Name = "Seleção Brasileira";
            brazilianTeam.Players.Add(new Player
            {
                Name = "Tafarel"
            });
            _teams.Add(brazilianTeam);
        }

        [HttpGet]
        public List<Team> Get()
        {
            return _teams;
        }
    }
}
