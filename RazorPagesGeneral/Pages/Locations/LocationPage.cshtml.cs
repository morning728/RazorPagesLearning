using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLearning.Models;
using RazorPagesLearning.Services.EventRepository;
using RazorPagesLearning.Services.LocationRepository;

namespace RazorPagesGeneral.Pages.Locations
{
    public class LocationPageModel : PageModel
    {
        private readonly IEventRepository _db;
        private readonly ILocationRepository _db_locations;
        private readonly IWebHostEnvironment _webHostEnvironment;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public LocationPageModel(IEventRepository db, IWebHostEnvironment webHostEnvironment, ILocationRepository db_l)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _db_locations = db_l;
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            events = _db.GetAllEvents();
        }

        public Location? Location;

        public IEnumerable<Event> events;
        public Event Event;

        [BindProperty]
        public IFormFile Photo { get; set; }
        public void OnGet(int id)
        {
            Location = _db_locations.GetLocationByID(id);
            Console.WriteLine(Location.Id);
            events = _db.GetAllEvents();
            //Event = new Event(728);
        }
        public IActionResult OnPost(Event Event, int id)
        {
            if (Event.PhotoPath != null) {

                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Event.PhotoPath);

                System.IO.File.Delete(filePath);
            }
            
            Event.PhotoPath = UploadFile();
            Location = _db_locations.GetLocationByID(id);
            Event.LocationId = Location.Id;
            #pragma warning disable CS8604 // Possible null reference argument.
            _db.add_new_event(Event);
#pragma warning restore CS8604 // Possible null reference argument.
            
            events = _db.GetAllEvents();

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
