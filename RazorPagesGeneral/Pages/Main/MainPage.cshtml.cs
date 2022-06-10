using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLearning.Models;
using RazorPagesLearning.Services.LocationRepository;

namespace RazorPagesGeneral.Pages.Main
{
    public class MainPageModel : PageModel
    {
        private readonly ILocationRepository _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MainPageModel(ILocationRepository db, IWebHostEnvironment webHostEnvironment)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            locations =_db.GetAllLocations();
        }
        public IEnumerable<Location> locations;
        public Location Location;

        [BindProperty]
        public IFormFile Photo { get; set; }
        public void OnGet()
        {
            locations = _db.GetAllLocations();
            //Location = new Location() {Name = "" };
        }
        public IActionResult OnPost(Location Location)
        {
            if (Location.PhotoPath != null)
            {

                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Location.PhotoPath);

                System.IO.File.Delete(filePath);
            }

            Location.PhotoPath = UploadFile();

#pragma warning disable CS8604 // Possible null reference argument.
            _db.AddLocation(Location);
#pragma warning restore CS8604 // Possible null reference argument.

            locations = _db.GetAllLocations();

            return Page();
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
