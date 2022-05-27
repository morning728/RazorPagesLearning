using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesLearning.Models
{
    public class Event
    {
        public Event(int id, Dept name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public Dept? Name { get; set; }

    }
}
