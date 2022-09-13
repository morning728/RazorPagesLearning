using RazorPagesLearning.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesLearning.Services.EventRepository
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();
        public void add_new_event(Event Event);

        public Event GetEventByID(int id);

        public void UpdateEvent(Event newEvent);

        
    }
}
