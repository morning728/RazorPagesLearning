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
                PosX = Event.PosX, 
                PosY = Event.PosY,
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
                    item.PosY = newEvent.PosY;
                    item.PhotoPath = newEvent.PhotoPath;
                    item.PosX = newEvent.PosX;
                    item.Description = newEvent.Description;
                    item.Date = newEvent.Date;
                    return;
                };
            }
            return;
        }
    }
}
