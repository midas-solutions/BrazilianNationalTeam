using System.Collections.Generic;

namespace NationalTeam.Models
{
    public class Team
    {
        public string Name { get; set; }

        public List<Player> Players { get; set; }

        public Team()
        {
            Players = new List<Player>();
        }
    }
}
