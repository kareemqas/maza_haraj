using Mazad_Haraj.Data;
using Mazad_Haraj.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Mazad_Haraj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HarajDbContext _db;

        public HomeController(ILogger<HomeController> logger, HarajDbContext harajDbContext)
        {

            _logger = logger;

            _db = harajDbContext;
        }

        public IActionResult Index()
        {
            //var lastthree = _db.Auctions.Include(x => x.Vechile).OrderByDescending(a => a.Id).Where(x=>x.Status == Enums.AuctionStatus.Currently).Take(3).ToList();
            //var lastone = _db.Auctions.Include(x => x.Vechile).OrderByDescending(a => a.Id).Where(x => x.Status == Enums.AuctionStatus.Currently).FirstOrDefault();

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Message msg)
        {

            if (ModelState.IsValid)
            {
                _db.Messages.Add(msg);
                _db.SaveChanges();
            }
            return View();
        }

       
    }
}