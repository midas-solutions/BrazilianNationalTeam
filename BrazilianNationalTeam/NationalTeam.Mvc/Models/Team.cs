using NationalTeam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NationalTeam.Mvc.Models
{
    public class Team
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }
    }
}