using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesLearning.Models;
using RazorPagesLearning.Services;

namespace RazorPagesGeneral.Pages.Blog
{
    public class NoteEditorPageModel : PageModel
    {
        private AppDBContext db;
        [BindProperty]
        public Note? note { get; set; }
        public string title { get; set; }
        public string mainText { get; set; }
        public NoteEditorPageModel(AppDBContext context)
        {
            db = context;
        }
        public void OnGet(int id = -1)
        {
            if (id != -1)
            {
                note = db.Notes.FirstOrDefault(n => n.Id == id);
            }
        }
        [HttpPost]
        public async Task<IActionResult> OnPost(string title, string mainText)
        {
            var a = await db.Notes.AddAsync(new Note() { mainText = mainText, title = title });
            db.SaveChanges();
            return RedirectToPage("/Blog/MainBlogPage");  
        }
    }
}
