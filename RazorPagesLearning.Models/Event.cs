using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RazorPagesLearning.Models
{
    public class Event
    {
        //public Event(int id, string desc, string eventName)
        //{
        //    Id = id;
        //    Description = desc;
        //    EventName = eventName;
        //    PosX = -1; PosY = -1;
        //}
        //public Event(int id)
        //{
        //    Id = id;
        //}
        //public Event()
        //{
        //    Id = new Random().Next();
        //    PosX = -1; PosY = -1;
        //}
        

        public int Id { get; set; }
        [MaxLength(50)]
        public string? EventName { get; set; }

        public string? Description { get; set; }
        public int? PosX { get; set; }
        public int? PosY { get; set; }

        public string? PhotoPath { get; set; }
        public string? Date { get; set; }
        public int? LocationId { get; set; }

    }
}
