using RazorPagesLearning.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesLearning.Services
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
                new Event(2,"Некое описание ляляля","Event 3"){PosX = 100, PosY=600 },
                new Event(3,"Некое описанfggggggggggggggggggggggggggggggggfgggggggggggggggggggggggggggggggggggие ляляля","Event 4"){PosX = -1, PosY=-1 },
                new Event(4, "Некое описание ляляля", "Event 5"){PosX = 1000, PosY=800 }
            };
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return EventList;
        }
        public void add_new_event(string description, string EventName, int? Posx = 50, int? Posy = 50)
        {
            if (description == null) description = "null Description";
            if (EventName == null) EventName = "null Event name";
            EventList.Add(new Event(new Random().Next(), description, EventName) {PosX = Posx, PosY = Posy });
            //@Console.WriteLine(description);
        }
    }
}
