using NationalTeam.Models;
using System;
using System.Collections.Generic;
using NationalTeam.Repositories.Interfaces;

namespace NationalTeam.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        public static List<Team> Teams { get; set; }

        public TeamRepository()
        {
            Teams = new List<Team>();
        }

        public List<Team> GetAll()
        {
            return Teams;
        }

        public bool Insert(Team team)
        {
            bool success = true;
            Teams.Add(team);
            return success;
        }
    }
}
