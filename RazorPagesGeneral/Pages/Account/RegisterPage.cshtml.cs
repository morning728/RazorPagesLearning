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
            if (usr == null)
            {
                // ��������� ������������ � ��
                db.Users.Add(new User { login = user.login, password = user.password, role = "RegularUser" });
                await db.SaveChangesAsync();

                await Authenticate(new User { login = user.login, password = user.password, role = "RegularUser" }); // ��������������

                return RedirectToPage("/Main/MainPage");
            }
            else
                return Page();
        }

        private async Task Authenticate(User user)
        {
            // ������� ���� claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.role),
            };
            // ������� ������ ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // ��������� ������������������ ����
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
