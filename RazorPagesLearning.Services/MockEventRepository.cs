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
                new Event(0, Dept.Note),
                new Event(1, Dept.Discription),
                new Event(2, Dept.None),
                new Event(3, Dept.Note),
                new Event(4, Dept.Discription)
            };
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return EventList;
        }
    }
}
