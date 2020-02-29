using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NationalTeam.Models;
using NationalTeam.Repositories;
using NationalTeam.Repositories.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NationalTeam.WebApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ILogger<TeamController> _logger;

        private readonly IRepository<Team> _teamRepository;

        public TeamController(ILogger<TeamController> logger, ITeamRepository repository)
        {
            _logger = logger;
            _teamRepository = repository;
        }

        [Route("api/[controller]/getTeams")]
        [HttpGet]
        public List<Team> Get()
        {
            return _teamRepository.GetAll();
        }




        [Route("api/[controller]/meuqueridotestejson")]
        [HttpGet]
        public string MeuQueridoTesteJson() {
            return "just do it";
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
