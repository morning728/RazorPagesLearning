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
    public class RegisterModel : PageModel
    {
        private AppDBContext db;

        [BindProperty]
        public User user { get; set; }
        public RegisterModel(AppDBContext context)
        {
            db = context;
        }
        [HttpGet]
        public void OnGet()
        {
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPost()
        {
            User usr = await db.Users.FirstOrDefaultAsync(u => u.login == user.login);
            Console.WriteLine(user.password);
            if (usr == null)
            {
                // добавляем пользователя в бд
                db.Users.Add(new User { login = user.login, password = user.password });
                await db.SaveChangesAsync();
                Console.WriteLine("Добро пожаловать в C#!");

                await Authenticate(user.login); // аутентификация

                return RedirectToAction("Main/MainPage");
            }
            else
                return Page();
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
