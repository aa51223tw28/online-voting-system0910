using Microsoft.AspNetCore.Mvc;
using online_voting_system0910.Models;

namespace online_voting_system0910.Controllers
{
    public class BackstageController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly voting0910Context _Context;

        public BackstageController(ILogger<HomeController> logger, voting0910Context Context)
        {
            _logger = logger;
            _Context = Context;
        }

        //public string? Test()
        //{
        //    return _Context.VotingItem.FirstOrDefault()?.VotingItemName;
        //}

        public IActionResult Index()
        {
            var votingItems = _Context.VotingItem.ToList();

            return View(votingItems);
            
        }
        public IActionResult Create()
        {           
            return View();

        }
    }
}
