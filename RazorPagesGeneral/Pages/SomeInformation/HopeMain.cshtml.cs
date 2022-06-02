using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLearning.Models;
using RazorPagesLearning.Services;

namespace RazorPagesGeneral.Pages.SomeInformation
{
    public class HopeMainModel : PageModel
    {
        private readonly IEventRepository _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public HopeMainModel(IEventRepository db, IWebHostEnvironment webHostEnvironment)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            events = (List<Event>)_db.GetAllEvents();
        }
        public List<Event> events;
        public Event Event;

        [BindProperty]
        public IFormFile Photo { get; set; }
        public void OnGet()
        {
            Event = new Event(728);
        }
        public IActionResult OnPost(Event Event)
        {
            if (Event.PhotoPath != null) {

                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Event.PhotoPath);

                System.IO.File.Delete(filePath);
            }
            
            Event.PhotoPath = UploadFile();
            
            #pragma warning disable CS8604 // Possible null reference argument.
            _db.add_new_event(description: Event.Description, EventName: Event.EventName, Event.PhotoPath, Event.PosX, Event.PosY);
            #pragma warning restore CS8604 // Possible null reference argument.
            
            events = (List<Event>)_db.GetAllEvents();
            
            return Page();
        }

        private string? UploadFile() {
            string? newFileName = null;
            if (Photo != null) {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                newFileName = Guid.NewGuid().ToString() + Photo.FileName;
                string filePath = Path.Combine(uploadFolder, newFileName);

                using (var fs = new FileStream(filePath, FileMode.Create)) { 
                    Photo.CopyTo(fs);
                }
            }
            return newFileName;
        }
        
    }
}
