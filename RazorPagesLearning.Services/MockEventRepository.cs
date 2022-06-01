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
                new Event(0, "153", "Imya"){PosX = 20, PosY=20 },
                new Event(1, "166", "Imya"){PosX = 100, PosY=30 },
                new Event(2){PosX = 40, PosY=40 },
                new Event(3){PosX = -1, PosY=-1 },
                new Event(4, "181", "Imya"){PosX = 70, PosY=70 }
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
