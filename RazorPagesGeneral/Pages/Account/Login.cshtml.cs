using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesLearning.Models;
using RazorPagesLearning.Services;
using System.Security.Claims;

namespace RazorPagesGeneral.Pages.Account
{
    public class IndexModel : PageModel
    {
        private AppDBContext db;

        [BindProperty]
        public User user { get; set; }
        public IndexModel(AppDBContext context)
        {
            db = context;
        }
        [HttpGet]
        public void OnGet()
        {
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            User usr = await db.Users.FirstOrDefaultAsync(u => u.login == user.login && u.password == user.password);
            if (usr != null)
            {
                await Authenticate(user.login); // аутентификация

                return RedirectToAction("Main/MainPage");
            }
            return RedirectToAction("Register");
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
