using Mazad_Haraj.Data;
using Mazad_Haraj.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mazad_Haraj.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuctionController : Controller
    {
        private HarajDbContext _context;
        public AuctionController(HarajDbContext context) {
        
        _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Auction auction)
        {
            if (ModelState.IsValid)
            {
                _context.Auctions.Add(auction);
                _context.SaveChanges();
                return View();

            }
            else {

                return View();

            }

        }
    }
}
