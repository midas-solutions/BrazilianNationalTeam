using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrazilianNationalTeam.WebApi.Models
{
    public class Team
    {
        //TODO: Colocar o ano da seleção
        public string Name { get; set; }

        public List<Player> Players { get; set; }

        public Team()
        {
            Players = new List<Player>();
        }
    }
}
