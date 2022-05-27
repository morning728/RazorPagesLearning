using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLearning.Models;
using RazorPagesLearning.Services;

namespace RazorPagesGeneral.Pages.SomeInformation
{
    public class SomeInfoModel : PageModel
    {
        private readonly IEventRepository _db; 
        public SomeInfoModel(IEventRepository db)
        {
            _db = db;
        }

        public IEnumerable<Event> events;
        public void OnGet()
        {
            events = _db.GetAllEvents();
        }
    }
}
