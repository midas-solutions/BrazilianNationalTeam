using NationalTeam.Mvc.Models;
using RestSharp;
using System.Collections.Generic;

namespace NationalTeam.Mvc.Clients
{
    public class TeamClient
    {
        public List<Team> GetAll()
        {
            var url = @"https://localhost:5001/api/team/getAll";
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(url, DataFormat.Json);
            var response = client.Execute<List<Team>>(request);
            return response.Data;
        }
    }
}