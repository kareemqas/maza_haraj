using Mazad_Haraj.Data;
using Mazad_Haraj.Models;
using Mazad_Haraj.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Mazad_Haraj.DTO;

namespace Mazad_Haraj.Controllers
{
    public class AccountController : Controller
    {
        HarajDbContext _context;
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _SignInManager;
        readonly IWebHostEnvironment _webHost;


        public AccountController(HarajDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IWebHostEnvironment webHost)
        {
            _context = context;
            _userManager = userManager;
            _SignInManager = signInManager;
            _webHost = webHost;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(UserDto model)
        {
            //application/pdf

            if (!ModelState.IsValid)
            {

                return View();
            }

            string? img = UploadImage(model);

            AppUser user = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                Email = model.Email,
                City = model.City,
                Bio = model.Bio,
                Name = model.Name,
                IdNumber = model.IdNumber,
                WhatsAppNumber = model.WhatsAppNumber,
                UserName = model.Email,
                Type = model.Type,
                ImagePath = "/images/"+ img,

            };
            AppUser user2 = await _userManager.FindByEmailAsync(model.Email);
            if (user2 != null)
            {
                ModelState.AddModelError(string.Empty, "Sorry, The email already exists , please try Enter another email");
                return View("home");
            }

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim("Type", model.Type));
                return RedirectToAction("index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View();
            }


        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            return View(user);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {


            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            return View(user);
        }
        [Authorize]

        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            if (!ModelState.IsValid)
            {
                //return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.CurrnetPassword, model.Password);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return PartialView("_ChangePassword", model);
                //  return Page();
            }

            await _SignInManager.RefreshSignInAsync(user);

            return RedirectToAction("index", "Home");
        }
        [Authorize]

        [HttpPost]
        public async Task<IActionResult> Edit(AppUser model)
        {
            if (ModelState.IsValid)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                // Retrieve the user based on the model's id
                AppUser user = await _userManager.FindByIdAsync(userId);
                // Update the user's data with the new information
                model.Email = model.Email;
                model.City = model.City;
                model.Bio = model.Bio; ;
                model.Name = model.Name;
                model.IdNumber = model.IdNumber;
                model.WhatsAppNumber = model.WhatsAppNumber;
                model.UserName = model.Email;
                model.ImagePath = "/images/avatar/blank.png";

                // Save the changes
                var result = _userManager.UpdateAsync(user).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Profile", model); // Redirect to the user's profile page
                }
                else
                {
                    // Handle errors, e.g., show error messages to the user
                }
            }

            // If ModelState is not valid, redisplay the form with validation errors
            return RedirectToAction("Profile", model);
        }



        [HttpPost]
        public async Task<ActionResult> SignUp(UserDto model)
        {
            string? img = UploadImage(model);

            AppUser user = new AppUser()
            {
                 Id = Guid.NewGuid().ToString(),
                Email = model.Email,
                City = model.City,
                Bio = model.Bio,
                Name = model.Name,
                IdNumber = model.IdNumber,
                WhatsAppNumber = model.WhatsAppNumber,
                UserName = model.Email,
                Type = model.Type,
                ImagePath = "/images/"+ img,
            };

            AppUser user2 = await _userManager.FindByEmailAsync(model.Email);
            if (user2 != null)
            {
                return Ok(new { status = 0, message = "Email already exist", code = "existemail" });
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {

                await _SignInManager.SignInAsync(user, false);

                return Ok(new { status = 1, message = "success", code = "" });

                //return Ok(user);
            }
            else
            {
                var message = "";
                foreach (var error in result.Errors)
                {
                    message += error.Description;
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Ok(new { status = 0, message = message, code = "error" });

                //return Ok(new AppUser() { Id = "checkpassword" });
            }
        }
        private string UploadImage(UserDto user)
        {
            string fileName = null;
            if (user.Image != null)
            {
                string folderName = "images";
                string uploadDir = Path.Combine(_webHost.WebRootPath, folderName);
                fileName = Guid.NewGuid().ToString() + "-" + user.Image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    user.Image.CopyTo(stream);
                }


            }
            return fileName;

        }
    }
}
