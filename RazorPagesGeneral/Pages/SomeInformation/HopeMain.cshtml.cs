using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLearning.Models;
using RazorPagesLearning.Services;

namespace RazorPagesGeneral.Pages.SomeInformation
{
    public class HopeMainModel : PageModel
    {
        public IEventRepository _db;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public HopeMainModel(IEventRepository db)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _db = db;
            events = (List<Event>)_db.GetAllEvents();
        }
        public List<Event> events;
        public Event Event;
        public void OnGet()
        {
            Event = new Event(728);
        }
        public IActionResult OnPost(Event Event)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            _db.add_new_event(description: Event.Description, EventName: Event.EventName, Event.PosX, Event.PosY);
#pragma warning restore CS8604 // Possible null reference argument.
            events = (List<Event>)_db.GetAllEvents();
            return Page();
        }
        
    }
}