using BowlingProject.Models;
using BowlingProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

//here we will make views and models interact

namespace BowlingProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        //we want index to receive information about bowlers as well as information about the pagination
        public IActionResult Index(long? teamnumber, string teamname, int pageNum = 0)
        {
            int pageSize = 5;

            return View(new IndexViewModel
            {
                Bowlers = (context.Bowlers
                    .Where(b => b.TeamId == teamnumber || teamnumber == null) //display bowlers filtered by team or all bowlders if team is null
                    .OrderBy(b => b.Team)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize)
                    .ToList()),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,

                    //if no team has been selected, get the full count of bowlers
                    //otherwise, count the number of bowlers for the selected team
                    TotalNumItems = (teamnumber == null ? context.Bowlers.Count() :
                        context.Bowlers.Where(x => x.TeamId == teamnumber).Count())
                },

                TeamName = teamname
            }) ;
                
                //context.Bowlers
                //.Where(b => b.TeamId == teamnumber || teamnumber == null)
                //.OrderBy(b => b.Team)
                //.Skip((currentPage - 1) * pageSize)
                //.Take(pageSize)
                //.ToList());
                //.FromSqlInterpolated($"SELECT * FROM Bowlers WHERE TeamId = {teamnumber} OR {teamnumber} IS NULL")
                //.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
