using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesLearning.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? PhotoPath { get; set; }

        

        public Location()
        {
            Id = new Random().Next();
            Name = "empty location";
            PhotoPath = "noImageCase.jpg";
            //Console.WriteLine(Id);
        }

        
    }
}
