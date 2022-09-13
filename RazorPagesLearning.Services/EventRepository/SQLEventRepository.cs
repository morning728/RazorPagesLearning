using RazorPagesLearning.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesLearning.Services.EventRepository
{
    public class SQLEventRepository : IEventRepository
    {
        private readonly AppDBContext _context;

        public SQLEventRepository(AppDBContext context)
        {
            _context = context;
        }
        public void add_new_event(Event Event)
        {
            _context.Events.Add(Event);
            _context.SaveChanges();
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _context.Events;
        }

        public Event GetEventByID(int id)
        {
            return _context.Events.Find(id);
        }

        public void UpdateEvent(Event newEvent)
        {
            var Event = _context.Events.Attach(newEvent);
            Event.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        
    }
}
