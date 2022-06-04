using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLearning.Models;
using RazorPagesLearning.Services.EventRepository;

namespace RazorPagesGeneral.Pages.Locations
{
    public class SomeInfoModel : PageModel
    {
        public IEventRepository _db;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SomeInfoModel(IEventRepository db)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _db = db;
            events = (List<Event>)_db.GetAllEvents();
        }
        public List<Event> events;
        public Event Event;
        public void OnGet()
        {
           Event = new Event();
        }
        public IActionResult OnPost(Event Event)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            _db.add_new_event(Event);
#pragma warning restore CS8604 // Possible null reference argument.
            events = (List<Event>)_db.GetAllEvents();
            return Page();
        }

    }
}
