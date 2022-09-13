using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RazorPagesLearning.Models
{
    public class Event
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? EventName { get; set; }

        public string? Description { get; set; }
        public string? PhotoPath { get; set; }
        public string? Date { get; set; }
        public int? LocationId { get; set; }

        public string? Photos { get; set; }

        

    }
}
