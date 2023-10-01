using Mazad_Haraj.Data;
using Mazad_Haraj.Models;
using Mazad_Haraj.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Mazad_Haraj.Areas.Admin.Controllers
{
    public class UsersController : BaseController
    {
        private readonly HarajDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public UsersController(HarajDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _context.Users.Where(x => !x.IsDelete).ToListAsync();

            if (result == null)
            {
                return View();
            }
            return View(result);
        }

        public async Task<IActionResult> GetVerify()
        {
            var result = await _context.Users.Where(x => !x.IsDelete && x.IsVerify).ToListAsync();

            if (result == null)
            {
                return View();
            }
            return View(result);

        }
        public async Task<IActionResult> GetNotVerify()
        {
            var result = await _context.Users.Where(x => !x.IsDelete && !x.IsVerify).ToListAsync();

            if (result == null)
            {
                return View();
            }
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Verify(string id)
        {

            var user = await _context.Users.FirstOrDefaultAsync(x => !x.IsDelete && !x.IsVerify);

            if (user == null)
            {
                return RedirectToAction(nameof(Index));
            }

            user.IsVerify = true;
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> NotVerify(string id)
        {

            var user = await _context.Users.FirstOrDefaultAsync(x => !x.IsDelete && x.IsVerify);

            if (user == null)
            {
                return RedirectToAction(nameof(Index));
            }

            user.IsVerify = false;
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
     //   // POST: Admin/User/Create
     //   [HttpPost]
     //   public async Task<IActionResult> Create(UserDto dto)
     //   {
     //       if (ModelState.IsValid)
     //       {
     //           var emailExists = await _context.Users
     //.AnyAsync(x => !x.IsDelete && (x.Email == dto.Email));

     //           if (emailExists)
     //           {
     //               return RedirectToAction(nameof(Index));
     //           }
     //           try
     //           {
     //               AppUser user = new AppUser
     //               {
     //                   Name = dto.Name,
     //                   UserName = dto.Email,
     //                   Email = dto.Email,
     //                   EmailConfirmed = true,
     //                   IsVerify = true,
     //                   IsDelete = false
     //               };

     //               if (user != null) {
     //               await _userManager.CreateAsync(user, GenerateRandomPassword());
     //               return RedirectToAction(nameof(Index));
     //               }
     //           }
     //           catch (Exception)
     //           {
     //               return RedirectToAction(nameof(Index));

     //               throw;
     //           }


     //       }

     //       return RedirectToAction(nameof(Index));
     //   }


        private string GenerateRandomPassword()
        {
            string symbols = "$#@ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 10; i++)
            {
                int index = random.Next(symbols.Length);
                sb.Append(symbols[index]);
            }

            return sb.ToString();
        }

    }
}
