using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLearning.Models;
using RazorPagesLearning.Services;

namespace RazorPagesGeneral.Pages.SomeInformation
{
    public class EventEditPageModel : PageModel
    {
        private IEventRepository _db;
        public List<Event> events;
        public Event Event { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EventEditPageModel(IEventRepository db) {
            _db = db;
            events = (List<Event>)_db.GetAllEvents();
        }
        #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public void OnGet(int id)
        {
            Event = _db.GetEventByID(id);
        }
    }
}
