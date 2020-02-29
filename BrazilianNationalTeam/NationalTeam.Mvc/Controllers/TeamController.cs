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
            ViewData["Hora"] = DateTime.Now;
            ViewBag.Hora = DateTime.Now;
            TempData["Hora"] = DateTime.Now;
            TeamClient client = new TeamClient();
            var result = client.GetAll();
            return View(result);
        }
    }
}