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
        [HttpPost]
        public IActionResult Create(VotingItem p)
        {
            _Context.VotingItem.Add(p);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            VotingItem prod = _Context.VotingItem.FirstOrDefault(p => p.VotingItemId == id);        
            return View(prod);            
        }
        [HttpPost]
        public IActionResult Edit(VotingItem item)
        {
            VotingItem prod = _Context.VotingItem.FirstOrDefault(p => p.VotingItemId == item.VotingItemId);
            if (prod != null)
            {                
                prod.VotingItemName = item.VotingItemName;
                _Context.SaveChanges();
            }
            return RedirectToAction("Index");          
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                VotingItem prod = _Context.VotingItem.FirstOrDefault(p => p.VotingItemId== id);
                if (prod != null)
                {
                    _Context.VotingItem.Remove(prod);
                    _Context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
