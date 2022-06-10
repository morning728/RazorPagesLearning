﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RazorPagesLearning.Models
{
    public class Location
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string? PhotoPath { get; set; }

        

        //public Location()
        //{
        //    Id = new Random().Next();
        //    Name = "empty location";
        //    PhotoPath = "noImageCase.jpg";
        //    //Console.WriteLine(Id);
        //}

        
    }
}
