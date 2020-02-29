using System;
using System.Collections.Generic;
using System.Threading;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NationalTeam.Models;
using NationalTeam.Repositories;
using NationalTeam.Repositories.Interfaces;
using NationalTeam.WebApi.Helper;
using Newtonsoft.Json;
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
        public string MeuQueridoTesteJson()
        {
            return "Vai Dani!!!!";
        }

        [Route("api/[controller]/param")]
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

        [Route("api/[controller]/getAll")]
        [HttpGet]
        public List<Team> GetAll()
        {
            return _teamRepository.GetAll();
        }

        [Route("api/[controller]/pegatimeano")]
        [HttpGet]
        public string PegaTimeAno()
        {
            var chromeOpt = new ChromeOptions();
            chromeOpt.AddArguments("--incognito");
            chromeOpt.AddArguments("--start-maximized");
            chromeOpt.AddArguments("--headless");

            var driver = new ChromeDriver(chromeOpt);
            
            const string url = "https://rsssfbrasil.com/sel/national.htm";

            try
            {
                var doc = new HtmlDocument();

                string link;
                string text;

                for (var i = 1; i < 9; i++)
                {
                    for (var j = 1; j < 6; j++)
                    {
                        Team team = new Team();
                        try
                        {
                            driver.Navigate().GoToUrl(url);
                            link = driver.FindElement(By.XPath($"/html/body/table[2]/tbody/tr[{i}]/td[{j}]/a")).GetAttribute("href");
                            text = driver.FindElement(By.XPath($"/html/body/table[2]/tbody/tr[{i}]/td[{j}]")).Text;

                            driver.Navigate().GoToUrl(link);

                            var teamName = driver.FindElement(By.XPath($"/html/body/table[1]/tbody/tr[3]/td/table/tbody/tr/td[1]/p[1]")).Text;
                            
                            var teamList = teamName.Split('\n');
                            team.Name = "Seleção Brasileira de " + text;
                            Console.WriteLine($"Link: {link} Texto: {text}");


                            foreach (var playerName in teamList)
                            {
                                Player player = new Player();
                                player.Name = playerName;
                                Console.WriteLine($"Jogador: {playerName}");
                                team.Players.Add(player);
                            }
                        }
                        catch 
                        {
                            Console.WriteLine("Sem Informação");
                        }
                        _teamRepository.Insert(team);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao navegar no Selenium. Mensagem: {e.Message} Stack: {e.StackTrace} ");
            }
            finally
            {
                driver?.Quit();
            }

            return JsonConvert.SerializeObject("");
        }
    }
}
