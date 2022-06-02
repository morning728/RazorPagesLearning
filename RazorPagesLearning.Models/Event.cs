using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesLearning.Models
{
    public class Event
    {
        public Event(int id, string desc, string eventName)
        {
            Id = id;
            Description = desc;
            EventName = eventName;
            PosX = -1; PosY = -1;
        }
        public Event(int id)
        {
            Id = id;
        }
        public Event()
        {
            Id = -1;
            Description = "empty_event";
            EventName = "empty_event_name"; 
            PosX = -1; PosY = -1;
        }
        

        public int Id { get; set; }
        public string? EventName { get; set; }

        public string? Description { get; set; }

        public int? PosX { get; set; }
        public int? PosY { get; set; }

        public string? PhotoPath { get; set; }

    }
}
