using System.Collections.Generic;

namespace NationalTeam.Models
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
