using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NationalTeam.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NationalTeam.WebApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]
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

        [Route("api/[controller]/getTeams")]
        [HttpGet]
        public List<Team> Get()
        {
            return _teams;
        }

        [Route("api/[controller]/teste")]
        [HttpGet]
        public string Teste()
        {
            return "Vai Brasil!!!!";
        }

        [Route("api/[controller]/testeselenium")]
        [HttpGet]
        public string TesteSelenium()
        {
            var chromeOpt = new ChromeOptions();
            
            chromeOpt.AddArguments("--incognito");
            
            chromeOpt.AddArguments("--start-maximized");

            var driver = new ChromeDriver(chromeOpt);

            try
            {
                driver.Navigate().GoToUrl("https://www.google.com.br/");
                
                driver.FindElement(By.XPath("//*[@id=\"tsf\"]/div[2]/div[1]/div[1]/div/div[2]/input")).SendKeys("MIDAS SOLUTIONS");

                Thread.Sleep(TimeSpan.FromSeconds(2));

                driver.FindElement(By.XPath("//*[@id=\"tsf\"]/div[2]/div[1]/div[2]/div[2]/div[2]/center/input[1]")).Click();

                Thread.Sleep(TimeSpan.FromSeconds(2));

                driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div/div[1]/a/h3")).Click();
                
                Thread.Sleep(TimeSpan.FromSeconds(5));
            }
            catch (Exception ex)
            {
                return $"Errado {ex.Message}";
            }
            finally
            {
                driver?.Quit();
            }

            return "Navegação Ok";
        }



    }
}
