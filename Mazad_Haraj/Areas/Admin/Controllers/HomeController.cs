using Mazad_Haraj.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mazad_Haraj.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        HarajDbContext _dbContext;
        public HomeController(HarajDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: HomeController
        public ActionResult Index()
        {
            DateTime currentDate = DateTime.Now;

            ViewBag.totalAuctions = _dbContext.Auctions.Count();
            ViewBag.expiredAuctions = _dbContext.Auctions.Count(auction => auction.ExpiryDate <= currentDate);
            ViewBag.activeAuctions = _dbContext.Auctions.Count(auction => auction.StartDate <= currentDate && auction.ExpiryDate > currentDate);
            ViewBag.upcomingAuctions = _dbContext.Auctions.Count(auction => auction.StartDate > currentDate);
            return View();
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
