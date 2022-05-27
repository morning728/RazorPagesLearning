using RazorPagesLearning.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPagesLearning.Services
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();
    }
}
