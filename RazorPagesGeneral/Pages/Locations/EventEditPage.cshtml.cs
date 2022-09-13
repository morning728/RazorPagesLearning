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

        
        
        public Location Location;
        [BindProperty]
        public IFormFileCollection Photo { get; set; }
        public Event Event;

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
                System.IO.File.Delete(filePath);

            }
            if (Photo != null)
            {
                Event.Photos = UploadFile(Event);
                Event.PhotoPath = GetFirstPhotoPath(Event);
            }

            #pragma warning disable CS8604 // Possible null reference argument.
            _db.UpdateEvent(Event);
            #pragma warning restore CS8604 // Possible null reference argument.

            return RedirectToPage("LocationPage", Location);
        }

        private string? UploadFile(Event Event)
        {
            string? newFileName = null;
            string addedPhotos = "";
            if (Event.Photos != null)
            {
                addedPhotos = Event.Photos;
            }
            if (Photo != null)
            {
                foreach (var i in Photo)
                {
                    string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    newFileName = Guid.NewGuid().ToString() + i.FileName;
                    addedPhotos += "," + newFileName;
                    string filePath = Path.Combine(uploadFolder, newFileName);

                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        i.CopyTo(fs);
                    }
                }
            }
            return addedPhotos;
        }

        public string GetFirstPhotoPath(Event Event)
        {
            if (Event.Photos != null)
            {
                IEnumerable<string> _list = Event.Photos.Split(",");
                return _list.Last(); ;
            }
            else { return "noImageCase.jpg"; }
        }
    }
}
