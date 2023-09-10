using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using online_voting_system0910.Models;
using online_voting_system0910.Models.ViewModel;

namespace online_voting_system0910.Controllers
{
    public class ForestageController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly voting0910Context _Context;

        public ForestageController(ILogger<HomeController> logger, voting0910Context Context)
        {
            _logger = logger;
            _Context = Context;
        }

        public IActionResult Index()
        {
            var votingRecords = _Context.VotingRecord.ToList();
            var votingItems = _Context.VotingItem.ToList();

            var viewModel = from item in votingItems
                            join record in votingRecords on item.VotingItemId equals record.VotingItemId into recordGroup
                            select new VotingViewModel
                            {
                                VotingItemId = item.VotingItemId,
                                VotingItemName = item.VotingItemName,
                                VotingCount = recordGroup.Sum(r => 1)
                            };

            return View(viewModel);
        }
        public IActionResult Create()
        {
            var votingItems = _Context.VotingItem.ToList();
            ViewBag.VotingItems = votingItems;
            return View();
        }
    }
}
