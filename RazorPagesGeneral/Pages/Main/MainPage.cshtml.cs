using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLearning.Models;
using RazorPagesLearning.Services;
using RazorPagesLearning.Services.LocationRepository;

namespace RazorPagesGeneral.Pages.Main
{
    [Authorize]
    public class MainPageModel : PageModel
    {
        //private readonly ILocationRepository _db;
        private AppDBContext db;
        private readonly IWebHostEnvironment _webHostEnvironment;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public MainPageModel(AppDBContext context, IWebHostEnvironment webHostEnvironment)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            //_db = db;
            db = context;
            _webHostEnvironment = webHostEnvironment;
            
        }
        public IEnumerable<Location> locations;
        public Location Location;

        [BindProperty]
        public IFormFile Photo { get; set; }
        public void OnGet()
        {
            locations = db.Locations.ToList().Where(location => location.UserLogin == User.Identity.Name);
            //locations = _db.GetAllLocations();
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

            Location.UserLogin = User.Identity.Name;

#pragma warning disable CS8604 // Possible null reference argument.
            db.Add(Location);
            db.SaveChanges();
#pragma warning restore CS8604 // Possible null reference argument.

            locations = db.Locations.ToList().Where(location => location.UserLogin == User.Identity.Name);

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
