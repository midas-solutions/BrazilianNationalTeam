using NationalTeam.Mvc.Clients;
using System;
using System.Web.Mvc;

namespace NationalTeam.Mvc.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        public ActionResult Index()
        {
            TeamClient client = new TeamClient();
            var result = client.GetAll();
            return View(result);
        }
    }


}