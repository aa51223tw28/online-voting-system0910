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
            var viewModel = BuildVotingViewModel();
            return View(viewModel);
        }


        private List<VotingViewModel> BuildVotingViewModel()
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

            return viewModel.ToList();
        }


        public IActionResult Create()
        {
            var votingItems = _Context.VotingItem.ToList();
            ViewBag.VotingItems = votingItems;
            return View();
        }

        [HttpPost]
        public IActionResult Create(VotingCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                
                foreach (var votingItemId in viewModel.SelectedVotingItems)
                {
                    var votingItemRecord = new VotingRecord
                    {
                        Voter = viewModel.Voter,                       
                        VotingItemId = votingItemId
                    };
                    _Context.VotingRecord.Add(votingItemRecord);
                }

                _Context.SaveChanges();

                return RedirectToAction("Index"); 
            }

            return RedirectToAction("Index");
            
        }
    }
}
