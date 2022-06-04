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
                new Event(0, "Некое описание ляляля", "Event 1"){PosX = 20, PosY=20 },
                new Event(1, "Некое описание ляляля", "Event 2"){PosX = 500, PosY=690 },
                new Event(2,"Некое описание ляляля","Event 3"){PosX = 100, PosY=600, PhotoPath = "Event5pic.jpg" },
                new Event(3,"Некое описанfggggggggggggggggggggggggggggggggfgggggggggggggggggggggggggggggggggggие ляляля","Event 4"){PosX = -1, PosY=-1 },
                new Event(4, "Некое описание ляляля", "Event 5"){PosX = 1000, PosY=800, Date="2017-01-02" }
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
