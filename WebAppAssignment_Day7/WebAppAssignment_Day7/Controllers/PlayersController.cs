using Microsoft.AspNetCore.Mvc;
using WebAppAssignment_Day7.Models;

namespace WebAppAssignment_Day7.Controllers
{
    public class PlayersController : Controller
    {
        private List<Player> players = new List<Player>()
        {
            new Player(){PId=1,PName="MS.Dhoni",PCountry="India",PType="WicketKeeper"},
            new Player(){PId=2,PName="Rohit Sharma",PCountry="India",PType="Batsman"},
            new Player(){PId=3,PName="R.Jadeja",PCountry="India",PType="All-rounder"}

        };
        public IActionResult Index()
        {
            ViewBag.Countries = GetDistinctCountries();
            return View(players);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Player());
        }
        [HttpPost]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                players.Add(player);
                return RedirectToAction("Index");
            }
            return View();
        }
        private IEnumerable<string> GetDistinctCountries()
        {
            return players.Select(players => players.PCountry).Distinct();
        }


    }
}
