using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLearning.Models;
using RazorPagesLearning.Services;

namespace RazorPagesGeneral.Pages.Blog
{
    public class MainBlogPageModel : PageModel
    {
        private AppDBContext db;

        [BindProperty]
        public List<Note> notes { get; set; }
        public MainBlogPageModel(AppDBContext context)
        {
            db = context;
            notes = db.Notes.ToList();
        }
        [HttpGet]
        public void OnGet()
        {
        }
    }
}
