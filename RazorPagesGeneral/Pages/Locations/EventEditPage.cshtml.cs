using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLearning.Models;
using RazorPagesLearning.Services.EventRepository;
using RazorPagesLearning.Services.LocationRepository;

namespace RazorPagesGeneral.Pages.Locations
{
    public class EventEditPageModel : PageModel
    {
        private readonly ILocationRepository _db_locations;
        private IEventRepository _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Event Event;
        public Location Location;
        [BindProperty]
        public IFormFile Photo { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EventEditPageModel(IEventRepository db, IWebHostEnvironment webHostEnvironment, ILocationRepository db_locations) {
            _db_locations = db_locations;
            _db = db;
            
            _webHostEnvironment = webHostEnvironment;
            
        }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void OnGet(int id)
        {
            Event = _db.GetEventByID(id);
            Location = _db_locations.GetLocationByID((int)Event.LocationId);
        }

        public IActionResult OnPost(Event Event, Location Location) {
            if (Photo != null && Event.PhotoPath != null)
            {

                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Event.PhotoPath);
                Console.WriteLine("21");
                System.IO.File.Delete(filePath);

            }
            if (Photo != null)
            {
                Event.PhotoPath = UploadFile();
            }

            #pragma warning disable CS8604 // Possible null reference argument.
            _db.UpdateEvent(Event);
            #pragma warning restore CS8604 // Possible null reference argument.

            return RedirectToPage("LocationPage", Location);
        }

        private string? UploadFile()
        {
            string? newFileName = null;
            if (Photo != null)
            {
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                newFileName = Guid.NewGuid().ToString() + Photo.FileName;
                string filePath = Path.Combine(uploadFolder, newFileName);

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                }
            }
            return newFileName;
        }
    }
}
