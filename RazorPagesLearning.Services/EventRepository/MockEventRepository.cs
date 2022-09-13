using RazorPagesLearning.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesLearning.Services.EventRepository
{
    public class MockEventRepository : IEventRepository
    {
        private List<Event> EventList;
        public MockEventRepository()
        {
            EventList = new List<Event>()
            {
            };
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return EventList; 
        }
        public void add_new_event(Event Event)
        {
            EventList.Add(new Event() { 
                
                PhotoPath = Event.PhotoPath ,
                EventName = Event.EventName,
                Description = Event.Description,
                LocationId = Event.LocationId

            });
        }

        public Event GetEventByID(int id)
        {
            foreach (var item in EventList)
            {
                if (item.Id == id) return item;
            }
            return new Event();
        }

        public void UpdateEvent(Event newEvent)
        {
            foreach (var item in EventList)
            {
                if (item.Id == newEvent.Id)
                {
                    item.EventName = newEvent.EventName;
                    item.PhotoPath = newEvent.PhotoPath;
                    item.Description = newEvent.Description;
                    item.Date = newEvent.Date;
                    return;
                };
            }
            return;
        }

       
    }
}
