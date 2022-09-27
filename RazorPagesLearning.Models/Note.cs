using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesLearning.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string mainText { get; set; }
        public string? date { get; set; }
    }
}
