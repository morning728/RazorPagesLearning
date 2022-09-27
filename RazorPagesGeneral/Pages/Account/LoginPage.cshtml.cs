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
                await Authenticate(usr); // ��������������

                return RedirectToPage("/Main/MainPage");
            }
            return RedirectToPage("/Account/RegisterPage");
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
