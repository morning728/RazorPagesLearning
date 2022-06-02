using RazorPagesLearning.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesLearning.Services
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();
        public void add_new_event(string description, string EventName, string? photoPath, int? PosX=50, int? PosY=50);
    }
}
