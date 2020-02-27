using System.Collections.Generic;
using NationalTeam.Models;

namespace NationalTeam.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();

        bool Insert(T team);
    }

    public interface ITeamRepository : IRepository<Team>
    {

    }
}
